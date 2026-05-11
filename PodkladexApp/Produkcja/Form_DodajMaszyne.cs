using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_DodajMaszyne : Form
    {
        PodkladexContext context;
        int btn; // 1 - Dodawanie, 2 - Edycja
        private Maszyna istniejącaMaszyna;
        private readonly DateOnly MIN_VALID_DATE = new DateOnly(1753, 1, 1);

        // Konstruktor dla Dodawania
        public Form_DodajMaszyne(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            btn = 1;
            label_tytul.Text = "Dodaj nową maszynę";

            Initialize_cmb();
            SetupDateControls();
        }

        // Konstruktor dla Edycji
        public Form_DodajMaszyne(PodkladexContext context, Maszyna maszyna)
        {
            InitializeComponent();
            this.context = context;
            this.istniejącaMaszyna = maszyna;
            btn = 2;
            label_tytul.Text = "Edytuj maszynę";

            Initialize_cmb();
            SetupDateControls();
            LoadMachineData();
        }

        private void Initialize_cmb()
        {
            var typy = context.Typ.ToList();
            cmb_typ.DataSource = typy;
            cmb_typ.DisplayMember = "Nazwa";
            cmb_typ.ValueMember = "IdTyp";
        }

        private void SetupDateControls()
        {
            dtp_dataZakup.CustomFormat = "dd-MM-yyyy";
            dtp_dataUruch.CustomFormat = "dd-MM-yyyy";
            dtp_dataWyl.CustomFormat = "dd-MM-yyyy";

            cb_dataZa.CheckedChanged += (s, e) => {
                dtp_dataZakup.Enabled = cb_dataZa.Checked;
                UpdateChronologyLogic();
            };
            cb_dataUr.CheckedChanged += (s, e) => {
                dtp_dataUruch.Enabled = cb_dataUr.Checked;
                UpdateChronologyLogic();
            };
            cb_dataWy.CheckedChanged += (s, e) => {
                dtp_dataWyl.Enabled = cb_dataWy.Checked;
            };

            if (btn == 1)
            {
                cb_dataZa.Checked = true;
                cb_dataUr.Checked = false;
                cb_dataWy.Checked = false;
                UpdateChronologyLogic();
            }
        }

        private void UpdateChronologyLogic()
        {
            // Można dodać datę uruchomienia tylko jeśli zaznaczono zakup
            cb_dataUr.Enabled = cb_dataZa.Checked;
            if (!cb_dataZa.Checked) cb_dataUr.Checked = false;

            // Można dodać datę wyłączenia tylko jeśli zaznaczono uruchomienie
            cb_dataWy.Enabled = cb_dataUr.Checked;
            if (!cb_dataUr.Checked) cb_dataWy.Checked = false;
        }

        // Bezpieczne przypisywanie daty do DateTimePicker (rozwiązuje błąd 0001-01-01)
        private void SafeSetDtpValue(DateTimePicker dtp, CheckBox cb, DateOnly date)
        {
            if (date > MIN_VALID_DATE)
            {
                dtp.Value = date.ToDateTime(TimeOnly.MinValue);
                cb.Checked = true;

                // Blokuj tylko jeśli rekord ma już przypisane te dane
                cb.Enabled = false;
                dtp.Enabled = false;
            }
            else
            {
                dtp.Value = DateTime.Now < dtp.MinDate ? dtp.MinDate : DateTime.Now;
                cb.Checked = false;
                cb.Enabled = true;
            }
        }

        private void LoadMachineData()
        {
            txtbox_Nazwa.Text = istniejącaMaszyna.Nazwa;
            txtbox_uwagi.Text = istniejącaMaszyna.Uwagi;

            // Zawsze edytowalne
            txtbox_Nazwa.ReadOnly = false;

            // Blokada typu jeśli przypisany
            var powiazanie = context.MaszynaTyp.AsNoTracking().FirstOrDefault(mt => mt.IdMaszyna == istniejącaMaszyna.IdMaszyna);
            if (powiazanie != null)
            {
                cmb_typ.SelectedValue = powiazanie.IdTyp;
                cmb_typ.Enabled = false;
            }

            // Bezpieczne ładowanie dat
            SafeSetDtpValue(dtp_dataZakup, cb_dataZa, istniejącaMaszyna.DataZakupu);
            SafeSetDtpValue(dtp_dataUruch, cb_dataUr, istniejącaMaszyna.DataUruchomienia);

            if (istniejącaMaszyna.DataWylaczenia.HasValue)
            {
                SafeSetDtpValue(dtp_dataWyl, cb_dataWy, istniejącaMaszyna.DataWylaczenia.Value);
            }
            else
            {
                cb_dataWy.Checked = false;
                cb_dataWy.Enabled = true;
            }

            UpdateChronologyLogic();
        }

        private void btn_Zapisz_Click(object sender, EventArgs e)
        {
            string nowaNazwa = txtbox_Nazwa.Text.Trim();
            if (string.IsNullOrEmpty(nowaNazwa))
            {
                MessageBox.Show("Nazwa maszyny nie może być pusta.", "Błąd");
                return;
            }

            // Walidacja unikalności nazwy
            bool nazwaIstnieje = context.Maszyna.Any(m =>
                m.Nazwa.ToLower() == nowaNazwa.ToLower() &&
                (btn == 1 || m.IdMaszyna != istniejącaMaszyna.IdMaszyna));

            if (nazwaIstnieje)
            {
                MessageBox.Show("Maszyna o takiej nazwie już istnieje.", "Błąd");
                return;
            }

            // Walidacja chronologii
            if (cb_dataZa.Checked && cb_dataUr.Checked && dtp_dataUruch.Value.Date < dtp_dataZakup.Value.Date)
            {
                MessageBox.Show("Data uruchomienia nie może być wcześniejsza niż data zakupu.", "Błąd");
                return;
            }

            if (cb_dataUr.Checked && cb_dataWy.Checked && dtp_dataWyl.Value.Date < dtp_dataUruch.Value.Date)
            {
                MessageBox.Show("Data wyłączenia nie może być wcześniejsza niż data uruchomienia.", "Błąd");
                return;
            }

            Maszyna maszyna = (btn == 1) ? new Maszyna() : context.Maszyna.Find(istniejącaMaszyna.IdMaszyna);

            maszyna.Nazwa = nowaNazwa;
            maszyna.Uwagi = txtbox_uwagi.Text;

            // Przypisanie dat
            if (cb_dataZa.Checked) maszyna.DataZakupu = DateOnly.FromDateTime(dtp_dataZakup.Value);
            if (cb_dataUr.Checked) maszyna.DataUruchomienia = DateOnly.FromDateTime(dtp_dataUruch.Value);

            if (cb_dataWy.Checked)
                maszyna.DataWylaczenia = DateOnly.FromDateTime(dtp_dataWyl.Value);
            else
                maszyna.DataWylaczenia = null;

            if (btn == 1)
            {
                if (cmb_typ.SelectedItem == null) { MessageBox.Show("Wybierz typ!"); return; }
                context.Maszyna.Add(maszyna);
                context.SaveChanges();

                var mt = new MaszynaTyp { IdMaszyna = maszyna.IdMaszyna, IdTyp = (int)cmb_typ.SelectedValue };
                context.MaszynaTyp.Add(mt);
            }

            context.SaveChanges();
            MessageBox.Show("Zapisano pomyślnie.");
            this.Close();
        }
    }
}
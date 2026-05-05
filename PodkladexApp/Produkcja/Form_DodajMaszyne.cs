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

namespace PodkladexApp
{
    public partial class Form_DodajMaszyne : Form
    {
        PodkladexContext context;
        int btn;
        private Maszyna istniejącaMaszyna; // przechowuje maszynę przekazaną do edycji

        public Form_DodajMaszyne(PodkladexContext context, string Nazwa, Maszyna maszyna)
        {
            InitializeComponent();
            this.context = context;
            dtp_dataUruch.CustomFormat = "dd-MM-yyyy";
            dtp_dataZakup.CustomFormat = "dd-MM-yyyy";
            dtp_dataWyl.CustomFormat = "dd-MM-yyyy";

            btn = 2;
            label_tytul.Text = "Edytuj maszynę";
            txtbox_Nazwa.Text = maszyna.Nazwa;
            txtbox_Nazwa.ReadOnly = true;
            dtp_dataUruch.Value = maszyna.DataUruchomienia.ToDateTime(TimeOnly.MinValue);
            dtp_dataUruch.Enabled = false;
            dtp_dataZakup.Value = maszyna.DataZakupu.ToDateTime(TimeOnly.MinValue);
            dtp_dataZakup.Enabled = false;
            dtp_dataWyl.Enabled = true;
            cmb_typ.Enabled = false;

            // zapamiętujemy przekazaną maszynę do późniejszej edycji
            istniejącaMaszyna = maszyna;

            LoadTypy();

            // jeśli maszyna ma przypisany typ, ustaw go w combo (opcjonalne)
            var powiazanie = context.MaszynaTyp.FirstOrDefault(mt => mt.IdMaszyna == maszyna.IdMaszyna);
            if (powiazanie != null)
            {
                cmb_typ.SelectedValue = powiazanie.IdTyp;
            }
            // przy edycji nie dodajemy nowego powiązania typu
        }

        public Form_DodajMaszyne(PodkladexContext context, string buttonName)
        {
            InitializeComponent();
            this.context = context;
            dtp_dataUruch.CustomFormat = "dd-MM-yyyy";
            dtp_dataZakup.CustomFormat = "dd-MM-yyyy";
            dtp_dataWyl.CustomFormat = "dd-MM-yyyy";

            btn = 1;
            label_tytul.Text = "Dodaj maszynę";
            dtp_dataWyl.Enabled = false;

            LoadTypy();
        }

        private void LoadTypy()
        {
            // ładuje typy do combo; wyświetla Nazwa, wartość to IdTyp
            var typy = context.Typ.OrderBy(t => t.Nazwa).ToList();
            cmb_typ.DisplayMember = "Nazwa";
            cmb_typ.ValueMember = "IdTyp";
            cmb_typ.DataSource = typy;
            cmb_typ.SelectedIndex = -1;
        }

        private void btn_funkcja_Click(object sender, EventArgs e)
        {
            if (txtbox_Nazwa.Text == "" || txtbox_Nazwa.Text == null)
            {
                MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");
                return;
            }

            if (btn == 1 && context.Maszyna.Where(m => m.Nazwa == txtbox_Nazwa.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Nazwa jest zajeta! Wpisz inną nazwę.", "Błąd");
                return;
            }

            if (btn == 2)
            {
                // edycja istniejącej maszyny - odszukaj po Id i zaktualizuj DataWylaczenia oraz opcjonalnie Uwagi
                if (istniejącaMaszyna == null)
                {
                    MessageBox.Show("Brak danych maszyny do edycji.", "Błąd");
                    return;
                }

                var dbMaszyna = context.Maszyna.FirstOrDefault(m => m.IdMaszyna == istniejącaMaszyna.IdMaszyna);
                if (dbMaszyna == null)
                {
                    MessageBox.Show("Nie odnaleziono maszyny w bazie.", "Błąd");
                    return;
                }

                dbMaszyna.DataWylaczenia = DateOnly.FromDateTime(dtp_dataWyl.Value);

                // zaktualizuj Uwagi tylko gdy pole nie jest puste
                if (!string.IsNullOrWhiteSpace(txtbox_uwagi.Text))
                {
                    dbMaszyna.Uwagi = txtbox_uwagi.Text;
                }

                context.SaveChanges();
                MessageBox.Show("Zaktualizowano maszynę!", "Edycja maszyny");
                this.FindForm().Close();
                return;
            }

            // dodawanie nowej maszyny
            Maszyna nowaMaszyna = new Maszyna
            {
                Nazwa = txtbox_Nazwa.Text,
                DataUruchomienia = DateOnly.FromDateTime(dtp_dataUruch.Value),
                DataZakupu = DateOnly.FromDateTime(dtp_dataZakup.Value),
                Uwagi = txtbox_uwagi.Text,
                DataWylaczenia = null
            };

            if (btn == 2)
            {
                nowaMaszyna.DataWylaczenia = DateOnly.FromDateTime(dtp_dataWyl.Value);
            }

            // jeśli dodajemy nową maszynę, wymagamy wyboru typu
            if (btn == 1 && cmb_typ.SelectedItem == null)
            {
                MessageBox.Show("Wybierz typ maszyny.", "Błąd");
                return;
            }

            context.Maszyna.Add(nowaMaszyna);
            context.SaveChanges(); // zapisujemy maszynę, aby uzyskać IdMaszyna

            // jeśli to dodawanie nowej maszyny, utwórz powiązanie MaszynaTyp
            if (btn == 1 && cmb_typ.SelectedItem != null)
            {
                int wybranyIdTyp = (int)cmb_typ.SelectedValue;
                var powiazanie = new MaszynaTyp
                {
                    IdMaszyna = nowaMaszyna.IdMaszyna,
                    IdTyp = wybranyIdTyp
                };
                context.MaszynaTyp.Add(powiazanie);
                context.SaveChanges();
            }

            MessageBox.Show("Dodano nową maszynę!", "Dodawanie maszyny");
            this.FindForm().Close();
        }
    }
}

using PodkladexApp.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PodkladexApp.Produkcja
{
    public partial class Form_ProdukcjaZaplanujPodform : Form
    {
        PodkladexContext db;
        int? selectedIdZamowienie;

        public Form_ProdukcjaZaplanujPodform(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;
            this.selectedIdZamowienie = null;
            InitializeBaseLogic();
        }

        public Form_ProdukcjaZaplanujPodform(PodkladexContext db, int idZamowienie)
        {
            InitializeComponent();
            this.db = db;
            this.selectedIdZamowienie = idZamowienie;
            this.Text = $"Planowanie produkcji - Zamówienie {idZamowienie}";

            LoadProductsForOrder(selectedIdZamowienie);
            InitializeBaseLogic();
        }

        private void InitializeBaseLogic()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            if (dtp != null)
            {
                dtp.ValueChanged += Dtp_Data_ValueChanged;
            }

            LoadAvailableMachines();
            LoadAvailableWorkers();
            WireMachineAndGridEvents();
        }

        private void LoadProductsForOrder(int? idZam)
        {
            if (idZam == null) return;

            var products = db.SzczegolyZamowienia
                .AsNoTracking()
                .Where(s => s.IdZamowienie == idZam.Value)
                .Select(s => new
                {
                    s.IdSzczegolyZamowienia,
                    s.IdProdukt,
                    Produkt = s.IdProduktNavigation.Nazwa,
                    Ilosc = s.Ilosc +
                            (db.Produkcja.Where(p => p.IdNormyPNavigation.IdProdukt == s.IdProdukt && p.IdZadaniePNavigation.IdZamowienie == idZam).Sum(p => p.Odpady) ?? 0) -
                            (db.Produkcja.Where(p => p.IdNormyPNavigation.IdProdukt == s.IdProdukt && p.IdZadaniePNavigation.IdZamowienie == idZam).Sum(p => p.Wyprodukowano) ?? 0),
                    s.IdMaterial,
                    Material = s.IdMaterialNavigation.Nazwa
                })
                .ToList();

            var dgvProdukty = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            if (dgvProdukty != null)
            {
                dgvProdukty.DataSource = products;
                dgvProdukty.Columns["IdSzczegolyZamowienia"].Visible = false;
                dgvProdukty.Columns["IdProdukt"].Visible = false;
                dgvProdukty.Columns["IdMaterial"].Visible = false;
            }
        }

        private void LoadAvailableMachines()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmb = Controls.Find("cmb_Maszyny", true).FirstOrDefault() as ComboBox;
            if (dtp == null || cmb == null) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            var busyIds = db.ZadanieProdukcyjne.Where(z => z.DataZadania == selectedDate).Select(z => z.IdMaszyna)
                .Union(db.Obsluga.Where(o => o.DataPoczatek <= selectedDate && (o.DataKoniec == null || o.DataKoniec >= selectedDate)).Select(o => o.IdMaszyna))
                .Distinct().ToList();

            var available = db.Maszyna
                .Where(m => !busyIds.Contains(m.IdMaszyna))
                .Select(m => new { m.IdMaszyna, m.Nazwa })
                .ToList();

            cmb.DisplayMember = "Nazwa";
            cmb.ValueMember = "IdMaszyna";
            cmb.DataSource = available;
            cmb.SelectedIndex = -1;
        }

        private void LoadAvailableWorkers()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmb = Controls.Find("cmb_pracownik", true).FirstOrDefault() as ComboBox;
            if (dtp == null || cmb == null) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);
            var busyPracownicy = db.Produkcja.Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate).Select(p => p.IdPracownik).ToList();

            var available = db.Pracownik
                .Where(p => !busyPracownicy.Contains(p.IdPracownik))
                .Select(p => new { p.IdPracownik, FullName = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();

            cmb.DisplayMember = "FullName";
            cmb.ValueMember = "IdPracownik";
            cmb.DataSource = available;
            cmb.SelectedIndex = -1;
        }

        private void LoadAvailableEquipment()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmbWyp = Controls.Find("cmb_wyp", true).FirstOrDefault() as ComboBox;
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;

            if (dtp == null || cmbWyp == null || dgv?.SelectedRows.Count == 0) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            // 1. Identyfikujemy wyposażenie, które jest JUŻ ZAJĘTE w tym dniu.
            // Łączymy Produkcję z Zadaniem (żeby mieć datę) i z MaszynaWyp (żeby wiedzieć, jakie to narzędzie).
            var busyEquipmentIds = db.Produkcja
                .AsNoTracking()
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .Join(db.MaszynaWyp,
                      p => new { p.IdZadaniePNavigation.IdMaszyna, IdNormaP = p.IdNormyP },
                      mw => new { mw.IdMaszyna, mw.IdNormaP },
                      (p, mw) => mw.IdWyposazenie)
                .Distinct()
                .ToList();

            // 2. Pobieramy z bazy WSZYSTKIE rekordy wyposażenia, których nie ma na liście "busy".
            var available = db.Wyposazenie
                .AsNoTracking()
                .Where(w => !busyEquipmentIds.Contains(w.IdWyposazenie))
                .Select(w => new { w.IdWyposazenie, w.Nazwa })
                .OrderBy(w => w.Nazwa)
                .ToList();

            // 3. Odświeżamy ComboBox
            cmbWyp.DataSource = null; // Czyścimy przed przypisaniem nowego źródła
            cmbWyp.DisplayMember = "Nazwa";
            cmbWyp.ValueMember = "IdWyposazenie";
            cmbWyp.DataSource = available;
            cmbWyp.SelectedIndex = -1;
        }

        private void WireMachineAndGridEvents()
        {
            var cmbMasz = Controls.Find("cmb_Maszyny", true).FirstOrDefault() as ComboBox;
            var cmbPrac = Controls.Find("cmb_pracownik", true).FirstOrDefault() as ComboBox;
            var cmbWyp = Controls.Find("cmb_wyp", true).FirstOrDefault() as ComboBox;
            var dgvProdukty = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            var btn = Controls.Find("btn_zapisz", true).FirstOrDefault() as Button;

            if (dgvProdukty != null) dgvProdukty.SelectionChanged += (s, e) => {
                RecalculateDoWyprod();
                if (cmbWyp != null) cmbWyp.DataSource = null;
            };

            if (cmbMasz != null)
            {
                cmbMasz.DropDown += (s, e) => UpdateMachineInfoGrid();
                cmbMasz.SelectedIndexChanged += (s, e) => {
                    RecalculateDoWyprod();
                    if (cmbWyp != null) cmbWyp.DataSource = null;
                };
            }

            if (cmbPrac != null) cmbPrac.DropDown += (s, e) => UpdateWorkerInfoGrid();
            if (cmbWyp != null) cmbWyp.DropDown += (s, e) => LoadAvailableEquipment();
            if (txtRbh != null) txtRbh.TextChanged += (s, e) => RecalculateDoWyprod();
            if (btn != null) btn.Click += Btn_zapisz_Click;
        }

        private void UpdateMachineInfoGrid()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var dtgInfo = Controls.Find("dtg_info", true).FirstOrDefault() as DataGridView;
            if (dtp == null || dtgInfo == null) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);
            var rbhSums = db.Produkcja
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .GroupBy(p => p.IdZadaniePNavigation.IdMaszyna)
                .Select(g => new { IdMaszyna = g.Key, Suma = g.Sum(x => x.Rbh) })
                .ToDictionary(k => k.IdMaszyna, v => v.Suma);

            var data = db.Maszyna.AsNoTracking().ToList().Select(m => new {
                m.Nazwa,
                Data = selectedDate,
                SumaRBH = rbhSums.ContainsKey(m.IdMaszyna) ? rbhSums[m.IdMaszyna] : 0m
            }).OrderBy(x => x.Nazwa).ToList();

            dtgInfo.DataSource = data;
        }

        private void UpdateWorkerInfoGrid()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var dtgInfo = Controls.Find("dtg_info", true).FirstOrDefault() as DataGridView;
            if (dtp == null || dtgInfo == null) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);
            var rbhSums = db.Produkcja
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .GroupBy(p => p.IdPracownik)
                .Select(g => new { IdPracownik = g.Key, Suma = g.Sum(x => x.Rbh) })
                .ToDictionary(k => k.IdPracownik, v => v.Suma);

            var data = db.Pracownik.Include(p => p.IdOsobaNavigation).AsNoTracking().ToList().Select(p => new {
                Pracownik = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko,
                Data = selectedDate,
                SumaRBH = rbhSums.ContainsKey(p.IdPracownik) ? rbhSums[p.IdPracownik] : 0m
            }).OrderBy(x => x.Pracownik).ToList();

            dtgInfo.DataSource = data;
        }

        private void Dtp_Data_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableMachines();
            LoadAvailableWorkers();
            var dtgInfo = Controls.Find("dtg_info", true).FirstOrDefault() as DataGridView;
            var cmbWyp = Controls.Find("cmb_wyp", true).FirstOrDefault() as ComboBox;
            if (dtgInfo != null) dtgInfo.DataSource = null;
            if (cmbWyp != null) cmbWyp.DataSource = null;
        }

        private void RecalculateDoWyprod()
        {
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            var txtDo = Controls.Find("txt_doWyprod", true).FirstOrDefault() as TextBox;

            if (dgv?.SelectedRows.Count > 0 && decimal.TryParse(txtRbh.Text, out decimal rbh))
            {
                int idP = (int)dgv.SelectedRows[0].Cells["IdProdukt"].Value;
                int idM = (int)dgv.SelectedRows[0].Cells["IdMaterial"].Value;
                var norma = db.NormaProd.FirstOrDefault(n => n.IdProdukt == idP && n.IdMaterial == idM);

                if (norma != null && norma.Czas != 0)
                    txtDo.Text = (rbh * (norma.Ilosc / norma.Czas)).ToString("N2");
            }
        }

        private void Btn_zapisz_Click(object sender, EventArgs e)
        {
            var cmbMasz = Controls.Find("cmb_Maszyny", true).FirstOrDefault() as ComboBox;
            var cmbPrac = Controls.Find("cmb_pracownik", true).FirstOrDefault() as ComboBox;
            var cmbWyp = Controls.Find("cmb_wyp", true).FirstOrDefault() as ComboBox;
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;

            if (selectedIdZamowienie != null && cmbMasz.SelectedValue != null && cmbPrac.SelectedValue != null && cmbWyp.SelectedValue != null && dgv.SelectedRows.Count > 0)
            {
                var zadanie = new ZadanieProdukcyjne
                {
                    IdMaszyna = (int)cmbMasz.SelectedValue,
                    DataZadania = DateOnly.FromDateTime(dtp.Value.Date),
                    IdZamowienie = selectedIdZamowienie.Value
                };
                db.ZadanieProdukcyjne.Add(zadanie);
                db.SaveChanges();

                int idP = (int)dgv.SelectedRows[0].Cells["IdProdukt"].Value;
                int idM = (int)dgv.SelectedRows[0].Cells["IdMaterial"].Value;
                var norma = db.NormaProd.First(n => n.IdProdukt == idP && n.IdMaterial == idM);

                db.Produkcja.Add(new Models.Produkcja
                {
                    IdPracownik = (int)cmbPrac.SelectedValue,
                    Rbh = decimal.Parse(txtRbh.Text),
                    IdZadanieP = zadanie.IdZadanieP,
                    IdNormyP = norma.IdNormaP
                });

                db.SaveChanges();
                MessageBox.Show("Zadanie produkcyjne zostało zaplanowane.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola (Maszyna, Pracownik, Wyposażenie) oraz wybrać produkt.");
            }
        }
    }
}
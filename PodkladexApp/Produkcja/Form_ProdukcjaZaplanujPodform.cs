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

            var productsQuery = db.SzczegolyZamowienia
                .AsNoTracking()
                .Where(s => s.IdZamowienie == idZam.Value)
                .Select(s => new
                {
                    s.IdSzczegolyZamowienia,
                    s.IdProdukt,
                    Produkt = s.IdProduktNavigation.Nazwa,
                    RawIlosc = (decimal)s.Ilosc +
                            (db.Produkcja.Where(p => p.IdNormyPNavigation.IdProdukt == s.IdProdukt && p.IdZadaniePNavigation.IdZamowienie == idZam).Sum(p => p.Odpady) ?? 0) -
                            (db.Produkcja.Where(p => p.IdNormyPNavigation.IdProdukt == s.IdProdukt && p.IdZadaniePNavigation.IdZamowienie == idZam).Sum(p => p.Wyprodukowano) ?? 0) -
                            (db.Produkcja.Where(p => p.IdNormyPNavigation.IdProdukt == s.IdProdukt && p.IdZadaniePNavigation.IdZamowienie == idZam)
                                         .Sum(p => p.Rbh * (p.IdNormyPNavigation.Ilosc / (p.IdNormyPNavigation.Czas != 0 ? p.IdNormyPNavigation.Czas : 1)))),
                    s.IdMaterial,
                    Material = s.IdMaterialNavigation.Nazwa
                })
                .ToList();

            var products = productsQuery.Select(x => new {
                x.IdSzczegolyZamowienia,
                x.IdProdukt,
                x.Produkt,
                Ilosc = x.RawIlosc < 0 ? 0m : x.RawIlosc,
                x.IdMaterial,
                x.Material
            }).ToList();

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

            var authorizedWorkers = db.Pracownik
                .Where(p =>
                    p.Umowa.Any(u => u.DataRoz <= selectedDate && u.DataZak >= selectedDate) &&
                    !p.WniosekUrlopowy.Any(url => url.StatusWniosku == true && url.DataRozp <= selectedDate && url.DataZak >= selectedDate) &&
                    !p.ZwolnienieLekarskie.Any(z => z.DataPoczatek <= selectedDate && z.DataKoniec >= selectedDate) &&
                    p.BadanieMedyczne.Any(b => (b.IdTypBadaniaMed == 1 || b.IdTypBadaniaMed == 2 || b.IdTypBadaniaMed == 3) && (b.DataWaznosci == null || b.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 1 || s.IdSzkolenia == 2) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 6 || s.IdSzkolenia == 7) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate))
                );

            var busyPracownicy = db.Produkcja.Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate).Select(p => p.IdPracownik).ToList();

            var available = authorizedWorkers
                .Where(p => !busyPracownicy.Contains(p.IdPracownik))
                .Select(p => new { p.IdPracownik, FullName = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();

            cmb.DisplayMember = "FullName";
            cmb.ValueMember = "IdPracownik";
            cmb.DataSource = available;
            cmb.SelectedIndex = -1;
        }

        private void WireMachineAndGridEvents()
        {
            var cmbMasz = Controls.Find("cmb_Maszyny", true).FirstOrDefault() as ComboBox;
            var cmbPrac = Controls.Find("cmb_pracownik", true).FirstOrDefault() as ComboBox;
            var cmbWyp = Controls.Find("cmb_wyp", true).FirstOrDefault() as ComboBox;
            var dgvProdukty = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            var btn = Controls.Find("btn_zapisz", true).FirstOrDefault() as Button;

            if (dgvProdukty != null)
            {
                dgvProdukty.SelectionChanged += (s, e) => {
                    RecalculateDoWyprod(true); // true oznacza wywołanie przy zmianie selekcji
                    if (cmbWyp != null) cmbWyp.DataSource = null;
                };
            }

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

            var authorizedWorkersQuery = db.Pracownik
                .Where(p =>
                    p.Umowa.Any(u => u.DataRoz <= selectedDate && u.DataZak >= selectedDate) &&
                    !p.WniosekUrlopowy.Any(url => url.StatusWniosku == true && url.DataRozp <= selectedDate && url.DataZak >= selectedDate) &&
                    !p.ZwolnienieLekarskie.Any(z => z.DataPoczatek <= selectedDate && z.DataKoniec >= selectedDate) &&
                    p.BadanieMedyczne.Any(b => (b.IdTypBadaniaMed == 1 || b.IdTypBadaniaMed == 2 || b.IdTypBadaniaMed == 3) && (b.DataWaznosci == null || b.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 1 || s.IdSzkolenia == 2) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 6 || s.IdSzkolenia == 7) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate))
                );

            var rbhSums = db.Produkcja
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .GroupBy(p => p.IdPracownik)
                .Select(g => new { IdPracownik = g.Key, Suma = g.Sum(x => x.Rbh) })
                .ToDictionary(k => k.IdPracownik, v => v.Suma);

            var data = authorizedWorkersQuery.Include(p => p.IdOsobaNavigation).AsNoTracking().ToList().Select(p => new {
                Pracownik = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko,
                Data = selectedDate,
                SumaRBH = rbhSums.ContainsKey(p.IdPracownik) ? rbhSums[p.IdPracownik] : 0m
            }).OrderBy(x => x.Pracownik).ToList();

            dtgInfo.DataSource = data;
        }

        private void LoadAvailableEquipment()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmbWyp = Controls.Find("cmb_wyp", true).FirstOrDefault() as ComboBox;
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;

            if (dtp == null || cmbWyp == null || dgv?.SelectedRows.Count == 0) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            var busyEquipmentIds = db.Produkcja
                .AsNoTracking()
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .Join(db.MaszynaWyp,
                      p => new { p.IdZadaniePNavigation.IdMaszyna, IdNormaP = p.IdNormyP },
                      mw => new { mw.IdMaszyna, mw.IdNormaP },
                      (p, mw) => mw.IdWyposazenie)
                .Distinct()
                .ToList();

            var available = db.Wyposazenie
                .AsNoTracking()
                .Where(w => !busyEquipmentIds.Contains(w.IdWyposazenie))
                .Select(w => new { w.IdWyposazenie, w.Nazwa })
                .OrderBy(w => w.Nazwa)
                .ToList();

            cmbWyp.DataSource = null;
            cmbWyp.DisplayMember = "Nazwa";
            cmbWyp.ValueMember = "IdWyposazenie";
            cmbWyp.DataSource = available;
            cmbWyp.SelectedIndex = -1;
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

        private void RecalculateDoWyprod(bool fromSelection = false)
        {
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            var txtDo = Controls.Find("txt_doWyprod", true).FirstOrDefault() as TextBox;

            if (dgv?.SelectedRows.Count == 0 || txtRbh == null || txtDo == null) return;

            var row = dgv.SelectedRows[0];
            int idP = (int)row.Cells["IdProdukt"].Value;
            int idM = (int)row.Cells["IdMaterial"].Value;
            var norma = db.NormaProd.FirstOrDefault(n => n.IdProdukt == idP && n.IdMaterial == idM);

            if (norma == null || norma.Czas == 0 || norma.Ilosc == 0) return;

            // Zadanie 1: Sugerowanie RBH po wybraniu produktu (z limitem 8h)
            if (fromSelection)
            {
                decimal iloscZGrid = Convert.ToDecimal(row.Cells["Ilosc"].Value);
                decimal sugerowaneRbh = iloscZGrid * (norma.Czas / norma.Ilosc);
                if (sugerowaneRbh > 8) sugerowaneRbh = 8;
                txtRbh.Text = sugerowaneRbh.ToString("N2");
            }

            // Zadanie 2: Zabezpieczenie przed wartością > 8 (niezależnie od źródła)
            if (decimal.TryParse(txtRbh.Text, out decimal rbh))
            {
                if (rbh > 8)
                {
                    rbh = 8;
                    txtRbh.Text = "8,00"; // Automatyczna korekta do limitu
                }

                // Obliczanie ilości do wyprodukowania
                decimal wynik = rbh * (norma.Ilosc / norma.Czas);
                txtDo.Text = wynik.ToString("N2");

                // Sprawdzenie stanu magazynowego (Twoja poprawiona logika)
                var stanMagazynu = db.AktualnyStanMagazynu.AsNoTracking().FirstOrDefault(m => m.IdMaterial == idM);
                decimal aktualnyStan = stanMagazynu?.AktualnyStan ?? 0m;

                if (!(wynik < aktualnyStan))
                {
                    MessageBox.Show($"Ostrzeżenie: Niewystarczająca ilość materiału w magazynie! \nSzacowana produkcja: {wynik:N2}, Dostępna ilość materiału: {aktualnyStan:N2}", "Brak materiału", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
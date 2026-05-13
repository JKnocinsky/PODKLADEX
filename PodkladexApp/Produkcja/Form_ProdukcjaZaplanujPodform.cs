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
                            (db.KontrolaProd.Where(k => k.IdZadaniePNavigation.IdZamowienie == idZam && db.Produkcja.Any(p => p.IdZadanieP == k.IdZadanieP && p.IdNormyPNavigation.IdProdukt == s.IdProdukt)).Sum(k => k.Odpady) ?? 0) -
                            (db.Produkcja.Where(p => p.IdNormyPNavigation.IdProdukt == s.IdProdukt && p.IdZadaniePNavigation.IdZamowienie == idZam).Sum(p => p.Wyprodukowano) ?? 0) -
                            (db.Produkcja.Where(p => p.IdNormyPNavigation.IdProdukt == s.IdProdukt && p.IdZadaniePNavigation.IdZamowienie == idZam && p.Wyprodukowano == null)
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

            var prodRbh = db.Produkcja
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .GroupBy(p => p.IdZadaniePNavigation.IdMaszyna)
                .Select(g => new { Id = g.Key, Sum = g.Sum(p => p.Rbh) })
                .ToDictionary(x => x.Id, x => x.Sum);

            var maintenanceIds = db.Obsluga
                .Where(o => o.DataPoczatek <= selectedDate && (o.DataKoniec == null || o.DataKoniec >= selectedDate))
                .Select(o => o.IdMaszyna)
                .Distinct()
                .ToList();

            var available = db.Maszyna
                .AsEnumerable()
                .Where(m => {
                    decimal totalRbh = maintenanceIds.Contains(m.IdMaszyna) ? 8m : 0m;
                    if (prodRbh.ContainsKey(m.IdMaszyna)) totalRbh += prodRbh[m.IdMaszyna];
                    return totalRbh < 8;
                })
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

            var prodRbh = db.Produkcja
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .GroupBy(p => p.IdPracownik)
                .Select(g => new { Id = g.Key, Sum = g.Sum(p => p.Rbh) })
                .ToDictionary(x => x.Id, x => x.Sum);

            var ctrlProdRbh = db.KontrolaProd
                .Where(k => k.IdZadaniePNavigation.DataZadania == selectedDate)
                .GroupBy(k => k.IdPracownik)
                .Select(g => new { Id = g.Key, Sum = g.Sum(k => k.Rbh ?? 0) })
                .ToDictionary(x => x.Id, x => x.Sum);

            var ctrlMatRbh = db.KontrolaMat
                .Where(k => k.IdZadaniePNavigation.DataZadania == selectedDate)
                .GroupBy(k => k.IdPracownik)
                .Select(g => new { Id = g.Key, Sum = g.Sum(k => k.Rbh ?? 0) })
                .ToDictionary(x => x.Id, x => x.Sum);

            var maintenanceIds = db.Obsluga
                .Where(o => o.DataPoczatek <= selectedDate && (o.DataKoniec == null || o.DataKoniec >= selectedDate))
                .Select(o => o.IdPracownik)
                .Distinct()
                .ToList();

            var authorizedWorkers = db.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Where(p =>
                    p.Umowa.Any(u => u.DataRoz <= selectedDate && u.DataZak >= selectedDate) &&
                    !p.WniosekUrlopowy.Any(url => url.StatusWniosku == true && url.DataRozp <= selectedDate && url.DataZak >= selectedDate) &&
                    !p.ZwolnienieLekarskie.Any(z => z.DataPoczatek <= selectedDate && z.DataKoniec >= selectedDate) &&
                    p.BadanieMedyczne.Any(b => (b.IdTypBadaniaMed == 1 || b.IdTypBadaniaMed == 2 || b.IdTypBadaniaMed == 3) && (b.DataWaznosci == null || b.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 1 || s.IdSzkolenia == 2) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 6 || s.IdSzkolenia == 7) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate))
                );

            var available = authorizedWorkers
                .AsEnumerable()
                .Where(p => {
                    decimal total = maintenanceIds.Contains(p.IdPracownik) ? 8m : 0m;
                    if (prodRbh.ContainsKey(p.IdPracownik)) total += prodRbh[p.IdPracownik];
                    if (ctrlProdRbh.ContainsKey(p.IdPracownik)) total += ctrlProdRbh[p.IdPracownik];
                    if (ctrlMatRbh.ContainsKey(p.IdPracownik)) total += ctrlMatRbh[p.IdPracownik];
                    return total < 8;
                })
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
                    RecalculateDoWyprod(true);
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

            // Zadanie 1: Obsługa dropdown dla wyposażenia
            if (cmbWyp != null)
            {
                cmbWyp.DropDown += (s, e) => {
                    LoadAvailableEquipment();
                    UpdateEquipmentInfoGrid();
                };
            }

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

            var maintenanceIds = db.Obsluga.Where(o => o.DataPoczatek <= selectedDate && (o.DataKoniec == null || o.DataKoniec >= selectedDate)).Select(o => o.IdMaszyna).ToList();

            var data = db.Maszyna.AsNoTracking().ToList().Select(m => {
                decimal sum = maintenanceIds.Contains(m.IdMaszyna) ? 8m : 0m;
                if (rbhSums.ContainsKey(m.IdMaszyna)) sum += rbhSums[m.IdMaszyna];
                return new { m.Nazwa, Data = selectedDate, SumaRBH = sum };
            }).OrderBy(x => x.Nazwa).ToList();

            dtgInfo.DataSource = data;
            // Zadanie 3: Poprawa nagłówka
            if (dtgInfo.Columns.Contains("SumaRBH"))
                dtgInfo.Columns["SumaRBH"].HeaderText = "Suma RBH";
        }

        private void UpdateWorkerInfoGrid()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var dtgInfo = Controls.Find("dtg_info", true).FirstOrDefault() as DataGridView;
            if (dtp == null || dtgInfo == null) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            var authorizedWorkersQuery = db.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Where(p =>
                    p.Umowa.Any(u => u.DataRoz <= selectedDate && u.DataZak >= selectedDate) &&
                    !p.WniosekUrlopowy.Any(url => url.StatusWniosku == true && url.DataRozp <= selectedDate && url.DataZak >= selectedDate) &&
                    !p.ZwolnienieLekarskie.Any(z => z.DataPoczatek <= selectedDate && z.DataKoniec >= selectedDate) &&
                    p.BadanieMedyczne.Any(b => (b.IdTypBadaniaMed == 1 || b.IdTypBadaniaMed == 2 || b.IdTypBadaniaMed == 3) && (b.DataWaznosci == null || b.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 1 || s.IdSzkolenia == 2) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate)) &&
                    p.PracownikSzkolenia.Any(s => (s.IdSzkolenia == 6 || s.IdSzkolenia == 7) && (s.DataWaznosci == null || s.DataWaznosci > selectedDate))
                );

            var prodRbh = db.Produkcja.Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate).GroupBy(p => p.IdPracownik).Select(g => new { Id = g.Key, Sum = g.Sum(x => x.Rbh) }).ToDictionary(k => k.Id, v => v.Sum);
            var ctrlProdRbh = db.KontrolaProd.Where(k => k.IdZadaniePNavigation.DataZadania == selectedDate).GroupBy(k => k.IdPracownik).Select(g => new { Id = g.Key, Sum = g.Sum(k => k.Rbh ?? 0) }).ToDictionary(k => k.Id, v => v.Sum);
            var ctrlMatRbh = db.KontrolaMat.Where(k => k.IdZadaniePNavigation.DataZadania == selectedDate).GroupBy(k => k.IdPracownik).Select(g => new { Id = g.Key, Sum = g.Sum(k => k.Rbh ?? 0) }).ToDictionary(k => k.Id, v => v.Sum);
            var maintenanceIds = db.Obsluga.Where(o => o.DataPoczatek <= selectedDate && (o.DataKoniec == null || o.DataKoniec >= selectedDate)).Select(o => o.IdPracownik).ToList();

            var data = authorizedWorkersQuery.AsNoTracking().ToList().Select(p => {
                decimal total = maintenanceIds.Contains(p.IdPracownik) ? 8m : 0m;
                if (prodRbh.ContainsKey(p.IdPracownik)) total += prodRbh[p.IdPracownik];
                if (ctrlProdRbh.ContainsKey(p.IdPracownik)) total += ctrlProdRbh[p.IdPracownik];
                if (ctrlMatRbh.ContainsKey(p.IdPracownik)) total += ctrlMatRbh[p.IdPracownik];
                return new { Pracownik = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko, Data = selectedDate, SumaRBH = total };
            }).OrderBy(x => x.Pracownik).ToList();

            dtgInfo.DataSource = data;
            // Zadanie 3: Poprawa nagłówka
            if (dtgInfo.Columns.Contains("SumaRBH"))
                dtgInfo.Columns["SumaRBH"].HeaderText = "Suma RBH";
        }

        // Zadanie 1: Wyświetlanie sumy RBH dla wyposażenia
        private void UpdateEquipmentInfoGrid()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var dtgInfo = Controls.Find("dtg_info", true).FirstOrDefault() as DataGridView;
            if (dtp == null || dtgInfo == null) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            // Wyliczenie sumy RBH dla wyposażenia przypisanego do produkcji tego dnia
            var equipmentRbh = db.Produkcja
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .Join(db.MaszynaWyp,
                      p => new { p.IdZadaniePNavigation.IdMaszyna, IdNormaP = p.IdNormyP },
                      mw => new { mw.IdMaszyna, mw.IdNormaP },
                      (p, mw) => new { mw.IdWyposazenie, p.Rbh })
                .GroupBy(x => x.IdWyposazenie)
                .Select(g => new { IdWyposazenie = g.Key, Suma = g.Sum(x => x.Rbh) })
                .ToDictionary(k => k.IdWyposazenie, v => v.Suma);

            var data = db.Wyposazenie.AsNoTracking().ToList().Select(e => new {
                e.Nazwa,
                Data = selectedDate,
                SumaRBH = equipmentRbh.ContainsKey(e.IdWyposazenie) ? equipmentRbh[e.IdWyposazenie] : 0m
            }).OrderBy(x => x.Nazwa).ToList();

            dtgInfo.DataSource = data;
            // Zadanie 3: Poprawa nagłówka
            if (dtgInfo.Columns.Contains("SumaRBH"))
                dtgInfo.Columns["SumaRBH"].HeaderText = "Suma RBH";
        }

        private void LoadAvailableEquipment()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmbWyp = Controls.Find("cmb_wyp", true).FirstOrDefault() as ComboBox;
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;

            if (dtp == null || cmbWyp == null || dgv?.SelectedRows.Count == 0) return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            // Pobranie sumy RBH, aby filtrować tylko te poniżej 8h
            var equipmentRbh = db.Produkcja
                .Where(p => p.IdZadaniePNavigation.DataZadania == selectedDate)
                .Join(db.MaszynaWyp,
                      p => new { p.IdZadaniePNavigation.IdMaszyna, IdNormaP = p.IdNormyP },
                      mw => new { mw.IdMaszyna, mw.IdNormaP },
                      (p, mw) => new { mw.IdWyposazenie, p.Rbh })
                .GroupBy(x => x.IdWyposazenie)
                .Select(g => new { Id = g.Key, Sum = g.Sum(x => x.Rbh) })
                .ToDictionary(k => k.Id, v => v.Sum);

            var available = db.Wyposazenie
                .AsNoTracking()
                .AsEnumerable()
                .Where(w => {
                    decimal total = equipmentRbh.ContainsKey(w.IdWyposazenie) ? equipmentRbh[w.IdWyposazenie] : 0m;
                    return total < 8;
                })
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

            if (fromSelection)
            {
                decimal iloscZGrid = Convert.ToDecimal(row.Cells["Ilosc"].Value);
                decimal sugerowaneRbh = iloscZGrid * (norma.Czas / norma.Ilosc);
                if (sugerowaneRbh > 8) sugerowaneRbh = 8;
                txtRbh.Text = sugerowaneRbh.ToString("N2");
            }

            if (decimal.TryParse(txtRbh.Text, out decimal rbh))
            {
                if (rbh > 8) { rbh = 8; txtRbh.Text = "8,00"; }
                decimal wynik = rbh * (norma.Ilosc / norma.Czas);
                txtDo.Text = wynik.ToString("N2");

                var stanMagazynu = db.AktualnyStanMagazynu.AsNoTracking().FirstOrDefault(m => m.IdMaterial == idM);
                decimal aktualnyStan = stanMagazynu?.AktualnyStan ?? 0m;
                if (wynik > aktualnyStan)
                {
                    MessageBox.Show($"Ostrzeżenie: Niewystarczająca ilość materiału! \nSzacowana produkcja: {wynik:N2}, Dostępna ilość: {aktualnyStan:N2}", "Brak materiału", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (!decimal.TryParse(txtRbh.Text, out decimal plannedRbh)) return;
                int workerId = (int)cmbPrac.SelectedValue;
                int machineId = (int)cmbMasz.SelectedValue;
                int equipmentId = (int)cmbWyp.SelectedValue;
                var date = DateOnly.FromDateTime(dtp.Value.Date);

                var today = DateOnly.FromDateTime(DateTime.Today);
                if (date < today)
                {
                    MessageBox.Show("Nie można zaplanować zadania na datę wcześniejszą niż dzisiejsza.", "Błąd daty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Walidacja pracownika
                decimal workerCurrent = (db.Produkcja.Where(p => p.IdZadaniePNavigation.DataZadania == date && p.IdPracownik == workerId).Sum(p => (decimal?)p.Rbh) ?? 0) +
                                         (db.KontrolaProd.Where(k => k.IdZadaniePNavigation.DataZadania == date && k.IdPracownik == workerId).Sum(k => (decimal?)k.Rbh) ?? 0) +
                                         (db.KontrolaMat.Where(k => k.IdZadaniePNavigation.DataZadania == date && k.IdPracownik == workerId).Sum(k => (decimal?)k.Rbh) ?? 0) +
                                         (db.Obsluga.Any(o => o.DataPoczatek <= date && (o.DataKoniec == null || o.DataKoniec >= date) && o.IdPracownik == workerId) ? 8m : 0m);

                if (workerCurrent + plannedRbh > 8)
                {
                    MessageBox.Show($"Pracownik przekroczy limit 8 RBH (obecnie: {workerCurrent} + plan: {plannedRbh}). Proszę wybrać innego pracownika.", "Błąd limitu czasu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Walidacja maszyny
                decimal machineCurrent = (db.Produkcja.Where(p => p.IdZadaniePNavigation.DataZadania == date && p.IdZadaniePNavigation.IdMaszyna == machineId).Sum(p => (decimal?)p.Rbh) ?? 0) +
                                          (db.Obsluga.Any(o => o.DataPoczatek <= date && (o.DataKoniec == null || o.DataKoniec >= date) && o.IdMaszyna == machineId) ? 8m : 0m);

                if (machineCurrent + plannedRbh > 8)
                {
                    MessageBox.Show($"Maszyna przekroczy limit 8 RBH (obecnie: {machineCurrent} + plan: {plannedRbh}). Proszę wybrać inną maszynę.", "Błąd limitu maszyny", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Zadanie 2: Walidacja wyposażenia
                decimal equipmentCurrent = db.Produkcja
                    .Where(p => p.IdZadaniePNavigation.DataZadania == date)
                    .Join(db.MaszynaWyp,
                          p => new { p.IdZadaniePNavigation.IdMaszyna, IdNormaP = p.IdNormyP },
                          mw => new { mw.IdMaszyna, mw.IdNormaP },
                          (p, mw) => new { mw.IdWyposazenie, p.Rbh })
                    .Where(x => x.IdWyposazenie == equipmentId)
                    .Sum(x => (decimal?)x.Rbh) ?? 0m;

                if (equipmentCurrent + plannedRbh > 8)
                {
                    MessageBox.Show($"Wyposażenie przekroczy limit 8 RBH (obecnie: {equipmentCurrent} + plan: {plannedRbh}). Proszę wybrać inne wyposażenie lub zmniejszyć liczbę godzin.", "Błąd limitu wyposażenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var zadanie = new ZadanieProdukcyjne { IdMaszyna = machineId, DataZadania = date, IdZamowienie = selectedIdZamowienie.Value };
                db.ZadanieProdukcyjne.Add(zadanie);
                db.SaveChanges();

                int idP = (int)dgv.SelectedRows[0].Cells["IdProdukt"].Value;
                int idM = (int)dgv.SelectedRows[0].Cells["IdMaterial"].Value;
                var norma = db.NormaProd.First(n => n.IdProdukt == idP && n.IdMaterial == idM);

                db.Produkcja.Add(new Models.Produkcja { IdPracownik = workerId, Rbh = plannedRbh, IdZadanieP = zadanie.IdZadanieP, IdNormyP = norma.IdNormaP });
                db.SaveChanges();

                MessageBox.Show("Zadanie produkcyjne zostało zaplanowane.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola oraz wybrać produkt.");
            }
        }
    }
}
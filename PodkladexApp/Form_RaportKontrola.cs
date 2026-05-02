using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_RaportKontrola : Form
    {
        PodkladexContext _context;

        private enum TrybRaportu { Materialy, Produkty }
        private TrybRaportu aktualnyTryb;

        public Form_RaportKontrola(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            // Rejestracja zdarzeń
            this.Load += Form_RaportKontrola_Load;
            this.btn_WidokMaterialy.Click += btn_WidokMaterialy_Click;
            this.btn_WidokProdukty.Click += btn_WidokProdukty_Click;
            this.comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.btn_WyczyscFiltry.Click += btn_WyczyscFiltry_Click;
            this.DGV_Kontrole.SelectionChanged += DGV_Kontrole_SelectionChanged;
            this.comboBox_SortowaniePomiarow.SelectedIndexChanged += comboBox_SortowaniePomiarow_SelectedIndexChanged;

            // Zdarzenie do kolorowania wierszy
            this.DGV_Pomiary.DataBindingComplete += DGV_Pomiary_DataBindingComplete;

            FormatujTabele();
        }

        private void Form_RaportKontrola_Load(object sender, EventArgs e)
        {
            ZaladujSlowniki();
            UstawWidok(TrybRaportu.Materialy);
        }

        private void FormatujTabele()
        {
            DGV_Kontrole.AllowUserToAddRows = false;
            DGV_Kontrole.AllowUserToDeleteRows = false;
            DGV_Kontrole.ReadOnly = true;
            DGV_Kontrole.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Kontrole.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGV_Pomiary.AllowUserToAddRows = false;
            DGV_Pomiary.AllowUserToDeleteRows = false;
            DGV_Pomiary.ReadOnly = true;
            DGV_Pomiary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Pomiary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ZaladujSlowniki()
        {
            comboBox_FiltrPracownik.SelectedIndexChanged -= Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged -= Filtry_SelectedIndexChanged;
            comboBox_SortowaniePomiarow.SelectedIndexChanged -= comboBox_SortowaniePomiarow_SelectedIndexChanged;

            comboBox_FiltrPracownik.DataSource = _context.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Select(p => new { p.IdPracownik, ImieNazwisko = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();
            comboBox_FiltrPracownik.DisplayMember = "ImieNazwisko";
            comboBox_FiltrPracownik.ValueMember = "IdPracownik";

            comboBox_Sortowanie.DataSource = new List<string>
            {
                "Od najnowszych", "Od najstarszych", "Pracownik A-Z", "Zatwierdzone", "Niezatwierdzone"
            };

            comboBox_SortowaniePomiarow.DataSource = new List<string>
            {
                "Właściwość A-Z",
                "Właściwość Z-A",
                "Wartość (rosnąco)",
                "Wartość (malejąco)",
                "Status (Zgodne najpierw)",
                "Status (Niezgodne najpierw)"
            };

            comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            comboBox_SortowaniePomiarow.SelectedIndexChanged += comboBox_SortowaniePomiarow_SelectedIndexChanged;
        }

        private void UstawWidok(TrybRaportu tryb)
        {
            aktualnyTryb = tryb;
            if (aktualnyTryb == TrybRaportu.Materialy)
            {
                btn_WidokMaterialy.BackColor = Color.LightSkyBlue;
                btn_WidokProdukty.BackColor = SystemColors.Control;
            }
            else
            {
                btn_WidokProdukty.BackColor = Color.LightSkyBlue;
                btn_WidokMaterialy.BackColor = SystemColors.Control;
            }
            WyczyscFiltry();
        }

        private void btn_WidokMaterialy_Click(object sender, EventArgs e) => UstawWidok(TrybRaportu.Materialy);
        private void btn_WidokProdukty_Click(object sender, EventArgs e) => UstawWidok(TrybRaportu.Produkty);
        private void btn_WyczyscFiltry_Click(object sender, EventArgs e) => WyczyscFiltry();
        private void Filtry_SelectedIndexChanged(object sender, EventArgs e) => OdswiezKontrole();

        private void WyczyscFiltry()
        {
            comboBox_FiltrPracownik.SelectedIndex = -1;
            comboBox_Sortowanie.SelectedIndex = 0;
            comboBox_SortowaniePomiarow.SelectedIndex = 0;
            OdswiezKontrole();
        }

        private void OdswiezKontrole()
        {
            int? idPracownika = comboBox_FiltrPracownik.SelectedValue as int?;
            string wybraneSortowanie = comboBox_Sortowanie.SelectedItem?.ToString();

            if (aktualnyTryb == TrybRaportu.Materialy)
            {
                var query = _context.KontrolaMat
                    .Include(k => k.IdPracownikNavigation.IdOsobaNavigation)
                    .Include(k => k.IdZadaniePNavigation.IdMaszynaNavigation)
                    .Include(k => k.IdMaterialNavigation)
                    .Where(k => k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa.Contains("Gilotyna"))
                    .AsQueryable();

                if (idPracownika.HasValue) query = query.Where(k => k.IdPracownik == idPracownika.Value);

                var dane = query.Select(k => new {
                    ID = k.IdKontrolaMat,
                    Data_Zadania = k.IdZadaniePNavigation.DataZadania,
                    Pracownik = k.IdPracownikNavigation.IdOsobaNavigation.Imie + " " + k.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                    Maszyna = k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa,
                    Obiekt_Kontrolowany = k.IdMaterialNavigation.Nazwa,
                    Status = k.Zatwierdzone ? "ZATWIERDZONE" : "W TOKU"
                }).ToList();

                DGV_Kontrole.DataSource = SortujDaneKontroli(dane.AsEnumerable(), wybraneSortowanie);
            }
            else
            {
                var query = _context.KontrolaProd
                    .Include(k => k.IdPracownikNavigation.IdOsobaNavigation)
                    .Include(k => k.IdZadaniePNavigation.IdMaszynaNavigation)
                    .Include(k => k.IdZadaniePNavigation.Produkcja)
                        .ThenInclude(p => p.IdNormyPNavigation)
                        .ThenInclude(n => n.IdProduktNavigation)
                    .Where(k => k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa.Contains("Prasa"))
                    .AsQueryable();

                if (idPracownika.HasValue) query = query.Where(k => k.IdPracownik == idPracownika.Value);

                var dane = query.Select(k => new {
                    ID = k.IdKontrolaProd,
                    Data_Zadania = k.IdZadaniePNavigation.DataZadania,
                    Pracownik = k.IdPracownikNavigation.IdOsobaNavigation.Imie + " " + k.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                    Maszyna = k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa,
                    Obiekt_Kontrolowany = k.IdZadaniePNavigation.Produkcja.Any() && k.IdZadaniePNavigation.Produkcja.FirstOrDefault().IdNormyPNavigation != null
                              ? k.IdZadaniePNavigation.Produkcja.FirstOrDefault().IdNormyPNavigation.IdProduktNavigation.Nazwa : "Brak produktu",
                    Status = k.Zatwierdzone ? "ZATWIERDZONE" : "W TOKU"
                }).ToList();

                DGV_Kontrole.DataSource = SortujDaneKontroli(dane.AsEnumerable(), wybraneSortowanie);
            }
            UkryjID();
        }

        private List<dynamic> SortujDaneKontroli(IEnumerable<dynamic> dane, string sortowanie)
        {
            switch (sortowanie)
            {
                case "Od najstarszych": return dane.OrderBy(x => x.ID).ToList();
                case "Pracownik A-Z": return dane.OrderBy(x => x.Pracownik).ToList();
                case "Zatwierdzone": return dane.OrderByDescending(x => x.Status == "ZATWIERDZONE").ToList();
                case "Niezatwierdzone": return dane.OrderByDescending(x => x.Status == "W TOKU").ToList();
                default: return dane.OrderByDescending(x => x.ID).ToList();
            }
        }

        private void UkryjID()
        {
            if (DGV_Kontrole.Columns.Contains("ID")) DGV_Kontrole.Columns["ID"].Visible = false;
            if (DGV_Kontrole.Columns.Contains("Obiekt_Kontrolowany")) DGV_Kontrole.Columns["Obiekt_Kontrolowany"].HeaderText = "Obiekt Kontrolowany";
            if (DGV_Kontrole.Columns.Contains("Data_Zadania")) DGV_Kontrole.Columns["Data_Zadania"].HeaderText = "Data Zadania";
        }

        private void DGV_Kontrole_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Kontrole.CurrentRow != null && DGV_Kontrole.CurrentRow.Cells["ID"].Value != null)
            {
                OdswiezPomiary((int)DGV_Kontrole.CurrentRow.Cells["ID"].Value);
            }
            else DGV_Pomiary.DataSource = null;
        }

        private void comboBox_SortowaniePomiarow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGV_Kontrole.CurrentRow != null && DGV_Kontrole.CurrentRow.Cells["ID"].Value != null)
            {
                OdswiezPomiary((int)DGV_Kontrole.CurrentRow.Cells["ID"].Value);
            }
        }

        private void OdswiezPomiary(int idKontroli)
        {
            string sortowanie = comboBox_SortowaniePomiarow.SelectedItem?.ToString();

            if (aktualnyTryb == TrybRaportu.Materialy)
            {
                var kontrola = _context.KontrolaMat.FirstOrDefault(k => k.IdKontrolaMat == idKontroli);
                int idMaterial = kontrola?.IdMaterial ?? 0;
                var normy = _context.MaterialWlasciwosci.Where(mw => mw.IdMaterial == idMaterial).ToList();

                var dane = _context.PomiarMat.Where(p => p.IdKontrolaMat == idKontroli).Include(p => p.IdWlasciwosciNavigation).ToList()
                    .Select(p => {
                        var n = normy.FirstOrDefault(x => x.IdWlasciwosci == p.IdWlasciwosci);
                        decimal min = n?.WartoscMinimalna ?? 0;
                        decimal max = n?.WartoscMaksymalna ?? 0;
                        bool zgodny = p.WartoscZmierzona >= min && p.WartoscZmierzona <= max;
                        return new
                        {
                            Wlasciwosc = p.IdWlasciwosciNavigation.NazwaParametru,
                            Wartosc = p.WartoscZmierzona,
                            Min = min,
                            Max = max,
                            Status = zgodny ? "ZGODNY" : "NIEZGODNY"
                        };
                    }).ToList();
                DGV_Pomiary.DataSource = SortujPomiary(dane.AsEnumerable(), sortowanie);
            }
            else
            {
                var kontrola = _context.KontrolaProd.Include(k => k.IdZadaniePNavigation.Produkcja).ThenInclude(pr => pr.IdNormyPNavigation).FirstOrDefault(k => k.IdKontrolaProd == idKontroli);
                int idProdukt = kontrola?.IdZadaniePNavigation?.Produkcja?.FirstOrDefault()?.IdNormyPNavigation?.IdProdukt ?? 0;
                var normy = _context.ProduktWlasciwosci.Where(pw => pw.IdProdukt == idProdukt).ToList();

                var dane = _context.Pomiar.Where(p => p.IdKontrolaProd == idKontroli).Include(p => p.IdWlasciwosciNavigation).ToList()
                    .Select(p => {
                        var n = normy.FirstOrDefault(x => x.IdWlasciwosci == p.IdWlasciwosci);
                        decimal min = n?.WartoscMinimalna ?? 0;
                        decimal max = n?.WartoscMaksymalna ?? 0;
                        bool zgodny = p.WartoscZmierzona >= min && p.WartoscZmierzona <= max;
                        return new
                        {
                            Wlasciwosc = p.IdWlasciwosciNavigation.NazwaParametru,
                            Wartosc = p.WartoscZmierzona,
                            Min = min,
                            Max = max,
                            Status = zgodny ? "ZGODNY" : "NIEZGODNY"
                        };
                    }).ToList();
                DGV_Pomiary.DataSource = SortujPomiary(dane.AsEnumerable(), sortowanie);
            }
        }

        private List<dynamic> SortujPomiary(IEnumerable<dynamic> dane, string sortowanie)
        {
            switch (sortowanie)
            {
                case "Właściwość Z-A": return dane.OrderByDescending(x => x.Wlasciwosc).ToList();
                case "Wartość (rosnąco)": return dane.OrderBy(x => x.Wartosc).ToList();
                case "Wartość (malejąco)": return dane.OrderByDescending(x => x.Wartosc).ToList();
                case "Status (Zgodne najpierw)": return dane.OrderByDescending(x => x.Status).ThenBy(x => x.Wlasciwosc).ToList();
                case "Status (Niezgodne najpierw)": return dane.OrderBy(x => x.Status).ThenBy(x => x.Wlasciwosc).ToList();
                default: return dane.OrderBy(x => x.Wlasciwosc).ToList();
            }
        }

        private void DGV_Pomiary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_Pomiary.Rows)
            {
                if (row.Cells["Status"].Value?.ToString() == "ZGODNY") row.DefaultCellStyle.BackColor = Color.LightGreen;
                else row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }
    }
}
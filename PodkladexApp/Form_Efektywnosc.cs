using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ScottPlot;

namespace PodkladexApp
{
    public partial class Form_Efektywnosc : Form
    {
        PodkladexContext _context;

        private enum TrybWidoku { Materialy, Produkty }
        private TrybWidoku aktualnyTryb;

        public Form_Efektywnosc(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            // Rejestracja zdarzeń
            this.Load += Form_Efektywnosc_Load;
            this.btn_WidokMaterialy.Click += btn_WidokMaterialy_Click;
            this.btn_WidokProdukty.Click += btn_WidokProdukty_Click;
            this.comboBox_FiltrMaszyna.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.btn_WyczyscFiltry.Click += btn_WyczyscFiltry_Click;

            FormatujTabele();
        }

        private void Form_Efektywnosc_Load(object sender, EventArgs e)
        {
            ZaladujSlowniki();
            // Domyślnie ładujemy widok produkcji podkładek na start
            UstawWidok(TrybWidoku.Produkty);
        }

        private void FormatujTabele()
        {
            DGV_Efektywnosc.AllowUserToAddRows = false;
            DGV_Efektywnosc.AllowUserToDeleteRows = false;
            DGV_Efektywnosc.ReadOnly = true;
            DGV_Efektywnosc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Efektywnosc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ZaladujSlowniki()
        {
            comboBox_FiltrPracownik.SelectedIndexChanged -= Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged -= Filtry_SelectedIndexChanged;

            comboBox_FiltrPracownik.DataSource = _context.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Select(p => new { p.IdPracownik, Nazwa = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();
            comboBox_FiltrPracownik.DisplayMember = "Nazwa";
            comboBox_FiltrPracownik.ValueMember = "IdPracownik";

            comboBox_Sortowanie.DataSource = new List<string>
            {
                "Pracownik A-Z",
                "Maszyna A-Z",
                "Efektywność (od najwyższej)",
                "Efektywność (od najniższej)",
                "Największa produkcja [kg]"
            };

            comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
        }

        // Metoda zarządzająca stanem formularza
        private void UstawWidok(TrybWidoku tryb)
        {
            aktualnyTryb = tryb;

            if (aktualnyTryb == TrybWidoku.Materialy)
            {
                btn_WidokMaterialy.BackColor = System.Drawing.Color.LightSkyBlue;
                btn_WidokProdukty.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                btn_WidokProdukty.BackColor = System.Drawing.Color.LightSkyBlue;
                btn_WidokMaterialy.BackColor = System.Drawing.SystemColors.Control;
            }

            OdswiezZalezneFiltryMaszyn();
            WyczyscFiltry();
        }

        private void OdswiezZalezneFiltryMaszyn()
        {
            comboBox_FiltrMaszyna.SelectedIndexChanged -= Filtry_SelectedIndexChanged;

            if (aktualnyTryb == TrybWidoku.Produkty)
            {
                comboBox_FiltrMaszyna.DataSource = _context.Maszyna.Where(m => m.Nazwa.Contains("Prasa")).ToList();
            }
            else
            {
                comboBox_FiltrMaszyna.DataSource = _context.Maszyna.Where(m => m.Nazwa.Contains("Gilotyna")).ToList();
            }

            comboBox_FiltrMaszyna.DisplayMember = "Nazwa";
            comboBox_FiltrMaszyna.ValueMember = "IdMaszyna";
            comboBox_FiltrMaszyna.SelectedIndex = -1;

            comboBox_FiltrMaszyna.SelectedIndexChanged += Filtry_SelectedIndexChanged;
        }

        private void btn_WidokMaterialy_Click(object sender, EventArgs e) => UstawWidok(TrybWidoku.Materialy);
        private void btn_WidokProdukty_Click(object sender, EventArgs e) => UstawWidok(TrybWidoku.Produkty);
        private void btn_WyczyscFiltry_Click(object sender, EventArgs e) => WyczyscFiltry();
        private void Filtry_SelectedIndexChanged(object sender, EventArgs e) => OdswiezDane();

        private void WyczyscFiltry()
        {
            comboBox_FiltrMaszyna.SelectedIndex = -1;
            comboBox_FiltrPracownik.SelectedIndex = -1;
            comboBox_Sortowanie.SelectedIndex = 2; // Domyślnie "Efektywność (od najwyższej)"
            OdswiezDane();
        }

        private void OdswiezDane()
        {
            int? idMaszyna = comboBox_FiltrMaszyna.SelectedValue as int?;
            int? idPracownik = comboBox_FiltrPracownik.SelectedValue as int?;
            string wybraneSortowanie = comboBox_Sortowanie.SelectedItem?.ToString();

            IEnumerable<dynamic> suroweDane;

            if (aktualnyTryb == TrybWidoku.Produkty)
            {
                var queryProd = _context.KontrolaProd
                    .Include(k => k.IdZadaniePNavigation.IdMaszynaNavigation)
                    .Include(k => k.IdZadaniePNavigation.Produkcja).ThenInclude(p => p.IdPracownikNavigation.IdOsobaNavigation)
                    .Where(k => k.Zatwierdzone && k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa.Contains("Prasa"))
                    .AsQueryable();

                if (idMaszyna.HasValue) queryProd = queryProd.Where(k => k.IdZadaniePNavigation.IdMaszyna == idMaszyna.Value);
                if (idPracownik.HasValue) queryProd = queryProd.Where(k => k.IdZadaniePNavigation.Produkcja.Any(p => p.IdPracownik == idPracownik.Value));

                suroweDane = queryProd.ToList().Select(k => {
                    var produkcja = k.IdZadaniePNavigation.Produkcja.FirstOrDefault();
                    double w = produkcja != null ? (double)(produkcja.Wyprodukowano ?? 0m) : 0;
                    double o = (double)(k.Odpady ?? 0m);
                    string prac = produkcja != null ? $"{produkcja.IdPracownikNavigation.IdOsobaNavigation.Imie} {produkcja.IdPracownikNavigation.IdOsobaNavigation.Nazwisko}" : "Brak";

                    return new
                    {
                        ID = k.IdKontrolaProd,
                        Zadanie = k.IdZadanieP,
                        Pracownik = prac,
                        Maszyna = k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa,
                        Wyprodukowano_kg = w,
                        Odpady_kg = o,
                        Efektywnosc = (w + o) > 0 ? Math.Round((w / (w + o)) * 100, 2) : 0
                    };
                });
            }
            else
            {
                var queryMat = _context.KontrolaMat
                    .Include(k => k.IdZadaniePNavigation.IdMaszynaNavigation)
                    .Include(k => k.IdZadaniePNavigation.Produkcja).ThenInclude(p => p.IdPracownikNavigation.IdOsobaNavigation)
                    .Where(k => k.Zatwierdzone && k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa.Contains("Gilotyna"))
                    .AsQueryable();

                if (idMaszyna.HasValue) queryMat = queryMat.Where(k => k.IdZadaniePNavigation.IdMaszyna == idMaszyna.Value);
                if (idPracownik.HasValue) queryMat = queryMat.Where(k => k.IdZadaniePNavigation.Produkcja.Any(p => p.IdPracownik == idPracownik.Value));

                suroweDane = queryMat.ToList().Select(k => {
                    var produkcja = k.IdZadaniePNavigation.Produkcja.FirstOrDefault();
                    double w = produkcja != null ? (double)(produkcja.Wyprodukowano ?? 0m) : 0;
                    double o = (double)(k.Odpady ?? 0m);
                    string prac = produkcja != null ? $"{produkcja.IdPracownikNavigation.IdOsobaNavigation.Imie} {produkcja.IdPracownikNavigation.IdOsobaNavigation.Nazwisko}" : "Brak";

                    return new
                    {
                        ID = k.IdKontrolaMat,
                        Zadanie = k.IdZadanieP,
                        Pracownik = prac,
                        Maszyna = k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa,
                        Wyprodukowano_kg = w,
                        Odpady_kg = o,
                        Efektywnosc = (w + o) > 0 ? Math.Round((w / (w + o)) * 100, 2) : 0
                    };
                });
            }

            var daneLista = SortujDaneEfektywnosci(suroweDane, wybraneSortowanie);
            DGV_Efektywnosc.DataSource = daneLista;

            if (DGV_Efektywnosc.Columns.Count > 0)
            {
                DGV_Efektywnosc.Columns["ID"].Visible = false;
                DGV_Efektywnosc.Columns["Zadanie"].Visible = false;
                DGV_Efektywnosc.Columns["Wyprodukowano_kg"].HeaderText = "Wyprodukowano [kg]";
                DGV_Efektywnosc.Columns["Odpady_kg"].HeaderText = "Odpady [kg]";
                DGV_Efektywnosc.Columns["Efektywnosc"].HeaderText = "Efektywność [%]";
            }

            AktualizujWykres(daneLista);
        }

        private List<dynamic> SortujDaneEfektywnosci(IEnumerable<dynamic> dane, string sortowanie)
        {
            switch (sortowanie)
            {
                case "Pracownik A-Z": return dane.OrderBy(x => x.Pracownik).Cast<dynamic>().ToList();
                case "Maszyna A-Z": return dane.OrderBy(x => x.Maszyna).Cast<dynamic>().ToList();
                case "Efektywność (od najwyższej)": return dane.OrderByDescending(x => x.Efektywnosc).Cast<dynamic>().ToList();
                case "Efektywność (od najniższej)": return dane.OrderBy(x => x.Efektywnosc).Cast<dynamic>().ToList();
                case "Największa produkcja [kg]": return dane.OrderByDescending(x => x.Wyprodukowano_kg).Cast<dynamic>().ToList();
                default: return dane.OrderByDescending(x => x.Efektywnosc).Cast<dynamic>().ToList();
            }
        }

        private void AktualizujWykres(List<dynamic> dane)
        {
            formsPlot_Efektywnosc.Plot.Clear();

            if (dane.Count == 0)
            {
                formsPlot_Efektywnosc.Refresh();
                return;
            }

            var daneWykres = dane.Take(15).ToList();

            double[] wartosciEfektywnosci = daneWykres.Select(x => (double)x.Efektywnosc).ToArray();
            string[] etykiety = daneWykres.Select(x => $"{x.Maszyna}\n({x.Pracownik})").ToArray();

            var bars = formsPlot_Efektywnosc.Plot.Add.Bars(wartosciEfektywnosci);

            foreach (var bar in bars.Bars)
            {
                bar.FillColor = ScottPlot.Colors.DodgerBlue;
                bar.Label = bar.Value.ToString();
            }
            bars.ValueLabelStyle.Bold = true;

            ScottPlot.Tick[] xTicks = new ScottPlot.Tick[etykiety.Length];
            for (int i = 0; i < etykiety.Length; i++)
            {
                xTicks[i] = new ScottPlot.Tick(i, etykiety[i]);
            }

            formsPlot_Efektywnosc.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xTicks);
            formsPlot_Efektywnosc.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            formsPlot_Efektywnosc.Plot.Axes.Bottom.MinimumSize = 80;

            ScottPlot.Tick[] yTicks = new ScottPlot.Tick[]
            {
                new ScottPlot.Tick(0, "0"),
                new ScottPlot.Tick(20, "20"),
                new ScottPlot.Tick(40, "40"),
                new ScottPlot.Tick(60, "60"),
                new ScottPlot.Tick(80, "80"),
                new ScottPlot.Tick(100, "100")
            };
            formsPlot_Efektywnosc.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(yTicks);

            formsPlot_Efektywnosc.Plot.Axes.SetLimitsX(-1, daneWykres.Count);
            formsPlot_Efektywnosc.Plot.Axes.SetLimitsY(0, 115);

            formsPlot_Efektywnosc.Plot.YLabel("Efektywność [%]");
            formsPlot_Efektywnosc.Plot.Title(aktualnyTryb == TrybWidoku.Produkty ? "Efektywność produkcji wg rekordów (Podkładki)" : "Efektywność produkcji wg rekordów (Półfabrykaty)");

            formsPlot_Efektywnosc.Refresh();
        }
    }
}
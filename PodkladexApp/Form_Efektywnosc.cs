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

        public Form_Efektywnosc(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            this.Load += Form_Efektywnosc_Load;
            this.comboBox_FiltrMaszyna.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.btn_WyczyscFiltry.Click += btn_WyczyscFiltry_Click;

            FormatujTabele();
        }

        private void Form_Efektywnosc_Load(object sender, EventArgs e)
        {
            ZaladujSlowniki();
            WyczyscFiltry();
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
            comboBox_FiltrMaszyna.SelectedIndexChanged -= Filtry_SelectedIndexChanged;
            comboBox_FiltrPracownik.SelectedIndexChanged -= Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged -= Filtry_SelectedIndexChanged;

            comboBox_FiltrMaszyna.DataSource = _context.Maszyna.ToList();
            comboBox_FiltrMaszyna.DisplayMember = "Nazwa";
            comboBox_FiltrMaszyna.ValueMember = "IdMaszyna";

            comboBox_FiltrPracownik.DataSource = _context.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Select(p => new { p.IdPracownik, Nazwa = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();
            comboBox_FiltrPracownik.DisplayMember = "Nazwa";
            comboBox_FiltrPracownik.ValueMember = "IdPracownik";

            var opcjeSortowania = new List<string>
            {
                "Pracownik A-Z",
                "Maszyna A-Z",
                "Efektywność (od najwyższej)",
                "Efektywność (od najniższej)",
                "Największa produkcja [kg]"
            };
            comboBox_Sortowanie.DataSource = opcjeSortowania;

            comboBox_FiltrMaszyna.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
        }

        private void WyczyscFiltry()
        {
            comboBox_FiltrMaszyna.SelectedIndex = -1;
            comboBox_FiltrPracownik.SelectedIndex = -1;
            comboBox_Sortowanie.SelectedIndex = 2;
            OdswiezDane();
        }

        private void btn_WyczyscFiltry_Click(object sender, EventArgs e)
        {
            WyczyscFiltry();
        }

        private void Filtry_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdswiezDane();
        }

        private void OdswiezDane()
        {
            var query = _context.Produkcja
                .Include(p => p.IdZadaniePNavigation.IdMaszynaNavigation)
                .Include(p => p.IdPracownikNavigation.IdOsobaNavigation)
                .AsQueryable();

            if (comboBox_FiltrMaszyna.SelectedValue is int idMaszyna)
            {
                query = query.Where(p => p.IdZadaniePNavigation.IdMaszyna == idMaszyna);
            }

            if (comboBox_FiltrPracownik.SelectedValue is int idPracownik)
            {
                query = query.Where(p => p.IdPracownik == idPracownik);
            }

            var suroweDane = query.Select(p => new
            {
                ID = p.IdProdukcja,
                Zadanie = p.IdZadanieP,
                Pracownik = p.IdPracownikNavigation.IdOsobaNavigation.Imie + " " + p.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                Maszyna = p.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa,
                Wyprodukowano_kg = (double)p.Wyprodukowano,
                Odpady_kg = (double)p.Odpady,
                Efektywnosc = (double)(p.Wyprodukowano + p.Odpady) > 0
                    ? Math.Round(((double)p.Wyprodukowano / ((double)p.Wyprodukowano + (double)p.Odpady)) * 100, 2)
                    : 0
            }).ToList();

            string wybraneSortowanie = comboBox_Sortowanie.SelectedItem?.ToString();
            List<dynamic> daneLista;

            switch (wybraneSortowanie)
            {
                case "Pracownik A-Z": daneLista = suroweDane.OrderBy(x => x.Pracownik).Cast<dynamic>().ToList(); break;
                case "Maszyna A-Z": daneLista = suroweDane.OrderBy(x => x.Maszyna).Cast<dynamic>().ToList(); break;
                case "Efektywność (od najwyższej)": daneLista = suroweDane.OrderByDescending(x => x.Efektywnosc).Cast<dynamic>().ToList(); break;
                case "Efektywność (od najniższej)": daneLista = suroweDane.OrderBy(x => x.Efektywnosc).Cast<dynamic>().ToList(); break;
                case "Największa produkcja [kg]": daneLista = suroweDane.OrderByDescending(x => x.Wyprodukowano_kg).Cast<dynamic>().ToList(); break;
                default: daneLista = suroweDane.OrderByDescending(x => x.ID).Cast<dynamic>().ToList(); break;
            }

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

            ScottPlot.Tick[] ticks = new ScottPlot.Tick[etykiety.Length];
            for (int i = 0; i < etykiety.Length; i++)
            {
                ticks[i] = new ScottPlot.Tick(i, etykiety[i]);
            }

            formsPlot_Efektywnosc.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            formsPlot_Efektywnosc.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            formsPlot_Efektywnosc.Plot.Axes.Bottom.MinimumSize = 80;

            // Resetowanie kamery wykresu, aby pokazała wszystkie słupki (od -1 do liczby rekordów)
            formsPlot_Efektywnosc.Plot.Axes.SetLimitsX(-1, daneWykres.Count);
            formsPlot_Efektywnosc.Plot.Axes.SetLimitsY(0, 115);

            formsPlot_Efektywnosc.Plot.YLabel("Efektywność [%]");
            formsPlot_Efektywnosc.Plot.Title("Efektywność produkcji wg rekordów");

            formsPlot_Efektywnosc.Refresh();
        }
    }
}
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
using ScottPlot;

namespace PodkladexApp.Utrzymanie_ruchu
{
    public partial class Form_Awaryjnosc : Form
    {
        PodkladexContext context;
        public Form_Awaryjnosc(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            ZaladujMaszynyDoComboBox();
            ZaladujFiltryRaportu();
            ZaladujRaportAwaryjnosci();
            panel1.Visible = false;
        }
        private void ZaladujMaszynyDoComboBox()
        {
            var lista = context.Maszyna
                .Select(m => new
                {
                    m.IdMaszyna,
                    m.Nazwa
                })
                .OrderBy(m => m.Nazwa)
                .ToList();

            // opcja: "wszystkie"
            lista.Insert(0, new { IdMaszyna = 0, Nazwa = "Wszystkie" });

            cbox_maszyny.DataSource = lista;
            cbox_maszyny.DisplayMember = "Nazwa";
            cbox_maszyny.ValueMember = "IdMaszyna";

            cbox_maszyny.SelectedIndex = 0;
        }
        private void ZaladujFiltryRaportu()
        {
            var filtry = new List<KeyValuePair<string, string>>
            {
        new KeyValuePair<string, string>("awarie_desc", "Najwięcej awarii"),
        new KeyValuePair<string, string>("awarie_asc", "Najmniej awarii"),
        new KeyValuePair<string, string>("czas_desc", "Najdłuższy przestój"),
        new KeyValuePair<string, string>("czas_asc", "Najkrótszy przestój"),
        new KeyValuePair<string, string>("srednia_desc", "Najdłuższa naprawa"),
        new KeyValuePair<string, string>("srednia_asc", "Najkrótsza naprawa")
             };

            comboBox_filtry.DataSource = filtry;
            comboBox_filtry.DisplayMember = "Value"; // co widać
            comboBox_filtry.ValueMember = "Key";     // co używasz w kodzie

            comboBox_filtry.SelectedIndex = 0;
        }
        private void ZaladujRaportAwaryjnosci()
        {
            var query = context.Awaria.AsQueryable();

            // =========================
            // FILTR MASZYNY
            // =========================
            if (cbox_maszyny.SelectedValue != null &&
                int.TryParse(cbox_maszyny.SelectedValue.ToString(), out int idMaszyna) &&
                idMaszyna != 0)
            {
                query = query.Where(a => a.IdMaszyna == idMaszyna);
            }

            // =========================
            // POBRANIE DANYCH
            // =========================
            var dane = query
                .Select(a => new
                {
                    a.IdMaszyna,
                    Maszyna = a.IdMaszynaNavigation.Nazwa,

                    Pracownik = a.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                                a.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,

                    Start = a.DataZgloszenia,
                    Koniec = a.DataUsuniecia
                })
                .ToList();

            // =========================
            // GRUPOWANIE
            // =========================
            var wynik = dane
                .GroupBy(x => new { x.IdMaszyna, x.Maszyna })
                .Select(g =>
                {
                    // wszystkie czasy (także aktywne awarie)
                    var wszystkieCzasy = g.Select(x =>
                    {
                        DateTime start = x.Start.ToDateTime(TimeOnly.MinValue);
                        DateTime koniec = (x.Koniec ?? DateOnly.FromDateTime(DateTime.Now))
                                            .ToDateTime(TimeOnly.MinValue);

                        return (koniec - start).TotalHours;
                    }).ToList();

                    // tylko zakończone
                    var zakonczoneCzasy = g
                        .Where(x => x.Koniec != null)
                        .Select(x =>
                        {
                            DateTime start = x.Start.ToDateTime(TimeOnly.MinValue);
                            DateTime koniec = x.Koniec.Value.ToDateTime(TimeOnly.MinValue);

                            return (koniec - start).TotalHours;
                        }).ToList();

                    return new
                    {
                        Maszyna = g.Key.Maszyna,

                        IloscAwarii = g.Count(),

                        // wszystkie (także trwające)
                        CzasPrzestoju = Math.Round(wszystkieCzasy.Sum(), 2),

                        // tylko zakończone
                        SredniCzas = zakonczoneCzasy.Count > 0
                            ? Math.Round(zakonczoneCzasy.Average(), 2)
                            : 0,

                        NajczestszyPracownik = g
                            .GroupBy(x => x.Pracownik)
                            .OrderByDescending(x => x.Count())
                            .Select(x => x.Key)
                            .FirstOrDefault()
                    };
                })
                .ToList();

            // =========================
            // SORTOWANIE
            // =========================
            if (comboBox_filtry.SelectedValue != null)
            {
                string filtr = comboBox_filtry.SelectedValue.ToString();

                switch (filtr)
                {
                    case "awarie_desc":
                        wynik = wynik.OrderByDescending(x => x.IloscAwarii).ToList();
                        break;

                    case "awarie_asc":
                        wynik = wynik.OrderBy(x => x.IloscAwarii).ToList();
                        break;

                    case "czas_desc":
                        wynik = wynik.OrderByDescending(x => x.CzasPrzestoju).ToList();
                        break;

                    case "czas_asc":
                        wynik = wynik.OrderBy(x => x.CzasPrzestoju).ToList();
                        break;

                    case "srednia_desc":
                        wynik = wynik.OrderByDescending(x => x.SredniCzas).ToList();
                        break;

                    case "srednia_asc":
                        wynik = wynik.OrderBy(x => x.SredniCzas).ToList();
                        break;
                }
            }

            // =========================
            // DATA GRID
            // =========================
            dataGridView1.DataSource = wynik;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns["Maszyna"].FillWeight = 100;
            dataGridView1.Columns["IloscAwarii"].FillWeight = 80;
            dataGridView1.Columns["CzasPrzestoju"].FillWeight = 120;
            dataGridView1.Columns["SredniCzas"].FillWeight = 120;
            dataGridView1.Columns["NajczestszyPracownik"].FillWeight = 180;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Font = new Font("Segoe UI", 14);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // nazwy kolumn
            dataGridView1.Columns["Maszyna"].HeaderText = "Maszyna";
            dataGridView1.Columns["IloscAwarii"].HeaderText = "Ilość awarii";
            dataGridView1.Columns["CzasPrzestoju"].HeaderText = "Czas przestoju (h)";
            dataGridView1.Columns["SredniCzas"].HeaderText = "Śr. czas naprawy (h)";
            dataGridView1.Columns["NajczestszyPracownik"].HeaderText = "Najczęstszy pracownik";
        }

        private void cbox_maszyny_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujRaportAwaryjnosci();

        }

        private void comboBox_filtry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujRaportAwaryjnosci();

        }

        private void button_rysuj_wykres_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            RysujWykresMaszyn();
        }
        private void RysujWykresMaszyn()
        {
            if (dataGridView1.Rows.Count == 0) return;

            List<string> maszyny = new List<string>();
            List<double> iloscAwarii = new List<double>();
            List<double> lacznyCzas = new List<double>();
            List<double> sredniCzas = new List<double>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string maszyna = row.Cells["Maszyna"]?.Value?.ToString();

                double ilosc = Convert.ToDouble(row.Cells["IloscAwarii"]?.Value ?? 0);
                double laczny = Convert.ToDouble(row.Cells["CzasPrzestoju"]?.Value ?? 0);

                double sredni = ilosc > 0 ? laczny / ilosc : 0;

                maszyny.Add(maszyna);
                iloscAwarii.Add(ilosc);
                lacznyCzas.Add(laczny);
                sredniCzas.Add(sredni);
            }

            double[] xs = Enumerable.Range(0, maszyny.Count)
                                    .Select(i => (double)i)
                                    .ToArray();



            // =========================
            // WYKRES 2 — CZAS PRZESTOJU
            // =========================
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Add.Bars(lacznyCzas.ToArray());
            formsPlot1.Plot.Axes.Bottom.SetTicks(xs, maszyny.ToArray());
            formsPlot1.Plot.Title("Czas przestoju (h)");
            formsPlot1.Plot.YLabel("Godziny");
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();

            // =========================
            // WYKRES 3 — ŚREDNI CZAS
            // =========================
            formsPlot2.Plot.Clear();
            formsPlot2.Plot.Add.Bars(sredniCzas.ToArray());
            formsPlot2.Plot.Axes.Bottom.SetTicks(xs, maszyny.ToArray());
            formsPlot2.Plot.Title("Śr. czas naprawy (h)");
            formsPlot2.Plot.YLabel("Godziny");
            formsPlot2.Plot.Axes.AutoScale();
            formsPlot2.Refresh();
        }
    }

}

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
    public partial class Form_Przestoj : Form
    {
        PodkladexContext context;
        public Form_Przestoj(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            ZaladujFiltryPrzestojow();
            ZaladujRaportPrzestojow();
            panel1.Visible = false;
        }
        private void ZaladujFiltryPrzestojow()
        {
            var filtry = new List<KeyValuePair<string, string>>
    {
        new("maszyna_asc", "Maszyna A-Z"),
        new("maszyna_desc", "Maszyna Z-A"),

        new("ilosc_desc", "Najwięcej przestojów"),
        new("ilosc_asc", "Najmniej przestojów"),

        new("czas_desc", "Najdłuższy łączny czas"),
        new("czas_asc", "Najkrótszy łączny czas"),

        new("awaria_desc", "Najdłuższa awaria"),
        new("awaria_asc", "Najkrótsza awaria"),

        new("obsluga_desc", "Najdłuższa obsługa"),
        new("obsluga_asc", "Najkrótsza obsługa")
    };

            cbox_maszyny.DataSource = filtry;
            cbox_maszyny.DisplayMember = "Value";
            cbox_maszyny.ValueMember = "Key";

            cbox_maszyny.SelectedIndex = 0;
        }
        private void ZaladujRaportPrzestojow()
        {
            // =========================
            // FILTR MASZYNY
            // =========================
            int idMaszyna = 0;

            if (cbox_maszyny.SelectedValue != null)
                int.TryParse(cbox_maszyny.SelectedValue.ToString(), out idMaszyna);

            // =========================
            // AWARIE
            // =========================
            var awarie = context.Awaria
                .Where(a => idMaszyna == 0 || a.IdMaszyna == idMaszyna)
                .Select(a => new
                {
                    a.IdMaszyna,
                    Maszyna = a.IdMaszynaNavigation.Nazwa,
                    Start = a.DataZgloszenia,
                    Koniec = a.DataUsuniecia
                })
                .ToList();

            // =========================
            // OBSŁUGI (TU JUŻ PRZEBIEG!)
            // =========================
            var obslugi = context.Obsluga
                .Where(o => idMaszyna == 0 || o.IdMaszyna == idMaszyna)
                .Select(o => new
                {
                    o.IdMaszyna,
                    Maszyna = o.IdMaszynaNavigation.Nazwa,
                    Czas = (double)o.Przebieg // 🔥 GOTOWY CZAS
                })
                .ToList();

            // =========================
            // CZAS AWARII
            // =========================
            var awarieCzas = awarie.Select(a =>
            {
                DateTime start = a.Start.ToDateTime(TimeOnly.MinValue);
                DateTime koniec = (a.Koniec ?? DateOnly.FromDateTime(DateTime.Now))
                                   .ToDateTime(TimeOnly.MinValue);

                return new
                {
                    a.IdMaszyna,
                    a.Maszyna,
                    Czas = (koniec - start).TotalHours
                };
            });

            // =========================
            // OBSŁUGI (JUŻ GOTOWE)
            // =========================
            var obslugiCzas = obslugi.Select(o => new
            {
                o.IdMaszyna,
                o.Maszyna,
                Czas = o.Czas
            });

            // =========================
            // POŁĄCZENIE
            // =========================
            var wszystkie = awarieCzas
                .Select(x => new { x.IdMaszyna, x.Maszyna, x.Czas, Typ = "Awaria" })
                .Concat(
                    obslugiCzas.Select(x => new { x.IdMaszyna, x.Maszyna, x.Czas, Typ = "Obsługa" })
                )
                .ToList();

            // =========================
            // GRUPOWANIE
            // =========================
            var wynik = wszystkie
                .GroupBy(x => new { x.IdMaszyna, x.Maszyna })
                .Select(g => new
                {
                    Maszyna = g.Key.Maszyna,

                    IloscPrzestojow = g.Count(),

                    LacznyCzas = Math.Round(g.Sum(x => x.Czas), 2),

                    NajdluzszaAwaria = Math.Round(
                        g.Where(x => x.Typ == "Awaria")
                         .Select(x => x.Czas)
                         .DefaultIfEmpty(0)
                         .Max(), 2),

                    NajdluzszaObsluga = Math.Round(
                        g.Where(x => x.Typ == "Obsługa")
                         .Select(x => x.Czas)
                         .DefaultIfEmpty(0)
                         .Max(), 2)
                })
                .ToList();
            string filtr = cbox_maszyny.SelectedValue?.ToString();

            switch (filtr)
            {
                case "maszyna_asc":
                    wynik = wynik.OrderBy(x => x.Maszyna).ToList();
                    break;

                case "maszyna_desc":
                    wynik = wynik.OrderByDescending(x => x.Maszyna).ToList();
                    break;

                case "ilosc_desc":
                    wynik = wynik.OrderByDescending(x => x.IloscPrzestojow).ToList();
                    break;

                case "ilosc_asc":
                    wynik = wynik.OrderBy(x => x.IloscPrzestojow).ToList();
                    break;

                case "czas_desc":
                    wynik = wynik.OrderByDescending(x => x.LacznyCzas).ToList();
                    break;

                case "czas_asc":
                    wynik = wynik.OrderBy(x => x.LacznyCzas).ToList();
                    break;

                case "awaria_desc":
                    wynik = wynik.OrderByDescending(x => x.NajdluzszaAwaria).ToList();
                    break;

                case "awaria_asc":
                    wynik = wynik.OrderBy(x => x.NajdluzszaAwaria).ToList();
                    break;

                case "obsluga_desc":
                    wynik = wynik.OrderByDescending(x => x.NajdluzszaObsluga).ToList();
                    break;

                case "obsluga_asc":
                    wynik = wynik.OrderBy(x => x.NajdluzszaObsluga).ToList();
                    break;
            }

            // =========================
            // GRID
            // =========================
            dataGridView1.DataSource = wynik;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["Maszyna"].HeaderText = "Maszyna";

            dataGridView1.Columns["IloscPrzestojow"].HeaderText = "Ilość przestojów";

            dataGridView1.Columns["LacznyCzas"].HeaderText = "Łączny czas przestoju (h)";

            dataGridView1.Columns["NajdluzszaAwaria"].HeaderText = "Najdłuższa awaria (h)";

            dataGridView1.Columns["NajdluzszaObsluga"].HeaderText = "Najdłuższa obsługa (h)";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns["Maszyna"].FillWeight = 150;
            dataGridView1.Columns["IloscPrzestojow"].FillWeight = 70;
            dataGridView1.Columns["LacznyCzas"].FillWeight = 140;
            dataGridView1.Columns["NajdluzszaAwaria"].FillWeight = 130;
            dataGridView1.Columns["NajdluzszaObsluga"].FillWeight = 130;
            dataGridView1.Font = new Font("Segoe UI", 14);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void cbox_maszyny_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujRaportPrzestojow();
        }

        private void button_rysuj_wykres_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            RysujWykresPrzestojow();
        }
        private void RysujWykresPrzestojow()
        {
            var dane = dataGridView1.DataSource as IEnumerable<dynamic>;
            if (dane == null) return;

            string[] maszyn = dane.Select(x => (string)x.Maszyna).ToArray();
            double[] wartosci = dane.Select(x => (double)x.LacznyCzas).ToArray();

            formsPlot1.Plot.Clear();

            // 🔥 NOWY SPOSÓB W SCOTTPLOT 5
            var bar = formsPlot1.Plot.Add.Bars(wartosci);

            // opisy osi X
            formsPlot1.Plot.Axes.Bottom.SetTicks(
                Enumerable.Range(0, maszyn.Length).Select(i => (double)i).ToArray(),
                maszyn
            );

            formsPlot1.Plot.Title("Łączny czas przestojów maszyn");
            formsPlot1.Plot.YLabel("Czas (h)");
            formsPlot1.Plot.XLabel("Maszyny");

            formsPlot1.Plot.Axes.AutoScale();

            formsPlot1.Refresh();
        }



    }
}

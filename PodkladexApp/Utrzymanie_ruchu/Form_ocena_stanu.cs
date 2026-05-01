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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ScottPlot.TickGenerators;
using ScottPlot;
using ScottPlot.WinForms;
namespace PodkladexApp
{
    public partial class Form_ocena_stanu : Form
    {
        PodkladexContext context;

        public Form_ocena_stanu(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            comboBox_lista_rodzaj_obslug.SelectedIndex = -1;
            ZaladujMaszyny();
            panel1.Visible = false;
        }

        private void ZaladujMaszyny()
        {
            var lista = context.Maszyna.ToList();

            comboBox_lista_rodzaj_obslug.DataSource = lista;
            comboBox_lista_rodzaj_obslug.DisplayMember = "Nazwa";     // co widzi użytkownik
            comboBox_lista_rodzaj_obslug.ValueMember = "IdMaszyna";   // ID w tle

        }

        private void comboBox_lista_rodzaj_obslug_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaladujdate();
            ObliczDateKoncaGwarancji();
            ZaladujObslugiDlaMaszyny();
            ZaladujAwarieDlaMaszyny();
            ZaladujProdukcjeDlaMaszyny();
            PokazSumeRBH();
            GenerujWykresy();
        }
        private void Zaladujdate()
        {
            if (comboBox_lista_rodzaj_obslug.SelectedItem is Maszyna maszyna)
            {
                textBox_uruchomienie.Text = maszyna.DataUruchomienia.ToString("yyyy-MM-dd");
            }
        }
        private void ObliczDateKoncaGwarancji()
        {
            if (!(comboBox_lista_rodzaj_obslug.SelectedItem is Maszyna maszyna))
            {
                //MessageBox.Show("Wybierz maszynę.");
                return;
            }

            // 1. pobierz gwarancję dla maszyny
            var gwarancja = context.Gwarancja
                .FirstOrDefault(g => g.IdMaszyna == maszyna.IdMaszyna);

            if (gwarancja == null)
            {
                //MessageBox.Show("Brak gwarancji dla tej maszyny.");
                return;
            }

            int miesiace = gwarancja.CzasGwarancji;

            // 2. pokaż ilość miesięcy
            textBox_miesiace_gwarancji.Text = miesiace.ToString();

            // 3. data startowa
            DateOnly dataStart = maszyna.DataUruchomienia;
            textBox_uruchomienie.Text = dataStart.ToString("yyyy-MM-dd");

            // 4. obliczenie końca
            DateTime start = dataStart.ToDateTime(TimeOnly.MinValue);
            DateTime koniec = start.AddMonths(miesiace);

            textBox_miesiace_gwarancji.Text = koniec.ToString("yyyy-MM-dd");
        }
        private void ZaladujObslugiDlaMaszyny()
        {
            if (comboBox_lista_rodzaj_obslug.SelectedItem == null)
            {
                MessageBox.Show("Wybierz maszynę.");
                return;
            }

            var maszyna = (Maszyna)comboBox_lista_rodzaj_obslug.SelectedItem;

            var lista = context.Obsluga
                .Where(o => o.IdMaszyna == maszyna.IdMaszyna)
                .Select(o => new
                {
                    o.IdObsluga,
                    Maszyna = o.IdMaszynaNavigation.Nazwa,
                    RodzajObslugi = o.IdRodzajObslugiNavigation.Nazwa,
                    DataStart = o.DataPoczatek,
                    DataKoniec = o.DataKoniec,
                    o.Przebieg,


                    Czesci = string.Join(", ",
                        o.CzesciPrzeglady.Select(c =>
                            c.IdCzesciNavigation.Nazwa + " (" + c.Liczba + ")"
                        ))
                })
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["IdObsluga"].Visible = false;
            dataGridView1.Columns["Przebieg"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dataGridView1.Columns["Maszyna"].Width = 80;
            dataGridView1.Columns["RodzajObslugi"].Width = 80;
            dataGridView1.Columns["DataStart"].Width = 80;
            dataGridView1.Columns["DataKoniec"].Width = 80;
            dataGridView1.Columns["Czesci"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["RodzajObslugi"].HeaderText = "Rodzaj Obsługi";
            dataGridView1.Columns["DataStart"].HeaderText = "Data Rozpoczęcia";
            dataGridView1.Columns["DataKoniec"].HeaderText = "Data Zakończenia";
            dataGridView1.Columns["Czesci"].HeaderText = "Użyte Części";
        }
        private void ZaladujAwarieDlaMaszyny()
        {
            if (comboBox_lista_rodzaj_obslug.SelectedItem == null)
            {
                MessageBox.Show("Wybierz maszynę.");
                return;
            }

            var maszyna = (Maszyna)comboBox_lista_rodzaj_obslug.SelectedItem;

            var lista = context.Awaria
                .Where(a => a.IdMaszyna == maszyna.IdMaszyna)
                .Select(a => new
                {
                    a.IdAwaria,
                    Maszyna = a.IdMaszynaNavigation.Nazwa,
                    DataZgloszenia = a.DataZgloszenia,
                    DataUsuniecia = a.DataUsuniecia,
                    a.Opis,


                    Czesci = string.Join(", ",
                        a.CzesciAwaria.Select(c =>
                            c.IdCzesciNavigation.Nazwa + " (" + c.Liczba + ")"
                        ))
                })
                .ToList();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = lista;
            dataGridView2.Columns["IdAwaria"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dataGridView2.Columns["Maszyna"].Width = 80;
            dataGridView2.Columns["Opis"].Width = 80;
            dataGridView2.Columns["DataZgloszenia"].Width = 80;
            dataGridView2.Columns["DataUsuniecia"].Width = 80;
            dataGridView2.Columns["Czesci"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView2.Columns["DataZgloszenia"].HeaderText = "Data Zgłoszenia";
            dataGridView2.Columns["DataUsuniecia"].HeaderText = "Data Usunięcia";
            dataGridView2.Columns["Czesci"].HeaderText = "Użyte Części";

        }
        private void ZaladujProdukcjeDlaMaszyny()
        {
            if (comboBox_lista_rodzaj_obslug.SelectedItem == null)
                return;

            var maszyna = (Maszyna)comboBox_lista_rodzaj_obslug.SelectedItem;

            var lista = context.ZadanieProdukcyjne
                .Where(z => z.IdMaszyna == maszyna.IdMaszyna)
                .Select(z => new
                {
                    z.IdZadanieP,
                    Data = z.DataZadania,

                    RBH = z.Produkcja.Sum(p => (decimal?)p.Rbh) ?? 0
                })
                .ToList();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = lista;

            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.Columns["IdZadanieP"].Visible = false;
            dataGridView3.Columns["RBH"].HeaderText = "Godziny";


        }
        private void PokazSumeRBH()
        {
            if (comboBox_lista_rodzaj_obslug.SelectedItem == null)
                return;

            var maszyna = (Maszyna)comboBox_lista_rodzaj_obslug.SelectedItem;

            decimal suma = context.Produkcja
                .Where(p => p.IdZadaniePNavigation.IdMaszyna == maszyna.IdMaszyna)
                .Sum(p => (decimal?)p.Rbh) ?? 0;

            textBox1.Text = suma.ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            GenerujWykresy();
        }

        private Dictionary<DateOnly, int> RozbijNaDni(IEnumerable<(DateOnly start, DateOnly? end)> dane)
        {
            var wynik = new Dictionary<DateOnly, int>();

            foreach (var d in dane)
            {
                var start = d.start;
                var end = d.end ?? d.start;

                for (var day = start; day <= end; day = day.AddDays(1))
                {
                    if (!wynik.ContainsKey(day))
                        wynik[day] = 0;

                    wynik[day]++;
                }
            }

            return wynik;
        }
        private void GenerujWykresy()
        {
            var maszyna = (Maszyna)comboBox_lista_rodzaj_obslug.SelectedItem;

            // =========================
            // RBH
            // =========================
            var rbhData = context.Produkcja
                .Where(p => p.IdZadaniePNavigation.IdMaszyna == maszyna.IdMaszyna)
                .GroupBy(p => p.IdZadaniePNavigation.DataZadania)
                .Select(g => new { Data = g.Key, RBH = g.Sum(x => x.Rbh) })
                .ToList();

            var rbhDict = rbhData.ToDictionary(x => x.Data, x => x.RBH);

            // =========================
            // AWARIE (dni)
            // =========================
            var awarieRange = RozbijNaDni(
                context.Awaria
                .Where(a => a.IdMaszyna == maszyna.IdMaszyna)
                .ToList()
                .Select(a => (a.DataZgloszenia, a.DataUsuniecia))
            );

            // =========================
            // OBSŁUGI (dni)
            // =========================
            var obslugiRange = RozbijNaDni(
                context.Obsluga
                .Where(o => o.IdMaszyna == maszyna.IdMaszyna)
                .ToList()
                .Select(o => (o.DataPoczatek, o.DataKoniec))
            );

            // =========================
            // WSPÓLNE DATY
            // =========================
            var allDates = rbhData.Select(x => x.Data)
                .Concat(awarieRange.Keys)
                .Concat(obslugiRange.Keys)
                .Distinct()
                .OrderBy(x => x)
                .ToArray();

            int n = allDates.Length;

            double[] xs = Enumerable.Range(0, n).Select(i => (double)i).ToArray();

            string[] labels = allDates.Select(d => d.ToString("dd.MM")).ToArray();

            // =========================
            // RBH
            // =========================
            double[] rbh = allDates
                .Select(d => (double)(rbhDict.TryGetValue(d, out var v) ? v : 0))
                .ToArray();

            // =========================
            // AWARIE
            // =========================
            double[] aw = allDates
                .Select(d => (double)(awarieRange.TryGetValue(d, out var v) ? v : 0))
                .ToArray();

            // =========================
            // OBSŁUGI
            // =========================
            double[] ob = allDates
                .Select(d => (double)(obslugiRange.TryGetValue(d, out var v) ? v : 0))
                .ToArray();

            // =========================
            // 🔵 PLOT 1 - RBH
            // =========================
            formsPlot1.Plot.Clear();

            var bars = formsPlot1.Plot.Add.Bars(xs, rbh);
            bars.LegendText = "RBH";

            formsPlot1.Plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(xs, labels);

            formsPlot1.Plot.Title("RBH - Produkcja");
            formsPlot1.Plot.ShowLegend();

            formsPlot1.Refresh();

            // =========================
            // 🔴 PLOT 2 - AWARIE + OBSŁUGI
            // =========================
            formsPlot2.Plot.Clear();

            var awLine = formsPlot2.Plot.Add.Scatter(xs, aw);
            awLine.Label = "Awarie";

            var obLine = formsPlot2.Plot.Add.Scatter(xs, ob);
            obLine.Label = "Obsługi";

            formsPlot2.Plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(xs, labels);

            formsPlot2.Plot.Title("Serwis - Awarie i Obsługi");
            formsPlot2.Plot.ShowLegend();

            formsPlot2.Refresh();
        }

        private void Form_ocena_stanu_Load(object sender, EventArgs e)
        {

        }
    }
}

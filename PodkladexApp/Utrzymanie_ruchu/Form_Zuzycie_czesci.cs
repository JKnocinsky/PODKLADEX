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
    public partial class Form_Zuzycie_czesci : Form
    {
        PodkladexContext context;
        public Form_Zuzycie_czesci(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            ZaladujFiltryCzesci();
            ZaladujCzesciDoComboBox();
            panel1.Visible = false;
        }
        private void ZaladujCzesciDoComboBox()
        {
            var lista = context.CzescZamienna
                .Select(c => new
                {
                    c.IdCzesci,
                    c.Nazwa
                })
                .OrderBy(c => c.Nazwa)
                .ToList();

            lista.Insert(0, new { IdCzesci = 0, Nazwa = "Wszystkie" });

            cbox_maszyny.DataSource = lista;
            cbox_maszyny.DisplayMember = "Nazwa";
            cbox_maszyny.ValueMember = "IdCzesci";

            cbox_maszyny.SelectedIndex = 0;
        }
        private void ZaladujFiltryCzesci()
        {
            var filtry = new List<KeyValuePair<string, string>>
    {
        new ("ilosc_desc", "Najwięcej użyć"),
        new ("ilosc_asc", "Najmniej użyć"),
        new ("typ_awarie", "Najczęściej w awariach"),
        new ("typ_obslugi", "Najczęściej w obsługach"),
        new ("nazwa", "Alfabetycznie")
    };

            comboBox_filtry.DataSource = filtry;
            comboBox_filtry.DisplayMember = "Value";
            comboBox_filtry.ValueMember = "Key";

            comboBox_filtry.SelectedIndex = 0;
        }
        private void ZaladujRaportZuzyciaCzesci()
        {
            int idCzesci = 0;

            if (cbox_maszyny.SelectedValue != null)
                int.TryParse(cbox_maszyny.SelectedValue.ToString(), out idCzesci);

            // =========================
            // CZĘŚCI Z OBSŁUG
            // =========================
            var obslugi = context.CzesciPrzeglady
                .Select(x => new
                {
                    x.IdCzesci,
                    Nazwa = x.IdCzesciNavigation.Nazwa,
                    Ilosc = x.Liczba,
                    Typ = "Obsługa"
                });

            // =========================
            // CZĘŚCI Z AWARII
            // =========================
            var awarie = context.CzesciAwaria
                .Select(x => new
                {
                    x.IdCzesci,
                    Nazwa = x.IdCzesciNavigation.Nazwa,
                    Ilosc = x.Liczba,
                    Typ = "Awaria"
                });

            // =========================
            // POŁĄCZENIE
            // =========================
            var wszystkie = obslugi.Concat(awarie);

            if (idCzesci != 0)
                wszystkie = wszystkie.Where(x => x.IdCzesci == idCzesci);

            var dane = wszystkie.ToList();

            // =========================
            // GRUPOWANIE
            // =========================
            var wynik = dane
                .GroupBy(x => new { x.IdCzesci, x.Nazwa })
                .Select(g =>
                {
                    int suma = g.Sum(x => x.Ilosc);

                    int awarieCount = g.Where(x => x.Typ == "Awaria").Sum(x => x.Ilosc);
                    int obslugiCount = g.Where(x => x.Typ == "Obsługa").Sum(x => x.Ilosc);

                    string najczesciej =
                        awarieCount > obslugiCount ? "Awarie" :
                        obslugiCount > awarieCount ? "Obsługi" :
                        "Równo";

                    return new
                    {
                        NazwaCzesci = g.Key.Nazwa,
                        IloscUzyc = suma,
                        NajczesciejUzywanePrzy = najczesciej,
                        Awarie = awarieCount,
                        Obslugi = obslugiCount
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
                    case "ilosc_desc":
                        wynik = wynik.OrderByDescending(x => x.IloscUzyc).ToList();
                        break;

                    case "ilosc_asc":
                        wynik = wynik.OrderBy(x => x.IloscUzyc).ToList();
                        break;

                    case "typ_awarie":
                        wynik = wynik.OrderByDescending(x => x.Awarie).ToList();
                        break;

                    case "typ_obslugi":
                        wynik = wynik.OrderByDescending(x => x.Obslugi).ToList();
                        break;

                    case "nazwa":
                        wynik = wynik.OrderBy(x => x.NazwaCzesci).ToList();
                        break;
                }
            }

            // =========================
            // DATA GRID
            // =========================
            dataGridView1.DataSource = wynik;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns["NazwaCzesci"].HeaderText = "Część";
            dataGridView1.Columns["IloscUzyc"].HeaderText = "Ilość użyć";
            dataGridView1.Columns["NajczesciejUzywanePrzy"].HeaderText = "Najczęściej używane przy";

            // opcjonalnie ukryj szczegóły
            dataGridView1.Columns["Awarie"].Visible = false;
            dataGridView1.Columns["Obslugi"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // proporcje szerokości
            dataGridView1.Columns["NazwaCzesci"].FillWeight = 200;
            dataGridView1.Columns["IloscUzyc"].FillWeight = 80;
            dataGridView1.Columns["NajczesciejUzywanePrzy"].FillWeight = 150;
            dataGridView1.Font = new Font("Segoe UI", 14);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void cbox_maszyny_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujRaportZuzyciaCzesci();
        }

        private void comboBox_filtry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaladujRaportZuzyciaCzesci();
        }

        private void button_rysuj_wykres_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            RysujWykresZuzyciaCzesci();
        }
        private void RysujWykresZuzyciaCzesci()
        {
            var dane = dataGridView1.DataSource as IEnumerable<dynamic>;
            if (dane == null) return;

            var czesci = dane.Select(x => (string)x.NazwaCzesci).ToArray();
            var ilosci = dane.Select(x => (double)x.IloscUzyc).ToArray();

            formsPlot1.Plot.Clear();

            // 🔥 słupki
            var bars = formsPlot1.Plot.Add.Bars(ilosci);

            // indeksy X
            double[] xs = Enumerable.Range(0, czesci.Length)
                                    .Select(i => (double)i)
                                    .ToArray();

            formsPlot1.Plot.Axes.Bottom.SetTicks(xs, czesci);

            formsPlot1.Plot.Title("Zużycie części");
            formsPlot1.Plot.YLabel("Ilość użyć");
            formsPlot1.Plot.XLabel("Części");

            formsPlot1.Plot.Axes.AutoScale();

            formsPlot1.Refresh();
        }
    }
}

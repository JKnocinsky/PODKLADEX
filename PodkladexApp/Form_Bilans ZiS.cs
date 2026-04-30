using PodkladexApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScottPlot;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DrawingColor = System.Drawing.Color;
using FormsLabel = System.Windows.Forms.Label;

namespace PodkladexApp
{
    public partial class Form_BilansZiS : Form
    {
        private readonly PodkladexContext db;
        private readonly string connectionString;

        public Form_BilansZiS()
        {
            InitializeComponent();
            db = new PodkladexContext();
            connectionString = db.Database.GetDbConnection().ConnectionString;
        }
        private readonly DrawingColor[] koloryLegendy =
        {
            DrawingColor.SteelBlue,
            DrawingColor.Orange,
            DrawingColor.SeaGreen,
            DrawingColor.IndianRed,
            DrawingColor.MediumPurple
        };

        private void Form_BilansZiS_Load(object sender, EventArgs e)
        {
            ZaladujMiesiace();
            ZaladujLata();
            KonfigurujDataGridView();
            WyczyscPodsumowanie();
            WyczyscWykres();
        }

        private void ZaladujMiesiace()
        {
            comboBox_miesiacOd.Items.Clear();
            comboBox_miesiacDo.Items.Clear();

            for (int i = 1; i <= 12; i++)
            {
                comboBox_miesiacOd.Items.Add(i);
                comboBox_miesiacDo.Items.Add(i);
            }

            comboBox_miesiacOd.SelectedItem = 1;
            comboBox_miesiacDo.SelectedItem = DateTime.Today.Month;
        }

        private void ZaladujLata()
        {
            comboBox_rokOd.Items.Clear();
            comboBox_rokDo.Items.Clear();

            for (int i = 2024; i <= 2035; i++)
            {
                comboBox_rokOd.Items.Add(i);
                comboBox_rokDo.Items.Add(i);
            }

            comboBox_rokOd.SelectedItem = DateTime.Today.Year;
            comboBox_rokDo.SelectedItem = DateTime.Today.Year;
        }

        private void KonfigurujDataGridView()
        {
            dataGridView_bilans.AutoGenerateColumns = true;
            dataGridView_bilans.AllowUserToAddRows = false;
            dataGridView_bilans.AllowUserToDeleteRows = false;
            dataGridView_bilans.ReadOnly = true;
            dataGridView_bilans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_bilans.MultiSelect = false;
            dataGridView_bilans.RowHeadersVisible = false;
            dataGridView_bilans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void WyczyscPodsumowanie()
        {
            textBox_przychody.Text = "0,00 zł";
            textBox_wydatki.Text = "0,00 zł";
            textBox_dochod.Text = "0,00 zł";
        }

        private void WyczyscWykres()
        {
            formsPlot_bilans.Plot.Clear();
            formsPlot_bilans.Plot.Title("Struktura wydatków");
            formsPlot_bilans.Refresh();

            flowLayoutPanel_legenda.Controls.Clear();
        }

        private void button_pokazBilans_Click(object sender, EventArgs e)
        {
            if (comboBox_miesiacOd.SelectedItem == null ||
                comboBox_rokOd.SelectedItem == null ||
                comboBox_miesiacDo.SelectedItem == null ||
                comboBox_rokDo.SelectedItem == null)
            {
                MessageBox.Show(
                    "Wybierz pełny zakres dat.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int miesiacOd = Convert.ToInt32(comboBox_miesiacOd.SelectedItem);
                int rokOd = Convert.ToInt32(comboBox_rokOd.SelectedItem);
                int miesiacDo = Convert.ToInt32(comboBox_miesiacDo.SelectedItem);
                int rokDo = Convert.ToInt32(comboBox_rokDo.SelectedItem);

                int okresOd = rokOd * 100 + miesiacOd;
                int okresDo = rokDo * 100 + miesiacDo;

                if (okresOd > okresDo)
                {
                    MessageBox.Show(
                        "Data początkowa nie może być późniejsza niż data końcowa.",
                        "Błędny zakres",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = PobierzBilansZOkresu(okresOd, okresDo);

                dataGridView_bilans.DataSource = null;
                dataGridView_bilans.DataSource = dt;

                UstawNaglowkiKolumn();
                PodsumujBilans(dt);
                RysujWykresWydatkow(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas pobierania bilansu:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DataTable PobierzBilansZOkresu(int okresOd, int okresDo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        Rok,
                        Miesiac,
                        Przychody,
                        KosztyDostaw,
                        KosztySzkolen,
                        KosztyBadan,
                        KosztyWysylek,
                        KosztyWynagrodzen,
                        Wydatki,
                        Dochod
                    FROM dbo.Bilans_Miesieczny
                    WHERE (Rok * 100 + Miesiac) BETWEEN @OkresOd AND @OkresDo
                    ORDER BY Rok, Miesiac;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OkresOd", okresOd);
                    cmd.Parameters.AddWithValue("@OkresDo", okresDo);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        private void PodsumujBilans(DataTable dt)
        {
            decimal sumaPrzychodow = 0;
            decimal sumaWydatkow = 0;
            decimal sumaDochodu = 0;

            foreach (DataRow row in dt.Rows)
            {
                sumaPrzychodow += row["Przychody"] != DBNull.Value
                    ? Convert.ToDecimal(row["Przychody"])
                    : 0;

                sumaWydatkow += row["Wydatki"] != DBNull.Value
                    ? Convert.ToDecimal(row["Wydatki"])
                    : 0;

                sumaDochodu += row["Dochod"] != DBNull.Value
                    ? Convert.ToDecimal(row["Dochod"])
                    : 0;
            }

            textBox_przychody.Text = sumaPrzychodow.ToString("N2") + " zł";
            textBox_wydatki.Text = sumaWydatkow.ToString("N2") + " zł";
            textBox_dochod.Text = sumaDochodu.ToString("N2") + " zł";
        }

        private void RysujWykresWydatkow(DataTable dt)
        {
            double kosztyDostaw = 0;
            double kosztySzkolen = 0;
            double kosztyBadan = 0;
            double kosztyWysylek = 0;
            double kosztyWynagrodzen = 0;

            foreach (DataRow row in dt.Rows)
            {
                kosztyDostaw += row["KosztyDostaw"] != DBNull.Value
                    ? Convert.ToDouble(row["KosztyDostaw"])
                    : 0;

                kosztySzkolen += row["KosztySzkolen"] != DBNull.Value
                    ? Convert.ToDouble(row["KosztySzkolen"])
                    : 0;

                kosztyBadan += row["KosztyBadan"] != DBNull.Value
                    ? Convert.ToDouble(row["KosztyBadan"])
                    : 0;

                kosztyWysylek += row["KosztyWysylek"] != DBNull.Value
                    ? Convert.ToDouble(row["KosztyWysylek"])
                    : 0;

                kosztyWynagrodzen += row["KosztyWynagrodzen"] != DBNull.Value
                    ? Convert.ToDouble(row["KosztyWynagrodzen"])
                    : 0;
            }

            formsPlot_bilans.Plot.Clear();

            double[] values =
            {
                kosztyDostaw,
                kosztySzkolen,
                kosztyBadan,
                kosztyWysylek,
                kosztyWynagrodzen
            };

            string[] labels =
            {
                "Dostawy",
                "Szkolenia",
                "Badania",
                "Wysyłki",
                "Wynagrodzenia"
            };

            var pie = formsPlot_bilans.Plot.Add.Pie(values);

            formsPlot_bilans.Plot.Title("Struktura wydatków");
            formsPlot_bilans.Plot.Axes.AutoScale();
            formsPlot_bilans.Plot.Axes.Margins(0.05, 0.05);
            formsPlot_bilans.Refresh();

            UstawLegendeWydatkow(values, labels);
        }

        private void UstawLegendeWydatkow(double[] values, string[] labels)
        {
            flowLayoutPanel_legenda.Controls.Clear();

            double suma = values.Sum();

            if (suma <= 0)
            {
                FormsLabel brakDanych = new FormsLabel();
                brakDanych.Text = "Brak danych do wyświetlenia.";
                brakDanych.AutoSize = true;
                flowLayoutPanel_legenda.Controls.Add(brakDanych);
                return;
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] <= 0)
                    continue;

                double procent = values[i] / suma * 100.0;
                DodajWierszLegendy(
                    koloryLegendy[i % koloryLegendy.Length],
                    $"{labels[i]}: {values[i]:N2} zł ({procent:N1}%)");
            }
        }

        private void DodajWierszLegendy(DrawingColor kolor, string tekst)
        {
            Panel wiersz = new Panel();
            wiersz.Width = flowLayoutPanel_legenda.ClientSize.Width - 25;
            wiersz.Height = 28;
            wiersz.Margin = new Padding(3);

            Panel probkaKoloru = new Panel();
            probkaKoloru.BackColor = kolor;
            probkaKoloru.Width = 18;
            probkaKoloru.Height = 18;
            probkaKoloru.Left = 3;
            probkaKoloru.Top = 5;
            probkaKoloru.BorderStyle = BorderStyle.FixedSingle;

            FormsLabel opis = new FormsLabel();
            opis.Text = tekst;
            opis.AutoSize = false;
            opis.Left = 28;
            opis.Top = 4;
            opis.Width = wiersz.Width - 32;
            opis.Height = 20;

            wiersz.Controls.Add(probkaKoloru);
            wiersz.Controls.Add(opis);

            flowLayoutPanel_legenda.Controls.Add(wiersz);
        }

        private void UstawNaglowkiKolumn()
        {
            if (dataGridView_bilans.Columns.Count == 0)
                return;

            if (dataGridView_bilans.Columns["Rok"] != null)
                dataGridView_bilans.Columns["Rok"].HeaderText = "Rok";

            if (dataGridView_bilans.Columns["Miesiac"] != null)
                dataGridView_bilans.Columns["Miesiac"].HeaderText = "Miesiąc";

            if (dataGridView_bilans.Columns["Przychody"] != null)
                dataGridView_bilans.Columns["Przychody"].HeaderText = "Przychody";

            if (dataGridView_bilans.Columns["KosztyDostaw"] != null)
                dataGridView_bilans.Columns["KosztyDostaw"].HeaderText = "Koszty dostaw";

            if (dataGridView_bilans.Columns["KosztySzkolen"] != null)
                dataGridView_bilans.Columns["KosztySzkolen"].HeaderText = "Koszty szkoleń";

            if (dataGridView_bilans.Columns["KosztyBadan"] != null)
                dataGridView_bilans.Columns["KosztyBadan"].HeaderText = "Koszty badań";

            if (dataGridView_bilans.Columns["KosztyWysylek"] != null)
                dataGridView_bilans.Columns["KosztyWysylek"].HeaderText = "Koszty wysyłek";

            if (dataGridView_bilans.Columns["KosztyWynagrodzen"] != null)
                dataGridView_bilans.Columns["KosztyWynagrodzen"].HeaderText = "Koszty wynagrodzeń";

            if (dataGridView_bilans.Columns["Wydatki"] != null)
                dataGridView_bilans.Columns["Wydatki"].HeaderText = "Wydatki";

            if (dataGridView_bilans.Columns["Dochod"] != null)
                dataGridView_bilans.Columns["Dochod"].HeaderText = "Dochód";
        }
    }
}
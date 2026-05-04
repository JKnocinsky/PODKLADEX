using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PodkladexApp.Models;

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_HistoriaDostaw : Form
    {
        private PodkladexContext _context = new PodkladexContext();

        public Form_HistoriaDostaw()
        {
            InitializeComponent();

            // KROK 1: TWARDE PODPIĘCIE STARTU FORMULARZA (To tu był problem!)
            this.Load += Form_HistoriaZamowien_Load;
        }

        private void UstawWygladTabeli()
        {
            dataGridView_HistoriaZamowien.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView_HistoriaZamowien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dataGridView_HistoriaZamowien.RowTemplate.Height = 40;
            dataGridView_HistoriaZamowien.ColumnHeadersHeight = 50;
            dataGridView_HistoriaZamowien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dateTimePicker_Poczatek.Font = new Font("Segoe UI", 14);
            dateTimePicker_Koniec.Font = new Font("Segoe UI", 14);
        }

        private void Form_HistoriaZamowien_Load(object sender, EventArgs e)
        {
            UstawWygladTabeli();

            // Szeroki margines daty, aby złapać testowe dane z bazy
            dateTimePicker_Poczatek.Value = DateTime.Now.AddYears(-2);
            dateTimePicker_Koniec.Value = DateTime.Now.AddMonths(1);

            // =======================================================
            // KROK 2: KULOODPORNE PODPIĘCIE KONTROLEK
            // =======================================================
            radioButton_StatusWszystkie.CheckedChanged -= radioButton_StatusWszystkie_CheckedChanged;
            radioButton_StatusWszystkie.CheckedChanged += radioButton_StatusWszystkie_CheckedChanged;

            radioButton_StatusWToku.CheckedChanged -= radioButton_StatusWToku_CheckedChanged;
            radioButton_StatusWToku.CheckedChanged += radioButton_StatusWToku_CheckedChanged;

            radioButton_StatusZakonczone.CheckedChanged -= radioButton_StatusZakonczone_CheckedChanged;
            radioButton_StatusZakonczone.CheckedChanged += radioButton_StatusZakonczone_CheckedChanged;

            comboBox_sortowanie.SelectedIndexChanged -= comboBox_sortowanie_SelectedIndexChanged;
            comboBox_sortowanie.SelectedIndexChanged += comboBox_sortowanie_SelectedIndexChanged;

            dataGridView_HistoriaZamowien.SelectionChanged -= dataGridView_HistoriaZamowien_SelectionChanged;
            dataGridView_HistoriaZamowien.SelectionChanged += dataGridView_HistoriaZamowien_SelectionChanged;

            button_Szczegoly.Click -= button_Szczegoly_Click;
            button_Szczegoly.Click += button_Szczegoly_Click;

            // Ustawienia początkowe
            button_Szczegoly.Click -= button_Szczegoly_Click;
            button_Szczegoly.Click += button_Szczegoly_Click;

            // NOWE: Automatyczne kolorowanie w locie
            dataGridView_HistoriaZamowien.CellFormatting -= dataGridView_HistoriaZamowien_CellFormatting;
            dataGridView_HistoriaZamowien.CellFormatting += dataGridView_HistoriaZamowien_CellFormatting;

            // Ustawienia początkowe
            radioButton_StatusWszystkie.Checked = true;



            if (comboBox_sortowanie.Items.Count == 0)
            {
                comboBox_sortowanie.Items.AddRange(new string[] {
                    "Data - od najnowszych",
                    "Data - od najstarszych",
                    "Wartość - malejąco",
                    "Wartość - rosnąco",
                    "Dostawca (A-Z)",
                    "Status dostawy"
                });
            }

            comboBox_sortowanie.SelectedIndex = 0;

            // Włączamy podpowiedzi (tooltipy), gdy materiałów będzie dużo
            dataGridView_HistoriaZamowien.ShowCellToolTips = true;

            WyswietlHistorieZamowien();
        }

        private void WyswietlHistorieZamowien()
        {
            if (comboBox_sortowanie.SelectedIndex == -1) return;

            try
            {
                var dataOd = DateOnly.FromDateTime(dateTimePicker_Poczatek.Value);
                var dataDo = DateOnly.FromDateTime(dateTimePicker_Koniec.Value);
                var dataDzisiaj = DateOnly.FromDateTime(DateTime.Now);

                // 1. ZBUDOWANIE BAZY ZAPYTANIA (Zależności pobieramy do pamięci - Eager Loading)
                var zapytanieBaza = _context.Dostawa
                    .Include(d => d.IdFirmaNavigation)
                    .Include(d => d.SzczegolyDostawy)
                        .ThenInclude(sd => sd.IdMaterialNavigation)
                            .ThenInclude(m => m.IdRodzajNavigation)
                    .Include(d => d.SzczegolyDostawy)
                        .ThenInclude(sd => sd.IdMaterialNavigation)
                            .ThenInclude(m => m.MaterialWlasciwosci)
                    .Where(d => d.DataDostawy >= dataOd && d.DataDostawy <= dataDo)
                    .AsQueryable();

                if (radioButton_StatusWToku.Checked)
                {
                    zapytanieBaza = zapytanieBaza.Where(d => d.DataDostawy > dataDzisiaj);
                }
                else if (radioButton_StatusZakonczone.Checked)
                {
                    zapytanieBaza = zapytanieBaza.Where(d => d.DataDostawy <= dataDzisiaj);
                }

                // Pobranie danych do pamięci RAM - musimy to zrobić, by C# mógł skleić tekst!
                var pobraneDostawy = zapytanieBaza.ToList();

                // 2. SKLEJANIE WYNIKÓW I MAPOWANIE DO TABELI
                var wynik = pobraneDostawy.Select(d => new
                {
                    IdZamowienia = d.IdDostawa,
                    Klient = d.IdFirmaNavigation != null ? d.IdFirmaNavigation.Nazwa : "Brak danych firmy",
                    DataZlozenia = d.DataDostawy,

                    Status = d.DataDostawy > dataDzisiaj ? "W trakcie (w drodze)" : "Dostarczone",

                    CenaZbiorcza = d.SzczegolyDostawy.Any()
                                   ? d.SzczegolyDostawy.Sum(sz => sz.Cena * sz.Liczba)
                                   : 0m,

                    // Sklejamy materiały: \n zrzuci każdy materiał do nowej linijki w dymku (tooltip)
                    Materialy = string.Join(" \n", d.SzczegolyDostawy.Select(s =>
                    {
                        var mat = s.IdMaterialNavigation;
                        var grubo = mat?.MaterialWlasciwosci?.FirstOrDefault()?.WartoscNominalna;
                        var rodzaj = mat?.IdRodzajNavigation?.Nazwa;

                        return $"{mat?.Nazwa ?? "Nieznany"} || {(grubo.HasValue ? grubo.Value.ToString() : "Brak wymiaru")} || {(rodzaj ?? "Brak rodzaju")}";
                    }))
                }).ToList();

                // 3. SORTOWANIE W PAMIĘCI
                switch (comboBox_sortowanie.SelectedIndex)
                {
                    case 0: wynik = wynik.OrderByDescending(z => z.DataZlozenia).ToList(); break;
                    case 1: wynik = wynik.OrderBy(z => z.DataZlozenia).ToList(); break;
                    case 2: wynik = wynik.OrderByDescending(z => z.CenaZbiorcza).ToList(); break;
                    case 3: wynik = wynik.OrderBy(z => z.CenaZbiorcza).ToList(); break;
                    case 4: wynik = wynik.OrderBy(z => z.Klient).ToList(); break;
                    case 5: wynik = wynik.OrderByDescending(z => z.Status).ToList(); break;
                }

                // 4. ZASILENIE TABELI
                dataGridView_HistoriaZamowien.DataSource = wynik;

                // 5. FORMATOWANIE TABELI I UKRYWANIE TEKSTU DLA TOOLTIPÓW
                if (dataGridView_HistoriaZamowien.Columns.Count > 0)
                {
                    dataGridView_HistoriaZamowien.Columns["IdZamowienia"].HeaderText = "ID Dostawy";
                    dataGridView_HistoriaZamowien.Columns["IdZamowienia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dataGridView_HistoriaZamowien.Columns["Klient"].HeaderText = "Dostawca";
                    dataGridView_HistoriaZamowien.Columns["DataZlozenia"].HeaderText = "Data dostawy";

                    dataGridView_HistoriaZamowien.Columns["Status"].HeaderText = "Status";
                    dataGridView_HistoriaZamowien.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Zmiana nazwy nagłówka - dodajemy [zł]
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].HeaderText = "Wartość [zł]";

                    // Zmiana formatu z "C2" (Waluta) na "N2" (Liczba)
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].DefaultCellStyle.Format = "N2";

                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Opcjonalnie: wyrównanie liczb do prawej (standard dla księgowości)
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView_HistoriaZamowien.Columns["Materialy"].HeaderText = "Materiały";
                    // Zabraniamy łamania linii w komórce siatki - pokażą się "..." a po najechaniu pełna lista
                    dataGridView_HistoriaZamowien.Columns["Materialy"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych: \n\n{ex.Message}\n\nInner: {ex.InnerException?.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KolorujStatus()
        {
            foreach (DataGridViewRow row in dataGridView_HistoriaZamowien.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "W trakcie (w drodze)")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.OrangeRed;
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    }
                    else if (status == "Dostarczone")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.ForestGreen;
                    }
                }
            }
        }

        private void dataGridView_HistoriaZamowien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Sprawdzamy, czy obecnie rysowana komórka należy do kolumny "Status" i czy nie jest pusta
            if (dataGridView_HistoriaZamowien.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "W trakcie (w drodze)")
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                    e.CellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                }
                else if (status == "Dostarczone")
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                    // Przywracamy standardową czcionkę dla zakończonych, żeby nie zostały pogrubione po sortowaniu
                    e.CellStyle.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                }
            }
        }

        private void dateTimePicker_Poczatek_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void dateTimePicker_Koniec_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        private void radioButton_StatusWszystkie_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_StatusWToku_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_StatusZakonczone_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        private void comboBox_sortowanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            WyswietlHistorieZamowien();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        private void dataGridView_HistoriaZamowien_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                button_Szczegoly.Enabled = true;
            }
            else
            {
                button_Szczegoly.Enabled = false;
            }
        }

        private void button_Szczegoly_Click(object sender, EventArgs e)
        {
            OtworzSzczegoly();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OtworzSzczegoly();
        }

        private void OtworzSzczegoly()
        {
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView_HistoriaZamowien.SelectedRows[0];

                if (row.Cells["IdZamowienia"].Value != null)
                {
                    int idWybranejDostawy = Convert.ToInt32(row.Cells["IdZamowienia"].Value);

                    // Form_HistoriaDostawSzczegoly formSzczegoly = new Form_HistoriaDostawSzczegoly(idWybranejDostawy);
                    // formSzczegoly.ShowDialog();

                    WyswietlHistorieZamowien();
                }
                else
                {
                    MessageBox.Show("Nie można odnaleźć ID tej dostawy.");
                }
            }
        }

        private void dataGridView_HistoriaZamowien_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label_data_Poczatku_Click(object sender, EventArgs e) { }
    }
}
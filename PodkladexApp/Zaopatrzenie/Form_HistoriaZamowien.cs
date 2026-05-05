using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PodkladexApp.Models;

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_HistoriaZamowien : Form
    {
        private int _idZamowienia;
        private PodkladexContext _context = new PodkladexContext();

        public Form_HistoriaZamowien()
        {
            InitializeComponent();
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

            dateTimePicker_Poczatek.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker_Koniec.Value = DateTime.Now;

            // Zdarzenia dla typu klienta
            radioButton_Wszyscy.CheckedChanged -= radioButton_Wszyscy_CheckedChanged;
            radioButton_Wszyscy.CheckedChanged += radioButton_Wszyscy_CheckedChanged;
            radioButton_Firmy.CheckedChanged -= radioButton_Firmy_CheckedChanged;
            radioButton_Firmy.CheckedChanged += radioButton_Firmy_CheckedChanged;
            radioButton_Osoby.CheckedChanged -= radioButton_Osoby_CheckedChanged;
            radioButton_Osoby.CheckedChanged += radioButton_Osoby_CheckedChanged;

            // Zdarzenia dla statusu zamówienia
            radioButton_StatusWszystkie.CheckedChanged -= radioButton_StatusWszystkie_CheckedChanged;
            radioButton_StatusWszystkie.CheckedChanged += radioButton_StatusWszystkie_CheckedChanged;
            radioButton_StatusWToku.CheckedChanged -= radioButton_StatusWToku_CheckedChanged;
            radioButton_StatusWToku.CheckedChanged += radioButton_StatusWToku_CheckedChanged;
            radioButton_StatusZakonczone.CheckedChanged -= radioButton_StatusZakonczone_CheckedChanged;
            radioButton_StatusZakonczone.CheckedChanged += radioButton_StatusZakonczone_CheckedChanged;

            // Zdarzenie kolorowania w locie
            dataGridView_HistoriaZamowien.CellFormatting -= dataGridView_HistoriaZamowien_CellFormatting;
            dataGridView_HistoriaZamowien.CellFormatting += dataGridView_HistoriaZamowien_CellFormatting;

            radioButton_StatusWszystkie.Checked = true;

            if (comboBox_sortowanie.Items.Count == 0)
            {
                comboBox_sortowanie.Items.AddRange(new string[] {
                    "Data - od najnowszych",
                    "Data - od najstarszych",
                    "Cena - malejąco",
                    "Cena - rosnąco",
                    "Klient (A-Z)",
                    "Status zamówienia"
                });
            }

            comboBox_sortowanie.SelectedIndex = 0;
            WyswietlHistorieZamowien();
        }

        private void WyswietlHistorieZamowien()
        {
            if (comboBox_sortowanie.SelectedIndex == -1) return;

            var dataOd = DateOnly.FromDateTime(dateTimePicker_Poczatek.Value);
            var dataDo = DateOnly.FromDateTime(dateTimePicker_Koniec.Value);

            // 1. ZBUDOWANIE BAZY ZAPYTANIA I BEZPIECZNE POBRANIE DO RAM
            // Wykorzystujemy .Include(), by zaciągnąć dane przed skomplikowanym filtrowaniem.
            var zapytanieBaza = _context.Zamowienie
                .Include(z => z.IdKlientNavigation)
                    .ThenInclude(k => k.KlientFirma)
                        .ThenInclude(kf => kf.IdFirmaNavigation)
                .Include(z => z.IdKlientNavigation)
                    .ThenInclude(k => k.IdOsobaNavigation)
                .Include(z => z.SzczegolyZamowienia)
                .Where(z => z.DataPrzyjeciaZ >= dataOd && z.DataPrzyjeciaZ <= dataDo)
                .AsQueryable();

            if (radioButton_StatusWToku.Checked)
            {
                zapytanieBaza = zapytanieBaza.Where(z => z.DataZrealizowaniaZ == null);
            }
            else if (radioButton_StatusZakonczone.Checked)
            {
                zapytanieBaza = zapytanieBaza.Where(z => z.DataZrealizowaniaZ != null);
            }

            // Pobieramy wstępnie odfiltrowane po datach zamówienia do pamięci.
            // Dzięki temu omijamy ułomności Entity Framework w tłumaczeniu skomplikowanych dat SQL.
            var zamowieniaZBazy = zapytanieBaza.ToList();

            // 2. MAPOWANIE Z NIEZAWODNĄ LOGIKĄ W C#
            var listaZmapowana = zamowieniaZBazy.Select(z =>
            {
                // Sprawdzamy czy W DNIU zamówienia istniało aktywne powiązanie firmowe
                var aktywnePowiazanie = z.IdKlientNavigation?.KlientFirma?
                    .FirstOrDefault(kf => kf.DataPocz <= z.DataPrzyjeciaZ &&
                                          (kf.DataKoniec == null || kf.DataKoniec >= z.DataPrzyjeciaZ));

                bool jestFirma = aktywnePowiazanie != null && aktywnePowiazanie.IdFirmaNavigation != null;

                string klientNazwa = jestFirma
                    ? aktywnePowiazanie.IdFirmaNavigation.Nazwa
                    : (z.IdKlientNavigation?.IdOsobaNavigation != null
                        ? $"{z.IdKlientNavigation.IdOsobaNavigation.Imie} {z.IdKlientNavigation.IdOsobaNavigation.Nazwisko}"
                        : "Brak danych");

                return new
                {
                    IdZamowienia = z.IdZamowienie,
                    Klient = klientNazwa,
                    JestFirma = jestFirma, // Ukryta flaga pomocnicza
                    DataZlozenia = z.DataPrzyjeciaZ,
                    Status = z.DataZrealizowaniaZ == null ? "W trakcie realizacji" : "Zakończone",
                    CenaZbiorcza = z.SzczegolyZamowienia?.Any() == true
                                   ? z.SzczegolyZamowienia.Sum(sz => sz.Cena * sz.Ilosc)
                                   : 0m
                };
            }).AsEnumerable(); // Otwieramy drogę do dalszych działań na pamięci

            // 3. FILTROWANIE PO TYPIE KLIENTA NA PRZETWORZONYCH DANYCH
            if (radioButton_Firmy.Checked)
            {
                listaZmapowana = listaZmapowana.Where(z => z.JestFirma);
            }
            else if (radioButton_Osoby.Checked)
            {
                listaZmapowana = listaZmapowana.Where(z => !z.JestFirma);
            }

            // 4. SORTOWANIE
            switch (comboBox_sortowanie.SelectedIndex)
            {
                case 0: listaZmapowana = listaZmapowana.OrderByDescending(z => z.DataZlozenia); break;
                case 1: listaZmapowana = listaZmapowana.OrderBy(z => z.DataZlozenia); break;
                case 2: listaZmapowana = listaZmapowana.OrderByDescending(z => z.CenaZbiorcza); break;
                case 3: listaZmapowana = listaZmapowana.OrderBy(z => z.CenaZbiorcza); break;
                case 4: listaZmapowana = listaZmapowana.OrderBy(z => z.Klient); break;
                case 5: listaZmapowana = listaZmapowana.OrderByDescending(z => z.Status); break;
            }

            // 5. ODRZUCENIE ZBĘDNYCH DANYCH I PRZYPISANIE DO TABELI
            // Usuwamy flagę 'JestFirma', aby tabela wyświetliła tylko czyste, ładne kolumny
            var wynik = listaZmapowana.Select(w => new {
                w.IdZamowienia,
                w.Klient,
                w.DataZlozenia,
                w.Status,
                w.CenaZbiorcza
            }).ToList();

            dataGridView_HistoriaZamowien.DataSource = wynik;

            // 6. FORMATOWANIE KOLUMN
            if (dataGridView_HistoriaZamowien.Columns.Count > 0)
            {
                if (dataGridView_HistoriaZamowien.Columns["IdZamowienia"] != null)
                    dataGridView_HistoriaZamowien.Columns["IdZamowienia"].HeaderText = "ID Zamówienia";

                if (dataGridView_HistoriaZamowien.Columns["Klient"] != null)
                    dataGridView_HistoriaZamowien.Columns["Klient"].HeaderText = "Klient";

                if (dataGridView_HistoriaZamowien.Columns["DataZlozenia"] != null)
                    dataGridView_HistoriaZamowien.Columns["DataZlozenia"].HeaderText = "Data zamówienia";

                if (dataGridView_HistoriaZamowien.Columns["Status"] != null)
                {
                    dataGridView_HistoriaZamowien.Columns["Status"].HeaderText = "Status";
                    dataGridView_HistoriaZamowien.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"] != null)
                {
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].HeaderText = "Wartość zamówienia";
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].DefaultCellStyle.Format = "C2";
                }
            }
        }

        // =======================================================
        // KOLOROWANIE W LOCIE (Bez migania)
        // =======================================================
        private void dataGridView_HistoriaZamowien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView_HistoriaZamowien.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "W trakcie realizacji")
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                    e.CellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                }
                else if (status == "Zakończone")
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                    e.CellStyle.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                }
            }
        }

        // =======================================================
        // ZDARZENIA (EVENTY)
        // =======================================================
        private void dateTimePicker_Poczatek_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void dateTimePicker_Koniec_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        private void radioButton_Wszyscy_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_Firmy_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_Osoby_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        private void radioButton_StatusWszystkie_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_StatusWToku_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_StatusZakonczone_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        private void comboBox_sortowanie_SelectedIndexChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

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

        private void button_Szczegoly_Click(object sender, EventArgs e) => OtworzSzczegoly();
        private void button1_Click(object sender, EventArgs e) => OtworzSzczegoly();

        private void OtworzSzczegoly()
        {
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView_HistoriaZamowien.SelectedRows[0];

                if (row.Cells["IdZamowienia"].Value != null)
                {
                    int idWybranegoZamowienia = Convert.ToInt32(row.Cells["IdZamowienia"].Value);

                    Form_HistoriaZamowienSzczegoly formSzczegoly = new Form_HistoriaZamowienSzczegoly(idWybranegoZamowienia);
                    formSzczegoly.ShowDialog();

                    WyswietlHistorieZamowien();
                }
                else
                {
                    MessageBox.Show("Nie można odnaleźć ID tego zamówienia.");
                }
            }
        }

        private void dataGridView_HistoriaZamowien_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label_data_Poczatku_Click(object sender, EventArgs e) { }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Migrations;
using PodkladexApp.Models; // Przestrzeń nazw dla modeli: Zamowienie, Klient, Osoba

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_HistoriaZamowien : Form
    {
        private int _idZamowienia;

        // Instancja kontekstu bazy danych
        private PodkladexContext _context = new PodkladexContext();

        public Form_HistoriaZamowien()
        {
            InitializeComponent();
        }

        private void UstawWygladTabeli()
        {
            // Ustawienie czcionki dla komórek z danymi (Segoe UI, 14px)
            dataGridView_HistoriaZamowien.DefaultCellStyle.Font = new Font("Segoe UI", 14);

            // Ustawienie czcionki dla nagłówków kolumn (Segoe UI, 14px, opcjonalnie pogrubiona)
            dataGridView_HistoriaZamowien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // Zwiększenie wysokości wierszy, żeby większa czcionka się swobodnie mieściła
            dataGridView_HistoriaZamowien.RowTemplate.Height = 40;
            dataGridView_HistoriaZamowien.ColumnHeadersHeight = 50;

            // Żeby tekst ładnie mieścił się w komórkach (opcjonalne, ale polecane)
            dataGridView_HistoriaZamowien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dateTimePicker_Poczatek.Font = new Font("Segoe UI", 14);
            dateTimePicker_Koniec.Font = new Font("Segoe UI", 14);
        }

        private void Form_HistoriaZamowien_Load(object sender, EventArgs e)
        {
            UstawWygladTabeli();

            // Inicjalizacja zakresu dat w kontrolkach
            dateTimePicker_Poczatek.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker_Koniec.Value = DateTime.Now;

            // =======================================================
            // PODPIĘCIE ZDARZEŃ (Żeby odświeżało się samo przy kliknięciu)
            // =======================================================
            radioButton_Wszyscy.CheckedChanged += radioButton_Wszyscy_CheckedChanged;
            radioButton_Firmy.CheckedChanged += radioButton_Firmy_CheckedChanged;
            radioButton_Osoby.CheckedChanged += radioButton_Osoby_CheckedChanged;

            // Wypełnienie opcji sortowania w ComboBox
            if (comboBox_sortowanie.Items.Count == 0)
            {
                comboBox_sortowanie.Items.AddRange(new string[] {
                    "Data - od najnowszych",
                    "Data - od najstarszych",
                    "Cena - malejąco",
                    "Cena - rosnąco",
                    "Klient (A-Z)"
                });
            }

            comboBox_sortowanie.SelectedIndex = 0;
            WyswietlHistorieZamowien();
        }

        private void WyswietlHistorieZamowien()
        {
            // Zabezpieczenie przed błędem, jeśli ComboBox nie jest jeszcze zainicjalizowany
            if (comboBox_sortowanie.SelectedIndex == -1) return;

            // Konwersja dat z DateTimePicker na DateOnly (wymagane przez model)
            var dataOd = DateOnly.FromDateTime(dateTimePicker_Poczatek.Value);
            var dataDo = DateOnly.FromDateTime(dateTimePicker_Koniec.Value);

            // 1. ZBUDOWANIE BAZY ZAPYTANIA (Filtrowanie daty)
            var zapytanieBaza = _context.Zamowienie
                .Where(z => z.DataPrzyjeciaZ >= dataOd && z.DataPrzyjeciaZ <= dataDo)
                .AsQueryable();

            // ====================================================
            // 2. NOWE: FILTROWANIE PO TYPIE KLIENTA (RadioButtony)
            // ====================================================
            if (radioButton_Firmy.Checked)
            {
                // Tylko zamówienia klientów, którzy mają aktywne powiązanie z firmą
                zapytanieBaza = zapytanieBaza.Where(z => z.IdKlientNavigation.KlientFirma.Any(kf => kf.DataKoniec == null));
            }
            else if (radioButton_Osoby.Checked)
            {
                // Tylko zamówienia klientów prywatnych (brak aktywnego powiązania z firmą)
                zapytanieBaza = zapytanieBaza.Where(z => !z.IdKlientNavigation.KlientFirma.Any(kf => kf.DataKoniec == null));
            }
            // Jeśli radioButton_Wszyscy.Checked jest True, po prostu omijamy filtry (ładuje wszystko)

            // 3. MAPOWANIE DO WIDOKU W TABELI (Select)
            var zapytanie = zapytanieBaza.Select(z => new
            {
                IdZamowienia = z.IdZamowienie,

                Klient = z.IdKlientNavigation.KlientFirma.Any(kf => kf.DataKoniec == null)
                    ? z.IdKlientNavigation.KlientFirma.FirstOrDefault(kf => kf.DataKoniec == null).IdFirmaNavigation.Nazwa
                    : (z.IdKlientNavigation.IdOsobaNavigation != null
                        ? z.IdKlientNavigation.IdOsobaNavigation.Imie + " " + z.IdKlientNavigation.IdOsobaNavigation.Nazwisko
                        : "Brak danych"),

                DataZlozenia = z.DataPrzyjeciaZ,

                CenaZbiorcza = z.SzczegolyZamowienia.Any()
                               ? z.SzczegolyZamowienia.Sum(sz => sz.Cena * sz.Ilosc)
                               : 0m
            });

            // 4. Logika sortowania za pomocą ComboBoxa
            switch (comboBox_sortowanie.SelectedIndex)
            {
                case 0: // "Data - od najnowszych"
                    zapytanie = zapytanie.OrderByDescending(z => z.DataZlozenia);
                    break;
                case 1: // "Data - od najstarszych"
                    zapytanie = zapytanie.OrderBy(z => z.DataZlozenia);
                    break;
                case 2: // "Cena - malejąco"
                    zapytanie = zapytanie.OrderByDescending(z => z.CenaZbiorcza);
                    break;
                case 3: // "Cena - rosnąco"
                    zapytanie = zapytanie.OrderBy(z => z.CenaZbiorcza);
                    break;
                case 4: // "Klient (A-Z)"
                    zapytanie = zapytanie.OrderBy(z => z.Klient);
                    break;
            }

            // 5. Przypisanie gotowych (i posortowanych) danych do DataGridView
            dataGridView_HistoriaZamowien.DataSource = zapytanie.ToList();

            // 6. Formatowanie nagłówków kolumn
            if (dataGridView_HistoriaZamowien.Columns.Count > 0)
            {
                if (dataGridView_HistoriaZamowien.Columns["IdZamowienia"] != null)
                    dataGridView_HistoriaZamowien.Columns["IdZamowienia"].HeaderText = "ID Zamówienia";

                if (dataGridView_HistoriaZamowien.Columns["Klient"] != null)
                    dataGridView_HistoriaZamowien.Columns["Klient"].HeaderText = "Klient";

                if (dataGridView_HistoriaZamowien.Columns["DataZlozenia"] != null)
                    dataGridView_HistoriaZamowien.Columns["DataZlozenia"].HeaderText = "Data zamówienia";

                if (dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"] != null)
                {
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].HeaderText = "Wartość zamówienia";
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].DefaultCellStyle.Format = "C2"; // Format walutowy (np. zł)
                }
            }
        }

        // =======================================================
        // ZDARZENIA (EVENTY)
        // =======================================================
        private void dateTimePicker_Poczatek_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void dateTimePicker_Koniec_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        // Dodane zdarzenia odświeżające listę po przełączeniu opcji (podepnij je w Designerze!)
        private void radioButton_Wszyscy_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_Firmy_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void radioButton_Osoby_CheckedChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }

        private void dataGridView_HistoriaZamowien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView_HistoriaZamowien.SelectedRows[0];

                if (row.Cells["IdZamowienia"].Value != null)
                {
                    int idWybranegoZamowienia = Convert.ToInt32(row.Cells["IdZamowienia"].Value);

                    Form_HistoriaZamowienSzczegoly formSzczegoly = new Form_HistoriaZamowienSzczegoly(idWybranegoZamowienia);
                    formSzczegoly.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nie można odnaleźć ID tego zamówienia.");
                }
            }
        }

        private void comboBox_sortowanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            WyswietlHistorieZamowien();
        }

        private void label_data_Poczatku_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView_HistoriaZamowien.SelectedRows[0];

                if (row.Cells["IdZamowienia"].Value != null)
                {
                    int idWybranegoZamowienia = Convert.ToInt32(row.Cells["IdZamowienia"].Value);

                    Form_HistoriaZamowienSzczegoly formSzczegoly = new Form_HistoriaZamowienSzczegoly(idWybranegoZamowienia);
                    formSzczegoly.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nie można odnaleźć ID tego zamówienia.");
                }
            }
        }
    }
}
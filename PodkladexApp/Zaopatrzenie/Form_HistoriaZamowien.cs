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

        public partial class Form_HistoriaZamowienSzczegoly : Form
        {
            private int _idZamowienia;

            // TUTA JEST KLUCZ: Ta nazwa musi być w 100% identyczna z nazwą klasy wyżej!
            public Form_HistoriaZamowienSzczegoly(int idZamowienia)
            {
                _idZamowienia = idZamowienia;

                // Testowy tytuł okna
                this.Text = $"Szczegóły zamówienia nr {_idZamowienia}";
            }

            // ... reszta kodu (jeśli jakaś jest) ...
        }
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
            // 2. Wypełnienie opcji sortowania w ComboBox
            // Zabezpieczenie na wypadek, gdyby dodano je z poziomu Designera
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

            // 1. Pobranie danych z bazy (bez użycia .ToList(), aby posortować je w SQL, a nie w pamięci RAM)
            var zapytanie = _context.Zamowienie
                .Where(z => z.DataPrzyjeciaZ >= dataOd && z.DataPrzyjeciaZ <= dataDo)
                .Select(z => new
                {
                    IdZamowienia = z.IdZamowienie,

                    // Złączenie Imie i Nazwisko z tabeli Osoba
                    Klient = z.IdKlientNavigation.IdOsobaNavigation != null
                        ? z.IdKlientNavigation.IdOsobaNavigation.Imie + " " + z.IdKlientNavigation.IdOsobaNavigation.Nazwisko
                        : "Brak danych",

                    DataZlozenia = z.DataPrzyjeciaZ,

                    // Suma całkowita dla danego zamówienia: Ilość * Cena
                    CenaZbiorcza = z.SzczegolyZamowienia.Any()
                                   ? z.SzczegolyZamowienia.Sum(sz => sz.Cena * sz.Ilosc)
                                   : 0m
                });

            // 2. Logika sortowania za pomocą ComboBoxa
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

            // 3. Przypisanie gotowych (i posortowanych) danych do DataGridView
            dataGridView_HistoriaZamowien.DataSource = zapytanie.ToList();

            // 4. Formatowanie nagłówków kolumn
            if (dataGridView_HistoriaZamowien.Columns.Count > 0)
            {
                if (dataGridView_HistoriaZamowien.Columns["IdZamowienia"] != null)
                    dataGridView_HistoriaZamowien.Columns["IdZamowienia"].HeaderText = "ID Zamówienia";

                if (dataGridView_HistoriaZamowien.Columns["Klient"] != null)
                    dataGridView_HistoriaZamowien.Columns["Klient"].HeaderText = "Klient (Imię i Nazwisko)";

                if (dataGridView_HistoriaZamowien.Columns["DataZlozenia"] != null)
                    dataGridView_HistoriaZamowien.Columns["DataZlozenia"].HeaderText = "Data zamówienia";

                if (dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"] != null)
                {
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].HeaderText = "Wartość zamówienia";
                    dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].DefaultCellStyle.Format = "C2"; // Format walutowy (np. zł)
                }
            }
        }

        // Możesz dodać zdarzenia, aby odświeżać listę przy zmianie daty lub sortowania
        private void dateTimePicker_Poczatek_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();
        private void dateTimePicker_Koniec_ValueChanged(object sender, EventArgs e) => WyswietlHistorieZamowien();

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }

        private void dataGridView_HistoriaZamowien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // ... wcześniejszy kod ...

        // To zdarzenie odpala się za każdym razem, gdy użytkownik klika w inny wiersz tabeli
        private void dataGridView_HistoriaZamowien_SelectionChanged(object sender, EventArgs e)
        {
            // Sprawdzamy, czy w tabeli jest zaznaczony DOKŁADNIE jeden wiersz
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                button_Szczegoly.Enabled = true; // Odblokuj przycisk
            }
            else
            {
                button_Szczegoly.Enabled = false; // Zablokuj przycisk (np. jeśli użytkownik odznaczy lub zaznaczy wiele)
            }
        }

        // To się dzieje, gdy klikniemy odblokowany przycisk "Szczegóły"
        private void button_Szczegoly_Click(object sender, EventArgs e)
        {
            // Zabezpieczenie (choć przycisk jest zablokowany, gdy nie ma wyboru, lepiej uważać)
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                // Wyciągamy zaznaczony wiersz
                DataGridViewRow row = dataGridView_HistoriaZamowien.SelectedRows[0];

                // UWAGA: Żeby to zadziałało, musimy się upewnić, że kolumna "IdZamowienia" 
                // istnieje w DataGridView. Wcześniej ją ukrywaliśmy (Visible = false), ale dane TAM SĄ!
                if (row.Cells["IdZamowienia"].Value != null)
                {
                    // Pobieramy to ukryte ID z komórki
                    int idWybranegoZamowienia = Convert.ToInt32(row.Cells["IdZamowienia"].Value);

                    // Tworzymy i otwieramy nowy formularz, przekazując mu ID!
                    Form_HistoriaZamowienSzczegoly formSzczegoly = new Form_HistoriaZamowienSzczegoly(idWybranegoZamowienia);
                    formSzczegoly.ShowDialog(); // ShowDialog blokuje stary formularz, dopóki ten nie zostanie zamknięty (polecane)
                }
                else
                {
                    MessageBox.Show("Nie można odnaleźć ID tego zamówienia.");
                }
            }
        }

        // ... reszta kodu ...

        private void comboBox_sortowanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Za każdym razem, gdy zmienisz wartość w ComboBoxie, 
            // lista pobierze się i posortuje na nowo automatycznie!
            WyswietlHistorieZamowien();
        }

        private void label_data_Poczatku_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Zabezpieczenie (choć przycisk jest zablokowany, gdy nie ma wyboru, lepiej uważać)
            if (dataGridView_HistoriaZamowien.SelectedRows.Count == 1)
            {
                // Wyciągamy zaznaczony wiersz
                DataGridViewRow row = dataGridView_HistoriaZamowien.SelectedRows[0];

                // UWAGA: Żeby to zadziałało, musimy się upewnić, że kolumna "IdZamowienia" 
                // istnieje w DataGridView. Wcześniej ją ukrywaliśmy (Visible = false), ale dane TAM SĄ!
                if (row.Cells["IdZamowienia"].Value != null)
                {
                    // Pobieramy to ukryte ID z komórki
                    int idWybranegoZamowienia = Convert.ToInt32(row.Cells["IdZamowienia"].Value);

                    // Tworzymy i otwieramy nowy formularz, przekazując mu ID!
                    Form_HistoriaZamowienSzczegoly formSzczegoly = new Form_HistoriaZamowienSzczegoly(idWybranegoZamowienia);
                    formSzczegoly.ShowDialog(); // ShowDialog blokuje stary formularz, dopóki ten nie zostanie zamknięty (polecane)
                }
                else
                {
                    MessageBox.Show("Nie można odnaleźć ID tego zamówienia.");
                }
            }
        }
    }
}
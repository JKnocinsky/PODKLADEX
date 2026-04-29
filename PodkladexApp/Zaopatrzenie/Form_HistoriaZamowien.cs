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
        // Instancja kontekstu bazy danych
        private PodkladexContext _context = new PodkladexContext();

        public Form_HistoriaZamowien()
        {
            InitializeComponent();
        }

        private void Form_HistoriaZamowien_Load(object sender, EventArgs e)
        {
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
            // Konwersja dat z DateTimePicker na DateOnly (wymagane przez model Zamowienie)
            var dataOd = DateOnly.FromDateTime(dateTimePicker_Poczatek.Value);
            var dataDo = DateOnly.FromDateTime(dateTimePicker_Koniec.Value);

            // Pobranie danych z bazy z wykorzystaniem właściwości nawigacyjnych
            var historia = _context.Zamowienie
                .Where(z => z.DataPrzyjeciaZ >= dataOd && z.DataPrzyjeciaZ <= dataDo)
                .Select(z => new
                {
                    // Kolumna 1: Imię i nazwisko klienta z tabeli Osoba
                    Klient = z.IdKlientNavigation.IdOsobaNavigation != null
                        ? z.IdKlientNavigation.IdOsobaNavigation.Imie + " " + z.IdKlientNavigation.IdOsobaNavigation.Nazwisko
                        : "Brak danych",

                    // Kolumna 2: Data złożenia zamówienia
                    DataZlozenia = z.DataPrzyjeciaZ,

                    // Kolumna 3: Cena zbiorcza (Suma Cena * Ilosc z detali)
                    CenaZbiorcza = z.SzczegolyZamowienia.Sum(sz => sz.Cena * sz.Ilosc)
                })
                .ToList();

            // Przypisanie danych do właściwej kontrolki DataGridView
            dataGridView_HistoriaZamowien.DataSource = historia;

            // Formatowanie nagłówków kolumn
            if (dataGridView_HistoriaZamowien.Columns.Count > 0)
            {
                dataGridView_HistoriaZamowien.Columns["Klient"].HeaderText = "Klient (Imię i Nazwisko)";
                dataGridView_HistoriaZamowien.Columns["DataZlozenia"].HeaderText = "Data zamówienia";
                dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].HeaderText = "Wartość zamówienia";
                dataGridView_HistoriaZamowien.Columns["CenaZbiorcza"].DefaultCellStyle.Format = "C2"; // Format walutowy
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

        private void comboBox_sortowanie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
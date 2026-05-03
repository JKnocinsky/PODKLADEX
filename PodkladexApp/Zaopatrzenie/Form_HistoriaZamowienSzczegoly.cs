using PodkladexApp.Models; // Podmień na swój prawdziwy namespace z modelami
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
// Dodaj using dla Entity Framework, aby działało Include()
using Microsoft.EntityFrameworkCore; // Użyj System.Data.Entity jeśli masz starszy EF6

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_HistoriaZamowienSzczegoly : Form
    {
        private int _idZamowienia;
        private PodkladexContext _db = new PodkladexContext();

        public Form_HistoriaZamowienSzczegoly(int idZamowienia)
        {
            InitializeComponent(); 
            _idZamowienia = idZamowienia;

            this.Text = $"Szczegóły zamówienia nr {_idZamowienia}";

            SkonfigurujDataGridView();
            ZaladujDaneZamowienia();
        }

        private void SkonfigurujDataGridView()
        {
            // Ustawienia dla dataGridView_Koszyk (tylko podgląd, bez edycji)
            dataGridView_Koszyk.AllowUserToAddRows = false;
            dataGridView_Koszyk.AllowUserToDeleteRows = false;
            dataGridView_Koszyk.ReadOnly = true;
            dataGridView_Koszyk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Koszyk.RowHeadersVisible = false; // Ukrywa boczny pasek ze strzałką
            dataGridView_Koszyk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Rozciąga kolumny
        }

        private void ZaladujDaneZamowienia()
        {
            try
            {
                // --- 1. POBRANIE DANYCH GŁÓWNYCH ZAMÓWIENIA, KLIENTA I OSOBY ---
                // Używamy nazw nawigacyjnych, które EF standardowo generuje dla kluczy obcych
                var zamowienie = _db.Zamowienie
                                    .Include(z => z.IdKlientNavigation)
                                    .ThenInclude(k => k.IdOsobaNavigation)
                                    .FirstOrDefault(z => z.IdZamowienie == _idZamowienia);

                if (zamowienie != null)
                {
                    // Wyciągamy Imię i Nazwisko z tabeli Osoba powiązanej z Klientem
                    if (zamowienie.IdKlientNavigation != null && zamowienie.IdKlientNavigation.IdOsobaNavigation != null)
                    {
                        var osoba = zamowienie.IdKlientNavigation.IdOsobaNavigation;
                        textBox_Klient.Text = $"{osoba.Imie} {osoba.Nazwisko}";
                    }
                    else
                    {
                        textBox_Klient.Text = "Brak przypisanego klienta/osoby";
                    }

                    // Uzupełnianie dat
                    textBox_DataZlozenia.Text = zamowienie.DataPrzyjeciaZ.ToString("dd.MM.yyyy");

                    textBox_DataZrealizowania.Text = zamowienie.DataZrealizowaniaZ.HasValue
                        ? zamowienie.DataZrealizowaniaZ.Value.ToString("dd.MM.yyyy")
                        : "W trakcie realizacji";

                    // --- 2. POBRANIE KOSZYKA (SZCZEGÓŁÓW ZAMÓWIENIA) ---
                    var szczegoly = _db.SzczegolyZamowienia
                                       .Include(sz => sz.IdProduktNavigation)
                                       .Include(sz => sz.IdMaterialNavigation)
                                       .Where(sz => sz.IdZamowienie == _idZamowienia)
                                       .ToList();

                    // Formatowanie danych do DataGridView
                    var listaZakupow = szczegoly.Select(sz => new
                    {
                        // Sprawdzamy czy relacje nie są nullem i pobieramy nazwy
                        Produkt = sz.IdProduktNavigation != null ? sz.IdProduktNavigation.Nazwa : "Brak",
                        Materiał = sz.IdMaterialNavigation != null ? sz.IdMaterialNavigation.Nazwa : "Brak",
                        Ilość = sz.Ilosc,
                        Cena = sz.Cena,
                        Uwagi = sz.Uwagi
                    }).ToList();

                    dataGridView_Koszyk.DataSource = listaZakupow;
                }
                else
                {
                    MessageBox.Show("Nie odnaleziono zamówienia w bazie.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania szczegółów: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dbamy o to, by kontekst bazy się poprawnie zamykał
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }

        private void textBox_Klient_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
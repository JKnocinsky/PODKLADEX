using PodkladexApp.Models; // Podmień na swój prawdziwy namespace z modelami
using System;
using System.Data;
using System.Drawing; // POTRZEBNE DO USTAWIANIA CZCIONEK (Font)
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            // Odpalamy ustawienia wyglądu i ładujemy dane
            SkonfigurujWyglad();
            ZaladujDaneZamowienia();
        }

        private void SkonfigurujWyglad()
        {
            // --- 1. WYGLĄD DATAGRIDVIEW ---
            dataGridView_Koszyk.AllowUserToAddRows = false;
            dataGridView_Koszyk.AllowUserToDeleteRows = false;
            dataGridView_Koszyk.ReadOnly = true;
            dataGridView_Koszyk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Koszyk.RowHeadersVisible = false;
            dataGridView_Koszyk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Zmiana czcionki dla komórek z danymi (Segoe UI, 14)
            dataGridView_Koszyk.DefaultCellStyle.Font = new Font("Segoe UI", 14);

            // Zmiana czcionki dla nagłówków kolumn (Segoe UI, 14, Pogrubiona)
            dataGridView_Koszyk.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // Zwiększenie wysokości wierszy, żeby nowa czcionka ładnie wyglądała
            dataGridView_Koszyk.RowTemplate.Height = 40;
            dataGridView_Koszyk.ColumnHeadersHeight = 50;

            // --- 2. ZABLOKOWANIE EDYCJI TEXTBOXÓW (tylko do odczytu) ---
            textBox_Klient.ReadOnly = true;
            textBox_DataZlozenia.ReadOnly = true;
            textBox_DataZrealizowania.ReadOnly = true;

            textBox_NazwaFirmy.ReadOnly = true;
            textBox_NIP.ReadOnly = true;

            // Zablokowanie pól adresowych
            textBox_Miejscowosc.ReadOnly = true; // Miejscowość
            textBox_Ulica.ReadOnly = true;
            textBox_Numer.ReadOnly = true;
            textBox_KodPocztowy.ReadOnly = true;
        }

        private void ZaladujDaneZamowienia()
        {
            try
            {
                // Pobieramy dane łącząc z Klientem, Osobą, oraz powiązaniami Klient_Firma i Firma
                var zamowienie = _db.Zamowienie
                                    .Include(z => z.IdKlientNavigation)
                                        .ThenInclude(k => k.IdOsobaNavigation)
                                    .Include(z => z.IdKlientNavigation)
                                        .ThenInclude(k => k.KlientFirma)
                                            .ThenInclude(kf => kf.IdFirmaNavigation)
                                    .FirstOrDefault(z => z.IdZamowienie == _idZamowienia);

                if (zamowienie != null)
                {
                    // --- UZUPEŁNIANIE DANYCH KLIENTA (OSOBY) I ADRESU ---
                    if (zamowienie.IdKlientNavigation != null && zamowienie.IdKlientNavigation.IdOsobaNavigation != null)
                    {
                        var osoba = zamowienie.IdKlientNavigation.IdOsobaNavigation;
                        textBox_Klient.Text = $"{osoba.Imie} {osoba.Nazwisko}";

                        // Ładowanie danych adresowych Z TABELI OSOBA
                        textBox_Miejscowosc.Text = osoba.Miejscowosc;
                        textBox_Ulica.Text = osoba.Ulica;
                        textBox_Numer.Text = osoba.Numer;
                        // Jeśli w Entity Framework właściwość nazywa się inaczej (np. Kod_pocztowy), podmień to poniżej:
                        textBox_KodPocztowy.Text = osoba.KodPocztowy;
                    }
                    else
                    {
                        textBox_Klient.Text = "Brak przypisanego klienta/osoby";

                        // Czyszczenie pól adresowych w przypadku braku osoby
                        textBox_Miejscowosc.Clear();
                        textBox_Ulica.Clear();
                        textBox_Numer.Clear();
                        textBox_KodPocztowy.Clear();
                    }

                    // --- DATY ---
                    textBox_DataZlozenia.Text = zamowienie.DataPrzyjeciaZ.ToString("dd.MM.yyyy");

                    textBox_DataZrealizowania.Text = zamowienie.DataZrealizowaniaZ.HasValue
                        ? zamowienie.DataZrealizowaniaZ.Value.ToString("dd.MM.yyyy")
                        : "W trakcie realizacji";

                    // --- LOGIKA WYŚWIETLANIA FIRMY ---
                    // Szukamy aktualnego powiązania (takiego, gdzie DataKoniec jest NULL)
                    var aktywnePowiazanie = zamowienie.IdKlientNavigation?.KlientFirma?
                                                      .FirstOrDefault(kf => kf.DataKoniec == null);

                    if (aktywnePowiazanie != null && aktywnePowiazanie.IdFirmaNavigation != null)
                    {
                        // Klient ma firmę - pokazujemy panel i ładujemy TYLKO nazwę i NIP
                        panel_Firmy.Visible = true;
                        textBox_NazwaFirmy.Text = aktywnePowiazanie.IdFirmaNavigation.Nazwa;
                        textBox_NIP.Text = aktywnePowiazanie.IdFirmaNavigation.Nip;
                    }
                    else
                    {
                        // Klient nie ma przypisanej aktywnej firmy - ukrywamy cały panel
                        panel_Firmy.Visible = false;

                        // Zabezpieczające czyszczenie pól firmowych
                        textBox_NazwaFirmy.Clear();
                        textBox_NIP.Clear();
                    }

                    // --- UZUPEŁNIANIE KOSZYKA (DataGridView) ---
                    var szczegoly = _db.SzczegolyZamowienia
                                       .Include(sz => sz.IdProduktNavigation)
                                       .Include(sz => sz.IdMaterialNavigation)
                                       .Where(sz => sz.IdZamowienie == _idZamowienia)
                                       .ToList();

                    var listaZakupow = szczegoly.Select(sz => new
                    {
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }

        private void label_Firma_Click(object sender, EventArgs e) { }
        private void textBox_Ulica_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox_KodPocztowy_TextChanged(object sender, EventArgs e) { }
        private void textBox_Numer_TextChanged(object sender, EventArgs e) { }
    }
}
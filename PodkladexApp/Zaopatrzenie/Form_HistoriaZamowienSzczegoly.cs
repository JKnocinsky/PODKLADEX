using PodkladexApp.Models; // Podmień na swój prawdziwy namespace z modelami
using System;
using System.Data;
using System.Drawing; // POTRZEBNE DO USTAWIANIA CZCIONEK (Font)
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

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

            // Jeśli nazwałeś TextBoxy na firmę inaczej, popraw te nazwy poniżej:
            textBox_NazwaFirmy.ReadOnly = true;
            textBox_NIP.ReadOnly = true;
        }

        private void ZaladujDaneZamowienia()
        {
            try
            {
                // Pobieramy dane łącząc z Klientem, Osobą, oraz powiązaniami Klient_Firma i Firma[cite: 9]
                // UWAGA NA NAZWY! Jeśli EF nazwał kolekcję w liczbie mnogiej (np. KlientFirmas), podmień "KlientFirma" na "KlientFirmas".
                var zamowienie = _db.Zamowienie
                                    .Include(z => z.IdKlientNavigation)
                                        .ThenInclude(k => k.IdOsobaNavigation)
                                    .Include(z => z.IdKlientNavigation)
                                        .ThenInclude(k => k.KlientFirma)
                                            .ThenInclude(kf => kf.IdFirmaNavigation)
                                    .FirstOrDefault(z => z.IdZamowienie == _idZamowienia);

                if (zamowienie != null)
                {
                    // --- UZUPEŁNIANIE DANYCH KLIENTA I DAT ---
                    if (zamowienie.IdKlientNavigation != null && zamowienie.IdKlientNavigation.IdOsobaNavigation != null)
                    {
                        var osoba = zamowienie.IdKlientNavigation.IdOsobaNavigation;
                        textBox_Klient.Text = $"{osoba.Imie} {osoba.Nazwisko}";
                    }
                    else
                    {
                        textBox_Klient.Text = "Brak przypisanego klienta/osoby";
                    }

                    textBox_DataZlozenia.Text = zamowienie.DataPrzyjeciaZ.ToString("dd.MM.yyyy");

                    textBox_DataZrealizowania.Text = zamowienie.DataZrealizowaniaZ.HasValue
                        ? zamowienie.DataZrealizowaniaZ.Value.ToString("dd.MM.yyyy")
                        : "W trakcie realizacji";

                    // --- LOGIKA WYŚWIETLANIA FIRMY ---
                    // Szukamy aktualnego powiązania (takiego, gdzie DataKoniec jest NULL)[cite: 9]
                    var aktywnePowiazanie = zamowienie.IdKlientNavigation?.KlientFirma?
                                                      .FirstOrDefault(kf => kf.DataKoniec == null);

                    if (aktywnePowiazanie != null && aktywnePowiazanie.IdFirmaNavigation != null)
                    {
                        // Klient ma firmę - pokazujemy panel i ładujemy dane
                        panel_Firmy.Visible = true;
                        textBox_NazwaFirmy.Text = aktywnePowiazanie.IdFirmaNavigation.Nazwa;
                        textBox_NIP.Text = aktywnePowiazanie.IdFirmaNavigation.Nip;
                    }
                    else
                    {
                        // Klient nie ma przypisanej aktywnej firmy - ukrywamy cały panel
                        panel_Firmy.Visible = false;

                        // Zabezpieczające czyszczenie pól
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
    }
}
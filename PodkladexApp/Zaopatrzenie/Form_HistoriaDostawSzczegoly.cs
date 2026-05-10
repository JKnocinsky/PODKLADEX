using PodkladexApp.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_HistoriaDostawSzczegoly : Form
    {
        private int _idDostawy;
        private PodkladexContext _db = new PodkladexContext();

        public Form_HistoriaDostawSzczegoly(int idDostawy)
        {
            InitializeComponent();
            _idDostawy = idDostawy;

            // Ustawienie tytułu okna
            this.Text = $"Szczegóły dostawy nr {_idDostawy}";

            // Konfiguracja i ładowanie danych przy starcie
            SkonfigurujWyglad();
            ZaladujDaneDostawy();
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

            // Zwiększenie wysokości wierszy
            dataGridView_Koszyk.RowTemplate.Height = 40;
            dataGridView_Koszyk.ColumnHeadersHeight = 50;

            // --- 2. ZABLOKOWANIE EDYCJI TEXTBOXÓW (tylko do odczytu) ---
            textBox_Osoba.ReadOnly = true;
            textBox_NumerTelefonu.ReadOnly = true;
            textBox_DataDostawy.ReadOnly = true;
            textBox_NazwaFirmy.ReadOnly = true;
            textBox_NIP.ReadOnly = true;
        }

        private void ZaladujDaneDostawy()
        {
            try
            {
                // 1. Pobieramy dostawę łącząc ją z Firmą oraz Pracownikiem (i jego Osobą)
                var dostawa = _db.Dostawa
                    .Include(d => d.IdFirmaNavigation)
                    .Include(d => d.IdPracownikNavigation)
                        .ThenInclude(p => p.IdOsobaNavigation)
                    .FirstOrDefault(d => d.IdDostawa == _idDostawy);

                if (dostawa != null)
                {
                    // --- DANE PRACOWNIKA (OSOBY PRZYJMUJĄCEJ DOSTAWĘ) ---
                    if (dostawa.IdPracownikNavigation != null && dostawa.IdPracownikNavigation.IdOsobaNavigation != null)
                    {
                        var osoba = dostawa.IdPracownikNavigation.IdOsobaNavigation;
                        textBox_Osoba.Text = $"{osoba.Imie} {osoba.Nazwisko}";

                        // Formatowanie numeru telefonu (XXX-XXX-XXX)
                        string tel = osoba.NrTelefonu;
                        if (!string.IsNullOrEmpty(tel))
                        {
                            string rawTel = new string(tel.Where(char.IsDigit).ToArray());
                            if (rawTel.Length == 9)
                            {
                                tel = rawTel.Insert(3, "-").Insert(7, "-");
                            }
                        }
                        textBox_NumerTelefonu.Text = string.IsNullOrEmpty(tel) ? "Brak telefonu" : tel;
                    }
                    else
                    {
                        textBox_Osoba.Text = "Brak przypisanego pracownika";
                        textBox_NumerTelefonu.Text = "-";
                    }

                    // --- DATA DOSTAWY ---
                    textBox_DataDostawy.Text = dostawa.DataDostawy.ToString("dd.MM.yyyy");

                    // --- DANE FIRMY DOSTAWCZEJ ---
                    if (dostawa.IdFirmaNavigation != null)
                    {
                        textBox_NazwaFirmy.Text = dostawa.IdFirmaNavigation.Nazwa;

                        // Formatowanie NIP (XXX-XXX-XX-XX)
                        string nip = dostawa.IdFirmaNavigation.Nip;
                        if (!string.IsNullOrEmpty(nip))
                        {
                            string rawNip = new string(nip.Where(char.IsDigit).ToArray());
                            if (rawNip.Length == 10)
                            {
                                nip = rawNip.Insert(3, "-").Insert(7, "-").Insert(10, "-");
                            }
                        }
                        textBox_NIP.Text = nip;
                    }
                    else
                    {
                        textBox_NazwaFirmy.Text = "Brak przypisanej firmy";
                        textBox_NIP.Text = "-";
                    }

                    // --- UZUPEŁNIANIE KOSZYKA Z MATERIAŁAMI ---
                    var listaDostarczonychMaterialow = _db.SzczegolyDostawy
                        .Include(sd => sd.IdMaterialNavigation)
                        .Where(sd => sd.IdDostawa == _idDostawy)
                        .Select(sd => new
                        {
                            Materiał = sd.IdMaterialNavigation != null ? sd.IdMaterialNavigation.Nazwa : "Brak nazwy",
                            Ilość = sd.Liczba,
                            Cena = sd.Cena,
                            Wartość = sd.Liczba * sd.Cena // Dodatkowa, wyliczana w locie kolumna dla wygody
                        })
                        .ToList();

                    dataGridView_Koszyk.DataSource = listaDostarczonychMaterialow;

                    // --- FORMATOWANIE KOSZYKA I ZMIANA NAGŁÓWKÓW ---
                    if (dataGridView_Koszyk.Columns["Ilość"] != null)
                    {
                        dataGridView_Koszyk.Columns["Ilość"].HeaderText = "Liczba [kg]";
                    }

                    if (dataGridView_Koszyk.Columns["Cena"] != null)
                    {
                        dataGridView_Koszyk.Columns["Cena"].HeaderText = "Cena za kilogram [zł]";
                        dataGridView_Koszyk.Columns["Cena"].DefaultCellStyle.Format = "N2"; // Liczba z 2 miejscami po przecinku
                    }

                    if (dataGridView_Koszyk.Columns["Wartość"] != null)
                    {
                        dataGridView_Koszyk.Columns["Wartość"].HeaderText = "Wartość [zł]";
                        dataGridView_Koszyk.Columns["Wartość"].DefaultCellStyle.Format = "N2"; // Liczba z 2 miejscami po przecinku
                    }
                }
                else
                {
                    MessageBox.Show("Nie odnaleziono dostawy w bazie.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania szczegółów dostawy: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Zwalniamy zasoby bazy danych przy zamknięciu okienka
            _db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
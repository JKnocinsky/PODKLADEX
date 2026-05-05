using PodkladexApp.Models;
using System;
using System.Data;
using System.Drawing;
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

            SkonfigurujWyglad();
            ZaladujDaneZamowienia();
        }

        private void SkonfigurujWyglad()
        {
            dataGridView_Koszyk.AllowUserToAddRows = false;
            dataGridView_Koszyk.ReadOnly = true;
            dataGridView_Koszyk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Koszyk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Koszyk.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView_Koszyk.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dataGridView_Koszyk.RowTemplate.Height = 40;

            textBox_Klient.ReadOnly = true;
            textBox_DataZlozenia.ReadOnly = true;
            textBox_DataZrealizowania.ReadOnly = true;
            textBox_NazwaFirmy.ReadOnly = true;
            textBox_NIP.ReadOnly = true;
            textBox_Miejscowosc.ReadOnly = true;
            textBox_Ulica.ReadOnly = true;
            textBox_Numer.ReadOnly = true;
            textBox_KodPocztowy.ReadOnly = true;
        }

        private void ZaladujDaneZamowienia()
        {
            try
            {
                // 1. Pobieramy zamówienie wraz z pełną historią powiązań klienta z firmami
                var zamowienie = _db.Zamowienie
                    .Include(z => z.IdKlientNavigation)
                        .ThenInclude(k => k.IdOsobaNavigation)
                    .Include(z => z.IdKlientNavigation)
                        .ThenInclude(k => k.KlientFirma)
                            .ThenInclude(kf => kf.IdFirmaNavigation)
                    .FirstOrDefault(z => z.IdZamowienie == _idZamowienia);

                if (zamowienie != null)
                {
                    // Dane podstawowe osoby
                    if (zamowienie.IdKlientNavigation?.IdOsobaNavigation != null)
                    {
                        var osoba = zamowienie.IdKlientNavigation.IdOsobaNavigation;
                        textBox_Klient.Text = $"{osoba.Imie} {osoba.Nazwisko}";
                        textBox_Miejscowosc.Text = osoba.Miejscowosc;
                        textBox_Ulica.Text = osoba.Ulica;
                        textBox_Numer.Text = osoba.Numer;
                        textBox_KodPocztowy.Text = osoba.KodPocztowy;
                    }

                    // Daty zamówienia
                    textBox_DataZlozenia.Text = zamowienie.DataPrzyjeciaZ.ToString("dd.MM.yyyy");
                    textBox_DataZrealizowania.Text = zamowienie.DataZrealizowaniaZ.HasValue
                        ? zamowienie.DataZrealizowaniaZ.Value.ToString("dd.MM.yyyy")
                        : "W trakcie realizacji";

                    // --- KLUCZOWA LOGIKA C# ---
                    // Szukamy firmy, w której klient pracował DOKŁADNIE W DNIU złożenia tego zamówienia
                    var dataZamowienia = zamowienie.DataPrzyjeciaZ;

                    var powiazanieHistoryczne = zamowienie.IdKlientNavigation?.KlientFirma?
                        .FirstOrDefault(kf => kf.DataPocz <= dataZamowienia &&
                                             (kf.DataKoniec == null || kf.DataKoniec >= dataZamowienia));

                    if (powiazanieHistoryczne != null && powiazanieHistoryczne.IdFirmaNavigation != null)
                    {
                        panel_Firmy.Visible = true;
                        textBox_NazwaFirmy.Text = powiazanieHistoryczne.IdFirmaNavigation.Nazwa;
                        textBox_NIP.Text = powiazanieHistoryczne.IdFirmaNavigation.Nip;
                    }
                    else
                    {
                        panel_Firmy.Visible = false;
                        textBox_NazwaFirmy.Clear();
                        textBox_NIP.Clear();
                    }

                    // Szczegóły koszyka
                    var listaZakupow = _db.SzczegolyZamowienia
                        .Include(sz => sz.IdProduktNavigation)
                        .Include(sz => sz.IdMaterialNavigation)
                        .Where(sz => sz.IdZamowienie == _idZamowienia)
                        .ToList()
                        .Select(sz => new
                        {
                            Produkt = sz.IdProduktNavigation?.Nazwa ?? "Brak",
                            Materiał = sz.IdMaterialNavigation?.Nazwa ?? "Brak",
                            Ilość = sz.Ilosc,
                            Cena = sz.Cena,
                            Uwagi = sz.Uwagi
                        }).ToList();

                    dataGridView_Koszyk.DataSource = listaZakupow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
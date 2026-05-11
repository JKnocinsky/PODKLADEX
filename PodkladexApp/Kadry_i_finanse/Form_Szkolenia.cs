using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_Szkolenia : Form
    {
        private readonly PodkladexContext db;

        private bool ladowanieFiltrow = false;
        private bool ladowanieComboPracownikow = false;
        private bool ustawianieAutomatyczneDaty = false;
        private bool recznaZmianaDatyWaznosci = false;

        private int? edytowanyIdPracownik = null;
        private int? edytowanyIdSzkolenia = null;
        private DateOnly? edytowanaDataSzkolenia = null;

        private List<PracownikComboBoxItem> listaPracownikow = new List<PracownikComboBoxItem>();

        private class PracownikComboBoxItem
        {
            public int IdPracownik { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string DanePracownika { get; set; }
        }

        public Form_Szkolenia()
        {
            InitializeComponent();
            db = new PodkladexContext();

            panel1.Visible = false;

            UkryjPrzyciskZatwierdzZmiany();
        }

        private void Form_Szkolenia_Load(object sender, EventArgs e)
        {
            KonfigurujDataGridView();

            ZaladujPracownikow();
            ZaladujPracownikowDoComboBox();
            ZaladujPracownikowDoFiltra();
            ZaladujSzkoleniaDoComboBox();

            UstawDomyslneDane();
            UstawTrybDodawania();

            ZaladujSzkoleniaPracownikow();
        }

        private void KonfigurujDataGridView()
        {
            dataGridView_szkolenia.AutoGenerateColumns = false;
            dataGridView_szkolenia.AllowUserToAddRows = false;
            dataGridView_szkolenia.AllowUserToDeleteRows = false;
            dataGridView_szkolenia.ReadOnly = true;
            dataGridView_szkolenia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_szkolenia.MultiSelect = false;
            dataGridView_szkolenia.RowHeadersVisible = false;
            dataGridView_szkolenia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_szkolenia.Columns.Clear();

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdPracownik",
                HeaderText = "IdPracownik",
                DataPropertyName = "IdPracownik",
                Visible = false
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdSzkolenia",
                HeaderText = "IdSzkolenia",
                DataPropertyName = "IdSzkolenia",
                Visible = false
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataSzkoleniaKey",
                HeaderText = "DataSzkoleniaKey",
                DataPropertyName = "DataSzkoleniaKey",
                Visible = false
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Pracownik",
                HeaderText = "Pracownik",
                DataPropertyName = "Pracownik",
                FillWeight = 170
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Szkolenie",
                HeaderText = "Szkolenie",
                DataPropertyName = "Szkolenie",
                FillWeight = 140
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "CzyObowiazkowe",
                HeaderText = "Obowiązkowe",
                DataPropertyName = "CzyObowiazkowe",
                FillWeight = 70
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "WaznoscDni",
                HeaderText = "Ważność [dni]",
                DataPropertyName = "WaznoscDni",
                FillWeight = 80
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataSzkolenia",
                HeaderText = "Data szkolenia",
                DataPropertyName = "DataSzkolenia",
                FillWeight = 90
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataWaznosci",
                HeaderText = "Ważne do",
                DataPropertyName = "DataWaznosci",
                FillWeight = 90
            });

            dataGridView_szkolenia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CenaSzkolenia",
                HeaderText = "Cena",
                DataPropertyName = "CenaSzkolenia",
                FillWeight = 70
            });

            dataGridView_szkolenia.CellDoubleClick -= dataGridView_szkolenia_CellDoubleClick;
            dataGridView_szkolenia.CellDoubleClick += dataGridView_szkolenia_CellDoubleClick;
        }

        private void ZaladujSzkoleniaPracownikow()
        {
            try
            {
                var zapytanie = db.PracownikSzkolenia
                    .Include(ps => ps.IdPracownikNavigation)
                    .ThenInclude(p => p.IdOsobaNavigation)
                    .Include(ps => ps.IdSzkoleniaNavigation)
                    .AsQueryable();

                if (comboBox_filtrPracownik.SelectedValue != null)
                {
                    int idPracownik = Convert.ToInt32(comboBox_filtrPracownik.SelectedValue);

                    if (idPracownik > 0)
                    {
                        zapytanie = zapytanie.Where(ps => ps.IdPracownik == idPracownik);
                    }
                }

                if (checkBox_tylkoNiewazne.Checked)
                {
                    DateOnly dzis = DateOnly.FromDateTime(DateTime.Today);

                    zapytanie = zapytanie.Where(ps =>
                        ps.DataWaznosci != null &&
                        ps.DataWaznosci < dzis);
                }

                var daneZBazy = zapytanie
                    .OrderBy(ps => ps.IdPracownikNavigation.IdOsobaNavigation.Nazwisko)
                    .ThenBy(ps => ps.IdPracownikNavigation.IdOsobaNavigation.Imie)
                    .ThenByDescending(ps => ps.DataSzkolenia)
                    .ToList();

                var lista = daneZBazy
                    .Select(ps => new
                    {
                        IdPracownik = ps.IdPracownik,
                        IdSzkolenia = ps.IdSzkolenia,
                        DataSzkoleniaKey = ps.DataSzkolenia.ToString("yyyy-MM-dd"),

                        Pracownik = ps.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                                    ps.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,

                        Szkolenie = ps.IdSzkoleniaNavigation.Nazwa,

                        CzyObowiazkowe = ps.IdSzkoleniaNavigation.CzyObowiazkowe ?? false,

                        WaznoscDni = ps.IdSzkoleniaNavigation.Waznosc.HasValue
                            ? ps.IdSzkoleniaNavigation.Waznosc.Value.ToString()
                            : "Bezterminowe",

                        DataSzkolenia = ps.DataSzkolenia.ToString("dd.MM.yyyy"),

                        DataWaznosci = ps.DataWaznosci.HasValue
                            ? ps.DataWaznosci.Value.ToString("dd.MM.yyyy")
                            : "Bezterminowe",

                        CenaSzkolenia = ps.CenaSzkolenia.ToString("0.00", CultureInfo.GetCultureInfo("pl-PL"))
                    })
                    .ToList();

                dataGridView_szkolenia.DataSource = null;
                dataGridView_szkolenia.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania szkoleń:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ZaladujPracownikow()
        {
            try
            {
                listaPracownikow = db.Pracownik
                    .Include(p => p.IdOsobaNavigation)
                    .Select(p => new PracownikComboBoxItem
                    {
                        IdPracownik = p.IdPracownik,
                        Imie = p.IdOsobaNavigation.Imie,
                        Nazwisko = p.IdOsobaNavigation.Nazwisko,
                        DanePracownika = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania pracowników:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private List<PracownikComboBoxItem> PrzygotujListeBezPustejKolekcji(List<PracownikComboBoxItem> lista)
        {
            if (lista.Count > 0)
                return lista;

            return new List<PracownikComboBoxItem>
            {
                new PracownikComboBoxItem
                {
                    IdPracownik = -1,
                    Imie = "",
                    Nazwisko = "",
                    DanePracownika = "Brak wyników"
                }
            };
        }

        private void UstawDaneComboBoxPracownikowDoDodawania(List<PracownikComboBoxItem> pracownicy, string tekst = "")
        {
            ladowanieComboPracownikow = true;

            var listaDoUstawienia = PrzygotujListeBezPustejKolekcji(pracownicy);

            comboBox_pracownik.DataSource = null;
            comboBox_pracownik.DisplayMember = "DanePracownika";
            comboBox_pracownik.ValueMember = "IdPracownik";
            comboBox_pracownik.DataSource = listaDoUstawienia;

            comboBox_pracownik.SelectedIndex = -1;
            comboBox_pracownik.Text = tekst;
            comboBox_pracownik.SelectionStart = comboBox_pracownik.Text.Length;
            comboBox_pracownik.SelectionLength = 0;

            ladowanieComboPracownikow = false;
        }

        private void UstawDaneComboBoxPracownikowDoFiltra(
            List<PracownikComboBoxItem> pracownicy,
            bool dodajWszystkich = true,
            bool ustawWszystkichJakoWybrane = false,
            string tekst = "")
        {
            ladowanieFiltrow = true;

            var listaDoFiltra = new List<object>();

            if (dodajWszystkich)
            {
                listaDoFiltra.Add(new
                {
                    IdPracownik = 0,
                    DanePracownika = "Wszyscy pracownicy"
                });
            }

            if (pracownicy.Count == 0)
            {
                listaDoFiltra.Add(new
                {
                    IdPracownik = -1,
                    DanePracownika = "Brak wyników"
                });
            }
            else
            {
                foreach (var pracownik in pracownicy)
                {
                    listaDoFiltra.Add(new
                    {
                        IdPracownik = pracownik.IdPracownik,
                        DanePracownika = pracownik.DanePracownika
                    });
                }
            }

            comboBox_filtrPracownik.DataSource = null;
            comboBox_filtrPracownik.DisplayMember = "DanePracownika";
            comboBox_filtrPracownik.ValueMember = "IdPracownik";
            comboBox_filtrPracownik.DataSource = listaDoFiltra;

            if (ustawWszystkichJakoWybrane && comboBox_filtrPracownik.Items.Count > 0)
            {
                comboBox_filtrPracownik.SelectedIndex = 0;
                comboBox_filtrPracownik.Text = "Wszyscy pracownicy";
            }
            else
            {
                comboBox_filtrPracownik.SelectedIndex = -1;
                comboBox_filtrPracownik.Text = tekst;
                comboBox_filtrPracownik.SelectionStart = comboBox_filtrPracownik.Text.Length;
                comboBox_filtrPracownik.SelectionLength = 0;
            }

            ladowanieFiltrow = false;
        }

        private void ZaladujPracownikowDoComboBox()
        {
            UstawDaneComboBoxPracownikowDoDodawania(listaPracownikow);
        }

        private void ZaladujPracownikowDoFiltra()
        {
            UstawDaneComboBoxPracownikowDoFiltra(listaPracownikow, true, true);
        }

        private void ZaladujSzkoleniaDoComboBox()
        {
            try
            {
                var szkolenia = db.Szkolenie
                    .Select(s => new
                    {
                        IdSzkolenia = s.IdSzkolenia,
                        Nazwa = s.Nazwa
                    })
                    .ToList();

                comboBox_szkolenie.DataSource = szkolenia;
                comboBox_szkolenie.DisplayMember = "Nazwa";
                comboBox_szkolenie.ValueMember = "IdSzkolenia";
                comboBox_szkolenie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania listy szkoleń:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UstawDomyslneDane()
        {
            ustawianieAutomatyczneDaty = true;
            recznaZmianaDatyWaznosci = false;

            dateTimePicker_dataSzkolenia.Value = DateTime.Today;
            dateTimePicker_dataWaznosci.Value = DateTime.Today;
            textBox_cenaSzkolenia.Text = "";

            ustawianieAutomatyczneDaty = false;
        }

        private void UkryjPrzyciskZatwierdzZmiany()
        {
            Control[] znalezioneKontrolki = Controls.Find("button_zatwierdzZmiany", true);

            if (znalezioneKontrolki.Length > 0)
            {
                znalezioneKontrolki[0].Visible = false;
                znalezioneKontrolki[0].Enabled = false;
            }
        }

        private void PokazPrzyciskZatwierdzZmiany()
        {
            Control[] znalezioneKontrolki = Controls.Find("button_zatwierdzZmiany", true);

            if (znalezioneKontrolki.Length > 0)
            {
                znalezioneKontrolki[0].Visible = true;
                znalezioneKontrolki[0].Enabled = true;
            }
        }

        private void UstawTrybDodawania()
        {
            edytowanyIdPracownik = null;
            edytowanyIdSzkolenia = null;
            edytowanaDataSzkolenia = null;

            comboBox_pracownik.Enabled = true;
            comboBox_szkolenie.Enabled = true;
            dateTimePicker_dataSzkolenia.Enabled = true;

            button_dodajSzkolenie.Enabled = true;
            button_dodajSzkolenie.Visible = true;

            UkryjPrzyciskZatwierdzZmiany();
        }

        private void UstawTrybEdycji()
        {
            comboBox_pracownik.Enabled = false;
            comboBox_szkolenie.Enabled = true;
            dateTimePicker_dataSzkolenia.Enabled = true;

            button_dodajSzkolenie.Enabled = false;
            button_dodajSzkolenie.Visible = true;

            PokazPrzyciskZatwierdzZmiany();
        }

        private void WyczyscPanelDodawania()
        {
            comboBox_pracownik.SelectedIndex = -1;
            comboBox_pracownik.Text = "";
            comboBox_szkolenie.SelectedIndex = -1;

            UstawDomyslneDane();
            UstawTrybDodawania();
        }

        private void UstawDateWaznosciAutomatycznie()
        {
            if (comboBox_szkolenie.SelectedValue == null)
                return;

            try
            {
                int idSzkolenia = Convert.ToInt32(comboBox_szkolenie.SelectedValue);

                var szkolenie = db.Szkolenie.FirstOrDefault(s => s.IdSzkolenia == idSzkolenia);

                if (szkolenie == null)
                    return;

                if (szkolenie.Waznosc.HasValue && szkolenie.Waznosc.Value > 0)
                {
                    ustawianieAutomatyczneDaty = true;
                    dateTimePicker_dataWaznosci.Value = dateTimePicker_dataSzkolenia.Value.Date.AddDays(szkolenie.Waznosc.Value);
                    ustawianieAutomatyczneDaty = false;
                }
            }
            catch
            {
                ustawianieAutomatyczneDaty = false;
            }
        }

        private bool SprobujPobracCeneSzkolenia(out decimal cena)
        {
            string tekstCeny = textBox_cenaSzkolenia.Text.Trim().Replace('.', ',');

            if (!decimal.TryParse(
                tekstCeny,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pl-PL"),
                out cena))
            {
                MessageBox.Show(
                    "Podaj poprawną cenę szkolenia.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cena < 0)
            {
                MessageBox.Show(
                    "Cena szkolenia nie może być ujemna.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private DateOnly? UstalDateWaznosci(int idSzkolenia)
        {
            DateOnly? dataWaznosci = DateOnly.FromDateTime(dateTimePicker_dataWaznosci.Value.Date);

            var szkolenie = db.Szkolenie.FirstOrDefault(s => s.IdSzkolenia == idSzkolenia);

            if (szkolenie != null && (!szkolenie.Waznosc.HasValue || szkolenie.Waznosc.Value <= 0))
            {
                dataWaznosci = null;
            }

            return dataWaznosci;
        }

        private void ZaladujSzkolenieDoEdycji(int idPracownik, int idSzkolenia, DateOnly dataSzkolenia)
        {
            try
            {
                var wpis = db.PracownikSzkolenia
                    .FirstOrDefault(ps =>
                        ps.IdPracownik == idPracownik &&
                        ps.IdSzkolenia == idSzkolenia &&
                        ps.DataSzkolenia == dataSzkolenia);

                if (wpis == null)
                {
                    MessageBox.Show(
                        "Nie znaleziono wybranego szkolenia.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                panel1.Visible = true;

                ZaladujPracownikowDoComboBox();
                ZaladujSzkoleniaDoComboBox();

                edytowanyIdPracownik = wpis.IdPracownik;
                edytowanyIdSzkolenia = wpis.IdSzkolenia;
                edytowanaDataSzkolenia = wpis.DataSzkolenia;

                comboBox_pracownik.SelectedValue = wpis.IdPracownik;
                comboBox_szkolenie.SelectedValue = wpis.IdSzkolenia;

                dateTimePicker_dataSzkolenia.Value = wpis.DataSzkolenia.ToDateTime(TimeOnly.MinValue);

                if (wpis.DataWaznosci.HasValue)
                {
                    dateTimePicker_dataWaznosci.Value = wpis.DataWaznosci.Value.ToDateTime(TimeOnly.MinValue);
                }
                else
                {
                    dateTimePicker_dataWaznosci.Value = wpis.DataSzkolenia.ToDateTime(TimeOnly.MinValue);
                }

                textBox_cenaSzkolenia.Text = wpis.CenaSzkolenia.ToString("0.00", CultureInfo.GetCultureInfo("pl-PL"));

                UstawTrybEdycji();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania szkolenia do edycji:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DodajSzkolenie()
        {
            if (comboBox_pracownik.SelectedValue == null || Convert.ToInt32(comboBox_pracownik.SelectedValue) <= 0)
            {
                MessageBox.Show(
                    "Wybierz pracownika.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (comboBox_szkolenie.SelectedValue == null)
            {
                MessageBox.Show(
                    "Wybierz szkolenie.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!SprobujPobracCeneSzkolenia(out decimal cena))
                return;

            try
            {
                int idPracownik = Convert.ToInt32(comboBox_pracownik.SelectedValue);
                int idSzkolenia = Convert.ToInt32(comboBox_szkolenie.SelectedValue);

                DateOnly dataSzkolenia = DateOnly.FromDateTime(dateTimePicker_dataSzkolenia.Value.Date);
                DateOnly? dataWaznosci = UstalDateWaznosci(idSzkolenia);

                bool czyIstnieje = db.PracownikSzkolenia.Any(ps =>
                    ps.IdPracownik == idPracownik &&
                    ps.IdSzkolenia == idSzkolenia &&
                    ps.DataSzkolenia == dataSzkolenia);

                if (czyIstnieje)
                {
                    MessageBox.Show(
                        "Dla tego pracownika istnieje już wpis tego samego szkolenia z tą samą datą szkolenia.",
                        "Duplikat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                PracownikSzkolenia nowyWpis = new PracownikSzkolenia
                {
                    IdPracownik = idPracownik,
                    IdSzkolenia = idSzkolenia,
                    DataSzkolenia = dataSzkolenia,
                    DataWaznosci = dataWaznosci,
                    CenaSzkolenia = cena
                };

                db.PracownikSzkolenia.Add(nowyWpis);
                db.SaveChanges();

                MessageBox.Show(
                    "Szkolenie zostało przypisane do pracownika.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscPanelDodawania();
                panel1.Visible = false;
                ZaladujSzkoleniaPracownikow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas dodawania szkolenia:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ZapiszZmianySzkolenia()
        {
            if (edytowanyIdPracownik == null ||
                edytowanyIdSzkolenia == null ||
                edytowanaDataSzkolenia == null)
            {
                MessageBox.Show(
                    "Nie wybrano szkolenia do edycji.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (comboBox_szkolenie.SelectedValue == null)
            {
                MessageBox.Show(
                    "Wybierz szkolenie.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!SprobujPobracCeneSzkolenia(out decimal cena))
                return;

            try
            {
                int nowyIdPracownik = edytowanyIdPracownik.Value;
                int nowyIdSzkolenia = Convert.ToInt32(comboBox_szkolenie.SelectedValue);

                DateOnly nowaDataSzkolenia = DateOnly.FromDateTime(dateTimePicker_dataSzkolenia.Value.Date);
                DateOnly? nowaDataWaznosci = UstalDateWaznosci(nowyIdSzkolenia);

                var staryWpis = db.PracownikSzkolenia.FirstOrDefault(ps =>
                    ps.IdPracownik == edytowanyIdPracownik.Value &&
                    ps.IdSzkolenia == edytowanyIdSzkolenia.Value &&
                    ps.DataSzkolenia == edytowanaDataSzkolenia.Value);

                if (staryWpis == null)
                {
                    MessageBox.Show(
                        "Nie znaleziono szkolenia w bazie.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                bool zmienionoKlucz =
                    nowyIdPracownik != edytowanyIdPracownik.Value ||
                    nowyIdSzkolenia != edytowanyIdSzkolenia.Value ||
                    nowaDataSzkolenia != edytowanaDataSzkolenia.Value;

                if (zmienionoKlucz)
                {
                    bool duplikat = db.PracownikSzkolenia.Any(ps =>
                        ps.IdPracownik == nowyIdPracownik &&
                        ps.IdSzkolenia == nowyIdSzkolenia &&
                        ps.DataSzkolenia == nowaDataSzkolenia);

                    if (duplikat)
                    {
                        MessageBox.Show(
                            "Dla tego pracownika istnieje już wpis tego samego szkolenia z tą samą datą szkolenia.",
                            "Duplikat",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    db.PracownikSzkolenia.Remove(staryWpis);

                    var nowyWpis = new PracownikSzkolenia
                    {
                        IdPracownik = nowyIdPracownik,
                        IdSzkolenia = nowyIdSzkolenia,
                        DataSzkolenia = nowaDataSzkolenia,
                        DataWaznosci = nowaDataWaznosci,
                        CenaSzkolenia = cena
                    };

                    db.PracownikSzkolenia.Add(nowyWpis);
                }
                else
                {
                    staryWpis.DataWaznosci = nowaDataWaznosci;
                    staryWpis.CenaSzkolenia = cena;
                }

                db.SaveChanges();

                MessageBox.Show(
                    "Zmiany szkolenia zostały zapisane.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscPanelDodawania();
                panel1.Visible = false;
                ZaladujSzkoleniaPracownikow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas zapisywania zmian szkolenia:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button_odswiez_Click(object sender, EventArgs e)
        {
            ZaladujSzkoleniaPracownikow();
        }

        private void button_noweSzkolenie_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible)
            {
                WyczyscPanelDodawania();
                ZaladujPracownikowDoComboBox();
                ZaladujSzkoleniaDoComboBox();
                UstawTrybDodawania();
            }
            else
            {
                WyczyscPanelDodawania();
                UstawTrybDodawania();
            }
        }

        private void button_dodajSzkolenie_Click(object sender, EventArgs e)
        {
            DodajSzkolenie();
        }

        private void button_zatwierdzZmiany_Click(object sender, EventArgs e)
        {
            ZapiszZmianySzkolenia();
        }

        private void dataGridView_szkolenia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                var row = dataGridView_szkolenia.Rows[e.RowIndex];

                int idPracownik = Convert.ToInt32(row.Cells["IdPracownik"].Value);
                int idSzkolenia = Convert.ToInt32(row.Cells["IdSzkolenia"].Value);

                string dataKey = row.Cells["DataSzkoleniaKey"].Value?.ToString();

                if (!DateOnly.TryParseExact(
                    dataKey,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateOnly dataSzkolenia))
                {
                    MessageBox.Show(
                        "Nie udało się odczytać daty szkolenia.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                ZaladujSzkolenieDoEdycji(idPracownik, idSzkolenia, dataSzkolenia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas wyboru szkolenia:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void comboBox_filtrPracownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ladowanieFiltrow)
                return;

            if (comboBox_filtrPracownik.SelectedIndex == -1 || comboBox_filtrPracownik.SelectedValue == null)
                return;

            int id = Convert.ToInt32(comboBox_filtrPracownik.SelectedValue);

            if (id == -1)
                return;

            ZaladujSzkoleniaPracownikow();
        }

        private void comboBox_filtrPracownik_TextUpdate(object sender, EventArgs e)
        {
            if (ladowanieFiltrow)
                return;

            string wpisanyTekst = comboBox_filtrPracownik.Text;

            BeginInvoke(new Action(() =>
            {
                FiltrujComboBoxFiltrPracownik(wpisanyTekst);
            }));
        }

        private void FiltrujComboBoxFiltrPracownik(string wpisanyTekst)
        {
            if (ladowanieFiltrow)
                return;

            wpisanyTekst = wpisanyTekst?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(wpisanyTekst))
            {
                UstawDaneComboBoxPracownikowDoFiltra(listaPracownikow, true, false, "");
                return;
            }

            var przefiltrowanaLista = listaPracownikow
                .Where(p =>
                    p.Imie.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.Nazwisko.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.DanePracownika.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase))
                .ToList();

            UstawDaneComboBoxPracownikowDoFiltra(przefiltrowanaLista, true, false, wpisanyTekst);

            if (przefiltrowanaLista.Count > 0)
            {
                comboBox_filtrPracownik.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void comboBox_filtrPracownik_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_filtrPracownik.Text))
            {
                UstawDaneComboBoxPracownikowDoFiltra(listaPracownikow, true, true);
                ZaladujSzkoleniaPracownikow();
            }
        }

        private void checkBox_tylkoNiewazne_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujSzkoleniaPracownikow();
        }

        private void comboBox_pracownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ladowanieComboPracownikow)
                return;

            if (comboBox_pracownik.SelectedIndex == -1 || comboBox_pracownik.SelectedValue == null)
                return;

            int id = Convert.ToInt32(comboBox_pracownik.SelectedValue);

            if (id == -1)
                return;
        }

        private void comboBox_pracownik_TextUpdate(object sender, EventArgs e)
        {
            if (ladowanieComboPracownikow)
                return;

            string wpisanyTekst = comboBox_pracownik.Text;

            BeginInvoke(new Action(() =>
            {
                FiltrujComboBoxPracownik(wpisanyTekst);
            }));
        }

        private void FiltrujComboBoxPracownik(string wpisanyTekst)
        {
            if (ladowanieComboPracownikow)
                return;

            wpisanyTekst = wpisanyTekst?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(wpisanyTekst))
            {
                UstawDaneComboBoxPracownikowDoDodawania(listaPracownikow, "");
                return;
            }

            var przefiltrowanaLista = listaPracownikow
                .Where(p =>
                    p.Imie.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.Nazwisko.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.DanePracownika.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase))
                .ToList();

            UstawDaneComboBoxPracownikowDoDodawania(przefiltrowanaLista, wpisanyTekst);

            if (przefiltrowanaLista.Count > 0)
            {
                comboBox_pracownik.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void comboBox_pracownik_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_pracownik.Text))
            {
                UstawDaneComboBoxPracownikowDoDodawania(listaPracownikow, "");
            }
        }

        private void comboBox_szkolenie_SelectedIndexChanged(object sender, EventArgs e)
        {
            recznaZmianaDatyWaznosci = false;
            UstawDateWaznosciAutomatycznie();
        }

        private void dateTimePicker_dataSzkolenia_ValueChanged(object sender, EventArgs e)
        {
            if (!recznaZmianaDatyWaznosci)
            {
                UstawDateWaznosciAutomatycznie();
            }
        }

        private void dateTimePicker_dataWaznosci_ValueChanged(object sender, EventArgs e)
        {
            if (!ustawianieAutomatyczneDaty)
            {
                recznaZmianaDatyWaznosci = true;
            }
        }
    }
}
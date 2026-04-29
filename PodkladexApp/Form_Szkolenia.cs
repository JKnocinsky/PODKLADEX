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
        private bool ustawianieAutomatyczneDaty = false;
        private bool recznaZmianaDatyWaznosci = false;

        public Form_Szkolenia()
        {
            InitializeComponent();
            db = new PodkladexContext();
            panel1.Visible = false;
        }

        private void Form_Szkolenia_Load(object sender, EventArgs e)
        {
            KonfigurujDataGridView();
            ZaladujPracownikowDoComboBox();
            ZaladujSzkoleniaDoComboBox();
            ZaladujPracownikowDoFiltra();
            UstawDomyslneDane();
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

                    if (idPracownik != 0)
                    {
                        zapytanie = zapytanie.Where(ps => ps.IdPracownik == idPracownik);
                    }
                }

                if (checkBox_tylkoNiewazne.Checked)
                {
                    DateOnly dzis = DateOnly.FromDateTime(DateTime.Today);
                    zapytanie = zapytanie.Where(ps => ps.DataWaznosci != null && ps.DataWaznosci < dzis);
                }

                var daneZBazy = zapytanie
                    .OrderBy(ps => ps.IdPracownikNavigation.IdOsobaNavigation.Nazwisko)
                    .ThenBy(ps => ps.IdPracownikNavigation.IdOsobaNavigation.Imie)
                    .ThenByDescending(ps => ps.DataSzkolenia)
                    .ToList();

                var lista = daneZBazy
                    .Select(ps => new
                    {
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
                        CenaSzkolenia = ps.CenaSzkolenia.ToString("0.00")
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

        private void ZaladujPracownikowDoComboBox()
        {
            try
            {
                var pracownicy = db.Pracownik
                    .Include(p => p.IdOsobaNavigation)
                    .Select(p => new
                    {
                        IdPracownik = p.IdPracownik,
                        DanePracownika = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko
                    })
                    .ToList();

                comboBox_pracownik.DataSource = pracownicy;
                comboBox_pracownik.DisplayMember = "DanePracownika";
                comboBox_pracownik.ValueMember = "IdPracownik";
                comboBox_pracownik.SelectedIndex = -1;
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

        private void ZaladujPracownikowDoFiltra()
        {
            try
            {
                ladowanieFiltrow = true;

                var pracownicy = db.Pracownik
                    .Include(p => p.IdOsobaNavigation)
                    .Select(p => new
                    {
                        IdPracownik = p.IdPracownik,
                        DanePracownika = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko
                    })
                    .ToList();

                var listaDoFiltra = new List<object>
                {
                    new { IdPracownik = 0, DanePracownika = "Wszyscy pracownicy" }
                };

                foreach (var pracownik in pracownicy)
                {
                    listaDoFiltra.Add(new
                    {
                        IdPracownik = pracownik.IdPracownik,
                        DanePracownika = pracownik.DanePracownika
                    });
                }

                comboBox_filtrPracownik.DataSource = null;
                comboBox_filtrPracownik.DataSource = listaDoFiltra;
                comboBox_filtrPracownik.DisplayMember = "DanePracownika";
                comboBox_filtrPracownik.ValueMember = "IdPracownik";
                comboBox_filtrPracownik.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania pracowników do filtra:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                ladowanieFiltrow = false;
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

        private void WyczyscPanelDodawania()
        {
            comboBox_pracownik.SelectedIndex = -1;
            comboBox_szkolenie.SelectedIndex = -1;
            UstawDomyslneDane();
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
                    dateTimePicker_dataWaznosci.Value =
                        dateTimePicker_dataSzkolenia.Value.Date.AddDays(szkolenie.Waznosc.Value);
                    ustawianieAutomatyczneDaty = false;
                }
            }
            catch
            {
                ustawianieAutomatyczneDaty = false;
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
            }
        }

        private void button_dodajSzkolenie_Click(object sender, EventArgs e)
        {
            if (comboBox_pracownik.SelectedValue == null)
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

            if (!decimal.TryParse(
                    textBox_cenaSzkolenia.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal cena)
                &&
                !decimal.TryParse(
                    textBox_cenaSzkolenia.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.GetCultureInfo("pl-PL"),
                    out cena))
            {
                MessageBox.Show(
                    "Podaj poprawną cenę szkolenia.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cena < 0)
            {
                MessageBox.Show(
                    "Cena szkolenia nie może być ujemna.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idPracownik = Convert.ToInt32(comboBox_pracownik.SelectedValue);
                int idSzkolenia = Convert.ToInt32(comboBox_szkolenie.SelectedValue);
                DateOnly dataSzkolenia = DateOnly.FromDateTime(dateTimePicker_dataSzkolenia.Value.Date);
                DateOnly? dataWaznosci = DateOnly.FromDateTime(dateTimePicker_dataWaznosci.Value.Date);

                bool czyIstnieje = db.PracownikSzkolenia.Any(ps =>
                    ps.IdPracownik == idPracownik &&
                    ps.IdSzkolenia == idSzkolenia);

                if (czyIstnieje)
                {
                    MessageBox.Show(
                        "Dla tego pracownika istnieje już wpis tego szkolenia.",
                        "Duplikat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var szkolenie = db.Szkolenie.FirstOrDefault(s => s.IdSzkolenia == idSzkolenia);
                if (szkolenie != null && (!szkolenie.Waznosc.HasValue || szkolenie.Waznosc.Value <= 0))
                {
                    dataWaznosci = null;
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

        private void comboBox_filtrPracownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ladowanieFiltrow)
                return;

            ZaladujSzkoleniaPracownikow();
        }

        private void checkBox_tylkoNiewazne_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujSzkoleniaPracownikow();
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
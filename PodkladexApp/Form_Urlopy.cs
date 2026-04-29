using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_Urlopy : Form
    {
        private PodkladexContext db;

        private bool ladowanieFiltrow = false;
        private bool ladowanieComboPracownikow = false;

        private List<PracownikComboBoxItem> listaPracownikow = new List<PracownikComboBoxItem>();

        private class PracownikComboBoxItem
        {
            public int IdPracownik { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string DanePracownika { get; set; }
        }

        public Form_Urlopy()
        {
            InitializeComponent();
            db = new PodkladexContext();
        }

        private void Form_Urlopy_Load(object sender, EventArgs e)
        {
            KonfigurujDataGridView();
            panel1.Visible = false;

            ZaladujPracownikow();
            ZaladujPracownikowDoComboBox();
            ZaladujPracownikowDoFiltra();
            ZaladujRodzajeUrlopuDoComboBox();
            UstawDomyslneDaty();
            ZaladujWnioski();
        }

        private void KonfigurujDataGridView()
        {
            dataGridView_urlopy.AutoGenerateColumns = false;
            dataGridView_urlopy.AllowUserToAddRows = false;
            dataGridView_urlopy.AllowUserToDeleteRows = false;
            dataGridView_urlopy.ReadOnly = true;
            dataGridView_urlopy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_urlopy.MultiSelect = false;
            dataGridView_urlopy.RowHeadersVisible = false;
            dataGridView_urlopy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_urlopy.Columns.Clear();

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdWniosku",
                HeaderText = "ID wniosku",
                DataPropertyName = "IdWniosku",
                FillWeight = 60,
                Visible = false
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Pracownik",
                HeaderText = "Pracownik",
                DataPropertyName = "Pracownik",
                FillWeight = 150
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Urlop",
                HeaderText = "Rodzaj urlopu",
                DataPropertyName = "Urlop",
                FillWeight = 110
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataRozp",
                HeaderText = "Data rozpoczęcia",
                DataPropertyName = "DataRozp",
                FillWeight = 90
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataZak",
                HeaderText = "Data zakończenia",
                DataPropertyName = "DataZak",
                FillWeight = 90
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "StatusWniosku",
                HeaderText = "Zatwierdzony",
                DataPropertyName = "StatusWniosku",
                FillWeight = 70
            });
        }

        private void ZaladujWnioski()
        {
            try
            {
                var zapytanie = db.WniosekUrlopowy
                    .Include(w => w.IdPracownikNavigation)
                        .ThenInclude(p => p.IdOsobaNavigation)
                    .Include(w => w.IdUrlopuNavigation)
                    .AsQueryable();

                if (checkBox_tylkoNiezatwierdzone.Checked)
                {
                    zapytanie = zapytanie.Where(w => w.StatusWniosku == false);
                }

                if (comboBox_filtrPracownik.SelectedValue != null)
                {
                    int idPracownik = Convert.ToInt32(comboBox_filtrPracownik.SelectedValue);

                    if (idPracownik != 0)
                    {
                        zapytanie = zapytanie.Where(w => w.IdPracownik == idPracownik);
                    }
                }

                var daneZBazy = zapytanie
                    .OrderBy(w => w.StatusWniosku)
                    .ThenBy(w => w.DataRozp)
                    .ToList();

                var lista = daneZBazy
                    .Select(w => new
                    {
                        w.IdWniosku,
                        Pracownik = w.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                                    w.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                        Urlop = w.IdUrlopuNavigation.Nazwa,
                        DataRozp = w.DataRozp.ToString("dd.MM.yyyy"),
                        DataZak = w.DataZak.ToString("dd.MM.yyyy"),
                        w.StatusWniosku
                    })
                    .ToList();

                dataGridView_urlopy.DataSource = null;
                dataGridView_urlopy.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania wniosków urlopowych:\n" + ex.Message,
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

        private void UstawDaneComboBoxPracownikowDoDodawania(List<PracownikComboBoxItem> pracownicy)
        {
            ladowanieComboPracownikow = true;

            comboBox_Dane_Pracownika.DataSource = null;
            comboBox_Dane_Pracownika.DataSource = pracownicy;
            comboBox_Dane_Pracownika.DisplayMember = "DanePracownika";
            comboBox_Dane_Pracownika.ValueMember = "IdPracownik";
            comboBox_Dane_Pracownika.SelectedIndex = -1;
            comboBox_Dane_Pracownika.Text = "";

            ladowanieComboPracownikow = false;
        }

        private void UstawDaneComboBoxPracownikowDoFiltra(List<PracownikComboBoxItem> pracownicy, bool ustawWszystkich = true)
        {
            try
            {
                ladowanieFiltrow = true;

                var listaDoFiltra = new List<object>();

                if (ustawWszystkich)
                {
                    listaDoFiltra.Add(new { IdPracownik = 0, DanePracownika = "Wszyscy pracownicy" });
                }

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

                if (ustawWszystkich)
                {
                    comboBox_filtrPracownik.SelectedIndex = 0;
                    comboBox_filtrPracownik.Text = "Wszyscy pracownicy";
                }
                else
                {
                    comboBox_filtrPracownik.SelectedIndex = -1;
                    comboBox_filtrPracownik.Text = "";
                }

                ladowanieFiltrow = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }
        }

        private void ZaladujPracownikowDoComboBox()
        {
            UstawDaneComboBoxPracownikowDoDodawania(listaPracownikow);
        }

        private void ZaladujPracownikowDoFiltra()
        {
            UstawDaneComboBoxPracownikowDoFiltra(listaPracownikow, true);
        }

        private void ZaladujRodzajeUrlopuDoComboBox()
        {
            try
            {
                var rodzajeUrlopu = db.Urlop
                    .Select(u => new
                    {
                        IdUrlopu = u.IdUrlopu,
                        Nazwa = u.Nazwa
                    })
                    .ToList();

                comboBox_Rodzaj_Urlopu.DataSource = rodzajeUrlopu;
                comboBox_Rodzaj_Urlopu.DisplayMember = "Nazwa";
                comboBox_Rodzaj_Urlopu.ValueMember = "IdUrlopu";
                comboBox_Rodzaj_Urlopu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania rodzajów urlopu:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UstawDomyslneDaty()
        {
            dateTimePicker_datarozp.Value = DateTime.Today;
            dateTimePicker_datazak.Value = DateTime.Today;
        }

        private void WyczyscPanelDodawania()
        {
            comboBox_Dane_Pracownika.SelectedIndex = -1;
            comboBox_Dane_Pracownika.Text = "";
            comboBox_Rodzaj_Urlopu.SelectedIndex = -1;
            UstawDomyslneDaty();
        }

        private int? PobierzIdZaznaczonegoWniosku()
        {
            if (dataGridView_urlopy.CurrentRow == null)
                return null;

            object wartosc = dataGridView_urlopy.CurrentRow.Cells["IdWniosku"].Value;

            if (wartosc == null)
                return null;

            return Convert.ToInt32(wartosc);
        }

        private void button_odswiez_Click(object sender, EventArgs e)
        {
            ZaladujWnioski();
        }

        private void checkBox_tylkoNiezatwierdzone_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujWnioski();
        }

        private void button_zatwierdz_Click(object sender, EventArgs e)
        {
            int? idWniosku = PobierzIdZaznaczonegoWniosku();

            if (idWniosku == null)
            {
                MessageBox.Show(
                    "Wybierz wniosek do zatwierdzenia.",
                    "Brak wyboru",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var wniosek = db.WniosekUrlopowy.FirstOrDefault(w => w.IdWniosku == idWniosku.Value);

                if (wniosek == null)
                {
                    MessageBox.Show(
                        "Nie znaleziono wybranego wniosku.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (wniosek.StatusWniosku)
                {
                    MessageBox.Show(
                        "Ten wniosek jest już zatwierdzony.",
                        "Informacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult wynik = MessageBox.Show(
                    "Czy na pewno chcesz zatwierdzić wybrany wniosek urlopowy?",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (wynik == DialogResult.No)
                    return;

                wniosek.StatusWniosku = true;
                db.SaveChanges();

                MessageBox.Show(
                    "Wniosek został zatwierdzony.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ZaladujWnioski();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas zatwierdzania wniosku:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button_dodajWniosek_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible)
            {
                WyczyscPanelDodawania();
                ZaladujPracownikowDoComboBox();
                ZaladujRodzajeUrlopuDoComboBox();
            }
        }

        private void button_dodajWniosekdoZatwierdzenia_Click(object sender, EventArgs e)
        {
            if (comboBox_Dane_Pracownika.SelectedValue == null)
            {
                MessageBox.Show(
                    "Wybierz pracownika.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (comboBox_Rodzaj_Urlopu.SelectedValue == null)
            {
                MessageBox.Show(
                    "Wybierz rodzaj urlopu.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePicker_datazak.Value.Date < dateTimePicker_datarozp.Value.Date)
            {
                MessageBox.Show(
                    "Data zakończenia urlopu nie może być wcześniejsza niż data rozpoczęcia.",
                    "Błędne daty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idPracownik = Convert.ToInt32(comboBox_Dane_Pracownika.SelectedValue);
                int idUrlopu = Convert.ToInt32(comboBox_Rodzaj_Urlopu.SelectedValue);

                WniosekUrlopowy nowyWniosek = new WniosekUrlopowy
                {
                    IdPracownik = idPracownik,
                    IdUrlopu = idUrlopu,
                    DataRozp = DateOnly.FromDateTime(dateTimePicker_datarozp.Value.Date),
                    DataZak = DateOnly.FromDateTime(dateTimePicker_datazak.Value.Date),
                    StatusWniosku = false
                };

                db.WniosekUrlopowy.Add(nowyWniosek);
                db.SaveChanges();

                MessageBox.Show(
                    "Wniosek został dodany do zatwierdzenia.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscPanelDodawania();
                panel1.Visible = false;
                ZaladujWnioski();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas dodawania wniosku urlopowego:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void comboBox_filtrPracownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ladowanieFiltrow)
                ZaladujWnioski();
        }

        private void comboBox_filtrPracownik_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                if (listaPracownikow == null)
                    return;

                string wpisanyTekst = comboBox_filtrPracownik.Text.Trim();

                var przefiltrowanaLista = listaPracownikow
                    .Where(p =>
                        p.Imie.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                        p.Nazwisko.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                        p.DanePracownika.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                UstawDaneComboBoxPracownikowDoFiltra(przefiltrowanaLista, false);

                comboBox_filtrPracownik.Text = wpisanyTekst;
                comboBox_filtrPracownik.SelectionStart = comboBox_filtrPracownik.Text.Length;
                comboBox_filtrPracownik.SelectionLength = 0;

                if (przefiltrowanaLista.Count > 0)
                {
                    comboBox_filtrPracownik.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Błąd filtra");
            }
        }

        private void comboBox_Dane_Pracownika_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ladowanieComboPracownikow)
                return;
        }

        private void comboBox_Dane_Pracownika_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                if (listaPracownikow == null)
                    return;

                string wpisanyTekst = comboBox_Dane_Pracownika.Text.Trim();

                var przefiltrowanaLista = listaPracownikow
                    .Where(p =>
                        p.Imie.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                        p.Nazwisko.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                        p.DanePracownika.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                ladowanieComboPracownikow = true;

                comboBox_Dane_Pracownika.DataSource = null;
                comboBox_Dane_Pracownika.DataSource = przefiltrowanaLista;
                comboBox_Dane_Pracownika.DisplayMember = "DanePracownika";
                comboBox_Dane_Pracownika.ValueMember = "IdPracownik";
                comboBox_Dane_Pracownika.SelectedIndex = -1;
                comboBox_Dane_Pracownika.Text = wpisanyTekst;
                comboBox_Dane_Pracownika.SelectionStart = comboBox_Dane_Pracownika.Text.Length;
                comboBox_Dane_Pracownika.SelectionLength = 0;

                if (przefiltrowanaLista.Count > 0)
                {
                    comboBox_Dane_Pracownika.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }

                ladowanieComboPracownikow = false;
            }
            catch (Exception)
            {

                MessageBox.Show("Błąd nazwy");
            }
        }
    }
}
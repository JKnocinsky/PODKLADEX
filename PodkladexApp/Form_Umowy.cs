using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_Umowy : Form
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

        public Form_Umowy()
        {
            InitializeComponent();
            db = new PodkladexContext();
            panel1.Visible = false;
        }

        private void Form_Umowy_Load(object sender, EventArgs e)
        {
            KonfigurujDataGridView();
            ZaladujPracownikow();
            ZaladujPracownikowDoComboBox();
            ZaladujPracownikowDoFiltra();
            ZaladujRodzajeUmowDoComboBox();
            UstawDomyslneDaty();
            ZaladujUmowy();
        }

        private void KonfigurujDataGridView()
        {
            dataGridView_umowy.AutoGenerateColumns = false;
            dataGridView_umowy.AllowUserToAddRows = false;
            dataGridView_umowy.AllowUserToDeleteRows = false;
            dataGridView_umowy.ReadOnly = true;
            dataGridView_umowy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_umowy.MultiSelect = false;
            dataGridView_umowy.RowHeadersVisible = false;
            dataGridView_umowy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_umowy.Columns.Clear();

            dataGridView_umowy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdUmowa",
                HeaderText = "ID",
                DataPropertyName = "IdUmowa",
                FillWeight = 50,
                Visible = false
            });

            dataGridView_umowy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Pracownik",
                HeaderText = "Pracownik",
                DataPropertyName = "Pracownik",
                FillWeight = 160
            });

            dataGridView_umowy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RodzajUmowy",
                HeaderText = "Rodzaj umowy",
                DataPropertyName = "RodzajUmowy",
                FillWeight = 120
            });

            dataGridView_umowy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataRoz",
                HeaderText = "Od",
                DataPropertyName = "DataRoz",
                FillWeight = 80
            });

            dataGridView_umowy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataZak",
                HeaderText = "Do",
                DataPropertyName = "DataZak",
                FillWeight = 80
            });
        }

        private void ZaladujUmowy()
        {
            try
            {
                var zapytanie = db.Umowa
                    .Include(u => u.IdPracownikNavigation)
                        .ThenInclude(p => p.IdOsobaNavigation)
                    .Include(u => u.IdRodzajuNavigation)
                    .AsQueryable();

                if (comboBox_filtrPracownik.SelectedValue != null)
                {
                    int idPracownik = Convert.ToInt32(comboBox_filtrPracownik.SelectedValue);

                    if (idPracownik != 0)
                    {
                        zapytanie = zapytanie.Where(u => u.IdPracownik == idPracownik);
                    }
                }

                if (checkBox_tylkoAktywne.Checked)
                {
                    DateOnly dzis = DateOnly.FromDateTime(DateTime.Today);
                    zapytanie = zapytanie.Where(u => u.DataRoz <= dzis && u.DataZak >= dzis);
                }

                var daneZBazy = zapytanie
                    .OrderBy(u => u.DataRoz)
                    .ToList();

                var lista = daneZBazy
                    .Select(u => new
                    {
                        u.IdUmowa,
                        Pracownik = u.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                                    u.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                        RodzajUmowy = u.IdRodzajuNavigation.Nazwa,
                        DataRoz = u.DataRoz.ToString("dd.MM.yyyy"),
                        DataZak = u.DataZak.ToString("dd.MM.yyyy")
                    })
                    .ToList();

                dataGridView_umowy.DataSource = null;
                dataGridView_umowy.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania umów:\n" + ex.Message,
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

            comboBox_pracownik.DataSource = null;
            comboBox_pracownik.DataSource = pracownicy;
            comboBox_pracownik.DisplayMember = "DanePracownika";
            comboBox_pracownik.ValueMember = "IdPracownik";
            comboBox_pracownik.SelectedIndex = -1;
            comboBox_pracownik.Text = "";

            ladowanieComboPracownikow = false;
        }

        private void UstawDaneComboBoxPracownikowDoFiltra(List<PracownikComboBoxItem> pracownicy, bool ustawWszystkich = true)
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

        private void ZaladujPracownikowDoComboBox()
        {
            UstawDaneComboBoxPracownikowDoDodawania(listaPracownikow);
        }

        private void ZaladujPracownikowDoFiltra()
        {
            UstawDaneComboBoxPracownikowDoFiltra(listaPracownikow, true);
        }

        private void ZaladujRodzajeUmowDoComboBox()
        {
            try
            {
                var rodzajeUmow = db.RodzajUmowy
                    .Select(r => new
                    {
                        IdRodzaju = r.IdRodzaju,
                        Nazwa = r.Nazwa
                    })
                    .ToList();

                comboBox_rodzajUmowy.DataSource = rodzajeUmow;
                comboBox_rodzajUmowy.DisplayMember = "Nazwa";
                comboBox_rodzajUmowy.ValueMember = "IdRodzaju";
                comboBox_rodzajUmowy.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania rodzajów umów:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UstawDomyslneDaty()
        {
            dateTimePicker_dataroz.Value = DateTime.Today;
            dateTimePicker_datazak.Value = DateTime.Today;
        }

        private void WyczyscPolaDodawania()
        {
            comboBox_pracownik.SelectedIndex = -1;
            comboBox_pracownik.Text = "";
            comboBox_rodzajUmowy.SelectedIndex = -1;
            UstawDomyslneDaty();
        }

        private void button_dodajUmowe_Click(object sender, EventArgs e)
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

            if (comboBox_rodzajUmowy.SelectedValue == null)
            {
                MessageBox.Show(
                    "Wybierz rodzaj umowy.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePicker_datazak.Value.Date < dateTimePicker_dataroz.Value.Date)
            {
                MessageBox.Show(
                    "Data zakończenia umowy nie może być wcześniejsza niż data rozpoczęcia.",
                    "Błędne daty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idPracownik = Convert.ToInt32(comboBox_pracownik.SelectedValue);
                int idRodzaju = Convert.ToInt32(comboBox_rodzajUmowy.SelectedValue);

                Umowa nowaUmowa = new Umowa
                {
                    IdPracownik = idPracownik,
                    IdRodzaju = idRodzaju,
                    DataRoz = DateOnly.FromDateTime(dateTimePicker_dataroz.Value.Date),
                    DataZak = DateOnly.FromDateTime(dateTimePicker_datazak.Value.Date)
                };

                db.Umowa.Add(nowaUmowa);
                db.SaveChanges();

                MessageBox.Show(
                    "Nowa umowa została dodana.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscPolaDodawania();
                panel1.Visible = false;
                ZaladujUmowy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas dodawania umowy:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button_nowaumowa_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible)
            {
                WyczyscPolaDodawania();
                ZaladujPracownikowDoComboBox();
                ZaladujRodzajeUmowDoComboBox();
            }
        }

        private void comboBox_filtrPracownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ladowanieFiltrow)
                return;

            ZaladujUmowy();
        }

        private void comboBox_filtrPracownik_TextUpdate(object sender, EventArgs e)
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

        private void comboBox_pracownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ladowanieComboPracownikow)
                return;
        }

        private void comboBox_pracownik_TextUpdate(object sender, EventArgs e)
        {
            if (listaPracownikow == null)
                return;

            string wpisanyTekst = comboBox_pracownik.Text.Trim();

            var przefiltrowanaLista = listaPracownikow
                .Where(p =>
                    p.Imie.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.Nazwisko.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.DanePracownika.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ladowanieComboPracownikow = true;

            comboBox_pracownik.DataSource = null;
            comboBox_pracownik.DataSource = przefiltrowanaLista;
            comboBox_pracownik.DisplayMember = "DanePracownika";
            comboBox_pracownik.ValueMember = "IdPracownik";
            comboBox_pracownik.SelectedIndex = -1;
            comboBox_pracownik.Text = wpisanyTekst;
            comboBox_pracownik.SelectionStart = comboBox_pracownik.Text.Length;
            comboBox_pracownik.SelectionLength = 0;

            if (przefiltrowanaLista.Count > 0)
            {
                comboBox_pracownik.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }

            ladowanieComboPracownikow = false;
        }

        private void checkBox_tylkoAktywne_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujUmowy();
        }
    }
}
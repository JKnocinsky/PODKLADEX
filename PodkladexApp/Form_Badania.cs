using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_Badania : Form
    {
        private readonly PodkladexContext db;

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

        public Form_Badania()
        {
            InitializeComponent();
            db = new PodkladexContext();
            panel1.Visible = false;
        }

        private void Form_Badania_Load(object sender, EventArgs e)
        {
            KonfigurujDataGridView();
            ZaladujPracownikow();
            ZaladujPracownikowDoComboBox();
            ZaladujPracownikowDoFiltra();
            ZaladujTypyBadanDoComboBox();
            UstawDomyslneDane();
            ZaladujBadania();
        }

        private void KonfigurujDataGridView()
        {
            dataGridView_badania.AutoGenerateColumns = false;
            dataGridView_badania.AllowUserToAddRows = false;
            dataGridView_badania.AllowUserToDeleteRows = false;
            dataGridView_badania.ReadOnly = true;
            dataGridView_badania.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_badania.MultiSelect = false;
            dataGridView_badania.RowHeadersVisible = false;
            dataGridView_badania.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_badania.Columns.Clear();

            dataGridView_badania.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Pracownik",
                HeaderText = "Pracownik",
                DataPropertyName = "Pracownik",
                FillWeight = 170
            });

            dataGridView_badania.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TypBadania",
                HeaderText = "Typ badania",
                DataPropertyName = "TypBadania",
                FillWeight = 150
            });

            dataGridView_badania.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataBadania",
                HeaderText = "Data badania",
                DataPropertyName = "DataBadania",
                FillWeight = 90
            });

            dataGridView_badania.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataWaznosci",
                HeaderText = "Ważne do",
                DataPropertyName = "DataWaznosci",
                FillWeight = 90
            });

            dataGridView_badania.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Koszt",
                HeaderText = "Koszt",
                DataPropertyName = "Koszt",
                FillWeight = 70
            });

            dataGridView_badania.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Uwagi",
                HeaderText = "Uwagi",
                DataPropertyName = "Uwagi",
                FillWeight = 150
            });
        }

        private void ZaladujBadania()
        {
            try
            {
                var zapytanie = db.BadanieMedyczne
                    .Include(b => b.IdPracownikNavigation)
                        .ThenInclude(p => p.IdOsobaNavigation)
                    .Include(b => b.IdTypBadaniaMedNavigation)
                    .AsQueryable();

                if (comboBox_filtrPracownik.SelectedValue != null)
                {
                    int idPracownik = Convert.ToInt32(comboBox_filtrPracownik.SelectedValue);

                    if (idPracownik > 0)
                    {
                        zapytanie = zapytanie.Where(b => b.IdPracownik == idPracownik);
                    }
                }

                if (checkBox_tylkoNiewazne.Checked)
                {
                    DateOnly dzis = DateOnly.FromDateTime(DateTime.Today);
                    zapytanie = zapytanie.Where(b => b.DataWaznosci != null && b.DataWaznosci < dzis);
                }

                var daneZBazy = zapytanie
                    .OrderBy(b => b.IdPracownikNavigation.IdOsobaNavigation.Nazwisko)
                    .ThenBy(b => b.IdPracownikNavigation.IdOsobaNavigation.Imie)
                    .ThenByDescending(b => b.DataBadania)
                    .ToList();

                var lista = daneZBazy
                    .Select(b => new
                    {
                        Pracownik = b.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                                    b.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                        TypBadania = b.IdTypBadaniaMedNavigation.Nazwa,
                        DataBadania = b.DataBadania.ToString("dd.MM.yyyy"),
                        DataWaznosci = b.DataWaznosci.HasValue
                            ? b.DataWaznosci.Value.ToString("dd.MM.yyyy")
                            : "Bezterminowe",
                        Koszt = b.Koszt.ToString("0.00"),
                        Uwagi = string.IsNullOrWhiteSpace(b.Uwagi) ? "-" : b.Uwagi
                    })
                    .ToList();

                dataGridView_badania.DataSource = null;
                dataGridView_badania.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania badań:\n" + ex.Message,
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

        private void UstawDaneComboBoxPracownikowDoFiltra(List<PracownikComboBoxItem> pracownicy, bool ustawWszystkich = true, string tekst = "")
        {
            ladowanieFiltrow = true;

            var listaDoFiltra = new List<object>();

            if (ustawWszystkich)
            {
                listaDoFiltra.Add(new { IdPracownik = 0, DanePracownika = "Wszyscy pracownicy" });
            }

            if (pracownicy.Count == 0)
            {
                listaDoFiltra.Add(new { IdPracownik = -1, DanePracownika = "Brak wyników" });
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

            if (ustawWszystkich && comboBox_filtrPracownik.Items.Count > 0)
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
            UstawDaneComboBoxPracownikowDoFiltra(listaPracownikow, true);
        }

        private void ZaladujTypyBadanDoComboBox()
        {
            try
            {
                var typyBadan = db.TypBadaniaMed
                    .Select(t => new
                    {
                        IdTypBadaniaMed = t.IdTypBadaniaMed,
                        Nazwa = t.Nazwa
                    })
                    .ToList();

                comboBox_typBadania.DataSource = typyBadan;
                comboBox_typBadania.DisplayMember = "Nazwa";
                comboBox_typBadania.ValueMember = "IdTypBadaniaMed";
                comboBox_typBadania.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania typów badań:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UstawDomyslneDane()
        {
            dateTimePicker_dataBadania.Value = DateTime.Today;
            dateTimePicker_dataWaznosci.Value = DateTime.Today;
            textBox_koszt.Text = "";
            textBox_uwagi.Text = "";
        }

        private void WyczyscPanelDodawania()
        {
            comboBox_pracownik.SelectedIndex = -1;
            comboBox_pracownik.Text = "";
            comboBox_typBadania.SelectedIndex = -1;
            UstawDomyslneDane();
        }

        private void button_odswiez_Click(object sender, EventArgs e)
        {
            ZaladujBadania();
        }

        private void button_noweBadanie_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible)
            {
                WyczyscPanelDodawania();
                ZaladujPracownikowDoComboBox();
                ZaladujTypyBadanDoComboBox();
            }
        }

        private void button_dodajBadanie_Click(object sender, EventArgs e)
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

            if (comboBox_typBadania.SelectedValue == null)
            {
                MessageBox.Show(
                    "Wybierz typ badania.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(
                    textBox_koszt.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal koszt)
                &&
                !decimal.TryParse(
                    textBox_koszt.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.GetCultureInfo("pl-PL"),
                    out koszt))
            {
                MessageBox.Show(
                    "Podaj poprawny koszt badania.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (koszt < 0)
            {
                MessageBox.Show(
                    "Koszt badania nie może być ujemny.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePicker_dataWaznosci.Value.Date < dateTimePicker_dataBadania.Value.Date)
            {
                MessageBox.Show(
                    "Data ważności nie może być wcześniejsza niż data badania.",
                    "Błędne daty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idPracownik = Convert.ToInt32(comboBox_pracownik.SelectedValue);
                int idTypBadania = Convert.ToInt32(comboBox_typBadania.SelectedValue);
                DateOnly dataBadania = DateOnly.FromDateTime(dateTimePicker_dataBadania.Value.Date);
                DateOnly? dataWaznosci = DateOnly.FromDateTime(dateTimePicker_dataWaznosci.Value.Date);
                string uwagi = textBox_uwagi.Text.Trim();

                BadanieMedyczne noweBadanie = new BadanieMedyczne
                {
                    IdPracownik = idPracownik,
                    IdTypBadaniaMed = idTypBadania,
                    DataBadania = dataBadania,
                    DataWaznosci = dataWaznosci,
                    Koszt = koszt,
                    Uwagi = string.IsNullOrWhiteSpace(uwagi) ? null : uwagi
                };

                db.BadanieMedyczne.Add(noweBadanie);
                db.SaveChanges();

                MessageBox.Show(
                    "Badanie zostało dodane.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscPanelDodawania();
                panel1.Visible = false;
                ZaladujBadania();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas dodawania badania:\n" + ex.Message,
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

            ZaladujBadania();
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
                UstawDaneComboBoxPracownikowDoFiltra(listaPracownikow, true);
                ZaladujBadania();
                return;
            }

            var przefiltrowanaLista = listaPracownikow
                .Where(p =>
                    p.Imie.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.Nazwisko.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    p.DanePracownika.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase))
                .ToList();

            UstawDaneComboBoxPracownikowDoFiltra(przefiltrowanaLista, false, wpisanyTekst);

            if (przefiltrowanaLista.Count > 0)
            {
                comboBox_filtrPracownik.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void checkBox_tylkoNiewazne_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujBadania();
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
                UstawDaneComboBoxPracownikowDoDodawania(listaPracownikow);
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
    }
}
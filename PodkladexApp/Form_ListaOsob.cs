using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PodkladexApp.Models;

namespace PodkladexApp
{
    public partial class Form_ListaOsob : Form
    {
        private PodkladexContext db;

        public Form_ListaOsob()
        {
            InitializeComponent();

            db = new PodkladexContext();

            ZaladujOsobyDoComboBox();
        }

        private void ZaladujOsobyDoComboBox()
        {
            try
            {
                var osoby = db.Osoba
                    .ToList()
                    .Select(o => new
                    {
                        IdOsoba = o.IdOsoba,
                        PelnaNazwa = o.Imie + " " + o.Nazwisko
                    })
                    .ToList();

                comboBox_idosoby.DataSource = osoby;
                comboBox_idosoby.DisplayMember = "PelnaNazwa";
                comboBox_idosoby.ValueMember = "IdOsoba";
                comboBox_idosoby.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania osób z bazy:\n" + ex.Message);
            }
        }

        private void ZaladujDaneOsobyDoPol(int idOsoby)
        {
            try
            {
                var osoba = db.Osoba.FirstOrDefault(o => o.IdOsoba == idOsoby);

                if (osoba == null)
                {
                    MessageBox.Show("Nie znaleziono osoby.");
                    return;
                }

                panel_daneosoby.Visible = true;

                textBox_imie.Text = osoba.Imie;
                textBox_nazwisko.Text = osoba.Nazwisko;
                textBox_numertelefonu.Text = osoba.NrTelefonu;
                textBox_email.Text = osoba.AdresEMail;
                textBox_miejscowosc.Text = osoba.Miejscowosc;
                textBox_kodpocztowy.Text = osoba.KodPocztowy;
                textBox_ulica.Text = osoba.Ulica;
                textBox_numer.Text = osoba.Numer;
                textBox_pesel.Text = osoba.Pesel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania danych osoby:\n" + ex.Message);
            }
        }

        private void comboBox_idosoby_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBox_idosoby.SelectedIndex == -1 || comboBox_idosoby.SelectedValue == null)
                return;

            try
            {
                int idOsoby = (int)comboBox_idosoby.SelectedValue;
                ZaladujDaneOsobyDoPol(idOsoby);
            }
            catch
            {
                // zabezpieczenie na moment bindowania DataSource
            }
        }

        private void btn_edytowanie_Click(object? sender, EventArgs e)
        {
            if (comboBox_idosoby.SelectedIndex == -1 || comboBox_idosoby.SelectedValue == null)
            {
                MessageBox.Show("Wybierz osobę z listy.");
                return;
            }

            DialogResult wynik = MessageBox.Show(
                "Czy na pewno chcesz zapisać zmiany danych tej osoby?",
                "Potwierdzenie edycji",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (wynik == DialogResult.No)
            {
                return;
            }

            try
            {
                int idOsoby = (int)comboBox_idosoby.SelectedValue;

                var osoba = db.Osoba.FirstOrDefault(o => o.IdOsoba == idOsoby);

                if (osoba == null)
                {
                    MessageBox.Show("Nie znaleziono osoby w bazie.");
                    return;
                }

                osoba.Imie = textBox_imie.Text.Trim();
                osoba.Nazwisko = textBox_nazwisko.Text.Trim();
                osoba.NrTelefonu = textBox_numertelefonu.Text.Trim();
                osoba.AdresEMail = textBox_email.Text.Trim();
                osoba.Miejscowosc = textBox_miejscowosc.Text.Trim();
                osoba.KodPocztowy = textBox_kodpocztowy.Text.Trim();
                osoba.Ulica = textBox_ulica.Text.Trim();
                osoba.Numer = textBox_numer.Text.Trim();
                osoba.Pesel = textBox_pesel.Text.Trim();

                db.SaveChanges();

                MessageBox.Show("Dane zostały zaktualizowane.");

                ZaladujOsobyDoComboBox();
                comboBox_idosoby.SelectedValue = idOsoby;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas edycji danych:\n" + ex.Message);
            }
        }
        private void btn_usuwanie_Click(object? sender, EventArgs e)
        {
            if (comboBox_idosoby.SelectedIndex == -1 || comboBox_idosoby.SelectedValue == null)
            {
                MessageBox.Show(
                    "Wybierz osobę, którą chcesz usunąć.",
                    "Brak wyboru",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult wynik = MessageBox.Show(
                "Czy na pewno chcesz usunąć wybraną osobę?",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (wynik == DialogResult.No)
            {
                return;
            }

            try
            {
                int idOsoby = (int)comboBox_idosoby.SelectedValue;

                var osoba = db.Osoba.FirstOrDefault(o => o.IdOsoba == idOsoby);

                if (osoba == null)
                {
                    MessageBox.Show(
                        "Nie znaleziono osoby w bazie.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                db.Osoba.Remove(osoba);
                db.SaveChanges();

                MessageBox.Show(
                    "Osoba została usunięta.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscPola();
                panel_daneosoby.Visible = false;
                ZaladujOsobyDoComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nie można usunąć tej osoby.\nMoże być powiązana z innymi rekordami w bazie.\n\n" + ex.Message,
                    "Błąd usuwania",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void WyczyscPola()
        {
            textBox_imie.Text = "";
            textBox_nazwisko.Text = "";
            textBox_numertelefonu.Text = "";
            textBox_email.Text = "";
            textBox_miejscowosc.Text = "";
            textBox_kodpocztowy.Text = "";
            textBox_ulica.Text = "";
            textBox_numer.Text = "";
            textBox_pesel.Text = "";
        }

        private void textBox_numertelefonu_TextChanged(object sender, EventArgs e)
        {
            string numer = textBox_numertelefonu.Text;

            if (string.IsNullOrEmpty(numer))
                return;

            if (!numer.All(char.IsDigit))
            {
                textBox_numertelefonu.Text = new string(numer.Where(char.IsDigit).ToArray());
                textBox_numertelefonu.SelectionStart = textBox_numertelefonu.Text.Length;
            }
        }

        private void button_ArrowL_Click(object sender, EventArgs e)
        {
            if (comboBox_idosoby.Items.Count == 0)
                return;

            if (comboBox_idosoby.SelectedIndex > 0)
            {
                comboBox_idosoby.SelectedIndex--;
            }
            else
            {
                MessageBox.Show("To jest pierwszy rekord.");
            }
        }

        private void button_ArrowR_Click(object sender, EventArgs e)
        {
            if (comboBox_idosoby.Items.Count == 0)
                return;

            if (comboBox_idosoby.SelectedIndex < comboBox_idosoby.Items.Count - 1)
            {
                comboBox_idosoby.SelectedIndex++;
            }
            else
            {
                MessageBox.Show("To jest ostatni rekord.");
            }
        }

        private void btn_dodawanie_Click(object? sender, EventArgs e)
        {
            if (!CzyWszystkiePolaUzupelnione())
            {
                MessageBox.Show(
                    "Nie wszystkie pola zostały uzupełnione.\nWypełnij wszystkie dane przed dodaniem osoby.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string imie = textBox_imie.Text.Trim();
            string nazwisko = textBox_nazwisko.Text.Trim();
            string nrTelefonu = textBox_numertelefonu.Text.Trim();
            string email = textBox_email.Text.Trim();
            string miejscowosc = textBox_miejscowosc.Text.Trim();
            string kodPocztowy = textBox_kodpocztowy.Text.Trim();
            string ulica = textBox_ulica.Text.Trim();
            string numer = textBox_numer.Text.Trim();
            string pesel = textBox_pesel.Text.Trim();

            try
            {
                bool czyIstniejePesel = db.Osoba.Any(o => o.Pesel == pesel);

                if (czyIstniejePesel)
                {
                    MessageBox.Show(
                        "Osoba o podanym numerze PESEL już istnieje w bazie.",
                        "Duplikat PESEL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult wynik = MessageBox.Show(
                    "Czy na pewno chcesz dodać nową osobę?",
                    "Potwierdzenie dodania",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (wynik == DialogResult.No)
                {
                    return;
                }

                Osoba nowaOsoba = new Osoba
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    NrTelefonu = nrTelefonu,
                    AdresEMail = email,
                    Miejscowosc = miejscowosc,
                    KodPocztowy = kodPocztowy,
                    Ulica = ulica,
                    Numer = numer,
                    Pesel = pesel
                };

                db.Osoba.Add(nowaOsoba);
                db.SaveChanges();

                MessageBox.Show(
                    "Nowa osoba została dodana poprawnie.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ZaladujOsobyDoComboBox();
                WyczyscPola();
                comboBox_idosoby.SelectedIndex = -1;
                panel_daneosoby.Visible = false;
            }
            catch (Exception ex)
            {
                string blad = ex.Message;

                if (ex.InnerException != null)
                {
                    blad += "\n\nSzczegóły:\n" + ex.InnerException.Message;
                }

                MessageBox.Show(
                    "Wystąpił błąd podczas dodawania osoby:\n" + blad,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private bool CzyWszystkiePolaUzupelnione()
        {
            return !string.IsNullOrWhiteSpace(textBox_imie.Text)
                && !string.IsNullOrWhiteSpace(textBox_nazwisko.Text)
                && !string.IsNullOrWhiteSpace(textBox_numertelefonu.Text)
                && !string.IsNullOrWhiteSpace(textBox_email.Text)
                && !string.IsNullOrWhiteSpace(textBox_miejscowosc.Text)
                && !string.IsNullOrWhiteSpace(textBox_kodpocztowy.Text)
                && !string.IsNullOrWhiteSpace(textBox_ulica.Text)
                && !string.IsNullOrWhiteSpace(textBox_numer.Text)
                && !string.IsNullOrWhiteSpace(textBox_pesel.Text);
        }

        private void btn_wyczysc_Click(object sender, EventArgs e)
        {
            WyczyscPola();
            comboBox_idosoby.SelectedIndex = -1;
        }
    }
}

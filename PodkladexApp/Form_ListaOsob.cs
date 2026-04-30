using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PodkladexApp
{
    public partial class Form_ListaOsob : Form
    {
        private PodkladexContext db;
        private List<OsobaComboBoxItem> listaOsob;
        private bool ladowanieComboBox = false;

        private class OsobaComboBoxItem
        {
            public int IdOsoba { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string PelnaNazwa { get; set; }
        }

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
                listaOsob = db.Osoba
                    .ToList()
                    .Select(o => new OsobaComboBoxItem
                    {
                        IdOsoba = o.IdOsoba,
                        Imie = o.Imie,
                        Nazwisko = o.Nazwisko,
                        PelnaNazwa = o.Imie + " " + o.Nazwisko
                    })
                    .ToList();

                UstawDaneComboBox(listaOsob, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania osób z bazy:\n" + ex.Message);
            }
        }

        private List<OsobaComboBoxItem> PrzygotujListeBezPustejKolekcji(List<OsobaComboBoxItem> osoby)
        {
            if (osoby.Count > 0)
                return osoby;

            return new List<OsobaComboBoxItem>
            {
                new OsobaComboBoxItem
                {
                    IdOsoba = -1,
                    Imie = "",
                    Nazwisko = "",
                    PelnaNazwa = "Brak wyników"
                }
            };
        }

        private void UstawDaneComboBox(List<OsobaComboBoxItem> osoby, string tekst = "")
        {
            ladowanieComboBox = true;

            var listaDoUstawienia = PrzygotujListeBezPustejKolekcji(osoby);

            comboBox_idosoby.DataSource = null;
            comboBox_idosoby.DisplayMember = "PelnaNazwa";
            comboBox_idosoby.ValueMember = "IdOsoba";
            comboBox_idosoby.DataSource = listaDoUstawienia;
            comboBox_idosoby.SelectedIndex = -1;
            comboBox_idosoby.Text = tekst;
            comboBox_idosoby.SelectionStart = comboBox_idosoby.Text.Length;
            comboBox_idosoby.SelectionLength = 0;

            ladowanieComboBox = false;
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
            if (ladowanieComboBox)
                return;

            if (comboBox_idosoby.SelectedIndex == -1 || comboBox_idosoby.SelectedValue == null)
                return;

            try
            {
                int idOsoby = Convert.ToInt32(comboBox_idosoby.SelectedValue);

                if (idOsoby == -1)
                    return;

                ZaladujDaneOsobyDoPol(idOsoby);
            }
            catch
            {
            }
        }

        private void comboBox_idosoby_TextUpdate(object sender, EventArgs e)
        {
            if (ladowanieComboBox)
                return;

            string wpisanyTekst = comboBox_idosoby.Text;

            BeginInvoke(new Action(() =>
            {
                FiltrujComboBoxOsob(wpisanyTekst);
            }));
        }

        private void FiltrujComboBoxOsob(string wpisanyTekst)
        {
            if (ladowanieComboBox)
                return;

            wpisanyTekst = wpisanyTekst?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(wpisanyTekst))
            {
                UstawDaneComboBox(listaOsob, "");
                return;
            }

            var przefiltrowanaLista = listaOsob
                .Where(o =>
                    o.Imie.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    o.Nazwisko.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase) ||
                    o.PelnaNazwa.Contains(wpisanyTekst, StringComparison.OrdinalIgnoreCase))
                .ToList();

            UstawDaneComboBox(przefiltrowanaLista, wpisanyTekst);

            if (przefiltrowanaLista.Count > 0)
            {
                comboBox_idosoby.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void comboBox_idosoby_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_idosoby.Text))
            {
                UstawDaneComboBox(listaOsob, "");
            }
        }

        private void btn_edytowanie_Click(object? sender, EventArgs e)
        {
            if (comboBox_idosoby.SelectedIndex == -1 || comboBox_idosoby.SelectedValue == null)
            {
                MessageBox.Show("Wybierz osobę z listy.");
                return;
            }

            int idOsoby = Convert.ToInt32(comboBox_idosoby.SelectedValue);
            if (idOsoby <= 0)
            {
                MessageBox.Show("Wybierz poprawną osobę z listy.");
                return;
            }

            if (!CzyWszystkiePolaUzupelnione())
            {
                MessageBox.Show(
                    "Nie wszystkie pola zostały uzupełnione.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!CzyDaneOsobySaPoprawne())
                return;

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

            int idOsoby = Convert.ToInt32(comboBox_idosoby.SelectedValue);
            if (idOsoby <= 0)
            {
                MessageBox.Show(
                    "Wybierz poprawną osobę z listy.",
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
                comboBox_idosoby.Text = "";
                comboBox_idosoby.SelectedIndex = -1;
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

        private void textBox_imie_TextChanged(object sender, EventArgs e)
        {
            OdfiltrujTylkoLitery(textBox_imie);
        }

        private void textBox_nazwisko_TextChanged(object sender, EventArgs e)
        {
            OdfiltrujTylkoLitery(textBox_nazwisko);
        }

        private void textBox_miejscowosc_TextChanged(object sender, EventArgs e)
        {
            OdfiltrujTylkoLitery(textBox_miejscowosc);
        }

        private void textBox_numertelefonu_TextChanged(object sender, EventArgs e)
        {
            OdfiltrujTylkoCyfry(textBox_numertelefonu, 15);
        }

        private void textBox_pesel_TextChanged(object sender, EventArgs e)
        {
            OdfiltrujTylkoCyfry(textBox_pesel, 11);
        }

        private void textBox_kodpocztowy_TextChanged(object sender, EventArgs e)
        {
            string tekst = textBox_kodpocztowy.Text;
            int pozycja = textBox_kodpocztowy.SelectionStart;

            string przefiltrowany = new string(tekst.Where(c => char.IsDigit(c) || c == '-').ToArray());

            if (przefiltrowany.Length > 6)
                przefiltrowany = przefiltrowany.Substring(0, 6);

            if (tekst != przefiltrowany)
            {
                textBox_kodpocztowy.Text = przefiltrowany;
                textBox_kodpocztowy.SelectionStart = Math.Min(pozycja, textBox_kodpocztowy.Text.Length);
            }
        }

        private void textBox_numer_TextChanged(object sender, EventArgs e)
        {
            string tekst = textBox_numer.Text;
            int pozycja = textBox_numer.SelectionStart;

            string przefiltrowany = new string(tekst.Where(c => char.IsLetterOrDigit(c) || c == '/' || c == '-').ToArray());

            if (tekst != przefiltrowany)
            {
                textBox_numer.Text = przefiltrowany;
                textBox_numer.SelectionStart = Math.Min(pozycja, textBox_numer.Text.Length);
            }
        }

        private void OdfiltrujTylkoLitery(TextBox textBox)
        {
            string tekst = textBox.Text;
            int pozycja = textBox.SelectionStart;

            string przefiltrowany = new string(tekst.Where(c => char.IsLetter(c) || c == ' ' || c == '-').ToArray());

            if (tekst != przefiltrowany)
            {
                textBox.Text = przefiltrowany;
                textBox.SelectionStart = Math.Min(pozycja, textBox.Text.Length);
            }
        }

        private void OdfiltrujTylkoCyfry(TextBox textBox, int maxDlugosc)
        {
            string tekst = textBox.Text;
            int pozycja = textBox.SelectionStart;

            string przefiltrowany = new string(tekst.Where(char.IsDigit).ToArray());

            if (przefiltrowany.Length > maxDlugosc)
                przefiltrowany = przefiltrowany.Substring(0, maxDlugosc);

            if (tekst != przefiltrowany)
            {
                textBox.Text = przefiltrowany;
                textBox.SelectionStart = Math.Min(pozycja, textBox.Text.Length);
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

            if (!CzyDaneOsobySaPoprawne())
                return;

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
                    "Czy na pewno chcesz dodać nową osobę i od razu przypisać ją jako pracownika?",
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

                Pracownik nowyPracownik = new Pracownik
                {
                    IdOsoba = nowaOsoba.IdOsoba
                };

                db.Pracownik.Add(nowyPracownik);
                db.SaveChanges();

                MessageBox.Show(
                    "Nowa osoba została dodana poprawnie i przypisana jako pracownik.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ZaladujOsobyDoComboBox();
                WyczyscPola();
                comboBox_idosoby.Text = "";
                comboBox_idosoby.SelectedIndex = -1;
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

        private bool CzyDaneOsobySaPoprawne()
        {
            if (textBox_pesel.Text.Length != 11)
            {
                MessageBox.Show(
                    "PESEL musi składać się dokładnie z 11 cyfr.",
                    "Błędny PESEL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!textBox_pesel.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                    "PESEL może zawierać wyłącznie cyfry.",
                    "Błędny PESEL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!textBox_numertelefonu.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Numer telefonu może zawierać wyłącznie cyfry.",
                    "Błędny numer telefonu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (textBox_numertelefonu.Text.Length < 9)
            {
                MessageBox.Show(
                    "Numer telefonu powinien zawierać co najmniej 9 cyfr.",
                    "Błędny numer telefonu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (textBox_kodpocztowy.Text.Length != 6 || textBox_kodpocztowy.Text[2] != '-')
            {
                MessageBox.Show(
                    "Kod pocztowy musi mieć format XX-XXX.",
                    "Błędny kod pocztowy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!textBox_email.Text.Contains("@") || !textBox_email.Text.Contains("."))
            {
                MessageBox.Show(
                    "Podaj poprawny adres e-mail.",
                    "Błędny e-mail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btn_wyczysc_Click(object sender, EventArgs e)
        {
            comboBox_idosoby.Text = "";
            comboBox_idosoby.SelectedIndex = -1;
            UstawDaneComboBox(listaOsob, "");
            WyczyscPola();
        }
    }
}
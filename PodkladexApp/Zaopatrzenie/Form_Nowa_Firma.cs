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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PodkladexApp
{
    public partial class Form_Nowa_Firma : Form

    {
        // Flaga pamiętająca tryb pracy
        private bool czyTrybEdycji = false;

        private void UstawWidokPoczatkowy()
        {
            // Ukrywamy panel z textboxami i przyciskiem "Zaakceptuj"
            panel_dane_firmy.Visible = false;

            // Ukrywamy comboboxa do wyboru firmy i jego labela
            comboBox_Nazwa_firmy.Visible = false;
            label_ProszeWybracFirme.Visible = false;

            // Czyszczenie zawartości
            textBox_NazwaFirmy.Clear();
            textBox_NIP_firmy.Clear();
            textBox_Miejscowosc_firmy.Clear();
            textBox_Kod_pocztowy_firmy.Clear();
            textBox_Ulica_firmy.Clear();
            textBox_Numer_firmy.Clear();
        }



        // 1. Inicjalizacja połączenia z bazą danych (Entity Framework Core)
        private PodkladexContext _db = new PodkladexContext();

        private void ResetujWidok()
        {


            // 2. Resetowanie widoczności standardowych elementów
            panel_dane_firmy.Visible = false;
            comboBox_Nazwa_firmy.Visible = false;
            label_ProszeWybracFirme.Visible = false;
            comboBox_Nazwa_firmy.DataSource = null;
            comboBox_Nazwa_firmy.SelectedIndex = -1;

            // 3. Czyszczenie pól tekstowych
            textBox_NazwaFirmy.Clear();
            textBox_Miejscowosc_firmy.Clear();
            textBox_Kod_pocztowy_firmy.Clear();
            textBox_Ulica_firmy.Clear();
            textBox_Numer_firmy.Clear();
            textBox_NIP_firmy.Clear();
        }



        public Form_Nowa_Firma()
        {
            InitializeComponent();
            // 1. Pobieramy firmy z bazy
            ResetujWidok();
            var listaFirm = _db.Firma.ToList();

            // 2. Podpinamy dane
            comboBox_Nazwa_firmy.DataSource = listaFirm;
            comboBox_Nazwa_firmy.DisplayMember = "Nazwa";    // Wyświetla nazwę
            comboBox_Nazwa_firmy.ValueMember = "IdFirma";    // Trzyma ID w tle

            // 3. KLUCZOWA ZMIANA: Czyścimy domyślne zaznaczenie
            // Musi to nastąpić PO przypisaniu DataSource
            comboBox_Nazwa_firmy.SelectedIndex = -1;

            // 4. Odkrywamy ComboBox, ukrywamy panel do czasu wyboru
            comboBox_Nazwa_firmy.Visible = true;
            label_ProszeWybracFirme.Visible = true;
            panel_dane_firmy.Visible = false;
        }


        private void textBox_Miejscowosc_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Kod_pocztowy_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Ulica_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Numer_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_NIP_firmy_TextChanged(object sender, EventArgs e)
        {

        }


        private void label_ulica_Click(object sender, EventArgs e)
        {

        }

        private void Nowa_Firma_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_NIP_Click(object sender, EventArgs e)
        {

        }

        private void textBox_NazwaFirmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Dodaj_nowa_firme_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Kod_pocztowy_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_Miejscowosc_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_NazwaFirmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_NIP_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_Ulica_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_Numer_firmy.Text))

            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!",
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
        }

        private void button_Wyczysc_Click(object sender, EventArgs e)
        {
            // Czyścimy wszystkie pola tekstowe za pomocą wbudowanej metody Clear()
            textBox_Kod_pocztowy_firmy.Clear();
            textBox_Miejscowosc_firmy.Clear();
            textBox_NazwaFirmy.Clear();
            textBox_NIP_firmy.Clear();
            textBox_Ulica_firmy.Clear();
            textBox_Numer_firmy.Clear();

            // Jeśli masz jakieś pole liczbowe (NumericUpDown), np. gdybyś dodawał kapitał itp.:
            // numericUpDown_JakiesPole.Value = numericUpDown_JakiesPole.Minimum;


        }

        private void label_ProszeWybracFirme_Click(object sender, EventArgs e)
        {

        }

        private void Label_Nazwa_firmy_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_NazwaFirmy_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_Miejscowosc_firmy_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_Kod_pocztowy_firmy_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_Ulica_firmy_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_Numer_firmy_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_NIP_firmy_TextChanged_1(object sender, EventArgs e)
        {

        }




        private void comboBox_Nazwa_firmy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Upewniamy się, że cokolwiek wybrano
            if (comboBox_Nazwa_firmy.SelectedItem != null && comboBox_Nazwa_firmy.SelectedItem is Firma wybranaFirma)
            {
                // Wypełniamy TextBoxy z panelu
                textBox_NazwaFirmy.Text = wybranaFirma.Nazwa;
                textBox_Miejscowosc_firmy.Text = wybranaFirma.Miejscowosc;
                textBox_Kod_pocztowy_firmy.Text = wybranaFirma.KodPocztowy;
                textBox_Ulica_firmy.Text = wybranaFirma.Ulica;
                textBox_Numer_firmy.Text = wybranaFirma.Numer;
                textBox_NIP_firmy.Text = wybranaFirma.Nip;

                // Pokazujemy od razu cały Twój Panel z uzupełnionymi polami
                panel_dane_firmy.Visible = true;

                // POKAZUJEMY PRZYCISK USUWANIA (bo jesteśmy w trybie edycji)
                //button_usun_firme.Visible = true;
            }
        }

        private void panel_dane_firmy_Paint(object sender, PaintEventArgs e)
        {

        }

        /*private void button_usun_firme_Click(object sender, EventArgs e)
        {
            // Sprawdzamy, czy w ogóle edytujemy istniejącą firmę (czy coś jest wybrane w ComboBox)
            if (comboBox_Nazwa_firmy.SelectedItem != null && comboBox_Nazwa_firmy.SelectedItem is Firma wybranaFirma)
            {
                // 1. ZABEZPIECZENIE: Sprawdzenie powiązań w bazie danych
                bool czyMaKlientow = _db.KlientFirma.Any(k => k.IdFirma == wybranaFirma.IdFirma);
                bool czyMaDostawy = _db.Dostawa.Any(d => d.IdFirma == wybranaFirma.IdFirma);
                bool czyMaGwarancje = _db.Gwarancja.Any(g => g.IdFirma == wybranaFirma.IdFirma);

                if (czyMaKlientow || czyMaDostawy || czyMaGwarancje)
                {
                    MessageBox.Show("Nie można usunąć tej firmy, ponieważ jest ona używana w systemie!\n\n" +
                                    "Firma jest przypisana do:\n" +
                                    (czyMaKlientow ? "- Modułu Klient-Firma\n" : "") +
                                    (czyMaDostawy ? "- Modułu Dostaw\n" : "") +
                                    (czyMaGwarancje ? "- Modułu Gwarancji\n" : ""),
                                    "Błąd usuwania",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // 2. Jeśli firma nie ma powiązań, wyświetlamy okienko z pytaniem
                DialogResult wynik = MessageBox.Show($"Czy na pewno chcesz usunąć firmę: {wybranaFirma.Nazwa}?",
                                                     "Potwierdzenie usunięcia",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                // 3. Jeśli użytkownik kliknie "Tak"
                if (wynik == DialogResult.Yes)
                {
                    var firmaDoUsuniecia = _db.Firma.Find(wybranaFirma.IdFirma);

                    if (firmaDoUsuniecia != null)
                    {
                        try
                        {
                            _db.Firma.Remove(firmaDoUsuniecia);
                            _db.SaveChanges();

                            MessageBox.Show("Firma została pomyślnie usunięta!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // POWRÓT DO DOMYŚLNEGO WIDOKU PO USUNIĘCIU
                            ResetujWidok();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wystąpił błąd podczas usuwania z bazy:\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz najpierw firmę z listy.");
            }
        }
        */

        private void button_zaakceptuj_zmiany_Click(object sender, EventArgs e)
        {
            // Opcjonalne zabezpieczenie: Wymagamy minimum nazwy i NIP
            if (string.IsNullOrWhiteSpace(textBox_NazwaFirmy.Text) || string.IsNullOrWhiteSpace(textBox_NIP_firmy.Text))
            {
                MessageBox.Show("Nazwa firmy i NIP są polami obowiązkowymi!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Warunek: jeśli NIC nie wybrano z ComboBoxa - to znaczy, że DODAJEMY nową firmę
            if (comboBox_Nazwa_firmy.SelectedIndex == -1)
            {
                Firma nowaFirma = new Firma()
                {
                    Nazwa = textBox_NazwaFirmy.Text,
                    Miejscowosc = textBox_Miejscowosc_firmy.Text,
                    KodPocztowy = textBox_Kod_pocztowy_firmy.Text,
                    Ulica = textBox_Ulica_firmy.Text,
                    Numer = textBox_Numer_firmy.Text,
                    Nip = textBox_NIP_firmy.Text
                };

                _db.Firma.Add(nowaFirma);
                MessageBox.Show("Dodano nową firmę!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Warunek: jeśli COŚ wybrano z ComboBoxa - to znaczy, że EDYTUJEMY istniejącą
            else if (comboBox_Nazwa_firmy.SelectedItem is Firma wybranaFirma)
            {
                var firmaDoEdycji = _db.Firma.Find(wybranaFirma.IdFirma);

                if (firmaDoEdycji != null)
                {
                    firmaDoEdycji.Nazwa = textBox_NazwaFirmy.Text;
                    firmaDoEdycji.Miejscowosc = textBox_Miejscowosc_firmy.Text;
                    firmaDoEdycji.KodPocztowy = textBox_Kod_pocztowy_firmy.Text;
                    firmaDoEdycji.Ulica = textBox_Ulica_firmy.Text;
                    firmaDoEdycji.Numer = textBox_Numer_firmy.Text;
                    firmaDoEdycji.Nip = textBox_NIP_firmy.Text;

                    MessageBox.Show("Zaktualizowano dane firmy!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Wykonanie zmian w bazie Entity Framework
            _db.SaveChanges();

            // POWRÓT DO DOMYŚLNEGO WIDOKU PO ZAPISIE LUB EDYCJI
            ResetujWidok();
        }

        private void button_usun_firme_Click_1(object sender, EventArgs e)
        {

        }
        /*
        private void button_usun_firme_Click_2(object sender, EventArgs e)
        {
            // Sprawdzamy, czy w ogóle edytujemy istniejącą firmę (czy coś jest wybrane w ComboBox)
            if (comboBox_Nazwa_firmy.SelectedItem != null && comboBox_Nazwa_firmy.SelectedItem is Firma wybranaFirma)
            {
                // 1. ZABEZPIECZENIE: Sprawdzenie powiązań w bazie danych
                bool czyMaKlientow = _db.KlientFirma.Any(k => k.IdFirma == wybranaFirma.IdFirma);
                bool czyMaDostawy = _db.Dostawa.Any(d => d.IdFirma == wybranaFirma.IdFirma);
                bool czyMaGwarancje = _db.Gwarancja.Any(g => g.IdFirma == wybranaFirma.IdFirma);

                if (czyMaKlientow || czyMaDostawy || czyMaGwarancje)
                {
                    MessageBox.Show("Nie można usunąć tej firmy, ponieważ jest ona używana w systemie!\n\n" +
                                    "Firma jest przypisana do:\n" +
                                    (czyMaKlientow ? "- Modułu Klient-Firma\n" : "") +
                                    (czyMaDostawy ? "- Modułu Dostaw\n" : "") +
                                    (czyMaGwarancje ? "- Modułu Gwarancji\n" : ""),
                                    "Błąd usuwania",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // 2. Jeśli firma nie ma powiązań, wyświetlamy okienko z pytaniem
                DialogResult wynik = MessageBox.Show($"Czy na pewno chcesz usunąć firmę: {wybranaFirma.Nazwa}?",
                                                     "Potwierdzenie usunięcia",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                // 3. Jeśli użytkownik kliknie "Tak"
                if (wynik == DialogResult.Yes)
                {
                    var firmaDoUsuniecia = _db.Firma.Find(wybranaFirma.IdFirma);

                    if (firmaDoUsuniecia != null)
                    {
                        try
                        {
                            _db.Firma.Remove(firmaDoUsuniecia);
                            _db.SaveChanges();

                            MessageBox.Show("Firma została pomyślnie usunięta!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // POWRÓT DO DOMYŚLNEGO WIDOKU PO USUNIĘCIU
                            ResetujWidok();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wystąpił błąd podczas usuwania z bazy:\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz najpierw firmę z listy.");
            }
        }
        */

        private void button_zaakceptuj_zmiany_Click_1(object sender, EventArgs e)
        {
            // Opcjonalne zabezpieczenie: Wymagamy minimum nazwy i NIP
            if (string.IsNullOrWhiteSpace(textBox_NazwaFirmy.Text) || string.IsNullOrWhiteSpace(textBox_NIP_firmy.Text))
            {
                MessageBox.Show("Nazwa firmy i NIP są polami obowiązkowymi!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Warunek: jeśli NIC nie wybrano z ComboBoxa - to znaczy, że DODAJEMY nową firmę
            if (comboBox_Nazwa_firmy.SelectedIndex == -1)
            {
                Firma nowaFirma = new Firma()
                {
                    Nazwa = textBox_NazwaFirmy.Text,
                    Miejscowosc = textBox_Miejscowosc_firmy.Text,
                    KodPocztowy = textBox_Kod_pocztowy_firmy.Text,
                    Ulica = textBox_Ulica_firmy.Text,
                    Numer = textBox_Numer_firmy.Text,
                    Nip = textBox_NIP_firmy.Text
                };

                _db.Firma.Add(nowaFirma);
                MessageBox.Show("Dodano nową firmę!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Warunek: jeśli COŚ wybrano z ComboBoxa - to znaczy, że EDYTUJEMY istniejącą
            else if (comboBox_Nazwa_firmy.SelectedItem is Firma wybranaFirma)
            {
                var firmaDoEdycji = _db.Firma.Find(wybranaFirma.IdFirma);

                if (firmaDoEdycji != null)
                {
                    firmaDoEdycji.Nazwa = textBox_NazwaFirmy.Text;
                    firmaDoEdycji.Miejscowosc = textBox_Miejscowosc_firmy.Text;
                    firmaDoEdycji.KodPocztowy = textBox_Kod_pocztowy_firmy.Text;
                    firmaDoEdycji.Ulica = textBox_Ulica_firmy.Text;
                    firmaDoEdycji.Numer = textBox_Numer_firmy.Text;
                    firmaDoEdycji.Nip = textBox_NIP_firmy.Text;

                    MessageBox.Show("Zaktualizowano dane firmy!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Wykonanie zmian w bazie Entity Framework
            _db.SaveChanges();

            // POWRÓT DO DOMYŚLNEGO WIDOKU PO ZAPISIE LUB EDYCJI
            ResetujWidok();
        }

        private void button_Dodaj_firme_Click(object sender, EventArgs e)
        {
            // Ustawiamy tryb na dodawanie
            czyTrybEdycji = false;

            UstawWidokPoczatkowy(); // Ukrywa comboboxa i czyści pola

            // Odkrywamy TYLKO panel z textboxami i przyciskiem zatwierdzenia
            panel_dane_firmy.Visible = true;
        }

        private void button_Edytuj_dane_firmy_Click(object sender, EventArgs e)
        {
            // Ustawiamy tryb na edycję
            czyTrybEdycji = true;

            UstawWidokPoczatkowy(); // Ukrywa panel z textboxami (pojawi się dopiero po wyborze firmy)

            // Odkrywamy TYLKO comboboxa i jego labela
            comboBox_Nazwa_firmy.Visible = true;
            label_ProszeWybracFirme.Visible = true;

            // Pobranie danych z bazy i załadowanie do ComboBoxa
            var listaFirm = _db.Firma.ToList();
            comboBox_Nazwa_firmy.DataSource = listaFirm;
            comboBox_Nazwa_firmy.DisplayMember = "Nazwa";
            comboBox_Nazwa_firmy.ValueMember = "IdFirma";
            comboBox_Nazwa_firmy.SelectedIndex = -1; // Zostawiamy puste na start
        }
    }
}


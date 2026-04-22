using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PodkladexApp.Models; // Wymagane, aby widzieć klasę PodkladexContext i Firma

namespace PodkladexApp
{
    public partial class Form_ZaoLog : Form
    {
        // 1. Inicjalizacja połączenia z bazą danych (Entity Framework Core)
        private PodkladexContext _db = new PodkladexContext();

        public Form_ZaoLog()
        {
            InitializeComponent();

            // Ukrywamy ComboBox przy starcie formularza.
            comboBox_Nazwa_firmy.Visible = false;
        }

        private void button_Nowa_firma_Click_1(object sender, EventArgs e)
        {
            // Ukrywamy listę rozwijaną i usuwamy jej ewentualne zaznaczenie
            comboBox_Nazwa_firmy.SelectedIndex = -1;
            comboBox_Nazwa_firmy.Visible = false;

            // Czyścimy pola TextBox, aby przygotować je na nową firmę
            textBox_NazwaFirmy.Clear();
            textBox_Miejscowosc_firmy.Clear();
            textBox_Kod_pocztowy_firmy.Clear();
            textBox_Ulica_firmy.Clear();
            textBox_Numer_firmy.Clear();
            textBox_NIP_firmy.Clear();

            // Wyświetlamy panel, w którym użytkownik wpisze nowe dane
            panel_dane_firmy.Visible = true;
            // UKRYWAMY PRZYCISK USUWANIA (bo dodajemy nową firmę)
            button_usun_firme.Visible = false;
        }

        // =========================================================================
        // 2. Lista firm
        // =========================================================================
        private void button_Edytuj_firmy_Click(object sender, EventArgs e)
        {
            // Pobieramy firmy z bazy
            var listaFirm = _db.Firma.ToList();

            // Podpinamy je pod ukryty ComboBox
            comboBox_Nazwa_firmy.DataSource = listaFirm;
            comboBox_Nazwa_firmy.DisplayMember = "Nazwa";    // Wyświetla nazwę
            comboBox_Nazwa_firmy.ValueMember = "IdFirma";    // Trzyma ID w tle

            // Odkrywamy ComboBox
            comboBox_Nazwa_firmy.Visible = true;
        }

        // =========================================================================
        // 3. Wybieramy firmę z listy - pojawiają się dane w TextBoxach
        // =========================================================================
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
                button_usun_firme.Visible = true;
            }
        }


        // =========================================================================
        // Puste zdarzenia wygenerowane przez designera
        // =========================================================================
        private void button_konf_mat_Click(object sender, EventArgs e) { }
        private void textBox_NazwaFirmy_TextChanged(object sender, EventArgs e) { }
        private void textBox_Miejscowosc_firmy_TextChanged(object sender, EventArgs e) { }
        private void textBox_Kod_pocztowy_firmy_TextChanged(object sender, EventArgs e) { }
        private void textBox_Ulica_firmy_TextChanged(object sender, EventArgs e) { }
        private void textBox_Numer_firmy_TextChanged(object sender, EventArgs e) { }
        private void textBox_NIP_firmy_TextChanged(object sender, EventArgs e) { }
        private void Label_Nazwa_firmy_Click(object sender, EventArgs e) { }
        private void label_Miejscowosc_Click(object sender, EventArgs e) { }
        private void label_kod_pocztowy_firmy_Click(object sender, EventArgs e) { }
        private void label_ulica_Click(object sender, EventArgs e) { }
        private void label_Numer_Click(object sender, EventArgs e) { }
        private void label_NIP_Click(object sender, EventArgs e) { }

        private void Form_ZaoLog_Load(object sender, EventArgs e)
        {

        }

        private void button_usun_firme_Click(object sender, EventArgs e)
        {
            // Sprawdzamy, czy w ogóle edytujemy istniejącą firmę (czy coś jest wybrane w ComboBox)
            if (comboBox_Nazwa_firmy.SelectedItem != null && comboBox_Nazwa_firmy.SelectedItem is Firma wybranaFirma)
            {
                // 1. Wyświetlamy okienko z pytaniem o potwierdzenie usunięcia
                DialogResult wynik = MessageBox.Show($"Czy na pewno chcesz usunąć firmę: {wybranaFirma.Nazwa}?",
                                                     "Potwierdzenie usunięcia",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                // 2. Jeśli użytkownik kliknie "Tak"
                if (wynik == DialogResult.Yes)
                {
                    // Pobieramy rekord do usunięcia z bazy danych
                    var firmaDoUsuniecia = _db.Firma.Find(wybranaFirma.IdFirma);

                    if (firmaDoUsuniecia != null)
                    {
                        // Usuwamy z kontekstu i zapisujemy zmiany w bazie
                        _db.Firma.Remove(firmaDoUsuniecia);
                        _db.SaveChanges();

                        MessageBox.Show("Firma została usunięta!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ukrywamy panel i resetujemy ComboBox
                        panel_dane_firmy.Visible = false;
                        comboBox_Nazwa_firmy.Visible = false;

                        // Opcjonalnie: usuwamy aktualne dane z ComboBoxa, 
                        // aby usunięta firma zniknęła z listy od razu
                        comboBox_Nazwa_firmy.DataSource = null;
                    }
                }
            }
            else
            {
                // Komunikat na wypadek, gdyby ktoś kliknął przycisk, zanim cokolwiek załadował (choć w Twoim układzie to mało prawdopodobne)
                MessageBox.Show("Wybierz najpierw firmę z listy.");
            }
        }

        private void button_zaakceptuj_zmiany_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Dodano nową firmę!");
            }
            // Warunek: jeśli COŚ wybrano z ComboBoxa - to znaczy, że EDYTUJEMY istniejącą
            else if (comboBox_Nazwa_firmy.SelectedItem is Firma wybranaFirma)
            {
                // Pobieramy rekord do edycji z bazy danych
                var firmaDoEdycji = _db.Firma.Find(wybranaFirma.IdFirma);

                if (firmaDoEdycji != null)
                {
                    // Aktualizujemy właściwości
                    firmaDoEdycji.Nazwa = textBox_NazwaFirmy.Text;
                    firmaDoEdycji.Miejscowosc = textBox_Miejscowosc_firmy.Text;
                    firmaDoEdycji.KodPocztowy = textBox_Kod_pocztowy_firmy.Text;
                    firmaDoEdycji.Ulica = textBox_Ulica_firmy.Text;
                    firmaDoEdycji.Numer = textBox_Numer_firmy.Text;
                    firmaDoEdycji.Nip = textBox_NIP_firmy.Text;

                    MessageBox.Show("Zaktualizowano dane firmy!");
                }
            }

            // Wykonanie zmian w bazie Entity Framework
            _db.SaveChanges();

            // Na koniec warto schować panel i zresetować kontrolki
            panel_dane_firmy.Visible = false;
            comboBox_Nazwa_firmy.Visible = false;
            comboBox_Nazwa_firmy.SelectedIndex = -1;
        }
    }
}
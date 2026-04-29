using PodkladexApp.Models; // Wymagane, aby widzieć klasę PodkladexContext i Firma
using PodkladexApp.Zaopatrzenie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodkladexApp
{
    public partial class Form_ZaoLog : Form
    {
        // 1. Inicjalizacja połączenia z bazą danych (Entity Framework Core)
        private PodkladexContext _db = new PodkladexContext();
        Form activeForm = null;

        public Form_ZaoLog()
        {
            InitializeComponent();

            // Wymuszamy domyślny, "czysty" widok przy starcie formularza
            ResetujWidok();
        }

        // --- NOWA METODA: Powrót do widoku domyślnego ---
        private void ResetujWidok()
        {
            // 1. ZAMYKANIE PODFORMULARZA (np. Form_Zamowienie)
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

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

        private void button_Nowa_firma_Click_1(object sender, EventArgs e)
        {
            // Najpierw czyścimy cały formularz do stanu domyślnego
            ResetujWidok();

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
                label_ProszeWybracFirme.Visible = false;
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
        private void Form_ZaoLog_Load(object sender, EventArgs e) { }

        private void button_usun_firme_Click(object sender, EventArgs e)
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

        private void btn_Dostawa_Click(object sender, EventArgs e)
        {
            Form_Dostawa form_Dostawa = new Form_Dostawa();
            form_Dostawa.Show();
        }


        private void button_NoweZamowienie_Click(object sender, EventArgs e)
        {
            // Otwieramy KROK 1 (Produkty) wewnątrz panelu
            OpenChildForm(new Form_SzczegolyZamowienia());
        }


        private void button_zamow_material_Click(object sender, EventArgs e)
        {

        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            // Ręcznie ustalamy pozycję i rozmiar, żeby idealnie pasowało po prawej stronie 
            // (wypełnia miejsce nad ukrytym panelem firm i comboboxem)
            childForm.Location = new Point(337, 65);
            childForm.Size = new Size(1920, 1200);

            // KLUCZOWA ZMIANA: Dodajemy formularz do głównego okna (this), a nie do panel_dane_firmy!
            this.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void button_utworz_zamowienie_Click(object sender, EventArgs e)
        {
            {
                // --- NOWA LOGIKA ---
                // 1. Zaczynamy od otwarcia koszyka produktów
                Form_SzczegolyZamowienia formularzKoszyka = new Form_SzczegolyZamowienia();

                // 2. Wyświetlamy okno
                formularzKoszyka.Show();

                // Użyj formularzKoszyka.ShowDialog(); jeśli chcesz, aby użytkownik nie mógł 
                // klikać niczego w głównym menu, dopóki nie zamknie procesu zamówienia.
            }
        }

        private void label_ProszeWybracFirme_Click(object sender, EventArgs e)
        {

        }
    }
}
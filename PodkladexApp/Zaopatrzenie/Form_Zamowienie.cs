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

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_Zamowienie : Form
    {
        // 1. Deklaracja połączenia z bazą
        private PodkladexContext _db = new PodkladexContext();

        // Flaga określająca typ klienta (domyślnie false = prywatny)
        private bool czyFirma = false;

        public Form_Zamowienie()
        {
            InitializeComponent();
        }

        private void Form_Zamowienie_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

            // 2. Ładowanie podpowiedzi z bazy danych
            ZaladujPodpowiedzi();
        }

        private void ZaladujPodpowiedzi()
        {
            // Autouzupełnianie dla NIP
            AutoCompleteStringCollection nipKolekcja = new AutoCompleteStringCollection();
            var nipy = _db.Firma.Select(f => f.Nip).ToArray();
            nipKolekcja.AddRange(nipy);

            textBox_NIP.AutoCompleteCustomSource = nipKolekcja;
            textBox_NIP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_NIP.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Autouzupełnianie dla Email (lub numeru telefonu/PESELu)
            AutoCompleteStringCollection emailKolekcja = new AutoCompleteStringCollection();
            var emaile = _db.Osoba.Select(o => o.AdresEMail).ToArray(); // Upewnij się, jak dokładnie EF nazwał to pole, np. AdresEMail
            emailKolekcja.AddRange(emaile);

            textBox_email.AutoCompleteCustomSource = emailKolekcja;
            textBox_email.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_email.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void button_Klient_prywatny_Click(object sender, EventArgs e)
        {
            czyFirma = false;
            panel1.Visible = true;
            label_nazwa_firmy.Visible = false; textBox_nazwa_firmy.Visible = false;
            label_NIP.Visible = false; textBox_NIP.Visible = false;
        }

        private void button_klient_z_firmy_Click(object sender, EventArgs e)
        {
            czyFirma = true;
            panel1.Visible = true;
            label_nazwa_firmy.Visible = true; textBox_nazwa_firmy.Visible = true;
            label_NIP.Visible = true; textBox_NIP.Visible = true;
        }


        // ==========================================
        // Puste zdarzenia wygenerowane przez designera
        // ==========================================
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox_imie_TextChanged(object sender, EventArgs e) { }
        private void textBox_Numer_telefonu_TextChanged(object sender, EventArgs e) { }
        private void textBox_email_TextChanged(object sender, EventArgs e) { }
        private void textBox_Miejscowosc_TextChanged(object sender, EventArgs e) { }
        private void textBox_kod_pocztowy_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void textBox_nazwa_firmy_TextChanged(object sender, EventArgs e) { }
        private void textBox_NIP_TextChanged(object sender, EventArgs e) { }

        // Podepnij to pod zdarzenie LEAVE dla textBox_NIP
        // --- ZDARZENIA DLA EMAIL (OSOBA) ---
        private void textBox_email_Leave(object sender, EventArgs e)
        {
            UzupelnijDaneOsoby();
        }

        private void textBox_email_KeyDown(object sender, KeyEventArgs e)
        {
            // Jeśli użytkownik wciśnie Enter
            if (e.KeyCode == Keys.Enter)
            {
                UzupelnijDaneOsoby();
                e.SuppressKeyPress = true; // Zapobiega systemowemu piknięciu "ding"
            }
        }

        // --- ZDARZENIA DLA NIP (FIRMA) ---
        private void textBox_NIP_Leave(object sender, EventArgs e)
        {
            UzupelnijDaneFirmy();
        }

        private void textBox_NIP_KeyDown(object sender, KeyEventArgs e)
        {
            // Jeśli użytkownik wciśnie Enter
            if (e.KeyCode == Keys.Enter)
            {
                UzupelnijDaneFirmy();
                e.SuppressKeyPress = true;
            }
        }

        // DODAJ PRZYCISK "Zapisz" W DESIGNERZE I PODEPNIJ TO ZDARZENIE
        private void button_zapisz_Click(object sender, EventArgs e)
        {
            // 1. Sprawdzamy, czy osoba już istnieje w bazie (np. po PESELu lub Emailu)
            var osoba = _db.Osoba.FirstOrDefault(o => o.AdresEMail == textBox_email.Text);

            if (osoba == null)
            {
                // Osoba nie istnieje -> Tworzymy nową
                osoba = new Osoba()
                {
                    Imie = textBox_imie.Text,
                    Nazwisko = textBox_Nazwisko.Text,
                    NrTelefonu = textBox_Numer_telefonu.Text,
                    AdresEMail = textBox_email.Text,
                    Miejscowosc = textBox_Miejscowosc.Text,
                    KodPocztowy = textBox_kod_pocztowy.Text,
                    Ulica = textBox_ulica.Text,
                    Numer = textBox_numer.Text,
                    Pesel = "00000000000" // <--- WAŻNE: Musisz tu podpiąć tekst z textBox_PESEL.Text !
                };
                _db.Osoba.Add(osoba);
                _db.SaveChanges(); // Zapisujemy, aby uzyskać ID_Osoby
            }

            // 2. Szukamy czy ta osoba jest już Klientem
            var klient = _db.Klient.FirstOrDefault(k => k.IdOsoba == osoba.IdOsoba);
            if (klient == null)
            {
                klient = new Klient() { IdOsoba = osoba.IdOsoba };
                _db.Klient.Add(klient);
                _db.SaveChanges(); // Zapisujemy, aby uzyskać ID_Klienta
            }

            // 3. Jeśli zaznaczono "Firma", obsługujemy logikę firmy
            if (czyFirma)
            {
                var firma = _db.Firma.FirstOrDefault(f => f.Nip == textBox_NIP.Text);

                if (firma == null)
                {
                    // Firma nie istnieje -> tworzymy nową
                    firma = new Firma()
                    {
                        Nazwa = textBox_nazwa_firmy.Text,
                        Nip = textBox_NIP.Text,
                        // Zakładam, że firma na start otrzymuje ten sam adres, 
                        // chyba że zrobisz oddzielne pola adresowe dla firmy w swoim formularzu
                        Miejscowosc = textBox_Miejscowosc.Text,
                        KodPocztowy = textBox_kod_pocztowy.Text,
                        Ulica = textBox_ulica.Text,
                        Numer = textBox_numer.Text
                    };
                    _db.Firma.Add(firma);
                    _db.SaveChanges(); // Generuje ID_Firmy
                }

                // 4. Łączymy Klienta z Firmą w tabeli pośredniej
                var klientFirma = _db.KlientFirma.FirstOrDefault(kf => kf.IdKlient == klient.IdKlient && kf.IdFirma == firma.IdFirma);
                if (klientFirma == null)
                {
                    klientFirma = new KlientFirma()
                    {
                        IdKlient = klient.IdKlient,
                        IdFirma = firma.IdFirma
                    };
                    _db.KlientFirma.Add(klientFirma);
                }
            }

            // Finalny zapis całej transakcji
            _db.SaveChanges();

            MessageBox.Show("Klient (oraz ewentualna firma) został poprawnie zapisany/zaktualizowany w bazie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Odświeżenie list podpowiedzi, aby nowa osoba była od razu widoczna
            ZaladujPodpowiedzi();
        }

        private void UzupelnijDaneOsoby()
        {
            if (string.IsNullOrWhiteSpace(textBox_email.Text)) return;

            // Szukamy osoby o podanym emailu
            var znalezionaOsoba = _db.Osoba.FirstOrDefault(o => o.AdresEMail == textBox_email.Text);

            if (znalezionaOsoba != null)
            {
                textBox_imie.Text = znalezionaOsoba.Imie;
                textBox_Nazwisko.Text = znalezionaOsoba.Nazwisko;
                textBox_Numer_telefonu.Text = znalezionaOsoba.NrTelefonu;
                textBox_Miejscowosc.Text = znalezionaOsoba.Miejscowosc;
                textBox_kod_pocztowy.Text = znalezionaOsoba.KodPocztowy;
                textBox_ulica.Text = znalezionaOsoba.Ulica;
                textBox_numer.Text = znalezionaOsoba.Numer;

                // Pamiętaj o dodaniu pola PESEL!
                // textBox_PESEL.Text = znalezionaOsoba.Pesel; 
            }
        }

        private void UzupelnijDaneFirmy()
        {
            if (string.IsNullOrWhiteSpace(textBox_NIP.Text)) return;

            // Szukamy firmy o podanym NIPie
            var znalezionaFirma = _db.Firma.FirstOrDefault(f => f.Nip == textBox_NIP.Text);

            if (znalezionaFirma != null)
            {
                textBox_nazwa_firmy.Text = znalezionaFirma.Nazwa;

                // Jeśli firma ma u Ciebie w bazie swój własny adres, możesz go tu też uzupełnić:
                // textBox_Miejscowosc.Text = znalezionaFirma.Miejscowosc;
                // itp.
            }
        }

        private void label_imie_Click(object sender, EventArgs e)
        {

        }

        private void label_nazwisko_Click(object sender, EventArgs e)
        {

        }
    }
}

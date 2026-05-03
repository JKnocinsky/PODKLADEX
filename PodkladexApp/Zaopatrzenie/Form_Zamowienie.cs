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

        private List<Form_SzczegolyZamowienia.PozycjaKoszyka> _produktyDoZapisania;

        public Form_Zamowienie(List<Form_SzczegolyZamowienia.PozycjaKoszyka> koszyk)
        {
            InitializeComponent();
            _produktyDoZapisania = koszyk;
        }

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
        // DODAJ PRZYCISK "Zapisz" W DESIGNERZE I PODEPNIJ TO ZDARZENIE
        private void button_zapisz_Click(object sender, EventArgs e)
        {
            // 1. Sprawdzamy, czy osoba już istnieje w bazie po Emailu
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
                    // ZAWSZE pobieramy adres dla Osoby z tych kontrolek
                    Miejscowosc = textBox_Miejscowosc.Text,
                    KodPocztowy = textBox_kod_pocztowy.Text,
                    Ulica = textBox_ulica.Text,
                    Numer = textBox_numer.Text,
                    Pesel = "00000000000" // <--- Pamiętaj o podpięciu TextBoxa
                };
                _db.Osoba.Add(osoba);
            }
            else
            {
                // Osoba istnieje -> Sprawdzamy, czy którekolwiek z danych uległy zmianie
                bool czyDaneZmienione =
                    osoba.Imie != textBox_imie.Text ||
                    osoba.Nazwisko != textBox_Nazwisko.Text ||
                    osoba.NrTelefonu != textBox_Numer_telefonu.Text ||
                    osoba.Miejscowosc != textBox_Miejscowosc.Text ||
                    osoba.KodPocztowy != textBox_kod_pocztowy.Text ||
                    osoba.Ulica != textBox_ulica.Text ||
                    osoba.Numer != textBox_numer.Text;
                // || osoba.Pesel != textBox_PESEL.Text; // Odkomentuj, gdy dodasz PESEL

                if (czyDaneZmienione)
                {
                    // Dane się zmieniły! Tworzymy nowy rekord w bazie, aby nie nadpisać historii
                    osoba = new Osoba()
                    {
                        Imie = textBox_imie.Text,
                        Nazwisko = textBox_Nazwisko.Text,
                        NrTelefonu = textBox_Numer_telefonu.Text,
                        AdresEMail = textBox_email.Text, // Zachowujemy ten sam email
                        Miejscowosc = textBox_Miejscowosc.Text,
                        KodPocztowy = textBox_kod_pocztowy.Text,
                        Ulica = textBox_ulica.Text,
                        Numer = textBox_numer.Text,
                        Pesel = "00000000000"
                    };
                    _db.Osoba.Add(osoba);
                }
                // Jeśli czyDaneZmienione == false, zmienna 'osoba' nadal trzyma stary rekord z bazy,
                // więc nie dodajemy go ponownie, po prostu zostanie podpięty pod nowe zamówienie/klienta.
            }

            // Zapisujemy zmiany (wygeneruje to nowe IdOsoba, jeśli obiekt został dodany)
            _db.SaveChanges();

            // 2. Szukamy czy ta osoba jest już Klientem (używamy aktualnego osoba.IdOsoba)
            var klient = _db.Klient.FirstOrDefault(k => k.IdOsoba == osoba.IdOsoba);
            if (klient == null)
            {
                klient = new Klient() { IdOsoba = osoba.IdOsoba };
                _db.Klient.Add(klient);
                _db.SaveChanges(); // Zapisujemy, aby uzyskać IdKlienta
            }

            // 3. Logika Firmy
            if (czyFirma && !string.IsNullOrWhiteSpace(textBox_NIP.Text))
            {
                var firma = _db.Firma.FirstOrDefault(f => f.Nip == textBox_NIP.Text);

                if (firma == null)
                {
                    firma = new Firma()
                    {
                        Nazwa = textBox_nazwa_firmy.Text,
                        Nip = textBox_NIP.Text,
                        // --- TUTAJ ROBIMY MYK: PRZYPISUJEMY TEN SAM ADRES CO OSOBIE ---
                        Miejscowosc = textBox_Miejscowosc.Text,
                        KodPocztowy = textBox_kod_pocztowy.Text,
                        Ulica = textBox_ulica.Text,
                        Numer = textBox_numer.Text
                    };
                    _db.Firma.Add(firma);
                    _db.SaveChanges();
                }
                else
                {
                    // Aktualizujemy dane firmy, jeśli już istnieje, również wspólnym adresem
                    firma.Nazwa = textBox_nazwa_firmy.Text;
                    firma.Miejscowosc = textBox_Miejscowosc.Text;
                    firma.KodPocztowy = textBox_kod_pocztowy.Text;
                    firma.Ulica = textBox_ulica.Text;
                    firma.Numer = textBox_numer.Text;
                }

                _db.SaveChanges(); // Zapisuje zmiany dla firmy

                // 4. Łączymy Klienta z Firmą w tabeli pośredniej
                var klientFirma = _db.KlientFirma.FirstOrDefault(kf => kf.IdKlient == klient.IdKlient && kf.IdFirma == firma.IdFirma);
                if (klientFirma == null)
                {
                    klientFirma = new KlientFirma()
                    {
                        IdKlient = klient.IdKlient,
                        IdFirma = firma.IdFirma,
                        DataPocz = DateOnly.FromDateTime(DateTime.Today) // <--- Tutaj przypisujemy dzisiejszą datę początku
                    };
                    _db.KlientFirma.Add(klientFirma);
                }
            }

            // Finalny zapis relacji Klient-Firma
            _db.SaveChanges();
            // === DODANY KOD: 5. Tworzenie nagłówka zamówienia ===
            var zamowienie = new Zamowienie()
            {
                IdKlient = klient.IdKlient, // Zmienna 'klient' z Twojego kodu powyżej
                DataPrzyjeciaZ = DateOnly.FromDateTime(DateTime.Today),
                DataZrealizowaniaZ = null
            };
            _db.Zamowienie.Add(zamowienie);
            _db.SaveChanges(); // Zapisujemy, aby baza wygenerowała IdZamowienie

            // === DODANY KOD: 6. Zapisywanie produktów z koszyka ===
            // Upewniamy się, że koszyk został przekazany i nie jest pusty
            if (_produktyDoZapisania != null && _produktyDoZapisania.Count > 0)
            {
                foreach (var poz in _produktyDoZapisania)
                {
                    var szczegol = new SzczegolyZamowienia()
                    {
                        IdZamowienie = zamowienie.IdZamowienie, // Powiązanie z nagłówkiem z kroku 5
                        IdProdukt = poz.IdProduktu,
                        IdMaterial = poz.IdMaterialu,
                        Ilosc = poz.Ilosc,
                        Cena = poz.Cena,
                        Uwagi = poz.Uwagi
                    };
                    _db.SzczegolyZamowienia.Add(szczegol);
                }

                _db.SaveChanges(); // Ostateczny zapis wszystkich szczegółów do bazy
            }

            // Opcjonalnie: Ustawienie flagi sukcesu i zamknięcie tego okna (Krok 2)
            // Jeśli chcesz, aby okno zamknęło się po kliknięciu "OK" w MessageBox,
            // przenieś te dwie linijki POD MessageBox.Show

            MessageBox.Show("Dane zostały poprawnie zapisane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
            // Odświeżenie list podpowiedzi
            // ZaladujPodpowiedzi(); // You can't call this after this.Close(), so I moved it or you can remove it.
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

        private void button_czyszczenie_Click(object sender, EventArgs e)
        {
            // Czyszczenie danych klienta (osoby)
            textBox_imie.Clear();
            textBox_Nazwisko.Clear();
            textBox_Numer_telefonu.Clear();
            textBox_email.Clear();

            // Czyszczenie danych adresowych
            textBox_Miejscowosc.Clear();
            textBox_kod_pocztowy.Clear();
            textBox_ulica.Clear();
            textBox_numer.Clear();

            // Czyszczenie danych firmowych
            textBox_nazwa_firmy.Clear();
            textBox_NIP.Clear();

        }

        private void button_Wroc_Click(object sender, EventArgs e)
        {
            // Ustawiamy wynik na Cancel (oznacza, że nie zapisaliśmy) i zamykamy formularz.
            // To uruchomi zdarzenie FormClosed w KROKU 1, które z powrotem pokaże koszyk!
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

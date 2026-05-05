using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using PodkladexApp.Models;

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_Zamowienie : Form
    {
        private List<Form_SzczegolyZamowienia.PozycjaKoszyka> _produktyDoZapisania;
        private PodkladexContext _db = new PodkladexContext();

        private bool czyFirma = false;

        public Form_Zamowienie(List<Form_SzczegolyZamowienia.PozycjaKoszyka> koszyk)
        {
            InitializeComponent();
            _produktyDoZapisania = koszyk;
            this.Load += Form_Zamowienie_Load;
        }

        public Form_Zamowienie()
        {
            InitializeComponent();
            this.Load += Form_Zamowienie_Load;
        }

        private void Form_Zamowienie_Load(object sender, EventArgs e)
        {
            czyFirma = false;
            panel1.Visible = true;
            label_nazwa_firmy.Visible = false; textBox_nazwa_firmy.Visible = false;
            label_NIP.Visible = false; textBox_NIP.Visible = false;

            // FIZYCZNE ZABLOKOWANIE MAKSYMALNEJ DŁUGOŚCI ZNAKÓW
            textBox_NIP.MaxLength = 13;
            textBox_Numer_telefonu.MaxLength = 11;
            textBox_kod_pocztowy.MaxLength = 6;

            // =======================================================
            // TWARDE PODPIĘCIE ZDARZEŃ FORMATUJĄCYCH I AKCJI
            // =======================================================
            textBox_Numer_telefonu.TextChanged -= textBox_Numer_telefonu_TextChanged;
            textBox_Numer_telefonu.TextChanged += textBox_Numer_telefonu_TextChanged;

            textBox_kod_pocztowy.TextChanged -= textBox_kod_pocztowy_TextChanged;
            textBox_kod_pocztowy.TextChanged += textBox_kod_pocztowy_TextChanged;

            textBox_NIP.TextChanged -= textBox_NIP_TextChanged;
            textBox_NIP.TextChanged += textBox_NIP_TextChanged;

            textBox_email.Leave -= textBox_email_Leave;
            textBox_email.Leave += textBox_email_Leave;
            textBox_email.KeyDown -= textBox_email_KeyDown;
            textBox_email.KeyDown += textBox_email_KeyDown;

            textBox_NIP.Leave -= textBox_NIP_Leave;
            textBox_NIP.Leave += textBox_NIP_Leave;
            textBox_NIP.KeyDown -= textBox_NIP_KeyDown;
            textBox_NIP.KeyDown += textBox_NIP_KeyDown;

            ZaladujPodpowiedziNIP();
            OdswiezPodpowiedziEmail();
        }

        // ==========================================
        // DYNAMICZNE PODPOWIEDZI KONTROLEK
        // ==========================================
        private void ZaladujPodpowiedziNIP()
        {
            AutoCompleteStringCollection nipKolekcja = new AutoCompleteStringCollection();
            var nipy = _db.Firma.Where(f => !string.IsNullOrEmpty(f.Nip)).Select(f => f.Nip).ToArray();
            nipKolekcja.AddRange(nipy);

            textBox_NIP.AutoCompleteCustomSource = nipKolekcja;
            textBox_NIP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_NIP.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void OdswiezPodpowiedziEmail()
        {
            try
            {
                AutoCompleteStringCollection emailKolekcja = new AutoCompleteStringCollection();
                var dzisiaj = DateOnly.FromDateTime(DateTime.Today);

                // 1. Zbieramy WSZYSTKIE e-maile z bazy do pamięci RAM
                var wszystkieEmaile = _db.Osoba
                    .Where(o => !string.IsNullOrEmpty(o.AdresEMail))
                    .Select(o => o.AdresEMail)
                    .Distinct()
                    .ToList();

                // 2. Zbieramy tylko te E-MAILE, które mają aktywne powiązanie z firmą (do pamięci RAM)
                var emaileFirmowe = _db.KlientFirma
                    .Include(kf => kf.IdKlientNavigation)
                        .ThenInclude(k => k.IdOsobaNavigation)
                    .Where(kf => kf.DataKoniec == null || kf.DataKoniec >= dzisiaj)
                    .Where(kf => kf.IdKlientNavigation != null && kf.IdKlientNavigation.IdOsobaNavigation != null)
                    .Select(kf => kf.IdKlientNavigation.IdOsobaNavigation.AdresEMail)
                    .Where(e => !string.IsNullOrEmpty(e))
                    .Distinct()
                    .ToList();

                string[] emaile;

                if (czyFirma)
                {
                    // Pokazujemy tylko emaile firmowe
                    emaile = emaileFirmowe.ToArray();
                }
                else
                {
                    // Magia: używamy .Except() na lokalnych listach w RAMie! To eliminuje błędy bazy danych EF Core.
                    emaile = wszystkieEmaile.Except(emaileFirmowe).ToArray();
                }

                emailKolekcja.AddRange(emaile);
                textBox_email.AutoCompleteCustomSource = emailKolekcja;
                textBox_email.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox_email.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania podpowiedzi: {ex.Message}");
            }
        }

        // ==========================================
        // PRZEŁĄCZNIKI TYPU KLIENTA
        // ==========================================
        private void button_Klient_prywatny_Click(object sender, EventArgs e)
        {
            czyFirma = false;
            panel1.Visible = true;
            label_nazwa_firmy.Visible = false; textBox_nazwa_firmy.Visible = false;
            label_NIP.Visible = false; textBox_NIP.Visible = false;

            button_czyszczenie_Click(null, null);
            OdswiezPodpowiedziEmail();
        }

        private void button_klient_z_firmy_Click(object sender, EventArgs e)
        {
            czyFirma = true;
            panel1.Visible = true;
            label_nazwa_firmy.Visible = true; textBox_nazwa_firmy.Visible = true;
            label_NIP.Visible = true; textBox_NIP.Visible = true;

            button_czyszczenie_Click(null, null);
            OdswiezPodpowiedziEmail();
        }

        // ==========================================
        // AUTOMATYCZNE FORMATOWANIE W LOCIE
        // ==========================================
        private void textBox_Numer_telefonu_TextChanged(object sender, EventArgs e)
        {
            string raw = new string(textBox_Numer_telefonu.Text.Where(char.IsDigit).ToArray());
            if (raw.Length > 9) raw = raw.Substring(0, 9);

            string formatted = raw;
            if (raw.Length > 3) formatted = raw.Insert(3, "-");
            if (raw.Length > 6) formatted = formatted.Insert(7, "-");

            if (textBox_Numer_telefonu.Text != formatted)
            {
                textBox_Numer_telefonu.Text = formatted;
                textBox_Numer_telefonu.SelectionStart = textBox_Numer_telefonu.Text.Length;
            }
        }

        private void textBox_kod_pocztowy_TextChanged(object sender, EventArgs e)
        {
            string raw = new string(textBox_kod_pocztowy.Text.Where(char.IsDigit).ToArray());
            if (raw.Length > 5) raw = raw.Substring(0, 5);

            string formatted = raw;
            if (raw.Length > 2) formatted = raw.Insert(2, "-");

            if (textBox_kod_pocztowy.Text != formatted)
            {
                textBox_kod_pocztowy.Text = formatted;
                textBox_kod_pocztowy.SelectionStart = textBox_kod_pocztowy.Text.Length;
            }
        }

        private void textBox_NIP_TextChanged(object sender, EventArgs e)
        {
            string raw = new string(textBox_NIP.Text.Where(char.IsDigit).ToArray());
            if (raw.Length > 10) raw = raw.Substring(0, 10);

            string formatted = raw;
            if (raw.Length > 3) formatted = formatted.Insert(3, "-");
            if (raw.Length > 6) formatted = formatted.Insert(7, "-");
            if (raw.Length > 8) formatted = formatted.Insert(10, "-");

            if (textBox_NIP.Text != formatted)
            {
                textBox_NIP.Text = formatted;
                textBox_NIP.SelectionStart = textBox_NIP.Text.Length;
            }
        }

        // ==========================================
        // POBIERANIE DANYCH Z BAZY PO WPISANIU
        // ==========================================
        private void textBox_email_Leave(object sender, EventArgs e) => UzupelnijDaneOsoby();
        private void textBox_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UzupelnijDaneOsoby();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox_NIP_Leave(object sender, EventArgs e) => UzupelnijDaneFirmy();
        private void textBox_NIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UzupelnijDaneFirmy();
                e.SuppressKeyPress = true;
            }
        }

        private void UzupelnijDaneOsoby()
        {
            if (string.IsNullOrWhiteSpace(textBox_email.Text)) return;

            try
            {
                // Bierzemy dane adresowe z najnowszego zamówienia danego klienta
                var znalezionaOsoba = _db.Zamowienie
                    .Include(z => z.IdKlientNavigation)
                        .ThenInclude(k => k.IdOsobaNavigation)
                    .Where(z => z.IdKlientNavigation.IdOsobaNavigation.AdresEMail == textBox_email.Text)
                    .OrderByDescending(z => z.DataPrzyjeciaZ)
                    .ThenByDescending(z => z.IdZamowienie)
                    .Select(z => z.IdKlientNavigation.IdOsobaNavigation)
                    .FirstOrDefault();

                // Zabezpieczenie: jeśli nie ma zamówień, bierzemy najnowszą iterację osoby po Emailu
                if (znalezionaOsoba == null)
                {
                    znalezionaOsoba = _db.Osoba
                        .Where(o => o.AdresEMail == textBox_email.Text)
                        .OrderByDescending(o => o.IdOsoba)
                        .FirstOrDefault();
                }

                if (znalezionaOsoba != null)
                {
                    textBox_imie.Text = znalezionaOsoba.Imie;
                    textBox_Nazwisko.Text = znalezionaOsoba.Nazwisko;
                    textBox_Numer_telefonu.Text = znalezionaOsoba.NrTelefonu;
                    textBox_Miejscowosc.Text = znalezionaOsoba.Miejscowosc;
                    textBox_kod_pocztowy.Text = znalezionaOsoba.KodPocztowy;
                    textBox_ulica.Text = znalezionaOsoba.Ulica;
                    textBox_numer.Text = znalezionaOsoba.Numer;

                    if (czyFirma)
                    {
                        var dzisiaj = DateOnly.FromDateTime(DateTime.Today);

                        // Szukamy firmy po EMAILU, a nie po ID, ponieważ IdOsoba może się zmieniać!
                        var powiazanieFirmowe = _db.KlientFirma
                            .Include(kf => kf.IdFirmaNavigation)
                            .Include(kf => kf.IdKlientNavigation)
                                .ThenInclude(k => k.IdOsobaNavigation)
                            .Where(kf => kf.IdKlientNavigation.IdOsobaNavigation.AdresEMail == textBox_email.Text)
                            .Where(kf => kf.DataKoniec == null || kf.DataKoniec >= dzisiaj)
                            .OrderByDescending(kf => kf.IdKlientFirma)
                            .FirstOrDefault();

                        if (powiazanieFirmowe != null && powiazanieFirmowe.IdFirmaNavigation != null)
                        {
                            textBox_nazwa_firmy.Text = powiazanieFirmowe.IdFirmaNavigation.Nazwa;
                            textBox_NIP.Text = powiazanieFirmowe.IdFirmaNavigation.Nip;
                        }
                        else
                        {
                            textBox_nazwa_firmy.Clear();
                            textBox_NIP.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd uzupełniania danych: {ex.Message}");
            }
        }

        private void UzupelnijDaneFirmy()
        {
            if (string.IsNullOrWhiteSpace(textBox_NIP.Text)) return;

            var znalezionaFirma = _db.Firma.FirstOrDefault(f => f.Nip == textBox_NIP.Text);

            if (znalezionaFirma != null)
            {
                textBox_nazwa_firmy.Text = znalezionaFirma.Nazwa;
                textBox_Miejscowosc.Text = znalezionaFirma.Miejscowosc;
                textBox_kod_pocztowy.Text = znalezionaFirma.KodPocztowy;
                textBox_ulica.Text = znalezionaFirma.Ulica;
                textBox_numer.Text = znalezionaFirma.Numer;
            }
        }

        // ==========================================
        // GŁÓWNA LOGIKA ZAPISU (Przycisk Zapisz)
        // ==========================================
        private void button_zapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_imie.Text) ||
                string.IsNullOrWhiteSpace(textBox_Nazwisko.Text) ||
                string.IsNullOrWhiteSpace(textBox_Numer_telefonu.Text) ||
                string.IsNullOrWhiteSpace(textBox_email.Text) ||
                string.IsNullOrWhiteSpace(textBox_Miejscowosc.Text) ||
                string.IsNullOrWhiteSpace(textBox_kod_pocztowy.Text) ||
                string.IsNullOrWhiteSpace(textBox_ulica.Text) ||
                string.IsNullOrWhiteSpace(textBox_numer.Text))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie podstawowe dane kontaktowe i adresowe.", "Braki w formularzu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(textBox_email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Podano niepoprawny format adresu e-mail.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox_kod_pocztowy.Text.Length != 6)
            {
                MessageBox.Show("Kod pocztowy jest niekompletny.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox_Numer_telefonu.Text.Length != 11)
            {
                MessageBox.Show("Numer telefonu musi składać się z 9 cyfr.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (czyFirma)
            {
                if (string.IsNullOrWhiteSpace(textBox_nazwa_firmy.Text) ||
                    string.IsNullOrWhiteSpace(textBox_NIP.Text))
                {
                    MessageBox.Show("Wybrano opcję zakupu na firmę. Proszę uzupełnić Nazwę firmy oraz NIP.", "Braki w formularzu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBox_NIP.Text.Length != 13)
                {
                    MessageBox.Show("Numer NIP musi składać się dokładnie z 10 cyfr.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // --- 1. OSOBA (Ochrona historii starych zamówień) ---
                var osoba = _db.Zamowienie
                    .Include(z => z.IdKlientNavigation)
                        .ThenInclude(k => k.IdOsobaNavigation)
                    .Where(z => z.IdKlientNavigation.IdOsobaNavigation.AdresEMail == textBox_email.Text)
                    .OrderByDescending(z => z.DataPrzyjeciaZ)
                    .ThenByDescending(z => z.IdZamowienie)
                    .Select(z => z.IdKlientNavigation.IdOsobaNavigation)
                    .FirstOrDefault();

                if (osoba == null)
                {
                    osoba = _db.Osoba.OrderByDescending(o => o.IdOsoba).FirstOrDefault(o => o.AdresEMail == textBox_email.Text);
                }

                if (osoba == null)
                {
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
                        Pesel = null
                    };
                    _db.Osoba.Add(osoba);
                }
                else
                {
                    bool czyDaneZmienione =
                        osoba.Imie != textBox_imie.Text ||
                        osoba.Nazwisko != textBox_Nazwisko.Text ||
                        osoba.NrTelefonu != textBox_Numer_telefonu.Text ||
                        osoba.Miejscowosc != textBox_Miejscowosc.Text ||
                        osoba.KodPocztowy != textBox_kod_pocztowy.Text ||
                        osoba.Ulica != textBox_ulica.Text ||
                        osoba.Numer != textBox_numer.Text;

                    if (czyDaneZmienione)
                    {
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
                            Pesel = null
                        };
                        _db.Osoba.Add(osoba);
                    }
                }

                _db.SaveChanges(); // Generuje nowe ID dla nowej osoby

                // --- 2. KLIENT ---
                var klient = _db.Klient.FirstOrDefault(k => k.IdOsoba == osoba.IdOsoba);
                if (klient == null)
                {
                    klient = new Klient() { IdOsoba = osoba.IdOsoba };
                    _db.Klient.Add(klient);
                    _db.SaveChanges();
                }

                // --- 3. FIRMA I POWIĄZANIE ---
                if (czyFirma)
                {
                    var firma = _db.Firma.FirstOrDefault(f => f.Nip == textBox_NIP.Text);

                    if (firma == null)
                    {
                        firma = new Firma()
                        {
                            Nazwa = textBox_nazwa_firmy.Text,
                            Nip = textBox_NIP.Text,
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
                        firma.Nazwa = textBox_nazwa_firmy.Text;
                        firma.Miejscowosc = textBox_Miejscowosc.Text;
                        firma.KodPocztowy = textBox_kod_pocztowy.Text;
                        firma.Ulica = textBox_ulica.Text;
                        firma.Numer = textBox_numer.Text;
                        _db.Firma.Update(firma);
                    }

                    _db.SaveChanges();

                    var dzisiaj = DateOnly.FromDateTime(DateTime.Today);

                    var klientFirma = _db.KlientFirma.FirstOrDefault(kf => kf.IdKlient == klient.IdKlient && kf.IdFirma == firma.IdFirma);

                    if (klientFirma == null)
                    {
                        klientFirma = new KlientFirma()
                        {
                            IdKlient = klient.IdKlient,
                            IdFirma = firma.IdFirma,
                            DataPocz = dzisiaj
                        };
                        _db.KlientFirma.Add(klientFirma);
                    }
                    else if (klientFirma.DataKoniec != null && klientFirma.DataKoniec < dzisiaj)
                    {
                        var nowePowiazanie = new KlientFirma()
                        {
                            IdKlient = klient.IdKlient,
                            IdFirma = firma.IdFirma,
                            DataPocz = dzisiaj
                        };
                        _db.KlientFirma.Add(nowePowiazanie);
                    }
                }

                _db.SaveChanges();

                // --- 4. ZAMÓWIENIE I SZCZEGÓŁY ---
                var zamowienie = new Zamowienie()
                {
                    IdKlient = klient.IdKlient,
                    DataPrzyjeciaZ = DateOnly.FromDateTime(DateTime.Today),
                    DataZrealizowaniaZ = null
                };
                _db.Zamowienie.Add(zamowienie);
                _db.SaveChanges();

                if (_produktyDoZapisania != null && _produktyDoZapisania.Count > 0)
                {
                    foreach (var poz in _produktyDoZapisania)
                    {
                        var szczegol = new SzczegolyZamowienia()
                        {
                            IdZamowienie = zamowienie.IdZamowienie,
                            IdProdukt = poz.IdProduktu,
                            IdMaterial = poz.IdMaterialu,
                            Ilosc = poz.Ilosc,
                            Cena = poz.Cena,
                            Uwagi = poz.Uwagi
                        };
                        _db.SzczegolyZamowienia.Add(szczegol);
                    }
                    _db.SaveChanges();
                }

                MessageBox.Show("Dane zostały poprawnie zapisane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisu: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // PRZYCISKI POMOCNICZE
        // ==========================================
        private void button_czyszczenie_Click(object sender, EventArgs e)
        {
            textBox_imie.Clear();
            textBox_Nazwisko.Clear();
            textBox_Numer_telefonu.Clear();
            textBox_email.Clear();
            textBox_Miejscowosc.Clear();
            textBox_kod_pocztowy.Clear();
            textBox_ulica.Clear();
            textBox_numer.Clear();
            textBox_nazwa_firmy.Clear();
            textBox_NIP.Clear();
        }

        private void button_Wroc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Puste zdarzenia wygenerowane przez designera 
        private void label_imie_Click(object sender, EventArgs e) { }
        private void label_nazwisko_Click(object sender, EventArgs e) { }
        private void textBox_imie_TextChanged(object sender, EventArgs e) { }
        private void textBox_email_TextChanged(object sender, EventArgs e) { }
        private void textBox_Miejscowosc_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void textBox_nazwa_firmy_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
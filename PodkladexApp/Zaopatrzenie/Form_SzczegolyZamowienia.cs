using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PodkladexApp.Models; // <-- Wymagane, aby widzieć klasy takie jak PodkladexContext, Produkt, Material

namespace PodkladexApp.Zaopatrzenie
{


    public partial class Form_SzczegolyZamowienia : Form
    {

        private void AktualizujWyliczonaCene()
        {
            // Pobieramy ID wybranego materiału z ComboBoxa
            if (comboBox_Material.SelectedValue is int idMaterialu)
            {
                // 1. Łączymy SzczegolyDostawy z Dostawa (JOIN), 
                // filtrujemy po materiale, sortujemy po dacie z tabeli Dostawa i wyciągamy cenę.
                var ostatniaCenaZakupu = (from sd in _db.SzczegolyDostawy
                                          join d in _db.Dostawa on sd.IdDostawa equals d.IdDostawa
                                          where sd.IdMaterial == idMaterialu
                                          orderby d.DataDostawy descending
                                          select sd.Cena).FirstOrDefault();

                if (ostatniaCenaZakupu > 0)
                {
                    decimal iloscKg = numericUpDown_Ilosc.Value;

                    // TWOJE RÓWNANIE: (Cena za kg * 1.25 marży) * ilość w kg
                    decimal surowaCena = (ostatniaCenaZakupu * 1.25m) * iloscKg;

                    // NOWE: Zaokrąglenie do 2 miejsc po przecinku
                    decimal wyliczonaCena = Math.Round(surowaCena, 2);

                    // Ustawiamy wynik w polu ceny
                    numericUpDown_Cena.Value = wyliczonaCena;
                }
                else
                {
                    // Jeśli materiał nigdy nie był kupowany
                    numericUpDown_Cena.Value = 0;
                }
            }
        }


        private void ZablokujReszteFormularza(bool stan)
        {
            comboBox_Material.Enabled = stan;
            numericUpDown_Ilosc.Enabled = stan;
            numericUpDown_Cena.Enabled = stan;
            textBox_Uwagi.Enabled = stan;
            button_DodajPozycje.Enabled = stan;
        }


        // Klasa przetrzymująca dane wybranej pozycji w "koszyku"
        public class PozycjaKoszyka
        {
            public int IdProduktu { get; set; }
            public string NazwaProduktu { get; set; }
            public int IdMaterialu { get; set; }
            public string NazwaMaterialu { get; set; }
            public int Ilosc { get; set; } // Zmienione na int, zgodnie z tabelą Szczegoly_zamowienia w SQL
            public decimal Cena { get; set; }
            public string Uwagi { get; set; }
        }

        // Deklaracja połączenia z bazą i listy (naszego koszyka)
        private PodkladexContext _db = new PodkladexContext();
        private List<PozycjaKoszyka> _koszyk = new List<PozycjaKoszyka>();

        public Form_SzczegolyZamowienia()
        {
            InitializeComponent();
        }

        private void Form_SzczegolyZamowienia_Load(object sender, EventArgs e)
        {
            // Ładowanie listy produktów z bazy danych
            comboBox_Produkt.DataSource = _db.Produkt.ToList();
            comboBox_Produkt.DisplayMember = "Nazwa";
            comboBox_Produkt.ValueMember = "IdProdukt"; // Upewnij się, że pole nazywa się IdProdukt

            // Ustawiamy brak wybranego produktu na start
            comboBox_Produkt.SelectedIndex = -1;

            // Konfiguracja wartości domyślnych
            numericUpDown_Ilosc.Minimum = 1;

            // Blokujemy resztę okna dopóki nie zostanie wybrany produkt
            ZablokujReszteFormularza(false);
            dataGridView_Koszyk.DefaultCellStyle.Font = new Font("Segoe UI", 14);

            // (Opcjonalnie) Jeśli chcesz, żeby nagłówki kolumn też były większe i np. pogrubione:
            dataGridView_Koszyk.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        }

        private void button_DodajPozycje_Click(object sender, EventArgs e)
        {
            // Upewniamy się, że cokolwiek zostało wybrane z list
            if (comboBox_Produkt.SelectedItem is Produkt p && comboBox_Material.SelectedItem is Material m)
            {
                // Zczytywanie wartości z interfejsu do nowego obiektu
                var nowaPozycja = new PozycjaKoszyka
                {
                    IdProduktu = p.IdProdukt,
                    NazwaProduktu = p.Nazwa,
                    IdMaterialu = m.IdMaterial,
                    NazwaMaterialu = m.Nazwa,
                    Ilosc = (int)numericUpDown_Ilosc.Value, // Rzutujemy na INT
                    Cena = numericUpDown_Cena.Value,
                    Uwagi = textBox_Uwagi.Text
                };

                // Dodanie do wewnętrznej listy
                _koszyk.Add(nowaPozycja);

                // Odświeżenie tabelki na ekranie (DataGridView)
                dataGridView_Koszyk.DataSource = null;
                dataGridView_Koszyk.DataSource = _koszyk;

                // Czyszczenie pół dla wygody dodania kolejnego produktu
                numericUpDown_Ilosc.Value = 1;
                numericUpDown_Cena.Value = 0;
                textBox_Uwagi.Clear();
            }
            else
            {
                MessageBox.Show("Wybierz poprawnie produkt oraz materiał z list rozwijanych.", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // UKRYWANIE IDENTYFIKATORÓW:
            dataGridView_Koszyk.DataSource = null;
            dataGridView_Koszyk.DataSource = _koszyk;

            // Zmiana nazw i rozszerzanie po zbindowaniu danych:
            if (dataGridView_Koszyk.Columns["NazwaProduktu"] != null)
            {
                dataGridView_Koszyk.Columns["NazwaProduktu"].HeaderText = "Produkt";
            }

            if (dataGridView_Koszyk.Columns["NazwaMaterialu"] != null)
            {
                dataGridView_Koszyk.Columns["NazwaMaterialu"].HeaderText = "Materiał";
            }

            // Ukrywanie ID (z poprzedniego kroku)
            dataGridView_Koszyk.Columns["IdProduktu"].Visible = false;
            dataGridView_Koszyk.Columns["IdMaterialu"].Visible = false;

            // Automatyczne dopasowanie szerokości wszystkich kolumn
            dataGridView_Koszyk.AutoResizeColumns();
        }

        private void button_PrzejdzDalej_Click(object sender, EventArgs e)
        {
            // 1. Sprawdzenie, czy koszyk nie jest pusty
            if (_koszyk.Count == 0)
            {
                MessageBox.Show("Koszyk jest pusty! Dodaj przynajmniej jeden produkt przed przejściem do danych klienta.", "Brak produktów", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ====================================================
            // 2. NOWE: SPRAWDZENIE ZAPOTRZEBOWANIA MATERIAŁOWEGO
            // ====================================================
            string raportBrakow = GenerujRaportBrakow();
            if (!string.IsNullOrEmpty(raportBrakow))
            {
                // Wyświetlamy ostrzeżenie z żółtym trójkątem, ale pozwalamy przejść dalej po kliknięciu "OK"
                string wiadomosc = "W magazynie nie ma wystarczającej ilości materiału!\n\n" +
                                   raportBrakow +
                                   "\nZamówienie zostanie przetworzone, ale pamiętaj o zamówieniu surowca.";

                MessageBox.Show(wiadomosc, "Wymagane domówienie materiału", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // ====================================================

            // 3. Tworzymy KROK 2 (Dane klienta) - TEN KOD JUŻ MASZ
            Form_Zamowienie formKlient = new Form_Zamowienie(_koszyk);
            Control kontenerRodzica = this.Parent;

            if (kontenerRodzica != null)
            {
                // --- ODKRYTO RODZICA: Formularz jest wstrzyknięty w inne okno (przez OpenChildForm) ---
                formKlient.TopLevel = false;
                formKlient.FormBorderStyle = FormBorderStyle.None;

                // Kopiujemy rozmiar i pozycję od aktualnego okna koszyka
                formKlient.Location = this.Location;
                formKlient.Size = this.Size;

                // Dodajemy okno klienta do tego samego kontenera
                kontenerRodzica.Controls.Add(formKlient);
                formKlient.BringToFront();
                formKlient.Show();

                // Ukrywamy koszyk
                this.Hide();

                // Podpinamy powrót
                formKlient.FormClosed += (s, args) =>
                {
                    if (formKlient.DialogResult == DialogResult.OK)
                    {
                        this.Close(); // Finał - zapisano poprawnie
                    }
                    else
                    {
                        this.Show(); // Użytkownik kliknął powrót, odkrywamy znowu koszyk
                    }
                };
            }
            else
            {
                // --- BRAK RODZICA: Formularz jest otwarty jako wolne okno przez zwykłe .Show() ---
                this.Hide(); // Ukrywamy koszyk

                if (formKlient.ShowDialog() == DialogResult.OK)
                {
                    this.Close(); // Finał po oknie modalnym
                }
                else
                {
                    this.Show(); // Powrót do koszyka
                }
            }

        }
        private string GenerujRaportBrakow()
        {
            StringBuilder raport = new StringBuilder();

            // Grupujemy koszyk po ID materiału, aby zsumować ile łącznie potrzebujemy danego surowca
            var grupyMaterialow = _koszyk.GroupBy(k => new { k.IdMaterialu, k.NazwaMaterialu }).ToList();

            foreach (var grupa in grupyMaterialow)
            {
                int idMat = grupa.Key.IdMaterialu;
                decimal laczneZapotrzebowanie = 0;

                foreach (var poz in grupa)
                {
                    // POBIERANIE NORMY
                    var norma = _db.NormaProd
                                   .Where(n => n.IdProdukt == poz.IdProduktu && n.IdMaterial == idMat)
                                   .FirstOrDefault();

                    if (norma != null)
                    {
                        decimal ileMatNaJednostke = 0;
                        if (norma.Ilosc > 0)
                        {
                            ileMatNaJednostke = (decimal)norma.IloscMat / (decimal)norma.Ilosc;
                        }

                        // Mnożymy przez ilość z koszyka
                        laczneZapotrzebowanie += poz.Ilosc * ileMatNaJednostke;
                    }
                    else
                    {
                        raport.AppendLine($"- UWAGA: Brak normy w systemie dla pary: {poz.NazwaProduktu} + {poz.NazwaMaterialu}.");
                    }
                }

                // POBIERANIE STANU MAGAZYNOWEGO BEZPOŚREDNIO Z WIDOKU SQL
                var stanBaza = _db.AktualnyStanMagazynu
                                  .FirstOrDefault(s => s.IdMaterial == idMat);

                decimal stanMagazynu = stanBaza?.AktualnyStan ?? 0m;

                // Porównujemy zapotrzebowanie ze stanem magazynowym
                if (stanMagazynu < laczneZapotrzebowanie)
                {
                    decimal brakuje = laczneZapotrzebowanie - stanMagazynu;

                    // =========================================================
                    // NOWE: Pobieranie wartości nominalnej brakującego materiału
                    // =========================================================
                    var wartoscNominalna = _db.MaterialWlasciwosci
                                              .Where(mw => mw.IdMaterial == idMat)
                                              .Select(mw => mw.WartoscNominalna)
                                              .FirstOrDefault();

                    // Dodajemy wartość nominalną do tekstu w raporcie
                    raport.AppendLine($"- {grupa.Key.NazwaMaterialu} (Grubość: {wartoscNominalna}): BRAKUJE {Math.Round(brakuje, 2)} kg (Zapotrzebowanie: {Math.Round(laczneZapotrzebowanie, 2)} kg | Na stanie: {Math.Round(stanMagazynu, 2)} kg)");
                }
            }

            return raport.ToString();
        }

        // ==========================================
        // Puste zdarzenia (odpięte/nieużywane w tej chwili, pozostawione na przyszłość)
        // ==========================================
        private void comboBox_Produkt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sprawdzamy, czy użytkownik faktycznie wybrał produkt
            if (comboBox_Produkt.SelectedItem is Produkt wybranyProdukt)
            {
                // Odblokowujemy resztę formularza
                ZablokujReszteFormularza(true);

                // Zapytanie LINQ dopasowujące materiały do produktu
                var pasujaceMaterialy = (from m in _db.Material
                                         join mw in _db.MaterialWlasciwosci on m.IdMaterial equals mw.IdMaterial
                                         join pw in _db.ProduktWlasciwosci on mw.IdWlasciwosci equals pw.IdWlasciwosci
                                         where pw.IdProdukt == wybranyProdukt.IdProdukt
                                            && mw.WartoscNominalna == pw.WartoscNominalna
                                         select m).Distinct().ToList();

                // Podpinamy przefiltrowaną listę pod ComboBox
                comboBox_Material.DataSource = pasujaceMaterialy;
                comboBox_Material.DisplayMember = "Nazwa";
                comboBox_Material.ValueMember = "IdMaterial";

                // ==========================================
                // BRAK MATERIAŁU - ZMIENIONY KOMUNIKAT
                // ==========================================
                if (pasujaceMaterialy.Count == 0)
                {
                    // Pobieramy wartość nominalną (grubość) dla wybranego produktu z bazy
                    var wymaganaGrubosc = _db.ProduktWlasciwosci
                                             .Where(pw => pw.IdProdukt == wybranyProdukt.IdProdukt)
                                             .Select(pw => pw.WartoscNominalna)
                                             .FirstOrDefault();

                    // Tworzymy spersonalizowany komunikat
                    string wiadomosc = $"Brak materiałów o zgodnej grubości dla wybranego produktu!\n\n" +
                                       $"Wymagana wartość nominalna to: {wymaganaGrubosc}";

                    MessageBox.Show(wiadomosc, "Brak odpowiedniego materiału", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Blokujemy możliwość dodania pozycji do koszyka
                    button_DodajPozycje.Enabled = false;
                }
            }
            else
            {
                // Jeśli zaznaczenie zniknie, znowu blokujemy formularz i czyścimy materiały
                ZablokujReszteFormularza(false);
                comboBox_Material.DataSource = null;
            }
        }

        private void comboBox_Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizujWyliczonaCene();
        }
        private void numericUpDown_Ilosc_ValueChanged(object sender, EventArgs e)
        {
            AktualizujWyliczonaCene();
        }
        private void numericUpDown_Cena_ValueChanged(object sender, EventArgs e) { }

        private void textBox_Uwagi_TextChanged(object sender, EventArgs e) { }
        private void dataGridView_Koszyk_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
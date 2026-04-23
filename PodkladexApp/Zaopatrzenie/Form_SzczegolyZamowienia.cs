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
            comboBox_Produkt.ValueMember = "IdProdukt"; // Upewnij się, że pole w encji nazywa się IdProdukt

            // Ładowanie listy materiałów z bazy danych
            comboBox_Material.DataSource = _db.Material.ToList();
            comboBox_Material.DisplayMember = "Nazwa";
            comboBox_Material.ValueMember = "IdMaterial"; // Upewnij się, że pole w encji to IdMaterial

            // Konfiguracja wartości domyślnych dla UI
            numericUpDown_Ilosc.Minimum = 1;
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
                    // POBIERANIE NORMY - Zmień 'ProduktNorma' na nazwę Twojej encji z modelu EF
                    // oraz upewnij się, że pola 'IloscMaterialu' i 'IloscProduktu' nazywają się tak samo w Twojej klasie.
                    var norma = _db.NormaProd
                                   .Where(n => n.IdProdukt == poz.IdProduktu && n.IdMaterial == idMat)
                                   // .OrderByDescending(n => n.DataWprowadzenia) <-- Odkomentuj, jeśli masz pole z datą normy
                                   .FirstOrDefault();

                    if (norma != null)
                    {
                        // Obliczamy ile potrzeba materiału na 1 sztukę (lub 1 kg) produktu
                        decimal ileMatNaJednostke = (decimal)norma.Ilosc / (decimal)norma.IloscMat;

                        // Mnożymy przez ilość z koszyka
                        laczneZapotrzebowanie += poz.Ilosc * ileMatNaJednostke;
                    }
                    else
                    {
                        raport.AppendLine($"- UWAGA: Brak normy w systemie dla pary: {poz.NazwaProduktu} + {poz.NazwaMaterialu}.");
                    }
                }

                // POBIERANIE STANU MAGAZYNOWEGO
                // 1. Suma z dostaw (Co wjechało)
                decimal wjechalo = _db.SzczegolyDostawy
                                      .Where(d => d.IdMaterial == idMat)
                                      .Sum(d => (decimal?)d.Liczba) ?? 0;

                // 2. Suma zużycia (Co zeszło) - ZMIEŃ TO gdy dodasz tabelę zużycia!
                decimal wyjechalo = 0;
                // Przykład w przyszłości: _db.ZuzycieMaterialu.Where(z => z.IdMaterial == idMat).Sum(z => (decimal?)z.Ilosc) ?? 0;

                decimal stanMagazynu = wjechalo - wyjechalo;

                // Porównujemy zapotrzebowanie ze stanem magazynowym
                if (stanMagazynu < laczneZapotrzebowanie)
                {
                    decimal brakuje = laczneZapotrzebowanie - stanMagazynu;
                    raport.AppendLine($"- {grupa.Key.NazwaMaterialu}: BRAKUJE {Math.Round(brakuje, 2)} kg (Zapotrzebowanie: {Math.Round(laczneZapotrzebowanie, 2)} kg | Na stanie: {Math.Round(stanMagazynu, 2)} kg)");
                }
            }

            return raport.ToString();
        }

        // ==========================================
        // Puste zdarzenia (odpięte/nieużywane w tej chwili, pozostawione na przyszłość)
        // ==========================================
        private void comboBox_Produkt_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox_Material_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numericUpDown_Ilosc_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDown_Cena_ValueChanged(object sender, EventArgs e) { }
        private void textBox_Uwagi_TextChanged(object sender, EventArgs e) { }
        private void dataGridView_Koszyk_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
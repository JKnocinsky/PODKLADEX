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
            if (_koszyk.Count == 0)
            {
                MessageBox.Show("Koszyk jest pusty! Dodaj przynajmniej jeden produkt przed przejściem do danych klienta.", "Brak produktów", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tworzymy KROK 2 (Dane klienta)
            Form_Zamowienie formKlient = new Form_Zamowienie(_koszyk);

            // --- KLUCZOWA ZMIANA: Ustawiamy formularz tak, aby zachowywał się jak element panelu ---
            formKlient.TopLevel = false;
            formKlient.FormBorderStyle = FormBorderStyle.None;
            formKlient.Dock = DockStyle.Fill;

            // Pobieramy panel z głównego okna (ten, w którym aktualnie jest nasz koszyk)
            Panel parentPanel = (Panel)this.Parent;
            parentPanel.Controls.Add(formKlient); // Dodajemy do niego formularz klienta

            formKlient.BringToFront(); // Wysuwamy na wierzch
            formKlient.Show();         // Wyświetlamy

            // Ukrywamy obecny formularz (koszyk) - użytkownik widzi teraz płynne przejście
            this.Hide();

            // Dodajemy sprytną logikę: co ma się stać, gdy okno klienta zostanie zamknięte?
            formKlient.FormClosed += (s, args) =>
            {
                // Sprawdzamy, w jaki sposób zakończono pracę w oknie klienta
                if (formKlient.DialogResult == DialogResult.OK)
                {
                    // Jeśli zamówienie zostało poprawnie zapisane do bazy, zamykamy cały proces
                    this.Close();
                }
                else
                {
                    // Jeśli użytkownik anulował lub kliknął "Powrót", ponownie pokazujemy koszyk
                    this.Show();
                }
            };
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
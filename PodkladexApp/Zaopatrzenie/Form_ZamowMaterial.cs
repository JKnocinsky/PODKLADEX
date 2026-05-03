using PodkladexApp.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_ZamowMaterial : Form
    {


        // 1. Inicjalizacja kontekstu bazy danych
        private PodkladexContext _db = new PodkladexContext();

        // 2. Koszyk przechowujący pozycje (Twoja klasa ElementKoszykaDostawy)
        private BindingList<ElementKoszykaDostawy> _koszyk = new BindingList<ElementKoszykaDostawy>();

        private void dataGridView_Koszyk_SelectionChanged(object sender, EventArgs e)
        {
            // Jeśli zaznaczono dokładnie jeden wiersz, skopiuj z niego dane do okienek wprowadzania
            if (dataGridView_Koszyk.SelectedRows.Count == 1)
            {
                var wybranyElement = (ElementKoszykaDostawy)dataGridView_Koszyk.SelectedRows[0].DataBoundItem;

                comboBox_Material.SelectedValue = wybranyElement.IdMaterialu;
                numericUpDown_Ilosc.Value = wybranyElement.Liczba;
                numericUpDown_Cena.Value = wybranyElement.CenaZaKg;
            }
        }

        public Form_ZamowMaterial()
        {
            InitializeComponent();

            // Podpinamy zdarzenie Load (możesz to też wyklikać w Designerze)
            this.Load += Form_ZamowMaterial_Load;
        }

        private void Form_ZamowMaterial_Load(object sender, EventArgs e)
        {
            // 1. Podpięcie koszyka pod DataGridView
            dataGridView_Koszyk.DataSource = _koszyk;
            FormatujTabele();

            // 2. Ładowanie Firm (Dostawców)
            comboBox_Firma.DataSource = _db.Firma.ToList();
            comboBox_Firma.DisplayMember = "Nazwa";
            comboBox_Firma.ValueMember = "IdFirma";
            comboBox_Firma.SelectedIndex = -1;

            // 3. Ładowanie aktywnych pracowników
            var dzis = DateOnly.FromDateTime(DateTime.Now);
            var aktywniPracownicy = _db.Pracownik
                .Where(p => p.Umowa.Any(u => u.DataZak >= dzis))
                .Select(p => new
                {
                    IdPracownik = p.IdPracownik,
                    Dane = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko
                }).ToList();

            comboBox1.DataSource = aktywniPracownicy;
            comboBox1.DisplayMember = "Dane";
            comboBox1.ValueMember = "IdPracownik";
            comboBox1.SelectedIndex = -1;

            // 4. Ładowanie Materiałów do wyboru
            var materialyZGruboscia = _db.Material
                .Select(m => new
                {
                    IdMaterial = m.IdMaterial,
                    PelnaNazwa = m.Nazwa + " || " +
                                 (m.MaterialWlasciwosci.Any() ? m.MaterialWlasciwosci.FirstOrDefault().WartoscNominalna.ToString() : "Brak wymiaru") + " || " +
                                 (m.IdRodzajNavigation != null ? m.IdRodzajNavigation.Nazwa : "Brak rodzaju")
                }).ToList();

            comboBox_Material.DataSource = materialyZGruboscia;
            comboBox_Material.DisplayMember = "PelnaNazwa";
            comboBox_Material.ValueMember = "IdMaterial";
            comboBox_Material.SelectedIndex = -1;

            // 5. Ustawienie domyślnej daty
            dateTimePicker_data.Value = DateTime.Now;

            // =======================================================
            // 6. KULOODPORNE PODPIĘCIE PRZYCISKÓW (Tylko 1 wykonanie)
            // =======================================================
            button_DodajPozycje.Click -= button_DodajPozycje_Click;
            button_DodajPozycje.Click += button_DodajPozycje_Click;

            button_usun_z_zamowienia.Click -= button_usun_z_zamowienia_Click;
            button_usun_z_zamowienia.Click += button_usun_z_zamowienia_Click;

            button_edytuj_zamowienie.Click -= button_edytuj_zamowienie_Click;
            button_edytuj_zamowienie.Click += button_edytuj_zamowienie_Click;

            button_PrzejdzDalej.Click -= button_PrzejdzDalej_Click;
            button_PrzejdzDalej.Click += button_PrzejdzDalej_Click;

            button_powrot.Click -= button_powrot_Click;
            button_powrot.Click += button_powrot_Click;

            dataGridView_Koszyk.SelectionChanged -= dataGridView_Koszyk_SelectionChanged;
            dataGridView_Koszyk.SelectionChanged += dataGridView_Koszyk_SelectionChanged;
        }


        private void FormatujTabele()
        {
            if (dataGridView_Koszyk == null) return;

            dataGridView_Koszyk.AllowUserToAddRows = false;
            dataGridView_Koszyk.AllowUserToDeleteRows = false;
            dataGridView_Koszyk.ReadOnly = true;
            dataGridView_Koszyk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Koszyk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Koszyk.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView_Koszyk.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            if (dataGridView_Koszyk.Columns.Count > 0)
            {
                dataGridView_Koszyk.Columns["IdMaterialu"].Visible = false;
                dataGridView_Koszyk.Columns["NazwaMaterialu"].HeaderText = "Materiał";
                dataGridView_Koszyk.Columns["Liczba"].HeaderText = "Liczba [kg]";
                dataGridView_Koszyk.Columns["CenaZaKg"].HeaderText = "Cena za kilogram [zł]";
                dataGridView_Koszyk.Columns["CenaZaKg"].DefaultCellStyle.Format = "C2";
                dataGridView_Koszyk.Columns["WartoscCalkowita"].HeaderText = "Wartość materiału [zł]";
                dataGridView_Koszyk.Columns["WartoscCalkowita"].DefaultCellStyle.Format = "C2";
            }
        }

        // ==========================================
        // PRZYCISKI KOSZYKA (Z Twoimi nazwami)
        // ==========================================

        private void button_DodajPozycje_Click(object sender, EventArgs e)
        {
            if (comboBox_Material.SelectedValue == null || numericUpDown_Ilosc.Value <= 0)
            {
                MessageBox.Show("Wybierz materiał i podaj ilość większą od 0.");
                return;
            }

            int idWybranegoMaterialu = (int)comboBox_Material.SelectedValue;
            string sklejonaNazwa = comboBox_Material.Text;

            // KLUCZOWA ZMIANA: Szukamy w koszyku elementu o tym samym ID *ORAZ* tej samej Cenie!
            var istniejacy = _koszyk.FirstOrDefault(x => x.IdMaterialu == idWybranegoMaterialu && x.CenaZaKg == numericUpDown_Cena.Value);

            if (istniejacy != null)
            {
                // Jeśli jest już taki materiał z taką samą ceną -> zsumuj kilogramy
                istniejacy.Liczba += numericUpDown_Ilosc.Value;
                _koszyk.ResetBindings();
            }
            else
            {
                // Jeśli to nowy materiał, LUB ten sam materiał ale z INNĄ ceną -> stwórz nową pozycję w koszyku
                _koszyk.Add(new ElementKoszykaDostawy
                {
                    IdMaterialu = idWybranegoMaterialu,
                    NazwaMaterialu = sklejonaNazwa,
                    Liczba = numericUpDown_Ilosc.Value,
                    CenaZaKg = numericUpDown_Cena.Value
                });
            }

            FormatujTabele();
            WyczyscPolaWprowadzania();

            // Odznaczamy wiersze w tabeli po dodaniu, aby wyczyścić wybór
            dataGridView_Koszyk.ClearSelection();
        }

        private void button_usun_z_zamowienia_Click(object sender, EventArgs e)
        {
            if (dataGridView_Koszyk.SelectedRows.Count > 0)
            {
                var indeks = dataGridView_Koszyk.SelectedRows[0].Index;
                _koszyk.RemoveAt(indeks);
            }
            else
            {
                MessageBox.Show("Wybierz element z tabeli do usunięcia.");
            }
        }

        private void button_edytuj_zamowienie_Click(object sender, EventArgs e)
        {
            if (dataGridView_Koszyk.SelectedRows.Count > 0)
            {
                if (comboBox_Material.SelectedValue == null || numericUpDown_Ilosc.Value <= 0)
                {
                    MessageBox.Show("Wybierz materiał i podaj ilość większą od 0.");
                    return;
                }

                // Pobieramy zaznaczony wiersz
                var wybranyElement = (ElementKoszykaDostawy)dataGridView_Koszyk.SelectedRows[0].DataBoundItem;

                // Nadpisujemy go nowymi wartościami z kontrolek
                wybranyElement.IdMaterialu = (int)comboBox_Material.SelectedValue;
                wybranyElement.NazwaMaterialu = comboBox_Material.Text;
                wybranyElement.Liczba = numericUpDown_Ilosc.Value;
                wybranyElement.CenaZaKg = numericUpDown_Cena.Value;

                // Zmuszamy koszyk do odświeżenia widoku
                _koszyk.ResetBindings();

                WyczyscPolaWprowadzania();
                dataGridView_Koszyk.ClearSelection();
            }
            else
            {
                MessageBox.Show("Wybierz element z tabeli, który chcesz zaktualizować.");
            }
        }

        private void WyczyscPolaWprowadzania()
        {
            comboBox_Material.SelectedIndex = -1;
            numericUpDown_Ilosc.Value = 0;
            numericUpDown_Cena.Value = 0;
        }

        // ==========================================
        // FINALIZACJA I POWRÓT
        // ==========================================

        private void button_PrzejdzDalej_Click(object sender, EventArgs e)
        {
            if (comboBox_Firma.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz dostawcę (firmę).", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz pracownika przyjmującego dostawę.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_koszyk.Count == 0)
            {
                MessageBox.Show("Koszyk jest pusty! Dodaj materiały do zamówienia.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nowaDostawa = new Dostawa
                {
                    IdFirma = (int)comboBox_Firma.SelectedValue,
                    IdPracownik = (int)comboBox1.SelectedValue,
                    DataDostawy = DateOnly.FromDateTime(dateTimePicker_data.Value)
                };

                _db.Dostawa.Add(nowaDostawa);
                _db.SaveChanges();

                foreach (var pozycja in _koszyk)
                {
                    var szczegol = new SzczegolyDostawy
                    {
                        IdDostawa = nowaDostawa.IdDostawa,
                        IdMaterial = pozycja.IdMaterialu,
                        Liczba = pozycja.Liczba,
                        Cena = pozycja.CenaZaKg
                    };
                    _db.SzczegolyDostawy.Add(szczegol);
                }

                _db.SaveChanges();

                MessageBox.Show("Zamówienie materiału zostało pomyślnie zrealizowane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Zamykamy formularz po pomyślnym zapisie!
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu do bazy: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_powrot_Click(object sender, EventArgs e)
        {
            // Zamyka obecny formularz i wraca do poprzedniego
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // USUŃ: _db.Dispose();
            // Entity Framework Core posiada wbudowany Garbage Collector, 
            // który samodzielnie i o wiele bezpieczniej zwalnia zasoby 
            // po całkowitym zamknięciu i wyczyszczeniu formularza z pamięci.
            base.OnFormClosed(e);
        }

        // Zostawiłem puste metody z Twojego kodu, żeby nic Ci się nie rozsypało w Designerze
        private void comboBox_Firma_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox_Material_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numericUpDown_Ilosc_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDown_Cena_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker_data_ValueChanged(object sender, EventArgs e) { }
        private void textBox_Uwagi_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dataGridView_Koszyk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
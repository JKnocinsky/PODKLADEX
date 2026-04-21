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
            // Otwiera Twój formularz do dodawania (zgodnie z oryginalnym kodem)
            Form_Nowa_Firma form_Nowa_Firma = new Form_Nowa_Firma();
            form_Nowa_Firma.Show();
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
            if (comboBox_Nazwa_firmy.SelectedItem != null && comboBox_Nazwa_firmy.SelectedItem is Firma)
            {
                // Rzutowanie na model bazy danych
                Firma wybranaFirma = (Firma)comboBox_Nazwa_firmy.SelectedItem;

                // Wypełniamy TextBoxy z panelu
                textBox_NazwaFirmy.Text = wybranaFirma.Nazwa;
                textBox_Miejscowosc_firmy.Text = wybranaFirma.Miejscowosc;
                textBox_Kod_pocztowy_firmy.Text = wybranaFirma.KodPocztowy;
                textBox_Ulica_firmy.Text = wybranaFirma.Ulica;
                textBox_Numer_firmy.Text = wybranaFirma.Numer;
                textBox_NIP_firmy.Text = wybranaFirma.Nip;

                // Pokazujemy od razu cały Twój Panel z uzupełnionymi polami!
                panel_dane_firmy.Visible = true;
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
    }
}
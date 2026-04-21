using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PodkladexApp
{
    public partial class Form_Firma_edycja : Form
    {
        public Form_Firma_edycja()
        {
            InitializeComponent();
        }


        private void textBox_Miejscowosc_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Kod_pocztowy_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Ulica_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Numer_firmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_NIP_firmy_TextChanged(object sender, EventArgs e)
        {

        }


        private void label_ulica_Click(object sender, EventArgs e)
        {

        }

        private void Nowa_Firma_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_NIP_Click(object sender, EventArgs e)
        {

        }

        private void textBox_NazwaFirmy_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Dodaj_nowa_firme_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Kod_pocztowy_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_Miejscowosc_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_NazwaFirmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_NIP_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_Ulica_firmy.Text) ||
                string.IsNullOrWhiteSpace(textBox_Numer_firmy.Text))

            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!",
                                "Błąd",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
        }

    }
    }


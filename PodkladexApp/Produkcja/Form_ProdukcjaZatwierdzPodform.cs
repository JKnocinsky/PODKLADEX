using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace PodkladexApp.Produkcja
{
    public partial class Form_ProdukcjaZatwierdzPodform : Form
    {
        PodkladexContext db;
        private int _idProdukcja;

        public Form_ProdukcjaZatwierdzPodform(PodkladexContext db, int idProdukcja, decimal iloscWyprodukowana, decimal iloscOdpadow)
        {
            InitializeComponent();
            this.db = db;
            this._idProdukcja = idProdukcja;

            txt_wyprodukowano.Text = iloscWyprodukowana.ToString("0.##");
            txt_odpady.Text = iloscOdpadow.ToString("0.##");
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            // Parsowanie wartości (lokalizacja uwzględniona)
            decimal? wyprodukowano = null;
            decimal? odpady = null;

            if (!string.IsNullOrWhiteSpace(txt_wyprodukowano.Text))
            {
                if (!decimal.TryParse(txt_wyprodukowano.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var w))
                {
                    MessageBox.Show("Nieprawidłowa wartość w polu 'Wyprodukowano'. Wprowadź liczbę zmiennoprzecinkową.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                wyprodukowano = w;
            }

            if (!string.IsNullOrWhiteSpace(txt_odpady.Text))
            {
                if (!decimal.TryParse(txt_odpady.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var o))
                {
                    MessageBox.Show("Nieprawidłowa wartość w polu 'Odpady'. Wprowadź liczbę zmiennoprzecinkową.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                odpady = o;
            }

            try
            {
                var prod = db.Produkcja.FirstOrDefault(p => p.IdProdukcja == _idProdukcja);
                if (prod == null)
                {
                    MessageBox.Show("Nie znaleziono rekordu produkcji o podanym Id.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                prod.Wyprodukowano = wyprodukowano;
                prod.Odpady = odpady;

                db.SaveChanges();

                MessageBox.Show("Dane zostały zapisane.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

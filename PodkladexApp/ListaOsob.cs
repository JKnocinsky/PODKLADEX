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
using PodkladexApp.Models;

namespace PodkladexApp
{
    public partial class ListaOsob : Form
    {
        private PodkladexContext db;

        public ListaOsob()
        {
            InitializeComponent();

            db = new PodkladexContext();

            ZaladujOsobyDoComboBox();
        }

        private void ZaladujOsobyDoComboBox()
        {
            try
            {
                var osoby = db.Osoba
                    .ToList()
                    .Select(o => new
                    {
                        IdOsoba = o.IdOsoba,
                        PelnaNazwa = o.Imie + " " + o.Nazwisko
                    })
                    .ToList();

                comboBox_idosoby.DataSource = osoby;
                comboBox_idosoby.DisplayMember = "PelnaNazwa";
                comboBox_idosoby.ValueMember = "IdOsoba";
                comboBox_idosoby.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania osób z bazy:\n" + ex.Message);
            }
        }

        private void ZaladujDaneOsobyDoPol(int idOsoby)
        {
            try
            {
                var osoba = db.Osoba.FirstOrDefault(o => o.IdOsoba == idOsoby);

                if (osoba == null)
                {
                    MessageBox.Show("Nie znaleziono osoby.");
                    return;
                }

                panel_daneosoby.Visible = true;

                textBox_imie.Text = osoba.Imie;
                textBox_nazwisko.Text = osoba.Nazwisko;
                textBox_numertelefonu.Text = osoba.NrTelefonu;
                textBox_email.Text = osoba.AdresEMail;
                textBox_miejscowosc.Text = osoba.Miejscowosc;
                textBox_kodpocztowy.Text = osoba.KodPocztowy;
                textBox_ulica.Text = osoba.Ulica;
                textBox_numer.Text = osoba.Numer;
                textBox_pesel.Text = osoba.Pesel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania danych osoby:\n" + ex.Message);
            }
        }

        private void comboBox_idosoby_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBox_idosoby.SelectedIndex == -1 || comboBox_idosoby.SelectedValue == null)
                return;

            try
            {
                int idOsoby = (int)comboBox_idosoby.SelectedValue;
                ZaladujDaneOsobyDoPol(idOsoby);
            }
            catch
            {
                // zabezpieczenie na moment bindowania DataSource
            }
        }
    }
}

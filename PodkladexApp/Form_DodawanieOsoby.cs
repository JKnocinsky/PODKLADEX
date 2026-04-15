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
    public partial class Form_DodawanieOsoby : Form
    {
        private PodkladexContext db;

        public Form_DodawanieOsoby()
        {
            InitializeComponent();

            db = new PodkladexContext();
            btn_dodaj.Click += btn_dodaj_Click;
        }

        private void btn_dodaj_Click(object? sender, EventArgs e)
        {
            if (!CzyWszystkiePolaUzupelnione())
            {
                MessageBox.Show(
                    "Nie wszystkie pola zostały uzupełnione.\nWypełnij wszystkie dane przed dodaniem osoby.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult wynik = MessageBox.Show(
                "Czy na pewno chcesz dodać nową osobę?",
                "Potwierdzenie dodania",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (wynik == DialogResult.No)
            {
                return;
            }

            try
            {
                Osoba nowaOsoba = new Osoba
                {
                    Imie = textBox_imie.Text.Trim(),
                    Nazwisko = textBox_nazwisko.Text.Trim(),
                    NrTelefonu = textBox_numertelefonu.Text.Trim(),
                    AdresEMail = textBox_email.Text.Trim(),
                    Miejscowosc = textBox_miejscowosc.Text.Trim(),
                    KodPocztowy = textBox_kodpocztowy.Text.Trim(),
                    Ulica = textBox_ulica.Text.Trim(),
                    Numer = textBox_numer.Text.Trim(),
                    Pesel = textBox_pesel.Text.Trim()
                };

                db.Osoba.Add(nowaOsoba);
                db.SaveChanges();

                MessageBox.Show(
                    "Nowa osoba została dodana poprawnie.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Wystąpił błąd podczas dodawania osoby:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool CzyWszystkiePolaUzupelnione()
        {
            return !string.IsNullOrWhiteSpace(textBox_imie.Text)
                && !string.IsNullOrWhiteSpace(textBox_nazwisko.Text)
                && !string.IsNullOrWhiteSpace(textBox_numertelefonu.Text)
                && !string.IsNullOrWhiteSpace(textBox_email.Text)
                && !string.IsNullOrWhiteSpace(textBox_miejscowosc.Text)
                && !string.IsNullOrWhiteSpace(textBox_kodpocztowy.Text)
                && !string.IsNullOrWhiteSpace(textBox_ulica.Text)
                && !string.IsNullOrWhiteSpace(textBox_numer.Text)
                && !string.IsNullOrWhiteSpace(textBox_pesel.Text);
        }
    }
}
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

namespace PodkladexApp
{
    public partial class Form_KontrolaProd : Form
    {
        PodkladexContext _context;

        private enum TrybPracy { Brak, Dodawanie, Edycja, Usuwanie }
        private TrybPracy aktualnyTryb = TrybPracy.Brak;

        public Form_KontrolaProd(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            // Rejestracja zdarzeń
            this.Load += Form_KontrolaProd_Load;
            this.btn_KontProdDodaj.Click += btn_KontProdDodaj_Click;
            this.btn_KontProdEdytuj.Click += btn_KontProdEdytuj_Click;
            this.btn_KontProdUsun.Click += btn_KontProdUsun_Click;
            this.btn_KontProdPotwierdz.Click += btn_KontProdPotwierdz_Click;
            this.comboBox_KontProdKont.SelectedIndexChanged += comboBox_KontProdKont_SelectedIndexChanged;
        }

        private void Form_KontrolaProd_Load(object sender, EventArgs e)
        {
            UkryjWszystko();
            OdswiezDane();
        }

        private void UkryjWszystko()
        {
            // Ukrywanie pól wejściowych i reset ich stanu
            comboBox_KontProdPrac.Visible = false;
            comboBox_KontProdPrac.Enabled = true;
            comboBox_KontProdPrac.SelectedIndex = -1;

            textBox_KontProdRBH.Visible = false;
            textBox_KontProdRBH.ReadOnly = false;
            textBox_KontProdRBH.Clear();

            checkBox_KontProdZat.Visible = false;
            checkBox_KontProdZat.Enabled = true;
            checkBox_KontProdZat.Checked = false;

            textBox_KontProdOdpady.Visible = false;
            textBox_KontProdOdpady.ReadOnly = false;
            textBox_KontProdOdpady.Clear();

            comboBox_KontProdZadP.Visible = false;
            comboBox_KontProdZadP.Enabled = true;
            comboBox_KontProdZadP.SelectedIndex = -1;

            comboBox_KontProdKont.Visible = false;
            btn_KontProdPotwierdz.Visible = false;

            // Ukrywanie etykiet
            label_KontProdPrac.Visible = false;
            label_KontProdRBH.Visible = false;
            label_KontProdZat.Visible = false;
            label_KontProdOdpady.Visible = false;
            label_KontProdZadP.Visible = false;
            label_KontProdKont.Visible = false;
        }

        private void OdswiezDane()
        {
            // Główna lista kontroli produkcji
            comboBox_KontProdKont.DataSource = _context.KontrolaProd.ToList();
            comboBox_KontProdKont.DisplayMember = "IdKontrolaProd"; // Podmień jeśli klucz to np. IdKontrolaP
            comboBox_KontProdKont.ValueMember = "IdKontrolaProd";
            comboBox_KontProdKont.SelectedIndex = -1;

            // Pracownicy z połączonym imieniem i nazwiskiem
            comboBox_KontProdPrac.DataSource = _context.Pracownik
                .Select(p => new
                {
                    p.IdPracownik,
                    PelneNazwisko = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko
                })
                .ToList();
            comboBox_KontProdPrac.DisplayMember = "PelneNazwisko";
            comboBox_KontProdPrac.ValueMember = "IdPracownik";
            comboBox_KontProdPrac.SelectedIndex = -1;

            // Lista zadań produkcyjnych
            comboBox_KontProdZadP.DataSource = _context.ZadanieProdukcyjne.ToList();
            comboBox_KontProdZadP.DisplayMember = "IdZadanieP";
            comboBox_KontProdZadP.ValueMember = "IdZadanieP";
            comboBox_KontProdZadP.SelectedIndex = -1;
        }

        private void PokazPolaEdycji()
        {
            label_KontProdPrac.Visible = true;
            comboBox_KontProdPrac.Visible = true;

            label_KontProdRBH.Visible = true;
            textBox_KontProdRBH.Visible = true;

            label_KontProdZat.Visible = true;
            checkBox_KontProdZat.Visible = true;

            label_KontProdOdpady.Visible = true;
            textBox_KontProdOdpady.Visible = true;

            label_KontProdZadP.Visible = true;
            comboBox_KontProdZadP.Visible = true;
        }

        private void btn_KontProdDodaj_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Dodawanie;
            UkryjWszystko();
            PokazPolaEdycji();
            btn_KontProdPotwierdz.Visible = true;
        }

        private void btn_KontProdEdytuj_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Edycja;
            UkryjWszystko();

            label_KontProdKont.Visible = true;
            comboBox_KontProdKont.Visible = true;

            PokazPolaEdycji();
            btn_KontProdPotwierdz.Visible = true;
        }

        private void btn_KontProdUsun_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Usuwanie;
            UkryjWszystko();

            label_KontProdKont.Visible = true;
            comboBox_KontProdKont.Visible = true;

            PokazPolaEdycji();

            // Blokujemy możliwość edycji przy usuwaniu
            comboBox_KontProdPrac.Enabled = false;
            comboBox_KontProdZadP.Enabled = false;
            textBox_KontProdRBH.ReadOnly = true;
            textBox_KontProdOdpady.ReadOnly = true;
            checkBox_KontProdZat.Enabled = false;

            btn_KontProdPotwierdz.Visible = true;
        }

        private void comboBox_KontProdKont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_KontProdKont.SelectedItem != null)
            {
                var wybrany = (KontrolaProd)comboBox_KontProdKont.SelectedItem;

                comboBox_KontProdPrac.SelectedValue = wybrany.IdPracownik;
                comboBox_KontProdZadP.SelectedValue = wybrany.IdZadanieP;

                textBox_KontProdRBH.Text = wybrany.Rbh?.ToString();
                textBox_KontProdOdpady.Text = wybrany.Odpady?.ToString();
                checkBox_KontProdZat.Checked = wybrany.Zatwierdzone;
            }
        }

        private void btn_KontProdPotwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                // Walidacja czy wybrano z listy do edycji/usunięcia
                if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_KontProdKont.SelectedValue == null)
                {
                    MessageBox.Show("Proszę wybrać kontrolę produkcji z listy!", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Walidacja list rozwijanych (klucze obce) przy dodawaniu i edycji
                if (aktualnyTryb == TrybPracy.Dodawanie || aktualnyTryb == TrybPracy.Edycja)
                {
                    if (comboBox_KontProdPrac.SelectedValue == null || comboBox_KontProdZadP.SelectedValue == null)
                    {
                        MessageBox.Show("Wybierz pracownika i zadanie produkcyjne!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Parsowanie danych liczbowych (Rbh i Odpady mogą być nullem)
                decimal? rbh = string.IsNullOrWhiteSpace(textBox_KontProdRBH.Text) ? (decimal?)null : decimal.Parse(textBox_KontProdRBH.Text);
                decimal? odpady = string.IsNullOrWhiteSpace(textBox_KontProdOdpady.Text) ? (decimal?)null : decimal.Parse(textBox_KontProdOdpady.Text);

                if (aktualnyTryb == TrybPracy.Dodawanie)
                {
                    var nowa = new KontrolaProd
                    {
                        IdPracownik = (int)comboBox_KontProdPrac.SelectedValue,
                        IdZadanieP = (int)comboBox_KontProdZadP.SelectedValue,
                        Rbh = rbh,
                        Odpady = odpady,
                        Zatwierdzone = checkBox_KontProdZat.Checked
                    };
                    _context.KontrolaProd.Add(nowa);
                }
                else if (aktualnyTryb == TrybPracy.Edycja)
                {
                    int id = (int)comboBox_KontProdKont.SelectedValue;
                    var edytowana = _context.KontrolaProd.Find(id);

                    if (edytowana != null)
                    {
                        edytowana.IdPracownik = (int)comboBox_KontProdPrac.SelectedValue;
                        edytowana.IdZadanieP = (int)comboBox_KontProdZadP.SelectedValue;
                        edytowana.Rbh = rbh;
                        edytowana.Odpady = odpady;
                        edytowana.Zatwierdzone = checkBox_KontProdZat.Checked;
                    }
                }
                else if (aktualnyTryb == TrybPracy.Usuwanie)
                {
                    int id = (int)comboBox_KontProdKont.SelectedValue;
                    var doUsuniecia = _context.KontrolaProd.Find(id);

                    if (doUsuniecia != null)
                    {
                        DialogResult res = MessageBox.Show($"Czy na pewno usunąć kontrolę nr {id}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No) return;

                        _context.KontrolaProd.Remove(doUsuniecia);
                    }
                }

                _context.SaveChanges();
                MessageBox.Show("Operacja wykonana pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OdswiezDane();
                UkryjWszystko();
                aktualnyTryb = TrybPracy.Brak;
            }
            catch (FormatException)
            {
                MessageBox.Show("Nieprawidłowy format liczbowy w polach Rbh lub Odpady.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
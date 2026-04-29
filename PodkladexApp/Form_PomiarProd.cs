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
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_PomiarProd : Form
    {
        PodkladexContext _context;

        private enum TrybPracy { Brak, Dodawanie, Edycja, Usuwanie }
        private TrybPracy aktualnyTryb = TrybPracy.Brak;

        public Form_PomiarProd(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            // Rejestracja zdarzeń
            this.Load += Form_PomiarProd_Load;
            this.btn_PomiarProdDodaj.Click += btn_PomiarProdDodaj_Click;
            this.btn_PomiarProdEdytuj.Click += btn_PomiarProdEdytuj_Click;
            this.btn_PomiarProdUsun.Click += btn_PomiarProdUsun_Click;
            this.btn_PomiarProdPotwierdz.Click += btn_PomiarProdPotwierdz_Click;
            this.comboBox_PomiarProdPomiar.SelectedIndexChanged += comboBox_PomiarProdPomiar_SelectedIndexChanged;
        }

        private void Form_PomiarProd_Load(object sender, EventArgs e)
        {
            UkryjWszystko();
            OdswiezDane();
        }

        private void UkryjWszystko()
        {
            // Ukrywanie pól wejściowych i reset stanu
            comboBox_PomiarProdKont.Visible = false;
            comboBox_PomiarProdKont.Enabled = true;
            comboBox_PomiarProdKont.SelectedIndex = -1;

            comboBox_PomiarProdWlasc.Visible = false;
            comboBox_PomiarProdWlasc.Enabled = true;
            comboBox_PomiarProdWlasc.SelectedIndex = -1;

            textBox_PomiarProdWartosc.Visible = false;
            textBox_PomiarProdWartosc.ReadOnly = false;
            textBox_PomiarProdWartosc.Clear();

            comboBox_PomiarProdPomiar.Visible = false;
            btn_PomiarProdPotwierdz.Visible = false;

            // Ukrywanie etykiet
            label_PomiarProdKont.Visible = false;
            label_PomiarProdWlasc.Visible = false;
            label_PomiarProdWartosc.Visible = false;
            label_PomiarProdPomiar.Visible = false;
        }

        private void OdswiezDane()
        {
            // Lista pomiarów do wyboru - z czytelną nazwą z tabeli Wlasciwosc
            comboBox_PomiarProdPomiar.DataSource = _context.Pomiar
                .Include(p => p.IdWlasciwosciNavigation)
                .Select(p => new
                {
                    p.IdPomiar,
                    OpisPomiaru = "Pomiar nr " + p.IdPomiar + " - " + p.IdWlasciwosciNavigation.NazwaParametru
                })
                .ToList();
            comboBox_PomiarProdPomiar.DisplayMember = "OpisPomiaru";
            comboBox_PomiarProdPomiar.ValueMember = "IdPomiar";
            comboBox_PomiarProdPomiar.SelectedIndex = -1;

            // Słownik: Kontrola Produkcji
            comboBox_PomiarProdKont.DataSource = _context.KontrolaProd.ToList();
            comboBox_PomiarProdKont.DisplayMember = "IdKontrolaProd";
            comboBox_PomiarProdKont.ValueMember = "IdKontrolaProd";
            comboBox_PomiarProdKont.SelectedIndex = -1;

            // Słownik: Właściwości
            comboBox_PomiarProdWlasc.DataSource = _context.Wlasciwosc.ToList();
            comboBox_PomiarProdWlasc.DisplayMember = "NazwaParametru";
            comboBox_PomiarProdWlasc.ValueMember = "IdWlasciwosci";
            comboBox_PomiarProdWlasc.SelectedIndex = -1;
        }

        private void PokazPolaEdycji()
        {
            label_PomiarProdKont.Visible = true;
            comboBox_PomiarProdKont.Visible = true;

            label_PomiarProdWlasc.Visible = true;
            comboBox_PomiarProdWlasc.Visible = true;

            label_PomiarProdWartosc.Visible = true;
            textBox_PomiarProdWartosc.Visible = true;
        }

        private void btn_PomiarProdDodaj_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Dodawanie;
            UkryjWszystko();
            PokazPolaEdycji();
            btn_PomiarProdPotwierdz.Visible = true;
        }

        private void btn_PomiarProdEdytuj_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Edycja;
            UkryjWszystko();

            label_PomiarProdPomiar.Visible = true;
            comboBox_PomiarProdPomiar.Visible = true;

            PokazPolaEdycji();
            btn_PomiarProdPotwierdz.Visible = true;
        }

        private void btn_PomiarProdUsun_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Usuwanie;
            UkryjWszystko();

            label_PomiarProdPomiar.Visible = true;
            comboBox_PomiarProdPomiar.Visible = true;

            PokazPolaEdycji();

            // Zablokowanie edycji szczegółów przy usuwaniu
            comboBox_PomiarProdKont.Enabled = false;
            comboBox_PomiarProdWlasc.Enabled = false;
            textBox_PomiarProdWartosc.ReadOnly = true;

            btn_PomiarProdPotwierdz.Visible = true;
        }

        private void comboBox_PomiarProdPomiar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_PomiarProdPomiar.SelectedValue != null)
            {
                int selectedId = (int)comboBox_PomiarProdPomiar.SelectedValue;
                var wybrany = _context.Pomiar.Find(selectedId);

                if (wybrany != null)
                {
                    comboBox_PomiarProdKont.SelectedValue = wybrany.IdKontrolaProd;
                    comboBox_PomiarProdWlasc.SelectedValue = wybrany.IdWlasciwosci;
                    textBox_PomiarProdWartosc.Text = wybrany.WartoscZmierzona.ToString();
                }
            }
        }

        private void btn_PomiarProdPotwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                // Walidacja wyboru z głównej listy przy edycji/usuwaniu
                if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_PomiarProdPomiar.SelectedValue == null)
                {
                    MessageBox.Show("Proszę wybrać pomiar z listy!", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Walidacja uzupełnienia danych przy dodawaniu/edycji
                if (aktualnyTryb == TrybPracy.Dodawanie || aktualnyTryb == TrybPracy.Edycja)
                {
                    if (comboBox_PomiarProdKont.SelectedValue == null || comboBox_PomiarProdWlasc.SelectedValue == null || string.IsNullOrWhiteSpace(textBox_PomiarProdWartosc.Text))
                    {
                        MessageBox.Show("Proszę uzupełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (aktualnyTryb == TrybPracy.Dodawanie)
                {
                    var nowy = new Pomiar
                    {
                        IdKontrolaProd = (int)comboBox_PomiarProdKont.SelectedValue,
                        IdWlasciwosci = (int)comboBox_PomiarProdWlasc.SelectedValue,
                        WartoscZmierzona = decimal.Parse(textBox_PomiarProdWartosc.Text)
                    };
                    _context.Pomiar.Add(nowy);
                }
                else if (aktualnyTryb == TrybPracy.Edycja)
                {
                    int id = (int)comboBox_PomiarProdPomiar.SelectedValue;
                    var edytowany = _context.Pomiar.Find(id);

                    if (edytowany != null)
                    {
                        edytowany.IdKontrolaProd = (int)comboBox_PomiarProdKont.SelectedValue;
                        edytowany.IdWlasciwosci = (int)comboBox_PomiarProdWlasc.SelectedValue;
                        edytowany.WartoscZmierzona = decimal.Parse(textBox_PomiarProdWartosc.Text);
                    }
                }
                else if (aktualnyTryb == TrybPracy.Usuwanie)
                {
                    int id = (int)comboBox_PomiarProdPomiar.SelectedValue;
                    var doUsuniecia = _context.Pomiar.Find(id);

                    if (doUsuniecia != null)
                    {
                        DialogResult res = MessageBox.Show($"Czy na pewno usunąć pomiar nr {id}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No) return;

                        _context.Pomiar.Remove(doUsuniecia);
                    }
                }

                _context.SaveChanges();
                MessageBox.Show("Operacja zakończona sukcesem.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OdswiezDane();
                UkryjWszystko();
                aktualnyTryb = TrybPracy.Brak;
            }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadzono nieprawidłowy format wartości pomiaru. Upewnij się, że wpisano poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
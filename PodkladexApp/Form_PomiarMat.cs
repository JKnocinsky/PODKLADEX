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
    public partial class Form_PomiarMat : Form
    {
        PodkladexContext _context;

        private enum TrybPracy { Brak, Dodawanie, Edycja, Usuwanie }
        private TrybPracy aktualnyTryb = TrybPracy.Brak;

        public Form_PomiarMat(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            // Rejestracja zdarzeń
            this.Load += Form_PomiarMat_Load;
            this.btn_PomiarMatDodaj.Click += btn_PomiarMatDodaj_Click;
            this.btn_PomiarMatEdytuj.Click += btn_PomiarMatEdytuj_Click;
            this.btn_PomiarMatUsun.Click += btn_PomiarMatUsun_Click;
            this.btn_PomiarMatPotwierdz.Click += btn_PomiarMatPotwierdz_Click;
            this.comboBox_PomiarMatPomiar.SelectedIndexChanged += comboBox_PomiarMatPomiar_SelectedIndexChanged;
        }

        private void Form_PomiarMat_Load(object sender, EventArgs e)
        {
            UkryjWszystko();
            OdswiezDane();
        }

        private void UkryjWszystko()
        {
            // Ukrywanie pól wejściowych i reset stanu
            comboBox_PomiarMatKontMat.Visible = false;
            comboBox_PomiarMatKontMat.Enabled = true;
            comboBox_PomiarMatKontMat.SelectedIndex = -1;

            comboBox_PomiarMatWlasc.Visible = false;
            comboBox_PomiarMatWlasc.Enabled = true;
            comboBox_PomiarMatWlasc.SelectedIndex = -1;

            textBox_PomiarMatWartosc.Visible = false;
            textBox_PomiarMatWartosc.ReadOnly = false;
            textBox_PomiarMatWartosc.Clear();

            comboBox_PomiarMatPomiar.Visible = false;
            btn_PomiarMatPotwierdz.Visible = false;

            // Ukrywanie etykiet
            label_PomiarMatKontMat.Visible = false;
            label_PomiarMatWlasc.Visible = false;
            label_PomiarMatWartosc.Visible = false;
            label_PomiarMatPomiar.Visible = false;
        }

        private void OdswiezDane()
        {
            // Lista pomiarów do wyboru - z czytelną nazwą z tabeli Wlasciwosc
            comboBox_PomiarMatPomiar.DataSource = _context.PomiarMat
                .Include(p => p.IdWlasciwosciNavigation)
                .Select(p => new
                {
                    p.IdPomiarMat,
                    OpisPomiaru = "Pomiar nr " + p.IdPomiarMat + " - " + p.IdWlasciwosciNavigation.NazwaParametru
                })
                .ToList();
            comboBox_PomiarMatPomiar.DisplayMember = "OpisPomiaru";
            comboBox_PomiarMatPomiar.ValueMember = "IdPomiarMat";
            comboBox_PomiarMatPomiar.SelectedIndex = -1;

            // Słownik: Kontrola Materiału
            comboBox_PomiarMatKontMat.DataSource = _context.KontrolaMat.ToList();
            comboBox_PomiarMatKontMat.DisplayMember = "IdKontrolaMat";
            comboBox_PomiarMatKontMat.ValueMember = "IdKontrolaMat";
            comboBox_PomiarMatKontMat.SelectedIndex = -1;

            // Słownik: Właściwości - dopasowane do modelu z NazwaParametru i IdWlasciwosci
            comboBox_PomiarMatWlasc.DataSource = _context.Wlasciwosc.ToList();
            comboBox_PomiarMatWlasc.DisplayMember = "NazwaParametru";
            comboBox_PomiarMatWlasc.ValueMember = "IdWlasciwosci";
            comboBox_PomiarMatWlasc.SelectedIndex = -1;
        }

        private void PokazPolaEdycji()
        {
            label_PomiarMatKontMat.Visible = true;
            comboBox_PomiarMatKontMat.Visible = true;

            label_PomiarMatWlasc.Visible = true;
            comboBox_PomiarMatWlasc.Visible = true;

            label_PomiarMatWartosc.Visible = true;
            textBox_PomiarMatWartosc.Visible = true;
        }

        private void btn_PomiarMatDodaj_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Dodawanie;
            UkryjWszystko();
            PokazPolaEdycji();
            btn_PomiarMatPotwierdz.Visible = true;
        }

        private void btn_PomiarMatEdytuj_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Edycja;
            UkryjWszystko();
            label_PomiarMatPomiar.Visible = true;
            comboBox_PomiarMatPomiar.Visible = true;
            PokazPolaEdycji();
            btn_PomiarMatPotwierdz.Visible = true;
        }

        private void btn_PomiarMatUsun_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Usuwanie;
            UkryjWszystko();
            label_PomiarMatPomiar.Visible = true;
            comboBox_PomiarMatPomiar.Visible = true;
            PokazPolaEdycji();

            comboBox_PomiarMatKontMat.Enabled = false;
            comboBox_PomiarMatWlasc.Enabled = false;
            textBox_PomiarMatWartosc.ReadOnly = true;

            btn_PomiarMatPotwierdz.Visible = true;
        }

        private void comboBox_PomiarMatPomiar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_PomiarMatPomiar.SelectedValue != null)
            {
                int selectedId = (int)comboBox_PomiarMatPomiar.SelectedValue;
                var wybrany = _context.PomiarMat.Find(selectedId);

                if (wybrany != null)
                {
                    comboBox_PomiarMatKontMat.SelectedValue = wybrany.IdKontrolaMat;
                    comboBox_PomiarMatWlasc.SelectedValue = wybrany.IdWlasciwosci;
                    textBox_PomiarMatWartosc.Text = wybrany.WartoscZmierzona.ToString();
                }
            }
        }

        private void btn_PomiarMatPotwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_PomiarMatPomiar.SelectedValue == null)
                {
                    MessageBox.Show("Proszę wybrać pomiar z listy!", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (aktualnyTryb == TrybPracy.Dodawanie || aktualnyTryb == TrybPracy.Edycja)
                {
                    if (comboBox_PomiarMatKontMat.SelectedValue == null || comboBox_PomiarMatWlasc.SelectedValue == null || string.IsNullOrWhiteSpace(textBox_PomiarMatWartosc.Text))
                    {
                        MessageBox.Show("Proszę uzupełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (aktualnyTryb == TrybPracy.Dodawanie)
                {
                    var nowy = new PomiarMat
                    {
                        IdKontrolaMat = (int)comboBox_PomiarMatKontMat.SelectedValue,
                        IdWlasciwosci = (int)comboBox_PomiarMatWlasc.SelectedValue,
                        WartoscZmierzona = decimal.Parse(textBox_PomiarMatWartosc.Text)
                    };
                    _context.PomiarMat.Add(nowy);
                }
                else if (aktualnyTryb == TrybPracy.Edycja)
                {
                    int id = (int)comboBox_PomiarMatPomiar.SelectedValue;
                    var edytowany = _context.PomiarMat.Find(id);
                    if (edytowany != null)
                    {
                        edytowany.IdKontrolaMat = (int)comboBox_PomiarMatKontMat.SelectedValue;
                        edytowany.IdWlasciwosci = (int)comboBox_PomiarMatWlasc.SelectedValue;
                        edytowany.WartoscZmierzona = decimal.Parse(textBox_PomiarMatWartosc.Text);
                    }
                }
                else if (aktualnyTryb == TrybPracy.Usuwanie)
                {
                    int id = (int)comboBox_PomiarMatPomiar.SelectedValue;
                    var doUsuniecia = _context.PomiarMat.Find(id);
                    if (doUsuniecia != null)
                    {
                        DialogResult res = MessageBox.Show($"Czy na pewno usunąć pomiar nr {id}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No) return;
                        _context.PomiarMat.Remove(doUsuniecia);
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
                MessageBox.Show("Błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
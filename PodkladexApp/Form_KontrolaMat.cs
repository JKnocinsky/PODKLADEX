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
    public partial class Form_KontrolaMat : Form
    {
        PodkladexContext _context;

        private enum TrybPracy { Brak, Dodawanie, Edycja, Usuwanie }
        private TrybPracy aktualnyTryb = TrybPracy.Brak;

        public Form_KontrolaMat(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            // Rejestracja zdarzeń
            this.Load += Form_KontrolaMat_Load;
            this.btn_DodajKontMat.Click += btn_DodajKontMat_Click;
            this.btn_EdytujKontMat.Click += btn_EdytujKontMat_Click;
            this.btn_UsunKontMat.Click += btn_UsunKontMat_Click;
            this.btn_KontMatPotwierdz.Click += btn_KontMatPotwierdz_Click;
            this.comboBox_KontMatKont.SelectedIndexChanged += comboBox_KontMatKont_SelectedIndexChanged;
        }

        private void Form_KontrolaMat_Load(object sender, EventArgs e)
        {
            UkryjWszystko();
            OdswiezDane();
        }

        private void UkryjWszystko()
        {
            // Ukrywanie pól i list
            comboBox_KontMatPrac.Visible = false;
            comboBox_KontMatPrac.Enabled = true;

            textBox_KontMatRBH.Visible = false;
            textBox_KontMatRBH.ReadOnly = false;
            textBox_KontMatRBH.Clear();

            checkBox_KontrolaMatZat.Visible = false;
            checkBox_KontrolaMatZat.Enabled = true;
            checkBox_KontrolaMatZat.Checked = false;

            textBox_KontMatOdpady.Visible = false;
            textBox_KontMatOdpady.ReadOnly = false;
            textBox_KontMatOdpady.Clear();

            comboBox_KontMatZadP.Visible = false;
            comboBox_KontMatZadP.Enabled = true;

            comboBox_KontMatMaterial.Visible = false;
            comboBox_KontMatMaterial.Enabled = true;

            comboBox_KontMatKont.Visible = false;
            btn_KontMatPotwierdz.Visible = false;

            // Ukrywanie etykiet
            label_KontMatPrac.Visible = false;
            label_KontMatRBH.Visible = false;
            label_KontMatZat.Visible = false;
            label_KontMatOdpady.Visible = false;
            label_KontMatZadP.Visible = false;
            label_KontMatMateral.Visible = false;
            label_KontMatKontrola.Visible = false;
        }

        private void OdswiezDane()
        {
            // Główna lista kontroli
            comboBox_KontMatKont.DataSource = _context.KontrolaMat.ToList();
            comboBox_KontMatKont.DisplayMember = "IdKontrolaMat";
            comboBox_KontMatKont.ValueMember = "IdKontrolaMat";
            comboBox_KontMatKont.SelectedIndex = -1;

            // Łączenie pracownika z danymi osoby dla czytelnego wyświetlania imienia i nazwiska
            comboBox_KontMatPrac.DataSource = _context.Pracownik
                .Select(p => new
                {
                    p.IdPracownik,
                    PelneNazwisko = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko
                })
                .ToList();
            comboBox_KontMatPrac.DisplayMember = "PelneNazwisko";
            comboBox_KontMatPrac.ValueMember = "IdPracownik";
            comboBox_KontMatPrac.SelectedIndex = -1;

            comboBox_KontMatZadP.DataSource = _context.ZadanieProdukcyjne.ToList();
            comboBox_KontMatZadP.DisplayMember = "IdZadanieP";
            comboBox_KontMatZadP.ValueMember = "IdZadanieP";
            comboBox_KontMatZadP.SelectedIndex = -1;

            comboBox_KontMatMaterial.DataSource = _context.Material.ToList();
            comboBox_KontMatMaterial.DisplayMember = "Nazwa";
            comboBox_KontMatMaterial.ValueMember = "IdMaterial";
            comboBox_KontMatMaterial.SelectedIndex = -1;
        }

        private void btn_DodajKontMat_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Dodawanie;
            UkryjWszystko();
            PokazPolaEdycji();
            btn_KontMatPotwierdz.Visible = true;
        }

        private void btn_EdytujKontMat_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Edycja;
            UkryjWszystko();
            label_KontMatKontrola.Visible = true;
            comboBox_KontMatKont.Visible = true;
            PokazPolaEdycji();
            btn_KontMatPotwierdz.Visible = true;
        }

        private void btn_UsunKontMat_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Usuwanie;
            UkryjWszystko();
            label_KontMatKontrola.Visible = true;
            comboBox_KontMatKont.Visible = true;
            PokazPolaEdycji();

            comboBox_KontMatPrac.Enabled = false;
            comboBox_KontMatZadP.Enabled = false;
            comboBox_KontMatMaterial.Enabled = false;
            textBox_KontMatRBH.ReadOnly = true;
            textBox_KontMatOdpady.ReadOnly = true;
            checkBox_KontrolaMatZat.Enabled = false;

            btn_KontMatPotwierdz.Visible = true;
        }

        private void PokazPolaEdycji()
        {
            label_KontMatPrac.Visible = true;
            comboBox_KontMatPrac.Visible = true;
            label_KontMatRBH.Visible = true;
            textBox_KontMatRBH.Visible = true;
            label_KontMatZat.Visible = true;
            checkBox_KontrolaMatZat.Visible = true;
            label_KontMatOdpady.Visible = true;
            textBox_KontMatOdpady.Visible = true;
            label_KontMatZadP.Visible = true;
            comboBox_KontMatZadP.Visible = true;
            label_KontMatMateral.Visible = true;
            comboBox_KontMatMaterial.Visible = true;
        }

        private void comboBox_KontMatKont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_KontMatKont.SelectedItem != null)
            {
                var wybrany = (KontrolaMat)comboBox_KontMatKont.SelectedItem;

                comboBox_KontMatPrac.SelectedValue = wybrany.IdPracownik;
                comboBox_KontMatZadP.SelectedValue = wybrany.IdZadanieP;
                comboBox_KontMatMaterial.SelectedValue = wybrany.IdMaterial;

                textBox_KontMatRBH.Text = wybrany.Rbh?.ToString();
                textBox_KontMatOdpady.Text = wybrany.Odpady?.ToString();
                checkBox_KontrolaMatZat.Checked = wybrany.Zatwierdzone;
            }
        }

        private void btn_KontMatPotwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_KontMatKont.SelectedValue == null)
                {
                    MessageBox.Show("Proszę wybrać kontrolę z listy!", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (aktualnyTryb == TrybPracy.Dodawanie || aktualnyTryb == TrybPracy.Edycja)
                {
                    if (comboBox_KontMatPrac.SelectedValue == null || comboBox_KontMatZadP.SelectedValue == null || comboBox_KontMatMaterial.SelectedValue == null)
                    {
                        MessageBox.Show("Wybierz pracownika, zadanie i materiał!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                decimal? rbh = string.IsNullOrWhiteSpace(textBox_KontMatRBH.Text) ? (decimal?)null : decimal.Parse(textBox_KontMatRBH.Text);
                decimal? odpady = string.IsNullOrWhiteSpace(textBox_KontMatOdpady.Text) ? (decimal?)null : decimal.Parse(textBox_KontMatOdpady.Text);

                if (aktualnyTryb == TrybPracy.Dodawanie)
                {
                    var nowa = new KontrolaMat
                    {
                        IdPracownik = (int)comboBox_KontMatPrac.SelectedValue,
                        IdZadanieP = (int)comboBox_KontMatZadP.SelectedValue,
                        IdMaterial = (int)comboBox_KontMatMaterial.SelectedValue,
                        Rbh = rbh,
                        Odpady = odpady,
                        Zatwierdzone = checkBox_KontrolaMatZat.Checked
                    };
                    _context.KontrolaMat.Add(nowa);
                }
                else if (aktualnyTryb == TrybPracy.Edycja)
                {
                    int id = (int)comboBox_KontMatKont.SelectedValue;
                    var edytowana = _context.KontrolaMat.Find(id);
                    if (edytowana != null)
                    {
                        edytowana.IdPracownik = (int)comboBox_KontMatPrac.SelectedValue;
                        edytowana.IdZadanieP = (int)comboBox_KontMatZadP.SelectedValue;
                        edytowana.IdMaterial = (int)comboBox_KontMatMaterial.SelectedValue;
                        edytowana.Rbh = rbh;
                        edytowana.Odpady = odpady;
                        edytowana.Zatwierdzone = checkBox_KontrolaMatZat.Checked;
                    }
                }
                else if (aktualnyTryb == TrybPracy.Usuwanie)
                {
                    int id = (int)comboBox_KontMatKont.SelectedValue;
                    var doUsuniecia = _context.KontrolaMat.Find(id);
                    if (doUsuniecia != null)
                    {
                        DialogResult res = MessageBox.Show($"Czy na pewno usunąć kontrolę nr {id}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No) return;
                        _context.KontrolaMat.Remove(doUsuniecia);
                    }
                }

                _context.SaveChanges();
                MessageBox.Show("Operacja wykonana pomyślnie.");

                OdswiezDane();
                UkryjWszystko();
                aktualnyTryb = TrybPracy.Brak;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }
    }
}
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
    public partial class Form_Material : Form
    {
        PodkladexContext _context;

        private enum TrybPracy { Brak, Dodawanie, Edycja, Usuwanie }
        private TrybPracy aktualnyTryb = TrybPracy.Brak;

        public Form_Material(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            // Rejestracja zdarzeń
            this.Load += Form_Material_Load;
            this.btn_DodajMaterial.Click += btn_DodajMaterial_Click;
            this.btn_EdytujMat.Click += btn_EdytujMat_Click;
            this.btn_UsunMat.Click += btn_UsunMat_Click;
            this.btn_MaterialPotwierdz.Click += btn_MaterialPotwierdz_Click;
            this.comboBox_MaterialLista.SelectedIndexChanged += comboBox_MaterialLista_SelectedIndexChanged;
        }

        private void Form_Material_Load(object sender, EventArgs e)
        {
            UkryjWszystko();
            OdswiezDane();
        }

        private void UkryjWszystko()
        {
            // Reset kolorów przycisków głównego menu
            btn_DodajMaterial.BackColor = SystemColors.Control;
            btn_EdytujMat.BackColor = SystemColors.Control;
            btn_UsunMat.BackColor = SystemColors.Control;

            // Ukrywanie i resetowanie stanu pól tekstowych
            textBox_DodajNazweMat.Visible = false;
            textBox_DodajNazweMat.ReadOnly = false;
            textBox_DodajNazweMat.Clear();

            textBox_DodajOpisMat.Visible = false;
            textBox_DodajOpisMat.ReadOnly = false;
            textBox_DodajOpisMat.Clear();

            // Ukrywanie i resetowanie list
            comboBox_MaterialLista.Visible = false;

            comboBox_MaterialRodzaj.Visible = false;
            comboBox_MaterialRodzaj.Enabled = true;
            comboBox_MaterialRodzaj.SelectedIndex = -1;

            btn_MaterialPotwierdz.Visible = false;

            // Ukrywanie etykiet
            label_NazwaMat.Visible = false;
            label_OpisMat.Visible = false;
            label_MaterialRodzaj.Visible = false;
            label_DodajUsun.Visible = false;
        }

        private void OdswiezDane()
        {
            comboBox_MaterialLista.DataSource = _context.Material.ToList();
            comboBox_MaterialLista.DisplayMember = "Nazwa";
            comboBox_MaterialLista.ValueMember = "IdMaterial";
            comboBox_MaterialLista.SelectedIndex = -1;

            comboBox_MaterialRodzaj.DataSource = _context.RodzajMaterialu.ToList();
            comboBox_MaterialRodzaj.DisplayMember = "Nazwa";
            comboBox_MaterialRodzaj.ValueMember = "IdRodzaj";
            comboBox_MaterialRodzaj.SelectedIndex = -1;
        }

        private void btn_DodajMaterial_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Dodawanie;
            UkryjWszystko();

            // Podświetlenie aktywnego przycisku i zmiana tekstu akcji
            btn_DodajMaterial.BackColor = Color.LightSkyBlue;
            btn_MaterialPotwierdz.Text = "Dodaj nowy materiał";

            label_NazwaMat.Visible = true;
            textBox_DodajNazweMat.Visible = true;

            label_OpisMat.Visible = true;
            textBox_DodajOpisMat.Visible = true;

            label_MaterialRodzaj.Visible = true;
            comboBox_MaterialRodzaj.Visible = true;

            btn_MaterialPotwierdz.Visible = true;
        }

        private void btn_EdytujMat_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Edycja;
            UkryjWszystko();

            // Podświetlenie aktywnego przycisku i zmiana tekstu akcji
            btn_EdytujMat.BackColor = Color.LightSkyBlue;
            btn_MaterialPotwierdz.Text = "Zapisz zmiany";

            label_DodajUsun.Visible = true;
            comboBox_MaterialLista.Visible = true;

            label_NazwaMat.Visible = true;
            textBox_DodajNazweMat.Visible = true;

            label_OpisMat.Visible = true;
            textBox_DodajOpisMat.Visible = true;

            label_MaterialRodzaj.Visible = true;
            comboBox_MaterialRodzaj.Visible = true;

            btn_MaterialPotwierdz.Visible = true;
        }

        private void btn_UsunMat_Click(object sender, EventArgs e)
        {
            aktualnyTryb = TrybPracy.Usuwanie;
            UkryjWszystko();

            // Podświetlenie aktywnego przycisku i zmiana tekstu akcji
            btn_UsunMat.BackColor = Color.LightSkyBlue;
            btn_MaterialPotwierdz.Text = "Usuń materiał";

            // Pokaż listę wyboru
            label_DodajUsun.Visible = true;
            comboBox_MaterialLista.Visible = true;

            // Pokaż szczegóły jako tylko do odczytu
            label_NazwaMat.Visible = true;
            textBox_DodajNazweMat.Visible = true;
            textBox_DodajNazweMat.ReadOnly = true;

            label_OpisMat.Visible = true;
            textBox_DodajOpisMat.Visible = true;
            textBox_DodajOpisMat.ReadOnly = true;

            label_MaterialRodzaj.Visible = true;
            comboBox_MaterialRodzaj.Visible = true;
            comboBox_MaterialRodzaj.Enabled = false;

            btn_MaterialPotwierdz.Visible = true;
        }

        private void comboBox_MaterialLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Wypełnianie pól danymi przy edycji oraz przy usuwaniu
            if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_MaterialLista.SelectedItem != null)
            {
                var wybrany = (Material)comboBox_MaterialLista.SelectedItem;
                textBox_DodajNazweMat.Text = wybrany.Nazwa;
                textBox_DodajOpisMat.Text = wybrany.Opis;
                comboBox_MaterialRodzaj.SelectedValue = wybrany.IdRodzaj;
            }
        }

        private void btn_MaterialPotwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                // Walidacja wyboru materiału (Edycja/Usuwanie)
                if ((aktualnyTryb == TrybPracy.Edycja || aktualnyTryb == TrybPracy.Usuwanie) && comboBox_MaterialLista.SelectedValue == null)
                {
                    MessageBox.Show("Proszę wybrać materiał z listy!", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Walidacja rodzaju (Dodawanie/Edycja)
                if ((aktualnyTryb == TrybPracy.Dodawanie || aktualnyTryb == TrybPracy.Edycja) && comboBox_MaterialRodzaj.SelectedValue == null)
                {
                    MessageBox.Show("Proszę wybrać rodzaj materiału!", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (aktualnyTryb == TrybPracy.Dodawanie)
                {
                    var nowy = new Material
                    {
                        Nazwa = textBox_DodajNazweMat.Text,
                        Opis = textBox_DodajOpisMat.Text,
                        IdRodzaj = (int)comboBox_MaterialRodzaj.SelectedValue
                    };
                    _context.Material.Add(nowy);
                }
                else if (aktualnyTryb == TrybPracy.Edycja)
                {
                    int id = (int)comboBox_MaterialLista.SelectedValue;
                    var edytowany = _context.Material.Find(id);
                    if (edytowany != null)
                    {
                        edytowany.Nazwa = textBox_DodajNazweMat.Text;
                        edytowany.Opis = textBox_DodajOpisMat.Text;
                        edytowany.IdRodzaj = (int)comboBox_MaterialRodzaj.SelectedValue;
                    }
                }
                else if (aktualnyTryb == TrybPracy.Usuwanie)
                {
                    int id = (int)comboBox_MaterialLista.SelectedValue;
                    var doUsuniecia = _context.Material.Find(id);
                    if (doUsuniecia != null)
                    {
                        // Dodatkowe potwierdzenie usunięcia
                        DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć materiał: {doUsuniecia.Nazwa}?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No) return;

                        _context.Material.Remove(doUsuniecia);
                    }
                }

                _context.SaveChanges();
                MessageBox.Show("Operacja zakończona pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OdswiezDane();
                UkryjWszystko();
                aktualnyTryb = TrybPracy.Brak;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
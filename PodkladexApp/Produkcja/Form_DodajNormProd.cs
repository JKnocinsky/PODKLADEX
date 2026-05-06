using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodkladexApp.Produkcja
{
    public partial class Form_DodajNormProd : Form
    {
        PodkladexContext db;
        NormaProd normaProd;
        int btn;

        // Pola przechowujące przekazane identyfikatory
        private readonly int _selectedProduktId;
        private readonly int _selectedMaterialId;

        public Form_DodajNormProd(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;
            btn = 0;
        }

        public Form_DodajNormProd(PodkladexContext db, NormaProd wybranaNorma)
        {
            InitializeComponent();
            this.db = db;
            this.normaProd = wybranaNorma;
            btn = 1;
        }

        // Konstruktor przyjmujący identyfikatory produktu i materiału
        public Form_DodajNormProd(PodkladexContext db, int selectedProduktId, int selectedMaterialId)
        {
            InitializeComponent();
            this.db = db;

            _selectedProduktId = selectedProduktId;
            _selectedMaterialId = selectedMaterialId;

            // Nie ustawiamy SelectedValue tutaj, bo źródło danych combo zostanie przypisane przy ładowaniu formularza.
            btn = 0;
        }

        // Publiczne właściwości do odczytu, jeśli potrzebne poza tym formularzem
        public int SelectedProduktId => _selectedProduktId;
        public int SelectedMaterialId => _selectedMaterialId;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadCombos();
            ApplyInitialSelection();
        }

        private void LoadCombos()
        {
            // Wypełnij cmb_produkt listą produktów posortowanych po nazwie
            var produkty = db.Produkt
                .OrderBy(p => p.Nazwa)
                .Select(p => new { p.IdProdukt, p.Nazwa })
                .ToList();

            cmb_produkt.DisplayMember = "Nazwa";
            cmb_produkt.ValueMember = "IdProdukt";
            cmb_produkt.DataSource = produkty;

            // Wypełnij cmb_material listą materiałów posortowanych po nazwie
            var materialy = db.Material
                .OrderBy(m => m.Nazwa)
                .Select(m => new { m.IdMaterial, m.Nazwa })
                .ToList();

            cmb_material.DisplayMember = "Nazwa";
            cmb_material.ValueMember = "IdMaterial";
            cmb_material.DataSource = materialy;
        }

        private void ApplyInitialSelection()
        {
            // Jeśli konstruktor otrzymał obiekt normaProd, ustaw wybrane elementy według jego Id
            if (normaProd != null)
            {
                cmb_produkt.SelectedValue = normaProd.IdProdukt;
                cmb_material.SelectedValue = normaProd.IdMaterial;

                // Możliwe wstępne wypełnienie pól tekstowych wartościami normy
                txt_usedMaterial.Text = normaProd.IloscMat.ToString(CultureInfo.CurrentCulture);
                txt_wyprodukowano.Text = normaProd.Ilosc.ToString(CultureInfo.CurrentCulture);
                txt_czas.Text = normaProd.Czas.ToString(CultureInfo.CurrentCulture);

                // Jeśli chcesz zablokować edycję przy edycji normy, odkomentuj poniższe:
                // cmb_produkt.Enabled = false;
                // cmb_material.Enabled = false;
            }

            // Jeśli konstruktor otrzymał identyfikatory, ustaw i zablokuj odpowiednie combo
            if (_selectedProduktId != 0)
            {
                cmb_produkt.SelectedValue = _selectedProduktId;
                cmb_produkt.Enabled = false;
            }

            if (_selectedMaterialId != 0)
            {
                cmb_material.SelectedValue = _selectedMaterialId;
                cmb_material.Enabled = false;
            }
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            // Walidacja wybranych produktów i materiałów
            if (cmb_produkt.SelectedItem == null)
            {
                MessageBox.Show("Wybierz produkt.", "Brak wartości", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_material.SelectedItem == null)
            {
                MessageBox.Show("Wybierz materiał.", "Brak wartości", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parsowanie pól liczbowych (używamy aktualnej kultury, by obsłużyć przecinek/kropkę zgodnie z ustawieniami)
            if (!decimal.TryParse(txt_usedMaterial.Text?.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var iloscMat))
            {
                MessageBox.Show("Wprowadź poprawną wartość ilości materiału (IloscMat).", "Niepoprawny format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_wyprodukowano.Text?.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var ilosc))
            {
                MessageBox.Show("Wprowadź poprawną wartość wyprodukowanych sztuk (Ilosc).", "Niepoprawny format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_czas.Text?.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var czas))
            {
                MessageBox.Show("Wprowadź poprawną wartość czasu (Czas).", "Niepoprawny format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Jeśli nie przekazano normy do edycji - tworzymy nowy rekord NormaProd
            if (normaProd == null)
            {
                try
                {
                    var nowaNorma = new NormaProd
                    {
                        IdProdukt = Convert.ToInt32(cmb_produkt.SelectedValue),
                        IdMaterial = Convert.ToInt32(cmb_material.SelectedValue),
                        IloscMat = iloscMat,
                        Ilosc = ilosc,
                        Czas = czas,
                        Data = DateOnly.FromDateTime(DateTime.Now)
                    };

                    db.NormaProd.Add(nowaNorma);
                    db.SaveChanges();

                    MessageBox.Show("Nowa norma została zapisana.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Jeśli chcesz obsłużyć aktualizację istniejącej normy, można tu zaktualizować pola i zapisać:
                try
                {
                    normaProd.IdProdukt = Convert.ToInt32(cmb_produkt.SelectedValue);
                    normaProd.IdMaterial = Convert.ToInt32(cmb_material.SelectedValue);
                    normaProd.IloscMat = iloscMat;
                    normaProd.Ilosc = ilosc;
                    normaProd.Czas = czas;
                    normaProd.Data = DateOnly.FromDateTime(DateTime.Now);

                    db.NormaProd.Update(normaProd);
                    db.SaveChanges();

                    MessageBox.Show("Norma została zaktualizowana.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas aktualizacji: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }   
    }
}

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
using Microsoft.EntityFrameworkCore; // Dodane dla obsługi Include

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

            btn = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadCombos();
            ApplyInitialSelection();
        }

        private void LoadCombos()
        {
            var produkty = db.Produkt
                .OrderBy(p => p.Nazwa)
                .Select(p => new { p.IdProdukt, p.Nazwa })
                .ToList();

            cmb_produkt.DisplayMember = "Nazwa";
            cmb_produkt.ValueMember = "IdProdukt";
            cmb_produkt.DataSource = produkty;

            var materialy = db.Material
                .Include(m => m.MaterialWlasciwosci)
                    .ThenInclude(mw => mw.IdWlasciwosciNavigation)
                .OrderBy(m => m.Nazwa)
                .AsEnumerable()
                .Select(m => new
                {
                    m.IdMaterial,
                    NazwaZGruboscia = $"{m.Nazwa} || {(m.MaterialWlasciwosci.FirstOrDefault(mw => mw.IdWlasciwosciNavigation.NazwaParametru == "Grubość")?.WartoscNominalna ?? 0):N2}"
                })
                .ToList();

            cmb_material.DisplayMember = "NazwaZGruboscia";
            cmb_material.ValueMember = "IdMaterial";
            cmb_material.DataSource = materialy;
        }

        private void ApplyInitialSelection()
        {
            if (normaProd != null)
            {
                cmb_produkt.SelectedValue = normaProd.IdProdukt;
                cmb_material.SelectedValue = normaProd.IdMaterial;

                txt_usedMaterial.Text = normaProd.IloscMat.ToString(CultureInfo.CurrentCulture);
                txt_wyprodukowano.Text = normaProd.Ilosc.ToString(CultureInfo.CurrentCulture);
                txt_czas.Text = normaProd.Czas.ToString(CultureInfo.CurrentCulture);
            }

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
            if (cmb_produkt.SelectedValue == null || cmb_material.SelectedValue == null)
            {
                MessageBox.Show("Proszę wybrać produkt i materiał.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentProduktId = Convert.ToInt32(cmb_produkt.SelectedValue);
            int currentMaterialId = Convert.ToInt32(cmb_material.SelectedValue);

            // ======================================================
            // WALIDACJA UNIKALNOŚCI NORMY (Zadanie)
            // ======================================================
            bool duplicateExists;
            if (normaProd == null) // Tryb dodawania
            {
                duplicateExists = db.NormaProd.Any(n => n.IdProdukt == currentProduktId && n.IdMaterial == currentMaterialId);
            }
            else // Tryb edycji
            {
                duplicateExists = db.NormaProd.Any(n => n.IdProdukt == currentProduktId && n.IdMaterial == currentMaterialId && n.IdNormaP != normaProd.IdNormaP);
            }

            if (duplicateExists)
            {
                MessageBox.Show("Norma dla wybranego produktu i materiału (o tej grubości) już istnieje w systemie.\n\n" +
                                "Nie można utworzyć duplikatu. Jeśli chcesz zmienić parametry tej normy, odszukaj ją na liście głównej i użyj opcji 'Edytuj'.",
                                "Norma już istnieje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // ======================================================

            if (!decimal.TryParse(txt_usedMaterial.Text?.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var iloscMat))
            {
                MessageBox.Show("Wprowadź poprawną wartość ilości materiału.", "Niepoprawny format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_wyprodukowano.Text?.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var ilosc))
            {
                MessageBox.Show("Wprowadź poprawną wartość wyprodukowanych sztuk.", "Niepoprawny format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_czas.Text?.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var czas))
            {
                MessageBox.Show("Wprowadź poprawną wartość czasu.", "Niepoprawny format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (normaProd == null)
            {
                try
                {
                    var nowaNorma = new NormaProd
                    {
                        IdProdukt = currentProduktId,
                        IdMaterial = currentMaterialId,
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
                try
                {
                    normaProd.IdProdukt = currentProduktId;
                    normaProd.IdMaterial = currentMaterialId;
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
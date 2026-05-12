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
using PodkladexApp.Produkcja;

namespace PodkladexApp
{
    public partial class Form_NormaProd : Form
    {
        PodkladexContext bd;

        public Form_NormaProd(PodkladexContext bd)
        {

            InitializeComponent();
            this.bd = bd;
            // Załaduj listę norm wraz z nazwami produktu i materiału
            LoadNormyGrid();

            dgv_NormyProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cmb_filtr.Items.AddRange(new string[] { "Wszystkie", "Produkt", "Maszyna", "Materiał" });
        }

        private void LoadNormyGrid()
        {
            // Załaduj powiązane encje aby uzyskać nazwy maszyn, produktu i materiału wraz z grubością
            var normyEntities = bd.NormaProd
                .Include(n => n.IdProduktNavigation)
                .Include(n => n.IdMaterialNavigation)
                    .ThenInclude(m => m.MaterialWlasciwosci)
                        .ThenInclude(mw => mw.IdWlasciwosciNavigation)
                .Include(n => n.MaszynaWyp)
                    .ThenInclude(mw => mw.IdMaszynaNavigation)
                .ToList();

            var normy = normyEntities
                .Select(n => new
                {
                    // PRZYWRÓCONO: IdNormaP musi być w DataSource, aby edycja działała
                    n.IdNormaP,
                    Produkt = n.IdProduktNavigation != null ? n.IdProduktNavigation.Nazwa : string.Empty,
                    // Nazwa materiału || grubość (2 miejsca po przecinku)
                    Material = n.IdMaterialNavigation != null
                        ? $"{n.IdMaterialNavigation.Nazwa} || {(n.IdMaterialNavigation.MaterialWlasciwosci.FirstOrDefault(mw => mw.IdWlasciwosciNavigation.NazwaParametru == "Grubość")?.WartoscNominalna ?? 0):N2}"
                        : string.Empty,
                    n.IloscMat,
                    n.Ilosc,
                    n.Czas,
                    n.Data
                })
                .ToList();

            dgv_NormyProd.DataSource = normy;

            // Ukrywamy kolumnę techniczną IdNormaP przed użytkownikiem
            if (dgv_NormyProd.Columns.Contains("IdNormaP"))
                dgv_NormyProd.Columns["IdNormaP"].Visible = false;

            dgv_NormyProd.Columns["Material"].HeaderText = "Materiał";
            dgv_NormyProd.Columns["IloscMat"].HeaderText = "Ilość zużytego materiału";
            dgv_NormyProd.Columns["Ilosc"].HeaderText = "Ilość wyprodukowana";
        }

        private void btn_dodaj_Click(object sender, EventArgs e)
        {
            Form_DodajNormProd formDodaj = new Form_DodajNormProd(bd);
            formDodaj.FormClosed += (s, args) => LoadNormyGrid(); // Odśwież po zamknięciu
            formDodaj.ShowDialog();
        }

        private void btn_edytuj_Click(object sender, EventArgs e)
        {
            if (dgv_NormyProd.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz normę do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Teraz kolumna IdNormaP istnieje w DataSource, więc ta linijka zadziała poprawnie:
            var selectedNormaId = Convert.ToInt32(dgv_NormyProd.SelectedRows[0].Cells["IdNormaP"].Value);
            var wybranaNorma = bd.NormaProd.Find(selectedNormaId);

            if (wybranaNorma == null)
            {
                MessageBox.Show("Nie znaleziono wybranej normy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form_DodajNormProd formDodaj = new Form_DodajNormProd(bd, wybranaNorma);
            formDodaj.FormClosed += (s, args) => LoadNormyGrid(); // Odśwież po zamknięciu
            formDodaj.ShowDialog();
        }

        private void btn_MaszWyp_Click(object sender, EventArgs e)
        {
        }

        private void cmb_wybieranie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_filtr.SelectedItem == null)
            {
                LoadNormyGrid();
                return;
            }

            var filtr = cmb_filtr.SelectedItem.ToString();

            if (cmb_wybieranie.DataSource == null || cmb_wybieranie.SelectedValue == null)
            {
                LoadNormyGrid();
                return;
            }

            switch (filtr)
            {
                case "Produkt":
                    {
                        int idProd = Convert.ToInt32(cmb_wybieranie.SelectedValue);
                        var normyEntities = bd.NormaProd
                            .Include(n => n.IdProduktNavigation)
                            .Include(n => n.IdMaterialNavigation)
                                .ThenInclude(m => m.MaterialWlasciwosci)
                                    .ThenInclude(mw => mw.IdWlasciwosciNavigation)
                            .Include(n => n.MaszynaWyp)
                                .ThenInclude(mw => mw.IdMaszynaNavigation)
                            .Where(n => n.IdProdukt == idProd)
                            .ToList();

                        var normy = normyEntities
                            .Select(n => new
                            {
                                n.IdNormaP,
                                Produkt = n.IdProduktNavigation != null ? n.IdProduktNavigation.Nazwa : string.Empty,
                                Material = n.IdMaterialNavigation != null
                                    ? $"{n.IdMaterialNavigation.Nazwa} || {(n.IdMaterialNavigation.MaterialWlasciwosci.FirstOrDefault(mw => mw.IdWlasciwosciNavigation.NazwaParametru == "Grubość")?.WartoscNominalna ?? 0):N2}"
                                    : string.Empty,
                                n.IloscMat,
                                n.Ilosc,
                                n.Czas,
                                n.Data
                            })
                            .ToList();

                        dgv_NormyProd.DataSource = normy;
                        break;
                    }

                case "Maszyna":
                    {
                        int idMasz = Convert.ToInt32(cmb_wybieranie.SelectedValue);
                        var normyEntities = bd.NormaProd
                            .Include(n => n.IdProduktNavigation)
                            .Include(n => n.IdMaterialNavigation)
                                .ThenInclude(m => m.MaterialWlasciwosci)
                                    .ThenInclude(mw => mw.IdWlasciwosciNavigation)
                            .Include(n => n.MaszynaWyp)
                                .ThenInclude(mw => mw.IdMaszynaNavigation)
                            .Where(n => n.MaszynaWyp.Any(mw => mw.IdMaszyna == idMasz))
                            .ToList();

                        var normy = normyEntities
                            .Select(n => new
                            {
                                n.IdNormaP,
                                Produkt = n.IdProduktNavigation != null ? n.IdProduktNavigation.Nazwa : string.Empty,
                                Material = n.IdMaterialNavigation != null
                                    ? $"{n.IdMaterialNavigation.Nazwa} || {(n.IdMaterialNavigation.MaterialWlasciwosci.FirstOrDefault(mw => mw.IdWlasciwosciNavigation.NazwaParametru == "Grubość")?.WartoscNominalna ?? 0):N2}"
                                    : string.Empty,
                                n.IloscMat,
                                n.Ilosc,
                                n.Czas,
                                n.Data
                            })
                            .ToList();

                        dgv_NormyProd.DataSource = normy;
                        break;
                    }

                case "Materiał":
                    {
                        int idMat = Convert.ToInt32(cmb_wybieranie.SelectedValue);
                        var normyEntities = bd.NormaProd
                            .Include(n => n.IdProduktNavigation)
                            .Include(n => n.IdMaterialNavigation)
                                .ThenInclude(m => m.MaterialWlasciwosci)
                                    .ThenInclude(mw => mw.IdWlasciwosciNavigation)
                            .Include(n => n.MaszynaWyp)
                                .ThenInclude(mw => mw.IdMaszynaNavigation)
                            .Where(n => n.IdMaterial == idMat)
                            .ToList();

                        var normy = normyEntities
                            .Select(n => new
                            {
                                n.IdNormaP,
                                Produkt = n.IdProduktNavigation != null ? n.IdProduktNavigation.Nazwa : string.Empty,
                                Material = n.IdMaterialNavigation != null
                                    ? $"{n.IdMaterialNavigation.Nazwa} || {(n.IdMaterialNavigation.MaterialWlasciwosci.FirstOrDefault(mw => mw.IdWlasciwosciNavigation.NazwaParametru == "Grubość")?.WartoscNominalna ?? 0):N2}"
                                    : string.Empty,
                                n.IloscMat,
                                n.Ilosc,
                                n.Czas,
                                n.Data
                            })
                            .ToList();

                        dgv_NormyProd.DataSource = normy;
                        break;
                    }

                default:
                    LoadNormyGrid();
                    break;
            }

            if (dgv_NormyProd.Columns.Contains("IdNormaP"))
                dgv_NormyProd.Columns["IdNormaP"].Visible = false;
        }

        private void cmb_filtr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_filtr.SelectedItem != null)
            {
                switch (cmb_filtr.SelectedItem.ToString())
                {
                    case "Wszystkie":
                        LoadNormyGrid();
                        cmb_wybieranie.DataSource = null;
                        cmb_wybieranie.Items.Clear();
                        cmb_wybieranie.SelectedIndex = -1;
                        cmb_wybieranie.Refresh();
                        break;

                    case "Produkt":
                        var produkty = bd.Produkt
                            .Select(p => new { p.IdProdukt, p.Nazwa })
                            .ToList();
                        cmb_wybieranie.DataSource = null;
                        cmb_wybieranie.DisplayMember = "Nazwa";
                        cmb_wybieranie.ValueMember = "IdProdukt";
                        cmb_wybieranie.DataSource = produkty;
                        cmb_wybieranie.SelectedIndex = -1;
                        cmb_wybieranie.Refresh();
                        break;

                    case "Maszyna":
                        {
                            var maszyny = bd.Maszyna
                                .Select(m => new { m.IdMaszyna, m.Nazwa })
                                .ToList();
                            cmb_wybieranie.DataSource = null;
                            cmb_wybieranie.DisplayMember = "Nazwa";
                            cmb_wybieranie.ValueMember = "IdMaszyna";
                            cmb_wybieranie.DataSource = maszyny;
                            cmb_wybieranie.SelectedIndex = -1;
                            cmb_wybieranie.Refresh();
                            break;
                        }

                    case "Materiał":
                        {
                            var materiały = bd.Material
                                .Select(mat => new { mat.IdMaterial, mat.Nazwa })
                                .ToList();
                            cmb_wybieranie.DataSource = null;
                            cmb_wybieranie.DisplayMember = "Nazwa";
                            cmb_wybieranie.ValueMember = "IdMaterial";
                            cmb_wybieranie.DataSource = materiały;
                            cmb_wybieranie.SelectedIndex = -1;
                            cmb_wybieranie.Refresh();
                            break;
                        }
                }
            }
        }
    }
}
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
    public partial class Form_NormaProd : Form
    {
        PodkladexContext db;

        public Form_NormaProd(PodkladexContext db)
        {

            InitializeComponent();
            this.db = db;
            // Załaduj listę norm wraz z nazwami produktu i materiału
            LoadNormyGrid();

            //dgv_NormyProd.Columns["DataZakupu"].HeaderText = "Data zakupu";
            //dgv_NormyProd.Columns["DataUruchomienia"].HeaderText = "Data uruchomienia";
            //dgv_NormyProd.Columns["DataWylaczenia"].HeaderText = "Data wyłączenia";
            dgv_NormyProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cmb_filtr.Items.AddRange(new string[] { "Wszystkie", "Produkt", "Maszyna", "Materiał" });
        }

        private void LoadNormyGrid()
        {
            // Załaduj powiązane encje aby uzyskać nazwy maszyn, produktu i materiału
            var normyEntities = db.NormaProd
                .Include(n => n.IdProduktNavigation)
                .Include(n => n.IdMaterialNavigation)
                .Include(n => n.MaszynaWyp)
                    .ThenInclude(mw => mw.IdMaszynaNavigation)
                .ToList();

            var normy = normyEntities
                .Select(n => new
                {
                    // Pierwsza kolumna: nazwy maszyn powiązanych z tą normą (po przecinku jeśli więcej niż jedna)
                    Maszyna = string.Join(", ", n.MaszynaWyp
                        .Select(mw => mw.IdMaszynaNavigation != null ? mw.IdMaszynaNavigation.Nazwa : string.Empty)
                        .Where(s => !string.IsNullOrEmpty(s))),
                    n.IdNormaP,
                    Produkt = n.IdProduktNavigation != null ? n.IdProduktNavigation.Nazwa : string.Empty,
                    Material = n.IdMaterialNavigation != null ? n.IdMaterialNavigation.Nazwa : string.Empty,
                    n.IloscMat,
                    n.Ilosc,
                    n.Czas,
                    n.Data
                })
                .ToList();

            dgv_NormyProd.DataSource = normy;
            if (dgv_NormyProd.Columns.Contains("IdNormaP"))
                dgv_NormyProd.Columns["IdNormaP"].Visible = false;
        }

        private void btn_dodaj_Click(object sender, EventArgs e)
        {

            Button button = sender as Button;
            Maszyna selectedMaszyna = null;

            if (button.Text == "Edytuj")
            {
                DataGridViewRow row = dgv_NormyProd.SelectedRows.Count > 0 ? dgv_NormyProd.SelectedRows[0] : null;

                if (row == null)
                {
                    MessageBox.Show("Proszę wybrać maszynę z listy.");
                }
                else
                {
                    selectedMaszyna = row.DataBoundItem as Maszyna;
                }

                // otwarcie formularza dodawania maszyny z przekazaniem nazwy przycisku oraz maszny
                Form_DodajMaszyne FD = new Form_DodajMaszyne(db, button.Name, selectedMaszyna);
                FD.ShowDialog();
            }
            else if (button.Text == "Dodaj")
            {
                Form_DodajMaszyne FD = new Form_DodajMaszyne(db, button.Name);
                FD.ShowDialog();
                dgv_NormyProd.DataSource = db.Maszyna.ToList();
                dgv_NormyProd.Refresh();
            }
            else
            {
                DataGridViewRow row = dgv_NormyProd.SelectedRows.Count > 0 ? dgv_NormyProd.SelectedRows[0] : null;

                if (row == null)
                {
                    MessageBox.Show("Proszę wybrać maszynę z listy.");
                }
                else
                {
                    selectedMaszyna = row.DataBoundItem as Maszyna;
                    var confirmResult = MessageBox.Show("Czy na pewno chcesz usunąć tę maszynę?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        db.Maszyna.Remove(selectedMaszyna);
                        db.SaveChanges();
                    }
                    dgv_NormyProd.DataSource = db.Maszyna.ToList();
                    dgv_NormyProd.Refresh();
                }
            }
            // wybór maszyny z DataGridView
        }

        private void btn_MaszWyp_Click(object sender, EventArgs e)
        {

        }

        private void cmb_wybieranie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_filtr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_filtr.SelectedItem != null)
            {
                switch (cmb_filtr.SelectedItem.ToString())
                {
                    case "Wszystkie":
                        LoadNormyGrid();
                        break;

                    case "Produkt":
                        cmb_wybieranie.DataSource = db.Produkt.ToList();
                        cmb_wybieranie.Refresh();
                        break;

                    case "Maszyna":
                        cmb_wybieranie.DataSource = db.Maszyna.ToList();
                        cmb_wybieranie.Refresh();
                        break;

                    case "Materiał":
                        cmb_wybieranie.DataSource = db.Material.ToList();
                        cmb_wybieranie.Refresh();
                        break;
                }
            }
        }
    }
}

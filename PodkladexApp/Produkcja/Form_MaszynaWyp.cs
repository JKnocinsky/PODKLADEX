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

namespace PodkladexApp.Produkcja
{
    public partial class Form_MaszynaWyp : Form
    {
        PodkladexContext db;
        public Form_MaszynaWyp(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;
            dgv_Wyposazenie.DataSource = db.Wyposazenie.ToList();
            dgv_Wyposazenie.Columns["IdWyposazenie"].Visible = false;
            dgv_Wyposazenie.ClearSelection(); // Brak domyślnego wyboru

            cb_wyborMaszyny.DataSource = db.Maszyna.ToList();
            // Wyświetlaj w comboboxie nazwę maszyny, a wartością przypisz Id
            cb_wyborMaszyny.DisplayMember = "Nazwa";
            cb_wyborMaszyny.ValueMember = "IdMaszyna";
            cb_wyborMaszyny.SelectedIndex = -1; // Brak domyślnego wyboru

            dgv_wlasciwosci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void cb_wyborMaszyny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_wyborMaszyny.SelectedItem != null)
            {
                Maszyna selectedMaszyna = cb_wyborMaszyny.SelectedItem as Maszyna;
                if (selectedMaszyna == null)
                {
                    dgv_Wyposazenie.DataSource = db.Wyposazenie.ToList();
                    return;
                }

                // Pobierz Wyposazenie powiązane z wybraną maszyną przez relację MaszynaWyp
                var wyposazenieList = db.Wyposazenie
                    .Where(w => w.MaszynaWyp.Any(mw => mw.IdMaszyna == selectedMaszyna.IdMaszyna))
                    .ToList();

                dgv_Wyposazenie.DataSource = wyposazenieList;
                // Ukryj kolumnę Id (jeśli istnieje)
                if (dgv_Wyposazenie.Columns.Contains("IdWyposazenie"))
                    dgv_Wyposazenie.Columns["IdWyposazenie"].Visible = false;

                dgv_Wyposazenie.Columns["MaszynaWyp"].Visible = false;
                dgv_Wyposazenie.Columns["WyposazenieWlasciwosci"].Visible = false;
            }
        }

        private void cb_wyborMaszyny_TextChanged(object sender, EventArgs e)
        {
            if (cb_wyborMaszyny.Text == "")
            {
                dgv_Wyposazenie.DataSource = db.Wyposazenie.ToList();
            }
        }

        private void txtbox_wyszukaj_TextChanged(object sender, EventArgs e)
        {
            string query = txtbox_wyszukaj.Text?.Trim() ?? string.Empty;

            // Jeśli nie ma wpisanego tekstu - przywróć widok wg wyboru w cb_wyborMaszyny albo pełną listę
            if (string.IsNullOrEmpty(query))
            {
                if (cb_wyborMaszyny.SelectedItem is Maszyna selMaszyna)
                {
                    var wyposazenieList = db.Wyposazenie
                        .Where(w => w.MaszynaWyp.Any(mw => mw.IdMaszyna == selMaszyna.IdMaszyna))
                        .ToList();
                    dgv_Wyposazenie.DataSource = wyposazenieList;
                }
                else
                {
                    dgv_Wyposazenie.DataSource = db.Wyposazenie.ToList();
                }
            }
            else
            {
                // Szukaj tylko wśród elementów zgodnych z wyborem maszyny (jeśli jest wybrana)
                if (cb_wyborMaszyny.SelectedItem is Maszyna selectedMaszyna)
                {
                    var filtered = db.Wyposazenie
                        .Where(w => w.Nazwa.Contains(query) &&
                                    w.MaszynaWyp.Any(mw => mw.IdMaszyna == selectedMaszyna.IdMaszyna))
                        .ToList();
                    dgv_Wyposazenie.DataSource = filtered;
                }
                else
                {
                    // Brak wybranej maszyny — przeszukaj całą listę Wyposazenie
                    var filtered = db.Wyposazenie
                        .Where(w => w.Nazwa.Contains(query))
                        .ToList();
                    dgv_Wyposazenie.DataSource = filtered;
                }
            }

            // Ukryj niepożądane kolumny jeżeli istnieją
            if (dgv_Wyposazenie.Columns.Contains("IdWyposazenie"))
                dgv_Wyposazenie.Columns["IdWyposazenie"].Visible = false;

            if (dgv_Wyposazenie.Columns.Contains("MaszynaWyp"))
                dgv_Wyposazenie.Columns["MaszynaWyp"].Visible = false;

            if (dgv_Wyposazenie.Columns.Contains("WyposazenieWlasciwosci"))
                dgv_Wyposazenie.Columns["WyposazenieWlasciwosci"].Visible = false;
        }

        private void btn_dodaj_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Wyposazenie selectedWyposazenie = null;
            Form_DodajWyposazenie form = new Form_DodajWyposazenie(db, button.Name, selectedWyposazenie);
            form.ShowDialog();
        }

        private void dgv_Wyposazenie_SelectionChanged(object sender, EventArgs e)
        {
            // Jeśli brak zaznaczenia — wyczyść widok właściwości
            if (dgv_Wyposazenie.SelectedRows.Count == 0)
            {
                dgv_wlasciwosci.DataSource = null;
                dgv_wlasciwosci.Rows.Clear();
                dgv_wlasciwosci.Columns.Clear();
                return;
            }

            // Pobierz powiązany obiekt Wyposazenie z DataBoundItem
            Wyposazenie selectedWyposazenie = dgv_Wyposazenie.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem as Wyposazenie)
                .FirstOrDefault();

            if (selectedWyposazenie == null)
            {
                dgv_wlasciwosci.DataSource = null;
                dgv_wlasciwosci.Rows.Clear();
                dgv_wlasciwosci.Columns.Clear();
                return;
            }

            // Pobierz z bazy wszystkie powiązane właściwości i ustaw jako źródło danych
            var props = db.WyposazenieWlasciwosci
                .Where(ww => ww.IdWyposazenie == selectedWyposazenie.IdWyposazenie)
                .Select(ww => new
                {
                    Nazwa = ww.IdWlasciwosciNavigation != null ? ww.IdWlasciwosciNavigation.NazwaParametru : string.Empty,
                    Wartosc = ww.Wartosc
                })
                .ToList();

            dgv_wlasciwosci.AutoGenerateColumns = true;
            dgv_wlasciwosci.DataSource = props;

            // Przyjazne nagłówki kolumn
            if (dgv_wlasciwosci.Columns.Contains("Nazwa"))
                dgv_wlasciwosci.Columns["Nazwa"].HeaderText = "Właściwość";
            if (dgv_wlasciwosci.Columns.Contains("Wartosc"))
                dgv_wlasciwosci.Columns["Wartosc"].HeaderText = "Wartość";
        }

        private void btn_edytuj_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Wyposazenie selectedWyposazenie = dgv_Wyposazenie.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem as Wyposazenie)
                .FirstOrDefault();

            if (selectedWyposazenie == null)
            {
                MessageBox.Show("Proszę wybrać wyposażenie do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form_DodajWyposazenie form = new Form_DodajWyposazenie(db, button.Name, selectedWyposazenie);
            form.ShowDialog();
        }

        private void btn_przypisz_Click(object sender, EventArgs e)
        {
            Form_PrzypiszWyp form = new Form_PrzypiszWyp(db);
            form.ShowDialog();
        }
    }
}

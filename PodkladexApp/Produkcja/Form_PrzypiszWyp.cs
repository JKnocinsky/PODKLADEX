using PodkladexApp.Models;
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
    public partial class Form_PrzypiszWyp : Form
    {
        PodkladexContext db;
        Maszyna maszyna;
        int btn;
        public Form_PrzypiszWyp(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;
            btn = 1;
            this.Load += Form_PrzypiszWyp_Load;
        }

        public Form_PrzypiszWyp(PodkladexContext db, Maszyna maszyna)
        {
            InitializeComponent();
            this.db = db;
            this.maszyna = maszyna;
            btn = 2;
            this.Load += Form_PrzypiszWyp_Load;
        }

        private void Form_PrzypiszWyp_Load(object sender, EventArgs e)
        {
            // Ustaw dgv_wyposazenie - wszystkie rekordy Wyposazenie
            dgv_wyposazenie.AutoGenerateColumns = true;
            dgv_wyposazenie.DataSource = db.Wyposazenie.ToList();
            if (dgv_wyposazenie.Columns.Contains("IdWyposazenie"))
                dgv_wyposazenie.Columns["IdWyposazenie"].Visible = false;
            if (dgv_wyposazenie.Columns.Contains("MaszynaWyp"))
                dgv_wyposazenie.Columns["MaszynaWyp"].Visible = false;
            if (dgv_wyposazenie.Columns.Contains("WyposazenieWlasciwosci"))
                dgv_wyposazenie.Columns["WyposazenieWlasciwosci"].Visible = false;
            dgv_wyposazenie.ClearSelection();
            dgv_wyposazenie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ustaw cmb_maszyna
            cmb_maszyna.DisplayMember = "Nazwa";
            cmb_maszyna.ValueMember = "IdMaszyna";
            cmb_maszyna.DropDownStyle = ComboBoxStyle.DropDownList;

            if (btn == 2 && maszyna != null)
            {
                // Pokazujemy tylko przekazaną maszynę i blokujemy wybór (read-only)
                cmb_maszyna.DataSource = new List<Maszyna> { maszyna };
                cmb_maszyna.SelectedIndex = 0;
                // ComboBox nie ma właściwości ReadOnly — ustawiamy Disabled, aby uniemożliwić zmianę
                cmb_maszyna.Enabled = false;
            }
            else
            {
                // Pokazujemy wszystkie maszyny
                var maszyny = db.Maszyna.OrderBy(m => m.Nazwa).ToList();
                cmb_maszyna.DataSource = maszyny;
                cmb_maszyna.SelectedIndex = -1; // brak domyślnego wyboru
                cmb_maszyna.Enabled = true;
            }
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            try
            {
                // Pobierz Id maszyny: z pola przekazanego przez konstruktor lub z comboboxa
                int idMaszyna;
                if (maszyna != null)
                {
                    idMaszyna = maszyna.IdMaszyna;
                }
                else
                {
                    if (cmb_maszyna.SelectedValue == null || !(cmb_maszyna.SelectedValue is int))
                    {
                        MessageBox.Show("Proszę wybrać maszynę.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    idMaszyna = (int)cmb_maszyna.SelectedValue;
                }

                // Pobierz wybrane wyposażenie z DataGridView
                Wyposazenie selectedWyposazenie = null;
                if (dgv_wyposazenie.SelectedRows != null && dgv_wyposazenie.SelectedRows.Count > 0)
                {
                    selectedWyposazenie = dgv_wyposazenie.SelectedRows
                        .Cast<DataGridViewRow>()
                        .Select(r => r.DataBoundItem as Wyposazenie)
                        .FirstOrDefault();
                }

                // Jeżeli nie ma zaznaczenia spróbuj pobrać CurrentRow
                if (selectedWyposazenie == null && dgv_wyposazenie.CurrentRow != null)
                {
                    selectedWyposazenie = dgv_wyposazenie.CurrentRow.DataBoundItem as Wyposazenie;
                }

                if (selectedWyposazenie == null)
                {
                    MessageBox.Show("Proszę wybrać wyposażenie z listy.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Utwórz nowy rekord MaszynaWyp
                var mw = new MaszynaWyp
                {
                    IdMaszyna = idMaszyna,
                    IdWyposazenie = selectedWyposazenie.IdWyposazenie,
                    // Pole IdNormaP w modelu jest typu int (nie-nullable). Jeżeli nie ma wartości domyślnej,
                    // ustawiamy 0 — jeżeli to niewłaściwe, proszę wskazać wartość lub sposób wyboru normy.
                    IdNormaP = 0
                };

                db.MaszynaWyp.Add(mw);
                db.SaveChanges();

                MessageBox.Show("Wyposażenie zostało przypisane do maszyny.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
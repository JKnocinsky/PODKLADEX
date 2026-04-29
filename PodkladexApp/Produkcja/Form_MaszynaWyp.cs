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
            cb_wyborMaszyny.DataSource = db.Maszyna.ToList();
            // Wyświetlaj w comboboxie nazwę maszyny, a wartością przypisz Id
            cb_wyborMaszyny.DisplayMember = "Nazwa";
            cb_wyborMaszyny.ValueMember = "IdMaszyna";
        }

        private void cb_wyborMaszyny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_wyborMaszyny.SelectedItem != null)
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
            if(cb_wyborMaszyny.Text == "")
            {
                dgv_Wyposazenie.DataSource = db.Wyposazenie.ToList();
            }
        }
    }
}

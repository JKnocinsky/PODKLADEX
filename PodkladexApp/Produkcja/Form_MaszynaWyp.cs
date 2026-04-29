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
        }

        private void cb_wyborMaszyny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_wyborMaszyny.SelectedItem != null)
            {
                Maszyna selectedMaszyna = cb_wyborMaszyny.SelectedItem as Maszyna;
                var wypMasz = db.MaszynaWyp.ToList();
                var wyposazenieList = db.MaszynaWyp.Where(mw => mw.IdMaszyna == selectedMaszyna.IdMaszyna).ToList();
                dgv_Wyposazenie.DataSource = wyposazenieList;
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
            //List<Maszyna> maszyny = db.Maszyna.Where(m => m.Nazwa.Contains(txt_Nazwa_Maszyny.Text)).ToList();
            //dgv_Maszyny.DataSource = maszyny;
            List<Wyposazenie> wyposazenie = db.Wyposazenie.Where(w => w.Nazwa.Contains(txtbox_wyszukaj.Text)).ToList();
            dgv_Wyposazenie.DataSource = wyposazenie;
        }
    }
}

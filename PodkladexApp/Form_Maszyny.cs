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
    public partial class Form_Maszyny : Form
    {
        PodkladexContext db;

        public Form_Maszyny(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;
            dgv_Maszyny.DataSource = db.Maszyna.ToList();
            dgv_Maszyny.Columns["IdMaszyna"].Visible = false;
            dgv_Maszyny.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_dodaj_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Maszyna selectedMaszyna = null;
            // wybór maszyny z DataGridView

            DataGridViewRow row = dgv_Maszyny.SelectedRows.Count > 0 ? dgv_Maszyny.SelectedRows[0] : null;

            if (row == null)
            {
                MessageBox.Show("Proszę wybrać maszynę z listy.");
            }
            else
            {
                selectedMaszyna = row.DataBoundItem as Maszyna;
            }


            // otwarcie formularza dodawania maszyny z przekazaniem nazwy przycisku oraz maszny
            Form_DodajMaszyne FD = new Form_DodajMaszyne(button.Name, selectedMaszyna);
            FD.ShowDialog();
        }

        private void txt_Nazwa_Maszyny_TextChanged(object sender, EventArgs e)
        {
            List<Maszyna> maszyny = db.Maszyna.Where(m => m.Nazwa.Contains(txt_Nazwa_Maszyny.Text)).ToList();
            dgv_Maszyny.DataSource = maszyny; 
        }
    }
}

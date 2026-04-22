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
    public partial class Form_Produkcja : Form
    {
        PodkladexContext db;
        Form activeForm = null;

        public Form_Produkcja(PodkladexContext db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void btn_maszyny_Click(object sender, EventArgs e)
        {
            Form_Maszyny form = new Form_Maszyny(db);
            OpenChildForm(form);
        }
        private void OpenChildForm(Form childForm)
        {
            Panel panel = tableLayoutPanel1.Controls["panel_Produkcja"] as Panel;

            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }
    }
}

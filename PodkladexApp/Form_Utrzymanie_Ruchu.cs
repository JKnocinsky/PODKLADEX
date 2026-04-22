using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PodkladexApp.Models;

namespace PodkladexApp
{
    public partial class Form_Utrzymanie_Ruchu : Form
    {
        PodkladexContext context;
        Form activeForm = null;
        public Form_Utrzymanie_Ruchu(Models.PodkladexContext db)
        {
            InitializeComponent();
            context= db;
        }

        private void button_otworz_czesci_zamienne_Click(object sender, EventArgs e)
        {
            Form_czesci_zamienne formczesci = new Form_czesci_zamienne(context);
            OpenChildForm(formczesci);
        }

        private void button_otworz_awaria_Click(object sender, EventArgs e)
        {
            Form_Awaria formawaria = new Form_Awaria(context);
            OpenChildForm(formawaria);
        }

        private void button_otworz_obsluga_Click(object sender, EventArgs e)
        {
            Form_Obsluga formobsluga = new Form_Obsluga(context);
            OpenChildForm(formobsluga); 
            
        }

        private void button_otworz_rodzaj_obslugi_Click(object sender, EventArgs e)
        {
            Form_Rodzaj_obslugi formrodzajobslugi = new Form_Rodzaj_obslugi(context);
            OpenChildForm(formrodzajobslugi);
        }

        private void button_otworz_normy_eksplatacyjne_Click(object sender, EventArgs e)
        {
            Form_Normy_eksploatacyjne formnormyeksploatacyjne = new Form_Normy_eksploatacyjne(context);
            OpenChildForm(formnormyeksploatacyjne);
        }

        private void button_otworz_gwarancja_Click(object sender, EventArgs e)
        {
            Form_Gwarancja formGwarancja = new Form_Gwarancja(context);
            OpenChildForm(formGwarancja);
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_UR.Controls.Add(childForm);
            panel_UR.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}

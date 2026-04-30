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
            context = db;
            button_otworz_awaria.FlatStyle=FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle=FlatStyle.System;
            button_otworz_gwarancja.FlatStyle=FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle=FlatStyle.System;
            button_otworz_obsluga.FlatStyle=FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle=FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle=FlatStyle.System;
        }

        private void button_otworz_czesci_zamienne_Click(object sender, EventArgs e)
        {
            Form_czesci_zamienne formczesci = new Form_czesci_zamienne(context);
            OpenChildForm(formczesci);
            button_otworz_awaria.FlatStyle = FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.Flat;
            button_otworz_gwarancja.FlatStyle = FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.System;
            button_otworz_obsluga.FlatStyle = FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.System;
        }

        private void button_otworz_awaria_Click(object sender, EventArgs e)
        {
            Form_Awaria formawaria = new Form_Awaria(context);
            OpenChildForm(formawaria);
            button_otworz_awaria.FlatStyle = FlatStyle.Flat;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.System;
            button_otworz_gwarancja.FlatStyle = FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.System;
            button_otworz_obsluga.FlatStyle = FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.System;
        }

        private void button_otworz_obsluga_Click(object sender, EventArgs e)
        {
            Form_Obsluga formobsluga = new Form_Obsluga(context);
            OpenChildForm(formobsluga);
            button_otworz_awaria.FlatStyle = FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.System;
            button_otworz_gwarancja.FlatStyle = FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.System;
            button_otworz_obsluga.FlatStyle = FlatStyle.Flat;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.System;

        }

        private void button_otworz_rodzaj_obslugi_Click(object sender, EventArgs e)
        {
            Form_Rodzaj_obslugi formrodzajobslugi = new Form_Rodzaj_obslugi(context);
            OpenChildForm(formrodzajobslugi);
            button_otworz_awaria.FlatStyle = FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.System;
            button_otworz_gwarancja.FlatStyle = FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.System;
            button_otworz_obsluga.FlatStyle = FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.Flat;
        }

        private void button_otworz_normy_eksplatacyjne_Click(object sender, EventArgs e)
        {
            Form_Normy_eksploatacyjne formnormyeksploatacyjne = new Form_Normy_eksploatacyjne(context);
            OpenChildForm(formnormyeksploatacyjne);
            button_otworz_awaria.FlatStyle = FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.System;
            button_otworz_gwarancja.FlatStyle = FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.Flat;
            button_otworz_obsluga.FlatStyle = FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.System;
        }

        private void button_otworz_gwarancja_Click(object sender, EventArgs e)
        {
            Form_Gwarancja formGwarancja = new Form_Gwarancja(context);
            OpenChildForm(formGwarancja);
            button_otworz_awaria.FlatStyle = FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.System;
            button_otworz_gwarancja.FlatStyle = FlatStyle.Flat;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.System;
            button_otworz_obsluga.FlatStyle = FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.System;
        }
        private void button_otworz_napawy_Click(object sender, EventArgs e)
        {
            Form_Naprawy formnaprawy = new Form_Naprawy(context);
            OpenChildForm(formnaprawy);
            button_otworz_awaria.FlatStyle = FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.System;
            button_otworz_gwarancja.FlatStyle = FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.Flat;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.System;
            button_otworz_obsluga.FlatStyle = FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.System;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.System;
        }
        private void button_otworz_ocena_stanu_Click(object sender, EventArgs e)
        {
            Form_ocena_stanu formOcenaStanu = new Form_ocena_stanu(context);
            OpenChildForm(formOcenaStanu);
            button_otworz_awaria.FlatStyle = FlatStyle.System;
            button_otworz_czesci_zamienne.FlatStyle = FlatStyle.System;
            button_otworz_gwarancja.FlatStyle = FlatStyle.System;
            button_otworz_napawy.FlatStyle = FlatStyle.System;
            button_otworz_normy_eksplatacyjne.FlatStyle = FlatStyle.System;
            button_otworz_obsluga.FlatStyle = FlatStyle.System;
            button_otworz_ocena_stanu.FlatStyle = FlatStyle.Flat;
            button_otworz_rodzaj_obslugi.FlatStyle = FlatStyle.System;
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

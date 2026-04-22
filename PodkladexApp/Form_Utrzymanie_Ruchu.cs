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
        public Form_Utrzymanie_Ruchu(Models.PodkladexContext db)
        {
            InitializeComponent();
            context= db;
        }

        private void button_otworz_czesci_zamienne_Click(object sender, EventArgs e)
        {
            new Form_czesci_zamienne(context).Show();
        }

        private void button_otworz_awaria_Click(object sender, EventArgs e)
        {
            new Form_Awaria().Show();
        }

        private void button_otworz_obsluga_Click(object sender, EventArgs e)
        {
            new Form_Obsluga().Show();
        }

        private void button_otworz_rodzaj_obslugi_Click(object sender, EventArgs e)
        {
            new Form_Rodzaj_obslugi().Show();
        }

        private void button_otworz_normy_eksplatacyjne_Click(object sender, EventArgs e)
        {
            new Form_Normy_eksploatacyjne().Show(); 
        }

        private void button_otworz_gwarancja_Click(object sender, EventArgs e)
        {
            new Form_Gwarancja().Show(); 
        }
    }
}

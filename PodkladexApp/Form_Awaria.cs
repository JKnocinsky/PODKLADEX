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
    public partial class Form_Awaria : Form
    {
        public Form_Awaria(PodkladexContext context)
        {
            InitializeComponent();
            panel_posredniczaca.Visible = false;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button_powrot_z_awaria_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Awaria_Load(object sender, EventArgs e)
        {

        }

        private void button_dodaj_czesc_Click(object sender, EventArgs e)
        {
            panel_posredniczaca.Visible = true;
            button_dodaj_czesc.FlatStyle = FlatStyle.Flat;
        }
    }
}

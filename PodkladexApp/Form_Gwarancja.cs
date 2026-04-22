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
    public partial class Form_Gwarancja : Form
    {
        public Form_Gwarancja(PodkladexContext context)
        {
            InitializeComponent();
        }

        private void button_powrot_z_gwarancja_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

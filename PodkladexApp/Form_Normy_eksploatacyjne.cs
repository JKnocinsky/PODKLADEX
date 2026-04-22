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
    public partial class Form_Normy_eksploatacyjne : Form
    {
        public Form_Normy_eksploatacyjne(PodkladexContext context)
        {
            InitializeComponent();
        }

        private void button_powrot_z_normy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

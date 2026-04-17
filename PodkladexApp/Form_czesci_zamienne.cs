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
    public partial class Form_czesci_zamienne : Form
    {
        public Form_czesci_zamienne()
        {
            InitializeComponent();
        }

        private void button_powrot_z_czesci_zamienne_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

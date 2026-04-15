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
        public Form_Produkcja()
        {
            InitializeComponent();
        }

        private void btn_maszyny_Click(object sender, EventArgs e)
        {
            new Form_Maszyny().Show();
        }
    }
}

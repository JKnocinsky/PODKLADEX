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
        public Form_Maszyny()
        {
            InitializeComponent();
        }

        private void btn_dodaj_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Form_DodajMaszyne FD = new Form_DodajMaszyne(button.Name);
            FD.ShowDialog();
        }
    }
}

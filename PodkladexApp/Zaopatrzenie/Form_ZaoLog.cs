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
    public partial class Form_ZaoLog : Form
    {
        public Form_ZaoLog()
        {
            InitializeComponent();
        }

        private void button_Nowa_firma_Click_1(object sender, EventArgs e)
        {
            Form_Nowa_Firma form_Nowa_Firma = new Form_Nowa_Firma();
            form_Nowa_Firma.Show();
        }

        private void button_Edytuj_firmy_Click(object sender, EventArgs e)
        {

        }

        private void button_konf_mat_Click(object sender, EventArgs e)
        {

        }
    }
}

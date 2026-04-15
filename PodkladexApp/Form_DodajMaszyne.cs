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
    public partial class Form_DodajMaszyne : Form
    {
        public Form_DodajMaszyne()
        {
            InitializeComponent();
        }

        public Form_DodajMaszyne(string Nazwa)
        {
            InitializeComponent();
            switch (Nazwa) 
            {
                case "btn_dodaj":
                    label_tytul.Text = "Dodaj maszynę";

                    break;
                case "btn_edytuj":
                    label_tytul.Text = "Edytuj maszynę";
                    break;
            }
        }

        private void btn_funkcja_Click(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodkladexApp.Zaopatrzenie
{
    public partial class Form_SzczegolyZamowienia : Form
    {

        public class PozycjaKoszyka
        {
            public int IdProduktu { get; set; }
            public string NazwaProduktu { get; set; }
            public int IdMaterialu { get; set; }
            public string NazwaMaterialu { get; set; }
            public decimal Ilosc { get; set; }
            public decimal Cena { get; set; }
            public string Uwagi { get; set; }
        }

        public Form_SzczegolyZamowienia()
        {
            InitializeComponent();
        }



        private void comboBox_Produkt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Material_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form_SzczegolyZamowienia_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown_Ilosc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown_Cena_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Uwagi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_DodajPozycje_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_Koszyk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

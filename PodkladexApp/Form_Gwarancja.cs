using PodkladexApp.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PodkladexApp
{
    public partial class Form_Gwarancja : Form
    {
        PodkladexContext context;
        public Form_Gwarancja(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            comboBox_lista_gwarnacja_maszyny.DataSource = context.Maszyna.ToList();
            comboBox_lista_gwarnacja_maszyny.DisplayMember = "Nazwa";
            comboBox_lista_gwarnacja_maszyny.SelectedIndex = -1;
            comboBox_lista_firm.DataSource = context.Firma.ToList();
            comboBox_lista_firm.DisplayMember = "Nazwa";
            comboBox_lista_firm.SelectedIndex = -1;
            button_potwierdz.Visible = false;
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;
            dataGridView_gwarancja_info.Visible = false;


            label3.Visible = false;
            label_lista_rodzajow.Visible = false;
            comboBox_lista_gwarnacja_maszyny.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            textBox_miesiace_gwarancji.Visible = false;
            label_dodajczesc.Visible = false;
            textBox_warunki_gwarancji.Visible=false;
            comboBox_lista_firm.Visible = false;
        }

        private void button_powrot_z_gwarancja_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_dodaj_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Flat;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;
            button_potwierdz.Visible = true;
            dataGridView_gwarancja_info.Visible = false;
            label3.Visible = false;
            label_lista_rodzajow.Visible = true;
            comboBox_lista_gwarnacja_maszyny.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox_miesiace_gwarancji.Visible = true;
            label_dodajczesc.Visible = true;
            textBox_warunki_gwarancji.Visible = true;
            comboBox_lista_firm.Visible = true;
        }

        private void button_usun_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Flat;
            button_potwierdz.Visible = true;
            dataGridView_gwarancja_info.Visible = true;
            label3.Visible = true;

            dataGridView_gwarancja_info.Visible = true;
            label3.Visible = true;
            button_potwierdz.Visible = true;
            dataGridView_gwarancja_info.Visible = true;
            label3.Visible = true;
            label_lista_rodzajow.Visible = true;
            comboBox_lista_gwarnacja_maszyny.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox_miesiace_gwarancji.Visible = true;
            label_dodajczesc.Visible = true;
            textBox_warunki_gwarancji.Visible = true;
            comboBox_lista_firm.Visible = true;
        }

        private void button_edytuj_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Flat;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;
            button_potwierdz.Visible = true;
            dataGridView_gwarancja_info.Visible = true;
            label3.Visible = true;
            button_potwierdz.Visible = true;
            dataGridView_gwarancja_info.Visible = true;
            label3.Visible = true;
            label_lista_rodzajow.Visible = true;
            comboBox_lista_gwarnacja_maszyny.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox_miesiace_gwarancji.Visible = true;
            label_dodajczesc.Visible = true;
            textBox_warunki_gwarancji.Visible = true;
            comboBox_lista_firm.Visible = true;
        }
    }
}

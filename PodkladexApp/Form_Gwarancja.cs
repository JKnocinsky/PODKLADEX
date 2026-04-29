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

        bool flaga_usun = false;
        bool flaga_edytuj = false;
        bool flaga_dodaj = false;
        public Form_Gwarancja(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            comboBox_lista_gwarnacja_maszyny.DataSource = context.Maszyna.ToList();
            comboBox_lista_gwarnacja_maszyny.DisplayMember = "Nazwa";
            comboBox_lista_gwarnacja_maszyny.SelectedIndex = -1;
            comboBox_lista_gwarnacja_maszyny.ValueMember = "IdMaszyna";

            comboBox_lista_firm.DataSource = context.Firma.ToList();
            comboBox_lista_firm.DisplayMember = "Nazwa";
            comboBox_lista_firm.SelectedIndex = -1;

            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;

            panel1.Visible = false;
            panel2.Visible = false;

            var lista = context.Gwarancja
                .Select(g => new
                {
                    g.IdGwarancja,
                    g.IdMaszyna,
                    Maszyna = g.IdMaszynaNavigation.Nazwa,
                    g.IdFirma,
                    Firma = g.IdFirmaNavigation.Nazwa,
                    g.CzasGwarancji,
                    g.Warunki
                })
                    .ToList();
            dataGridView_gwarancja_info.DataSource = lista;
            dataGridView_gwarancja_info.Columns["IdGwarancja"].Visible = false;
            dataGridView_gwarancja_info.Columns["IdMaszyna"].Visible = false;
            dataGridView_gwarancja_info.Columns["IdFirma"].Visible = false;
            dataGridView_gwarancja_info.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



        }

        private void button_dodaj_gwarancje_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

            panel2.Visible = false;

            button_dodaj_gwarancje.FlatStyle = FlatStyle.Flat;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;
        }


        private void button_usun_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Flat;
            panel2.Visible = true;
            panel1.Visible = false;


        }

        private void button_edytuj_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Flat;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;

            panel1.Visible = true;
            panel2.Visible = true;

        }

        private void button_potwierdz_Click(object sender, EventArgs e)
        {
            if (flaga_usun == true)
            {
                Usun_czesc();
            }
            if (flaga_dodaj == true)
            {
                Dodaj_czesc();

            }
            if (flaga_edytuj == true)
            {
                Edytuj_czesc();
            }

        }
        private void Usun_czesc()
        {

        }
        private void Edytuj_czesc()
        {

        }
        private void Dodaj_czesc()
        {

        }

        private void dataGridView_gwarancja_info_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_gwarancja_info.CurrentRow != null)
            {
                var idMaszyny = dataGridView_gwarancja_info.CurrentRow.Cells["IdMaszyna"].Value;
                comboBox_lista_gwarnacja_maszyny.SelectedValue = idMaszyny;
            }
        }
        private void dataGridView_gwarancja_info_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
         
        }
    }
}

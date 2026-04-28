using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PodkladexApp.Models; // potrzebne

namespace PodkladexApp
{
    public partial class Form_czesci_zamienne : Form
    {
        PodkladexContext context; // dodac wszedzie w formularzach
        bool flaga_usun = false;
        bool flaga_edytuj = false;
        bool flaga_dodaj = false;
        public Form_czesci_zamienne(PodkladexContext context) // dodac wszedzie w formularzach (PodkladexContext context)
        {
            InitializeComponent();
            this.context = context; // dodac wszedzie w formularzach
            comboBox_lista_czesci.DataSource = context.CzescZamienna.ToList();
            comboBox_lista_czesci.DisplayMember = "Nazwa";
            comboBox_lista_czesci.SelectedIndex = -1;
            panel_lista.Visible = false;
            panel_nazwa.Visible = false;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            button_edytuj_czesc.FlatStyle= FlatStyle.Standard;
            button_usun_czesc.FlatStyle=FlatStyle.Standard;
        }

        private void button_powrot_z_czesci_zamienne_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_usun_czesc_Click(object sender, EventArgs e)
        {
            panel_lista.Visible = true;
            panel_nazwa.Visible = false;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            button_edytuj_czesc.FlatStyle = FlatStyle.Standard;
            button_usun_czesc.FlatStyle = FlatStyle.Flat;
            flaga_usun = true;
            flaga_edytuj = false;
            flaga_dodaj = false;

        }
        private void button_dodaj_czesc_Click(object sender, EventArgs e)
         {
             panel_nazwa.Visible = true;
             panel_lista.Visible = false;
                    button_dodaj_czesc.FlatStyle = FlatStyle.Flat;
                    button_edytuj_czesc.FlatStyle = FlatStyle.Standard;
                    button_usun_czesc.FlatStyle = FlatStyle.Standard;
                    flaga_dodaj = true;
            flaga_usun = false;
            flaga_edytuj = false;
        }
        private void button_edytuj_czesc_Click(object sender, EventArgs e)
        {
            panel_lista.Visible = true;
            panel_nazwa.Visible = true;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            button_edytuj_czesc.FlatStyle = FlatStyle.Flat;
            button_usun_czesc.FlatStyle = FlatStyle.Standard;
            flaga_edytuj = true;
            flaga_usun = false;
            flaga_dodaj = false;
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
               textBox_nazwa_czesci.Clear();
            }
            if (flaga_edytuj == true) 
            { 
                Edytuj_czesc(); 
            }
        }

        private void Usun_czesc()
        {
            CzescZamienna czescZamienna = new CzescZamienna();
            if (comboBox_lista_czesci.SelectedItem == null || comboBox_lista_czesci.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano części.", "Błąd");
            }
            else
            {
                czescZamienna = comboBox_lista_czesci.SelectedItem as CzescZamienna;
                context.CzescZamienna.Remove(czescZamienna);
                context.SaveChanges();
                comboBox_lista_czesci.DataSource = context.CzescZamienna.ToList();
                textBox_nazwa_czesci.Clear();
                comboBox_lista_czesci.SelectedIndex = -1;
            }
        }

        private void Dodaj_czesc()
        {
            CzescZamienna czescZamienna = new CzescZamienna();
            if (textBox_nazwa_czesci.Text == "" || textBox_nazwa_czesci.Text == null)
            {
                MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");

            }
            else if (context.CzescZamienna.Where(czesc => czesc.Nazwa == textBox_nazwa_czesci.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Nazwa jest zajeta! Wpisz inna nazwę.", "Błąd");
            }
            else
            {
                czescZamienna.Nazwa = textBox_nazwa_czesci.Text;
                context.CzescZamienna.Add(czescZamienna);
                context.SaveChanges();
        
                comboBox_lista_czesci.DataSource = context.CzescZamienna.ToList();
                comboBox_lista_czesci.SelectedItem = czescZamienna;
            }
        }
        private void Edytuj_czesc()
        {
            CzescZamienna czescZamienna = new CzescZamienna();
            if (comboBox_lista_czesci.SelectedItem == null || comboBox_lista_czesci.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano części.", "Błąd");
            }
            else
            {
                czescZamienna = comboBox_lista_czesci.SelectedItem as CzescZamienna;
                int index = comboBox_lista_czesci.SelectedIndex;

                if (textBox_nazwa_czesci.Text == "" || textBox_nazwa_czesci.Text == null)
                {
                    MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");

                }
                else
                {
                    czescZamienna.Nazwa = textBox_nazwa_czesci.Text;

                    context.SaveChanges();
                    comboBox_lista_czesci.DataSource = context.CzescZamienna.ToList();
                    textBox_nazwa_czesci.Clear();
                    comboBox_lista_czesci.SelectedIndex = index;
                }

            }
        }

        private void comboBox_lista_czesci_SelectedIndexChanged(object sender, EventArgs e)
        {
            CzescZamienna czescZamienna = comboBox_lista_czesci.SelectedItem as CzescZamienna;
            if (comboBox_lista_czesci.SelectedItem == null || comboBox_lista_czesci.SelectedIndex == -1)
            {
                textBox_nazwa_czesci.Text = "";
            }
            else
            {
                textBox_nazwa_czesci.Text = czescZamienna.Nazwa;
            }
        }

        private void label_dodajczesc_Click(object sender, EventArgs e)
        {

        }
    }
}

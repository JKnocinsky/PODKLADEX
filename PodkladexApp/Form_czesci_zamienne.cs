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
using PodkladexApp.Models;

namespace PodkladexApp
{
    public partial class Form_czesci_zamienne : Form
    {
        PodkladexContext context; // dodac wszedzie w formularzach
        public Form_czesci_zamienne(PodkladexContext context) // dodac wszedzie w formularzach (PodkladexContext context)
        {
            InitializeComponent();
            this.context = context; // dodac wszedzie w formularzach
            comboBox_lista_czesci.DataSource = context.CzescZamienna.ToList();
            comboBox_lista_czesci.DisplayMember = "Nazwa";
            comboBox_lista_czesci.SelectedIndex = -1;

        }

        private void button_powrot_z_czesci_zamienne_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_usun_czesc_Click(object sender, EventArgs e)
        {
            CzescZamienna czescZamienna = new CzescZamienna();
            if (comboBox_lista_czesci.SelectedItem == null || comboBox_lista_czesci.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano czesci.", "Błąd");
            }
            else
            {
                czescZamienna = comboBox_lista_czesci.SelectedItem as CzescZamienna;
                context.CzescZamienna.Remove(czescZamienna);
                context.SaveChanges();
                comboBox_lista_czesci.DataSource = context.CzescZamienna.ToList();
                textBox_nazwa_czesci.Clear();
            }
        }

        private void button_dodaj_czesc_Click(object sender, EventArgs e)
        {
            CzescZamienna czescZamienna = new CzescZamienna();



            if (textBox_nazwa_czesci.Text == "" || textBox_nazwa_czesci.Text == null)
            {
                MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.","Błąd");

            }
            else if(context.CzescZamienna.Where(czesc => czesc.Nazwa == textBox_nazwa_czesci.Text).FirstOrDefault()!=null)
            {
                MessageBox.Show("Nazwa jest zajeta! Wpisz inna nazwę.","Błąd");
            }
            else
            {
                czescZamienna.Nazwa = textBox_nazwa_czesci.Text;
                context.CzescZamienna.Add(czescZamienna);
                context.SaveChanges();
                comboBox_lista_czesci.DataSource = context.CzescZamienna.ToList();
                textBox_nazwa_czesci.Clear();
            }

        }

        private void button_edytuj_czesc_Click(object sender, EventArgs e)
        {
            CzescZamienna czescZamienna = new CzescZamienna();
            if (comboBox_lista_czesci.SelectedItem == null || comboBox_lista_czesci.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano czesci.","Błąd");
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
    }
}

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

namespace PodkladexApp
{
    public partial class Form_Rodzaj_obslugi : Form
    {
        bool flaga_usun = false;
        bool flaga_edytuj = false;
        bool flaga_dodaj = false;
        PodkladexContext context;
        public Form_Rodzaj_obslugi(PodkladexContext context)
        {
            InitializeComponent();
            panel_lista_rodzajow.Visible = false;
            panel_nazwa_opis.Visible = false;
            button_dodaj_obsluge.FlatStyle = FlatStyle.Standard;
            button_edytuj_czesc.FlatStyle = FlatStyle.Standard;
            button_usun_obsluga.FlatStyle = FlatStyle.Standard;
            this.context = context; // dodac wszedzie w formularzach
            comboBox_lista_rodzaj_obslug.DataSource = context.RodzajObslugi.ToList();
            comboBox_lista_rodzaj_obslug.DisplayMember = "Nazwa";
            comboBox_lista_rodzaj_obslug.SelectedIndex = -1;

        }

        private void button_dodaj_obsluge_Click(object sender, EventArgs e)
        {
            panel_lista_rodzajow.Visible = false;
            panel_nazwa_opis.Visible = true;
            button_dodaj_obsluge.FlatStyle = FlatStyle.Flat;
            button_edytuj_czesc.FlatStyle = FlatStyle.Standard;
            button_usun_obsluga.FlatStyle = FlatStyle.Standard;
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = true;
        }

        private void button_edytuj_czesc_Click(object sender, EventArgs e)
        {
            panel_lista_rodzajow.Visible = true;
            panel_nazwa_opis.Visible = true;
            button_dodaj_obsluge.FlatStyle = FlatStyle.Standard;
            button_edytuj_czesc.FlatStyle = FlatStyle.Flat;
            button_usun_obsluga.FlatStyle = FlatStyle.Standard;
            flaga_usun = false;
            flaga_edytuj = true;
            flaga_dodaj = false;
        }

        private void button_usun_obsluga_Click(object sender, EventArgs e)
        {
            panel_lista_rodzajow.Visible = true;
            panel_nazwa_opis.Visible = false;
            button_dodaj_obsluge.FlatStyle = FlatStyle.Standard;
            button_edytuj_czesc.FlatStyle = FlatStyle.Standard;
            button_usun_obsluga.FlatStyle = FlatStyle.Flat;
            flaga_usun = true;
            flaga_edytuj = false;
            flaga_dodaj = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flaga_usun == true)
            {
                Usun_czesc();
            }
            if (flaga_dodaj == true)
            {
                Dodaj_czesc();
                textBox_nazwa_obslugi.Clear();
            }
            if (flaga_edytuj == true)
            {
                Edytuj_czesc();
            }
        }
        private void Usun_czesc()
        {
            
            RodzajObslugi rodzajObslugi = new RodzajObslugi();
            if (comboBox_lista_rodzaj_obslug.SelectedItem == null || comboBox_lista_rodzaj_obslug.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano części.", "Błąd");
            }
            else
            {
                rodzajObslugi = comboBox_lista_rodzaj_obslug.SelectedItem as RodzajObslugi;
                context.RodzajObslugi.Remove(rodzajObslugi);
                context.SaveChanges();
                comboBox_lista_rodzaj_obslug.DataSource = context.RodzajObslugi.ToList();
                comboBox_lista_rodzaj_obslug.SelectedIndex = -1;
            }
        }
        private void Dodaj_czesc()
        {
            RodzajObslugi rodzajObslugi = new RodzajObslugi();
            if (textBox_nazwa_obslugi.Text == "" || textBox_nazwa_obslugi.Text == null)
            {
                MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");

            }
            else if (context.RodzajObslugi.Where(czesc => czesc.Nazwa == textBox_nazwa_obslugi.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Nazwa jest zajeta! Wpisz inna nazwę.", "Błąd");
            }
            else
            {
                rodzajObslugi.Nazwa = textBox_nazwa_obslugi.Text;
                rodzajObslugi.Opis = textBox_opis_rodzaj_obslugi.Text;
                context.RodzajObslugi.Add(rodzajObslugi);
                context.SaveChanges();

                comboBox_lista_rodzaj_obslug.DataSource = context.RodzajObslugi.ToList();
                comboBox_lista_rodzaj_obslug.SelectedItem = rodzajObslugi;
            }
        }
        private void Edytuj_czesc()
        {
            RodzajObslugi rodzajObslugi = new RodzajObslugi();
            if (comboBox_lista_rodzaj_obslug.SelectedItem == null || comboBox_lista_rodzaj_obslug.SelectedIndex == -1)
            {
                MessageBox.Show("Nie wybrano części.", "Błąd");
            }
            else
            {
                rodzajObslugi = comboBox_lista_rodzaj_obslug.SelectedItem as RodzajObslugi;
                int index = comboBox_lista_rodzaj_obslug.SelectedIndex;

                if (textBox_nazwa_obslugi.Text == "" || textBox_nazwa_obslugi.Text == null)
                {
                    MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");

                }
                else
                {
                    rodzajObslugi.Nazwa = textBox_nazwa_obslugi.Text;
                    rodzajObslugi.Opis = textBox_opis_rodzaj_obslugi.Text;
                    context.SaveChanges();
                    comboBox_lista_rodzaj_obslug.DataSource = context.RodzajObslugi.ToList();
                    textBox_nazwa_obslugi.Clear();
                    comboBox_lista_rodzaj_obslug.SelectedIndex = index;
                }

            }
        }
    }
}

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

namespace PodkladexApp.Produkcja
{
    public partial class Form_DodajWyposazenie : Form
    {
        PodkladexContext context;
        public Form_DodajWyposazenie(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            cmb_wlasciwosc.DataSource = context.Wlasciwosc.Select(w => w.NazwaParametru).ToList();

            dgv_wlasciwosci.Columns.Add("colWlasciwosc", "Właściwość");
            dgv_wlasciwosci.Columns.Add("colWartosc", "Wartość");
        }

        private void btn_zapiszZamknij_Click(object sender, EventArgs e)
        {
            Wyposazenie noweWyposazenie = new Wyposazenie();

            if (txtbox_Nazwa.Text == "" || txtbox_Nazwa.Text == null)
            {
                MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");

            }
            else if (context.Wyposazenie.Where(wyposazenie => wyposazenie.Nazwa == txtbox_Nazwa.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Nazwa jest zajeta! Wpisz inna nazwę.", "Błąd");
            }
            else
            {
                noweWyposazenie.Nazwa = txtbox_Nazwa.Text;
                noweWyposazenie.Uwagi = txtbox_Uwagi.Text;
                context.Wyposazenie.Add(noweWyposazenie);
                context.SaveChanges();
                MessageBox.Show("Dodano nowe Wyposażenie!", "Dodawanie wyposażenia");

                foreach (DataGridViewRow row in dgv_wlasciwosci.Rows)
                {
                    if (row.Cells["colWlasciwosc"].Value != null && row.Cells["colWartosc"].Value != null)
                    {
                        WyposazenieWlasciwosci noweWlasc = new WyposazenieWlasciwosci();
                        noweWlasc.IdWyposazenie = context.Wyposazenie.Where(wyposazenie => wyposazenie.Nazwa == txtbox_Nazwa.Text).FirstOrDefault().IdWyposazenie;
                        noweWlasc.IdWlasciwosci = context.Wlasciwosc.Where(wlasciwosc => wlasciwosc.NazwaParametru == row.Cells["colWlasciwosc"].Value.ToString()).FirstOrDefault().IdWlasciwosci;
                        noweWlasc.Wartosc = decimal.Parse(row.Cells["colWartosc"].Value.ToString());
                        context.WyposazenieWlasciwosci.Add(noweWlasc);
                        context.SaveChanges();
                    }
                }

                this.Close();
            }
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            WyposazenieWlasciwosci noweWlasc = new WyposazenieWlasciwosci();

            if (cmb_wlasciwosc.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano właściwości! Wybierz właściwość.", "Błąd");
            }
            else if (txtbox_wartosc.Text == "" || txtbox_wartosc.Text == null)
            {
                MessageBox.Show("Wartość jest pusta! Wpisz wartość.", "Błąd");
            }
            else if (!decimal.TryParse(txtbox_wartosc.Text.Trim(), out decimal parsedValue))
            {
                MessageBox.Show("Wprowadzono nieprawidłowy format wartości. Wprowadź liczbę zmiennoprzecinkową.", "Błąd");
                return;
            }
            else
            {
                dgv_wlasciwosci.Rows.Add(cmb_wlasciwosc.SelectedItem.ToString(), txtbox_wartosc.Text);
            }
        }
    }
}

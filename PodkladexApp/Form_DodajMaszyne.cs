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
    public partial class Form_DodajMaszyne : Form
    {
        PodkladexContext context;
        int btn;

        public Form_DodajMaszyne(PodkladexContext context, string Nazwa, Maszyna maszyna)
        {
            InitializeComponent();
            this.context = context;
            dtp_dataUruch.CustomFormat = "dd-MM-yyyy";
            dtp_dataZakup.CustomFormat = "dd-MM-yyyy";
            dtp_dataWyl.CustomFormat = "dd-MM-yyyy";
        }

        public Form_DodajMaszyne(PodkladexContext context, string buttonName)
        {
            InitializeComponent();
            this.context = context;
            dtp_dataUruch.CustomFormat = "dd-MM-yyyy";
            dtp_dataZakup.CustomFormat = "dd-MM-yyyy";
            dtp_dataWyl.CustomFormat = "dd-MM-yyyy";
        }

        private void btn_funkcja_Click(object sender, EventArgs e)
        {
            Maszyna nowaMaszyna = new Maszyna();

            if (txtbox_Nazwa.Text == "" || txtbox_Nazwa.Text == null)
            {
                MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");

            }
            else if (context.Maszyna.Where(maszyna => maszyna.Nazwa == txtbox_Nazwa.Text).FirstOrDefault() != null)
            {
                MessageBox.Show("Nazwa jest zajeta! Wpisz inna nazwę.", "Błąd");
            }
            else
            {
                nowaMaszyna.Nazwa = txtbox_Nazwa.Text;
                nowaMaszyna.DataUruchomienia = DateOnly.FromDateTime(dtp_dataUruch.Value);
                nowaMaszyna.DataZakupu = DateOnly.FromDateTime(dtp_dataZakup.Value);
                nowaMaszyna.DataWylaczenia = DateOnly.FromDateTime(dtp_dataWyl.Value);
                context.Maszyna.Add(nowaMaszyna);
                context.SaveChanges();
                MessageBox.Show("Dodano nową maszynę!", "Dodawanie maszyny");
            }
        }
    }
}

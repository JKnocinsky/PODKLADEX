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
    public partial class Form_Jakosc : Form
    {
        PodkladexContext context;
        Form activeForm = null;
        public Form_Jakosc(PodkladexContext db)
        {
            InitializeComponent();
            context = db;
        }


        private void btn_Material_Click_1(object sender, EventArgs e)
        {
            Form_Material formMaterial = new Form_Material(context);
            OpenChildForm(formMaterial);
        }
        private void btn_KontrolaMat_Click(object sender, EventArgs e)
        {
            Form_KontrolaMat formKontrolaMat = new Form_KontrolaMat(context);
            OpenChildForm(formKontrolaMat);
        }
        private void btn_KontrolaProd_Click(object sender, EventArgs e)
        {
            Form_KontrolaProd formKontrolaProd = new Form_KontrolaProd(context);
            OpenChildForm(formKontrolaProd);
        }
        private void btn_Efektywnosc_Click(object sender, EventArgs e)
        {
            Form_Efektywnosc formEfektywnosc = new Form_Efektywnosc(context);
            OpenChildForm(formEfektywnosc);
        }
        private void btn_RaportKontrola_Click(object sender, EventArgs e)
        {
            Form_RaportKontrola formRaportKontrola = new Form_RaportKontrola(context);
            OpenChildForm(formRaportKontrola);
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Jakosc.Controls.Add(childForm);
            panel_Jakosc.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form_Jakosc_Load(object sender, EventArgs e)
        {

        }
    }

}

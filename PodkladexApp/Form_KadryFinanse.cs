using System;
using System.Drawing;
using System.Windows.Forms;

namespace PodkladexApp
{
    public partial class Form_KadryFinanse : Form
    {
        private Form activeForm = null;

        public Form_KadryFinanse()
        {
            InitializeComponent();

            UstawStylPrzyciskow();
            UstawAktywnyPrzycisk(button_listaosob);
            OpenChildForm(new Form_ListaOsob());
        }

        private void UstawStylPrzyciskow()
        {
            button_listaosob.UseVisualStyleBackColor = false;
            button_urlopy.UseVisualStyleBackColor = false;
            button_szkolenia.UseVisualStyleBackColor = false;
            button_badania.UseVisualStyleBackColor = false;
            button_umowy.UseVisualStyleBackColor = false;

            button_listaosob.BackColor = SystemColors.Control;
            button_urlopy.BackColor = SystemColors.Control;
            button_szkolenia.BackColor = SystemColors.Control;
            button_badania.BackColor = SystemColors.Control;
            button_umowy.BackColor = SystemColors.Control;
        }

        private void ResetujKoloryPrzyciskow()
        {
            button_listaosob.BackColor = SystemColors.Control;
            button_urlopy.BackColor = SystemColors.Control;
            button_szkolenia.BackColor = SystemColors.Control;
            button_badania.BackColor = SystemColors.Control;
            button_umowy.BackColor = SystemColors.Control;
        }

        private void UstawAktywnyPrzycisk(Button aktywnyPrzycisk)
        {
            ResetujKoloryPrzyciskow();
            aktywnyPrzycisk.BackColor = Color.Silver;
        }

        private void OpenChildForm(Form childForm, bool dopasujDoCalegoPanelu = true)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            panel_kadryfinanse.Controls.Clear();
            panel_kadryfinanse.Controls.Add(childForm);
            panel_kadryfinanse.Tag = childForm;

            if (dopasujDoCalegoPanelu)
            {
                childForm.Dock = DockStyle.Fill;
            }
            else
            {
                childForm.Dock = DockStyle.None;
                childForm.Location = new Point(5, 5);
            }

            childForm.BringToFront();
            childForm.Show();
        }

        private void button_listaosob_Click(object sender, EventArgs e)
        {
            UstawAktywnyPrzycisk(button_listaosob);
            OpenChildForm(new Form_ListaOsob());
        }

        private void button_umowy_Click(object sender, EventArgs e)
        {
            UstawAktywnyPrzycisk(button_umowy);
            OpenChildForm(new Form_Umowy());
        }

        private void button_szkolenia_Click(object sender, EventArgs e)
        {
            UstawAktywnyPrzycisk(button_szkolenia);
            OpenChildForm(new Form_Szkolenia());
        }

        private void button_badania_Click(object sender, EventArgs e)
        {
            UstawAktywnyPrzycisk(button_badania);
            OpenChildForm(new Form_Badania());
        }

        private void button_urlopy_Click(object sender, EventArgs e)
        {
            UstawAktywnyPrzycisk(button_urlopy);
            OpenChildForm(new Form_Urlopy());
        }
    }
}
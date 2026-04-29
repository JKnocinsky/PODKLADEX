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
            PrzygotujPrzycisk(button_listaosob);
            PrzygotujPrzycisk(button_urlopy);
            PrzygotujPrzycisk(button_szkolenia);
            PrzygotujPrzycisk(button_badania);
            PrzygotujPrzycisk(button_umowy);
        }

        private void PrzygotujPrzycisk(Button button)
        {
            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            button.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
            button.BackColor = SystemColors.Control;
            button.TabStop = false;
        }

        private void ResetujWygladPrzyciskow()
        {
            UstawNieaktywnyPrzycisk(button_listaosob);
            UstawNieaktywnyPrzycisk(button_urlopy);
            UstawNieaktywnyPrzycisk(button_szkolenia);
            UstawNieaktywnyPrzycisk(button_badania);
            UstawNieaktywnyPrzycisk(button_umowy);
        }

        private void UstawNieaktywnyPrzycisk(Button button)
        {
            button.BackColor = SystemColors.Control;
            button.FlatAppearance.BorderSize = 1;
        }

        private void UstawAktywnyPrzycisk(Button aktywnyPrzycisk)
        {
            ResetujWygladPrzyciskow();
            aktywnyPrzycisk.BackColor = Color.Gainsboro;
            aktywnyPrzycisk.FlatAppearance.BorderSize = 0;
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
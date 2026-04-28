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
            OpenChildForm(new Form_ListaOsob());
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
            OpenChildForm(new Form_ListaOsob());
        }

        private void button_umowy_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Umowy());
        }

        private void button_szkolenia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Szkolenia());
        }

        private void button_badania_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Badania());
        }

        private void button_urlopy_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Urlopy());
        }
    }
}
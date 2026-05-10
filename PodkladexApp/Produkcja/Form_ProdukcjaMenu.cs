using PodkladexApp.Models;
using PodkladexApp.Produkcja;
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
    public partial class Form_ProdukcjaMenu : Form
    {
        PodkladexContext db;
        Form activeForm = null;

        public Form_ProdukcjaMenu(PodkladexContext db)
        {
            this.db = db;
            InitializeComponent();

            btn_odpady.Click -= btn_odpady_Click;
            btn_odpady.Click += btn_odpady_Click;
            btn_odpady.BringToFront();
        }

        private void btn_maszyny_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            Form_Maszyny form = new Form_Maszyny(db);
            OpenChildForm(form);
        }

        private void btn_wyp_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            Form_MaszynaWyp form = new Form_MaszynaWyp(db);
            OpenChildForm(form);
        }

        private void btn_normyP_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            Form_NormaProd form = new Form_NormaProd(db);
            OpenChildForm(form);
        }

        private void btn_prod_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();

            RemoveProdButtons();

            // 1. Przesunięcie przycisku
            tableLayoutPanel1.SetRow(btn_odpady, 7);

            // 2. KLUCZOWE: Wymuszenie bycia na wierzchu i odświeżenie kontrolki
            btn_odpady.BringToFront();

            var btnZaplanuj = new Button
            {
                Name = "btn_zaplanujProd",
                Text = "Zaplanuj i zatwierdź",
                Size = new Size((int)(btn_prod.Width * 0.7), btn_prod.Height),
                Font = new Font("Segoe UI", 14.5F),
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            btnZaplanuj.Click += btnZaplanuj_Click;

            var btnZatwierdz = new Button
            {
                Name = "btn_zatwierdzProd",
                Text = "Rozlicz",
                Size = new Size((int)(btn_prod.Width * 0.7), btn_prod.Height),
                Font = new Font("Segoe UI", 14.5F),
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            btnZatwierdz.Click += btnZatwierdz_Click;

            tableLayoutPanel1.Controls.Add(btnZaplanuj, 0, 5);
            tableLayoutPanel1.Controls.Add(btnZatwierdz, 0, 6);

            tableLayoutPanel1.ResumeLayout(true);
        }

        private void btnZaplanuj_Click(object? sender, EventArgs e)
        {
            var form = new Form_ProdukcjaZaplanuj(db);
            OpenChildForm(form);
        }

        private void btnZatwierdz_Click(object? sender, EventArgs e)
        {
            var form = new Form_ProdukcjaZatwierdz(db);
            OpenChildForm(form);
        }

        private void RemoveProdButtons()
        {
            var names = new[] { "btn_zaplanujProd", "btn_zatwierdzProd" };
            foreach (var name in names)
            {
                var found = tableLayoutPanel1.Controls.Find(name, true);
                foreach (Control c in found)
                {
                    tableLayoutPanel1.Controls.Remove(c);
                    c.Dispose();
                }
            }

            // Powrót i ponowne wymuszenie widoczności
            tableLayoutPanel1.SetRow(btn_odpady, 5);
            btn_odpady.BringToFront();
        }

        private void OpenChildForm(Form childForm)
        {
            Panel panel = tableLayoutPanel1.Controls["panel_Produkcja"] as Panel;

            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            if (panel != null)
            {
                panel.Controls.Add(childForm);
                panel.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }

        private void btn_Pracownicy_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            Form_ProdukcjaPracownicy form = new Form_ProdukcjaPracownicy(db);
            OpenChildForm(form);
        }

        private void btn_odpady_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            Form_ProdukcjaOdpady form = new Form_ProdukcjaOdpady(db);
            OpenChildForm(form);
        }
    }
}
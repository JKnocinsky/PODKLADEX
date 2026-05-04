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
            //Panel panel = new Panel();
            //tableLayoutPanel1.Controls.Add(panel,0,0);
            //panel.Location = new Point(3, 3);
            //panel.Size = new Size(1650, 800);
            //panel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            //panel.BorderStyle = BorderStyle.FixedSingle;
            //panel.BackColor = Color.Transparent;
            //panel.BringToFront();
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
            // Usuń wszystkie kontrolki które znajdują się w wierszach 5 i 6 tableLayoutPanel1
            var toRemove = tableLayoutPanel1.Controls
                .Cast<Control>()
                .Where(c =>
                {
                    var pos = tableLayoutPanel1.GetPositionFromControl(c);
                    return pos.Row == 5 || pos.Row == 6;
                })
                .ToList();

            foreach (var ctrl in toRemove)
            {
                tableLayoutPanel1.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            var btnZaplanuj = new Button
            {
                Name = "btn_zaplanujProd",
                Text = "Zaplanuj produkcję",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                Font = new Font("Segoe UI", 14.5F),
                Size = new Size(300, 69)
            };

            // attach click handler to create and show Form_ProdukcjaZaplanuj
            btnZaplanuj.Click += btnZaplanuj_Click;

            tableLayoutPanel1.Controls.Add(btnZaplanuj, 0, 5);
            btnZaplanuj.BringToFront();

            var btnZatwierdz = new Button
            {
                Name = "btn_zatwierdzProd",
                Text = "Zatwierdź produkcję",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                Font = new Font("Segoe UI", 14.5F),
                Size = new Size(300, 69)
            };

            tableLayoutPanel1.Controls.Add(btnZatwierdz, 0, 6);
            btnZatwierdz.BringToFront();
        }

        // click handler: tworzy Form_ProdukcjaZaplanuj przekazując db i otwiera go w panelu
        private void btnZaplanuj_Click(object? sender, EventArgs e)
        {
            var form = new Form_ProdukcjaZaplanuj(db);
            OpenChildForm(form);
        }

        // Usuwa przyciski utworzone przez btn_prod (jeśli istnieją)
        private void RemoveProdButtons()
        {
            if (tableLayoutPanel1 == null) return;

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
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}

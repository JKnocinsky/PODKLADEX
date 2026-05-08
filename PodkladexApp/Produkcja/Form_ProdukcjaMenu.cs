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

            // KLUCZOWE: Na starcie ustawiamy wysokość wierszy 5 i 6 na 0, 
            // aby pozostałe przyciski nie były nienaturalnie rozciągnięte.
            HideProductionRows();
        }

        private void HideProductionRows()
        {
            tableLayoutPanel1.SuspendLayout();
            // Sprawdzamy czy panel ma wystarczającą liczbę wierszy
            if (tableLayoutPanel1.RowStyles.Count > 6)
            {
                // Ustawiamy wysokość na 0 (Absolute), co sprawia, że wiersze znikają z layoutu
                tableLayoutPanel1.RowStyles[5] = new RowStyle(SizeType.Absolute, 0);
                tableLayoutPanel1.RowStyles[6] = new RowStyle(SizeType.Absolute, 0);
            }
            tableLayoutPanel1.ResumeLayout(true);
        }

        private void ShowProductionRows()
        {
            tableLayoutPanel1.SuspendLayout();
            // Przywracamy wysokość wierszy do wartości procentowej zgodnej z resztą menu (np. 14%)
            if (tableLayoutPanel1.RowStyles.Count > 6)
            {
                tableLayoutPanel1.RowStyles[5] = new RowStyle(SizeType.Percent, 14.28f);
                tableLayoutPanel1.RowStyles[6] = new RowStyle(SizeType.Percent, 14.28f);
            }
            tableLayoutPanel1.ResumeLayout(true);
        }

        private void btn_maszyny_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            HideProductionRows(); // Zwijamy wiersze 5 i 6 przy wyborze innej opcji
            Form_Maszyny form = new Form_Maszyny(db);
            OpenChildForm(form);
        }

        private void btn_wyp_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            HideProductionRows();
            Form_MaszynaWyp form = new Form_MaszynaWyp(db);
            OpenChildForm(form);
        }

        private void btn_normyP_Click(object sender, EventArgs e)
        {
            RemoveProdButtons();
            HideProductionRows();
            Form_NormaProd form = new Form_NormaProd(db);
            OpenChildForm(form);
        }

        private void btn_prod_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();

            // 1. Usuwamy stare kontrolki, jeśli istniały
            var toRemove = tableLayoutPanel1.Controls
                .Cast<Control>()
                .Where(c => {
                    var pos = tableLayoutPanel1.GetPositionFromControl(c);
                    return pos.Row == 5 || pos.Row == 6;
                })
                .ToList();

            foreach (var ctrl in toRemove)
            {
                tableLayoutPanel1.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            // 2. Tworzymy przyciski z Dock = Fill (znacznie stabilniejszy niż Anchor przy zmianach rozmiaru)
            var btnZaplanuj = new Button
            {
                Name = "btn_zaplanujProd",
                Text = "Zaplanuj i zatwierdź produkcję",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14.5F),
                Margin = new Padding(10)
            };
            btnZaplanuj.Click += btnZaplanuj_Click;

            var btnZatwierdz = new Button
            {
                Name = "btn_zatwierdzProd",
                Text = "Rozlicz produkcję",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14.5F),
                Margin = new Padding(10)
            };
            btnZatwierdz.Click += btnZatwierdz_Click;

            // 3. Dodajemy kontrolki i rozwijamy wiersze
            tableLayoutPanel1.Controls.Add(btnZaplanuj, 0, 5);
            tableLayoutPanel1.Controls.Add(btnZatwierdz, 0, 6);

            ShowProductionRows(); // To wymusi na panelu prawidłowy podział miejsca i "ściśnie" resztę przycisków

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
    }
}
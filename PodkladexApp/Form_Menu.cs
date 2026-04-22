using PodkladexApp.Models;

namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        PodkladexContext db;
        Form activeForm = null;

        public Form_Menu()
        {
            InitializeComponent();
            db = new PodkladexContext();
            //List<Pracownik> pracownicy = db.Pracownik.ToList();

            //comboBox1.DataSource = pracownicy;
        }

        private void btn_Kadry_Click(object sender, EventArgs e)
        {
            Form_ListaOsob form_ListaOsob = new Form_ListaOsob();
            form_ListaOsob.BackColor = Color.Black;
            form_ListaOsob.Padding = new Padding(2);
            form_ListaOsob.Width = 824;
            form_ListaOsob.Height = 756;

            OpenChildForm(form_ListaOsob, false);
        }


        private void btn_Kontrola_Jakosci_Click(object sender, EventArgs e)
        {
            Form_Jakosc form_Jakosc = new Form_Jakosc(db);
            OpenChildForm(form_Jakosc);
        }

        private void btn_Zaopatrzenie_Click(object sender, EventArgs e)
        {
            Form_ZaoLog form_ZaoLog = new Form_ZaoLog();
            OpenChildForm(form_ZaoLog);
        }

        private void btn_Produkcja_Click(object sender, EventArgs e)
        {
            Form_Produkcja form_Produkcja = new Form_Produkcja(db);
            OpenChildForm(form_Produkcja);
        }

        private void btn_Utrzymanie_Ruchu_Click(object sender, EventArgs e)
        {
            Form_Utrzymanie_Ruchu form = new Form_Utrzymanie_Ruchu(db);
            OpenChildForm(form);
        }

        public void OpenChildForm(Form childForm, bool dopasujDoCalegoPanelu = true)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            panel_Main.Controls.Clear();
            panel_Main.Controls.Add(childForm);
            panel_Main.Tag = childForm;

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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

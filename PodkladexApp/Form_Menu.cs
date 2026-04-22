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
            Form_Kadry_finanse formKadry = new Form_Kadry_finanse();
            OpenChildForm(formKadry);
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

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Main.Controls.Add(childForm);
            panel_Main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

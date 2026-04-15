using PodkladexApp.Models;

namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        PodkladexContext db;

        public Form_Menu()
        {
            InitializeComponent();
            db = new PodkladexContext();
            List<Pracownik> pracownicy = db.Pracownik.ToList();

            comboBox1.DataSource = pracownicy;
        }

        private void btn_Kadry_Click(object sender, EventArgs e)
        {
            Form_Kadry_finanse formKadry = new Form_Kadry_finanse();
            formKadry.Show();
        }


        private void btn_Kontrola_Jakosci_Click(object sender, EventArgs e)
        {
            new Form_Jakosc().Show();
        }

        private void btn_Zaopatrzenie_Click(object sender, EventArgs e)
        {
            Form_ZaoLog form_ZaoLog = new Form_ZaoLog();
            form_ZaoLog.Show();
        }
    }
}

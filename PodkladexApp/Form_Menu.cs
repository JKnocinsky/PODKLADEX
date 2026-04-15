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
            pracownicy.Add(new Pracownik { IdOsoba = 1 });
            pracownicy.Add(new Pracownik { IdOsoba = 2 });

            comboBox1.DataSource = pracownicy;
        }

        private void btn_Kontrola_Jakosci_Click(object sender, EventArgs e)
        {
            new Form_Jakosc().Show();
        }
    }
}

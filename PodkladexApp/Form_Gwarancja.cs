using PodkladexApp.Models;
using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PodkladexApp
{
    public partial class Form_Gwarancja : Form
    {
        PodkladexContext context;
        bool flaga_usun = false;
        bool flaga_edytuj = false;
        bool flaga_dodaj = false;

        public Form_Gwarancja(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            comboBox_lista_gwarnacja_maszyny.DataSource = context.Maszyna.ToList();
            comboBox_lista_gwarnacja_maszyny.DisplayMember = "Nazwa";
            comboBox_lista_gwarnacja_maszyny.ValueMember = "IdMaszyna";
            comboBox_lista_gwarnacja_maszyny.SelectedIndex = -1;


            comboBox_lista_firm.DataSource = context.Firma.ToList();
            comboBox_lista_firm.DisplayMember = "Nazwa";
            comboBox_lista_firm.SelectedIndex = -1;
            comboBox_lista_firm.ValueMember = "IdFirma";

            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;

            OdswiezObslugi();




        }
        private void Czyszczenie()
        {
            comboBox_lista_firm.SelectedIndex = -1;
            comboBox_lista_gwarnacja_maszyny.SelectedIndex = -1;
            textBox_warunki_gwarancji.Text= string.Empty;
            textBox_uruchomienie.Text= string.Empty;
            textBox_miesiace_gwarancji.Text = string.Empty;
        }
        private void OdswiezObslugi()
        {
            var lista = context.Gwarancja
                .Select(g => new
                {
                    g.IdGwarancja,
                    g.IdMaszyna,
                    Data = g.IdMaszynaNavigation.DataUruchomienia,
                    Maszyna = g.IdMaszynaNavigation.Nazwa,
                    g.IdFirma,
                    Firma = g.IdFirmaNavigation.Nazwa,
                    CzasGwarancji = (int)g.CzasGwarancji, //do zmiany dopóki nie wygeneeuje ktoś nowego modelu relacyjnego | CzasGwarancji,
                    g.Warunki
                })
                    .ToList();
            dataGridView_gwarancja_info.DataSource = lista;
            dataGridView_gwarancja_info.Columns["IdGwarancja"].Visible = false;
            dataGridView_gwarancja_info.Columns["IdMaszyna"].Visible = false;
            dataGridView_gwarancja_info.Columns["IdFirma"].Visible = false;
            dataGridView_gwarancja_info.Columns["Data"].Visible = false;
            dataGridView_gwarancja_info.Columns["CzasGwarancji"].HeaderText = "Czas Gwarancji";
            dataGridView_gwarancja_info.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_gwarancja_info.Columns["CzasGwarancji"].Width = 100;
            dataGridView_gwarancja_info.Columns["Maszyna"].Width = 100;
            dataGridView_gwarancja_info.Columns["Firma"].Width = 150;
            dataGridView_gwarancja_info.Columns["Warunki"].Width = 250;
            dataGridView_gwarancja_info.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void button_dodaj_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Flat;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = true;
        }


        private void button_usun_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_usun_gwarancje.FlatStyle = FlatStyle.Flat;
            flaga_usun = true;
            flaga_edytuj = false;
            flaga_dodaj = false;

        }

        private void button_edytuj_gwarancje_Click(object sender, EventArgs e)
        {
            button_dodaj_gwarancje.FlatStyle = FlatStyle.Standard;
            button_edytuj_gwarancje.FlatStyle = FlatStyle.Flat;
            button_usun_gwarancje.FlatStyle = FlatStyle.Standard;
            flaga_usun = false;
            flaga_edytuj = true;
            flaga_dodaj = false;

        }

        private void button_potwierdz_Click(object sender, EventArgs e)
        {
            if (flaga_usun == true)
            {
                Usun_czesc();
                OdswiezObslugi();
                Czyszczenie();
            }
            if (flaga_dodaj == true)
            {
                Dodaj_czesc();
                OdswiezObslugi();
                Czyszczenie();

            }
            if (flaga_edytuj == true)
            {

                Edytuj_czesc();
                OdswiezObslugi();
                Czyszczenie();
            }

        }
        private void Usun_czesc()
        {
            if (dataGridView_gwarancja_info.CurrentRow == null)
            {
                MessageBox.Show("Wybierz gwarancję do usunięcia.","Błąd");
                
            }

            int id = Convert.ToInt32(dataGridView_gwarancja_info.CurrentRow.Cells["IdGwarancja"].Value);

            var gwarancja = context.Gwarancja
            .AsEnumerable()
            .FirstOrDefault(g => g.IdGwarancja == id);

            if (gwarancja == null)
            {
                MessageBox.Show("Nie znaleziono gwarancji.", "Błąd");
                
            }

            var result = MessageBox.Show(
                "Czy na pewno chcesz usunąć gwarancję?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                context.Gwarancja.Remove(gwarancja);
                context.SaveChanges();

                MessageBox.Show("Usunięto gwarancję.","Informacja");
            }
            else
            {
                MessageBox.Show("Anulowano.","Błąd");
            }



        }
        private void Edytuj_czesc()
        {
            if (dataGridView_gwarancja_info.CurrentRow == null)
            {
                MessageBox.Show("Wybierz gwarancję do edycji.", "Błąd");
                
            }

            // ID z tabeli
            int id = Convert.ToInt32(dataGridView_gwarancja_info.CurrentRow.Cells["IdGwarancja"].Value);

            var gwarancja = context.Gwarancja.FirstOrDefault(g => g.IdGwarancja == id);

            if (gwarancja == null)
            {
                MessageBox.Show("Nie znaleziono gwarancji.", "Błąd");
               
            }

            // walidacja maszyny
            if (comboBox_lista_gwarnacja_maszyny.SelectedItem == null)
            {
                MessageBox.Show("Wybierz maszynę.", "Błąd");
               
            }

            // walidacja firmy
            if (comboBox_lista_firm.SelectedItem == null)
            {
                MessageBox.Show("Wybierz firmę.", "Błąd");
                
            }

            // walidacja miesięcy
            if (!int.TryParse(textBox_miesiace_gwarancji.Text, out int miesiace) || miesiace < 0)
            {
                MessageBox.Show("Niepoprawna liczba miesięcy.", "Błąd");
               
            }

            var maszyna = (Maszyna)comboBox_lista_gwarnacja_maszyny.SelectedItem;
            var firma = (Firma)comboBox_lista_firm.SelectedItem;

            // aktualizacja
            gwarancja.IdMaszyna = maszyna.IdMaszyna;
            gwarancja.IdFirma = firma.IdFirma;
            gwarancja.CzasGwarancji = miesiace;
            gwarancja.Warunki = string.IsNullOrWhiteSpace(textBox_warunki_gwarancji.Text)
                ? null
                : textBox_warunki_gwarancji.Text;

            context.SaveChanges();

            MessageBox.Show("Zaktualizowano gwarancję.", "Informacja");
        }
        private void Dodaj_czesc()
        {
            // 1. Walidacja maszyny
            if (comboBox_lista_gwarnacja_maszyny.SelectedItem == null)
            {
                MessageBox.Show("Wybierz maszynę.", "Błąd");
                
            }

            // 2. Walidacja firmy
            if (comboBox_lista_firm.SelectedItem == null)
            {
                MessageBox.Show("Wybierz firmę udzielającą gwarancji.", "Błąd");
                
            }

            // 3. Walidacja miesięcy
            if (string.IsNullOrWhiteSpace(textBox_miesiace_gwarancji.Text))
            {
                MessageBox.Show("Podaj ilość miesięcy gwarancji.", "Błąd");
                
            }

            if (!int.TryParse(textBox_miesiace_gwarancji.Text, out int miesiace) || miesiace < 0)
            {
                MessageBox.Show("Ilość miesięcy musi być liczbą większą lub równą 0.", "Błąd");
                
            }

            // 4. Pobranie ID
            var maszyna = (Maszyna)comboBox_lista_gwarnacja_maszyny.SelectedItem;
            var firma = (Firma)comboBox_lista_firm.SelectedItem;

            // 5. Sprawdzenie czy gwarancja już istnieje
            bool istnieje = context.Gwarancja
                .Any(g => g.IdMaszyna == maszyna.IdMaszyna
                       && g.IdFirma == firma.IdFirma);

            if (istnieje)
            {
                MessageBox.Show("Ta maszyna ma już gwarancję od tej firmy.", "Błąd");
               
            }

            // 6. Tworzenie obiektu
            var nowaGwarancja = new Gwarancja
            {
                IdMaszyna = maszyna.IdMaszyna,
                IdFirma = firma.IdFirma,
                CzasGwarancji = miesiace,
                Warunki = string.IsNullOrWhiteSpace(textBox_warunki_gwarancji.Text)
                    ? null
                    : textBox_warunki_gwarancji.Text
            };

            // 7. Zapis do bazy
            context.Gwarancja.Add(nowaGwarancja);
            context.SaveChanges();

            MessageBox.Show("Dodano gwarancję.", "Informacja");
        }

        private void dataGridView_gwarancja_info_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_gwarancja_info.CurrentRow != null)
            {
                var idMaszyny = dataGridView_gwarancja_info.CurrentRow.Cells["IdMaszyna"].Value;
                comboBox_lista_gwarnacja_maszyny.SelectedValue = idMaszyny;
                var idFirmy = dataGridView_gwarancja_info.CurrentRow.Cells["IdFirma"].Value;
                comboBox_lista_firm.SelectedValue = idFirmy;
                var czas = dataGridView_gwarancja_info.CurrentRow.Cells["CzasGwarancji"].Value;
                textBox_miesiace_gwarancji.Text = czas?.ToString();
                var warunki = dataGridView_gwarancja_info.CurrentRow.Cells["Warunki"].Value;
                textBox_warunki_gwarancji.Text = warunki?.ToString();
                var data = dataGridView_gwarancja_info.CurrentRow.Cells["Data"].Value;
                textBox_uruchomienie.Text = data?.ToString();
            }
        }

        private void dataGridView_gwarancja_info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

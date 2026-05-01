using PodkladexApp.Models;
using ScottPlot.Palettes;
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
    public partial class Form_Normy_eksploatacyjne : Form
    {
        PodkladexContext context;
        bool flaga_usun = false;
        bool flaga_edytuj = false;
        bool flaga_dodaj = false;
        bool flag_norma = false;
        public Form_Normy_eksploatacyjne(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;

            ZaladujNormy();
            OdswiezNormy();
            ZaladujMaszyny();
            panel1.Visible = false;
            panel2.Visible = false;

            button_dodaj_norme_eksp.FlatStyle = FlatStyle.Standard;
            button_edytuj_norma.FlatStyle = FlatStyle.Standard;
            button_usun_norma.FlatStyle = FlatStyle.Standard;
            button_maszyny_norma.FlatStyle = FlatStyle.Standard;

        }
        private void ZaladujNormy()
        {
            

            // ComboBox
            comboBox_lista_norm.DataSource = context.NormyEksploatacyjne.ToList();
            comboBox_lista_norm.DisplayMember = "NazwaNormy";
            comboBox_lista_norm.ValueMember = "IdNormyEkspl";
            comboBox_lista_norm.SelectedIndex = -1;
        }
        private void OdswiezNormy()
        {
            comboBox_lista_norm.DataSource = null;
            comboBox_lista_norm.DataSource = context.NormyEksploatacyjne.ToList();
            comboBox_lista_norm.DisplayMember = "NazwaNormy";
            comboBox_lista_norm.ValueMember = "IdNormyEkspl";
            comboBox_lista_norm.SelectedIndex = -1;
            textBox_nazwa_normy.Text = "";
            textBox_norma_rbh.Text = "";

        }


        private void button_edytuj_norma_Click(object sender, EventArgs e)
        {
            flaga_usun = false;
            flaga_edytuj = true;
            flaga_dodaj = false;
            flag_norma = false;
            button_dodaj_norme_eksp.FlatStyle = FlatStyle.Standard;
            button_edytuj_norma.FlatStyle = FlatStyle.Flat;
            button_usun_norma.FlatStyle = FlatStyle.Standard;
            button_maszyny_norma.FlatStyle = FlatStyle.Standard;

        }

        private void comboBox_lista_norm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_lista_norm.SelectedItem is NormyEksploatacyjne norm)
            {
                textBox_nazwa_normy.Text = norm.NazwaNormy;
                textBox_norma_rbh.Text = norm.PrzebiegNorma.ToString();
            }
        }

        private void button_dodaj_norme_eksp_Click(object sender, EventArgs e)
        {
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = true;
            flag_norma = false;
            button_dodaj_norme_eksp.FlatStyle = FlatStyle.Flat;
            button_edytuj_norma.FlatStyle = FlatStyle.Standard;
            button_usun_norma.FlatStyle = FlatStyle.Standard;
            button_maszyny_norma.FlatStyle = FlatStyle.Standard;

        }

        private void button_usun_norma_Click(object sender, EventArgs e)
        {
            flaga_usun = true;
            flaga_edytuj = false;
            flaga_dodaj = false;
            flag_norma = false;
            button_dodaj_norme_eksp.FlatStyle = FlatStyle.Standard;
            button_edytuj_norma.FlatStyle = FlatStyle.Standard;
            button_usun_norma.FlatStyle = FlatStyle.Flat;
            button_maszyny_norma.FlatStyle = FlatStyle.Standard;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flaga_usun == true)
            {
                Usun();

            }
            if (flaga_dodaj == true)
            {
                Dodaj();


            }
            if (flaga_edytuj == true)
            {
                Edytuj();
            }
            if (flag_norma == true)
            {
                DodajNormeMaszyna();
            }
            ZaladujNormyMaszyna();
            OdswiezNormy();
        }

        private void button_maszyny_norma_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            flag_norma = true;
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = false;
            button_maszyny_norma.FlatStyle = FlatStyle.Flat;
            button_dodaj_norme_eksp.FlatStyle = FlatStyle.Standard;
            button_edytuj_norma.FlatStyle = FlatStyle.Standard;
            button_usun_norma.FlatStyle = FlatStyle.Standard;
            ZaladujNormyMaszyna();
        }
        private void Dodaj()
        {
            string nazwa = textBox_nazwa_normy.Text.Trim();

            if (string.IsNullOrWhiteSpace(nazwa))
            {
                MessageBox.Show("Podaj nazwę normy.");
                return;
            }

            if (!decimal.TryParse(textBox_norma_rbh.Text, out decimal rbh) || rbh < 0)
            {
                MessageBox.Show("Podaj poprawną wartość normy (>= 0).");
                return;
            }

            // sprawdzenie czy istnieje
            bool istnieje = context.NormyEksploatacyjne
                .Any(n => n.NazwaNormy == nazwa);

            if (istnieje)
            {
                MessageBox.Show("Norma o tej nazwie już istnieje.");
                return;
            }

            var nowa = new NormyEksploatacyjne
            {
                NazwaNormy = nazwa,
                PrzebiegNorma = rbh
            };

            context.NormyEksploatacyjne.Add(nowa);
            context.SaveChanges();

            MessageBox.Show("Dodano normę.");
        }
        private void Usun()
        {
            if (comboBox_lista_norm.SelectedItem == null)
            {
                MessageBox.Show("Wybierz normę.");
                return;
            }

            var selected = (NormyEksploatacyjne)comboBox_lista_norm.SelectedItem;

            var norm = context.NormyEksploatacyjne
                .FirstOrDefault(n => n.IdNormyEkspl == selected.IdNormyEkspl);

            if (norm == null)
            {
                MessageBox.Show("Nie znaleziono normy.");
                return;
            }

            var result = MessageBox.Show(
                "Czy na pewno chcesz usunąć normę?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            context.NormyEksploatacyjne.Remove(norm);
            context.SaveChanges();

            MessageBox.Show("Usunięto normę.");
        }
        private void Edytuj()
        {
            if (comboBox_lista_norm.SelectedItem == null)
            {
                MessageBox.Show("Wybierz normę.");
                return;
            }

            var selected = (NormyEksploatacyjne)comboBox_lista_norm.SelectedItem;

            string nazwa = textBox_nazwa_normy.Text.Trim();

            if (string.IsNullOrWhiteSpace(nazwa))
            {
                MessageBox.Show("Nazwa nie może być pusta.");
                return;
            }

            if (!decimal.TryParse(textBox_norma_rbh.Text, out decimal rbh) || rbh < 0)
            {
                MessageBox.Show("Podaj poprawną wartość normy.");
                return;
            }

            // sprawdzenie czy nazwa zajęta (ale nie przez siebie)
            bool istnieje = context.NormyEksploatacyjne
                .Any(n => n.NazwaNormy == nazwa && n.IdNormyEkspl != selected.IdNormyEkspl);

            if (istnieje)
            {
                MessageBox.Show("Taka nazwa już istnieje.");
                return;
            }

            var norm = context.NormyEksploatacyjne
                .FirstOrDefault(n => n.IdNormyEkspl == selected.IdNormyEkspl);

            if (norm == null)
            {
                MessageBox.Show("Nie znaleziono normy.");
                return;
            }

            norm.NazwaNormy = nazwa;
            norm.PrzebiegNorma = rbh;

            context.SaveChanges();

            MessageBox.Show("Zaktualizowano normę.");
        }
        private void ZaladujNormyMaszyna()
        {
            var lista = context.NormyMaszyna
                .Select(n => new
                {
                    n.IdNormyMaszyna,
                    IdMaszyna = n.IdMaszyna,
                    Maszyna = n.IdMaszynaNavigation.Nazwa,
                    Norma = n.IdNormyEksplNavigation.NazwaNormy,
                    n.IdNormyEkspl,
                    n.Wartosc,
                    PrzebiegNorma = n.IdNormyEksplNavigation.PrzebiegNorma
                })
                .ToList();

            dataGridView1.DataSource = lista;
            dataGridView1.Columns["IdNormyMaszyna"].Visible = false;
            dataGridView1.Columns["IdNormyEkspl"].Visible = false;
            dataGridView1.Columns["IdMaszyna"].Visible = false;
            dataGridView1.Columns["Wartosc"].HeaderText = "Wartość poza produkcją";
            dataGridView1.Columns["PrzebiegNorma"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ZaladujMaszyny()
        {
            var maszynyWBazie = context.Maszyna.ToList();

            if (checkBox1.Checked)
            {
                // ID maszyn już użytych w gridzie
                var uzyteMaszynyIds = dataGridView1.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["IdMaszyna"].Value != null)
                    .Select(r => Convert.ToInt32(r.Cells["IdMaszyna"].Value))
                    .Distinct()
                    .ToList();

                // filtr: tylko nieużywane
                maszynyWBazie = maszynyWBazie
                    .Where(m => !uzyteMaszynyIds.Contains(m.IdMaszyna))
                    .ToList();
            }

            comboBox1.DataSource = maszynyWBazie;
            comboBox1.DisplayMember = "Nazwa";
            comboBox1.ValueMember = "IdMaszyna";
            comboBox1.SelectedIndex = -1;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            ZaladujMaszyny();
        }
        private void DodajNormeMaszyna()
        {
            // 1. Walidacja maszyny
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Wybierz maszynę.");
                return;
            }

            // 2. Walidacja normy
            if (comboBox_lista_norm.SelectedItem == null)
            {
                MessageBox.Show("Wybierz normę.");
                return;
            }

            var maszyna = (Maszyna)comboBox1.SelectedItem;
            var norma = (NormyEksploatacyjne)comboBox_lista_norm.SelectedItem;

            // 3. Sprawdzenie czy już istnieje taki wpis
            bool istnieje = context.NormyMaszyna.Any(n =>
                n.IdMaszyna == maszyna.IdMaszyna &&
                n.IdNormyEkspl == norma.IdNormyEkspl);

            if (istnieje)
            {
                MessageBox.Show("Ta norma jest już przypisana do tej maszyny.");
                return;
            }

            // 4. Tworzenie rekordu
            var nowy = new NormyMaszyna
            {
                IdMaszyna = maszyna.IdMaszyna,
                IdNormyEkspl = norma.IdNormyEkspl,
                Wartosc = 0m
            };

            // 5. Zapis
            context.NormyMaszyna.Add(nowy);
            context.SaveChanges();

            MessageBox.Show("Dodano normę do maszyny.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WczytajDoKontrolekZGrid();
        }
        private void WczytajDoKontrolekZGrid()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz rekord z tabeli.");
                return;
            }

            int idMaszyna = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdMaszyna"].Value);
            int idNorma = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdNormyEkspl"].Value);

            // 🔥 TU JEST MIEJSCE NA FIX
            if (comboBox1.DataSource != null)
                comboBox1.SelectedValue = idMaszyna;

            if (comboBox_lista_norm.DataSource != null)
                comboBox_lista_norm.SelectedValue = idNorma;

            textBox1.Text = dataGridView1.CurrentRow.Cells["Wartosc"].Value?.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZmienWartoscNormyMaszyna();
            ZaladujNormyMaszyna();
        }
        private void ZmienWartoscNormyMaszyna()
        {
            // 1. Walidacja
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Wybierz maszynę.");
                return;
            }

            if (comboBox_lista_norm.SelectedItem == null)
            {
                MessageBox.Show("Wybierz normę.");
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal wartosc) || wartosc < 0)
            {
                MessageBox.Show("Podaj poprawną wartość (>= 0).");
                return;
            }

            var maszyna = (Maszyna)comboBox1.SelectedItem;
            var norma = (NormyEksploatacyjne)comboBox_lista_norm.SelectedItem;

            // 2. Szukanie rekordu
            var rekord = context.NormyMaszyna.FirstOrDefault(n =>
                n.IdMaszyna == maszyna.IdMaszyna &&
                n.IdNormyEkspl == norma.IdNormyEkspl);

            if (rekord == null)
            {
                MessageBox.Show("Nie znaleziono rekordu.");
                return;
            }

            // 3. Aktualizacja
            rekord.Wartosc = wartosc;

            context.SaveChanges();

            MessageBox.Show("Zaktualizowano wartość.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UsunPowiazanieNormyMaszyna();
            ZaladujNormyMaszyna();
        }

        private void UsunPowiazanieNormyMaszyna()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Wybierz maszynę.");
                return;
            }

            if (comboBox_lista_norm.SelectedItem == null)
            {
                MessageBox.Show("Wybierz normę.");
                return;
            }

            var maszyna = (Maszyna)comboBox1.SelectedItem;
            var norma = (NormyEksploatacyjne)comboBox_lista_norm.SelectedItem;

            var rekord = context.NormyMaszyna.FirstOrDefault(n =>
                n.IdMaszyna == maszyna.IdMaszyna &&
                n.IdNormyEkspl == norma.IdNormyEkspl);

            if (rekord == null)
            {
                MessageBox.Show("Nie znaleziono powiązania.");
                return;
            }

            var result = MessageBox.Show(
                "Czy na pewno chcesz usunąć powiązanie?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            context.NormyMaszyna.Remove(rekord);
            context.SaveChanges();

            MessageBox.Show("Usunięto powiązanie.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UsunPowiazanieNormyMaszyna();
        }
    }
}

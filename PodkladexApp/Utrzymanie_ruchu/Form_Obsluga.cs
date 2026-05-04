using Microsoft.EntityFrameworkCore;
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

namespace PodkladexApp
{

    public partial class Form_Obsluga : Form
    {
        PodkladexContext context;
        bool flaga_usun = false;
        bool flaga_edytuj = false;
        bool flaga_dodaj = false;
        bool flaga_dodaj_czesc = false;
        public Form_Obsluga(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            panel1.Visible = false;
            panel2.Visible = false;
            panel_posredniczaca.Visible = false;
            button1.FlatStyle = FlatStyle.Standard;
            button2.FlatStyle = FlatStyle.Standard;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            button_zglos_awarie.FlatStyle = FlatStyle.Standard;
            ZaladujOsobyDoComboBox();
            ZaladujMaszynyDoComboBox();
            ZaladujRodzajObslugiDoComboBox();
            ZaladujObslugiDoComboBox();

        }

        private void button_zglos_awarie_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel_posredniczaca.Visible = false;
            button1.FlatStyle = FlatStyle.Standard;
            button2.FlatStyle = FlatStyle.Standard;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            button_zglos_awarie.FlatStyle = FlatStyle.Flat;
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = true;
            flaga_dodaj_czesc = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel_posredniczaca.Visible = false;
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Standard;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            button_zglos_awarie.FlatStyle = FlatStyle.Standard;
            flaga_usun = false;
            flaga_edytuj = true;
            flaga_dodaj = false;
            flaga_dodaj_czesc = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel_posredniczaca.Visible = false;
            button1.FlatStyle = FlatStyle.Standard;
            button2.FlatStyle = FlatStyle.Flat;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            button_zglos_awarie.FlatStyle = FlatStyle.Standard;
            flaga_usun = true;
            flaga_edytuj = false;
            flaga_dodaj = false;
            flaga_dodaj_czesc = false;
        }

        private void button_dodaj_czesc_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel_posredniczaca.Visible = true;
            button1.FlatStyle = FlatStyle.Standard;
            button2.FlatStyle = FlatStyle.Standard;
            button_dodaj_czesc.FlatStyle = FlatStyle.Flat;
            button_zglos_awarie.FlatStyle = FlatStyle.Standard;
            ZaladujCzesciDoComboBox();
            ZaladujCzesciPrzegladyDlaObslugi();
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = false;
            flaga_dodaj_czesc = true;
        }

        private void button_potwierdz_Click(object sender, EventArgs e)
        {
            if (flaga_usun == true)
            {
                UsunObsluge();
                WyczyscKontrolkiObsluga();
            }
            if (flaga_dodaj == true)
            {
                DodajObsluge();
                WyczyscKontrolkiObsluga();
            }
            if (flaga_edytuj == true)
            {
                EdytujObsluge();
                WyczyscKontrolkiObsluga();
            }

        }
        private void ZaladujOsobyDoComboBox()
        {
            var lista = context.Osoba
                .Select(o => new
                {
                    o.IdOsoba,
                    PelnaNazwa = o.Imie + " " + o.Nazwisko
                })
                .ToList();

            cbox_osoby.DataSource = lista;
            cbox_osoby.DisplayMember = "PelnaNazwa";  // co widać
            cbox_osoby.ValueMember = "IdOsoba";       // ID w tle

            cbox_osoby.SelectedIndex = -1; // brak zaznaczenia na start
        }
        private void ZaladujMaszynyDoComboBox()
        {
            var lista = context.Maszyna
                .Select(m => new
                {
                    m.IdMaszyna,
                    m.Nazwa
                })
                .ToList();

            cbox_maszyna.DataSource = lista;
            cbox_maszyna.DisplayMember = "Nazwa";      // co widzisz
            cbox_maszyna.ValueMember = "IdMaszyna";    // ID w tle

            cbox_maszyna.SelectedIndex = -1; // brak zaznaczenia na start
        }
        private void ZaladujRodzajObslugiDoComboBox()
        {
            var lista = context.RodzajObslugi
                .Select(r => new
                {
                    r.IdRodzajObslugi,
                    r.Nazwa
                })
                .ToList();

            comboBox_rodzaj_obslugi.DataSource = lista;
            comboBox_rodzaj_obslugi.DisplayMember = "Nazwa";       // widoczna nazwa
            comboBox_rodzaj_obslugi.ValueMember = "IdRodzajObslugi"; // ID w tle

            comboBox_rodzaj_obslugi.SelectedIndex = -1; // brak wyboru na start
        }

        private void comboBox_lista_awarii_SelectedIndexChanged(object sender, EventArgs e)
        {
            WczytajObslugeDoKontrolek();
            if (flaga_dodaj_czesc == true)
            {
                ZaladujCzesciPrzegladyDlaObslugi();
            }

        }
        private void ZaladujObslugiDoComboBox()
        {
            var lista = context.Obsluga
                .Select(o => new
                {
                    o.IdObsluga,

                    Opis =
                        o.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                        o.IdPracownikNavigation.IdOsobaNavigation.Nazwisko
                        + " | " +
                        o.IdMaszynaNavigation.Nazwa
                        + " | " +
                        o.IdRodzajObslugiNavigation.Nazwa
                        + " | " +
                        o.DataPoczatek.ToString("dd.MM.yyyy")
                        + " - " +
                        (o.DataKoniec.HasValue
                            ? o.DataKoniec.Value.ToString("dd.MM.yyyy")
                            : "trwa")
                })
                .ToList();

            comboBox_lista_awarii.DataSource = lista;
            comboBox_lista_awarii.DisplayMember = "Opis";     // co widzisz
            comboBox_lista_awarii.ValueMember = "IdObsluga";  // ID w tle

            comboBox_lista_awarii.SelectedIndex = -1;
        }
        private void WczytajObslugeDoKontrolek()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
                return;

            var item = comboBox_lista_awarii.SelectedItem;

            if (item == null) return;

            int idObsluga = (int)item.GetType()
                .GetProperty("IdObsluga")
                .GetValue(item);
            var obsluga = context.Obsluga
    .Include(o => o.IdPracownikNavigation)
        .ThenInclude(p => p.IdOsobaNavigation)
    .FirstOrDefault(o => o.IdObsluga == idObsluga);

            if (obsluga == null)
            {
                MessageBox.Show("Nie znaleziono obsługi.");
                return;
            }

            // =========================
            // OSOBA
            // =========================
            cbox_osoby.SelectedValue = obsluga.IdPracownikNavigation.IdOsoba;

            // =========================
            // MASZYNA
            // =========================
            cbox_maszyna.SelectedValue = obsluga.IdMaszyna;

            // =========================
            // RODZAJ OBSŁUGI
            // =========================
            comboBox_rodzaj_obslugi.SelectedValue = obsluga.IdRodzajObslugi;

            // =========================
            // DATY
            // =========================
            dtp_data_zgloszenia.Value = obsluga.DataPoczatek.ToDateTime(TimeOnly.MinValue);

            if (obsluga.DataKoniec.HasValue)
            {
                dtp_data_usuniecia.Value = obsluga.DataKoniec.Value.ToDateTime(TimeOnly.MinValue);
                dtp_data_usuniecia.Checked = true;
            }
            else
            {
                dtp_data_usuniecia.Checked = false;
            }

            // =========================
            // UWAGI
            // =========================
            textBox1.Text = obsluga.Uwagi;

            // =========================
            // RBH / PRZEBIEG
            // =========================
            textBox_RBH.Text = obsluga.Przebieg.ToString();
        }
        private void WyczyscKontrolkiObsluga()
        {
            // ComboBoxy
            cbox_osoby.SelectedIndex = -1;
            cbox_maszyna.SelectedIndex = -1;
            comboBox_rodzaj_obslugi.SelectedIndex = -1;
            comboBox_lista_awarii.SelectedIndex = -1;

            // TextBoxy
            textBox1.Clear();          // Uwagi
            textBox_RBH.Clear();       // RBH

            // DateTimePicker - reset
            dtp_data_zgloszenia.Value = DateTime.Now;

            dtp_data_usuniecia.Value = DateTime.Now;
            dtp_data_usuniecia.Checked = false; // jeśli masz CheckBox w DateTimePicker

            // Numeric / inne (jeśli używasz)
            // num_ud_liczba_czesci.Value = num_ud_liczba_czesci.Minimum;
        }
        private void ZaladujCzesciDoComboBox()
        {
            var lista = context.CzescZamienna
                .OrderBy(c => c.Nazwa)
                .Select(c => new
                {
                    c.IdCzesci,
                    c.Nazwa
                })
                .ToList();

            cbox_czesc.DataSource = lista;
            cbox_czesc.DisplayMember = "Nazwa";       // co widzisz
            cbox_czesc.ValueMember = "IdCzesci";      // ID w tle

            cbox_czesc.SelectedIndex = -1; // brak wyboru na start
        }
        private void ZaladujCzesciPrzegladyDlaObslugi()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
                return;

            int idObsluga = (int)comboBox_lista_awarii.SelectedValue;

            var lista = context.CzesciPrzeglady
                .Where(x => x.IdObsluga == idObsluga)   // 🔥 KLUCZOWY FILTR
                .Select(x => new
                {
                    x.IdCzesciPrzeglady,
                    x.IdCzesci,
                    Czesc = x.IdCzesciNavigation.Nazwa,
                    x.Liczba,
                    x.Opis
                })
                .ToList();

            dataGridView1.DataSource = lista;

            // ukrycie ID
            if (dataGridView1.Columns["IdCzesciPrzeglady"] != null)
                dataGridView1.Columns["IdCzesciPrzeglady"].Visible = false;

            if (dataGridView1.Columns["IdCzesci"] != null)
                dataGridView1.Columns["IdCzesci"].Visible = false;
            dataGridView1.Columns["Czesc"].HeaderText = "Część";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Font = new Font("Segoe UI", 14);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void DodajObsluge()
        {
            // =========================
            // WALIDACJA OSOBY
            // =========================
            if (cbox_osoby.SelectedValue == null)
            {
                MessageBox.Show("Wybierz osobę.");
                return;
            }

            // =========================
            // WALIDACJA MASZYNY
            // =========================
            if (cbox_maszyna.SelectedValue == null)
            {
                MessageBox.Show("Wybierz maszynę.");
                return;
            }

            // =========================
            // WALIDACJA RODZAJU OBSŁUGI
            // =========================
            if (comboBox_rodzaj_obslugi.SelectedValue == null)
            {
                MessageBox.Show("Wybierz rodzaj obsługi.");
                return;
            }

            // =========================
            // ID
            // =========================
            int idOsoba = (int)cbox_osoby.SelectedValue;
            int idMaszyna = (int)cbox_maszyna.SelectedValue;
            int idRodzaj = (int)comboBox_rodzaj_obslugi.SelectedValue;

            // =========================
            // PRACOWNIK (PO OSOBIE)
            // =========================
            var pracownik = context.Pracownik
                .FirstOrDefault(p => p.IdOsoba == idOsoba);

            if (pracownik == null)
            {
                MessageBox.Show("Brak pracownika dla wybranej osoby.");
                return;
            }

            // =========================
            // DATY
            // =========================
            DateOnly dataStart = DateOnly.FromDateTime(dtp_data_zgloszenia.Value);

            DateOnly? dataKoniec = dtp_data_usuniecia.Checked
                ? DateOnly.FromDateTime(dtp_data_usuniecia.Value)
                : null;

            if (dataKoniec.HasValue && dataKoniec < dataStart)
            {
                MessageBox.Show("Data zakończenia nie może być wcześniejsza.");
                return;
            }

            // =========================
            // RBH
            // =========================
            if (!decimal.TryParse(textBox_RBH.Text, out decimal rbh) || rbh < 0)
            {
                MessageBox.Show("Podaj poprawną wartość RBH.");
                return;
            }

            // =========================
            // UWAGI
            // =========================
            string uwagi = textBox1.Text;

            // =========================
            // DODANIE
            // =========================
            var nowa = new Obsluga
            {
                IdMaszyna = idMaszyna,
                IdPracownik = pracownik.IdPracownik,
                IdRodzajObslugi = idRodzaj,
                DataPoczatek = dataStart,
                DataKoniec = dataKoniec,
                Uwagi = uwagi,
                Przebieg = rbh
            };

            context.Obsluga.Add(nowa);
            context.SaveChanges();

            MessageBox.Show("Dodano nową obsługę.");

            ZaladujObslugiDoComboBox();
        }
        private void EdytujObsluge()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
            {
                MessageBox.Show("Wybierz obsługę.");
                return;
            }

            int idObsluga = (int)comboBox_lista_awarii.SelectedValue;

            var obsluga = context.Obsluga
                .FirstOrDefault(o => o.IdObsluga == idObsluga);

            if (obsluga == null)
            {
                MessageBox.Show("Nie znaleziono obsługi.");
                return;
            }

            // =========================
            // WALIDACJA
            // =========================
            if (cbox_osoby.SelectedValue == null ||
                cbox_maszyna.SelectedValue == null ||
                comboBox_rodzaj_obslugi.SelectedValue == null)
            {
                MessageBox.Show("Uzupełnij dane.");
                return;
            }

            int idOsoba = (int)cbox_osoby.SelectedValue;
            int idMaszyna = (int)cbox_maszyna.SelectedValue;
            int idRodzaj = (int)comboBox_rodzaj_obslugi.SelectedValue;

            var pracownik = context.Pracownik
                .FirstOrDefault(p => p.IdOsoba == idOsoba);

            if (pracownik == null)
            {
                MessageBox.Show("Brak pracownika.");
                return;
            }

            // =========================
            // DATY
            // =========================
            DateOnly dataStart = DateOnly.FromDateTime(dtp_data_zgloszenia.Value);

            DateOnly? dataKoniec = dtp_data_usuniecia.Checked
                ? DateOnly.FromDateTime(dtp_data_usuniecia.Value)
                : null;

            // =========================
            // RBH
            // =========================
            if (!decimal.TryParse(textBox_RBH.Text, out decimal rbh))
            {
                MessageBox.Show("Błędne RBH.");
                return;
            }

            // =========================
            // UPDATE
            // =========================
            obsluga.IdMaszyna = idMaszyna;
            obsluga.IdPracownik = pracownik.IdPracownik;
            obsluga.IdRodzajObslugi = idRodzaj;
            obsluga.DataPoczatek = dataStart;
            obsluga.DataKoniec = dataKoniec;
            obsluga.Uwagi = textBox1.Text;
            obsluga.Przebieg = rbh;

            context.SaveChanges();

            MessageBox.Show("Zaktualizowano obsługę.");

            ZaladujObslugiDoComboBox();
        }
        private void UsunObsluge()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
            {
                MessageBox.Show("Wybierz obsługę.");
                return;
            }

            int idObsluga = (int)comboBox_lista_awarii.SelectedValue;

            var obsluga = context.Obsluga
                .FirstOrDefault(o => o.IdObsluga == idObsluga);

            if (obsluga == null)
            {
                MessageBox.Show("Nie znaleziono obsługi.");
                return;
            }

            var result = MessageBox.Show(
                "Czy na pewno chcesz usunąć tę obsługę?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                context.Obsluga.Remove(obsluga);
                context.SaveChanges();

                MessageBox.Show("Usunięto obsługę.");

                ZaladujObslugiDoComboBox();
                WyczyscKontrolkiObsluga();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WczytajCzescZGridu();
        }
        private void WczytajCzescZGridu()
        {
            if (dataGridView1.CurrentRow == null)
                return;

            // =========================
            // ID części (jeśli masz w gridzie)
            // =========================
            object idCzesciObj = dataGridView1.CurrentRow.Cells["IdCzesci"]?.Value;

            if (idCzesciObj != null)
            {
                int idCzesci = Convert.ToInt32(idCzesciObj);
                cbox_czesc.SelectedValue = idCzesci;
            }

            // =========================
            // LICZBA
            // =========================
            object liczbaObj = dataGridView1.CurrentRow.Cells["Liczba"]?.Value;

            if (liczbaObj != null)
            {
                num_ud_liczba_czesci.Value = Convert.ToDecimal(liczbaObj);
            }

            // =========================
            // OPIS
            // =========================
            object opisObj = dataGridView1.CurrentRow.Cells["Opis"]?.Value;

            if (opisObj != null)
            {
                tbox_opis_awaria_czesc.Text = opisObj.ToString();
            }
        }

        private void button_dodaj_czesc_awaria_posredniczaca_Click(object sender, EventArgs e)
        {
            if (flaga_dodaj_czesc == true)
            {
                DodajCzescDoObslugi();
                WyczyscKontrolkiCzesci();
            }
        }

        private void button_edycja_Click(object sender, EventArgs e)
        {
            if (flaga_dodaj_czesc == true)
            {
                EdytujCzescObslugi();
                WyczyscKontrolkiCzesci();
            }
        }

        private void button_usun_Click(object sender, EventArgs e)
        {
            if (flaga_dodaj_czesc == true)
            {
                UsunCzescZObslugi();
                WyczyscKontrolkiCzesci();
            }
        }
        private void DodajCzescDoObslugi()
        {
            if (comboBox_lista_awarii.SelectedValue == null ||
                cbox_czesc.SelectedValue == null)
            {
                MessageBox.Show("Wybierz obsługę i część.");
                return;
            }

            int idObsluga = (int)comboBox_lista_awarii.SelectedValue;
            int idCzesci = (int)cbox_czesc.SelectedValue;

            var nowa = new CzesciPrzeglady
            {
                IdObsluga = idObsluga,
                IdCzesci = idCzesci,
                Liczba = (int)num_ud_liczba_czesci.Value,
                Opis = tbox_opis_awaria_czesc.Text
            };

            context.CzesciPrzeglady.Add(nowa);
            context.SaveChanges();

            MessageBox.Show("Dodano część do obsługi.");

            ZaladujCzesciPrzegladyDlaObslugi();
        }
        private void EdytujCzescObslugi()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz rekord z tabeli.");
                return;
            }

            int id = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["IdCzesciPrzeglady"].Value
            );

            var rekord = context.CzesciPrzeglady
                .FirstOrDefault(x => x.IdCzesciPrzeglady == id);

            if (rekord == null)
            {
                MessageBox.Show("Nie znaleziono rekordu.");
                return;
            }

            if (cbox_czesc.SelectedValue == null)
            {
                MessageBox.Show("Wybierz część.");
                return;
            }

            rekord.IdCzesci = (int)cbox_czesc.SelectedValue;
            rekord.Liczba = (int)num_ud_liczba_czesci.Value;
            rekord.Opis = tbox_opis_awaria_czesc.Text;

            context.SaveChanges();

            MessageBox.Show("Zaktualizowano część.");

            ZaladujCzesciPrzegladyDlaObslugi();
        }
        private void UsunCzescZObslugi()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz rekord.");
                return;
            }

            int id = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["IdCzesciPrzeglady"].Value
            );

            var rekord = context.CzesciPrzeglady
                .FirstOrDefault(x => x.IdCzesciPrzeglady == id);

            if (rekord == null)
                return;

            var result = MessageBox.Show(
                "Usunąć część z obsługi?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                context.CzesciPrzeglady.Remove(rekord);
                context.SaveChanges();

                MessageBox.Show("Usunięto.");

                ZaladujCzesciPrzegladyDlaObslugi();
            }
        }
        private void WyczyscKontrolkiCzesci()
        {
            // ComboBox część
            cbox_czesc.SelectedIndex = -1;

            // NumericUpDown ilość
            num_ud_liczba_czesci.Value = num_ud_liczba_czesci.Minimum;

            // TextBox opis
            tbox_opis_awaria_czesc.Clear();
        }
    }
}

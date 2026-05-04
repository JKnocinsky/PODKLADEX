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
    public partial class Form_Awaria : Form
    {
        PodkladexContext context;
        bool flaga_usun = false;
        bool flaga_edytuj = false;
        bool flaga_dodaj = false;
        bool flaga_dodaj_czesc = false;
        public Form_Awaria(PodkladexContext context)
        {
            InitializeComponent();
            panel_posredniczaca.Visible = false;
            panel_awaria_info.Visible = false;
            panel_wybor_awarii.Visible = false;
            button_zglos_awarie.FlatStyle = FlatStyle.Standard;
            button_edytuj_awarie.FlatStyle = FlatStyle.Standard;
            button_usun_awarie.FlatStyle = FlatStyle.Standard;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            this.context = context;
            ZaladujDane();
            WyczyśćKontrolkiAwaria();
            ZaladujCzesciDoComboBox();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void button_dodaj_czesc_Click(object sender, EventArgs e)
        {
            panel_posredniczaca.Visible = true;
            panel_awaria_info.Visible = true;
            panel_wybor_awarii.Visible = true;
            button_dodaj_czesc.FlatStyle = FlatStyle.Flat;
            button_edytuj_awarie.FlatStyle = FlatStyle.Standard;
            button_usun_awarie.FlatStyle = FlatStyle.Standard;
            
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = false;
            flaga_dodaj_czesc = true;
            ZaladujCzesciAwariiDlaWybranej();

        }

        private void button_zglos_awarie_Click(object sender, EventArgs e)
        {
            panel_posredniczaca.Visible = false;
            panel_awaria_info.Visible = true;
            panel_wybor_awarii.Visible = false;
            button_zglos_awarie.FlatStyle = FlatStyle.Flat;
            button_edytuj_awarie.FlatStyle = FlatStyle.Standard;
            button_usun_awarie.FlatStyle = FlatStyle.Standard;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            flaga_usun = false;
            flaga_edytuj = false;
            flaga_dodaj = true;
            flaga_dodaj_czesc = false;

        }

        private void button_edytuj_awarie_Click(object sender, EventArgs e)
        {
            panel_posredniczaca.Visible = false;
            panel_awaria_info.Visible = true;
            panel_wybor_awarii.Visible = true;
            button_zglos_awarie.FlatStyle = FlatStyle.Standard;
            button_edytuj_awarie.FlatStyle = FlatStyle.Flat;
            button_usun_awarie.FlatStyle = FlatStyle.Standard;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            flaga_usun = false;
            flaga_edytuj = true;
            flaga_dodaj = false;
            flaga_dodaj_czesc = false;

        }

        private void button_usun_awarie_Click(object sender, EventArgs e)
        {
            panel_posredniczaca.Visible = false;
            panel_awaria_info.Visible = true;
            panel_wybor_awarii.Visible = true;
            button_zglos_awarie.FlatStyle = FlatStyle.Standard;
            button_edytuj_awarie.FlatStyle = FlatStyle.Standard;
            button_usun_awarie.FlatStyle = FlatStyle.Flat;
            button_dodaj_czesc.FlatStyle = FlatStyle.Standard;
            flaga_usun = true;
            flaga_edytuj = false;
            flaga_dodaj = false;
            flaga_dodaj_czesc = false;
        }
        private void ZaladujDane()
        {
            // =========================
            // 🔹 OSOBY
            // =========================
            var osoby = context.Osoba
                .Select(o => new
                {
                    o.IdOsoba,
                    PelnaNazwa = o.Imie + " " + o.Nazwisko
                })
                .ToList();

            cbox_osoby.DataSource = osoby;
            cbox_osoby.DisplayMember = "PelnaNazwa";
            cbox_osoby.ValueMember = "IdOsoba";
            cbox_osoby.SelectedIndex = -1;

            // =========================
            // 🔹 MASZYNY
            // =========================
            var maszyny = context.Maszyna
                .Select(m => new
                {
                    m.IdMaszyna,
                    m.Nazwa
                })
                .ToList();

            cbox_maszyna.DataSource = maszyny;
            cbox_maszyna.DisplayMember = "Nazwa";
            cbox_maszyna.ValueMember = "IdMaszyna";
            cbox_maszyna.SelectedIndex = -1;

            // =========================
            // 🔹 AWARIE (rozbudowany opis)
            // =========================
            var awarie = context.Awaria
                .Select(a => new
                {
                    a.IdAwaria,
                    Opis = a.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                           a.IdPracownikNavigation.IdOsobaNavigation.Nazwisko
                           + " | " +
                           a.IdMaszynaNavigation.Nazwa
                           + " | " +
                           a.DataZgloszenia.ToString("dd.MM.yyyy")
                           + " - " +
                           (a.DataUsuniecia.HasValue
                                ? a.DataUsuniecia.Value.ToString("dd.MM.yyyy")
                                : "brak")
                })
                .ToList();

            comboBox_lista_awarii.DataSource = awarie;
            comboBox_lista_awarii.DisplayMember = "Opis";
            comboBox_lista_awarii.ValueMember = "IdAwaria";
            comboBox_lista_awarii.SelectedIndex = -1;
        }

        private void comboBox_lista_awarii_SelectedIndexChanged(object sender, EventArgs e)
        {
            WczytajAwariaDoKontrolek();

            if (comboBox_lista_awarii.SelectedIndex < 0)
                return;

            if (flaga_dodaj_czesc == true)
            {
                ZaladujCzesciAwariiDlaWybranej();
            }

        }
        private void WczytajAwariaDoKontrolek()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
            {
                //MessageBox.Show("Wybierz awarię.");
                return;
            }

            var selected = comboBox_lista_awarii.SelectedItem;
            int idAwaria = selected.GetType().GetProperty("IdAwaria").GetValue(selected, null) as int? ?? 0;
            var awaria = context.Awaria
    .Include(a => a.IdPracownikNavigation)
        .ThenInclude(p => p.IdOsobaNavigation)
    .FirstOrDefault(a => a.IdAwaria == idAwaria);

            if (awaria == null)
            {
                MessageBox.Show("Nie znaleziono awarii.");
                return;
            }

            // =========================
            // MASZYNA
            // =========================
            cbox_maszyna.SelectedValue = awaria.IdMaszyna;

            // =========================
            // OSOBA (przez Pracownik → Osoba)
            // =========================
            int idOsoba = awaria.IdPracownikNavigation.IdOsoba;
            cbox_osoby.SelectedValue = idOsoba;

            // =========================
            // DATA ZGŁOSZENIA
            // =========================
            dtp_data_zgloszenia.Value = awaria.DataZgloszenia.ToDateTime(TimeOnly.MinValue);

            // =========================
            // DATA USUNIĘCIA
            // =========================
            if (awaria.DataUsuniecia.HasValue)
            {
                dtp_data_usuniecia.Value = awaria.DataUsuniecia.Value.ToDateTime(TimeOnly.MinValue);
                dtp_data_usuniecia.Checked = true; // jeśli masz checkbox w DateTimePicker
            }
            else
            {
                dtp_data_usuniecia.Checked = false;
            }

            // =========================
            // OPIS
            // =========================
            txtb_opis_awaria.Text = awaria.Opis;
        }

        private void button_potwierdz_Click(object sender, EventArgs e)
        {
            if (flaga_usun == true)
            {
                UsunAwaria();
                WyczyśćKontrolkiAwaria();
            }
            if (flaga_dodaj == true)
            {
                DodajAwaria();
                WyczyśćKontrolkiAwaria();
            }
            if (flaga_edytuj == true)
            {
                EdytujAwaria();
                WyczyśćKontrolkiAwaria();
            }
            if (flaga_dodaj_czesc == true)
            {

            }

        }
        private void DodajAwaria()
        {
            if (cbox_osoby.SelectedValue == null || cbox_maszyna.SelectedValue == null)
            {
                MessageBox.Show("Wybierz osobę i maszynę.");
                return;
            }

            int idOsoba = (int)cbox_osoby.SelectedValue;
            int idMaszyna = (int)cbox_maszyna.SelectedValue;

            var pracownik = context.Pracownik
                .FirstOrDefault(p => p.IdOsoba == idOsoba);

            if (pracownik == null)
            {
                MessageBox.Show("Brak powiązanego pracownika.");
                return;
            }

            DateOnly dataZgl = DateOnly.FromDateTime(dtp_data_zgloszenia.Value);
            DateOnly? dataUs = dtp_data_usuniecia.Checked
                ? DateOnly.FromDateTime(dtp_data_usuniecia.Value)
                : null;

            if (dataUs.HasValue && dataUs < dataZgl)
            {
                MessageBox.Show("Data usunięcia nie może być wcześniejsza niż zgłoszenia.");
                return;
            }

            var nowa = new Awaria
            {
                IdMaszyna = idMaszyna,
                IdPracownik = pracownik.IdPracownik,
                DataZgloszenia = dataZgl,
                DataUsuniecia = dataUs,
                Opis = txtb_opis_awaria.Text
            };

            context.Awaria.Add(nowa);
            context.SaveChanges();

            MessageBox.Show("Dodano awarię.");
            ZaladujDane();
        }
        private void EdytujAwaria()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
            {
                MessageBox.Show("Wybierz awarię.");
                return;
            }

            int idAwaria = (int)comboBox_lista_awarii.SelectedValue;

            var awaria = context.Awaria.FirstOrDefault(a => a.IdAwaria == idAwaria);

            if (awaria == null)
            {
                MessageBox.Show("Nie znaleziono rekordu.");
                return;
            }

            int idOsoba = (int)cbox_osoby.SelectedValue;
            int idMaszyna = (int)cbox_maszyna.SelectedValue;

            var pracownik = context.Pracownik
                .FirstOrDefault(p => p.IdOsoba == idOsoba);

            if (pracownik == null)
            {
                MessageBox.Show("Brak pracownika.");
                return;
            }

            DateOnly dataZgl = DateOnly.FromDateTime(dtp_data_zgloszenia.Value);
            DateOnly? dataUs = dtp_data_usuniecia.Checked
                ? DateOnly.FromDateTime(dtp_data_usuniecia.Value)
                : null;

            if (dataUs.HasValue && dataUs < dataZgl)
            {
                MessageBox.Show("Nieprawidłowe daty.");
                return;
            }

            awaria.IdMaszyna = idMaszyna;
            awaria.IdPracownik = pracownik.IdPracownik;
            awaria.DataZgloszenia = dataZgl;
            awaria.DataUsuniecia = dataUs;
            awaria.Opis = txtb_opis_awaria.Text;

            context.SaveChanges();

            MessageBox.Show("Zaktualizowano awarię.");
            ZaladujDane();
        }
        private void UsunAwaria()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
            {
                MessageBox.Show("Wybierz awarię.");
                return;
            }

            int idAwaria = (int)comboBox_lista_awarii.SelectedValue;

            var awaria = context.Awaria.FirstOrDefault(a => a.IdAwaria == idAwaria);

            if (awaria == null)
            {
                MessageBox.Show("Nie znaleziono.");
                return;
            }

            var result = MessageBox.Show(
                "Czy na pewno chcesz usunąć awarię?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                context.Awaria.Remove(awaria);
                context.SaveChanges();

                MessageBox.Show("Usunięto awarię.");
                ZaladujDane();
            }
        }
        private void WyczyśćKontrolkiAwaria()
        {
            // ComboBoxy
            cbox_osoby.SelectedIndex = -1;
            cbox_maszyna.SelectedIndex = -1;
            comboBox_lista_awarii.SelectedIndex = -1;

            // TextBox
            txtb_opis_awaria.Clear();

            // DateTimePicker - ustaw na dziś
            dtp_data_zgloszenia.Value = DateTime.Now;

            // Data usunięcia (nullable)
            dtp_data_usuniecia.Value = DateTime.Now;
            dtp_data_usuniecia.Checked = false; // ważne jeśli używasz ShowCheckBox = true
        }
        private void ZaladujCzesciAwariiDlaWybranej()
        {
            if (comboBox_lista_awarii.SelectedValue == null)
            {
                dataGridView1.DataSource = null;
                return;
            }

            int idAwaria = (int)comboBox_lista_awarii.SelectedValue;

            var lista = context.CzesciAwaria
                .Where(ca => ca.IdAwaria == idAwaria)
                .Select(ca => new
                {
                    ca.IdCzesciAwaria,
                    Czesc = ca.IdCzesciNavigation.Nazwa,
                    ca.Liczba

                })
                .ToList();

            dataGridView1.DataSource = lista;

            // ukrycie ID
            if (dataGridView1.Columns["IdCzesciAwaria"] != null)
                dataGridView1.Columns["IdCzesciAwaria"].Visible = false;

            // nazwy kolumn
            if (dataGridView1.Columns["Czesc"] != null)
                dataGridView1.Columns["Czesc"].HeaderText = "Część";

            if (dataGridView1.Columns["Liczba"] != null)
                dataGridView1.Columns["Liczba"].HeaderText = "Ilość";

            // wygląd
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Font = new Font("Segoe UI", 14);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void ZaladujCzesciDoComboBox()
        {
            var lista = context.CzescZamienna
                .Select(c => new
                {
                    c.IdCzesci,
                    c.Nazwa
                })
                .ToList();

            cbox_czesc.DataSource = lista;
            cbox_czesc.DisplayMember = "Nazwa";     // co widać
            cbox_czesc.ValueMember = "IdCzesci";    // ID

            cbox_czesc.SelectedIndex = -1; // brak zaznaczenia na start
        }
        private void DodajCzescDoAwarii()
        {
            // =========================
            // AWARIA
            // =========================
            if (comboBox_lista_awarii.SelectedValue == null)
            {
                MessageBox.Show("Wybierz awarię.");
                return;
            }

            // =========================
            // CZĘŚĆ
            // =========================
            if (cbox_czesc.SelectedValue == null)
            {
                MessageBox.Show("Wybierz część.");
                return;
            }

            // =========================
            // ILOŚĆ
            // =========================
            int liczba = (int)num_ud_liczba_czesci.Value;

            if (liczba <= 0)
            {
                MessageBox.Show("Liczba musi być większa od 0.");
                return;
            }

            // =========================
            // ID
            // =========================
            int idAwaria = (int)comboBox_lista_awarii.SelectedValue;
            int idCzesci = (int)cbox_czesc.SelectedValue;

            // =========================
            // SPRAWDZENIE DUPLIKATU
            // =========================
            var istnieje = context.CzesciAwaria
                .FirstOrDefault(x => x.IdAwaria == idAwaria && x.IdCzesci == idCzesci);

            if (istnieje != null)
            {
                MessageBox.Show("Ta część jest już przypisana do tej awarii.");
                return;
            }

            // =========================
            // DODANIE
            // =========================
            var nowa = new CzesciAwaria
            {
                IdAwaria = idAwaria,
                IdCzesci = idCzesci,
                Liczba = liczba
            };

            context.CzesciAwaria.Add(nowa);
            context.SaveChanges();

            MessageBox.Show("Dodano część do awarii.");

            // odśwież grid
            ZaladujCzesciAwariiDlaWybranej();
        }

        private void button_dodaj_czesc_awaria_posredniczaca_Click(object sender, EventArgs e)
        {
            if (flaga_dodaj_czesc == true)
            {
                DodajCzescDoAwarii();
                cbox_czesc.SelectedIndex = -1;
                num_ud_liczba_czesci.Value = 0;
            }

        }
        private void ZaladujCzescZDataGridView()
        {
            if (dataGridView1.CurrentRow == null)
                return;

            // =========================
            // ID CZĘŚCI AWARIA (jeśli potrzebne np. do edycji)
            // =========================
            int idCzesciAwaria = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["IdCzesciAwaria"].Value
            );

            // =========================
            // CZĘŚĆ → COMBOBOX
            // =========================
            string nazwaCzesci = dataGridView1.CurrentRow.Cells["Czesc"].Value?.ToString();

            if (!string.IsNullOrEmpty(nazwaCzesci))
            {
                cbox_czesc.Text = nazwaCzesci;
            }

            // =========================
            // LICZBA
            // =========================
            int liczba = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["Liczba"].Value
            );

            num_ud_liczba_czesci.Value = liczba;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ZaladujCzescZDataGridView();
        }

        private void button_edycja_czesc_Click(object sender, EventArgs e)
        {
            EdytujCzescAwarii();
            cbox_czesc.SelectedIndex = -1;
            num_ud_liczba_czesci.Value = 0;
        }

        private void button_usun_czesc_Click(object sender, EventArgs e)
        {
            UsunCzescAwarii();
            cbox_czesc.SelectedIndex = -1;
            num_ud_liczba_czesci.Value = 0;
        }
        private void EdytujCzescAwarii()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz rekord z tabeli.");
                return;
            }

            int idCzesciAwaria = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["IdCzesciAwaria"].Value
            );

            var rekord = context.CzesciAwaria
                .FirstOrDefault(x => x.IdCzesciAwaria == idCzesciAwaria);

            if (rekord == null)
            {
                MessageBox.Show("Nie znaleziono rekordu.");
                return;
            }

            // =========================
            // CZĘŚĆ
            // =========================
            if (cbox_czesc.SelectedValue == null)
            {
                MessageBox.Show("Wybierz część.");
                return;
            }

            int idCzesci = (int)cbox_czesc.SelectedValue;

            // =========================
            // ILOŚĆ
            // =========================
            int liczba = (int)num_ud_liczba_czesci.Value;

            if (liczba <= 0)
            {
                MessageBox.Show("Liczba musi być większa od 0.");
                return;
            }

            // =========================
            // UPDATE
            // =========================
            rekord.IdCzesci = idCzesci;
            rekord.Liczba = liczba;

            context.SaveChanges();

            MessageBox.Show("Zaktualizowano część.");

            ZaladujCzesciAwariiDlaWybranej();
        }
        private void UsunCzescAwarii()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz rekord.");
                return;
            }

            int idCzesciAwaria = Convert.ToInt32(
                dataGridView1.CurrentRow.Cells["IdCzesciAwaria"].Value
            );

            var rekord = context.CzesciAwaria
                .FirstOrDefault(x => x.IdCzesciAwaria == idCzesciAwaria);

            if (rekord == null)
            {
                MessageBox.Show("Nie znaleziono rekordu.");
                return;
            }

            var result = MessageBox.Show(
                "Czy na pewno chcesz usunąć tę część?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                context.CzesciAwaria.Remove(rekord);
                context.SaveChanges();

                MessageBox.Show("Usunięto część.");

                ZaladujCzesciAwariiDlaWybranej();
            }
        }
    }
}

using PodkladexApp.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PodkladexApp.Kadry_i_finanse
{
    public partial class Form_SiatkaPlac : Form
    {
        private readonly PodkladexContext db;

        private readonly int idPracownik;
        private readonly DateOnly dataRozUmowy;
        private readonly DateOnly dataZakUmowy;
        private readonly string danePracownika;

        private int? edytowaneIdSiatkaPlac = null;

        public Form_SiatkaPlac(
            int idPracownik,
            DateOnly dataRozUmowy,
            DateOnly dataZakUmowy,
            string danePracownika)
        {
            InitializeComponent();

            db = new PodkladexContext();

            this.idPracownik = idPracownik;
            this.dataRozUmowy = dataRozUmowy;
            this.dataZakUmowy = dataZakUmowy;
            this.danePracownika = danePracownika;
        }

        private void Form_SiatkaPlac_Load(object sender, EventArgs e)
        {
            KonfigurujDateTimePickery();
            KonfigurujDataGridView();

            label_pracownik.Text = "Pracownik: " + danePracownika;

            label_okresUmowy.Text =
                "Okres umowy: " +
                dataRozUmowy.ToString("dd.MM.yyyy") +
                " - " +
                dataZakUmowy.ToString("dd.MM.yyyy");

            UstawDomyslneDane();
            UstawTrybDodawania();
            ZaladujSiatkePlac();
        }

        private void KonfigurujDateTimePickery()
        {
            dateTimePicker_dataPocz.Format = DateTimePickerFormat.Custom;
            dateTimePicker_dataPocz.CustomFormat = "MM.yyyy";
            dateTimePicker_dataPocz.ShowUpDown = true;

            dateTimePicker_dataKoniec.Format = DateTimePickerFormat.Custom;
            dateTimePicker_dataKoniec.CustomFormat = "MM.yyyy";
            dateTimePicker_dataKoniec.ShowUpDown = true;
        }

        private void KonfigurujDataGridView()
        {
            dataGridView_siatkaPlac.AutoGenerateColumns = false;
            dataGridView_siatkaPlac.AllowUserToAddRows = false;
            dataGridView_siatkaPlac.AllowUserToDeleteRows = false;
            dataGridView_siatkaPlac.ReadOnly = true;
            dataGridView_siatkaPlac.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_siatkaPlac.MultiSelect = false;
            dataGridView_siatkaPlac.RowHeadersVisible = false;
            dataGridView_siatkaPlac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_siatkaPlac.Columns.Clear();

            dataGridView_siatkaPlac.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdSiatkaPlac",
                HeaderText = "ID",
                DataPropertyName = "IdSiatkaPlac",
                Visible = false
            });

            dataGridView_siatkaPlac.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataPocz",
                HeaderText = "Od miesiąca",
                DataPropertyName = "DataPocz",
                FillWeight = 100
            });

            dataGridView_siatkaPlac.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataKoniec",
                HeaderText = "Do miesiąca",
                DataPropertyName = "DataKoniec",
                FillWeight = 100
            });

            dataGridView_siatkaPlac.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Wynagrodzenie",
                HeaderText = "Wynagrodzenie miesięczne",
                DataPropertyName = "Wynagrodzenie",
                FillWeight = 120
            });

            dataGridView_siatkaPlac.CellDoubleClick -= dataGridView_siatkaPlac_CellDoubleClick;
            dataGridView_siatkaPlac.CellDoubleClick += dataGridView_siatkaPlac_CellDoubleClick;
        }

        private void ZaladujSiatkePlac()
        {
            try
            {
                var daneZBazy = db.SiatkaPlac
                    .Where(sp =>
                        sp.IdPracownik == idPracownik &&
                        sp.DataPocz <= dataZakUmowy &&
                        (sp.DataKoniec == null || sp.DataKoniec >= dataRozUmowy))
                    .OrderBy(sp => sp.DataPocz)
                    .ToList();

                var lista = daneZBazy
                    .Select(sp => new
                    {
                        sp.IdSiatkaPlac,

                        DataPocz = sp.DataPocz.ToString("MM.yyyy"),

                        DataKoniec = sp.DataKoniec.HasValue
                            ? sp.DataKoniec.Value.ToString("MM.yyyy")
                            : "Bezterminowo",

                        Wynagrodzenie = sp.Wynagrodzenie.ToString("0.00", CultureInfo.GetCultureInfo("pl-PL"))
                    })
                    .ToList();

                dataGridView_siatkaPlac.DataSource = null;
                dataGridView_siatkaPlac.DataSource = lista;

                dataGridView_siatkaPlac.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania siatki płac:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DateOnly PierwszyDzienMiesiaca(DateTime data)
        {
            return new DateOnly(data.Year, data.Month, 1);
        }

        private DateOnly OstatniDzienMiesiaca(DateTime data)
        {
            int ostatniDzien = DateTime.DaysInMonth(data.Year, data.Month);
            return new DateOnly(data.Year, data.Month, ostatniDzien);
        }

        private DateOnly PierwszyDzienMiesiaca(DateOnly data)
        {
            return new DateOnly(data.Year, data.Month, 1);
        }

        private DateOnly OstatniDzienMiesiaca(DateOnly data)
        {
            int ostatniDzien = DateTime.DaysInMonth(data.Year, data.Month);
            return new DateOnly(data.Year, data.Month, ostatniDzien);
        }

        private DateTime DataDoDateTime(DateOnly data)
        {
            return data.ToDateTime(TimeOnly.MinValue);
        }

        private void UstawDomyslneDane()
        {
            DateOnly pierwszyMiesiacUmowy = PierwszyDzienMiesiaca(dataRozUmowy);
            DateOnly ostatniMiesiacUmowy = PierwszyDzienMiesiaca(dataZakUmowy);

            dateTimePicker_dataPocz.Value = DataDoDateTime(pierwszyMiesiacUmowy);
            dateTimePicker_dataKoniec.Value = DataDoDateTime(ostatniMiesiacUmowy);

            textBox_wynagrodzenie.Text = "";
        }

        private void UstawTrybDodawania()
        {
            edytowaneIdSiatkaPlac = null;

            button_dodajWpis.Visible = true;
            button_dodajWpis.Enabled = true;

            button_zatwierdzZmiany.Visible = false;
            button_zatwierdzZmiany.Enabled = false;
        }

        private void UstawTrybEdycji()
        {
            button_dodajWpis.Visible = false;
            button_dodajWpis.Enabled = false;

            button_zatwierdzZmiany.Visible = true;
            button_zatwierdzZmiany.Enabled = true;
        }

        private bool SprobujPobracWynagrodzenie(out decimal wynagrodzenie)
        {
            string tekst = textBox_wynagrodzenie.Text.Trim().Replace('.', ',');

            if (!decimal.TryParse(
                tekst,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pl-PL"),
                out wynagrodzenie))
            {
                MessageBox.Show(
                    "Podaj poprawną kwotę wynagrodzenia.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (wynagrodzenie < 0)
            {
                MessageBox.Show(
                    "Wynagrodzenie nie może być ujemne.",
                    "Błędne dane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool SprawdzDaty(DateOnly dataPocz, DateOnly dataKoniec)
        {
            if (dataKoniec < dataPocz)
            {
                MessageBox.Show(
                    "Miesiąc końcowy nie może być wcześniejszy niż miesiąc początkowy.",
                    "Błędny okres",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            DateOnly pierwszyMiesiacUmowy = PierwszyDzienMiesiaca(dataRozUmowy);
            DateOnly ostatniMiesiacUmowy = OstatniDzienMiesiaca(dataZakUmowy);

            if (dataPocz < pierwszyMiesiacUmowy)
            {
                MessageBox.Show(
                    "Miesiąc początku wynagrodzenia nie może być wcześniejszy niż miesiąc rozpoczęcia umowy.",
                    "Błędny okres",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (dataKoniec > ostatniMiesiacUmowy)
            {
                MessageBox.Show(
                    "Miesiąc końca wynagrodzenia nie może być późniejszy niż miesiąc zakończenia umowy.",
                    "Błędny okres",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool CzyIstniejeKolizjaDat(DateOnly dataPocz, DateOnly dataKoniec)
        {
            return db.SiatkaPlac.Any(sp =>
                sp.IdPracownik == idPracownik &&
                sp.IdSiatkaPlac != (edytowaneIdSiatkaPlac ?? 0) &&
                sp.DataPocz <= dataKoniec &&
                (sp.DataKoniec == null || sp.DataKoniec >= dataPocz));
        }

        private void DodajWpis()
        {
            if (!SprobujPobracWynagrodzenie(out decimal wynagrodzenie))
                return;

            DateOnly dataPocz = PierwszyDzienMiesiaca(dateTimePicker_dataPocz.Value.Date);
            DateOnly dataKoniec = OstatniDzienMiesiaca(dateTimePicker_dataKoniec.Value.Date);

            if (!SprawdzDaty(dataPocz, dataKoniec))
                return;

            if (CzyIstniejeKolizjaDat(dataPocz, dataKoniec))
            {
                MessageBox.Show(
                    "Podany okres wynagrodzenia nachodzi na inny wpis w siatce płac tego pracownika.",
                    "Kolizja okresów",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                SiatkaPlac nowyWpis = new SiatkaPlac
                {
                    IdPracownik = idPracownik,
                    DataPocz = dataPocz,
                    DataKoniec = dataKoniec,
                    Wynagrodzenie = wynagrodzenie
                };

                db.SiatkaPlac.Add(nowyWpis);
                db.SaveChanges();

                MessageBox.Show(
                    "Wpis siatki płac został dodany.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscFormularz();
                ZaladujSiatkePlac();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas dodawania wpisu siatki płac:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ZaladujWpisDoEdycji(int idSiatkaPlac)
        {
            try
            {
                var wpis = db.SiatkaPlac.FirstOrDefault(sp => sp.IdSiatkaPlac == idSiatkaPlac);

                if (wpis == null)
                {
                    MessageBox.Show(
                        "Nie znaleziono wpisu siatki płac.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                edytowaneIdSiatkaPlac = wpis.IdSiatkaPlac;

                DateOnly miesiacPocz = PierwszyDzienMiesiaca(wpis.DataPocz);
                DateOnly miesiacKoniec = wpis.DataKoniec.HasValue
                    ? PierwszyDzienMiesiaca(wpis.DataKoniec.Value)
                    : PierwszyDzienMiesiaca(dataZakUmowy);

                dateTimePicker_dataPocz.Value = DataDoDateTime(miesiacPocz);
                dateTimePicker_dataKoniec.Value = DataDoDateTime(miesiacKoniec);

                textBox_wynagrodzenie.Text = wpis.Wynagrodzenie.ToString("0.00", CultureInfo.GetCultureInfo("pl-PL"));

                UstawTrybEdycji();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania wpisu do edycji:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ZapiszZmiany()
        {
            if (edytowaneIdSiatkaPlac == null)
            {
                MessageBox.Show(
                    "Nie wybrano wpisu do edycji.",
                    "Brak danych",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!SprobujPobracWynagrodzenie(out decimal wynagrodzenie))
                return;

            DateOnly dataPocz = PierwszyDzienMiesiaca(dateTimePicker_dataPocz.Value.Date);
            DateOnly dataKoniec = OstatniDzienMiesiaca(dateTimePicker_dataKoniec.Value.Date);

            if (!SprawdzDaty(dataPocz, dataKoniec))
                return;

            if (CzyIstniejeKolizjaDat(dataPocz, dataKoniec))
            {
                MessageBox.Show(
                    "Podany okres wynagrodzenia nachodzi na inny wpis w siatce płac tego pracownika.",
                    "Kolizja okresów",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                var wpis = db.SiatkaPlac.FirstOrDefault(sp => sp.IdSiatkaPlac == edytowaneIdSiatkaPlac.Value);

                if (wpis == null)
                {
                    MessageBox.Show(
                        "Nie znaleziono wpisu siatki płac w bazie.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                wpis.DataPocz = dataPocz;
                wpis.DataKoniec = dataKoniec;
                wpis.Wynagrodzenie = wynagrodzenie;

                db.SaveChanges();

                MessageBox.Show(
                    "Zmiany w siatce płac zostały zapisane.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                WyczyscFormularz();
                ZaladujSiatkePlac();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas zapisywania zmian:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void WyczyscFormularz()
        {
            UstawDomyslneDane();
            UstawTrybDodawania();

            if (dataGridView_siatkaPlac.DataSource != null)
            {
                dataGridView_siatkaPlac.ClearSelection();
            }
        }

        private void button_dodajWpis_Click(object sender, EventArgs e)
        {
            DodajWpis();
        }

        private void button_zatwierdzZmiany_Click(object sender, EventArgs e)
        {
            ZapiszZmiany();
        }

        private void button_wyczysc_Click(object sender, EventArgs e)
        {
            WyczyscFormularz();
        }

        private void dataGridView_siatkaPlac_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (dataGridView_siatkaPlac.Rows[e.RowIndex].Cells["IdSiatkaPlac"].Value == null)
                    return;

                int idSiatkaPlac = Convert.ToInt32(dataGridView_siatkaPlac.Rows[e.RowIndex].Cells["IdSiatkaPlac"].Value);

                ZaladujWpisDoEdycji(idSiatkaPlac);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas wyboru wpisu siatki płac:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
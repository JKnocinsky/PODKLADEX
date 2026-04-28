using PodkladexApp.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_Urlopy : Form
    {
        private PodkladexContext db;

        public Form_Urlopy()
        {
            InitializeComponent();
            db = new PodkladexContext();
        }

        private void Form_Urlopy_Load(object sender, EventArgs e)
        {
            KonfigurujDataGridView();
            ZaladujWnioski();
        }

        private void KonfigurujDataGridView()
        {
            dataGridView_urlopy.AutoGenerateColumns = false;
            dataGridView_urlopy.AllowUserToAddRows = false;
            dataGridView_urlopy.AllowUserToDeleteRows = false;
            dataGridView_urlopy.ReadOnly = true;
            dataGridView_urlopy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_urlopy.MultiSelect = false;
            dataGridView_urlopy.RowHeadersVisible = false;
            dataGridView_urlopy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_urlopy.Columns.Clear();

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdWniosku",
                HeaderText = "ID wniosku",
                DataPropertyName = "IdWniosku",
                FillWeight = 60
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Pracownik",
                HeaderText = "Pracownik",
                DataPropertyName = "Pracownik",
                FillWeight = 150
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Urlop",
                HeaderText = "Rodzaj urlopu",
                DataPropertyName = "Urlop",
                FillWeight = 110
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataRozp",
                HeaderText = "Data rozpoczęcia",
                DataPropertyName = "DataRozp",
                FillWeight = 90
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataZak",
                HeaderText = "Data zakończenia",
                DataPropertyName = "DataZak",
                FillWeight = 90
            });

            dataGridView_urlopy.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "StatusWniosku",
                HeaderText = "Zatwierdzony",
                DataPropertyName = "StatusWniosku",
                FillWeight = 70
            });
        }

        private void ZaladujWnioski()
        {
            try
            {
                var zapytanie = db.WniosekUrlopowy
                    .Include(w => w.IdPracownikNavigation)
                        .ThenInclude(p => p.IdOsobaNavigation)
                    .Include(w => w.IdUrlopuNavigation)
                    .AsQueryable();

                if (checkBox_tylkoNiezatwierdzone.Checked)
                {
                    zapytanie = zapytanie.Where(w => w.StatusWniosku == false);
                }

                var daneZBazy = zapytanie
                    .OrderBy(w => w.StatusWniosku)
                    .ThenBy(w => w.DataRozp)
                    .ToList();

                var lista = daneZBazy
                    .Select(w => new
                    {
                        w.IdWniosku,
                        Pracownik = w.IdPracownikNavigation.IdOsobaNavigation.Imie + " " +
                                    w.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                        Urlop = w.IdUrlopuNavigation.Nazwa,
                        DataRozp = w.DataRozp.ToString("dd.MM.yyyy"),
                        DataZak = w.DataZak.ToString("dd.MM.yyyy"),
                        w.StatusWniosku
                    })
                    .ToList();

                dataGridView_urlopy.DataSource = null;
                dataGridView_urlopy.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas ładowania wniosków urlopowych:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int? PobierzIdZaznaczonegoWniosku()
        {
            if (dataGridView_urlopy.CurrentRow == null)
                return null;

            object wartosc = dataGridView_urlopy.CurrentRow.Cells["IdWniosku"].Value;

            if (wartosc == null)
                return null;

            return Convert.ToInt32(wartosc);
        }

        private void button_odswiez_Click(object sender, EventArgs e)
        {
            ZaladujWnioski();
        }

        private void checkBox_tylkoNiezatwierdzone_CheckedChanged(object sender, EventArgs e)
        {
            ZaladujWnioski();
        }

        private void button_zatwierdz_Click(object sender, EventArgs e)
        {
            int? idWniosku = PobierzIdZaznaczonegoWniosku();

            if (idWniosku == null)
            {
                MessageBox.Show(
                    "Wybierz wniosek do zatwierdzenia.",
                    "Brak wyboru",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var wniosek = db.WniosekUrlopowy.FirstOrDefault(w => w.IdWniosku == idWniosku.Value);

                if (wniosek == null)
                {
                    MessageBox.Show(
                        "Nie znaleziono wybranego wniosku.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (wniosek.StatusWniosku)
                {
                    MessageBox.Show(
                        "Ten wniosek jest już zatwierdzony.",
                        "Informacja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult wynik = MessageBox.Show(
                    "Czy na pewno chcesz zatwierdzić wybrany wniosek urlopowy?",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (wynik == DialogResult.No)
                    return;

                wniosek.StatusWniosku = true;
                db.SaveChanges();

                MessageBox.Show(
                    "Wniosek został zatwierdzony.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ZaladujWnioski();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd podczas zatwierdzania wniosku:\n" + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
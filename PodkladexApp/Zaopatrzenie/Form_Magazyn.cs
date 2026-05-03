using Microsoft.EntityFrameworkCore;
using PodkladexApp.Models; // Pamiętaj o użyciu prawidłowego namespace z modelami
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PodkladexApp.Zaopatrzenie // <--- TU WPISZ SWÓJ NAMESPACE
{
    public partial class Form_Magazyn : Form
    {
        // 1. Obiekt bazy
        // 1. Obiekt bazy
        private PodkladexContext _db = new PodkladexContext();

        public Form_Magazyn()
        {
            InitializeComponent();
            this.Text = "Stany Magazynowe";

            // TWARDY START: Wywołujemy te metody prosto z konstruktora!
            // Dzięki temu mamy 100% pewności, że odpalą się zawsze przy OpenChildForm()
            KonfigurujWidok();
            ZaladujRodzajeDoFiltru();
            OdswiezTabelke();
        }

        // Metodę Form_Magazyn_Load możesz w ogóle usunąć z kodu, nie będzie nam już potrzebna!

        private void KonfigurujWidok()
        {
            // Opcje wizualne tabeli
            dataGridView_Magazyn.AllowUserToAddRows = false;
            dataGridView_Magazyn.AllowUserToDeleteRows = false;
            dataGridView_Magazyn.ReadOnly = true;
            dataGridView_Magazyn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Magazyn.RowHeadersVisible = false;
            dataGridView_Magazyn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Czcionki i wysokość, żeby to wyglądało "pro"
            dataGridView_Magazyn.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView_Magazyn.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dataGridView_Magazyn.RowTemplate.Height = 35;
            dataGridView_Magazyn.ColumnHeadersHeight = 45;
        }

        private void ZaladujRodzajeDoFiltru()
        {
            var rodzaje = _db.RodzajMaterialu.ToList();
            rodzaje.Insert(0, new RodzajMaterialu { IdRodzaj = 0, Nazwa = "-- Wszystkie --" });

            comboBox_Rodzaj.SelectedIndexChanged -= comboBox_Rodzaj_SelectedIndexChanged;
            comboBox_Rodzaj.DataSource = rodzaje;
            comboBox_Rodzaj.DisplayMember = "Nazwa";
            comboBox_Rodzaj.ValueMember = "IdRodzaj";
            comboBox_Rodzaj.SelectedIndexChanged += comboBox_Rodzaj_SelectedIndexChanged;
        }

        private void OdswiezTabelke()
        {
            try
            {
                var zapytanie = _db.AktualnyStanMagazynu.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(textBox_Wyszukaj.Text))
                {
                    string szukana = textBox_Wyszukaj.Text.ToLower();
                    zapytanie = zapytanie.Where(m => m.NazwaMaterialu.ToLower().Contains(szukana));
                }

                if (comboBox_Rodzaj.SelectedValue != null && (int)comboBox_Rodzaj.SelectedValue > 0)
                {
                    string wybranyRodzaj = comboBox_Rodzaj.Text;
                    zapytanie = zapytanie.Where(m => m.RodzajMaterialu == wybranyRodzaj);
                }

                // 1. Łączymy zapytanie z widoku z tabelą Material, aby dostać się do właściwości
                var daneZabaza = zapytanie.Join(_db.Material,
                    stan => stan.IdMaterial,
                    mat => mat.IdMaterial,
                    (stan, mat) => new
                    {
                        stan.IdMaterial,
                        stan.NazwaMaterialu,
                        stan.OpisMaterialu,
                        stan.RodzajMaterialu,
                        stan.CalkowiteDostawy,
                        stan.CalkowiteZuzycie,
                        stan.AktualnyStan,
                        // Zabezpieczamy się na wypadek braku wymiaru rzutując na ułamek "nullowalny"
                        WartoscNominalna = mat.MaterialWlasciwosci.Select(mw => (decimal?)mw.WartoscNominalna).FirstOrDefault()
                    }).ToList(); // Pobieramy do pamięci RAM, żeby LINQ nie "wywaliło" się na klejeniu stringów

                // 2. Mapujemy na ostateczny, ładny format
                var wynik = daneZabaza.Select(s => new
                {
                    s.IdMaterial,

                    // NOWE: Sklejona nazwa wg Twojego życzenia
                    Nazwa = s.NazwaMaterialu + " || " + (s.WartoscNominalna != null ? s.WartoscNominalna.ToString() : "Brak wymiaru"),

                    Opis = s.OpisMaterialu,
                    Rodzaj = s.RodzajMaterialu,
                    Dostawy = Math.Round(s.CalkowiteDostawy, 2),
                    Zuzycie = Math.Round(s.CalkowiteZuzycie, 2),
                    StanAktualny = Math.Round(s.AktualnyStan ?? 0m, 2)
                }).ToList();

                dataGridView_Magazyn.DataSource = wynik;

                // --- Opcjonalne upiększenia kolumn ---
                if (dataGridView_Magazyn.Columns.Count > 0)
                {
                    dataGridView_Magazyn.Columns["IdMaterial"].Visible = false; // Ukrywamy brzydkie ID

                    // Nazwa nagłówka zostaje nienaruszona
                    dataGridView_Magazyn.Columns["Nazwa"].HeaderText = "Materiał";

                    dataGridView_Magazyn.Columns["Opis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView_Magazyn.Columns["Dostawy"].HeaderText = "Suma dostaw [kg]";
                    dataGridView_Magazyn.Columns["Zuzycie"].HeaderText = "Zużycie [kg]";
                    dataGridView_Magazyn.Columns["StanAktualny"].HeaderText = "Na stanie [kg]";

                    dataGridView_Magazyn.Columns["Dostawy"].DefaultCellStyle.Format = "N2";
                    dataGridView_Magazyn.Columns["Zuzycie"].DefaultCellStyle.Format = "N2";
                    dataGridView_Magazyn.Columns["StanAktualny"].DefaultCellStyle.Format = "N2";

                    dataGridView_Magazyn.Columns["Dostawy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView_Magazyn.Columns["Zuzycie"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView_Magazyn.Columns["StanAktualny"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView_Magazyn.Columns["StanAktualny"].DefaultCellStyle.BackColor = Color.LightCyan;
                    dataGridView_Magazyn.Columns["StanAktualny"].DefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania magazynu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================
        // ZDARZENIA (EVENTY) KONTROLEK
        // Pamiętaj, aby podpiąć je w Designerze! (lub dopisz do nich "Handles" w VB.NET, ale to C#)
        // =====================================

        // Gdy wpisujemy literki, tablica odświeża się od razu
        private void textBox_Wyszukaj_TextChanged(object sender, EventArgs e)
        {
            OdswiezTabelke();
        }

        // Gdy zmieniamy rodzaj materiału w filtrze
        private void comboBox_Rodzaj_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdswiezTabelke();
        }

        // Kliknięcie w przycisk resetujący
        private void button_WyczyscFiltry_Click(object sender, EventArgs e)
        {
            textBox_Wyszukaj.Clear();
            comboBox_Rodzaj.SelectedIndex = 0; // Ustawia z powrotem "-- Wszystkie --"
            OdswiezTabelke(); // Na wszelki wypadek
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db.Dispose(); // Niezwykle ważne, aby nie ubijać pamięci
            base.OnFormClosed(e);
        }

        private void dataGridView_Magazyn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
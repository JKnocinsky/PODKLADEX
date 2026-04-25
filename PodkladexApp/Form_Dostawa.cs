using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PodkladexApp.Models;

namespace PodkladexApp
{
    public partial class Form_Dostawa : Form
    {
        private readonly PodkladexContext _context;

        public Form_Dostawa()
        {
            InitializeComponent();

            _context = new PodkladexContext();
            this.Load += Form_Dostawa_Load;
        }

        private void Form_Dostawa_Load(object sender, EventArgs e)
        {
            try
            {
                // Ładowanie Firm
                comboBox_DostawaFirma.DataSource = _context.Firma.ToList();
                comboBox_DostawaFirma.DisplayMember = "Nazwa";
                comboBox_DostawaFirma.ValueMember = "IdFirma";

                // Ładowanie Pracowników z imieniem i nazwiskiem
                var pracownicy = _context.Pracownik
                    .Include(p => p.IdOsobaNavigation)
                    .Select(p => new
                    {
                        p.IdPracownik,
                        ImieNazwisko = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko
                    })
                    .ToList();

                comboBox_DostawaPracownik.DataSource = pracownicy;
                comboBox_DostawaPracownik.DisplayMember = "ImieNazwisko";
                comboBox_DostawaPracownik.ValueMember = "IdPracownik";

                // Ładowanie Materiałów (zostawiamy, żeby kontrolka na widoku miała dane)
                comboBox_DostawaMat.DataSource = _context.Material.ToList();
                comboBox_DostawaMat.DisplayMember = "Nazwa";
                comboBox_DostawaMat.ValueMember = "IdMaterial";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DodajDostawe_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Pobieramy wartości z ComboBoxów Firmy i Pracownika oraz datę
                int wybraneIdFirmy = (int)comboBox_DostawaFirma.SelectedValue;
                int wybraneIdPracownika = (int)comboBox_DostawaPracownik.SelectedValue;
                // Konwersja DateTime na DateOnly
                DateOnly dataDostawy = DateOnly.FromDateTime(dateTimePicker1.Value);

                // 2. Tworzymy TYLKO główny obiekt dostawy (bez szczegółów)
                var nowaDostawa = new Dostawa
                {
                    IdFirma = wybraneIdFirmy,
                    IdPracownik = wybraneIdPracownika,
                    DataDostawy = dataDostawy
                };

                // 3. Zapisujemy wszystko do bazy
                _context.Dostawa.Add(nowaDostawa);
                _context.SaveChanges();

                MessageBox.Show("Dostawa została pomyślnie dodana do bazy!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
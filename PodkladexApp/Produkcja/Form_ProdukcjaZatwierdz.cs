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

namespace PodkladexApp.Produkcja
{
    public partial class Form_ProdukcjaZatwierdz : Form
    {
        PodkladexContext db;
        // Flaga do odróżnienia programatycznych zmian DateTimePicker od zmian użytkownika
        bool _suppressDtpCheckedSet = false;

        public Form_ProdukcjaZatwierdz(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;

            // Podłączamy zdarzenia tutaj, aby nie polegać na designerze.
            this.Load += Form_ProdukcjaZatwierdz_Load;
            cmb_zamowienia.SelectedIndexChanged += Cmb_zamowienia_SelectedIndexChanged;
            dtp_data.ValueChanged += Dtp_data_ValueChanged;
        }

        private void Form_ProdukcjaZatwierdz_Load(object? sender, EventArgs e)
        {
            LoadZamowienia();
            ConfigureDataGridView();
            // Nie wybieramy automatycznie elementów — umożliwia to "wyczyszczenie" wyborów
            cmb_zamowienia.SelectedIndex = -1;
            // Odświeżymy siatkę (pusta, dopóki nie będzie wybranego zamówienia i daty)
            RefreshProdukcjaGrid();
        }

        private void ConfigureDataGridView()
        {
            dgv_produkcja.AutoGenerateColumns = true;
            dgv_produkcja.ReadOnly = true;
            dgv_produkcja.AllowUserToAddRows = false;
            dgv_produkcja.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_produkcja.MultiSelect = false;
            dgv_produkcja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadZamowienia()
        {
            // Pobierz unikalne zamówienia z widoku, gdzie SredniaWartoscFormula < 100
            var items = db.WidokProdukcjaProcentRealizacji
                .Where(w => w.SredniaWartoscFormula < 100M)
                .Select(w => w.IdZamowienie)
                .Distinct()
                .OrderBy(id => id)
                .AsEnumerable()
                .Select(id => new
                {
                    Text = $"Zamówienie {id}",
                    Value = id
                })
                .ToList();

            cmb_zamowienia.DisplayMember = "Text";
            cmb_zamowienia.ValueMember = "Value";
            cmb_zamowienia.DataSource = items;
            // Pozostawiamy SelectedIndex = -1 (ustawione w Load) żeby umożliwić "wyczyszczenie" wyboru
        }

        private void Cmb_zamowienia_SelectedIndexChanged(object? sender, EventArgs e)
        {
            RefreshProdukcjaGrid();
        }

        private void Dtp_data_ValueChanged(object? sender, EventArgs e)
        {
            // Jeśli zmiana daty jest wykonana przez użytkownika -> włącz checkbox (jeśli dostępny)
            if (!_suppressDtpCheckedSet)
            {
                try
                {
                    if (dtp_data.ShowCheckBox)
                        dtp_data.Checked = true;
                }
                catch
                {
                    // kontrolka może nie mieć ShowCheckBox; ignorujemy
                }
            }

            RefreshProdukcjaGrid();
        }

        private void RefreshProdukcjaGrid()
        {
            try
            {
                bool hasZamowienie = cmb_zamowienia.SelectedIndex >= 0 && cmb_zamowienia.SelectedValue != null;
                bool hasDate;

                // Obsługa opcjonalnego checkboxa w DateTimePicker:
                // jeśli kontrolka nie ma checkboxa, Checked zwróci wyjątek — dlatego try/catch
                try
                {
                    hasDate = !dtp_data.ShowCheckBox || dtp_data.Checked;
                }
                catch
                {
                    hasDate = true; // brak checkboxa => data zawsze traktujemy jako wybrana
                }

                // Budujemy zapytanie dynamicznie — jeśli żaden filtr nie jest ustawiony, query pozostaje nieograniczone i zwróci wszystkie rekordy.
                var query = db.WidokZamowieniaZadania.AsQueryable();

                if (hasZamowienie)
                {
                    int selectedId = Convert.ToInt32(cmb_zamowienia.SelectedValue);
                    query = query.Where(w => w.IdZamowienie == selectedId);
                }

                if (hasDate)
                {
                    DateOnly selectedDateOnly = DateOnly.FromDateTime(dtp_data.Value.Date);
                    query = query.Where(w => w.DataZadania == selectedDateOnly);
                }

                var records = query
                    .Select(w => new ProductionGridItem
                    {
                        IdProdukcja = w.IdProdukcja,
                        DataZadania = w.DataZadania,
                        NazwaMaszyny = w.NazwaMaszyny,
                        NazwaProduktu = w.NazwaProduktu,
                        ObliczonaIloscWyprodukowana = w.ObliczonaIloscWyprodukowana,
                        ObliczonaIloscOdpadow = w.ObliczonaIloscOdpadow,
                        Pracownik = w.Pracownik,
                        RBH = w.Rbh
                    })
                    .ToList();

                dgv_produkcja.DataSource = records;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odświeżania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clearDate_Click(object sender, EventArgs e)
        {
            // Czyścimy datę w DateTimePicker — ustawiamy checked = false i datę na dziś.
            // Ustawiamy flagę aby nie zareagować w ValueChanged (programatyczna zmiana).
            _suppressDtpCheckedSet = true;
            try
            {
                dtp_data.Checked = false;
                dtp_data.Value = DateTime.Now;
            }
            finally
            {
                _suppressDtpCheckedSet = false;
            }

            RefreshProdukcjaGrid();
        }

        private void btn_zatwierdz_Click(object sender, EventArgs e)
        {
            // Pobierz wybrany rekord z dgv_produkcja
            if (dgv_produkcja.CurrentRow == null || dgv_produkcja.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Proszę wybrać rekord w tabeli.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = dgv_produkcja.CurrentRow.DataBoundItem as ProductionGridItem;
            if (item == null)
            {
                MessageBox.Show("Nie można odczytać wybranego rekordu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idProdukcja = item.IdProdukcja ?? 0;
            decimal iloscWyprodukowana = item.ObliczonaIloscWyprodukowana ?? 0M;
            decimal iloscOdpadow = item.ObliczonaIloscOdpadow ?? 0M;

            // Przekazujemy dodatkowe dane do podformularza
            var form = new Form_ProdukcjaZatwierdzPodform(db, idProdukcja, iloscWyprodukowana, iloscOdpadow);
            form.ShowDialog();
        }

        // DTO do bindowania DataGridView - konkretna klasa ułatwia późniejsze pobranie zaznaczonego rekordu
        private class ProductionGridItem
        {
            public int? IdProdukcja { get; set; }
            public DateOnly DataZadania { get; set; }
            public string NazwaMaszyny { get; set; } = string.Empty;
            public string NazwaProduktu { get; set; } = string.Empty;
            public decimal? ObliczonaIloscWyprodukowana { get; set; }
            public decimal? ObliczonaIloscOdpadow { get; set; }
            public string Pracownik { get; set; } = string.Empty;
            public decimal? RBH { get; set; }
        }
    }
}

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
        // Flaga zapobiegająca wielokrotnemu odświeżaniu siatki podczas operacji na kontrolkach
        bool _isUpdatingLayout = false;
        bool _suppressDtpCheckedSet = false;

        public Form_ProdukcjaZatwierdz(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;

            this.Load += Form_ProdukcjaZatwierdz_Load;
            cmb_zamowienia.SelectedIndexChanged += Cmb_zamowienia_SelectedIndexChanged;
            dtp_data.ValueChanged += Dtp_data_ValueChanged;
            dgv_produkcja.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        }

        private void Form_ProdukcjaZatwierdz_Load(object? sender, EventArgs e)
        {
            _isUpdatingLayout = true;
            LoadZamowienia();
            ConfigureDataGridView();
            cmb_zamowienia.SelectedIndex = -1;
            _isUpdatingLayout = false;

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
            // Zapamiętujemy aktualnie wybrane zamówienie przed odświeżeniem listy
            int? currentSelectedId = null;
            if (cmb_zamowienia.SelectedValue is int id) currentSelectedId = id;

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

            // Podpięcie danych
            cmb_zamowienia.DisplayMember = "Text";
            cmb_zamowienia.ValueMember = "Value";
            cmb_zamowienia.DataSource = items;

            // Przywracamy zaznaczenie, jeśli zamówienie nadal wymaga pracy (<100%)
            if (currentSelectedId.HasValue && items.Any(i => i.Value == currentSelectedId.Value))
            {
                cmb_zamowienia.SelectedValue = currentSelectedId.Value;
            }
            else
            {
                cmb_zamowienia.SelectedIndex = -1;
            }
        }

        private void Cmb_zamowienia_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_isUpdatingLayout) RefreshProdukcjaGrid();
        }

        private void Dtp_data_ValueChanged(object? sender, EventArgs e)
        {
            // ZABEZPIECZENIE: Sprawdzenie, czy wybrana data nie jest z przyszłości
            if (dtp_data.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Nie można wybrać daty z przyszłości.", "Błędna data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Ustawienie daty na dzisiejszą - to wywoła zdarzenie ponownie, 
                // ale następnym razem warunek (date > today) nie będzie spełniony.
                dtp_data.Value = DateTime.Today;
                return;
            }

            if (!_suppressDtpCheckedSet)
            {
                try
                {
                    if (dtp_data.ShowCheckBox)
                        dtp_data.Checked = true;
                }
                catch { }
            }
            if (!_isUpdatingLayout) RefreshProdukcjaGrid();
        }

        private void RefreshProdukcjaGrid()
        {
            try
            {
                bool hasZamowienie = cmb_zamowienia.SelectedIndex >= 0 && cmb_zamowienia.SelectedValue != null;
                bool hasDate;

                try
                {
                    hasDate = !dtp_data.ShowCheckBox || dtp_data.Checked;
                }
                catch
                {
                    hasDate = true;
                }

                var query = db.WidokZamowieniaZadania.AsQueryable();

                // Filtrowanie tylko niezatwierdzonych zadań (Zgodnie z Twoją prośbą)
                query = query.Where(w => db.Produkcja.Any(p => p.IdProdukcja == w.IdProdukcja && p.Wyprodukowano == null));

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
                dgv_produkcja.Columns["IdProdukcja"].Visible = false;
                dgv_produkcja.Columns["DataZadania"].HeaderText = "Data Zadania";
                dgv_produkcja.Columns["NazwaMaszyny"].HeaderText = "Nazwa Maszyny";
                dgv_produkcja.Columns["NazwaProduktu"].HeaderText = "Nazwa Produktu";

                dgv_produkcja.Columns["ObliczonaIloscWyprodukowana"].HeaderText = "Ilość Wyprodukowana (aproks.)";
                dgv_produkcja.Columns["ObliczonaIloscWyprodukowana"].DefaultCellStyle.Format = "N2";

                dgv_produkcja.Columns["ObliczonaIloscOdpadow"].HeaderText = "Ilość Odpadów (aproks.)";
                dgv_produkcja.Columns["ObliczonaIloscOdpadow"].DefaultCellStyle.Format = "N2";

                dgv_produkcja.Columns["Pracownik"].HeaderText = "Pracownik";
                dgv_produkcja.Columns["RBH"].HeaderText = "RBH";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odświeżania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clearDate_Click(object sender, EventArgs e)
        {
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

            var form = new Form_ProdukcjaZatwierdzPodform(db, idProdukcja, iloscWyprodukowana, iloscOdpadow);

            if (form.ShowDialog() == DialogResult.OK)
            {
                // ZADANIE: Stabilne odświeżenie danych bez utraty filtrów
                _isUpdatingLayout = true;
                LoadZamowienia(); // Odśwież listę zamówień (zachowując wybór jeśli możliwe)
                _isUpdatingLayout = false;

                RefreshProdukcjaGrid(); // Odśwież tabelę (zatwierdzony rekord zniknie dzięki filtrowi NULL)
            }
        }

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
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
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp.Produkcja
{
    public partial class Form_ProdukcjaZaplanuj : Form
    {
        PodkladexContext db;

        public Form_ProdukcjaZaplanuj(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;

            cmb_filtr.Items.AddRange(new string[] { "Wszystkie", "Niezaplanowane", "Zaplanowane" });
            cmb_filtr.SelectedIndex = 0;

            cmb_filtr.SelectedIndexChanged += Cmb_filtr_SelectedIndexChanged;
            cmb_wybor.SelectedIndexChanged += Cmb_wybor_SelectedIndexChanged;

            // Obsługa wyboru wiersza w tabeli
            dtg_zaplanujProd.SelectionChanged += Dtg_zaplanujProd_SelectionChanged;

            // Upewnij się, że pasek ma zakres 0..100
            pb_procentZaplanowania.Minimum = 0;
            pb_procentZaplanowania.Maximum = 100;
            pb_procentZaplanowania.Value = 0;

            lbl_wybraneZam.Text = string.Empty;

            LoadGrid(refreshCombo: true);
        }

        private void Cmb_filtr_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // przy zmianie filtra odświeżamy również zawartość cmb_wybor
            LoadGrid(refreshCombo: true);
        }

        private void Cmb_wybor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // przy zmianie wyboru zamówienia odświeżamy tylko tabelę
            LoadGrid(refreshCombo: false);
        }

        private void Dtg_zaplanujProd_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateProgressBarFromSelection();
        }

        private void UpdateProgressBarFromSelection()
        {
            try
            {
                // Aktualizacja paska procentowego
                if (dtg_zaplanujProd.CurrentRow == null)
                {
                    pb_procentZaplanowania.Value = 0;
                    lbl_wybraneZam.Text = string.Empty;
                    return;
                }

                // Aktualizacja labela z wybranym zamówieniem
                var idCell = dtg_zaplanujProd.CurrentRow.Cells["IdZamowienie"];
                if (idCell != null && idCell.Value != null && idCell.Value != DBNull.Value)
                {
                    if (int.TryParse(Convert.ToString(idCell.Value), out var idVal))
                        lbl_wybraneZam.Text = $"Zamówienie {idVal}";
                    else
                        lbl_wybraneZam.Text = $"Zamówienie {idCell.Value}";
                }
                else
                {
                    lbl_wybraneZam.Text = string.Empty;
                }

                var cell = dtg_zaplanujProd.CurrentRow.Cells["ProcentZaplanowanejProdukcji"];
                if (cell == null || cell.Value == null || cell.Value == DBNull.Value)
                {
                    pb_procentZaplanowania.Value = 0;
                    return;
                }

                decimal percentDecimal = 0m;

                // Obsłuż różne typy wartości
                switch (cell.Value)
                {
                    case decimal d:
                        percentDecimal = d;
                        break;
                    case double db:
                        percentDecimal = (decimal)db;
                        break;
                    case float f:
                        percentDecimal = (decimal)f;
                        break;
                    case int i:
                        percentDecimal = i;
                        break;
                    case long l:
                        percentDecimal = l;
                        break;
                    case string s when decimal.TryParse(s, out var parsed):
                        percentDecimal = parsed;
                        break;
                    default:
                        // próba konwersji ogólnej
                        if (decimal.TryParse(Convert.ToString(cell.Value), out var conv))
                            percentDecimal = conv;
                        break;
                }

                // Zaokrąglij i obetnij do zakresu 0..100
                var percentInt = (int)Math.Round((double)percentDecimal);
                if (percentInt < pb_procentZaplanowania.Minimum) percentInt = pb_procentZaplanowania.Minimum;
                if (percentInt > pb_procentZaplanowania.Maximum) percentInt = pb_procentZaplanowania.Maximum;

                pb_procentZaplanowania.Value = percentInt;
            }
            catch
            {
                // W razie błędu ustaw domyślną wartość
                try { pb_procentZaplanowania.Value = 0; lbl_wybraneZam.Text = string.Empty; } catch { }
            }
        }

        private void LoadGrid(bool refreshCombo)
        {
            // Bazowe zapytanie do widoku
            var baseQuery = db.WidokProdukcjaPlanowanieObliczenia.AsNoTracking().AsQueryable();

            // Zastosuj filtr z cmb_filtr:
            switch (cmb_filtr.SelectedIndex)
            {
                case 1: // Niezaplanowane: Procent < 100 (null traktujemy jako 0)
                    baseQuery = baseQuery.Where(w => (w.ProcentZaplanowanejProdukcji ?? 0m) < 100m);
                    break;
                case 2: // Zaplanowane: Procent >= 100
                    baseQuery = baseQuery.Where(w => (w.ProcentZaplanowanejProdukcji ?? 0m) >= 100m);
                    break;
                default:
                    break;
            }

            // Odśwież listę wyboru zamówień tylko gdy wymagane (zmiana filtra)
            if (refreshCombo)
            {
                var wyborList = baseQuery
                    .Select(w => w.IdZamowienie)
                    .Distinct()
                    .OrderBy(id => id)
                    .ToList()
                    .Select(id => new
                    {
                        Text = $"Zamówienie {id}",
                        Value = id
                    })
                    .ToList();

                // Bezpieczne podpięcie datasource bez wywoływania eventu SelectedIndexChanged
                cmb_wybor.SelectedIndexChanged -= Cmb_wybor_SelectedIndexChanged;
                cmb_wybor.DisplayMember = "Text";
                cmb_wybor.ValueMember = "Value";
                cmb_wybor.DataSource = wyborList;
                cmb_wybor.SelectedIndex = -1; // brak zaznaczenia domyślnie
                cmb_wybor.SelectedIndexChanged += Cmb_wybor_SelectedIndexChanged;
            }

            // Teraz zastosuj dodatkowy filtr wg wybranego zamówienia (jeśli istnieje)
            var queryForGrid = baseQuery;
            if (cmb_wybor.SelectedValue is int selectedId)
            {
                queryForGrid = queryForGrid.Where(w => w.IdZamowienie == selectedId);
            }

            var list = queryForGrid
                .Select(w => new
                {
                    w.IdZamowienie,
                    w.NazwaProduktu,
                    IloscZamowienia = w.IloscZamowienia,
                    SumaOdpady = w.SumaOdpady,
                    ZaplanowanaProdukcja = w.ZaplanowanaProdukcja,
                    ProcentZaplanowanejProdukcji = w.ProcentZaplanowanejProdukcji
                })
                .ToList();

            dtg_zaplanujProd.DataSource = list;
            dtg_zaplanujProd.AutoResizeColumns();
            dtg_zaplanujProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dtg_zaplanujProd.Columns["IdZamowienie"].HeaderText = "Zamówienie";
            dtg_zaplanujProd.Columns["NazwaProduktu"].HeaderText = "Produkt";
            dtg_zaplanujProd.Columns["IloscZamowienia"].HeaderText = "Zamówiono";
            dtg_zaplanujProd.Columns["SumaOdpady"].HeaderText = "Odrzucono";
            dtg_zaplanujProd.Columns["ZaplanowanaProdukcja"].HeaderText = "Zaplanowano produkcję";
            dtg_zaplanujProd.Columns["ProcentZaplanowanejProdukcji"].HeaderText = "Procent realizacji";

            // Formatowanie kolumn: dwie cyfry po przecinku
            var colRbh = dtg_zaplanujProd.Columns["ZaplanowanaProdukcja"];
            if (colRbh != null)
            {
                colRbh.DefaultCellStyle.Format = "N2";
                colRbh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            var colPct = dtg_zaplanujProd.Columns["ProcentZaplanowanejProdukcji"];
            if (colPct != null)
            {
                colPct.DefaultCellStyle.Format = "N2";
                colPct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Po załadowaniu danych zaktualizuj pasek i label zgodnie z aktualnie wybranym wierszem
            UpdateProgressBarFromSelection();
        }

        private void btn_zaplanuj_Click(object sender, EventArgs e)
        {
            // Sprawdź czy wybrano wiersz
            if (dtg_zaplanujProd.CurrentRow == null)
            {
                MessageBox.Show("Wybierz zamówienie z listy przed planowaniem.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pobierz IdZamowienie z aktualnego wiersza
            var idCell = dtg_zaplanujProd.CurrentRow.Cells["IdZamowienie"];
            if (idCell == null || idCell.Value == null || idCell.Value == DBNull.Value)
            {
                MessageBox.Show("Wybrany wiersz nie zawiera identyfikatora zamówienia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(Convert.ToString(idCell.Value), out int idZamowienie))
            {
                MessageBox.Show("Nie można odczytać identyfikatora zamówienia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Przekaż IdZamowienie do podformularza
            Form_ProdukcjaZaplanujPodform form = new Form_ProdukcjaZaplanujPodform(db, idZamowienie);
            form.ShowDialog();
        }
    }
}

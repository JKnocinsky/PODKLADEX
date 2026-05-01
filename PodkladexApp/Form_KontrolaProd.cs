using PodkladexApp.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_KontrolaProd : Form
    {
        PodkladexContext _context;

        private enum TrybPracy { Brak, Dodawanie, Edycja }
        private TrybPracy aktualnyTryb = TrybPracy.Brak;
        private int _aktualneIdKontroli = 0;
        private int _aktualneIdPomiaru = 0;

        public Form_KontrolaProd(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            this.Load += Form_KontrolaProd_Load;

            this.btn_DodajKontProd.Click += btn_DodajKontProd_Click;
            this.btn_EdytujKontProd.Click += btn_EdytujKontProd_Click;
            this.btn_Edytuj.Click += btn_Edytuj_Click;
            this.btn_KontProdPotwierdz.Click += btn_KontProdPotwierdz_Click;
            this.btn_KontProdPomiar.Click += btn_KontProdPomiar_Click;
            this.btn_PomiarProdDodaj.Click += btn_PomiarProdDodaj_Click;
            this.btn_EdytujPomiar.Click += btn_EdytujPomiar_Click;
            this.btn_UsunPomiar.Click += btn_UsunPomiar_Click;
            this.btn_ZakonczKontrole.Click += btn_ZakonczKontrole_Click;
            this.btn_Anuluj.Click += btn_Anuluj_Click;

            this.DGV_PomiaryProd.CellFormatting += DGV_PomiaryProd_CellFormatting;
        }

        private void Form_KontrolaProd_Load(object sender, EventArgs e)
        {
            OdswiezSlowniki();
            OdswiezGornaTabele();
            UstawStanPoczatkowy();
        }

        private void UstawStanPoczatkowy()
        {
            aktualnyTryb = TrybPracy.Brak;
            _aktualneIdKontroli = 0;
            _aktualneIdPomiaru = 0;

            btn_DodajKontProd.Enabled = true;
            btn_EdytujKontProd.Enabled = true;

            DGV_KontProdKontrole.Visible = false;
            DGV_KontProdKontrole.Enabled = true;
            label_ListaKontroli.Visible = false;
            btn_Edytuj.Visible = false;

            label_KontProdPrac.Visible = false;
            comboBox_KontProdPrac.Visible = false;
            comboBox_KontProdPrac.Enabled = true;
            comboBox_KontProdPrac.SelectedIndex = -1;

            label_KontProdZadP.Visible = false;
            comboBox_KontProdZadP.Visible = false;
            comboBox_KontProdZadP.Enabled = true;
            comboBox_KontProdZadP.SelectedIndex = -1;

            btn_KontProdPotwierdz.Visible = false;
            btn_KontProdPotwierdz.Enabled = true;
            btn_KontProdPomiar.Visible = false;
            btn_KontProdPomiar.Enabled = true;
            btn_Anuluj.Visible = false;

            panel_DodawaniePomiaru.Visible = false;

            textBox_KontProdRBH.Clear();
            textBox_KontProdOdpady.Clear();
            checkBox_KontrolaProdZat.Checked = false;
            textBox_PomiarProdWartosc.Clear();

            btn_PomiarProdDodaj.Text = "Dodaj pomiar";
        }

        private void PokazPolaNaglowka()
        {
            label_KontProdPrac.Visible = true;
            comboBox_KontProdPrac.Visible = true;
            label_KontProdZadP.Visible = true;
            comboBox_KontProdZadP.Visible = true;
            btn_KontProdPotwierdz.Visible = true;
            btn_Anuluj.Visible = true;
        }

        private void btn_DodajKontProd_Click(object sender, EventArgs e)
        {
            UstawStanPoczatkowy();
            aktualnyTryb = TrybPracy.Dodawanie;

            btn_DodajKontProd.Enabled = false;
            btn_EdytujKontProd.Enabled = false;

            OdswiezSlowniki();
            PokazPolaNaglowka();
            btn_KontProdPomiar.Enabled = false;
        }

        private void btn_EdytujKontProd_Click(object sender, EventArgs e)
        {
            UstawStanPoczatkowy();
            aktualnyTryb = TrybPracy.Edycja;

            btn_DodajKontProd.Enabled = false;
            btn_EdytujKontProd.Enabled = false;

            OdswiezGornaTabele();
            DGV_KontProdKontrole.Visible = true;
            label_ListaKontroli.Visible = true;
            btn_Edytuj.Visible = true;
            btn_Anuluj.Visible = true;
        }

        private void btn_Edytuj_Click(object sender, EventArgs e)
        {
            if (DGV_KontProdKontrole.CurrentRow == null)
            {
                MessageBox.Show("Najpierw zaznacz kontrolę na liście.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = (int)DGV_KontProdKontrole.CurrentRow.Cells["ID"].Value;
            var wybrana = _context.KontrolaProd.Find(id);

            if (wybrana != null)
            {
                _aktualneIdKontroli = wybrana.IdKontrolaProd;

                DGV_KontProdKontrole.Enabled = false;
                btn_Edytuj.Visible = false;

                OdswiezSlowniki();
                PokazPolaNaglowka();

                comboBox_KontProdPrac.SelectedValue = wybrana.IdPracownik;

                comboBox_KontProdZadP.SelectedValue = wybrana.IdZadanieP;
                comboBox_KontProdZadP.Enabled = false;

                textBox_KontProdRBH.Text = wybrana.Rbh?.ToString();
                textBox_KontProdOdpady.Text = wybrana.Odpady?.ToString();
                checkBox_KontrolaProdZat.Checked = wybrana.Zatwierdzone;

                btn_KontProdPomiar.Enabled = true;
                btn_KontProdPomiar.Visible = true;
            }
        }

        private void btn_KontProdPotwierdz_Click(object sender, EventArgs e)
        {
            if (comboBox_KontProdPrac.SelectedValue == null || comboBox_KontProdZadP.SelectedValue == null)
            {
                MessageBox.Show("Uzupełnij Pracownika oraz Zadanie Produkcyjne przed potwierdzeniem.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (aktualnyTryb == TrybPracy.Dodawanie)
                {
                    var nowa = new KontrolaProd
                    {
                        IdPracownik = (int)comboBox_KontProdPrac.SelectedValue,
                        IdZadanieP = (int)comboBox_KontProdZadP.SelectedValue,
                        Zatwierdzone = false
                    };
                    _context.KontrolaProd.Add(nowa);
                    _context.SaveChanges();
                    _aktualneIdKontroli = nowa.IdKontrolaProd;
                }
                else
                {
                    var edytowana = _context.KontrolaProd.Find(_aktualneIdKontroli);
                    if (edytowana != null)
                    {
                        edytowana.IdPracownik = (int)comboBox_KontProdPrac.SelectedValue;
                        _context.SaveChanges();
                    }
                }

                comboBox_KontProdPrac.Enabled = false;
                comboBox_KontProdZadP.Enabled = false;
                btn_KontProdPotwierdz.Enabled = false;

                btn_KontProdPomiar.Visible = true;
                btn_KontProdPomiar.Enabled = true;

                OdswiezGornaTabele();
                MessageBox.Show("Nagłówek zapisany. Możesz przejść do pomiarów.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void btn_KontProdPomiar_Click(object sender, EventArgs e)
        {
            panel_DodawaniePomiaru.Visible = true;
            OdswiezTabelePomiarow();
            btn_KontProdPomiar.Enabled = false;
        }

        private void btn_Anuluj_Click(object sender, EventArgs e)
        {
            UstawStanPoczatkowy();
        }

        private void btn_EdytujPomiar_Click(object sender, EventArgs e)
        {
            if (DGV_PomiaryProd.CurrentRow == null)
            {
                MessageBox.Show("Najpierw zaznacz pomiar z tabeli do edycji.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPomiaru = (int)DGV_PomiaryProd.CurrentRow.Cells["ID"].Value;
            var pomiar = _context.Pomiar.Find(idPomiaru);

            if (pomiar != null)
            {
                _aktualneIdPomiaru = pomiar.IdPomiar;
                comboBox_PomiarProdWlasc.SelectedValue = pomiar.IdWlasciwosci;
                textBox_PomiarProdWartosc.Text = pomiar.WartoscZmierzona.ToString();

                btn_PomiarProdDodaj.Text = "Zapisz zmianę";
            }
        }

        private void btn_UsunPomiar_Click(object sender, EventArgs e)
        {
            if (DGV_PomiaryProd.CurrentRow == null)
            {
                MessageBox.Show("Wybierz z listy pomiar, który chcesz usunąć.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Czy na pewno chcesz trwale usunąć ten pomiar?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int idPomiaru = (int)DGV_PomiaryProd.CurrentRow.Cells["ID"].Value;
                var pomiar = _context.Pomiar.Find(idPomiaru);

                if (pomiar != null)
                {
                    _context.Pomiar.Remove(pomiar);
                    _context.SaveChanges();

                    if (_aktualneIdPomiaru == idPomiaru)
                    {
                        _aktualneIdPomiaru = 0;
                        textBox_PomiarProdWartosc.Clear();
                        btn_PomiarProdDodaj.Text = "Dodaj pomiar";
                    }

                    OdswiezTabelePomiarow();
                }
            }
        }

        private void btn_PomiarProdDodaj_Click(object sender, EventArgs e)
        {
            if (comboBox_PomiarProdWlasc.SelectedValue == null || string.IsNullOrWhiteSpace(textBox_PomiarProdWartosc.Text)) return;

            try
            {
                decimal wartosc = decimal.Parse(textBox_PomiarProdWartosc.Text.Replace('.', ','));

                if (_aktualneIdPomiaru == 0)
                {
                    var pomiar = new Pomiar
                    {
                        IdKontrolaProd = _aktualneIdKontroli,
                        IdWlasciwosci = (int)comboBox_PomiarProdWlasc.SelectedValue,
                        WartoscZmierzona = wartosc
                    };
                    _context.Pomiar.Add(pomiar);
                }
                else
                {
                    var pomiar = _context.Pomiar.Find(_aktualneIdPomiaru);
                    if (pomiar != null)
                    {
                        pomiar.IdWlasciwosci = (int)comboBox_PomiarProdWlasc.SelectedValue;
                        pomiar.WartoscZmierzona = wartosc;
                    }
                }

                _context.SaveChanges();

                _aktualneIdPomiaru = 0;
                textBox_PomiarProdWartosc.Clear();
                btn_PomiarProdDodaj.Text = "Dodaj pomiar";

                OdswiezTabelePomiarow();
            }
            catch { MessageBox.Show("Niepoprawny format liczby.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void OdswiezTabelePomiarow()
        {
            int idZadania = (int)comboBox_KontProdZadP.SelectedValue;

            // Dynamiczne wyciąganie ID_Produktu przez relację z zadaniem
            int idProdukt = _context.Produkcja
                .Where(p => p.IdZadanieP == idZadania)
                .Select(p => p.IdNormyPNavigation.IdProdukt)
                .FirstOrDefault();

            DGV_PomiaryProd.DataSource = _context.Pomiar
                .Where(p => p.IdKontrolaProd == _aktualneIdKontroli)
                .Include(p => p.IdWlasciwosciNavigation)
                .Select(p => new
                {
                    ID = p.IdPomiar,
                    Wlasciwosc = p.IdWlasciwosciNavigation.NazwaParametru,
                    Wartosc = p.WartoscZmierzona,
                    Min = _context.ProduktWlasciwosci.Where(m => m.IdProdukt == idProdukt && m.IdWlasciwosci == p.IdWlasciwosci).Select(m => (decimal?)m.WartoscMinimalna).FirstOrDefault(),
                    Max = _context.ProduktWlasciwosci.Where(m => m.IdProdukt == idProdukt && m.IdWlasciwosci == p.IdWlasciwosci).Select(m => (decimal?)m.WartoscMaksymalna).FirstOrDefault(),
                    Status = ""
                }).ToList();
        }

        private void DGV_PomiaryProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_PomiaryProd.Columns[e.ColumnIndex].Name == "Status")
            {
                var row = DGV_PomiaryProd.Rows[e.RowIndex];
                if (row.Cells["Wartosc"].Value == null) return;
                decimal val = Convert.ToDecimal(row.Cells["Wartosc"].Value);
                var min = row.Cells["Min"].Value;
                var max = row.Cells["Max"].Value;

                if (min != null && max != null && val >= (decimal)min && val <= (decimal)max)
                {
                    e.Value = "ZGODNY";
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    e.Value = "NIEZGODNY";
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void btn_ZakonczKontrole_Click(object sender, EventArgs e)
        {
            try
            {
                var k = _context.KontrolaProd.Find(_aktualneIdKontroli);
                if (k != null)
                {
                    k.Rbh = string.IsNullOrWhiteSpace(textBox_KontProdRBH.Text) ? null : decimal.Parse(textBox_KontProdRBH.Text.Replace('.', ','));
                    k.Odpady = string.IsNullOrWhiteSpace(textBox_KontProdOdpady.Text) ? null : decimal.Parse(textBox_KontProdOdpady.Text.Replace('.', ','));
                    k.Zatwierdzone = checkBox_KontrolaProdZat.Checked;
                    _context.SaveChanges();
                    MessageBox.Show("Zapisano pomyślnie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UstawStanPoczatkowy();
                    OdswiezGornaTabele();
                }
            }
            catch { MessageBox.Show("Błąd podczas zapisywania podsumowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void OdswiezSlowniki()
        {
            comboBox_KontProdPrac.DataSource = _context.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Select(p => new { p.IdPracownik, Nazwa = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();
            comboBox_KontProdPrac.DisplayMember = "Nazwa";
            comboBox_KontProdPrac.ValueMember = "IdPracownik";
            comboBox_KontProdPrac.SelectedIndex = -1;

            var zadania = _context.ZadanieProdukcyjne
                .Include(z => z.IdMaszynaNavigation)
                .Include(z => z.Produkcja)
                    .ThenInclude(p => p.IdNormyPNavigation)
                    .ThenInclude(n => n.IdProduktNavigation)
                .Where(z => z.IdMaszynaNavigation.Nazwa.Contains("Prasa"))
                .Where(z => !z.KontrolaProd.Any() || z.KontrolaProd.Any(k => k.IdKontrolaProd == _aktualneIdKontroli))
                .ToList();

            comboBox_KontProdZadP.DataSource = zadania.Select(z => new {
                z.IdZadanieP,
                OpisZadania = "Zadanie nr " + z.IdZadanieP + " - " + z.IdMaszynaNavigation.Nazwa +
                              (z.Produkcja.Any() && z.Produkcja.FirstOrDefault().IdNormyPNavigation != null ? " - Prod: " + z.Produkcja.FirstOrDefault().IdNormyPNavigation.IdProduktNavigation.Nazwa : "") +
                              " (" + z.DataZadania.ToString("yyyy-MM-dd") + ")"
            }).ToList();
            comboBox_KontProdZadP.DisplayMember = "OpisZadania";
            comboBox_KontProdZadP.ValueMember = "IdZadanieP";
            comboBox_KontProdZadP.SelectedIndex = -1;

            comboBox_PomiarProdWlasc.DataSource = _context.Wlasciwosc.ToList();
            comboBox_PomiarProdWlasc.DisplayMember = "NazwaParametru";
            comboBox_PomiarProdWlasc.ValueMember = "IdWlasciwosci";
            comboBox_PomiarProdWlasc.SelectedIndex = -1;
        }

        private void OdswiezGornaTabele()
        {
            DGV_KontProdKontrole.DataSource = _context.KontrolaProd
                .Include(k => k.IdPracownikNavigation.IdOsobaNavigation)
                .Include(k => k.IdZadaniePNavigation.IdMaszynaNavigation)
                .Include(k => k.IdZadaniePNavigation.Produkcja)
                    .ThenInclude(p => p.IdNormyPNavigation)
                    .ThenInclude(n => n.IdProduktNavigation)
                .Where(k => k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa.Contains("Prasa"))
                .Select(k => new {
                    ID = k.IdKontrolaProd,
                    Pracownik = k.IdPracownikNavigation.IdOsobaNavigation.Imie + " " + k.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                    Zadanie = k.IdZadanieP,
                    Wyprodukowano = k.IdZadaniePNavigation.Produkcja.Any() ? (decimal?)k.IdZadaniePNavigation.Produkcja.FirstOrDefault().Wyprodukowano : null,
                    Produkt = k.IdZadaniePNavigation.Produkcja.Any() && k.IdZadaniePNavigation.Produkcja.FirstOrDefault().IdNormyPNavigation != null
                              ? k.IdZadaniePNavigation.Produkcja.FirstOrDefault().IdNormyPNavigation.IdProduktNavigation.Nazwa : "Brak danych",
                    Odpady = k.Odpady,
                    Zat = k.Zatwierdzone ? "TAK" : "NIE"
                })
                .OrderByDescending(x => x.ID).ToList();
        }
    }
}
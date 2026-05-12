using PodkladexApp.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_KontrolaMat : Form
    {
        PodkladexContext _context;

        private enum TrybPracy { Brak, Dodawanie, Edycja }
        private TrybPracy aktualnyTryb = TrybPracy.Brak;
        private int _aktualneIdKontroli = 0;
        private int _aktualneIdPomiaru = 0;

        public Form_KontrolaMat(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            this.Load += Form_KontrolaMat_Load;

            this.btn_DodajKontMat.Click += btn_DodajKontMat_Click;
            this.btn_EdytujKontMat.Click += btn_EdytujKontMat_Click;
            this.btn_Edytuj.Click += btn_Edytuj_Click;
            this.btn_KontMatPotwierdz.Click += btn_KontMatPotwierdz_Click;
            this.btn_KontMatPomiar.Click += btn_KontMatPomiar_Click;
            this.btn_PomiarMatDodaj.Click += btn_PomiarMatDodaj_Click;
            this.btn_EdytujPomiar.Click += btn_EdytujPomiar_Click;
            this.btn_UsunPomiar.Click += btn_UsunPomiar_Click;
            this.btn_ZakonczKontrole.Click += btn_ZakonczKontrole_Click;
            this.btn_Anuluj.Click += btn_Anuluj_Click;

            // Podpięcie zdarzenia kliknięcia dla checkboxa
            this.checkBox_KontrolaMatZat.Click += checkBox_KontrolaMatZat_Click;

            this.DGV_PomiaryMat.CellFormatting += DGV_PomiaryMat_CellFormatting;

            this.comboBox_KontMatZadP.SelectedIndexChanged += comboBox_KontMatZadP_SelectedIndexChanged;
        }

        private void Form_KontrolaMat_Load(object sender, EventArgs e)
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

            btn_DodajKontMat.Enabled = true;
            btn_EdytujKontMat.Enabled = true;

            DGV_KontMatKontrole.Visible = false;
            DGV_KontMatKontrole.Enabled = true;
            label_ListaKontroli.Visible = false;
            btn_Edytuj.Visible = false;

            label_KontMatPrac.Visible = false;
            comboBox_KontMatPrac.Visible = false;
            comboBox_KontMatPrac.Enabled = true;
            comboBox_KontMatPrac.SelectedIndex = -1;

            label_KontMatZadP.Visible = false;
            comboBox_KontMatZadP.Visible = false;
            comboBox_KontMatZadP.Enabled = true;
            comboBox_KontMatZadP.SelectedIndex = -1;

            label_KontMatMateral.Visible = false;
            comboBox_KontMatMaterial.Visible = false;
            comboBox_KontMatMaterial.Enabled = true;
            comboBox_KontMatMaterial.SelectedIndex = -1;

            btn_KontMatPotwierdz.Visible = false;
            btn_KontMatPotwierdz.Enabled = true;
            btn_KontMatPomiar.Visible = false;
            btn_KontMatPomiar.Enabled = true;
            btn_Anuluj.Visible = false;

            panel_DodawaniePomiaru.Visible = false;

            textBox_KontMatRBH.Clear();
            textBox_KontMatOdpady.Clear();
            textBox_KontMatOdpadySzt.Clear();
            checkBox_KontrolaMatZat.Checked = false;
            textBox_PomiarMatWartosc.Clear();
            progressBar_Postep.Value = 0;
            label_PostepInfo.Text = "";

            btn_PomiarMatDodaj.Text = "Dodaj pomiar";
        }

        private void PokazPolaNaglowka()
        {
            label_KontMatPrac.Visible = true;
            comboBox_KontMatPrac.Visible = true;
            label_KontMatZadP.Visible = true;
            comboBox_KontMatZadP.Visible = true;
            label_KontMatMateral.Visible = true;
            comboBox_KontMatMaterial.Visible = true;
            btn_KontMatPotwierdz.Visible = true;
            btn_Anuluj.Visible = true;
        }

        private void comboBox_KontMatZadP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_KontMatZadP.SelectedValue is int idZadania)
            {
                var produkcja = _context.Produkcja
                    .Include(p => p.IdNormyPNavigation)
                    .FirstOrDefault(p => p.IdZadanieP == idZadania);

                if (produkcja != null)
                {
                    int idMaterialu = produkcja.IdNormyPNavigation.IdMaterial;

                    comboBox_KontMatMaterial.DataSource = _context.Material.Where(m => m.IdMaterial == idMaterialu).ToList();
                    comboBox_KontMatMaterial.DisplayMember = "Nazwa";
                    comboBox_KontMatMaterial.ValueMember = "IdMaterial";
                    comboBox_KontMatMaterial.SelectedValue = idMaterialu;
                }
                else
                {
                    comboBox_KontMatMaterial.DataSource = _context.Material.ToList();
                    comboBox_KontMatMaterial.DisplayMember = "Nazwa";
                    comboBox_KontMatMaterial.ValueMember = "IdMaterial";
                    comboBox_KontMatMaterial.SelectedIndex = -1;
                }
            }
        }

        private void btn_DodajKontMat_Click(object sender, EventArgs e)
        {
            UstawStanPoczatkowy();
            aktualnyTryb = TrybPracy.Dodawanie;

            btn_DodajKontMat.Enabled = false;
            btn_EdytujKontMat.Enabled = false;

            OdswiezSlowniki();
            PokazPolaNaglowka();
            btn_KontMatPomiar.Enabled = false;
        }

        private void btn_EdytujKontMat_Click(object sender, EventArgs e)
        {
            UstawStanPoczatkowy();
            aktualnyTryb = TrybPracy.Edycja;

            btn_DodajKontMat.Enabled = false;
            btn_EdytujKontMat.Enabled = false;

            OdswiezGornaTabele();
            DGV_KontMatKontrole.Visible = true;
            label_ListaKontroli.Visible = true;
            btn_Edytuj.Visible = true;
            btn_Anuluj.Visible = true;
        }

        private void btn_Edytuj_Click(object sender, EventArgs e)
        {
            if (DGV_KontMatKontrole.CurrentRow == null)
            {
                MessageBox.Show("Najpierw zaznacz kontrolę na liście.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = (int)DGV_KontMatKontrole.CurrentRow.Cells["ID"].Value;
            var wybrana = _context.KontrolaMat.Find(id);

            if (wybrana != null)
            {
                _aktualneIdKontroli = wybrana.IdKontrolaMat;

                DGV_KontMatKontrole.Enabled = false;
                btn_Edytuj.Visible = false;

                OdswiezSlowniki();
                PokazPolaNaglowka();

                comboBox_KontMatPrac.SelectedValue = wybrana.IdPracownik;

                comboBox_KontMatZadP.SelectedValue = wybrana.IdZadanieP;
                comboBox_KontMatZadP.Enabled = false;

                comboBox_KontMatMaterial.SelectedValue = wybrana.IdMaterial;
                comboBox_KontMatMaterial.Enabled = false;

                textBox_KontMatRBH.Text = wybrana.Rbh?.ToString();
                textBox_KontMatOdpady.Text = wybrana.Odpady?.ToString("N2");
                checkBox_KontrolaMatZat.Checked = wybrana.Zatwierdzone;

                btn_KontMatPomiar.Enabled = true;
                btn_KontMatPomiar.Visible = true;
            }
        }

        private void btn_KontMatPotwierdz_Click(object sender, EventArgs e)
        {
            if (comboBox_KontMatPrac.SelectedValue == null || comboBox_KontMatZadP.SelectedValue == null || comboBox_KontMatMaterial.SelectedValue == null)
            {
                MessageBox.Show("Uzupełnij wszystkie dane nagłówka.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (aktualnyTryb == TrybPracy.Dodawanie)
                {
                    var nowa = new KontrolaMat
                    {
                        IdPracownik = (int)comboBox_KontMatPrac.SelectedValue,
                        IdZadanieP = (int)comboBox_KontMatZadP.SelectedValue,
                        IdMaterial = (int)comboBox_KontMatMaterial.SelectedValue,
                        Zatwierdzone = false
                    };
                    _context.KontrolaMat.Add(nowa);
                    _context.SaveChanges();
                    _aktualneIdKontroli = nowa.IdKontrolaMat;
                }
                else
                {
                    var edytowana = _context.KontrolaMat.Find(_aktualneIdKontroli);
                    if (edytowana != null)
                    {
                        edytowana.IdPracownik = (int)comboBox_KontMatPrac.SelectedValue;
                        _context.SaveChanges();
                    }
                }

                comboBox_KontMatPrac.Enabled = false;
                comboBox_KontMatZadP.Enabled = false;
                comboBox_KontMatMaterial.Enabled = false;
                btn_KontMatPotwierdz.Enabled = false;

                btn_KontMatPomiar.Visible = true;
                btn_KontMatPomiar.Enabled = true;

                OdswiezGornaTabele();
                MessageBox.Show("Nagłówek zapisany. Możesz przejść do pomiarów.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void btn_KontMatPomiar_Click(object sender, EventArgs e)
        {
            panel_DodawaniePomiaru.Visible = true;

            // Filtrujemy combobox właściwości tylko do tych, które ma materiał (bez właściwości "Masa" id=8, bo ją wyliczamy)
            var kontrola = _context.KontrolaMat.Find(_aktualneIdKontroli);
            if (kontrola != null)
            {
                var wlasciwosciMaterialu = _context.MaterialWlasciwosci
                    .Where(mw => mw.IdMaterial == kontrola.IdMaterial && mw.IdWlasciwosci != 8)
                    .Include(mw => mw.IdWlasciwosciNavigation)
                    .Select(mw => new { mw.IdWlasciwosci, mw.IdWlasciwosciNavigation.NazwaParametru })
                    .ToList();

                comboBox_PomiarMatWlasc.DataSource = wlasciwosciMaterialu;
                comboBox_PomiarMatWlasc.DisplayMember = "NazwaParametru";
                comboBox_PomiarMatWlasc.ValueMember = "IdWlasciwosci";
            }

            OdswiezTabelePomiarow();
            btn_KontMatPomiar.Enabled = false;
        }

        private void btn_Anuluj_Click(object sender, EventArgs e)
        {
            UstawStanPoczatkowy();
        }

        private void btn_EdytujPomiar_Click(object sender, EventArgs e)
        {
            if (DGV_PomiaryMat.CurrentRow == null)
            {
                MessageBox.Show("Najpierw zaznacz pomiar z tabeli do edycji.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPomiaru = (int)DGV_PomiaryMat.CurrentRow.Cells["ID"].Value;
            var pomiar = _context.PomiarMat.Find(idPomiaru);

            if (pomiar != null)
            {
                _aktualneIdPomiaru = pomiar.IdPomiarMat;
                comboBox_PomiarMatWlasc.SelectedValue = pomiar.IdWlasciwosci;
                textBox_PomiarMatWartosc.Text = pomiar.WartoscZmierzona.ToString();

                btn_PomiarMatDodaj.Text = "Zapisz zmianę";
            }
        }

        private void btn_UsunPomiar_Click(object sender, EventArgs e)
        {
            if (DGV_PomiaryMat.CurrentRow == null)
            {
                MessageBox.Show("Wybierz z listy pomiar, który chcesz usunąć.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Czy na pewno chcesz trwale usunąć ten pomiar?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int idPomiaru = (int)DGV_PomiaryMat.CurrentRow.Cells["ID"].Value;
                var pomiar = _context.PomiarMat.Find(idPomiaru);

                if (pomiar != null)
                {
                    _context.PomiarMat.Remove(pomiar);
                    _context.SaveChanges();

                    if (_aktualneIdPomiaru == idPomiaru)
                    {
                        _aktualneIdPomiaru = 0;
                        textBox_PomiarMatWartosc.Clear();
                        btn_PomiarMatDodaj.Text = "Dodaj pomiar";
                    }

                    OdswiezTabelePomiarow();
                }
            }
        }

        private void btn_PomiarMatDodaj_Click(object sender, EventArgs e)
        {
            if (comboBox_PomiarMatWlasc.SelectedValue == null || string.IsNullOrWhiteSpace(textBox_PomiarMatWartosc.Text)) return;

            try
            {
                decimal wartosc = decimal.Parse(textBox_PomiarMatWartosc.Text.Replace('.', ','));

                if (_aktualneIdPomiaru == 0)
                {
                    var pomiar = new PomiarMat
                    {
                        IdKontrolaMat = _aktualneIdKontroli,
                        IdWlasciwosci = (int)comboBox_PomiarMatWlasc.SelectedValue,
                        WartoscZmierzona = wartosc
                    };
                    _context.PomiarMat.Add(pomiar);
                }
                else
                {
                    var pomiar = _context.PomiarMat.Find(_aktualneIdPomiaru);
                    if (pomiar != null)
                    {
                        pomiar.IdWlasciwosci = (int)comboBox_PomiarMatWlasc.SelectedValue;
                        pomiar.WartoscZmierzona = wartosc;
                    }
                }

                _context.SaveChanges();

                _aktualneIdPomiaru = 0;
                textBox_PomiarMatWartosc.Clear();
                btn_PomiarMatDodaj.Text = "Dodaj pomiar";

                OdswiezTabelePomiarow();
            }
            catch { MessageBox.Show("Niepoprawny format liczby.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void OdswiezTabelePomiarow()
        {
            var kontrola = _context.KontrolaMat.Find(_aktualneIdKontroli);
            if (kontrola == null) return;

            int idMat = kontrola.IdMaterial;

            DGV_PomiaryMat.DataSource = _context.PomiarMat
                .Where(p => p.IdKontrolaMat == _aktualneIdKontroli)
                .Include(p => p.IdWlasciwosciNavigation)
                .Select(p => new
                {
                    ID = p.IdPomiarMat,
                    Wlasciwosc = p.IdWlasciwosciNavigation.NazwaParametru,
                    Wartosc = p.WartoscZmierzona,
                    Min = _context.MaterialWlasciwosci.Where(m => m.IdMaterial == idMat && m.IdWlasciwosci == p.IdWlasciwosci).Select(m => (decimal?)m.WartoscMinimalna).FirstOrDefault(),
                    Max = _context.MaterialWlasciwosci.Where(m => m.IdMaterial == idMat && m.IdWlasciwosci == p.IdWlasciwosci).Select(m => (decimal?)m.WartoscMaksymalna).FirstOrDefault(),
                    Status = ""
                }).ToList();

            if (DGV_PomiaryMat.Columns.Contains("Min")) DGV_PomiaryMat.Columns["Min"].DefaultCellStyle.Format = "N2";
            if (DGV_PomiaryMat.Columns.Contains("Max")) DGV_PomiaryMat.Columns["Max"].DefaultCellStyle.Format = "N2";
            if (DGV_PomiaryMat.Columns.Contains("Wartosc")) DGV_PomiaryMat.Columns["Wartosc"].DefaultCellStyle.Format = "N2";

            // Wywołanie przeliczania postępu i sztuk zepsutych
            PrzeliczPostepIOdpady();
        }

        // =====================================
        // NOWA METODA: PRZELICZANIE ODPADÓW I POSTĘPU
        // =====================================
        private void PrzeliczPostepIOdpady()
        {
            if (_aktualneIdKontroli == 0) return;

            var kontrola = _context.KontrolaMat
                .Include(k => k.IdZadaniePNavigation.Produkcja)
                .FirstOrDefault(k => k.IdKontrolaMat == _aktualneIdKontroli);

            if (kontrola == null) return;

            // 1. Pobranie danych do obliczeń
            decimal wyprodukowano = kontrola.IdZadaniePNavigation.Produkcja.FirstOrDefault()?.Wyprodukowano ?? 0;

            // ID_wlasciwosci 8 = Masa nominalna arkusza
            decimal masaNominalna = _context.MaterialWlasciwosci
                .Where(m => m.IdMaterial == kontrola.IdMaterial && m.IdWlasciwosci == 8)
                .Select(m => m.WartoscNominalna)
                .FirstOrDefault();

            int liczbaWymagana = 0;
            if (masaNominalna > 0)
            {
                // Zaokrąglenie do pełnych wyprodukowanych sztuk
                liczbaWymagana = (int)(wyprodukowano / masaNominalna);
            }

            // 2. Pobranie bieżących pomiarów i norm dla materiału
            var pomiary = _context.PomiarMat.Where(p => p.IdKontrolaMat == _aktualneIdKontroli).ToList();
            int liczbaWypelniona = pomiary.Count;
            int niezgodneSztuki = 0;

            var normy = _context.MaterialWlasciwosci.Where(m => m.IdMaterial == kontrola.IdMaterial).ToList();

            // 3. Sprawdzanie zgodności każdego pomiaru
            foreach (var pomiar in pomiary)
            {
                var norma = normy.FirstOrDefault(n => n.IdWlasciwosci == pomiar.IdWlasciwosci);
                if (norma != null)
                {
                    if (pomiar.WartoscZmierzona < norma.WartoscMinimalna || pomiar.WartoscZmierzona > norma.WartoscMaksymalna)
                    {
                        niezgodneSztuki++;
                    }
                }
            }

            // 4. Aktualizacja logiki Paska Postępu
            if (liczbaWymagana <= 0)
            {
                progressBar_Postep.Value = 0;
                label_PostepInfo.Text = "Brak masy nominalnej w bazie / Produkcja 0 kg";
                label_PostepInfo.ForeColor = Color.Red;
            }
            else
            {
                int zliczone = liczbaWypelniona > liczbaWymagana ? liczbaWymagana : liczbaWypelniona;
                int procent = (int)((double)zliczone / liczbaWymagana * 100);

                progressBar_Postep.Value = procent;
                label_PostepInfo.Text = $"Postęp kontroli: {zliczone} / {liczbaWymagana} arkuszy ({procent}%)";

                if (procent >= 100) label_PostepInfo.ForeColor = Color.Green;
                else label_PostepInfo.ForeColor = Color.Black;
            }

            // 5. Przeliczanie i wpisywanie odpadów (Sztuki i Kg)
            textBox_KontMatOdpadySzt.Text = niezgodneSztuki.ToString();
            decimal odpadyKgol = niezgodneSztuki * masaNominalna;
            textBox_KontMatOdpady.Text = odpadyKgol.ToString("N2");
        }

        private void DGV_PomiaryMat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_PomiaryMat.Columns[e.ColumnIndex].Name == "Status")
            {
                var row = DGV_PomiaryMat.Rows[e.RowIndex];
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
                var k = _context.KontrolaMat.Find(_aktualneIdKontroli);
                if (k != null)
                {
                    k.Rbh = string.IsNullOrWhiteSpace(textBox_KontMatRBH.Text) ? null : decimal.Parse(textBox_KontMatRBH.Text.Replace('.', ','));
                    k.Odpady = string.IsNullOrWhiteSpace(textBox_KontMatOdpady.Text) ? null : decimal.Parse(textBox_KontMatOdpady.Text.Replace('.', ','));
                    k.Zatwierdzone = checkBox_KontrolaMatZat.Checked;
                    _context.SaveChanges();
                    MessageBox.Show("Zapisano pomyślnie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UstawStanPoczatkowy();
                    OdswiezGornaTabele();
                }
            }
            catch { MessageBox.Show("Błąd podczas zapisywania podsumowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // =====================================
        // METODA BLOKUJĄCA CHECKBOX ZATWIERDZONE
        // =====================================
        private void checkBox_KontrolaMatZat_Click(object sender, EventArgs e)
        {
            if (checkBox_KontrolaMatZat.Checked && progressBar_Postep.Value < 100)
            {
                checkBox_KontrolaMatZat.Checked = false;
                MessageBox.Show("Nie można zatwierdzić kontroli, ponieważ nie wykonano wszystkich wymaganych pomiarów!",
                                "Brak kompletnych pomiarów",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void OdswiezSlowniki()
        {
            comboBox_KontMatPrac.DataSource = _context.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Select(p => new { p.IdPracownik, Nazwa = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();
            comboBox_KontMatPrac.DisplayMember = "Nazwa";
            comboBox_KontMatPrac.ValueMember = "IdPracownik";
            comboBox_KontMatPrac.SelectedIndex = -1;

            var zadania = _context.ZadanieProdukcyjne
                .Include(z => z.IdMaszynaNavigation)
                .Include(z => z.Produkcja)
                    .ThenInclude(p => p.IdNormyPNavigation)
                    .ThenInclude(n => n.IdMaterialNavigation)
                .Where(z => z.IdMaszynaNavigation.Nazwa.Contains("Gilotyna"))
                .Where(z => !z.KontrolaMat.Any() || z.KontrolaMat.Any(k => k.IdKontrolaMat == _aktualneIdKontroli))
                .ToList();

            comboBox_KontMatZadP.DataSource = zadania.Select(z => new {
                z.IdZadanieP,
                OpisZadania = "Zadanie nr " + z.IdZadanieP + " - " + z.IdMaszynaNavigation.Nazwa +
                              (z.Produkcja.Any() ? " - Mat: " + z.Produkcja.First().IdNormyPNavigation.IdMaterialNavigation.Nazwa : "") +
                              " (" + z.DataZadania.ToString("yyyy-MM-dd") + ")"
            }).ToList();
            comboBox_KontMatZadP.DisplayMember = "OpisZadania";
            comboBox_KontMatZadP.ValueMember = "IdZadanieP";
            comboBox_KontMatZadP.SelectedIndex = -1;

            int maxWidth = comboBox_KontMatZadP.Width;
            foreach (var item in comboBox_KontMatZadP.Items)
            {
                int itemWidth = TextRenderer.MeasureText(comboBox_KontMatZadP.GetItemText(item), comboBox_KontMatZadP.Font).Width;
                if (itemWidth > maxWidth)
                {
                    maxWidth = itemWidth;
                }
            }
            comboBox_KontMatZadP.DropDownWidth = maxWidth + SystemInformation.VerticalScrollBarWidth;

            comboBox_KontMatMaterial.DataSource = _context.Material.ToList();
            comboBox_KontMatMaterial.DisplayMember = "Nazwa";
            comboBox_KontMatMaterial.ValueMember = "IdMaterial";
            comboBox_KontMatMaterial.SelectedIndex = -1;

            comboBox_PomiarMatWlasc.DataSource = _context.Wlasciwosc.ToList();
            comboBox_PomiarMatWlasc.DisplayMember = "NazwaParametru";
            comboBox_PomiarMatWlasc.ValueMember = "IdWlasciwosci";
            comboBox_PomiarMatWlasc.SelectedIndex = -1;
        }

        private void OdswiezGornaTabele()
        {
            DGV_KontMatKontrole.DataSource = _context.KontrolaMat
                .Include(k => k.IdPracownikNavigation.IdOsobaNavigation)
                .Include(k => k.IdMaterialNavigation)
                .Include(k => k.IdZadaniePNavigation.IdMaszynaNavigation)
                .Include(k => k.IdZadaniePNavigation.Produkcja)
                .Where(k => k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa.Contains("Gilotyna"))
                .Select(k => new {
                    ID = k.IdKontrolaMat,
                    Pracownik = k.IdPracownikNavigation.IdOsobaNavigation.Imie + " " + k.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                    Zadanie = k.IdZadanieP,
                    Wyprodukowano = k.IdZadaniePNavigation.Produkcja.Any() ? (decimal?)k.IdZadaniePNavigation.Produkcja.FirstOrDefault().Wyprodukowano : null,
                    Material = k.IdMaterialNavigation.Nazwa,
                    Odpady = k.Odpady,
                    Zat = k.Zatwierdzone ? "TAK" : "NIE"
                })
                .OrderByDescending(x => x.ID).ToList();

            if (DGV_KontMatKontrole.Columns.Contains("ID"))
            {
                DGV_KontMatKontrole.Columns["ID"].Visible = false;
            }

            if (DGV_KontMatKontrole.Columns.Contains("Wyprodukowano"))
            {
                DGV_KontMatKontrole.Columns["Wyprodukowano"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (DGV_KontMatKontrole.Columns.Contains("Pracownik"))
            {
                DGV_KontMatKontrole.Columns["Pracownik"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (DGV_KontMatKontrole.Columns.Contains("Odpady"))
            {
                DGV_KontMatKontrole.Columns["Odpady"].DefaultCellStyle.Format = "N2";
            }
        }
    }
}
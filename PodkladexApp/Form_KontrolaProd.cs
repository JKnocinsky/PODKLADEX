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

        // Zmienne do logiki obliczeniowej
        private decimal aktualnaMasaNominalna = 0;
        private bool czyWymuszonoZatwierdzenie = false;
        private bool isProgrammaticCheck = false;

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
            this.btn_WymusZatwierdzenie.Click += btn_WymusZatwierdzenie_Click;

            // Zdarzenie dla przycisku generowania
            this.btn_GenerujPomiary.Click += btn_GenerujPomiary_Click;

            // Zdarzenia
            this.textBox_OdpadyWizualneSzt.TextChanged += textBox_OdpadyWizualneSzt_TextChanged;
            this.checkBox_KontrolaProdZat.CheckedChanged += checkBox_KontrolaProdZat_CheckedChanged;
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
            aktualnaMasaNominalna = 0;
            czyWymuszonoZatwierdzenie = false;

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
            btn_WymusZatwierdzenie.Visible = false;

            panel_DodawaniePomiaru.Visible = false;

            textBox_KontProdRBH.Clear();

            textBox_OdpadyWizualneSzt.Clear();
            textBox_OdpadyPomiarySzt.Clear();
            textBox_KontProdOdpady.Clear();
            textBox_KontProdOdpadySzt.Clear();

            if (textBox_IloscSztukGeneruj != null) textBox_IloscSztukGeneruj.Clear();

            isProgrammaticCheck = true;
            checkBox_KontrolaProdZat.Checked = false;
            isProgrammaticCheck = false;

            textBox_PomiarProdWartosc.Clear();

            btn_PomiarProdDodaj.Text = "Dodaj pomiar";

            progressBar_Postep.Value = 0;
            label_PostepInfo.Text = "Postęp kontroli: 0%";
            label_PostepInfo.ForeColor = Color.Black;
            btn_ZakonczKontrole.Enabled = false;
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

                AktualizujPostepIWage();
                PrzeliczOdpadyZeZlychPomiarow();

                if (wybrana.Odpady.HasValue && aktualnaMasaNominalna > 0)
                {
                    int totalSzt = (int)Math.Round((decimal)wybrana.Odpady / aktualnaMasaNominalna, 0);
                    int pomiarySzt = 0;
                    int.TryParse(textBox_OdpadyPomiarySzt.Text, out pomiarySzt);

                    int wizualneSzt = totalSzt - pomiarySzt;
                    if (wizualneSzt < 0) wizualneSzt = 0;

                    textBox_OdpadyWizualneSzt.Text = wizualneSzt > 0 ? wizualneSzt.ToString() : "";
                }
                else
                {
                    textBox_OdpadyWizualneSzt.Clear();
                }

                AktualizujLaczneOdpady();

                isProgrammaticCheck = true;
                checkBox_KontrolaProdZat.Checked = wybrana.Zatwierdzone;
                isProgrammaticCheck = false;

                btn_KontProdPomiar.Enabled = true;
                btn_KontProdPomiar.Visible = true;
                btn_WymusZatwierdzenie.Visible = true;
                btn_WymusZatwierdzenie.Enabled = true;
                btn_ZakonczKontrole.Enabled = true;
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
                btn_WymusZatwierdzenie.Visible = true;
                btn_WymusZatwierdzenie.Enabled = true;
                btn_ZakonczKontrole.Enabled = true;

                AktualizujPostepIWage();
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
            AktualizujPostepIWage();
            PrzeliczOdpadyZeZlychPomiarow();
            btn_KontProdPomiar.Enabled = false;
        }

        private void btn_Anuluj_Click(object sender, EventArgs e)
        {
            UstawStanPoczatkowy();
        }

        // Generator Pomiarów bez Masy (ID = 8)
        private void btn_GenerujPomiary_Click(object sender, EventArgs e)
        {
            if (_aktualneIdKontroli == 0) return;

            if (!int.TryParse(textBox_IloscSztukGeneruj.Text, out int iloscPomiarow) || iloscPomiarow <= 0)
            {
                MessageBox.Show("Wpisz poprawną liczbę pomiarów do wygenerowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idZadania = (int)comboBox_KontProdZadP.SelectedValue;
            var prodInfo = _context.Produkcja.Include(p => p.IdNormyPNavigation).FirstOrDefault(p => p.IdZadanieP == idZadania);
            int idProdukt = prodInfo?.IdNormyPNavigation?.IdProdukt ?? 0;

            if (idProdukt == 0) return;

            // Wykluczamy właściwość Masa (ID = 8) z listy wymiarów do losowania
            var normy = _context.ProduktWlasciwosci
                .Where(pw => pw.IdProdukt == idProdukt && pw.IdWlasciwosci != 8)
                .ToList();

            if (!normy.Any())
            {
                MessageBox.Show("Brak zdefiniowanych norm wymiarowych dla tego produktu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rnd = new Random();

            for (int i = 0; i < iloscPomiarow; i++)
            {
                int randomIndex = rnd.Next(normy.Count);
                var wylosowanaNorma = normy[randomIndex];

                decimal min = wylosowanaNorma.WartoscMinimalna;
                decimal max = wylosowanaNorma.WartoscMaksymalna;
                decimal rozstep = max - min;

                if (rozstep == 0) rozstep = 0.1m;

                decimal losowaneMin = min - (rozstep * 0.15m);
                decimal losowaneMax = max + (rozstep * 0.15m);

                decimal wartoscWygenerowana = losowaneMin + (decimal)rnd.NextDouble() * (losowaneMax - losowaneMin);

                wartoscWygenerowana = Math.Round(wartoscWygenerowana, 2);

                _context.Pomiar.Add(new Pomiar
                {
                    IdKontrolaProd = _aktualneIdKontroli,
                    IdWlasciwosci = wylosowanaNorma.IdWlasciwosci,
                    WartoscZmierzona = wartoscWygenerowana
                });
            }

            _context.SaveChanges();
            OdswiezTabelePomiarow();
            AktualizujPostepIWage();
            PrzeliczOdpadyZeZlychPomiarow();

            MessageBox.Show($"Pomyślnie wygenerowano {iloscPomiarow} losowych pomiarów.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (MessageBox.Show("Czy na pewno chcesz trwale usunąć ten pomiar?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    AktualizujPostepIWage();
                    PrzeliczOdpadyZeZlychPomiarow();
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
                AktualizujPostepIWage();
                PrzeliczOdpadyZeZlychPomiarow();
            }
            catch { MessageBox.Show("Niepoprawny format liczby.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void PrzeliczOdpadyZeZlychPomiarow()
        {
            if (_aktualneIdKontroli == 0 || aktualnaMasaNominalna == 0) return;

            int idZadania = (int)comboBox_KontProdZadP.SelectedValue;
            var prodInfo = _context.Produkcja.Include(p => p.IdNormyPNavigation).FirstOrDefault(p => p.IdZadanieP == idZadania);
            int idProdukt = prodInfo?.IdNormyPNavigation?.IdProdukt ?? 0;

            if (idProdukt == 0) return;

            var pomiary = _context.Pomiar.Where(p => p.IdKontrolaProd == _aktualneIdKontroli).ToList();
            var normy = _context.ProduktWlasciwosci.Where(pw => pw.IdProdukt == idProdukt).ToList();

            int liczbaZlychSztuk = 0;
            foreach (var p in pomiary)
            {
                var n = normy.FirstOrDefault(nw => nw.IdWlasciwosci == p.IdWlasciwosci);
                if (n != null && (p.WartoscZmierzona < n.WartoscMinimalna || p.WartoscZmierzona > n.WartoscMaksymalna))
                {
                    liczbaZlychSztuk++;
                }
            }

            textBox_OdpadyPomiarySzt.Text = liczbaZlychSztuk > 0 ? liczbaZlychSztuk.ToString() : "";
            AktualizujLaczneOdpady();
        }

        private void AktualizujLaczneOdpady()
        {
            if (aktualnaMasaNominalna == 0) return;

            int wizualne = 0;
            int.TryParse(textBox_OdpadyWizualneSzt.Text, out wizualne);

            int pomiary = 0;
            int.TryParse(textBox_OdpadyPomiarySzt.Text, out pomiary);

            int lacznieSzt = wizualne + pomiary;
            decimal lacznieKg = lacznieSzt * aktualnaMasaNominalna;

            textBox_KontProdOdpadySzt.Text = lacznieSzt > 0 ? lacznieSzt.ToString() : "";
            textBox_KontProdOdpady.Text = lacznieKg > 0 ? lacznieKg.ToString("N5") : "";
        }

        private void textBox_OdpadyWizualneSzt_TextChanged(object sender, EventArgs e)
        {
            AktualizujLaczneOdpady();
        }

        private void AktualizujPostepIWage()
        {
            if (_aktualneIdKontroli == 0) return;

            var kontrola = _context.KontrolaProd
                .Include(k => k.IdZadaniePNavigation.Produkcja).ThenInclude(p => p.IdNormyPNavigation)
                .FirstOrDefault(k => k.IdKontrolaProd == _aktualneIdKontroli);

            if (kontrola == null) return;

            var produkcja = kontrola.IdZadaniePNavigation.Produkcja.FirstOrDefault();
            int idProdukt = produkcja?.IdNormyPNavigation?.IdProdukt ?? 0;
            decimal wyprodukowanoKg = produkcja?.Wyprodukowano ?? 0;

            if (idProdukt > 0)
            {
                var masaNorma = _context.ProduktWlasciwosci.FirstOrDefault(pw => pw.IdProdukt == idProdukt && pw.IdWlasciwosci == 8);
                aktualnaMasaNominalna = masaNorma?.WartoscNominalna ?? 0;

                if (aktualnaMasaNominalna > 0)
                {
                    int wymaganeSztuki = (int)Math.Ceiling((wyprodukowanoKg / aktualnaMasaNominalna) * 0.10m);

                    // Zmiana przy określaniu celu z uwzględnieniem ignorowania masy
                    int liczbaParametrow = _context.ProduktWlasciwosci.Count(pw => pw.IdProdukt == idProdukt && pw.IdWlasciwosci != 8);

                    int cel = wymaganeSztuki * liczbaParametrow;
                    int zrobione = _context.Pomiar.Count(p => p.IdKontrolaProd == _aktualneIdKontroli);

                    int proc = cel > 0 ? Math.Min(100, (int)((double)zrobione / cel * 100)) : 100;
                    progressBar_Postep.Value = proc;
                    label_PostepInfo.Text = $"Postęp: {proc}% ({zrobione}/{cel} pomiarów - 10% partii)";
                    label_PostepInfo.ForeColor = Color.Black;
                }
                else
                {
                    label_PostepInfo.Text = "BŁĄD: Brak zdefiniowanej masy (ID 8) dla produktu!";
                    label_PostepInfo.ForeColor = Color.Red;
                }
            }
        }

        private void btn_WymusZatwierdzenie_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz wymusić możliwość zakończenia kontroli przed wykonaniem wszystkich wymaganych pomiarów (10% wyprodukowanej partii)?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                czyWymuszonoZatwierdzenie = true;
                btn_WymusZatwierdzenie.Enabled = false;

                isProgrammaticCheck = true;
                checkBox_KontrolaProdZat.Checked = true;
                isProgrammaticCheck = false;

                AktualizujPostepIWage();
            }
        }

        private void checkBox_KontrolaProdZat_CheckedChanged(object sender, EventArgs e)
        {
            if (isProgrammaticCheck) return;

            if (checkBox_KontrolaProdZat.Checked && progressBar_Postep.Value < 100 && !czyWymuszonoZatwierdzenie)
            {
                MessageBox.Show("Nie można zatwierdzić kontroli przed wykonaniem wszystkich wymaganych pomiarów (10% partii). Użyj przycisku wymuszenia, jeśli to konieczne.", "Brak wymaganych pomiarów", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                isProgrammaticCheck = true;
                checkBox_KontrolaProdZat.Checked = false;
                isProgrammaticCheck = false;
            }
        }

        private void OdswiezTabelePomiarow()
        {
            int idZad = (int)comboBox_KontProdZadP.SelectedValue;
            int idP = _context.Produkcja.Where(p => p.IdZadanieP == idZad).Select(p => p.IdNormyPNavigation.IdProdukt).FirstOrDefault();

            DGV_PomiaryProd.DataSource = _context.Pomiar.Where(p => p.IdKontrolaProd == _aktualneIdKontroli).Include(p => p.IdWlasciwosciNavigation)
                .Select(p => new {
                    ID = p.IdPomiar,
                    Wlasciwosc = p.IdWlasciwosciNavigation.NazwaParametru,
                    Wartosc = p.WartoscZmierzona,
                    Min = _context.ProduktWlasciwosci.Where(m => m.IdProdukt == idP && m.IdWlasciwosci == p.IdWlasciwosci).Select(m => (decimal?)m.WartoscMinimalna).FirstOrDefault(),
                    Max = _context.ProduktWlasciwosci.Where(m => m.IdProdukt == idP && m.IdWlasciwosci == p.IdWlasciwosci).Select(m => (decimal?)m.WartoscMaksymalna).FirstOrDefault(),
                    Status = ""
                }).ToList();

            if (DGV_PomiaryProd.Columns.Contains("Min")) DGV_PomiaryProd.Columns["Min"].DefaultCellStyle.Format = "N2";
            if (DGV_PomiaryProd.Columns.Contains("Max")) DGV_PomiaryProd.Columns["Max"].DefaultCellStyle.Format = "N2";
            if (DGV_PomiaryProd.Columns.Contains("Wartosc")) DGV_PomiaryProd.Columns["Wartosc"].DefaultCellStyle.Format = "N2";
        }

        private void DGV_PomiaryProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_PomiaryProd.Columns[e.ColumnIndex].Name == "Status")
            {
                var r = DGV_PomiaryProd.Rows[e.RowIndex];
                if (r.Cells["Wartosc"].Value == null) return;

                decimal v = Convert.ToDecimal(r.Cells["Wartosc"].Value);
                decimal? mi = (decimal?)r.Cells["Min"].Value;
                decimal? ma = (decimal?)r.Cells["Max"].Value;

                bool ok = mi.HasValue && ma.HasValue && v >= mi && v <= ma;
                e.Value = ok ? "ZGODNY" : "NIEZGODNY";
                r.DefaultCellStyle.BackColor = ok ? Color.LightGreen : Color.LightCoral;
            }
        }

        private void btn_ZakonczKontrole_Click(object sender, EventArgs e)
        {
            if (!checkBox_KontrolaProdZat.Checked)
            {
                var dialogResult = MessageBox.Show("Czy na pewno chcesz zapisać i zamknąć kontrolę, która NIE JEST zatwierdzona?", "Brak zatwierdzenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

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
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania podsumowania: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            var zad = _context.ZadanieProdukcyjne
                .Include(z => z.IdMaszynaNavigation)
                .Include(z => z.Produkcja).ThenInclude(p => p.IdNormyPNavigation).ThenInclude(n => n.IdProduktNavigation)
                .Where(z => z.IdMaszynaNavigation.Nazwa.Contains("Prasa"))
                .Where(z => !z.KontrolaProd.Any() || z.KontrolaProd.Any(k => k.IdKontrolaProd == _aktualneIdKontroli))
                .ToList();

            comboBox_KontProdZadP.DataSource = zad.Select(z => new {
                z.IdZadanieP,
                OpisZadania = $"Zadanie nr {z.IdZadanieP} - {z.IdMaszynaNavigation.Nazwa} ({(z.Produkcja.Any() && z.Produkcja.FirstOrDefault().IdNormyPNavigation != null ? z.Produkcja.First().IdNormyPNavigation.IdProduktNavigation.Nazwa : "Brak")}) - {z.DataZadania:yyyy-MM-dd}"
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
                .Include(k => k.IdZadaniePNavigation.Produkcja).ThenInclude(p => p.IdNormyPNavigation).ThenInclude(n => n.IdProduktNavigation)
                .Where(k => k.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa.Contains("Prasa"))
                .Select(k => new {
                    ID = k.IdKontrolaProd,
                    Pracownik = k.IdPracownikNavigation.IdOsobaNavigation.Imie + " " + k.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                    Zadanie = k.IdZadanieP,
                    Wyprodukowano = k.IdZadaniePNavigation.Produkcja.Any() ? (decimal?)k.IdZadaniePNavigation.Produkcja.FirstOrDefault().Wyprodukowano : null,
                    Produkt = k.IdZadaniePNavigation.Produkcja.Any() && k.IdZadaniePNavigation.Produkcja.FirstOrDefault().IdNormyPNavigation != null ? k.IdZadaniePNavigation.Produkcja.FirstOrDefault().IdNormyPNavigation.IdProduktNavigation.Nazwa : "Brak danych",
                    Odpady = k.Odpady,
                    Zat = k.Zatwierdzone ? "TAK" : "NIE"
                }).OrderByDescending(x => x.ID).ToList();
        }
    }
}
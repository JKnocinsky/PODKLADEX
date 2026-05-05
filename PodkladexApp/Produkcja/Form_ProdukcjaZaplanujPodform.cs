using PodkladexApp.Models;
using System.Globalization;
using PodkladexApp.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
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
    public partial class Form_ProdukcjaZaplanujPodform : Form
    {
        PodkladexContext db;
        int? selectedIdZamowienie;

        public Form_ProdukcjaZaplanujPodform(PodkladexContext db)
        {
            InitializeComponent();
            this.db = db;
            this.selectedIdZamowienie = null;

            // Podłącz obsługę zmiany daty (jeśli kontrolka istnieje) i załaduj maszyny i pracowników
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            if (dtp != null)
            {
                dtp.ValueChanged -= Dtp_Data_ValueChanged;
                dtp.ValueChanged += Dtp_Data_ValueChanged;
            }

            LoadAvailableMachines();
            LoadAvailableWorkers();

            WireMachineAndGridEvents();
        }

        // Nowy konstruktor przyjmujący IdZamowienie wybrane w rodzicu
        public Form_ProdukcjaZaplanujPodform(PodkladexContext db, int idZamowienie)
        {
            InitializeComponent();
            this.db = db;
            this.selectedIdZamowienie = idZamowienie;

            // Opcjonalnie ustaw tytuł formularza tak, by widoczne było wybrane zamówienie
            this.Text = $"Planowanie produkcji - Zamówienie {idZamowienie}";

            // Załaduj listę produktów powiązanych z wybranym zamówieniem
            LoadProductsForOrder(selectedIdZamowienie);

            // Podłącz obsługę zmiany daty (jeśli kontrolka istnieje) i załaduj maszyny i pracowników
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            if (dtp != null)
            {
                dtp.ValueChanged -= Dtp_Data_ValueChanged;
                dtp.ValueChanged += Dtp_Data_ValueChanged;
            }

            LoadAvailableMachines();
            LoadAvailableWorkers();

            WireMachineAndGridEvents();
        }



        // Publiczna właściwość do odczytu wybranego IdZamowienie (jeśli będzie potrzebna)
        public int? SelectedIdZamowienie => selectedIdZamowienie;

        // Ładuje dane ze SzczegolyZamowienia powiązane z podanym IdZamowienie do dgv_produktyZamowienie
        private void LoadProductsForOrder(int? idZam)
        {
            if (idZam == null)
            {
                // Wyczyść grid gdy brak id
                if (Controls.ContainsKey("dgv_produktyZamowienie"))
                {
                    var dgv = Controls["dgv_produktyZamowienie"] as DataGridView;
                    if (dgv != null)
                        dgv.DataSource = null;
                }
                return;
            }

            // Pobierz szczegóły zamówienia wraz z nazwą produktu i materiału (jeśli dostępne)
            // Najpierw pobieramy szczegóły zamówienia do listy (EF -> pamięć), potem pobieramy wiersze widoku obliczeń
            var detailsList = db.SzczegolyZamowienia
                .AsNoTracking()
                .Where(s => s.IdZamowienie == idZam.Value)
                .Include(s => s.IdProduktNavigation)
                .Include(s => s.IdMaterialNavigation)
                .Select(s => new
                {
                    s.IdSzczegolyZamowienia,
                    s.IdProdukt,
                    Produkt = s.IdProduktNavigation != null ? s.IdProduktNavigation.Nazwa : string.Empty,
                    IloscOriginal = s.Ilosc,
                    s.IdMaterial, // Ta kolumna zostanie ukryta
                    Material = s.IdMaterialNavigation != null ? s.IdMaterialNavigation.Nazwa : string.Empty,
                    s.Cena,       // Ta kolumna zostanie ukryta
                    s.Uwagi
                })
                .ToList();

            // Pobierz obliczenia z widoku dla tego zamówienia
            var obliczenia = db.WidokProdukcjaPlanowanieObliczenia
                .AsNoTracking()
                .Where(w => w.IdZamowienie == idZam.Value)
                .ToList();

            // Pobierz mapę nazw produktu -> IdProdukt (case-insensitive), by móc przypisać IdProdukt do wierszy widoku
            var produktMap = db.Produkt
                .AsNoTracking()
                .ToDictionary(p => p.Nazwa, p => p.IdProdukt, StringComparer.OrdinalIgnoreCase);

            // Przekształć obliczenia z widoku na mapę keyed by IdProdukt (jeśli istnieje mapowanie nazwy->Id)
            var obliczeniaByProduktId = obliczenia
                .Select(o =>
                {
                    produktMap.TryGetValue(o.NazwaProduktu ?? string.Empty, out int pid);
                    return new
                    {
                        IdProdukt = pid == 0 ? (int?)null : pid,
                        IloscZamowienia = o.IloscZamowienia,
                        SumaOdpady = o.SumaOdpady ?? 0m,
                        ZaplanowanaProdukcja = o.ZaplanowanaProdukcja ?? 0m
                    };
                })
                .Where(x => x.IdProdukt != null)
                .ToDictionary(x => x.IdProdukt!.Value, x => x);

            // Połącz dane korzystając z IdProdukt i oblicz nową wartość Ilosc = Ilosc_zamowienia + Suma_Odpady - Zaplanowana_Produkcja
            var products = detailsList
                .Select(d =>
                {
                    obliczeniaByProduktId.TryGetValue(d.IdProdukt, out var match);

                    decimal iloscZam = match != null ? match.IloscZamowienia : d.IloscOriginal;
                    decimal sumaOdpady = match?.SumaOdpady ?? 0m;
                    decimal zaplanowana = match?.ZaplanowanaProdukcja ?? 0m;

                    var iloscObliczona = iloscZam + sumaOdpady - zaplanowana;

                    return new
                    {
                        d.IdSzczegolyZamowienia,
                        d.IdProdukt,
                        Produkt = d.Produkt,
                        Ilosc = iloscObliczona,
                        d.IdMaterial,
                        Material = d.Material,
                        d.Cena,
                        d.Uwagi
                    };
                })
                .ToList();

            var dgvProdukty = this.Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            if (dgvProdukty != null)
            {
                dgvProdukty.DataSource = products;
                dgvProdukty.AutoResizeColumns();

                // --- UKRYWANIE KOLUMN ---
                if (dgvProdukty.Columns["IdMaterial"] != null)
                    dgvProdukty.Columns["IdMaterial"].Visible = false;

                if (dgvProdukty.Columns["Cena"] != null)
                    dgvProdukty.Columns["Cena"].Visible = false;

                if (dgvProdukty.Columns["IdSzczegolyZamowienia"] != null)
                    dgvProdukty.Columns["IdSzczegolyZamowienia"].Visible = false;

                if (dgvProdukty.Columns["IdProdukt"] != null)
                    dgvProdukty.Columns["IdProdukt"].Visible = false;
                // ------------------------

                // Formatowanie kolumn liczbowych (opcjonalnie dla Ilosc, Cena jest ukryta)
                var colIlosc = dgvProdukty.Columns["Ilosc"];
                if (colIlosc != null)
                {
                    colIlosc.DefaultCellStyle.Format = "N2";
                    colIlosc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        // Publiczna metoda do odświeżania listy produktów (np. jeśli rodzic zmieni wybór)
        public void RefreshProductsForSelectedOrder(int? idZam)
        {
            selectedIdZamowienie = idZam;
            LoadProductsForOrder(selectedIdZamowienie);
        }

        // Zdarzenie obsługi zmiany daty dtp_Data
        private void Dtp_Data_ValueChanged(object? sender, EventArgs e)
        {
            LoadAvailableMachines();
            LoadAvailableWorkers();
        }

        // Ładuje maszyny, które w wybranym dniu nie mają zaplanowanych zadań produkcyjnych ani obsług
        private void LoadAvailableMachines()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmb = Controls.Find("cmb_Maszyny", true).FirstOrDefault() as ComboBox;
            if (dtp == null || cmb == null)
                return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            // Maszyny, które mają zadania produkcyjne dokładnie w tej dacie
            var busyZadania = db.WidokMaszynaZadaniaProdukcyjne
                .AsNoTracking()
                .Where(w => w.DataZadania == selectedDate)
                .Select(w => w.IdMaszyna);

            // Maszyny, które mają obsługę obejmującą tę datę:
            // DataPoczatek <= selectedDate AND (DataKoniec IS NULL OR DataKoniec >= selectedDate)
            var busyObslugi = db.WidokMaszynaObslugi
                .AsNoTracking()
                .Where(o => o.DataPoczatek <= selectedDate && (o.DataKoniec == null || o.DataKoniec >= selectedDate))
                .Select(o => o.IdMaszyna);

            // Zajęte maszyny (unijne)
            var busyIds = busyZadania.Union(busyObslugi).Distinct();

            // Pobierz Id maszyn skojarzone z typem IdTyp == 1
            var allowedMaszynaIds = db.MaszynaTyp
                .AsNoTracking()
                .Where(mt => mt.IdTyp == 1)
                .Select(mt => mt.IdMaszyna)
                .Distinct();

            // Pobierz maszyny, które nie są zajęte tego dnia i są przypisane do typu 1
            var available = db.Maszyna
                .AsNoTracking()
                .Where(m => allowedMaszynaIds.Contains(m.IdMaszyna) && !busyIds.Contains(m.IdMaszyna))
                .Select(m => new { m.IdMaszyna, m.Nazwa })
                .OrderBy(m => m.Nazwa)
                .ToList();

            cmb.DisplayMember = "Nazwa";
            cmb.ValueMember = "IdMaszyna";
            cmb.DataSource = available;
            cmb.SelectedIndex = -1;
        }

        // Ładuje pracowników, którzy w dniu wybranym w dtp_Data NIE wykonują zadania produkcyjnego
        private void LoadAvailableWorkers()
        {
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmb = Controls.Find("cmb_pracownik", true).FirstOrDefault() as ComboBox;
            if (dtp == null || cmb == null)
                return;

            var selectedDate = DateOnly.FromDateTime(dtp.Value.Date);

            // Id pracowników, którzy mają zadanie produkcyjne dokładnie w tej dacie
            var busyPracownicy = db.WidokPracownikZadaniaProdukcyjne
                .AsNoTracking()
                .Where(w => w.DataZadania == selectedDate)
                .Select(w => w.IdPracownik);

            // Pobierz pracowników, którzy nie są zajęci tego dnia
            var available = db.Pracownik
                .AsNoTracking()
                .Include(p => p.IdOsobaNavigation)
                .Where(p => !busyPracownicy.Contains(p.IdPracownik))
                .Select(p => new
                {
                    p.IdPracownik,
                    FullName = (p.IdOsobaNavigation != null ? (p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko) : string.Empty)
                })
                .OrderBy(p => p.FullName)
                .ToList();

            cmb.DisplayMember = "FullName";
            cmb.ValueMember = "IdPracownik";
            cmb.DataSource = available;
            cmb.SelectedIndex = -1;
        }

        // Podłącz zdarzenia dla cmb_Maszyny i dgv_produktyZamowienie (bez duplikatów)
        private void WireMachineAndGridEvents()
        {
            var cmb = Controls.Find("cmb_Maszyny", true).FirstOrDefault() as ComboBox;
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;

            // Podłącz zdarzenia tylko jeśli nie są już podpięte
            if (dgv != null)
            {
                dgv.SelectionChanged -= Dgv_ProduktyZamowienie_SelectionChanged;
                dgv.SelectionChanged += Dgv_ProduktyZamowienie_SelectionChanged;
            }
            if (cmb != null)
            {
                cmb.SelectedIndexChanged -= Cmb_Maszyny_SelectedIndexChanged;
                cmb.SelectedIndexChanged += Cmb_Maszyny_SelectedIndexChanged;
            }

            // Podłącz obsługę zmiany wartości txt_rbh, aby dynamicznie aktualizować txt_doWyprod
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            if (txtRbh != null)
            {
                txtRbh.TextChanged -= Txt_rbh_TextChanged;
                txtRbh.TextChanged += Txt_rbh_TextChanged;

                txtRbh.KeyPress -= Txt_rbh_KeyPress;
                txtRbh.KeyPress += Txt_rbh_KeyPress;
            }

            // Podłącz zapisz
            var btn = Controls.Find("btn_zapisz", true).FirstOrDefault() as Button;
            if (btn != null)
            {
                btn.Click -= Btn_zapisz_Click;
                btn.Click += Btn_zapisz_Click;
            }
        }

        private void Cmb_Maszyny_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Intencjonalnie puste — logika związana z normą została usunięta.
        }

        private void Dgv_ProduktyZamowienie_SelectionChanged(object? sender, EventArgs e)
        {
            // Po zmianie zaznaczenia przeliczamy wartość do wyprodukowania
            RecalculateDoWyprod();
        }

        private void Txt_rbh_TextChanged(object? sender, EventArgs e)
        {
            // Gdy zmieni się RBH, przeliczamy wartość do wyprodukowania
            RecalculateDoWyprod();
        }

        /// <summary>
        /// Obsługa KeyPress dla txt_rbh — pozwala tylko cyfry, separator dziesiętny i klawisze sterujące.
        /// </summary>
        private void Txt_rbh_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Pozwól klawisze kontrolne (Backspace itp.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Separator dziesiętny aktualnej kultury (najczęściej ',' w PL)
            var decimalSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            char sepChar = decimalSep.Length > 0 ? decimalSep[0] : ',';

            var tb = sender as TextBox;
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // Pozwól tylko jeden separator dziesiętny
            if (e.KeyChar == sepChar)
            {
                if (tb != null && tb.Text.IndexOf(sepChar) == -1)
                    return;
            }

            // W przeciwnym razie zablokuj
            e.Handled = true;
        }

        /// <summary>
        /// Znajduje odpowiednią NormęProd po IdProdukt i IdMaterial (z zaznaczonego wiersza dgv)
        /// i przelicza: wynik = rbh * (Ilosc / Czas). Wynik jest wyświetlany w txt_doWyprod.
        /// Jeśli brak normy — wyświetlany jest MessageBox Yes/No. Po wybraniu Yes otwierany jest formularz dodawania normy,
        /// po zamknięciu następuje odświeżenie kontekstu i ponowna próba pobrania normy.
        /// </summary>
        private void RecalculateDoWyprod()
        {
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            var txtDo = Controls.Find("txt_doWyprod", true).FirstOrDefault() as TextBox;

            if (dgv == null || txtRbh == null || txtDo == null)
                return;

            if (dgv.SelectedRows == null || dgv.SelectedRows.Count == 0)
            {
                txtDo.Text = string.Empty;
                return;
            }

            var row = dgv.SelectedRows[0];
            if (row == null)
            {
                txtDo.Text = string.Empty;
                return;
            }

            // Spróbuj odczytać IdProdukt i IdMaterial z wiersza (kolumny są ukryte, ale dostępne)
            object valProd = null;
            object valMat = null;
            if (dgv.Columns["IdProdukt"] != null)
                valProd = row.Cells["IdProdukt"].Value;

            if (dgv.Columns["IdMaterial"] != null)
                valMat = row.Cells["IdMaterial"].Value;

            if (valProd == null || valMat == null)
            {
                txtDo.Text = string.Empty;
                return;
            }

            if (!int.TryParse(valProd.ToString(), out int idProdukt) || !int.TryParse(valMat.ToString(), out int idMaterial))
            {
                txtDo.Text = string.Empty;
                return;
            }

            // Funkcja pomocnicza: próba pobrania normy i ewentualne otwarcie formularza norm
            NormaProd? GetNorma()
            {
                return db.NormaProd
                    .AsNoTracking()
                    .FirstOrDefault(n => n.IdProdukt == idProdukt && n.IdMaterial == idMaterial);
            }

            var norma = GetNorma();

            if (norma == null)
            {
                var dialog = MessageBox.Show("Nie znaleziono normy dla wybranego produktu i materiału. Czy chcesz dodać nową normę produkcyjną?", "Brak normy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    // Otwórz formularz dodawania normy (po zamknięciu próbujemy ponownie znaleźć normę)
                    // Zakładam istnienie formularza Form_DodajNormProd(PodkladexContext, idProdukt, idMaterial)
                    var formNorma = new Form_DodajNormProd(db, idProdukt, idMaterial);
                    formNorma.ShowDialog();

                    // Odświeżenie kontekstu: wyczyszczenie change tracker i ponowne załadowanie
                    try
                    {
                        db.ChangeTracker.Clear();
                        // opcjonalnie: załaduj set jeśli chcesz żeby był śledzony
                        // db.NormaProd.Load();
                    }
                    catch
                    {
                        // jeśli kontekst nie wspiera ChangeTracker.Clear() albo wyjątek - ignorujemy
                    }

                    norma = GetNorma();
                    if (norma == null)
                    {
                        txtDo.Text = string.Empty;
                        return;
                    }
                }
                else
                {
                    txtDo.Text = string.Empty;
                    return;
                }
            }

            // Parsowanie RBH
            var style = NumberStyles.Number;
            if (!decimal.TryParse(txtRbh.Text, style, CultureInfo.CurrentCulture, out decimal rbh))
            {
                // Jeśli nie można sparsować, traktujemy jako 0
                rbh = 0m;
            }

            // Obliczenie ilosc/czas — zabezpieczenie przed dzieleniem przez zero
            decimal ratio = 0m;
            if (norma.Czas != 0m)
                ratio = norma.Ilosc / norma.Czas;

            decimal wynik = rbh * ratio;

            // Wyświetl wynik z dwoma miejscami po przecinku
            txtDo.Text = wynik.ToString("N2", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Obsługa kliknięcia btn_zapisz: tworzy nowe ZadanieProdukcyjne z wybraną maszyną, datą i IdZamowienia.
        /// Po utworzeniu zadania dodaje rekord do Produkcja:
        /// - IdPracownik pobierane z cmb_pracownik
        /// - Rbh pobierane z txt_rbh
        /// - IdNormyP pobierane z normy powiązanej z zaznaczonym produktem/materialem
        /// - Wyprodukowano i Odpady pozostawione NULL
        /// </summary>
        private void Btn_zapisz_Click(object? sender, EventArgs e)
        {
            // walidacja IdZamowienie
            if (selectedIdZamowienie == null)
            {
                MessageBox.Show("Brak powiązanego zamówienia. Nie można utworzyć zadania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cmbMasz = Controls.Find("cmb_Maszyny", true).FirstOrDefault() as ComboBox;
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            var cmbPrac = Controls.Find("cmb_pracownik", true).FirstOrDefault() as ComboBox;
            var txtRbh = Controls.Find("txt_rbh", true).FirstOrDefault() as TextBox;
            var dgv = Controls.Find("dgv_produktyZamowienie", true).FirstOrDefault() as DataGridView;

            if (cmbMasz == null || dtp == null || cmbPrac == null || txtRbh == null || dgv == null)
            {
                MessageBox.Show("Brak wymaganych kontrolek.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbMasz.SelectedValue == null)
            {
                MessageBox.Show("Proszę wybrać maszynę.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbPrac.SelectedValue == null)
            {
                MessageBox.Show("Proszę wybrać pracownika.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idMaszyna;
            int idPracownik;
            try
            {
                idMaszyna = Convert.ToInt32(cmbMasz.SelectedValue);
                idPracownik = Convert.ToInt32(cmbPrac.SelectedValue);
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy identyfikator maszyny lub pracownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Utwórz zadanie produkcyjne
            var zadanie = new ZadanieProdukcyjne
            {
                IdMaszyna = idMaszyna,
                DataZadania = DateOnly.FromDateTime(dtp.Value.Date),
                IdZamowienie = selectedIdZamowienie.Value
            };

            try
            {
                db.ZadanieProdukcyjne.Add(zadanie);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy zapisie zadania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Po zapisaniu zadania spróbuj utworzyć wpis Produkcja powiązany z zadaniem
            // Odczytaj IdProdukt i IdMaterial z zaznaczonego wiersza dgv (tak jak w RecalculateDoWyprod)
            if (dgv.SelectedRows == null || dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać produkt z listy, aby powiązać normę.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgv.SelectedRows[0];

            object valProd = null;
            object valMat = null;
            if (dgv.Columns["IdProdukt"] != null)
                valProd = row.Cells["IdProdukt"].Value;

            if (dgv.Columns["IdMaterial"] != null)
                valMat = row.Cells["IdMaterial"].Value;

            if (valProd == null || valMat == null)
            {
                MessageBox.Show("Brak informacji o produkcie lub materiale w zaznaczonym wierszu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(valProd.ToString(), out int idProdukt) || !int.TryParse(valMat.ToString(), out int idMaterial))
            {
                MessageBox.Show("Nieprawidłowe IdProdukt lub IdMaterial.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pobierz normę (świeże odczytanie)
            NormaProd? norma = null;
            try
            {
                // upewnij się, że kontekst nie trzyma starych encji
                try { db.ChangeTracker.Clear(); } catch { }
                norma = db.NormaProd.AsNoTracking().FirstOrDefault(n => n.IdProdukt == idProdukt && n.IdMaterial == idMaterial);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy pobieraniu normy: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (norma == null)
            {
                MessageBox.Show("Nie znaleziono normy powiązanej z zaznaczonym produktem i materiałem. Produkcja nie została utworzona.", "Brak normy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parsowanie RBH z txt_rbh
            var style = NumberStyles.Number;
            if (!decimal.TryParse(txtRbh.Text, style, CultureInfo.CurrentCulture, out decimal rbh))
            {
                rbh = 0m;
            }

            // Utwórz rekord Produkcja
            var produkcja = new Models.Produkcja
            {
                IdPracownik = idPracownik,
                Rbh = rbh,
                Wyprodukowano = null,
                Odpady = null,
                IdZadanieP = zadanie.IdZadanieP,
                IdNormyP = norma.IdNormaP
            };

            try
            {
                db.Produkcja.Add(produkcja);
                db.SaveChanges();

                MessageBox.Show("Zadanie produkcyjne i wpis w Produkcja zostały utworzone.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FindForm()?.Close(); // Zamknij podformularz po zapisaniu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy zapisie wpisu Produkcja: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
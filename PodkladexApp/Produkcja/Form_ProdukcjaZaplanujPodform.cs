using PodkladexApp.Models;
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

            // Podłącz obsługę zmiany daty (jeśli kontrolka istnieje) i załaduj maszyny
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            if (dtp != null)
            {
                dtp.ValueChanged -= Dtp_Data_ValueChanged;
                dtp.ValueChanged += Dtp_Data_ValueChanged;
            }

            LoadAvailableMachines();
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

            // Podłącz obsługę zmiany daty (jeśli kontrolka istnieje) i załaduj maszyny
            var dtp = Controls.Find("dtp_Data", true).FirstOrDefault() as DateTimePicker;
            if (dtp != null)
            {
                dtp.ValueChanged -= Dtp_Data_ValueChanged;
                dtp.ValueChanged += Dtp_Data_ValueChanged;
            }

            LoadAvailableMachines();
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
            var products = db.SzczegolyZamowienia
                .AsNoTracking()
                .Where(s => s.IdZamowienie == idZam.Value)
                .Include(s => s.IdProduktNavigation)
                .Include(s => s.IdMaterialNavigation)
                .Select(s => new
                {
                    s.IdSzczegolyZamowienia,
                    s.IdProdukt,
                    Produkt = s.IdProduktNavigation != null ? s.IdProduktNavigation.Nazwa : string.Empty,
                    Ilosc = s.Ilosc,
                    s.IdMaterial, // Ta kolumna zostanie ukryta
                    Material = s.IdMaterialNavigation != null ? s.IdMaterialNavigation.Nazwa : string.Empty,
                    s.Cena,       // Ta kolumna zostanie ukryta
                    s.Uwagi
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

            // Pobierz maszyny, które nie są zajęte tego dnia
            var available = db.Maszyna
                .AsNoTracking()
                .Where(m => !busyIds.Contains(m.IdMaszyna))
                .Select(m => new { m.IdMaszyna, m.Nazwa })
                .OrderBy(m => m.Nazwa)
                .ToList();

            cmb.DisplayMember = "Nazwa";
            cmb.ValueMember = "IdMaszyna";
            cmb.DataSource = available;
            cmb.SelectedIndex = -1;
        }
    }
}
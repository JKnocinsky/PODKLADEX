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
    public partial class Form_ProdukcjaOdpady : Form
    {
        PodkladexContext db;

        public Form_ProdukcjaOdpady(PodkladexContext db)
        {
            this.db = db;
            InitializeComponent();

            // Załadowanie danych przy otwarciu formularza
            this.Load += Form_ProdukcjaOdpady_Load;

            // Ustawienie okna na pełny ekran zgodnie z Twoją poprawką
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form_ProdukcjaOdpady_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Pobranie danych z widoku zestawienia efektów
            var dane = db.WidokProdukcjaZestawienieEfektow.AsNoTracking().ToList();

            dgv_efekty.DataSource = dane;

            // 1. ID zamówienia
            if (dgv_efekty.Columns["IdZamowienie"] != null)
            {
                dgv_efekty.Columns["IdZamowienie"].HeaderText = "ID zamówienia";
                dgv_efekty.Columns["IdZamowienie"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 2. Oczekiwane zużycie materiału - formatowanie do 2 miejsc po przecinku
            if (dgv_efekty.Columns["OczekiwaneZuzycieMaterialu"] != null)
            {
                dgv_efekty.Columns["OczekiwaneZuzycieMaterialu"].HeaderText = "Oczekiwane zużycie materiału";
                dgv_efekty.Columns["OczekiwaneZuzycieMaterialu"].DefaultCellStyle.Format = "N2";
                dgv_efekty.Columns["OczekiwaneZuzycieMaterialu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 3. Oczekiwana produkcja - formatowanie do 2 miejsc po przecinku
            if (dgv_efekty.Columns["OczekiwanaProdukcja"] != null)
            {
                dgv_efekty.Columns["OczekiwanaProdukcja"].HeaderText = "Oczekiwana produkcja";
                dgv_efekty.Columns["OczekiwanaProdukcja"].DefaultCellStyle.Format = "N2";
                dgv_efekty.Columns["OczekiwanaProdukcja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 4. Oczekiwane odpady - formatowanie do 2 miejsc po przecinku
            if (dgv_efekty.Columns["OczekiwaneOdpady"] != null)
            {
                dgv_efekty.Columns["OczekiwaneOdpady"].HeaderText = "Oczekiwane odpady";
                dgv_efekty.Columns["OczekiwaneOdpady"].DefaultCellStyle.Format = "N2";
                dgv_efekty.Columns["OczekiwaneOdpady"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Pozostałe kolumny (również warto sformatować dla spójności zestawienia)
            if (dgv_efekty.Columns["RealneZuzycieMaterialu"] != null)
            {
                dgv_efekty.Columns["RealneZuzycieMaterialu"].HeaderText = "Realne zużycie materiału";
                dgv_efekty.Columns["RealneZuzycieMaterialu"].DefaultCellStyle.Format = "N2";
                dgv_efekty.Columns["RealneZuzycieMaterialu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgv_efekty.Columns["RealnaProdukcja"] != null)
            {
                dgv_efekty.Columns["RealnaProdukcja"].HeaderText = "Realna produkcja";
                dgv_efekty.Columns["RealnaProdukcja"].DefaultCellStyle.Format = "N2";
                dgv_efekty.Columns["RealnaProdukcja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgv_efekty.Columns["RealneOdpady"] != null)
            {
                dgv_efekty.Columns["RealneOdpady"].HeaderText = "Realne odpady";
                dgv_efekty.Columns["RealneOdpady"].DefaultCellStyle.Format = "N2";
                dgv_efekty.Columns["RealneOdpady"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Ustawienia estetyczne
            dgv_efekty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_efekty.ReadOnly = true;
            dgv_efekty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_efekty.RowHeadersVisible = false;
            dgv_efekty.AllowUserToAddRows = false;
        }
    }
}
using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PodkladexApp
{
    public partial class Form_Efektywnosc : Form
    {
        PodkladexContext _context;

        public Form_Efektywnosc(PodkladexContext db)
        {
            InitializeComponent();
            _context = db;

            this.Load += Form_Efektywnosc_Load;
            this.comboBox_FiltrMaszyna.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            this.btn_WyczyscFiltry.Click += btn_WyczyscFiltry_Click;

            FormatujTabele();
        }

        private void Form_Efektywnosc_Load(object sender, EventArgs e)
        {
            ZaladujSlowniki();
            WyczyscFiltry();
        }

        private void FormatujTabele()
        {
            DGV_Efektywnosc.AllowUserToAddRows = false;
            DGV_Efektywnosc.AllowUserToDeleteRows = false;
            DGV_Efektywnosc.ReadOnly = true;
            DGV_Efektywnosc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Efektywnosc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ZaladujSlowniki()
        {
            comboBox_FiltrMaszyna.SelectedIndexChanged -= Filtry_SelectedIndexChanged;
            comboBox_FiltrPracownik.SelectedIndexChanged -= Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged -= Filtry_SelectedIndexChanged;

            comboBox_FiltrMaszyna.DataSource = _context.Maszyna.ToList();
            comboBox_FiltrMaszyna.DisplayMember = "Nazwa";
            comboBox_FiltrMaszyna.ValueMember = "IdMaszyna";

            comboBox_FiltrPracownik.DataSource = _context.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .Select(p => new { p.IdPracownik, Nazwa = p.IdOsobaNavigation.Imie + " " + p.IdOsobaNavigation.Nazwisko })
                .ToList();
            comboBox_FiltrPracownik.DisplayMember = "Nazwa";
            comboBox_FiltrPracownik.ValueMember = "IdPracownik";

            // Definiowanie opcji sortowania
            var opcjeSortowania = new List<string>
            {
                "Pracownik A-Z",
                "Maszyna A-Z",
                "Efektywność (od najwyższej)",
                "Efektywność (od najniższej)",
                "Największa produkcja [kg]"
            };
            comboBox_Sortowanie.DataSource = opcjeSortowania;

            comboBox_FiltrMaszyna.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            comboBox_FiltrPracownik.SelectedIndexChanged += Filtry_SelectedIndexChanged;
            comboBox_Sortowanie.SelectedIndexChanged += Filtry_SelectedIndexChanged;
        }

        private void WyczyscFiltry()
        {
            comboBox_FiltrMaszyna.SelectedIndex = -1;
            comboBox_FiltrPracownik.SelectedIndex = -1;
            comboBox_Sortowanie.SelectedIndex = 2; // Domyślnie sortuj po najwyższej efektywności
            OdswiezDane();
        }

        private void btn_WyczyscFiltry_Click(object sender, EventArgs e)
        {
            WyczyscFiltry();
        }

        private void Filtry_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdswiezDane();
        }

        private void OdswiezDane()
        {
            // Pobieranie danych z tabeli Produkcja
            var query = _context.Produkcja
                .Include(p => p.IdZadaniePNavigation.IdMaszynaNavigation)
                .Include(p => p.IdPracownikNavigation.IdOsobaNavigation)
                .AsQueryable();

            if (comboBox_FiltrMaszyna.SelectedValue is int idMaszyna)
            {
                query = query.Where(p => p.IdZadaniePNavigation.IdMaszyna == idMaszyna);
            }

            if (comboBox_FiltrPracownik.SelectedValue is int idPracownik)
            {
                query = query.Where(p => p.IdPracownik == idPracownik);
            }

            var suroweDane = query.Select(p => new
            {
                ID = p.IdProdukcja,
                Zadanie = p.IdZadanieP,
                Pracownik = p.IdPracownikNavigation.IdOsobaNavigation.Imie + " " + p.IdPracownikNavigation.IdOsobaNavigation.Nazwisko,
                Maszyna = p.IdZadaniePNavigation.IdMaszynaNavigation.Nazwa,
                Wyprodukowano_kg = p.Wyprodukowano,
                Odpady_kg = p.Odpady,
                Efektywnosc = (p.Wyprodukowano + p.Odpady) > 0
                    ? Math.Round((p.Wyprodukowano / (p.Wyprodukowano + p.Odpady)) * 100, 2)
                    : 0
            }).ToList();

            // Zastosowanie sortowania wybranego w comboBox_Sortowanie
            string wybraneSortowanie = comboBox_Sortowanie.SelectedItem?.ToString();

            var danePosortowane = suroweDane.AsEnumerable();

            switch (wybraneSortowanie)
            {
                case "Pracownik A-Z":
                    danePosortowane = suroweDane.OrderBy(x => x.Pracownik);
                    break;
                case "Maszyna A-Z":
                    danePosortowane = suroweDane.OrderBy(x => x.Maszyna);
                    break;
                case "Efektywność (od najwyższej)":
                    danePosortowane = suroweDane.OrderByDescending(x => x.Efektywnosc);
                    break;
                case "Efektywność (od najniższej)":
                    danePosortowane = suroweDane.OrderBy(x => x.Efektywnosc);
                    break;
                case "Największa produkcja [kg]":
                    danePosortowane = suroweDane.OrderByDescending(x => x.Wyprodukowano_kg);
                    break;
                default:
                    danePosortowane = suroweDane.OrderByDescending(x => x.ID);
                    break;
            }

            DGV_Efektywnosc.DataSource = danePosortowane.ToList();

            if (DGV_Efektywnosc.Columns.Count > 0)
            {
                DGV_Efektywnosc.Columns["ID"].Visible = false;
                DGV_Efektywnosc.Columns["Zadanie"].Visible = false;

                DGV_Efektywnosc.Columns["Wyprodukowano_kg"].HeaderText = "Wyprodukowano [kg]";
                DGV_Efektywnosc.Columns["Odpady_kg"].HeaderText = "Odpady [kg]";
                DGV_Efektywnosc.Columns["Efektywnosc"].HeaderText = "Efektywność [%]";
            }
        }
    }
}
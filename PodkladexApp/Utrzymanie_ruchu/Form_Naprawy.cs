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

namespace PodkladexApp
{
    public partial class Form_Naprawy : Form
    {
        PodkladexContext context;

        public Form_Naprawy(PodkladexContext context)
        {
            InitializeComponent();
            this.context = context;
            var lista = context.RodzajObslugi.ToList(); // albo Twoje źródło danych

            checkedListBox1.DataSource = lista;
            checkedListBox1.DisplayMember = "Nazwa";
            checkedListBox1.ValueMember = "IdRodzajObslugi";

            var listaMaszyn = context.Maszyna.ToList(); // Twoje źródło danych

            checkedListBox2.DataSource = listaMaszyn;
            checkedListBox2.DisplayMember = "Nazwa";        // co widać
            checkedListBox2.ValueMember = "IdMaszyna";
            FiltrujObslugi();
        }

        private void FiltrujObslugi()
        {
            // 1. Zbierz zaznaczone ID maszyn
            var maszynyIds = checkedListBox2.CheckedItems
            .Cast<Maszyna>()
            .Select(x => x.IdMaszyna)
            .ToList();

            // 2. Zbierz zaznaczone ID rodzajów obsługi
            var rodzajeIds = checkedListBox1.CheckedItems
            .Cast<RodzajObslugi>()
            .Select(x => x.IdRodzajObslugi)
            .ToList();

            // 3. Zapytanie
            var query = context.Obsluga.AsQueryable();

            if (maszynyIds.Any())
            {
                query = query.Where(o => maszynyIds.Contains(o.IdMaszyna));
            }

            if (rodzajeIds.Any())
            {
                query = query.Where(o => rodzajeIds.Contains(o.IdRodzajObslugi));
            }

            // 4. Wynik do DataGridView
            dataGridView1.DataSource = query
            .Select(o => new
            {
                o.IdObsluga,
                Maszyna = o.IdMaszynaNavigation.Nazwa,
                Rodzaj = o.IdRodzajObslugiNavigation.Nazwa,
                o.DataPoczatek,
                o.DataKoniec,
                o.Przebieg,
                o.Uwagi,

                Czesci = string.Join(", ",
                    o.CzesciPrzeglady.Select(c =>
                        c.IdCzesciNavigation.Nazwa + " (" + c.Liczba + ")"
                    )
                )
            })
            .ToList();
            dataGridView1.Columns["IdObsluga"].Visible = false;
            dataGridView1.Columns["Przebieg"].Visible = false;
            dataGridView1.Columns["DataKoniec"].HeaderText = "Data Zakończenia";
            dataGridView1.Columns["DataPoczatek"].HeaderText = "Data Rozpoczęcia";
            dataGridView1.Columns["Czesci"].HeaderText = "Użyte części";


            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Font = new Font("Segoe UI", 14);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // proporcje
            dataGridView1.Columns["Maszyna"].FillWeight = 120;
            dataGridView1.Columns["Rodzaj"].FillWeight = 120;

            dataGridView1.Columns["DataPoczatek"].FillWeight = 110;
            dataGridView1.Columns["DataKoniec"].FillWeight = 110;

            dataGridView1.Columns["Uwagi"].FillWeight = 150;

            // 🔥 NAJWAŻNIEJSZE — dużo miejsca
            dataGridView1.Columns["Czesci"].FillWeight = 300;

        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)FiltrujObslugi);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)FiltrujObslugi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
        }
    }
}

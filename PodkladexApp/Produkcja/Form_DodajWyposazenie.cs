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
    public partial class Form_DodajWyposazenie : Form
    {
        // Dodane pole i DTO dla źródła danych DataGridView
        private BindingList<ParamDto> wlasciwosciBindingList;

        PodkladexContext context;
        int btn;
        Wyposazenie wyposazenie;

        // DTO wykorzystywane jako element listy źródłowej dla DataGridView
        private class ParamDto
        {
            public string Nazwa { get; set; }
            public decimal Wartosc { get; set; }
        }

        public Form_DodajWyposazenie(PodkladexContext context, string buttonName, Wyposazenie wyposazenie)
        {
            InitializeComponent();
            this.context = context;
            cmb_wlasciwosc.DataSource = context.Wlasciwosc.Select(w => w.NazwaParametru).ToList();

            switch (buttonName)
            {
                case "btn_dodaj":
                    btn = 1;

                    // Inicjalizuj pustą listę i powiąż z DataGridView zamiast dodawać kolumny ręcznie
                    wlasciwosciBindingList = new BindingList<ParamDto>();
                    dgv_wlasciwosci.DataSource = wlasciwosciBindingList;

                    lbl_tytul.Text = "Dodaj wyposażenie";
                    break;
                case "btn_edytuj":
                    btn = 2;
                    this.wyposazenie = wyposazenie;

                    // Najpierw zbuduj listę DTO, potem ustaw ją jako DataSource
                    var lista = context.WyposazenieWlasciwosci.Where(ww => ww.IdWyposazenie == wyposazenie.IdWyposazenie)
                        .Select(ww => new ParamDto
                        {
                            Nazwa = ww.IdWlasciwosciNavigation != null ? ww.IdWlasciwosciNavigation.NazwaParametru : string.Empty,
                            Wartosc = ww.Wartosc
                        })
                        .ToList();

                    wlasciwosciBindingList = new BindingList<ParamDto>(lista);
                    dgv_wlasciwosci.DataSource = wlasciwosciBindingList;

                    txtbox_Nazwa.Text = wyposazenie.Nazwa;

                    lbl_tytul.Text = "Edytuj wyposażenie";
                    break;
                default:
                    btn = 0;
                    break;
            }
        }

        private void btn_zapiszZamknij_Click(object sender, EventArgs e)
        {
            Wyposazenie noweWyposazenie = new Wyposazenie();

            switch (btn)
            {
                case 1:
                    if (txtbox_Nazwa.Text == "" || txtbox_Nazwa.Text == null)
                    {
                        MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");

                    }
                    else if (context.Wyposazenie.Where(wyposazenie => wyposazenie.Nazwa == txtbox_Nazwa.Text).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Nazwa jest zajeta! Wpisz inna nazwę.", "Błąd");
                    }
                    else
                    {
                        noweWyposazenie.Nazwa = txtbox_Nazwa.Text;
                        noweWyposazenie.Uwagi = txtbox_Uwagi.Text;
                        context.Wyposazenie.Add(noweWyposazenie);
                        context.SaveChanges();
                        MessageBox.Show("Dodano nowe Wyposażenie!", "Dodawanie wyposażenia");

                        foreach (DataGridViewRow row in dgv_wlasciwosci.Rows)
                        {
                            if (row.IsNewRow) continue;

                            object cellWlasciwosc = null;
                            object cellWartosc = null;

                            if (dgv_wlasciwosci.Columns.Contains("colWlasciwosc"))
                                cellWlasciwosc = row.Cells["colWlasciwosc"].Value;
                            else if (dgv_wlasciwosci.Columns.Contains("Nazwa"))
                                cellWlasciwosc = row.Cells["Nazwa"].Value;

                            if (dgv_wlasciwosci.Columns.Contains("colWartosc"))
                                cellWartosc = row.Cells["colWartosc"].Value;
                            else if (dgv_wlasciwosci.Columns.Contains("Wartosc"))
                                cellWartosc = row.Cells["Wartosc"].Value;

                            if (cellWlasciwosc != null && cellWartosc != null)
                            {
                                string nazwaParametru = cellWlasciwosc.ToString();
                                if (!decimal.TryParse(cellWartosc.ToString(), out decimal wartosc)) continue;

                                var wlasciwoscEntity = context.Wlasciwosc.FirstOrDefault(w => w.NazwaParametru == nazwaParametru);
                                if (wlasciwoscEntity == null) continue;

                                var noweWlasc = new WyposazenieWlasciwosci
                                {
                                    IdWyposazenie = context.Wyposazenie.Where(wy => wy.Nazwa == txtbox_Nazwa.Text).FirstOrDefault().IdWyposazenie,
                                    IdWlasciwosci = wlasciwoscEntity.IdWlasciwosci,
                                    Wartosc = wartosc
                                };
                                context.WyposazenieWlasciwosci.Add(noweWlasc);
                                context.SaveChanges();
                            }
                        }

                        this.Close();
                    }
                    break;
                case 2:
                    if (txtbox_Nazwa.Text == "" || txtbox_Nazwa.Text == null)
                    {
                        MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");
                    }
                    else
                    {
                        // Aktualizacja głównego rekordu wyposażenia
                        wyposazenie.Nazwa = txtbox_Nazwa.Text;
                        wyposazenie.Uwagi = txtbox_Uwagi.Text;
                        context.Wyposazenie.Update(wyposazenie);

                        // Przetworzenie wierszy z dgv_wlasciwosci:
                        // - jeśli powiązanie istnieje -> aktualizuj Wartosc
                        // - jeśli brak -> dodaj nowy rekord WyposazenieWlasciwosci
                        foreach (DataGridViewRow row in dgv_wlasciwosci.Rows)
                        {
                            if (row.IsNewRow) continue;

                            object cellWlasciwosc = null;
                            object cellWartosc = null;

                            if (dgv_wlasciwosci.Columns.Contains("colWlasciwosc"))
                                cellWlasciwosc = row.Cells["colWlasciwosc"].Value;
                            else if (dgv_wlasciwosci.Columns.Contains("Nazwa"))
                                cellWlasciwosc = row.Cells["Nazwa"].Value;

                            if (dgv_wlasciwosci.Columns.Contains("colWartosc"))
                                cellWartosc = row.Cells["colWartosc"].Value;
                            else if (dgv_wlasciwosci.Columns.Contains("Wartosc"))
                                cellWartosc = row.Cells["Wartosc"].Value;

                            if (cellWlasciwosc == null || cellWartosc == null) continue;

                            string nazwaParametru = cellWlasciwosc.ToString();
                            if (!decimal.TryParse(cellWartosc.ToString(), out decimal parsedWartosc)) continue;

                            // znajdź encję właściwości
                            var wlasciwoscEntity = context.Wlasciwosc.FirstOrDefault(w => w.NazwaParametru == nazwaParametru);
                            if (wlasciwoscEntity == null) continue;

                            // sprawdź czy istnieje powiązanie WyposazenieWlasciwosci
                            var existing = context.WyposazenieWlasciwosci
                                .FirstOrDefault(ww => ww.IdWyposazenie == wyposazenie.IdWyposazenie
                                                   && ww.IdWlasciwosci == wlasciwoscEntity.IdWlasciwosci);

                            if (existing != null)
                            {
                                // aktualizuj wartość
                                existing.Wartosc = parsedWartosc;
                                context.WyposazenieWlasciwosci.Update(existing);
                            }
                            else
                            {
                                // dodaj nowe powiązanie
                                var noweWlasc = new WyposazenieWlasciwosci
                                {
                                    IdWyposazenie = wyposazenie.IdWyposazenie,
                                    IdWlasciwosci = wlasciwoscEntity.IdWlasciwosci,
                                    Wartosc = parsedWartosc
                                };
                                context.WyposazenieWlasciwosci.Add(noweWlasc);
                            }
                        }

                        // Zapisz wszystkie zmiany jednorazowo
                        context.SaveChanges();
                        MessageBox.Show("Zmieniono dane Wyposażenia!", "Edycja wyposażenia");
                    }
                    break;
            }

        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            WyposazenieWlasciwosci noweWlasc = new WyposazenieWlasciwosci();

            if (cmb_wlasciwosc.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano właściwości! Wybierz właściwość.", "Błąd");
            }
            else if (txtbox_wartosc.Text == "" || txtbox_wartosc.Text == null)
            {
                MessageBox.Show("Wartość jest pusta! Wpisz wartość.", "Błąd");
            }
            else if (!decimal.TryParse(txtbox_wartosc.Text.Trim(), out decimal parsedValue))
            {
                MessageBox.Show("Wprowadzono nieprawidłowy format wartości. Wprowadź liczbę zmiennoprzecinkową.", "Błąd");
                return;
            }
            else
            {
                // Zamiast bezpośredniego dgv.Rows.Add — dodaj do listy źródłowej i odśwież DataSource jeśli potrzeba
                if (wlasciwosciBindingList != null)
                {
                    wlasciwosciBindingList.Add(new ParamDto
                    {
                        Nazwa = cmb_wlasciwosc.SelectedItem.ToString(),
                        Wartosc = parsedValue
                    });

                    // jeśli DataGridView wcześniej nie był powiązany (np. użytkownik dodał kolumny ręcznie),
                    // przypisz BindingList jako DataSource — tu jednak konstruktor już ustawia DataSource.
                    // dgv_wlasciwosci.DataSource = wlasciwosciBindingList;
                }
                else
                {
                    // awaryjnie zachowaj dotychczasowe zachowanie
                    dgv_wlasciwosci.Rows.Add(cmb_wlasciwosc.SelectedItem.ToString(), txtbox_wartosc.Text);
                }
            }
        }

        private void dgv_wlasciwosci_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}

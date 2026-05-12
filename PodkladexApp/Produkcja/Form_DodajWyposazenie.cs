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
        private BindingList<ParamDto> wlasciwosciBindingList;

        PodkladexContext context;
        int btn;
        Wyposazenie wyposazenie;

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

            // Podpięcie zdarzenia zmiany selekcji (Zadanie 1)
            dgv_wlasciwosci.SelectionChanged += dgv_wlasciwosci_SelectionChanged;

            switch (buttonName)
            {
                case "btn_dodaj":
                    btn = 1;
                    wlasciwosciBindingList = new BindingList<ParamDto>();
                    dgv_wlasciwosci.DataSource = wlasciwosciBindingList;
                    lbl_tytul.Text = "Dodaj wyposażenie";
                    break;
                case "btn_edytuj":
                    btn = 2;
                    this.wyposazenie = wyposazenie;

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
                    txtbox_Uwagi.Text = wyposazenie.Uwagi;
                    lbl_tytul.Text = "Edytuj wyposażenie";
                    break;
                default:
                    btn = 0;
                    break;
            }
        }

        private void btn_zapiszZamknij_Click(object sender, EventArgs e)
        {
            switch (btn)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(txtbox_Nazwa.Text))
                    {
                        MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");
                    }
                    else if (context.Wyposazenie.Any(w => w.Nazwa == txtbox_Nazwa.Text))
                    {
                        MessageBox.Show("Nazwa jest zajęta! Wpisz inną nazwę.", "Błąd");
                    }
                    else
                    {
                        Wyposazenie noweWyposazenie = new Wyposazenie
                        {
                            Nazwa = txtbox_Nazwa.Text,
                            Uwagi = txtbox_Uwagi.Text
                        };
                        context.Wyposazenie.Add(noweWyposazenie);
                        context.SaveChanges();

                        foreach (var item in wlasciwosciBindingList)
                        {
                            var wlascEntity = context.Wlasciwosc.FirstOrDefault(w => w.NazwaParametru == item.Nazwa);
                            if (wlascEntity == null) continue;

                            context.WyposazenieWlasciwosci.Add(new WyposazenieWlasciwosci
                            {
                                IdWyposazenie = noweWyposazenie.IdWyposazenie,
                                IdWlasciwosci = wlascEntity.IdWlasciwosci,
                                Wartosc = item.Wartosc
                            });
                        }
                        context.SaveChanges();
                        MessageBox.Show("Dodano nowe Wyposażenie!", "Dodawanie wyposażenia");
                        this.Close();
                    }
                    break;

                case 2:
                    if (string.IsNullOrWhiteSpace(txtbox_Nazwa.Text))
                    {
                        MessageBox.Show("Nazwa jest pusta! Wpisz nazwę.", "Błąd");
                    }
                    else
                    {
                        wyposazenie.Nazwa = txtbox_Nazwa.Text;
                        wyposazenie.Uwagi = txtbox_Uwagi.Text;
                        context.Wyposazenie.Update(wyposazenie);

                        foreach (var item in wlasciwosciBindingList)
                        {
                            var wlascEntity = context.Wlasciwosc.FirstOrDefault(w => w.NazwaParametru == item.Nazwa);
                            if (wlascEntity == null) continue;

                            var existing = context.WyposazenieWlasciwosci
                                .FirstOrDefault(ww => ww.IdWyposazenie == wyposazenie.IdWyposazenie && ww.IdWlasciwosci == wlascEntity.IdWlasciwosci);

                            if (existing != null)
                            {
                                existing.Wartosc = item.Wartosc;
                                context.WyposazenieWlasciwosci.Update(existing);
                            }
                            else
                            {
                                context.WyposazenieWlasciwosci.Add(new WyposazenieWlasciwosci
                                {
                                    IdWyposazenie = wyposazenie.IdWyposazenie,
                                    IdWlasciwosci = wlascEntity.IdWlasciwosci,
                                    Wartosc = item.Wartosc
                                });
                            }
                        }
                        context.SaveChanges();
                        MessageBox.Show("Zmieniono dane Wyposażenia!", "Edycja wyposażenia");
                        this.Close();
                    }
                    break;
            }
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            if (cmb_wlasciwosc.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano właściwości!", "Błąd");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtbox_wartosc.Text))
            {
                MessageBox.Show("Wartość jest pusta!", "Błąd");
                return;
            }
            if (!decimal.TryParse(txtbox_wartosc.Text.Trim(), out decimal parsedValue))
            {
                MessageBox.Show("Nieprawidłowy format wartości.", "Błąd");
                return;
            }

            string wybranaNazwa = cmb_wlasciwosc.SelectedItem.ToString();

            // Zadanie 2: Sprawdzenie czy właściwość już jest na liście i nadpisanie
            var istniejąca = wlasciwosciBindingList.FirstOrDefault(p => p.Nazwa == wybranaNazwa);

            if (istniejąca != null)
            {
                istniejąca.Wartosc = parsedValue;
                wlasciwosciBindingList.ResetBindings(); // Odświeżenie DataGridView
            }
            else
            {
                wlasciwosciBindingList.Add(new ParamDto
                {
                    Nazwa = wybranaNazwa,
                    Wartosc = parsedValue
                });
            }

            // Opcjonalne wyczyszczenie pól po dodaniu/edycji
            txtbox_wartosc.Clear();
            cmb_wlasciwosc.SelectedIndex = -1;
        }

        private void dgv_wlasciwosci_SelectionChanged(object sender, EventArgs e)
        {
            // Zadanie 1: Wybór właściwości o tym samym Id (nazwie) i wyświetlenie wartości
            if (dgv_wlasciwosci.CurrentRow != null && dgv_wlasciwosci.CurrentRow.DataBoundItem is ParamDto selectedParam)
            {
                cmb_wlasciwosc.SelectedItem = selectedParam.Nazwa;
                txtbox_wartosc.Text = selectedParam.Wartosc.ToString();
            }
        }
    }
}
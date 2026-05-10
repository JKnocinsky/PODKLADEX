using PodkladexApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PodkladexApp.Produkcja
{
    public partial class Form_ProdukcjaPracownicy : Form
    {
        private readonly PodkladexContext db;

        public Form_ProdukcjaPracownicy(PodkladexContext context)
        {
            InitializeComponent();
            db = context;

            // Podpięcie zdarzenia zmiany daty
            dtp_data.ValueChanged += Dtp_data_ValueChanged;

            // Inicjalizacja listy przy otwarciu
            this.Load += (s, e) => OdswiezListePracownikow();
        }

        private void Dtp_data_ValueChanged(object sender, EventArgs e)
        {
            OdswiezListePracownikow();
        }

        private void OdswiezListePracownikow()
        {
            // 1. Pobieramy wybraną datę i konwertujemy na DateOnly (używany w modelach)
            DateOnly wybranaData = DateOnly.FromDateTime(dtp_data.Value);

            // 2. Zapytanie LINQ uwzględniające wszystkie 5 kryteriów
            var dostepniPracownicy = db.Pracownik
                .Include(p => p.IdOsobaNavigation)
                .AsNoTracking()
                .Where(p =>
                    // KRYTERIUM 1: Ważność umowy
                    p.Umowa.Any(u => u.DataRoz <= wybranaData && u.DataZak >= wybranaData) &&

                    // KRYTERIUM 2: Brak urlopu w tym dniu (zakładamy, że statusWniosku = true oznacza zatwierdzony)
                    !p.WniosekUrlopowy.Any(url => url.StatusWniosku == true && url.DataRozp <= wybranaData && url.DataZak >= wybranaData) &&

                    // KRYTERIUM 3: Brak zwolnienia lekarskiego
                    !p.ZwolnienieLekarskie.Any(z => z.DataPoczatek <= wybranaData && z.DataKoniec >= wybranaData) &&

                    // KRYTERIUM 4: Obowiązkowe badania (Id 1, 2 lub 3) ważne w wybranym dniu
                    p.BadanieMedyczne.Any(b =>
                        (b.IdTypBadaniaMed == 1 || b.IdTypBadaniaMed == 2 || b.IdTypBadaniaMed == 3) &&
                        (b.DataWaznosci == null || b.DataWaznosci > wybranaData)) &&

                    // KRYTERIUM 5: Szkolenia (musi mieć zestaw: [1 lub 2] ORAZ [6 lub 7])
                    p.PracownikSzkolenia.Any(s =>
                        (s.IdSzkolenia == 1 || s.IdSzkolenia == 2) &&
                        (s.DataWaznosci == null || s.DataWaznosci > wybranaData)) &&
                    p.PracownikSzkolenia.Any(s =>
                        (s.IdSzkolenia == 6 || s.IdSzkolenia == 7) &&
                        (s.DataWaznosci == null || s.DataWaznosci > wybranaData))
                )
                .Select(p => new
                {
                    ID = p.IdPracownik,
                    Imię = p.IdOsobaNavigation.Imie,
                    Nazwisko = p.IdOsobaNavigation.Nazwisko,
                    Telefon = p.IdOsobaNavigation.NrTelefonu,
                    Email = p.IdOsobaNavigation.AdresEMail
                })
                .ToList();

            // 3. Wyświetlenie wyników w DataGridView
            dgv_pracownicy.DataSource = dostepniPracownicy;

            // Opcjonalne: poprawa wyglądu grida
            if (dgv_pracownicy.Columns.Count > 0)
            {
                dgv_pracownicy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
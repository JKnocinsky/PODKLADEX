using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodkladexApp
{
    public class Pokemon
    {
        public string Nazwa {  get; set; }
        public string Rodzaj { get; set; }
        public int Numer {  get; set; }
        public string Orientacja_seksulana { get; set; }

        public string Wyznanie_religijne { get; set; }

        public string Poglądy_polityczne { get; set; }

        public string PelnaNazwa => $"{Nazwa} - {Rodzaj}";

        public Pokemon()
        {
            Nazwa = "Pikachu";
            Rodzaj = "Elektryczny";
        }
        public Pokemon(string Nazwa, string Rodzaj)
        {
            this.Nazwa = Nazwa;
            this.Rodzaj = Rodzaj;
        }
        public Pokemon(string Nazwa, string Rodzaj, string Orientacja, string wyznanie_religijne, string poglądy_polityczne)
        {
            this.Nazwa = Nazwa;
            this.Rodzaj = Rodzaj;
            this.Orientacja_seksulana = Orientacja;
            this.Wyznanie_religijne = wyznanie_religijne;
            this.Poglądy_polityczne = poglądy_polityczne;
        }

        public void Doswiadczenie()
        {

        }

        public void WydajDzwiek(string tresc)
        {
            MessageBox.Show(
                tresc,
                "Błąd",
                MessageBoxButtons.OK
            );
        }

        public void Atak_pokemona(string atak)
        {
            MessageBox.Show(atak);
        }
    }
}

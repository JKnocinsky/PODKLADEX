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

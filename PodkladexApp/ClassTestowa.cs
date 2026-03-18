using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodkladexApp
{
    public class ClassTestowa
    {
        public string Nazwa {  get; set; }
        public string Rodzaj { get; set; }
        public int Numer {  get; set; }

        public ClassTestowa(string Nazwa, string Rodzaj)
        {
            Nazwa = "Pikachu";
            Rodzaj = "Elektryczny";
        }

        public static void WydajDzwiek(string tresc)
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

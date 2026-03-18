using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodkladexApp
{
    public class ClassTestowa
    {
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

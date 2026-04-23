using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodkladexApp.Models
{
    public class PozycjaKoszyka
    {
        public int IdProduktu { get; set; }
        public string NazwaProduktu { get; set; }
        public int IdMaterialu { get; set; }
        public string NazwaMaterialu { get; set; }
        public decimal Ilosc { get; set; } // Zgodnie z SQL Szczegoly_zamowienia to INT
        public decimal Cena { get; set; }
        public string Uwagi { get; set; }
    }
}
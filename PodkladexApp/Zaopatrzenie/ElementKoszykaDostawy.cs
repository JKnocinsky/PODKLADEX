using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodkladexApp.Zaopatrzenie
{
    public class ElementKoszykaDostawy
    {
        public int IdMaterialu { get; set; }
        public string NazwaMaterialu { get; set; }
        public decimal Liczba { get; set; } // w kg lub szt.
        public decimal CenaZaKg { get; set; }
        // Właściwość wyliczana automatycznie:
        public decimal WartoscCalkowita => Liczba * CenaZaKg;
    }
}

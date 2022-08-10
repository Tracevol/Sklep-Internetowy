using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.Tablica
{
    public class ElementKoszyka
    {
        [Key]
        public int IdElementuKoszyka { get; set; }

        public string IdSesjiKoszyka { get; set; }//tu bd zapisany identyfikator przegladarki

        public int IdOgloszenia { get; set; }

        public Ogloszenia Ogloszenia { get; set; }

        public int Ilosc { get; set; }

        public decimal Cena { get; set; }

        public DateTime DataUtworzenia { get; set; }

    }
}

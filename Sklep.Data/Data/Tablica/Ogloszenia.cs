using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.Tablica
{
    public class Ogloszenia
    {
        [Key]
        public int IdOgloszenia { get; set; }

        [Required(ErrorMessage = "Kod jest wymagany")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Foto jest wymagany")]
        [Display(Name = "Zdjęcie towaru")]
        public string Foto { get; set; }
        public string Opis { get; set; }

        public int IdRodzaju { get; set; }
        public Rodzaj Rodzaj { get; set; }

        [Display(Name ="Towar promowany")]
        public bool Promocja { get; set; }

    }
}


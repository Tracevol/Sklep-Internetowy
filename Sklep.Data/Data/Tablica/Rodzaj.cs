using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.Tablica
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę rodzaju")]
        [MaxLength(20, ErrorMessage = "Nazwa rodzaju powinna zawierać max 20 znaków")]
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public List<Ogloszenia> Ogloszenia { get; set; }
    }
}

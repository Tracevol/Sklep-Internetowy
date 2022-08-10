using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.CMS
{
    public class Parametry
    {
        [Key]
        public int IdParametru { get; set; }

        [Display(Name = "Kod")]
        [Required(ErrorMessage = "Kod jest wymagany")]
        [MaxLength(20, ErrorMessage = "Kod powinien zawierać max 20 znaków")]
        public string Kod { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Wpisz nazwę odnośnika")]
        [MaxLength(20, ErrorMessage = "Nazwa powinien zawierać max 20 znaków")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Wartość jest wymagana")]
        [Display(Name = "Tytuł aktualności")]
        public string Wartosc { get; set; }

        [Required(ErrorMessage = "Opis jest wymagana")]
        [Display(Name = "Opis")]
        public string Opis { get; set; }
    }
}

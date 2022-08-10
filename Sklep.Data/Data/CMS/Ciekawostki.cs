using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.CMS
{
    public class Ciekawostki
    {
        [Key]
        public int IdCiekawostki { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł ciekawostki")]
        [MaxLength(20, ErrorMessage = "Tytuł powinien zawierać max 10 znaków")]
        [Display(Name = "Tytuł aktualności")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł aktualności")]
        [MaxLength(30, ErrorMessage = "Tytuł strony powinien zawierać max 30 znaków")]
        [Display(Name = "Tytuł aktualności")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }

        [Display(Name = "Zdjęcie")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Zdjecie { get; set; }

        [Display(Name = "Pozycja")]
        [Required(ErrorMessage = "Pozycja jest wymagana")]
        [Column(TypeName = "nvarchar(MAX)")]
        public int Pozycja { get; set; }
    }
}

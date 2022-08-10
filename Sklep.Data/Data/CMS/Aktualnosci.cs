using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.CMS
{
    public class Aktualnosci
    {
        [Key]
        public int IdStrona { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł odnośnika")]
        [MaxLength(20, ErrorMessage = "Tytuł powinien zawierać max 20 znaków")]
        [Display(Name = "Tytuł odnośnika")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł aktualności")]
        [MaxLength(30, ErrorMessage = "Tytuł strony powinien zawierać max 30 znaków")]
        [Display(Name = "Tytuł aktualności")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string TablicaOgloszen { get; set; }

        [Required(ErrorMessage = "Pozycja jest wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }
    }
}

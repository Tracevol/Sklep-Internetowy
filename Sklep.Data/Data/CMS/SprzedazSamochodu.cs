using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.CMS
{
    public class SprzedazSamochodu
    {
        [Key]
        public int IdSprzedazy { get; set; }

        [Display(Name = "Marka samochodu")]
        [Required(ErrorMessage = "Marka jest wymagana!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Marka { get; set; }

        [Display(Name = "Model samochodu")]
        [Required(ErrorMessage = "Model jest wymagany!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Model { get; set; }

        [Display(Name = "Kraj pochodzenia")]
        [Required(ErrorMessage = "Kraj pochodzenia jest wymagany!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string KrajPochodzenia { get; set; }

        [Display(Name = "Przebieg samochodu")]
        [Required(ErrorMessage = "Przebieg samochodu jest wymagany!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Przebieg { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena jest wymagana!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public decimal Cena { get; set; }

        [Display(Name = "Lokalizacja")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Lokalizacja { get; set; }

        [Display(Name = "Telefon")]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(12, ErrorMessage = "Telefon powinien zawierać max 12 znaków")]
        public string Telefon { get; set; }
    }
}

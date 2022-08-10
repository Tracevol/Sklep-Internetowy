using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Data.Data.CMS
{
    public class WynikiIndyCar
    {
        [Key]
        public int IdWyniku { get; set; }

        [Display(Name = "Pozycja")]
        [Required(ErrorMessage = "Pozycja jest wymagana!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string PozycjaKierowcy { get; set; }

        [Display(Name = "Imię i nazwisko")]
        [Required(ErrorMessage = "Imię i nazwisko kierowcy wymagane!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ImieNazwisko { get; set; }

        [Display(Name = "Zespół")]
        [Required(ErrorMessage = "Nazwa zespołu jest wymagana!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Zespol { get; set; }

        [Display(Name = "Punkty")]
        [Required(ErrorMessage = "Punkty kierowcy są wymagane!")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Punkty { get; set; }
    }
}

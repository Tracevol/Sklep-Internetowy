using Sklep.Data.Data.Tablica;

namespace Sklep.PortalWWW.Models.Sklep
{

    // Ta klasa jest bo do widoku możemy przekazać w kontrolerze, jeden obiekt. A potrzebne nam są dwa
    // Lista towarów oraz lista razem
    public class DaneDoKoszyka
    {
        public List<ElementKoszyka> ElementyKoszyka { get; set; }
        public decimal Razem { get; set; }
    }
}

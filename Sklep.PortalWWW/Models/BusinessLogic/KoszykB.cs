using Microsoft.EntityFrameworkCore;
using Sklep.Data.Data;
using Sklep.Data.Data.Tablica;

namespace Sklep.PortalWWW.Models.BusinessLogic
{
    public class KoszykB
    {
        private readonly SklepContext _context;//baza danych 

        private string idSesjiKoszyka; // identyfikator przeglądarki

        public KoszykB(SklepContext context, HttpContext httpContext)//HttpContext parametr aplikacji internetowej
        {
            _context = context;

            idSesjiKoszyka = getIdSesjiKoszyka(httpContext);
        }

        private string getIdSesjiKoszyka(HttpContext httpContext)
        {

            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)  // jeżeli nie mamy jeszcze sesji koszyka
            {
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();

        }


        public void DodajDoKoszyka(Ogloszenia ogloszenia)
        {
            //sprawdza czy w tab ElementKoszyka jest juz towar ktory jest danej przegladarki
            //var tempElementKoszyka =
            //    _context.ElementKoszyka
            //    .Where(e => e.IdSesjiKoszyka == idSesjiKoszyka && e.IdOgloszenia == ogloszenia.IdOgloszenia)
            //    .FirstOrDefault();
            var tempElementKoszyka =
                (
                    from element in _context.ElementKoszyka
                    where element.IdOgloszenia == ogloszenia.IdOgloszenia && element.IdSesjiKoszyka == idSesjiKoszyka
                    select element

                ).FirstOrDefault();

            if (tempElementKoszyka != null)//jeżeli ta przegladarka ma juz w koszyku ten towar, to przy kazdym dodarniu zwiekszamy o 1
            {
                tempElementKoszyka.Ilosc++;
            }
            else// jeżeli przegladarka w koszyku nie ma tego towaru
            {
                tempElementKoszyka = new ElementKoszyka()//dodajemy do koszyka jako element
                {
                    IdSesjiKoszyka = idSesjiKoszyka,// dodajemy go do danej przegladarki
                    IdOgloszenia = ogloszenia.IdOgloszenia,
                    Ogloszenia = _context.Ogloszenia.Find(ogloszenia.IdOgloszenia),
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now
                };
                // dodajemy do kolekcji elementów koszyka
                _context.ElementKoszyka.Add(tempElementKoszyka);//dodajemy go do lokalnej kolekcji
            }
            _context.SaveChanges();//zapisać zmiany w bazie
        }

        public async Task<List<ElementKoszyka>> GetElementykoszykaKlienta()
        {
            return await 
                _context.ElementKoszyka.Where(e => e.IdSesjiKoszyka == this.idSesjiKoszyka).Include(e => e.Ogloszenia).ToListAsync();
            //include załaduje towar przy pobieraniu0
        }

        // funkcja zwraca sumę wartości(do zapłaty) towarów danego klienta
        public async Task<decimal> GetRazem()
        {
            // wszystkie ilości * cena
            var items =
                (
                from element in _context.ElementKoszyka
                where element.IdSesjiKoszyka == this.idSesjiKoszyka
                select element.Ogloszenia.Cena * (decimal?)element.Ilosc
                );

            return await items.SumAsync() ?? 0;//jak bd pusta kolekcja zwróci 0
        }


        public void UsunKoszyk(int id)
        {

            var elementKoszyka =
                (
                from element in _context.ElementKoszyka
                where element.IdOgloszenia == id && element.IdSesjiKoszyka == idSesjiKoszyka
                select element
                ).FirstOrDefault();

            if (elementKoszyka != null)
            {
                _context.ElementKoszyka.Remove(elementKoszyka);
                _context.SaveChanges();
            }


        }
        


    }
}

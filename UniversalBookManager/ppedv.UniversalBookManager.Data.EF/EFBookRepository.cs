using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System.Linq;

namespace ppedv.UniversalBookManager.Data.EF
{
    public class EFBookRepository : EFUniversalRepository<Book>, IBookRepository
    {
        public EFBookRepository(EFContext context) : base(context){}

        public Book GetBookWithHighestPrice()
        {
            return context.Book.OrderByDescending(x => x.Price)
                               .First();
        }

        public int GetTotalAmountOfBooksInCirculation(Book b)
        {
            return context.Inventory.Where(x => x.Book.ID == b.ID)
                                    .Sum(x => x.Amount);
        }
    }
}

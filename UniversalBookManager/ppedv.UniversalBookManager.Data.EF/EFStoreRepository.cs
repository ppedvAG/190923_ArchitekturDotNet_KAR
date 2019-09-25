using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.UniversalBookManager.Data.EF
{
    public class EFStoreRepository : EFUniversalRepository<Store>, IStoreRepository
    {
        public EFStoreRepository(EFContext context) : base(context){}

        public IEnumerable<Store> GetStoresWithBookInInventory(Book b)
        {
            var allInventoryEntriesWithBook = context.Inventory.Where(x => x.Book.ID == b.ID)
                                                               .Select(x => x.ID) // Inventory-ID
                                                               .ToArray(); // Alle Inventory-ID-nummern wo das vorkommt

            return context.Store.Where(x => allInventoryEntriesWithBook.Any(inv => inv == x.ID))
                                .ToArray();
        }

        public Store GetStoreWithHighestInventoryValue()
        {
            return context.Store
                          .OrderByDescending(x => x.Inventory.Sum(inv => inv.Amount * inv.Book.Price))
                          .First();
        }

        public Store GetStoreWithMostBooksInInventory()
        {
            return context.Store
                          .OrderByDescending(x => x.Inventory.Sum(inv => inv.Amount))
                          .First();
        }
    }
}

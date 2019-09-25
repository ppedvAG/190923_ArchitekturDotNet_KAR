using System.Collections.Generic;

namespace ppedv.UniversalBookManager.Domain.Interfaces
{
    public interface IStoreRepository : IUniversalRepository<Store>
    {
        Store GetStoreWithHighestInventoryValue();
        Store GetStoreWithMostBooksInInventory();
        IEnumerable<Store> GetStoresWithBookInInventory(Book b);
    }
}

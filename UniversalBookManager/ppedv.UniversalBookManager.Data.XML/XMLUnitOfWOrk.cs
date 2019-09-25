using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.UniversalBookManager.Data.XML
{
    public class XMLUnitOfWork : IUnitOfWork
    {
        public IBookRepository BookRepository => throw new NotImplementedException();

        public IStoreRepository StoreRepository => throw new NotImplementedException();

        public IUniversalRepository<T> GetRepository<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

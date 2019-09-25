using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.UniversalBookManager.Data.XML
{
    public class XMLUnitOfWork : IUnitOfWork
    {
        public Type[] SupportedTypes => new Type[] { typeof(Book) };
        public IBookRepository BookRepository => new XMLBookRepository();

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

using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.UniversalBookManager.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Type[] SupportedTypes { get; }

        // Spezial:
        IBookRepository BookRepository { get; }
        IStoreRepository StoreRepository { get; }

        // Repository-Factory:
        IUniversalRepository<T> GetRepository<T>() where T : Entity;

        void Save();
    }
}

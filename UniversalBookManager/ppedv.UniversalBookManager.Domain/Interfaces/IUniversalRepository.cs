using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.UniversalBookManager.Domain.Interfaces
{
    // Standardrepository mit den Features, die jeder Datentyp zumindest können muss
    public interface IUniversalRepository<T> where T : Entity
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetByID(int ID);
        IEnumerable<T> GetAll();
        IQueryable<T> Query(); // <--- für LINQ
    }
}

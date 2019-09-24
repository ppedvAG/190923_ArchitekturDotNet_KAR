using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.UniversalBookManager.Domain.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T item) where T : Entity; // == nur unsere eigenen Datentypen
        void Update<T>(T item) where T : Entity;
        void Delete<T>(T item) where T : Entity;
        T GetByID<T>(int ID) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;
        void Save();
    }
}

using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.UniversalBookManager.Data.EF
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context)
        {
            this.context = context;
        }
        private readonly EFContext context;

        public void Add<T>(T item) where T : Entity
        {
            context.Set<T>().Add(item); // Findet das richtige DBSet in der Klasse EFContext
        }

        public void Delete<T>(T item) where T : Entity
        {
            try
            {
                context.Set<T>().Remove(item);
            }
            catch (Exception ex)
            {

            }
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList(); // using System.Linq;
        }

        public T GetByID<T>(int ID) where T : Entity
        {
            return context.Set<T>().Find(ID);
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }


        public void Update<T>(T item) where T : Entity
        {
            T loadedItem = GetByID<T>(item.ID); // ELement neu aus der DB holen
            if (loadedItem != null)
            {
                // Wenn es noch existiert -> Update
                context.Entry(loadedItem).CurrentValues.SetValues(item);
                // Setzt die Werte von dem frisch geladenen DB-Item auf die Werte des Elements aus dem Parameter
            }
        }
    }
}

using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.UniversalBookManager.Data.EF
{
    public class EFUniversalRepository<T> : IUniversalRepository<T> where T : Entity
    {
        public EFUniversalRepository(EFContext context)
        {
            this.context = context;
        }
        protected readonly EFContext context;


        public void Add(T item)
        {
            context.Set<T>().Add(item); // Findet das richtige DBSet in der Klasse EFContext
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList(); // using System.Linq;
        }

        public T GetByID(int ID)
        {
            return context.Set<T>().Find(ID);
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public void Update(T item)
        {
            T loadedItem = GetByID(item.ID); // ELement neu aus der DB holen
            if (loadedItem != null)
            {
                // Wenn es noch existiert -> Update
                context.Entry(loadedItem).CurrentValues.SetValues(item);
                // Setzt die Werte von dem frisch geladenen DB-Item auf die Werte des Elements aus dem Parameter
            }
        }
    }


    public class EFUnitOfWork : IUnitOfWork
    {
        public Type[] SupportedTypes => new Type[] { typeof(Store), typeof(Inventory) };
        public EFUnitOfWork() : this(new EFContext()) { } // UnitOfWork erstellt die Connection selbst
        public EFUnitOfWork(EFContext context) // ConnectionString kommt vom UI
        {
            this.context = context;
        }
        protected readonly EFContext context;

        // Variante 1) Immer ein neues Repository zurückgeben
        public IBookRepository BookRepository => new EFBookRepository(context);

        // Variante 2) Singleton
        private IStoreRepository storeRepository;
        public IStoreRepository StoreRepository
        {
            get
            {
                // ToDo: Lock für Threadsicherheit
                if(storeRepository == null)
                {
                    storeRepository = new EFStoreRepository(context);
                }
                return storeRepository;
            }
        }

        // Variante 3) Automatisch generieren
        public IUniversalRepository<T> GetRepository<T>() where T : Entity
        {
            // Generator, der für jeden Datentyp ein neues Universalrepository zurückliefert

            // Variante "leicht":
            // return new EFUniversalRepository<T>(context); // T -> Inventory

            // Variante "schwer":
            // ToDo: Switch bzw is-Operator
            // ToDo: Cache für den Else-Fall
            // ToDo: IoC-Container nehmen (Autofac,Unity,CastleWindsor,SimpleIoC...)
            if(typeof(T) == typeof(Book))
            {
                return  (IUniversalRepository<T>)BookRepository;
            }
            else if (typeof(T) == typeof(Store))
            {
                return (IUniversalRepository<T>)StoreRepository;
            }
            else
                return new EFUniversalRepository<T>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

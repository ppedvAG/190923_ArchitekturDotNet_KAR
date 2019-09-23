using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspektorientiertes_Programmieren_Demo
{
    // Vergleich: Dekorator (brauche Parent...)
    public class LoggerRepository : IRepository
    {
        public LoggerRepository(IRepository parent)
        {
            this.parent = parent;
        }
        private readonly IRepository parent;

        private void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: {message}");
            Console.ResetColor();
        }



        public void Delete<T>(T item)
        {
            Log("Delete wird gestartet");
            parent.Delete(item);
            Log("Delete wird beendet");
        }

        public T GetByID<T>(int ID)
        {
            Log("GetByID mit der ID" + ID);
            var result = parent.GetByID<T>(ID);
            Log("GetByID beendet");

            return result;
        }

        public void Insert<T>(T item)
        {
            Log("Insert wird gestartet");
            parent.Insert(item);
            Log("Insert wird beendet");
        }

        public void Save()
        {
            Log("Save wird gestartet");
            parent.Save();
            Log("Save wird beendet");
        }

        public void Update<T>(T item)
        {
            Log("Update wird gestartet");
            parent.Update(item);
            Log("Update wird beendet");
        }
    }
}

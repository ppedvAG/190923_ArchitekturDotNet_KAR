using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspektorientiertes_Programmieren_Demo
{
    // Vergleich: Pizza (Root-Element)
    public class PersonenRepository : IRepository
    {
        // Echte DB-Befehle, hier nur Simulation mit der Konsole
        public void Insert<T>(T item)
        {
            Console.WriteLine($"Füge Element hinzu: {item}");
        }

        public void Delete<T>(T item)
        {
            Console.WriteLine($"Lösche Element : {item}");
        }

        public T GetByID<T>(int ID)
        {
            Console.WriteLine($"Gebe Element mit der ID: {ID} zurück");
            return default;
        }

        public void Save()
        {
            Console.WriteLine($"Speichere DB");
        }

        public void Update<T>(T item)
        {
            Console.WriteLine($"Update für Element: {item}");
        }
    }
}

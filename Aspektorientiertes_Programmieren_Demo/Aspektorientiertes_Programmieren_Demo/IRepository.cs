using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspektorientiertes_Programmieren_Demo
{
    // Vergleich: IComponent -> Basisfeatures, die jeder können muss
    public interface IRepository
    {
        void Insert<T>(T item);
        void Delete<T>(T item);
        void Update<T>(T item);
        T GetByID<T>(int ID);
        void Save(); // Alles Speichern
    }
}

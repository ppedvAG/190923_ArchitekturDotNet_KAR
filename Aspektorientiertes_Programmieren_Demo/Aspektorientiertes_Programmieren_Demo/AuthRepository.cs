using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspektorientiertes_Programmieren_Demo
{
    public enum User { ReadOnlyUser,RegularUser,Admin}
    public class AuthRepository : IRepository
    {
        public AuthRepository(IRepository parent, User currentUser)
        {
            this.parent = parent;
            this.currentUser = currentUser;
        }
        private readonly IRepository parent;
        private readonly User currentUser;

        private void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Delete<T>(T item)
        {
            if (currentUser == User.ReadOnlyUser || currentUser == User.RegularUser)
            {
                Log("Delete-Operation darf nur vom Admin ausgeführt werden !");
                return;
            }
            else
                parent.Delete(item);
        }

        public T GetByID<T>(int ID)
        {
            return parent.GetByID<T>(ID);
        }

        public void Insert<T>(T item)
        {
            if(currentUser == User.ReadOnlyUser)
            {
                Log("Insert-Operation darf nur vom Admin und RegualUser ausgeführt werden !");
                return;
            }
            parent.Insert(item);
        }

        public void Save()
        {
            if (currentUser == User.ReadOnlyUser)
            {
                Log("Save-Operation darf nur vom Admin und RegualUser ausgeführt werden !");
                return;
            }
            parent.Save();
        }

        public void Update<T>(T item)
        {
            if (currentUser == User.ReadOnlyUser)
            {
                Log("Update-Operation darf nur vom Admin und RegualUser ausgeführt werden !");
                return;
            }
            parent.Update(item);
        }
    }
}

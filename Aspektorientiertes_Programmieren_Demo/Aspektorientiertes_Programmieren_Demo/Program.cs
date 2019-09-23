using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspektorientiertes_Programmieren_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Anwendungsfall: Dekorator
            // Situation:
            // Datenbank, die mit Daten arbeitet
            // --> Repository (Features wie Add(), Update(), Delete()...)

            // Optionale Features/Aspekte, die man jederzeit hinzufügen kann
            // Logger, Auth-System

            var repo = new AuthRepository(new LoggerRepository(new PersonenRepository()),User.ReadOnlyUser);
            // var repo2 = new LoggerRepository(new FahrzeugRepo());
            // var repo3 = new LoggerRepository(new HausRepo());

            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100, ID = 42 };

            repo.Insert(p1);       // Simulation, dass die Person in die Datenbank eingetragen
            repo.Update(p1);
            repo.Delete(p1);
            var result = repo.GetByID<Person>(12345);
            repo.Save();


            // Variante mit Builder:
            // var repo = new PersonenRepo.Build()
            //                            .WithLogger()
            //                            .WithAuth(User.Admin)
            //                            .Create();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}

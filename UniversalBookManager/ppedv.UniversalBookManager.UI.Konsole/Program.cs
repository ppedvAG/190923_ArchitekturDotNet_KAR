using ppedv.UniversalBookManager.Data.EF;
using ppedv.UniversalBookManager.Domain.Interfaces;
using ppedv.UniversalBookManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.UniversalBookManager.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = new Core(new EFRepository(new EFContext()));

            // 2) Testdaten generieren, wenn keine Testdaten existieren
            if(core.GetAllBooks().Length == 0) // nicht besonders perfomant ;)
                core.GenerateTestData();

            foreach (var book in core.GetAllBooks())
            {
                Console.WriteLine($"{book.Author}: {book.Title}, Preis: {book.Price}");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}

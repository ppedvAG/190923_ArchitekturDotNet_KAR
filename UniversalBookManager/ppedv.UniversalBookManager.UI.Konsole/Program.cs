using ppedv.UniversalBookManager.Data.EF;
using ppedv.UniversalBookManager.Data.XML;
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
            Core core = new Core(new XMLUnitOfWork());
            core.GenerateTestDataForXML();

            foreach (var book in core.GetAllBooks())
            {
                Console.WriteLine($"{book.Author}: {book.Title}, Preis: {book.Price}");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}

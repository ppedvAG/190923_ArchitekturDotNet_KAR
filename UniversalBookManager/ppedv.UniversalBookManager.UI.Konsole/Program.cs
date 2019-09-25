using ppedv.UniversalBookManager.Data.EF;
using ppedv.UniversalBookManager.Data.XML;
using ppedv.UniversalBookManager.Domain;
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
        static void Main()
        {
            Core core = new Core(new XMLUnitOfWork(), new EFUnitOfWork());
            core.GenerateTestDataForXML();

            // Logik auf XML
            foreach (var book in core.GetAllBooks())
            {
                Console.WriteLine($"{book.Author}: {book.Title}, Preis: {book.Price}");
            }

            // Logik auf EF
            Console.WriteLine("-----");
            var result = core.GetUnitOfWorkFor<Store>().StoreRepository.GetStoreWithHighestInventoryValue();
            Console.WriteLine(result.Name);
            Console.WriteLine(result.Address);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}

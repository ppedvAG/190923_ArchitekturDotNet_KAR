using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Konsolenprogramm demo = new Konsolenprogramm();

            // demo mit den richtigen Daten automatisch füllen lassen

            DirectoryCatalog catalog = new DirectoryCatalog(".");
            CompositionContainer container = new CompositionContainer(catalog);

            container.ComposeParts(demo);

            demo.WichtigeKomponente[0].MachEtwas();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    class Konsolenprogramm
    {
        [ImportMany(typeof(IContract))]
        public IContract[] WichtigeKomponente { get; set; }
    }
}

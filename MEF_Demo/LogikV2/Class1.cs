using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogikV2
{
    [Export(typeof(IContract))]  // -> Import auf Interface
    public class MeinNeuerVertragMitMehrBeeeeeep : IContract
    {
        public string MeinWert { get; set; }

        public void MachEtwas()
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.WriteLine("Implementierung aus dem Projekt: Logik V2");
        }
    }
}

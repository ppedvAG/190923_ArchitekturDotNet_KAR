using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition; // => MEF
namespace Logik
{
    [Export(typeof(IContract))]  // -> Import auf Interface
    [Export("MeinVertragsname")] // -> Import auf Object
    public class Vertrag : IContract
    {
        public string MeinWert { get; set; }

        public void MachEtwas()
        {
            Console.Beep();
            Console.Beep();
            Console.WriteLine("Implementierung aus dem Projekt: Logik");
        }
    }
}

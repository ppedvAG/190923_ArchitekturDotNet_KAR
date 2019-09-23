using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Composite_Demo
{
    class Einzelaufgabe
    {
        public string Beschreibung { get; set; }
        public bool IstErledigt { get; set; }
        public void AufgabeAbarbeiten()
        {
            if (IstErledigt == false)
            {
                Thread.Sleep(1000);
                IstErledigt = true;
            }
        }
    }

    class Aufgabenliste
    {
        public List<Einzelaufgabe> Einzelaufgabenliste { get; set; }
        public void AufgabeHinzufügen(Einzelaufgabe aufgabe)
        {
            // ToDo: nur hinzufügen wenn sie nicht schon drinnen ist ...
            Einzelaufgabenliste.Add(aufgabe);
        }


        public List<Aufgabenliste> AufgabenlisteListe { get; set; }
        public void AufgabemListeHinzufügen(Aufgabenliste aufgaben)
        {
            // ToDo: nur hinzufügen wenn sie nicht schon drinnen ist ...
            AufgabenlisteListe.Add(aufgaben);
        }
    }
}

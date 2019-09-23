﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger.Instance.Log("Hallo Welt");
            //Logger.Instance.Log("Demo ");
            //Logger.Instance.Log("Ich logge etwas ...");

            Parallel.For(0, 1000, i =>
             {
                 Logger.Instance.Log($"Eintrag {i}");
             });


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task Parallel Lib
            // -> Task
            // -> Parallel
            // -> (PLINQ. .AsParallel() / .AsSequential())

            // Tasks starten

            // 1)
            Task t1 = new Task(A);
            t1.Start();

            // 2) seit .NET 4.0
            Task t2 = Task.Factory.StartNew(B); // Startet sofort

            // 3) seit .NET 4.5
            Task t3 = Task.Run(C);
            // macht das Selbe wie
            // Task.Factory.StartNew(B,CancellationToken.None,TaskCreationOptions.DenyChildAttach,TaskScheduler.Default)


            //t2.Wait();
            //Task.WaitAll(t1, t2, t3);
            Task.WaitAll(t1, t2, t3);

            // Task mit einem Resultat
            Task<string> zeitTask = new Task<string>(GetUhrzeit);
            zeitTask.Start();

            // 1) 
            Console.WriteLine(zeitTask.Result); // Wartet, bis das Ergebnis tatsächlich da ist


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static void A()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);

                Console.Write("A");
            }
        }
        public static void B()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(20); 

                Console.Write("B");
            }
        }
        public static void C()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(30);

                Console.Write("C");
            }
        }

        public static string GetUhrzeit()
        {
            Thread.Sleep(3000);
            return DateTime.Now.ToLongTimeString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Logger
    {
        private Logger()
        {
            instance_counter++;
        }

        private static int instance_counter = 0;
        private static readonly object lock_object = new object(); // nur für den Lock-Block
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{instance_counter}[{DateTime.Now.ToLongTimeString()}]: {message}");
            Console.ResetColor();
        }

        private static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null) // Aus Performancegründen, damit man nicht X mal locken muss, sondern nur exakt 1 mal
                {
                    lock (lock_object)
                    { // Hier darf nur ein Thread/Task hinein
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }

                return instance;
            }
        }

    }
}

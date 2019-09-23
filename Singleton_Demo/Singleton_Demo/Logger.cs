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

        }

        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: {message}");
            Console.ResetColor();
        }

        private static Logger instance;
        public static Logger Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }           
        }
     
    }
}

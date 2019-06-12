using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseApi
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            ServiceReference1.mainSoapClient mainSoapClient = new ServiceReference1.mainSoapClient();
            Console.WriteLine("Entrez une valeur entre 1 et 100");
            string value =  Console.ReadLine();
            int parseValue;
            if(int.TryParse(value, out parseValue))
            {
                Console.WriteLine("Résultat: " + mainSoapClient.Fibonacci(parseValue));
            }
            else
            {
                Console.WriteLine("mauvaise entrée");
                log.Info("error");

            }

            Console.ReadLine();


        }
    }
}

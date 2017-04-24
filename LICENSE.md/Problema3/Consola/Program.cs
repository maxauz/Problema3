using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problema3, Ingrese el monto:");
            string numeros = Console.ReadLine();
            Console.WriteLine("El resultado es:");
            MoneyParts.build(numeros);
            Console.ReadLine();
        }
    }
}

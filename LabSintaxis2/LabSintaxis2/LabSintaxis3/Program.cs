using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cantIteraciones = 5;
            string[] arreglo = new string[cantIteraciones];
            Console.WriteLine("Ingrese los elementos del arreglo: ");
            for (int i = 0; i < cantIteraciones; i++)
            {
                arreglo[i] = Console.ReadLine();
            }
            Console.WriteLine("Elementos del arreglo ordenados de manera inversa: ");

            for (int i = cantIteraciones - 1; i >= 0; i--)
            {
                Console.WriteLine(arreglo[i]);
            }

            Console.ReadKey();





        }
    }
}

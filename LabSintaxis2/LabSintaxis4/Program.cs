using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.WriteLine("\nIngrese una opcion de las siguientes: ");
                Console.WriteLine("1 - Funcion suma\n2 - Funcion biciesto\n3 - Funcion fibonacci");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        mostrarSuma();
                        break;
                    case 2:
                        esBiciesto();
                        break;
                }
            } while (op != 0);
            

        }
        static void mostrarSuma() //El resultado de la suma de < número uno > y < número dos > es < resultado >
        {
            int nro1, nro2;
            
            Console.Write("Ingrese el primer numero: ");
            nro1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el segundo numero: ");
            nro2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"El resultado de la suma de {nro1} y {nro2} es: {nro1 + nro2}");
            Console.ReadKey();

        }

        static bool esBiciesto()
        {
            Console.Write("Ingrese: ");
            int year = Convert.ToInt32(Console.ReadLine());
            if (year % 4 == 0)
            {
                if (year % 100 != 0) return true;
                else if (year % 400 == 0) return true;
                else return false;
            }
            else return false;
        }
    }
}

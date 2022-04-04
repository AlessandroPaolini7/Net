using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un texto: ");
            string inputTexto = Console.ReadLine();

            if (inputTexto is System.String)
            {
                Console.WriteLine("OPCIONES: ");
                Console.WriteLine("1 - Convertir a Mayusculas");
                Console.WriteLine("2 - Convertir a Minisculas");
                Console.WriteLine("3 - Mostrar cantidad de caracteres");
                Console.Write("Ingrese una opcion: ");
                ConsoleKeyInfo opcion = Console.ReadKey();
                Console.WriteLine();
                if (opcion.Key == ConsoleKey.D1)
                    Console.WriteLine(inputTexto.ToUpper());
                else if (opcion.Key == ConsoleKey.D2)
                    Console.WriteLine(inputTexto.ToLower());
                else if (opcion.Key == ConsoleKey.D3)
                    Console.WriteLine(inputTexto.Length);
                else Console.WriteLine("No se ingreso ninguna de las opciones.");
            }
            else
            {
                Console.WriteLine("No se ingreso un texto.");
            }
            Console.ReadKey();
        }
    }
}

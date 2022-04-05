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
            System.Console.WriteLine("Ingrese un texto");
            string inputTexto = System.Console.ReadLine();
            int opc;
            if (inputTexto != null)
            {
                System.Console.WriteLine("Ingrese una opción\n 1.Ver palabra en mayuscula\n 2.Ver palabra en minuscula\n 3.Ver cant de caracteres que contiene la palabra");
                opc = Convert.ToInt32(Console.ReadLine());
                if (opc >= 1 && opc <= 3)
                {
                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine(inputTexto.ToUpper());
                            break;
                        case 2:
                            Console.WriteLine(inputTexto.ToLower());
                            break;
                        case 3:
                            Console.WriteLine(inputTexto.Length);
                            break;
                    }
                }
                else Console.WriteLine("No ingreso una opcion entre 1 y 3");
                Console.ReadKey();
            }
        }
    }
}

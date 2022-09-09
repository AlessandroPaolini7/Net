using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        public Business.Logic.UsuarioLogic UsuarioNegocio { get; set; }

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            try
            {
                int op;
                do
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Listado de opciones: ");
                        Console.WriteLine("1– Listado General\n2– Consulta\n3– Agregar\n4- Modificar\n5- Eliminar\n6- Salir");
                        Console.Write("Ingrese una opcion: ");
                        op = Convert.ToInt32(Console.ReadLine());
                    } while (op < 1 | op > 6);

                    switch (op)
                    {
                        case 1:
                            ListadoGeneral();
                            break;
                        case 2:
                            Consultar();
                            break;
                        case 3:
                            Agregar();
                            break;
                        case 4:
                            Modificar();
                            break;
                        case 5:
                            Eliminar();
                            break;
                        case 6:
                            Console.WriteLine("Gracias por su tiempo...");
                            break;
                    }
                    Console.ReadKey();
                } while (op != 6);
                Console.ReadKey();
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero entero");

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        private void ListadoGeneral()
        {
            Console.Clear();

            Console.WriteLine("Listado de todos los usuarios: ");
            Console.WriteLine();
            foreach (Usuario user in UsuarioNegocio.GetAll())
            {
                MostrarDatos(user);
            }
        }

        private void MostrarDatos(Usuario user)
        {
        
            Console.WriteLine($"Usuario: {user.ID}");
            Console.WriteLine($"\t\tNombre: {user.Nombre}");
            Console.WriteLine($"\t\tApellido: {user.Apellido}");
            Console.WriteLine($"\t\tNombre de usuario: {user.NombreUsuario}");
            Console.WriteLine($"\t\tClave: {user.Clave}");
            Console.WriteLine($"\t\tEmail: {user.Email}");
            Console.WriteLine($"\t\tHabilitado: {user.Habilitado}");
            Console.WriteLine();

        }

        private void Consultar()
        {
            try
            {
                Console.Clear();

                Console.Write("Ingrese el ID del usuario a consultar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                this.MostrarDatos(UsuarioNegocio.GetOne(id));

            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero entero");
                
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        private void Modificar()
        {
            Console.Clear();

            Console.Write("Ingrese el ID del usuario a modificar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Usuario user = UsuarioNegocio.GetOne(id);
            user = ModificarValor(user);
            UsuarioNegocio.Save(user);

        }

        private Usuario ModificarValor(Usuario user)
        {
            try
            {

                int op;
                do
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Opciones a modificar: ");
                        Console.WriteLine("1– Nombre\n2– Apellido\n3– Nombre de usuario\n4- Clave\n5- Email\n6- Habilitado\n7- Salir");
                        Console.Write("Ingrese una opcion: ");
                        op = Convert.ToInt32(Console.ReadLine());
                    } while (op < 1 | op > 7);

                    switch (op)
                    {
                        case 1:
                            Console.Write("Ingrese nombre: ");
                            user.Nombre = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Ingrese apellido: ");
                            user.Apellido = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Ingrese nombre de usuario: ");
                            user.NombreUsuario = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Ingrese clave: ");
                            user.Clave = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Ingrese email: ");
                            user.Email = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("Ingrese Habilitado (1-SI / otro-NO): ");
                            user.Habilitado = (Console.ReadLine() == "1");
                            break;
                        case 7:
                            user.State = BusinessEntity.States.Modified;
                            break;
                    }
                    Console.ReadKey();
                } while (op != 7);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero entero");
                
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            return user;
        }

        private void Agregar()
        {
            Usuario user = new Usuario();

            Console.Clear();
            Console.Write("Ingrese nombre: ");
            user.Nombre = Console.ReadLine();
            Console.Write("Ingrese apellido: ");
            user.Apellido = Console.ReadLine();
            Console.Write("Ingrese nombre de usuario: ");
            user.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese clave: ");
            user.Clave = Console.ReadLine();
            Console.Write("Ingrese email: ");
            user.Email = Console.ReadLine();
            Console.Write("Ingrese habilitado (1-SI / otro-NO): ");
            user.Habilitado = (Console.ReadLine() == "1");
            user.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(user);
            Console.WriteLine();
            Console.WriteLine($"ID del nuevo usuario: {user.ID}");
        }

        private void Eliminar()
        {
            try
            {
                Console.Clear();

                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                UsuarioNegocio.Delete(id);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero entero");

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}

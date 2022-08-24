using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {


        static void Main(string[] args)
        {

            // Switch
            int Opcion, M, F;

            Console.WriteLine("***** Elije una opcion *****");
            Console.WriteLine("1. Modificar Usuario ");

            Console.WriteLine("2. Modificar Producto.");

            M = int.Parse(Console.ReadLine());







            switch (M)
            {

                case 1:
                    Console.WriteLine("***** Elije una opcion *****");
                    Console.WriteLine("******** Usuario *******");

                    Console.WriteLine("1. Ingresar.");

                    Console.WriteLine("2. Actualizar.");

                    Console.WriteLine("3. Eliminar.");

                    Console.WriteLine("4. Insertar Usuario ST.");

                    Console.WriteLine("5. Actualizar Usuario SP.");

                    Console.WriteLine("6. Eliminar Usuario SP.");

                    Console.WriteLine("7. Llamar toda la tabla Usuario.");

                    Console.WriteLine("8. Lamar a un Usuario por ID.");

                    Opcion = int.Parse(Console.ReadLine());
                   
                    switch (Opcion)
                    {
                        case 1:
                            PL.Usuario.Add();
                            Console.ReadKey();
                            break;

                        case 2:
                            PL.Usuario.Update();
                            Console.ReadKey();
                            break;

                        case 3:
                            PL.Usuario.Delete();
                            Console.ReadKey();
                            break;

                        case 4:
                            PL.Usuario.AddSP();
                            Console.ReadKey();
                            break;

                        case 5:
                            PL.Usuario.UpdateSP();
                            Console.ReadKey();
                            break;

                        case 6:
                            PL.Usuario.DeleteSP();
                            Console.ReadKey();
                            break;

                        case 7: PL.Usuario.GetAll();
                            Console.ReadKey();
                            break;

                        case 8: PL.Usuario.GetId();
                            Console.ReadKey();

                            break;
                    }
                     break;
            
                case 2:
                    Console.WriteLine("***** Elije una opcion *****");
                    Console.WriteLine("******** Producto *******");

                    Console.WriteLine("1. Insertar un Producto SP.");

                    Console.WriteLine("2. Actualizar un Producto SP.");

                    Console.WriteLine("3. Eliminar un Producto SP.");

                    Console.WriteLine("4. Llamar toda la tabla Producto.");

                    Console.WriteLine("5. Lamar a un Producto por ID.");

                    F = int.Parse(Console.ReadLine());

                  


                    switch (F)
                    {
                        case 1:
                            PL.Producto.Add();
                            Console.ReadKey();
                            break;
                        case 2:
                            PL.Producto.Update();
                            Console.ReadKey();
                            break;
                        case 3:
                            PL.Producto.Delete();
                            Console.ReadKey();
                            break;
                        case 4: PL.Producto.GetAll();
                            Console.ReadKey();
                            break;

                        case 5: PL.Producto.GetId();
                            Console.ReadKey();
                            break;
                   }
                    break;
            }
        }
    }
}

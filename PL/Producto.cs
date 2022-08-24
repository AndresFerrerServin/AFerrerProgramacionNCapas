using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Producto
    {
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese Nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Precio por Unidad");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Coloca la cantidad de Stock en el almacen");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Describe el producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Coloca el Id del proveedor asignado");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("A que departamento pertenece");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());


           // ML.Result result = BL.Producto.Add(producto);
           //ML.Result result = BL.Producto.AddEF(producto);
            ML.Result result = BL.Producto.AddLINQ(producto);

            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }
        }


        public static void Update()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del producto");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Precio por Unidad");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Coloca la cantidad de Stock en el almacen");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Describe el producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Coloca el Id del proveedor asignado");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("A que departamento pertenece");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());


           // ML.Result result = BL.Producto.Update(producto);
           //ML.Result result = BL.Producto.UpdateEF(producto);
            ML.Result result = BL.Producto.UpdateLINQ(producto);


            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }
        }


        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del producto");
            producto.IdProducto = int.Parse(Console.ReadLine());

           // ML.Result result = BL.Producto.Delete(producto);
           //ML.Result result = BL.Producto.DeleteEF(producto);
            ML.Result result = BL.Producto.DeleteLINQ(producto);

            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }
        }

         public static void GetAll()
        {
            //ML.Result result = BL.Producto.GetAll();
            //ML.Result result = BL.Producto.GetAllEF();
            ML.Result result = BL.Producto.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre:"+ producto.Nombre);
                    Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock " + producto.Stock);
                    Console.WriteLine("IdProveedor " + producto.Proveedor.IdProveedor);
                    Console.WriteLine("IdDepartamento" + producto.Departamento.IdDepartamento);
                    

                    Console.WriteLine("--------");
                }
                
            }
            else
            {
                Console.WriteLine("Ocurrió un error al traer la información del usuario: " + result.ErrorMessage);
            }
        }
        public static void GetId()
        {

            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del producto que desee ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Producto.GetId(producto.IdProductos);
            //ML.Result result = BL.Producto.GetIdEF(producto.IdProductos);
            ML.Result result = BL.Producto.GetIdLINQ(producto.IdProducto);

            if (result.Correct)
            {
                Console.WriteLine("IdProducto: " + ((ML.Producto)result.Object).IdProducto);
                Console.WriteLine("Nombre:" + ((ML.Producto)result.Object).Nombre);
                Console.WriteLine("PrecioUnitario: " + ((ML.Producto)result.Object).PrecioUnitario);
                Console.WriteLine("Stock " + ((ML.Producto)result.Object).Stock);
                Console.WriteLine("IdProveedor " + ((ML.Producto)result.Object).Proveedor.IdProveedor);
                Console.WriteLine("IdDepartamento" + ((ML.Producto)result.Object).Departamento.IdDepartamento);

            }
            else
            {

            }
        }




    }

    }
    


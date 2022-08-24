using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Crea el UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Crea un correo electronico");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Crea un password");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento MM/dd/yyyy");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo M / F");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular (Opcional)");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Id Rol del Usuario");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.Add(usuario);

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
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el ID a actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo M / F");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP");
            usuario.CURP = Console.ReadLine();

            ML.Result result = BL.Usuario.Update(usuario);

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
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el ID a eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.Delete(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }

        }


        public static void AddSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Crea el UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Correo electronico");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Crea un password");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento MM/dd/yyyyy");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo M / F");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular (Opcional)");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Id Rol del Usuario");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

           // ML.Result result = BL.Usuario.AddSP(usuario);
           // ML.Result result = BL.Usuario.AddEF(usuario);
             ML.Result result = BL.Usuario.AddLINQ(usuario);
            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }
        }
        
        
        public static void UpdateSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el ID a actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Correo electronico");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("password");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento MM-dd-yyyyy");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo M / F");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular (Opcional)");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Id Rol del Usuario");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.UpdateSP(usuario);

            //ML.Result result = BL.Usuario.UpdateEF(usuario);

            ML.Result result = BL.Usuario.UpdateLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado con exito");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar" + result.ErrorMessage);
            }
        }
       
        
        public static void DeleteSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el ID a eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

           // ML.Result result = BL.Usuario.DeleteSP(usuario);
           // ML.Result result = BL.Usuario.DeleteEF(usuario);
            ML.Result result = BL.Usuario.DeleteLINQ(usuario);
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
           // ML.Result result = BL.Usuario.GetAll();
            //ML.Result result = BL.Usuario.GetAllEF();
            ML.Result result = BL.Usuario.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                    Console.WriteLine("Username:"+ usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email:" + usuario.Email);
                    Console.WriteLine("Password:" + usuario.Password);
                    Console.WriteLine("FechaNacimiento:" + usuario.FechaNacimiento);
                    Console.WriteLine("Sexo:" + usuario.Sexo);
                    Console.WriteLine("Telefono" + usuario.Telefono);
                    Console.WriteLine("Celular:" + usuario.Celular);
                    Console.WriteLine("CURP:" + usuario.CURP);
                    Console.WriteLine("IdRol:" + usuario.Rol.IdRol);

                    Console.WriteLine("--------");
                }
                
            }
            else
            {
                Console.WriteLine("Ocurrió un error al traer la información del producto: " + result.ErrorMessage);
            }
        }
        public static void GetId()
        {
            
            ML.Usuario usuario = new ML.Usuario();
            

            Console.WriteLine("Ingrese el Id del usuario que desee ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.GetId(usuario.IdUsuario);
            //ML.Result result = BL.Usuario.GetIdEF(usuario.IdUsuario);
            ML.Result result = BL.Usuario.GetIdLINQ(usuario.IdUsuario);

            if (result.Correct)
            {

                Console.WriteLine("IdUsuario: " + ((ML.Usuario)result.Object).IdUsuario);
                Console.WriteLine("Username:" + ((ML.Usuario)result.Object).UserName);
                Console.WriteLine("Nombre: " + ((ML.Usuario)result.Object).Nombre);
                Console.WriteLine("ApellidoPaterno: " + ((ML.Usuario)result.Object).ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + ((ML.Usuario)result.Object).ApellidoMaterno);
                Console.WriteLine("Email:" + ((ML.Usuario)result.Object).Email);
                Console.WriteLine("Password:" + ((ML.Usuario)result.Object).Password);
                Console.WriteLine("FechaNacimiento:" + ((ML.Usuario)result.Object).FechaNacimiento); //UNBOXING//
                Console.WriteLine("Sexo:" + ((ML.Usuario)result.Object).Sexo);
                Console.WriteLine("Telefono" + ((ML.Usuario)result.Object).Telefono);
                Console.WriteLine("Celular:" + ((ML.Usuario)result.Object).Celular);
                Console.WriteLine("CURP:" + ((ML.Usuario)result.Object).CURP);
                Console.WriteLine("IdRol:" + ((ML.Usuario)result.Object).Rol.IdRol);

               
            }
        else
            {
             Console.WriteLine("Ocurrió un error al traer la información del producto: " + result.ErrorMessage);
            }
        }

        

        }


    }

    
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Departamento
    {
        public static void Add()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Nombre del Departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Id del departamento");
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

           // ML.Result result = BL.Departamento.AddEF(departamento);//Entity Framework
           ML.Result result = 

            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }
        }
    }
}

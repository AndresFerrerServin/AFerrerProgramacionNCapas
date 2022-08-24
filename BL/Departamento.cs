using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll() 
        { 
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.DepartamentoGetAll().ToList();
                    result.Objects = new List<object> ();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;

                            result.Objects.Add (departamento);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct=false;
                result.ErrorMessage = ex.Message;   
            }
            return result;
        }

        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var restulQuery = context.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);


                    if (restulQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Departamento departamento)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.DepartamentoUpdate(departamento.IdDepartamento,departamento.Nombre,departamento.Area.IdArea);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Departamento departamento)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.DepartamentoDelete(departamento.IdDepartamento);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}

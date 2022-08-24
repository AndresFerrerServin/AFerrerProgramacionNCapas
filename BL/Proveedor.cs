using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.ProveedorGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();
                            proveedor.IdProveedor = obj.IdProveedor;
                            proveedor.Nombre = obj.Nombre;
                            
                            result.Objects.Add(proveedor);
                        }
                        result.Correct= true;
                    }
                    else
                    {
                        result.Correct= false;
                        result.ErrorMessage = "No se encontro el registro";
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

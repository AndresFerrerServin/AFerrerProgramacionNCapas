using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ProductoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("PrecioUnitario", System.Data.SqlDbType.VarChar);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("Stock", System.Data.SqlDbType.VarChar);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                        collection[3].Value = producto.Descripcion;

                        collection[4] = new SqlParameter("IdProveedor", System.Data.SqlDbType.VarChar);
                        collection[4].Value = producto.Proveedor.IdProveedor;

                        collection[5] = new SqlParameter("IdDepartamento", System.Data.SqlDbType.VarChar);
                        collection[5].Value = producto.Departamento.IdDepartamento;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open(); //Nos ayuda a abrit la conexion

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }


        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ProductoUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[7];
                        collection[0] = new SqlParameter("IdProducto", System.Data.SqlDbType.VarChar);
                        collection[0].Value = producto.IdProducto;

                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = producto.Nombre;

                        collection[2] = new SqlParameter("PrecioUnitario", System.Data.SqlDbType.VarChar);
                        collection[2].Value = producto.PrecioUnitario;

                        collection[3] = new SqlParameter("Stock", System.Data.SqlDbType.VarChar);
                        collection[3].Value = producto.Stock;

                        collection[4] = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                        collection[4].Value = producto.Descripcion;

                        collection[5] = new SqlParameter("IdProveedor", System.Data.SqlDbType.VarChar);
                        collection[5].Value = producto.Proveedor.IdProveedor;

                        collection[6] = new SqlParameter("IdDepartamento", System.Data.SqlDbType.VarChar);
                        collection[6].Value = producto.Departamento.IdDepartamento;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open(); //Nos ayuda a abrit la conexion

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }


        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ProductoDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", System.Data.SqlDbType.VarChar);
                        collection[0].Value = producto.IdProducto;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open(); //Nos ayuda a abrit la conexion

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }

          public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ProductoGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable productoTable = new DataTable();

                        cmd.Connection.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(productoTable);

                        //inicializador condicion incrementador
                        if (productoTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in productoTable.Rows)
                            {
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse (row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());

                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse (row[4].ToString());

                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());

                                producto.Descripcion= row[6].ToString();
                                

                                result.Objects.Add(producto);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al momento de insertar la materia";
                        }
                        
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }
        public static ML.Result GetId(int IdProductos)
        {
            ML.Result result = new ML.Result();


            try
            {
                 using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ProductoGetId";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = IdProductos;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableProducto = new DataTable();

                            da.Fill(tableProducto);

                            cmd.Connection.Open();

                            if (tableProducto.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                DataRow row = tableProducto.Rows[0];

                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());

                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());

                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());

                                result.Object = producto;  //boxing    --unboxing

                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros en la tabla Materia";
                            }

                            //inicializador condición incremento


                        }


                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }



        public static ML.Result GetAllEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    //var usuarios = context.ProductoGetAll().ToList();
                    var query = context.ProductoGetAll(producto.Nombre,producto.Departamento.IdDepartamento,producto.Departamento.Area.IdArea).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = obj.PrecioUnitario;
                            producto.Stock = obj.Stock;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor;
                            producto.Proveedor.Nombre = obj.ProveedorNombre;


                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;
                            producto.Departamento.Nombre = obj.DepartamentoNombre;

                            producto.Descripcion =obj.Descripcion;
                            

                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = obj.IdArea;
                            producto.Departamento.Area.Nombre = obj.Nombre;
                            
                            

                            result.Objects.Add(producto);
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        public static ML.Result AddEF(ML.Producto producto)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {

                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento,producto.Imagen.ToString());
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
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

        public static ML.Result UpdateEF(ML.Producto producto)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto,producto.Nombre,producto.PrecioUnitario,producto.Stock,producto.Descripcion,producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento,producto.Imagen.ToString());
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

        public static ML.Result DeleteEF(ML.Producto producto)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.ProductoDelete(producto.IdProducto);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino";
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

        public static ML.Result GetIdEF(int IdProductos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.ProductoGetId(IdProductos).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {

                       ML.Producto producto = new ML.Producto();
                            producto.IdProducto = query.IdProducto;
                            producto.Nombre = query.Nombre;
                            producto.PrecioUnitario = query.PrecioUnitario;
                            producto.Stock = query.Stock;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = query.IdProveedor;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = query.IdDepartamento;
                            producto.Descripcion = query.Descripcion;

                            
                            

                        result.Object = producto;
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }




        public static ML.Result AddLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    DL_EF.Producto productoDL = new DL_EF.Producto();

                    productoDL.Nombre = producto.Nombre;
                    productoDL.PrecioUnitario = producto.PrecioUnitario;
                    productoDL.Stock = producto.Stock;
                    productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                    productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                    productoDL.Descripcion = producto.Descripcion;

                    context.Productoes.Add(productoDL);
                    context.SaveChanges();
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

        public static ML.Result UpdateLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = (from productos in context.Productoes
                                 where productos.IdProducto == producto.IdProducto
                                 select productos).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.PrecioUnitario = producto.PrecioUnitario;
                        query.Stock = producto.Stock;
                        query.IdProveedor = producto.Proveedor.IdProveedor;
                        query.IdDepartamento = producto.Departamento.IdDepartamento;
                        query.Descripcion = producto.Descripcion;
                        

                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro" + producto.IdProducto;
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

        public static ML.Result DeleteLINQ(ML.Producto producto)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = (from productos in context.Productoes
                                 where productos.IdProducto == producto.IdProducto
                                 select productos).First();

                    context.Productoes.Remove(query);
                    context.SaveChanges();
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

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = (from producto in context.Productoes
                                 select new
                                 {
                                     IdProducto = producto.IdProducto,
                                     Nombre = producto.Nombre,
                                     PrecioUnitario = producto.PrecioUnitario,
                                     Stock = producto.Stock,
                                     IdProveedor = producto.IdProveedor,
                                     IdDepartamento = producto.IdDepartamento,
                                     Descripcion = producto.Descripcion,
                                    
                                 }).ToList();


                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = obj.PrecioUnitario;
                            producto.Stock = obj.Stock;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;
                            producto.Descripcion = obj.Descripcion;
                          

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
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

        public static ML.Result GetIdLINQ(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = (from producto in context.Productoes
                                 where producto.IdProducto == IdProducto
                                 select new
                                 {
                                     IdProducto = producto.IdProducto,
                                     Nombre = producto.Nombre,
                                     PrecioUnitario = producto.PrecioUnitario,
                                     Stock = producto.Stock,
                                     IdProveedor = producto.IdProveedor,
                                     IdDepartamento = producto.IdDepartamento,
                                     Descripcion = producto.Descripcion,
                                 }).ToList();


                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = obj.PrecioUnitario;
                            producto.Stock = obj.Stock;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;
                            producto.Descripcion = obj.Descripcion;

                            result.Object = producto;
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
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

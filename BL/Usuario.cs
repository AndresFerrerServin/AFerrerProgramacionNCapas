using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno] ,[Sexo],[CURP])VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Sexo,@CURP)";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[5];
                    collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;

                    collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;

                    collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;

                    collection[3] = new SqlParameter("Sexo", System.Data.SqlDbType.VarChar);
                    collection[3].Value = usuario.Sexo;

                    collection[4] = new SqlParameter("CURP", System.Data.SqlDbType.VarChar);
                    collection[4].Value = usuario.CURP;

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
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }


        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UPDATE [Usuario] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Sexo] = @Sexo,[CURP] = @CURP WHERE IdUsuario = @IdUsuario";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[6];

                    collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.IdUsuario;

                    collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;

                    collection[2] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;

                    collection[3] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;

                    collection[4] = new SqlParameter("Sexo", System.Data.SqlDbType.VarChar);
                    collection[4].Value = usuario.Sexo;

                    collection[5] = new SqlParameter("CURP", System.Data.SqlDbType.VarChar);
                    collection[5].Value = usuario.CURP;

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
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;

        }


        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "DELETE FROM [Usuario] WHERE IdUsuario = @IdUsuario";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.IdUsuario;

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
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }


        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("UserName", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.UserName;

                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("Password", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Password;

                        collection[6] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.FechaNacimiento;

                        collection[7] = new SqlParameter("Sexo", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Sexo;

                        collection[8] = new SqlParameter("Telefono", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("IdRol", System.Data.SqlDbType.VarChar);
                        collection[11].Value = usuario.Rol.IdRol;

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


        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("UserName", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.UserName;

                        collection[2] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.Nombre;

                        collection[3] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;

                        collection[4] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.ApellidoMaterno;

                        collection[5] = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;

                        collection[6] = new SqlParameter("Password", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.Password;

                        collection[7] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.FechaNacimiento;

                        collection[8] = new SqlParameter("Sexo", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Sexo;

                        collection[9] = new SqlParameter("Telefono", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Telefono;

                        collection[10] = new SqlParameter("Celular", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.Celular;

                        collection[11] = new SqlParameter("CURP", System.Data.SqlDbType.VarChar);
                        collection[11].Value = usuario.CURP;

                        collection[12] = new SqlParameter("IdRol", System.Data.SqlDbType.VarChar);
                        collection[12].Value = usuario.Rol.IdRol;


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


        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.IdUsuario;

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
                    string query = "UsuarioGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable usuarioTable = new DataTable();

                        cmd.Connection.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(usuarioTable);

                        //inicializador condicion incrementador
                        if (usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.UserName = row[1].ToString();
                                usuario.Nombre = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.Password = row[6].ToString();
                                usuario.FechaNacimiento = row[7].ToString();
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[12].ToString());

                                result.Objects.Add(usuario);
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


        public static ML.Result GetId(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioGetId";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableUsuario = new DataTable();

                            da.Fill(tableUsuario);

                            cmd.Connection.Open();
                            if (tableUsuario.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                DataRow row = tableUsuario.Rows[0];

                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.UserName = row[1].ToString();
                                usuario.Nombre = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.Password = row[6].ToString();
                                usuario.FechaNacimiento = row[7].ToString();
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[12].ToString());

                                result.Object = usuario;  //boxing    --unboxing

                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros en la tabla Usuario";
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


        // Continuar actualizacion---

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.masterEntities contex = new DL_EF.masterEntities())
                {
                    var usuarios = contex.UsuarioGetAll(usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno).ToList();
                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol;
                            usuario.Rol.Nombre = obj.RolNombre;

                            result.Objects.Add(usuario);
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

        public static ML.Result AddEF(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {

                    var query = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP,usuario.Imagen, usuario.Rol.IdRol, usuario.Estatus, usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);
                    if (query > 0)
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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, 
                                                      usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.FechaNacimiento, 
                                                      usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, 
                                                      usuario.Rol.IdRol, usuario.Estatus,usuario.Direccion.IdDirreccion, usuario.Direccion.Calle, 
                                                      usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,
                                                      usuario.Direccion.Colonia.IdColonia);
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

        public static ML.Result DeleteEF(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.UsuarioDelete(usuario.IdUsuario);
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

        public static ML.Result GetIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = context.UsuarioGetId(IdUsuario).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol;

                        result.Object = usuario;
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






        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);
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

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = (from usuarios in context.Usuarios
                                 where usuarios.IdUsuario == usuario.IdUsuario
                                 select usuarios).SingleOrDefault();

                    if (query != null)
                    {
                        query.UserName = usuario.UserName;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                        query.Sexo = usuario.Sexo;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro" + usuario.IdUsuario;
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

        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = (from usuarios in context.Usuarios
                                 where usuarios.IdUsuario == usuario.IdUsuario
                                 select usuarios).First();

                    context.Usuarios.Remove(query);
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
                    var query = (from usuario in context.Usuarios
                                 select new
                                 {
                                     IdUsuario = usuario.IdUsuario,
                                     UserName = usuario.UserName,
                                     Nombre = usuario.Nombre,
                                     ApellidosPaterno = usuario.ApellidoPaterno,
                                     ApellidoMaterno = usuario.ApellidoMaterno,
                                     Email = usuario.Email,
                                     Password = usuario.Password,
                                     FechaNacimiento = usuario.FechaNacimiento,
                                     Sexo = usuario.Sexo,
                                     Telefono = usuario.Telefono,
                                     Celular = usuario.Celular,
                                     CURP = usuario.CURP,
                                     IdRol = usuario.IdRol
                                 }).ToList();


                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidosPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol;

                            result.Objects.Add(usuario);
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

        public static ML.Result GetIdLINQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.masterEntities context = new DL_EF.masterEntities())
                {
                    var query = (from usuario in context.Usuarios
                                 where usuario.IdUsuario == IdUsuario
                                 select new
                                 {
                                     IdUsuario = usuario.IdUsuario,
                                     UserName = usuario.UserName,
                                     Nombre = usuario.Nombre,
                                     ApellidosPaterno = usuario.ApellidoPaterno,
                                     ApellidoMaterno = usuario.ApellidoMaterno,
                                     Email = usuario.Email,
                                     Password = usuario.Password,
                                     FechaNacimiento = usuario.FechaNacimiento,
                                     Sexo = usuario.Sexo,
                                     Telefono = usuario.Telefono,
                                     Celular = usuario.Celular,
                                     CURP = usuario.CURP,
                                     IdRol = usuario.IdRol
                                 }).ToList();


                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidosPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol;

                            result.Object = usuario;
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
         
 

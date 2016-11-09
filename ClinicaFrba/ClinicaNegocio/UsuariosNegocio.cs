using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;

namespace ClinicaNegocio
{
    public class UsuariosNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public UsuariosNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }


        public DataTable BuscarProfesionales(string nombre, string especialidad, string email)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT u.habilitado, u.id_usuario, u.nombre + ' ' + u.apellido, u.fecha_nacimiento, u.mail";
                sqlRequest += "FROM SIEGFRIED.USUARIOS u, SIEGRIED.AFILIADOS a";
                sqlRequest += "WHERE u.id_usuario = a.id_afiliado";
                if (nombre != null && nombre != "") sqlRequest += " and u.nombre + ' ' + u.apellido LIKE  @nombre";                                                        			                                               //DomCalle		
                //if (plan != null && plan != 0) sqlRequest += " and u.id_plan = @id_plan";
                //if (estadoCivil != null && estadoCivil != 0) sqlRequest += " and u.estado_civil = @estado_civil";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                if (nombre != null && nombre != "") command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = "%" + nombre + "%";
                //if (plan != null && plan != 0) command.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan;
                //if (estadoCivil != null && estadoCivil != 0) command.Parameters.Add("@estado_civil", SqlDbType.Int).Value = estadoCivil;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    return dt;
                }


                command.Dispose();
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en la busqueda de afiliados" + ex.Message));
            }   
        }

        public DataTable getEstadosCiviles()
        {
            string Sql = "select * from SIEGFRIED.ESTADOS_CIVILES";
            DBConn.openConnection();
            SqlCommand cmd = new SqlCommand(Sql, DBConn.Connection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DBConn.closeConnection();
            return ds.Tables[0];
        }

        public DataTable getPlanes()
        {
            string Sql = "select * from SIEGFRIED.PLANES";
            DBConn.openConnection();
            SqlCommand cmd = new SqlCommand(Sql, DBConn.Connection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DBConn.closeConnection();
            return ds.Tables[0];
        }

        public DataTable BuscarAfiliados(String nombre, Int32 plan, Int32 estadoCivil)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT u.habilitado, u.id_usuario, u.nombre, u.apellido, u.fecha_nacimiento, u.mail, a.cantidad_familiares, u.direccion, u.dni, u.telefono";
                sqlRequest += " FROM SIEGFRIED.USUARIOS u, SIEGRIED.AFILIADOS a";
                sqlRequest += " WHERE u.id_usuario = a.id_afiliado";
                if (nombre != null && nombre != "") sqlRequest += " and u.nombre + ' ' + u.apellido LIKE  @nombre";                                                        			                                               //DomCalle		
                if (plan != null && plan != 0) sqlRequest += " and u.id_plan = @id_plan";                                                             		
                if (estadoCivil != null && estadoCivil != 0) sqlRequest += " and u.estado_civil = @estado_civil";                                                             			
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);                                                                 			
                if (nombre != null && nombre != "") command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = "%" + nombre + "%";                           				
                if (plan != null && plan != 0) command.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan;                                        		
                if (estadoCivil != null && estadoCivil != 0) command.Parameters.Add("@estado_civil", SqlDbType.Int).Value = estadoCivil;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    return dt;
                }


                command.Dispose();
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en la busqueda de afiliados" + ex.Message));
            }
        }

        public void darDeBaja(String id)
        {
            try
            {
                String proc = "SIEGFRIED.BAJA_USUARIO";
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();

            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo dar de baja al afiliado : " + e.Message));

            }
        }

        public void modificarAfiliado(String nombre,
            String apellido,
            String password,
            String direccion,
            Int32 documento,
            Int32 telefono,
            String mail,
            DateTime fechaNac,
            Int32 sexo,
            Int32 estadoCivil,
            Int32 cantFamiliares,
            Int32 plan)
            
        {
            try {
             String proc = "SIEGFRIED.MODIFICAR_AFILIADO";
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;
                    cmd.Parameters.Add("@nroDoc", SqlDbType.Int).Value = documento;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = telefono;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = fechaNac;
                    cmd.Parameters.Add("@sexo", SqlDbType.Int).Value = sexo;
                    cmd.Parameters.Add("@estadoCivil", SqlDbType.Int).Value = estadoCivil;
                    cmd.Parameters.Add("@cantFamiliares", SqlDbType.Int).Value = cantFamiliares;
                    cmd.Parameters.Add("@plan", SqlDbType.Int).Value = plan;
 
                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();
                
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo editar al afiliado : " + e.Message));

            }
        }

        public int agregarAfiliadoTitular(
            String nombre,
            String apellido,
            String password,
            String direccion,
            Int32 documento,
            Int32 telefono,
            String mail,
            DateTime fechaNac,
            Int32 sexo,
            Int32 estadoCivil,
            Int32 cantFamiliares,
            Int32 plan
            )
        {
            try {
                Int32 id = -1;
                String proc = "SIEGFRIED.ALTA_AFILIADO_TITULAR";
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;
                    cmd.Parameters.Add("@nroDoc", SqlDbType.Int).Value = documento;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = telefono;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = fechaNac;
                    cmd.Parameters.Add("@sexo", SqlDbType.Int).Value = sexo;
                    cmd.Parameters.Add("@estadoCivil", SqlDbType.Int).Value = estadoCivil;
                    cmd.Parameters.Add("@cantFamiliares", SqlDbType.Int).Value = cantFamiliares;
                    cmd.Parameters.Add("@plan", SqlDbType.Int).Value = plan;
 
                    var returnParameter = cmd.Parameters.Add("@id", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    id = (int) returnParameter.Value;
                }
                DBConn.closeConnection();
                return id;
                
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo agregar al afiliado: " + e.Message));

            }

        }

        public int agregarAfiliadoFamiliar(
            String nombre,
            String apellido,
            String password,
            String direccion,
            Int32 documento,
            Int32 telefono,
            String mail,
            DateTime fechaNac,
            Int32 sexo,
            Int32 estadoCivil,
            Int32 idTitular,
            Int32 plan
            )
        {
            try
            {
                Int32 id = -1;
                String proc = "SIEGFRIED.ALTA_AFILIADO_FAMILIAR";
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;
                    cmd.Parameters.Add("@nroDoc", SqlDbType.Int).Value = documento;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = telefono;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = fechaNac;
                    cmd.Parameters.Add("@sexo", SqlDbType.Int).Value = sexo;
                    cmd.Parameters.Add("@estadoCivil", SqlDbType.Int).Value = estadoCivil;
                    cmd.Parameters.Add("@idTitular", SqlDbType.Int).Value = idTitular;
                    cmd.Parameters.Add("@plan", SqlDbType.Int).Value = plan;

                    var returnParameter = cmd.Parameters.Add("@id", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    id = (int)returnParameter.Value;
                }
                DBConn.closeConnection();
                return id;

            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo agregar al afiliado: " + e.Message));

            }
        }



        public static object DbNullIfNull(object obj)
        {
            return obj != null ? obj : DBNull.Value;
        }
    }
}

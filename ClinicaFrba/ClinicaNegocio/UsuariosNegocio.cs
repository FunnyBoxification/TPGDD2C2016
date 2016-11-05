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

        public void agregarAfiliadoTitular()
        {
        }

        public void agregarAfiliadoFamiliar()
        {
        }

        /*public void ProcedureCliente(int tipo, int modo, int IdCod, string username, string password, string nombreRazon, string ApellidCui,
                                string Doccto, string tiporub, string fechaCiud, string mail, string telef, string direcc,
                                string nro, string piso, string dpto, string local, DateTime fechacreac)
        {
            try
            {

                var proc = "PMS.";
                if (modo == 0)
                {
                    proc += "ALTA_USUARIO_";
                }
                else
                {
                    proc += "MODIFICACION_USUARIO_";
                }
                if (tipo == 0)
                {
                    proc += "CLIENTE";
                }
                else
                {
                    proc += "EMPRESA";
                }
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand(proc, DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (modo == 1)
                    {
                        cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = IdCod;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = fechacreac;
                    }
                    cmd.Parameters.Add("@User_Nombre", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@User_Password", SqlDbType.VarChar).Value = password;
                    if (tipo == 0)
                    {                //Cliente    
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombreRazon;
                        cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = ApellidCui;
                        cmd.Parameters.Add("@Dni_Cliente", SqlDbType.Int).Value = Convert.ToInt32(Doccto);
                        cmd.Parameters.Add("@Tipo_Dni", SqlDbType.VarChar).Value = tiporub;
                        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = Convert.ToDateTime(fechaCiud);
                    }
                    else
                    { //empresa
                        cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = nombreRazon;
                        cmd.Parameters.Add("@Cuit_Empresa", SqlDbType.VarChar).Value = ApellidCui;
                        cmd.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = Doccto;
                        cmd.Parameters.Add("@Rubro", SqlDbType.VarChar).Value = tiporub;
                        cmd.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = fechaCiud;
                    }
                    cmd.Parameters.Add("@Mail", SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = telef;
                    cmd.Parameters.Add("@DomCalle", SqlDbType.VarChar).Value = direcc;
                    cmd.Parameters.Add("@NroCalle", SqlDbType.Int).Value = Convert.ToInt32(nro);
                    cmd.Parameters.Add("@Piso", SqlDbType.Int).Value = Convert.ToInt32(piso);
                    cmd.Parameters.Add("@Depto", SqlDbType.VarChar).Value = dpto;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.VarChar).Value = local;
                    if (modo == 0)
                    {
                        var returnParameter = cmd.Parameters.Add("@id", SqlDbType.Int);
                        //returnParameter.Value = 0;
                        returnParameter.Direction = ParameterDirection.Output;
                    }
                    //cmd.Parameters.Add("¨@Localidad", SqlDbType.VarChar).Value = local;
                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();

            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo editar la cantidad de intentos fallidos : " + e.Message));

            }
        }*/


        public static object DbNullIfNull(object obj)
        {
            return obj != null ? obj : DBNull.Value;
        }



        /*public DataTable ObtenerRubros()
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT Descripcion FROM PMS.RUBROS ";//Id_Cliente		

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);

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
                throw (new Exception("Error en la busqueda de clientes" + ex.Message));
            }
        }*/
    }
}

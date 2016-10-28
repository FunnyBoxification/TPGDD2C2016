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


        /*public DataTable BuscarEmpresas(string razonSocial, string cuit, string email)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;                                                                                                                 // Id_Empresa			
                sqlRequest = "SELECT  u.Habilitado, u.Id_Usuario as \"Código Usuario\", u.User_Nombre as \"Nombre Usuario\", ";                   // Cuit_Empresa		
                sqlRequest += "e.RAzonSocial as \"Razon Social\", e.Cuit_Empresa as \"CUIT\", e.Mail, e.DomCalle as \"Calle\", ";              // RazonSocial			
                sqlRequest += "e.NroCalle as \"Nro\", e.Piso, e.Depto, ";                                                                                // Mail				
                sqlRequest += "e.CodigoPostal as \"Cod Postal\", e.Ciudad ,  e.Telefono, e.NombreContacto as \"Contacto\", ";                                                     // DomCalle			
                sqlRequest += "(select r.Descripcion FROM PMS.RUBROS r where r.Id_Rubro = e.Id_Rubro) as \"Rubro\" , u.FechaCreacion as \"Fecha Creación\" ";                              // NroCalle			
                sqlRequest += " FROM PMS.USUARIOS u, PMS.EMPRESAS e";                                                                              // Piso				
                sqlRequest += " WHERE u.Id_Usuario = e.Id_Empresa ";                                                                               // Depto				
                if (razonSocial != null && razonSocial != "") sqlRequest += " and e.RazonSocial = @razonSocial";                                   // CodigoPostal		
                if (cuit != null && cuit != "") sqlRequest += " and e.Cuit_Empresa = @cuit";                                                       // Ciudad				
                if (email != null && email != "") sqlRequest += " and e.Mail = @email";                                                            // NombreContacto		
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);                                                                // Telefono			
                if (razonSocial != null && razonSocial != "") command.Parameters.Add("@razonSocial", SqlDbType.NVarChar).Value = razonSocial;      // Id_Rubro			
                if (cuit != null && cuit != "") command.Parameters.Add("@cuit", SqlDbType.NVarChar).Value = cuit;
                if (email != null && email != "") command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

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
                throw (new Exception("Error en la Busqueda de empresas: " + ex.Message));
            }
        }*/

        public DataTable BuscarAfiliados(String nombre, Int32 plan, Int32 estadoCivil)
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

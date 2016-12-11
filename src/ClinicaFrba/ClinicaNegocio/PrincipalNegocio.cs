using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaNegocio;

namespace ClinicaNegocio
{
    public class PrincipalNegocio
    {
         SqlServerDBConnection DBConn { get; set; }

        public PrincipalNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }

        public bool EsProfesionaloValido(int idProfesional)
        {
            DataTable dt = new DataTable();
            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT id_profesional FROM SIEGFRIED.PROFESIONALES where id_profesional = @idProf";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@idProf", SqlDbType.Int).Value = idProfesional;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {

                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                command.Dispose();
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en getDiaAgenda" + ex.Message));
            }
        }

        public List<String> getFuncionalidades(String nombre)
        {
            var listaFuncionalidades = new List<String>();

            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT Nombre FROM SIEGFRIED.FUNCIONALIDADES WHERE Id_Funcionalidad IN ";
                sqlRequest += "(SELECT Id_Funcionalidad FROM SIEGFRIED.FUNCIONALIDES_ROLES WHERE Id_Rol IN (SELECT Id_Rol FROM SIEGFRIED.ROLES WHERE Nombre='"+nombre+"' ))";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                //command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var funcionalidad = reader["Nombre"].ToString();
                        listaFuncionalidades.Add(funcionalidad);
                    }
                }

                command.Dispose();
                DBConn.closeConnection();

                return listaFuncionalidades;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObetenerRoles" + ex.Message));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClinicaNegocio;

namespace ClinicaNegocio
{
    public class ListadosNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public ListadosNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }

        public List<String> getSemestres()
        {
            var lista = new List<String>();

            lista.Add("Ene-Jun");
            lista.Add("Jul-Dic");
            return lista;
        }

        public List<String> getMeses(int semestre)
        {
            if (semestre == 0)
            {
                var lista = new List<String>();

                lista.Add("Enero");
                lista.Add("Febrero");
                lista.Add("Marzo");
                lista.Add("Abril");
                lista.Add("Mayo");
                lista.Add("Junio");
                return lista;
            }
            else
            {
                var lista = new List<String>();

                lista.Add("Julio");
                lista.Add("Agosto");
                lista.Add("Septiembre");
                lista.Add("Octubre");
                lista.Add("Noviembre");
                lista.Add("Diciembre");
                return lista;
            }
        }

        public List<String> getListados()
        {
            var listados = new List<String>();

            listados.Add("Especialidades con mas cancelaciones");
            listados.Add("Profesionales mas consultados");
            listados.Add("Profesionales que menos trabajaron");
            listados.Add("Afiliados con mas bonos comprados");
            listados.Add("Especialidades con mas bonos usados");
            return listados;

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

        public DataTable getEspecialidades()
        {
            string Sql = "select id_especialidad, descripcion from SIEGFRIED.ESPECIALIDADES";
            DBConn.openConnection();
            SqlCommand cmd = new SqlCommand(Sql, DBConn.Connection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DBConn.closeConnection();
            return ds.Tables[0];
        }

        public DataTable getAniosPublicaciones()
        {
            var dt = new DataTable();

            try
            {

                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT DISTINCT DATEPART(yyyy,Fecha) FROM SIEGFRIED.TURNOS";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                    command.Dispose();
                    DBConn.closeConnection();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en searchFacturasAlVendedor: " + ex.Message));
            }
        }
    }
}

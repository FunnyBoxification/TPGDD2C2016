using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaNegocio
{
    public class BonosNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public BonosNegocio(SqlServerDBConnection instance)
        {
            DBConn = instance;
        }

        public DataTable getPlanes()
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT id_plan, descripcion FROM SIEGFRIED.PLANES";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                command.Dispose();
                DBConn.closeConnection();
                return dt;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en BonosNegocio.getPlanes" + ex.Message));
            }
        }

        public DataTable buscarCompraBonos(Int32 idAfiliado, Int32 cantidad, DateTime fecha, Int32 plan)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT  ";
                sqlRequest += "FROM SIEGFRIED.COMPRA_BONOS ";
                sqlRequest += "WHERE 1=1 ";
                if (idAfiliado != -1)
                {
                    sqlRequest += "AND id_afiliado = @id_afiliado ";
                }
                if (cantidad != -1)
                {
                    sqlRequest += "AND cantidad = @cantidad ";
                }
                if (fecha != DateTime.) sqlRequest += " and fecha_compra = @fecha_compra ";

                if (plan != -1 ) sqlRequest += " and id_plan = @id_plan";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);

                if (idAfiliado != -1) command.Parameters.Add("@id_afiliado", SqlDbType.Int).Value = idAfiliado;
                if (cantidad != -1) command.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                if (fecha != null) command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                if (plan != -1) command.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan;

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
                throw (new Exception("Error en la Busqueda de compras de bonos" + ex.Message));
            }
        }

        public DataTable buscarCompraBonos(Int32 idAfiliado, Int32 cantidad, Int32 plan)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT  ";
                sqlRequest += "FROM SIEGFRIED.COMPRA_BONOS ";
                sqlRequest += "WHERE 1=1 ";
                if (idAfiliado != -1)
                {
                    sqlRequest += "AND id_afiliado = @id_afiliado ";
                }
                if (cantidad != -1)
                {
                    sqlRequest += "AND cantidad = @cantidad ";
                }
                
                if (plan != -1 ) sqlRequest += " and id_plan = @id_plan";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);

                if (idAfiliado != -1) command.Parameters.Add("@id_afiliado", SqlDbType.Int).Value = idAfiliado;
                if (cantidad != -1) command.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                if (plan != -1) command.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan;

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
                throw (new Exception("Error en la Busqueda de compras de bonos" + ex.Message));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;
using ClinicaNegocio;

namespace ClinicaNegocio
{
    public class ResultadoNegocio
    {
         public SqlServerDBConnection DBConn { get; set; }

        public ResultadoNegocio(SqlServerDBConnection dbConnection)
        {
            this.DBConn = dbConnection;
        }

        public void guardarConsulta(int idConsulta, String diagnostico, String sintomas, DateTime fechaAtencion)
        {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.GUARDAR_CONSULTA", DBConn.Connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@consulta", idConsulta);
                    cmd.Parameters.AddWithValue("@sintomas", sintomas);
                    cmd.Parameters.AddWithValue("@diagnostico", diagnostico);
                    cmd.Parameters.AddWithValue("@fecha", fechaAtencion);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Guardar Consulta" + ex.Message));
            }
        }

        public DataTable getConsultas(int afiliadoId, int profesionalId, int consultaId, DateTime fecha)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT c.id_consulta, c.id_turno, a.id_profesional, t.id_afiliado, a.id_especialidad FROM SIEGFRIED.CONSULTAS c, SIEGFRIED.USUARIOS u, SIEGFRIED.TURNOS t, SIEGFRIED.AGENDA a WHERE a.id_profesional = u.id_usuario AND c.id_turno = t.id_turno AND a.id_turno = c.id_turno";
                sqlRequest += " AND CONVERT(date,a.dia_hora) = CONVERT(date,@fecha) AND c.diagnostico is NULL and c.sintomas is NULL";
                if (afiliadoId != -1)
                {
                    sqlRequest += " AND t.id_afiliado = @idAfiliado";
                }
                if (profesionalId != -1)
                {
                    sqlRequest += " AND a.id_profesional = @profesional";
                }
                if (consultaId != -1)
                {
                    sqlRequest += "AND c.id_consulta = @consulta";
                }

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                if (afiliadoId != -1)
                {
                    command.Parameters.Add("@idAfiliado", SqlDbType.Int).Value = afiliadoId;
                }
                if (profesionalId != -1)
                {
                    command.Parameters.Add("@profesional", SqlDbType.Int).Value = profesionalId;
                }
                if (consultaId != -1)
                {
                    command.Parameters.Add("@consulta", SqlDbType.Int).Value = consultaId;
                }

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
                throw (new Exception("Error en ResultadoNegocio.getConsultas " + ex.Message));
            }
        }
    }
}

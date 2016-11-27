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
    public class RegistroLlegadaNegocio
    {
        public SqlServerDBConnection DBConn { get; set; }

        public RegistroLlegadaNegocio(SqlServerDBConnection dbConnection)
        {
            this.DBConn = dbConnection;
        }

        public DataTable getEspecialidades()
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT id_especialidad, descripcion FROM SIEGFRIED.ESPECIALIDADES";

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
                throw (new Exception("Error en RegistroLlegadaNegocio.getEspecialidades" + ex.Message));
            }
        }

        public DataTable getBonosDisponibles(int id_afiliado)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT * FROM SIEGFRIED.BONOS WHERE FLOOR(id_afiliado/100) = FLOOR(@id_afiliado/100) AND id_consulta is null AND id_plan = (SELECT id_plan FROM SIEGFRIED.AFILIADOS WHERE id_afiliado = @id_afiliado) ";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@id_afiliado", SqlDbType.Int).Value = id_afiliado;

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
                throw (new Exception("Error en RegistroLlegadaNegocio.getBonosDisponibles: " + ex.Message));
            }
        }

        public void generarConsulta(String idTurno, String idBono, DateTime fechaLlegada) {
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.GENERAR_CONSULTA", DBConn.Connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@turno", Int32.Parse(idTurno));
                    cmd.Parameters.AddWithValue("@bono", Int32.Parse(idBono));
                    cmd.Parameters.AddWithValue("@fecha", fechaLlegada);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Generar Consulta" + ex.Message));
            }
        }

        public DataTable getTurnos(int afiliadoId, String profesionalNombre, int especialidad, DateTime fecha)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT t.* FROM SIEGFRIED.TURNOS t, SIEGFRIED.AGENDA a, SIEGFRIED.USUARIOS u WHERE t.id_turno = a.id_turno AND a.id_profesional = u.id_usuario";
                sqlRequest += " AND CONVERT(date,a.dia_hora) = CONVERT(date,@fechaDeHoy) AND t.id_turno NOT IN (SELECT id_turno FROM SIEGFRIED.CONSULTAS)";
                if (afiliadoId != -1)
                {
                    sqlRequest += " AND t.id_afiliado = @idAfiliado";
                }
                if (profesionalNombre != null)
                {
                    sqlRequest += " AND (u.nombre like '%@profesionalNombre%' OR u.nombre+' '+u.apellido LIKE '%@profesionalNombre%' OR u.apellido LIKE '%profesionalNombre%')";
                }
                if (especialidad != -1)
                {
                    sqlRequest += "AND a.id_especialidad = @especialidad";
                }

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@fechaDeHoy", SqlDbType.DateTime).Value = fecha;
                if (afiliadoId != -1)
                {
                    command.Parameters.Add("@idAfiliado", SqlDbType.Int).Value = afiliadoId;
                }
                if (profesionalNombre != null)
                {
                    command.Parameters.Add("@profesionalNombre", SqlDbType.VarChar).Value = profesionalNombre;
                }
                if (especialidad != -1)
                {
                    command.Parameters.Add("@especialidad", SqlDbType.Int).Value = especialidad;
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
                throw (new Exception("Error en RegistroLlegadaNegocio.getTurnos: " + ex.Message));
            }
        }
    }
}

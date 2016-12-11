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
                sqlRequest = "SELECT DISTINCT DATEPART(yyyy,dia_hora) as anio FROM SIEGFRIED.AGENDA";

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

        public DataTable getEspecialidadesConMasCancelaciones(int anio, int semestre, int mes) {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT descripcion from SIEGFRIED.ESPECIALIDADES where id_especialidad IN (";
                sqlRequest += "SELECT TOP 5 a.id_especialidad ";
                sqlRequest += "from SIEGFRIED.AGENDA a ";
                sqlRequest += "where a.cancelado = 1 ";
                sqlRequest += "AND YEAR(a.dia_hora) = @anio AND MONTH(a.dia_hora) = @mes ";
                sqlRequest += "GROUP BY a.id_especialidad ";
                sqlRequest += "ORDER BY COUNT(a.id_turno) desc)";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;

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
                throw (new Exception("Error en ListadosNegocio.getEspecialidadesConMasCancelaciones" + ex.Message));
            }
        }

        public DataTable getProfesionalesMasConsultados(int anio,int semestre,int mes,int plan) {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT TOP 5 usuario.nombre+' '+usuario.apellido as medico, plann.descripcion, especialidad.descripcion, count(*) as cantidad_consultas ";
                sqlRequest += "FROM (";
                sqlRequest += "SELECT bono.id_plan as planid, agenda.id_profesional as profesional,agenda.id_especialidad as especialidad FROM SIEGFRIED.BONOS bono ";
                sqlRequest += "LEFT JOIN SIEGFRIED.CONSULTAS consulta on bono.id_consulta = consulta.id_consulta ";
                sqlRequest += "LEFT JOIN SIEGFRIED.TURNOS turno on turno.id_turno = consulta.id_turno ";
                sqlRequest += "LEFT JOIN SIEGFRIED.AGENDA agenda on turno.id_turno = agenda.id_turno ";
                sqlRequest += "WHERE bono.id_consulta is not null ";
                sqlRequest += "AND YEAR(agenda.dia_hora) = @anio AND MONTH(agenda.dia_hora) = @mes AND bono.id_plan = @plan ";
                sqlRequest +=") as vista ";
                sqlRequest += "LEFT JOIN SIEGFRIED.USUARIOS usuario ON vista.profesional = usuario.id_usuario ";
                sqlRequest += "LEFT JOIN SIEGFRIED.PLANES plann on plann.id_plan = vista.planid ";
                sqlRequest += "LEFT JOIN SIEGFRIED.ESPECIALIDADES especialidad on especialidad.id_especialidad = vista.especialidad ";
                sqlRequest += "GROUP BY plann.descripcion, usuario.nombre+' '+usuario.apellido, especialidad.descripcion ORDER BY 3 DESC";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                command.Parameters.Add("@plan", SqlDbType.Int).Value = plan;

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
                throw (new Exception("Error en ListadosNegocio.getProfesionalesMasConsultados" + ex.Message));
            }
        }

        public DataTable getProfesionalesQueMenosTrabajaron(int anio,int semestre,int mes,int plan,int especialidad) 
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT TOP 5 usuario.nombre+' '+usuario.apellido as medico,especialidad.descripcion,count(*) / 2 as horas_trabajadas ";
                sqlRequest += "FROM (";
                sqlRequest += "SELECT agenda.id_profesional as profesional,agenda.id_especialidad as especialidad ";
                sqlRequest += "FROM SIEGFRIED.BONOS bono LEFT JOIN SIEGFRIED.CONSULTAS consulta on bono.id_consulta = consulta.id_consulta LEFT JOIN SIEGFRIED.TURNOS turno on turno.id_turno = consulta.id_turno LEFT JOIN SIEGFRIED.AGENDA agenda on turno.id_turno = agenda.id_turno ";
                sqlRequest += "WHERE bono.id_consulta is not null ";
                sqlRequest += "AND YEAR(agenda.dia_hora) = @anio AND MONTH(agenda.dia_hora) = @mes AND bono.id_plan = @plan AND agenda.id_especialidad = @especialidad ";
                sqlRequest += ") as vista ";
                sqlRequest += "LEFT JOIN SIEGFRIED.USUARIOS usuario ON vista.profesional = usuario.id_usuario ";
                sqlRequest += "LEFT JOIN SIEGFRIED.ESPECIALIDADES especialidad on especialidad.id_especialidad = vista.especialidad ";
                sqlRequest += "GROUP BY usuario.nombre+' '+usuario.apellido, especialidad.descripcion ";
                sqlRequest += "ORDER BY 3 ASC";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                command.Parameters.Add("@plan", SqlDbType.Int).Value = plan;
                command.Parameters.Add("@especialidad", SqlDbType.Int).Value = especialidad;

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
                throw (new Exception("Error en ListadosNegocio.getProfesionalesQueMenosTrabajaron" + ex.Message));
            }
        }

        public DataTable getAfiliadosConMasBonosComprados(int anio,int semestre,int mes) {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT TOP 5 usuario.nombre + ' ' + usuario.apellido, COUNT(*), CASE WHEN bono.id_afiliado % 10 = 1 THEN 'No'	ELSE 'Si' END as es_de_grupo_familiar ";
                sqlRequest += "FROM SIEGFRIED.BONOS bono ";
                sqlRequest += "LEFT JOIN SIEGFRIED.USUARIOS usuario on bono.id_afiliado = usuario.id_usuario ";
                sqlRequest += "WHERE YEAR(bono.fecha_compra) = @anio AND MONTH(bono.fecha_compra) = @mes ";
                sqlRequest += "GROUP BY usuario.nombre + ' ' + usuario.apellido, bono.id_afiliado ORDER BY 2 DESC";
               
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;

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
                throw (new Exception("Error en ListadosNegocio.getAfiliadosConMasBonosComprados" + ex.Message));
            }
        }

        public DataTable getEspecialidadesConMasBonosUsados(int anio, int semestre, int mes) {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT especialidad.descripcion, vista.cantidad_consultas FROM ( ";
                sqlRequest += "SELECT TOP 5 bono.id_bono as id_bono,agenda.id_especialidad as id_especialidad, COUNT(*) as cantidad_consultas ";
                sqlRequest += "FROM SIEGFRIED.BONOS bono LEFT JOIN SIEGFRIED.CONSULTAS consulta on bono.id_consulta = consulta.id_consulta LEFT JOIN SIEGFRIED.TURNOS turno on turno.id_turno = consulta.id_turno LEFT JOIN SIEGFRIED.AGENDA agenda on turno.id_turno = agenda.id_turno ";
                sqlRequest += "WHERE bono.id_consulta is not null AND YEAR(agenda.dia_hora) = @anio AND MONTH(agenda.dia_hora) = @mes ";
                sqlRequest += "GROUP BY bono.id_bono, agenda.id_especialidad ORDER BY COUNT(*) DESC  ) vista ";
                sqlRequest += "left join siegfried.especialidades especialidad on especialidad.id_especialidad = vista.id_especialidad";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;

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
                throw (new Exception("Error en ListadosNegocio.getEspecialidadesConMasBonosUsados" + ex.Message));
            }
        }

        public DataTable getEstadisticas(int listado, int plan, int especialidad, int anio, int semestre, int mes)
        {
            if (listado == 0) //Especialidades con mas cancelaciones
            {
                return this.getEspecialidadesConMasCancelaciones(anio, semestre, mes);
            }
            else if (listado == 1) // Profesionales mas consultados
            {
                return this.getProfesionalesMasConsultados(anio,semestre,mes,plan);
            }
            else if (listado == 2) { // Profesionales que menos trabajaron
                return this.getProfesionalesQueMenosTrabajaron(anio,semestre,mes,plan,especialidad);
            }
            else if(listado == 3) //afiliados con mas bonos comprados
            {
                return this.getAfiliadosConMasBonosComprados(anio,semestre,mes);
            }
            else { //Especialidades con mas bonos usados
                return this.getEspecialidadesConMasBonosUsados(anio, semestre, mes);
            }
        }
    }
}

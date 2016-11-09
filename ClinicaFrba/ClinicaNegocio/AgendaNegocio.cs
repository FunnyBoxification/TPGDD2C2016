﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ClinicaNegocio
{
    public class AgendaNegocio
    {

         public SqlServerDBConnection DBConn { get; set; }

        public AgendaNegocio(SqlServerDBConnection dbConnection)
        {
            this.DBConn = dbConnection;
        }
            

        public DataTable getDiaAgenda(int idProfesional, DateTime dia)
        {

            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            DataTable dt = new DataTable();


            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT FORMAT((a.dia_hora),'hh:mm') as dia, (select descripcion from SIEGFRIED.ESPECIALIDADES where id_especialidad =  a.id_especialidad) as especialidad  FROM  SIEGFRIED.AGENDA a where @idProf = a.id_profesional and DATEPART(dayofyear, a.dia_hora) = DATEPART(dayofyear, @diabusc) and  DATEPART(YEAR, a.dia_hora) = DATEPART(YEAR, @diabusc)";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@idProf", SqlDbType.Int).Value = idProfesional;
                command.Parameters.Add("@diabusc", SqlDbType.DateTime).Value = dia;
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
                throw (new Exception("Error en getDiaAgenda" + ex.Message));
            }

        }

        public DataTable getDiaAgenda(int idProfesional, DateTime dia, int idespecialidad)
        {

            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            DataTable dt = new DataTable();


            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT id_agenda, FORMAT((a.dia_hora),'hh:mm') as dia, (select descripcion from SIEGFRIED.ESPECIALIDADES where id_especialidad =  a.id_especialidad) as especialidad, CASE WHEN id_turno IS NULL THEN 'Disponible' ELSE 'Ocupado' END as Turno FROM  SIEGFRIED.AGENDA a where @idProf = a.id_profesional and DATEPART(dayofyear, a.dia_hora) = DATEPART(dayofyear, @diabusc) and  DATEPART(YEAR, a.dia_hora) = DATEPART(YEAR, @diabusc) and id_especialidad = @idesp";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@idProf", SqlDbType.Int).Value = idProfesional;
                command.Parameters.Add("@diabusc", SqlDbType.DateTime).Value = dia;
                command.Parameters.Add("@idesp", SqlDbType.Int).Value = idespecialidad;
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
                throw (new Exception("Error en getDiaAgenda" + ex.Message));
            }

        }



        public void EjecutarDia(int idProfesional, DateTime desde, DateTime hasta, int idEspecialidad)
        {
           

            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.CREAR_DIA_AGENDA", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("desde", desde);
                    cmd.Parameters.AddWithValue("hasta", hasta);
                    cmd.Parameters.AddWithValue("especialidad", idEspecialidad);
                    cmd.Parameters.AddWithValue("idprofesional", idProfesional);                    
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Insertar Agenda en Dia" + ex.Message));
            }
        }




        public DataTable getEspecialidades(int idProfesional)
        {
            string Sql = "select a.id_especialidad, a.descripcion from SIEGFRIED.ESPECIALIDADES a, SIEGFRIED.PROFESIONAL_ESPECIALIDAD b where a.id_especialidad = b.id_especialidad and b.id_profesional = @idprof ";
            DBConn.openConnection();
            SqlCommand cmd = new SqlCommand(Sql, DBConn.Connection);
            cmd.Parameters.Add("@idProf", SqlDbType.Int).Value = idProfesional;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DBConn.closeConnection();
            return ds.Tables[0];
        }



        public void GrabarTurno(int idagenda, int idafiliado)
        {

            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.GRABAR_TURNO", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id_agenda", idagenda);
                    cmd.Parameters.AddWithValue("id_afiliado", idafiliado);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Insertar Agenda en Dia" + ex.Message));
            }
        }
    }
}

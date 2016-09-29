﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using ClinicaNegocio;

namespace ClinicaNegocio
{
    public class RolesNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public RolesNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }

        public int insertRol(String Nombre)
        {
            var dt = new DataTable();
            int result = -1;

            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.ALTA_ROL", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre", Nombre);
                    var returnParameter = cmd.Parameters.Add("@id", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int.TryParse(returnParameter.Value.ToString(), out result);
                    cmd.Dispose();
                }

                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObtenerRoles" + ex.Message));
            }
        }


        public void deleteAllFuncionalidadesDeRol(int idRol)
        {
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                /*String sqlRequest = "INSERT INTO PMS.FUNCIONALIDES_ROLES(Id_Rol, Id_Funcionalidad) VALUES (@Id_Rol, @Id_Funcionalidad)";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = idRol;
                command.Parameters.Add("@Id_Funcionalidad", SqlDbType.Int).Value = idFuncionalidad;*/
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.borrar_funcionalidades_rol", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id_Rol", idRol);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObtenerRoles" + ex.Message));
            }

        }
        public void insertFuncionalidadToRol(int idRol, int idFuncionalidad)
        {
            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                /*String sqlRequest = "INSERT INTO PMS.FUNCIONALIDES_ROLES(Id_Rol, Id_Funcionalidad) VALUES (@Id_Rol, @Id_Funcionalidad)";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = idRol;
                command.Parameters.Add("@Id_Funcionalidad", SqlDbType.Int).Value = idFuncionalidad;*/
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.insertFuncionalidad", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id_Rol", idRol);
                    cmd.Parameters.AddWithValue("Id_Funcionalidad", idFuncionalidad);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en Insertar Funcionalidad" + ex.Message));
            }
        }

        public void habilitarRol(int id)
        {
            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                /*String sqlRequest = "INSERT INTO PMS.FUNCIONALIDES_ROLES(Id_Rol, Id_Funcionalidad) VALUES (@Id_Rol, @Id_Funcionalidad)";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = idRol;
                command.Parameters.Add("@Id_Funcionalidad", SqlDbType.Int).Value = idFuncionalidad;*/
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.HABILITAR_ROL", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en baja rol: " + ex.Message));
            }
        }

        public void bajaRol(int id)
        {
            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                /*String sqlRequest = "INSERT INTO PMS.FUNCIONALIDES_ROLES(Id_Rol, Id_Funcionalidad) VALUES (@Id_Rol, @Id_Funcionalidad)";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = idRol;
                command.Parameters.Add("@Id_Funcionalidad", SqlDbType.Int).Value = idFuncionalidad;*/
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.BAJA_ROL", DBConn.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en baja rol: " + ex.Message));
            }
        }

        public List<String> getFuncionalidadesDeRol(int Id)
        {
            var listaFuncionalidades = new List<String>();

            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT Nombre FROM SIEGFRIED.FUNCIONALIDADES WHERE Id_Funcionalidad IN ";
                sqlRequest += "(SELECT Id_Funcionalidad FROM SIEGFRIED.FUNCIONALIDES_ROLES WHERE Id_Rol=@Id )";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

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

        public DataTable searchRoles(String nombre, int Habilitado)
        {
            try
            {
                var dt = new DataTable();
                DBConn.openConnection();
                String sqlRequest;
                sqlRequest = "SELECT * FROM SIEGFRIED.ROLES ";
                sqlRequest += "WHERE 1 = 1 ";
                if (nombre != null) sqlRequest += " and Nombre LIKE @Nombre";
                if (Habilitado != -1) sqlRequest += " and Habilitado = @Habilitado";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                if (nombre != null) command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = "%" + nombre + "%";
                if (Habilitado != -1) command.Parameters.Add("@Habilitado", SqlDbType.Int).Value = Habilitado;

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
                throw (new Exception("Error en ObtenerVisibilidades" + ex.Message));
            }

        }

        public DataTable getAllFuncionalidades()
        {

            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            var dt = new DataTable();

            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT * FROM SIEGFRIED.FUNCIONALIDADES WHERE Id_Funcionalidad IS NOT NULL";
                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                //command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
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
                throw (new Exception("Error en ObtenerRoles" + ex.Message));
            }

        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace ClinicaNegocio
{
    public class LoginNegocio
    {
        SqlServerDBConnection DBConn { get; set; }

        public LoginNegocio(SqlServerDBConnection dbConnection)
        {
            DBConn = dbConnection;
        }



        public int loginUser(string username, string password)
        {
            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT SIEGFRIED.getUser(@userName,@password)";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@userName", SqlDbType.VarChar).Value = username;

                command.Parameters.Add("@password", SqlDbType.VarChar).Value = password.ToString();

                int result = (int)command.ExecuteScalar();
                DBConn.closeConnection();
                return result;

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                Console.WriteLine("Error al obtener usuario : " + ex.Message);
                //System.Windows.Forms.MessageBox.Show("Error con la conexion  SQL ! " + ex.Message);
                throw new Exception("Error al obtener usuario : " + ex.Message);

            }
        }

        public DataTable getRolesDT(int idUser)
        {

            //int ID_ROL_COLUMN = 0;
            //List<decimal> listRolIds = new List<decimal>();
            DataTable dt = new DataTable();


            try
            {
                DBConn.openConnection();
                String sqlRequest = "SELECT R.Nombre FROM  SIEGFRIED.ROLES_USUARIOS RU JOIN SIEGFRIED.ROLES R ON RU.Id_Usuario = @idUser AND RU.Id_Rol = R.Id_Rol";

                SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
                command.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {

                    adapter.Fill(dt);
                    return dt;
                }

                //SqlDataReader reader = command.ExecuteReader();

                //while (reader.Read())
                //{
                //    decimal id_Rol = reader.GetDecimal(ID_ROL_COLUMN);
                //    listRolIds.Add(id_Rol);
                //}

                //reader.Close();
                command.Dispose();
                DBConn.closeConnection();

            }
            catch (Exception ex)
            {
                DBConn.closeConnection();
                throw (new Exception("Error en ObtenerRoles" + ex.Message));
            }

        }





        public void limpiarIntentos(String user)
        {
            String sqlRequest = "EXEC SIEGFRIED.LimpiarIntentos @userName = @user";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            DBConn.openConnection();
            command.ExecuteScalar();
            DBConn.closeConnection();
        }

        //public Rol getRolById(decimal idRol)
        //{
        //    MercadoEN.Rol rol = new Rol();


        //    String sqlRequest = "SELECT * FROM PMS.ROLES where Id_Rol = @idRol";
        //    SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
        //    command.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;

        //    try
        //    {
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            String nombre = reader.GetString(1);
        //            decimal habilitado = reader.GetDecimal(2);
        //            rol.nombre = nombre;
        //            rol.habilitado = habilitado;
        //            rol.id_rol = idRol;

        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        throw (new Exception("Error en ObetenerRoles" + e.Message));

        //    }


        //    command.Dispose();


        //    return rol;

        //}


        public decimal getIntentosDeLogin(String user)
        {
            DBConn.openConnection();
            String sqlRequest = "SELECT Intentos_Login FROM SIEGFRIED.USUARIOS where User_Nombre = @user";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            try
            {

                decimal intentos = (decimal)command.ExecuteScalar();
                return intentos;
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                return -1;
            }

        }


        public Boolean estaHabilitado(String user)
        {
            DBConn.openConnection();
            String sqlRequest = "SELECT Habilitado FROM SIEGFRIED.USUARIOS where User_Nombre = @user";
            SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            try
            {

                decimal habilitado = (decimal)command.ExecuteScalar();
                if (habilitado == 1) return true;
                else return false;
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                return false;
            }
        }

        public void incrementarIntentosLogin(String user)
        {
            //String sqlRequest = "EXEC PMS.AumentarIntentosFallidos @userName =  @user";
            //SqlCommand command = new SqlCommand(sqlRequest, DBConn.Connection);
            //command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            try
            {
                DBConn.openConnection();
                using (SqlCommand cmd = new SqlCommand("SIEGFRIED.AumentarIntentosFallidos", DBConn.Connection))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = user;
                    cmd.ExecuteNonQuery();
                }
                DBConn.closeConnection();
            }
            catch (Exception e)
            {
                DBConn.closeConnection();
                throw (new Exception("No se pudo editar la cantidad de intentos fallidos : " + e.Message));

            }
        }




    }
}


﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsUsuarios
    {
        SqlConnection _SqlConnection = null;//Me permite establecer comunicación con la BD
        SqlCommand _SqlCommand = null;//Me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null;//Me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//Cadena de conexión

        SqlParameter _SqlParameter = null;
        public clsUsuarios()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// VALIDAR USUARIO
        /// </summary>
        /// <param name="obclsUsuarios">OBJETO USUARIO</param>
        /// <returns>CONFIRMACIÓN</returns>
        public bool getValidarUsuario(Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarUsuario", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@cLogin", obclsUsuarios.stLogin));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPassword", obclsUsuarios.stPassword));

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                if (dsConsulta.Tables[0].Rows.Count > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _SqlConnection.Close();
            }
        }
        /// <summary>
        /// CREAR CUENTA DE USUARIO
        /// </summary>
        /// <param name="obclsUsuarios">OBJETO USUARIO</param>
        /// <returns>MENSAJE DE BD</returns>
        public string setCrearCuenta(Models.clsUsuarios obclsUsuarios, int inOpcion)
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarUsuarios", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                //PARAMETROS DE ENTRADA
                _SqlCommand.Parameters.Add(new SqlParameter("@cLogin", obclsUsuarios.stLogin));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPassword", obclsUsuarios.stPassword));
                _SqlCommand.Parameters.Add(new SqlParameter("@cImagen", obclsUsuarios.stImagen));
                _SqlCommand.Parameters.Add(new SqlParameter("@nOpcion", inOpcion));

                //PARAMETROS DE SALIDA
                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@cMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.VarChar;
                _SqlParameter.Size = 50;

                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();

                return _SqlParameter.Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _SqlConnection.Close();
            }
        }
    }
}

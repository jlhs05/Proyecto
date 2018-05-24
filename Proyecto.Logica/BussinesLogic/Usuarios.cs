using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BussinesLogic
{
    public class Usuarios
    {
        SqlConnection _SqlConnection = null;//me permite establecer comunicacion con BD
        SqlCommand _SqlCommand = null;// me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null;//me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//cadena de conexion
        public Usuarios()
        {   //instanciamos la clase conexion
            Conexion obConexion = new Conexion();
            stConexion = obConexion.getConexion();
        }


        /// <summary>
        /// Valiar usuario
        /// </summary>
        /// <param name="obUsuarios">objeto usuario</param>
        /// <returns>confirmacion</returns>
        public bool getValidarUsuario(Models.Usuarios obUsuarios)
        {
            try
            {
                DataSet dsConsulta = new DataSet();//DATASET es unconjunto de datos que me permite atrapar informacion desde SQL
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarUsuario",_SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@cLogin",obUsuarios.Login));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPassword", obUsuarios.Password));
                //ejectua el SP con los parametros almacenados
                //ExecuteNonQuery no retorna nadamas , mas que el # de registros afectados
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);
                //consultamos que la tabla contenga registros
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
     


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

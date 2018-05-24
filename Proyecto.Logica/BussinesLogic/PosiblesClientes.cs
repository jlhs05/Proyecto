using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BussinesLogic
{

    public class PosiblesClientes
    {
        SqlConnection _SqlConnection = null;//me permite establecer comunicacion con BD
        SqlCommand _SqlCommand = null;// me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null;//me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//cadena de conexion

        SqlParameter _SqlParameter = null;


        public PosiblesClientes()
        {   //instanciamos la clase conexion
            Conexion obConexion = new Conexion();
            stConexion = obConexion.getConexion();
        }


        /// <summary>
        /// consulta de posibles clientes
        /// </summary>
        /// <returns>Registro de posibles clientes</returns>
        public DataSet getConsultarPosiblesClientes()
        {
            try
            {
                DataSet dsConsulta = new DataSet();//DATASET es unconjunto de datos que me permite atrapar informacion desde SQL
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarPosiblesClientes", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                //ejectua el SP con los parametros almacenados
                //ExecuteNonQuery no retorna nadamas , mas que el # de registros afectados
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);
              
                return dsConsulta;


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
        /// aadministrar posibles clientes
        /// </summary>
        /// <param name="objposiblesClientes">objeto</param>
        /// <param name="noOpcion">mensaje de operacion</param>
        /// <returns></returns>
        public string SetAdministrarPosiblesClientes(Models.PosiblesClientes objposiblesClientes,int noOpcion)
        {
            try
            {               
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarPosiblesClientes", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@Identificacion", objposiblesClientes.Identificacion));
                _SqlCommand.Parameters.Add(new SqlParameter("@Empresa", objposiblesClientes.Empresa));
                _SqlCommand.Parameters.Add(new SqlParameter("@PrimerNombre",objposiblesClientes.PrimerNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@SegundoNombre", objposiblesClientes.SegundoNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@PrimerApellido", objposiblesClientes.PrimerApellido));
                _SqlCommand.Parameters.Add(new SqlParameter("@SegundoApellido", objposiblesClientes.SegundoApellido));
                _SqlCommand.Parameters.Add(new SqlParameter("@Direccion", objposiblesClientes.Direccion));
                _SqlCommand.Parameters.Add(new SqlParameter("@Telefono", objposiblesClientes.Telefono));
                _SqlCommand.Parameters.Add(new SqlParameter("@Correo", objposiblesClientes.Correo));
                _SqlCommand.Parameters.Add(new SqlParameter("@noOpcion", noOpcion));

               
                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@cMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType=SqlDbType.VarChar;
                _SqlParameter.Size = 50;

                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();


                return _SqlParameter.Value.ToString();


            }
            catch (Exception ex){throw ex;}
            finally
            {_SqlConnection.Close(); }
        }
    }
}

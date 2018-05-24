using System.Configuration;

namespace Proyecto.Logica.BussinesLogic
{
    public class Conexion
    {
        /// <summary>
        /// Obtiene conexion a BD
        /// </summary>
        /// <returns>CADENA DE CONEXION</returns>

        public string getConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}

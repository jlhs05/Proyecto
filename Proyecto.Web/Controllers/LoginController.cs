using Proyecto.Logica.BussinesLogic;
using System;

namespace Proyecto.Web.Controllers
{

    public class LoginController
    {

        /// <summary>
        /// valida usuario
        /// /// </summary>
        /// <param name="obUsuarios">objeto usuario</param>
        /// <returns>Confirmacion</returns>
        public bool getValidarUsuarioController(Logica.Models.Usuarios obUsuarios)
        {

            try
            {
                Usuarios obUsuario = new Usuarios();
                return obUsuario.getValidarUsuario(obUsuarios);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
using Proyecto.Logica.Models;
using System;

namespace Proyecto.Web.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ctrl+k+c comentar
            //ctrl +k+u descomentar
            //Lo que se ejecuta tan pronto carga la página
            //if(!IsPostBack)
            //ClientScript.RegisterStartupScript(this.GetType(), "alert","<script>swal ('Buen trabajo','see realizo proceso con exito','success')</script>");
            

        }

        protected void bntAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtEmail.Text)) stMensaje += "Ingrese Email,";
                if (string.IsNullOrEmpty(txtPassword.Text)) stMensaje += "Ingrese Password,";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));
                
                //DEFINO OBJETO CON PROPIEDADES
                Usuarios obUsuarios = new Usuarios
                {
                    Login = txtEmail.Text,
                    Password= txtPassword.Text
                };

                //INSTANCION CONTROLLADOR
                Controllers.LoginController obLoginController = new Controllers.LoginController();
                bool blBandera = obLoginController.getValidarUsuarioController(obUsuarios);

                if (blBandera is true)
                {
                    Response.Redirect("../Index/Index.aspx");//REDIRECCIONO
                }
                else
                {
                    throw new Exception("Usuario o Password incorrectos"); //excepcion controlada
                }

            }  
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>swal ('Error!','"+ex.Message+"!','error')</script>");

            }

        }
    }
}
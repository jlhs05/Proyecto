using Proyecto.Web.Controllers;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.PosiblesClientes
{
    public partial class PosiblesClientes : System.Web.UI.Page
    {
        #region Metodos y Funciones
        /// <summary>
        /// OBTIENE CONSULTA POSIBLES CLIENTES
        /// </summary>
        void getPosiblesClientes()
        {
            try
            {
                PosiblesClientesController objPosiblesClientesController = new PosiblesClientesController();
                DataSet dsConsulta = objPosiblesClientesController.getPosiblesClientesController();

                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    gvwDatos.DataSource = dsConsulta;
                }
                else
                {
                    gvwDatos.DataSource = null;
                }
                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>swal ('Error!','" + ex.Message + "!','error')</script>");
            }

        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPosiblesClientes();
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtIdentificacion.Text)) stMensaje += "Ingrese Identificacion,";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                Logica.Models.PosiblesClientes objPosiblesClientes = new Logica.Models.PosiblesClientes
                {
                    Identificacion = Convert.ToInt64(txtIdentificacion.Text),
                    Empresa = txtEmpresa.Text,
                    PrimerNombre =txtPrimerNombre.Text,
                    SegundoNombre= txtSegundoNombre.Text,
                    PrimerApellido= txtPrimerApellido.Text,
                    SegundoApellido= txtSegundoApellido.Text,
                    Direccion = txtDireccion.Text,
                    Telefono= txtTelefono.Text,
                    Correo= txtCorreo.Text,
                };
                PosiblesClientesController objPosiblesClientesController = new PosiblesClientesController();
                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>swal ('Excelente','" + objPosiblesClientesController.SetAdministrarPosiblesClientesController(objPosiblesClientes, Convert.ToInt32(lblOpcion.Text)) + "!','success')</script>");
                //dejamos en  blanco al opcion !
                lblOpcion.Text = txtIdentificacion.Text = txtEmpresa.Text =
                 txtPrimerNombre.Text= txtSegundoNombre.Text = txtPrimerApellido.Text = 
                 txtSegundoApellido.Text =txtDireccion.Text =txtTelefono.Text=txtCorreo.Text = string.Empty;

                getPosiblesClientes();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script> swal ('Error!','" + ex.Message + "!','error')</script>");

            }

        }

        protected void gvwDatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                //CommandArgument nos dice de que fila se dio click
                int inIndice = Convert.ToInt32(e.CommandArgument);
                //para saber que boton se presiono e.CommandName
                if (e.CommandName.Equals("Editar"))
                {
                    lblOpcion.Text = "2";
                    //accede a un control web dentro de un grid
                    //el tipo de control que se va buscar es un "Label", que esta dentro de un Grid, en la fila
                    txtIdentificacion.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblIdentificacion")).Text;
                    txtEmpresa.Text = gvwDatos.Rows[inIndice].Cells[1].Text.Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtPrimerNombre.Text = gvwDatos.Rows[inIndice].Cells[2].Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[2].Text; ;
                    txtSegundoNombre.Text = gvwDatos.Rows[inIndice].Cells[3].Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[3].Text; ;
                    txtPrimerApellido.Text = gvwDatos.Rows[inIndice].Cells[4].Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[4].Text; ;
                    txtSegundoApellido.Text = gvwDatos.Rows[inIndice].Cells[5].Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[5].Text; ;
                    txtDireccion.Text = gvwDatos.Rows[inIndice].Cells[6].Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[6].Text; ;
                    txtTelefono.Text = gvwDatos.Rows[inIndice].Cells[7].Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[7].Text; ;
                    txtCorreo.Text = gvwDatos.Rows[inIndice].Cells[8].Equals("&nbs;") ? string.Empty : gvwDatos.Rows[inIndice].Cells[8].Text; ;
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    //declaro un objecto y asigno la propiedad(Identificador)
                    Logica.Models.PosiblesClientes objPosiblesClientes = new Logica.Models.PosiblesClientes
                    {
                        Identificacion = Convert.ToInt64(((Label)gvwDatos.Rows[inIndice].FindControl("lblIdentificacion")).Text),
                        Empresa = string.Empty,
                        PrimerNombre= string.Empty,
                        SegundoNombre = string.Empty,
                        PrimerApellido= string.Empty,
                        SegundoApellido = string.Empty,
                        Direccion= string.Empty,
                        Telefono = string.Empty,
                        Correo = string.Empty
                };
                    PosiblesClientesController objPosiblesClientesController = new Controllers.PosiblesClientesController();

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>swal ('Excelente!','" + objPosiblesClientesController.SetAdministrarPosiblesClientesController(objPosiblesClientes, Convert.ToInt32(lblOpcion.Text)) + "!','success')</script>");
                    //dejamos en  blanco al opcion !
                    lblOpcion.Text = string.Empty;
                    getPosiblesClientes();
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>swal ('Error!','" + ex.Message + "!','error')</script>");

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtIdentificacion.Text = txtEmpresa.Text =
            txtPrimerNombre.Text = txtSegundoNombre.Text = txtPrimerApellido.Text =
            txtSegundoApellido.Text = txtDireccion.Text = txtTelefono.Text = txtCorreo.Text = string.Empty;
        }
        #endregion
    }
}
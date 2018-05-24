using Proyecto.Logica.BussinesLogic;
using System;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class PosiblesClientesController
    {

        /// <summary>
        /// OBTIENE POSIBLES CLIENTES
        /// </summary>
        /// <returns> REGISTROS DE POSIBLES CLIENTES</returns>
        public DataSet getPosiblesClientesController()
        {
            try
            {
                PosiblesClientes objPosiblesClientes = new PosiblesClientes();
                return objPosiblesClientes.getConsultarPosiblesClientes();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        /// <summary>
        /// administra posibles Clientes
        /// </summary>
        /// <param name="objPosiblesClientes">Objeto</param>
        /// <param name="noOpcion">Opcion de ejecucion</param>
        /// <returns>Mensaje de proceso</returns>
        public string SetAdministrarPosiblesClientesController(Logica.Models.PosiblesClientes objPosiblesClientes,int noOpcion )
        {
            try
            {
                PosiblesClientes objPosiblesCliente = new PosiblesClientes();
                return objPosiblesCliente.SetAdministrarPosiblesClientes(objPosiblesClientes, noOpcion);
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Credito_VerSolicitud : System.Web.UI.Page
{
    private String idSolicitud;
    private String idCliente;

    protected void Page_Load(object sender, EventArgs e)
    {
        idSolicitud = Request.QueryString["idSolicitud"];
        lblIdSolicitud.Text = idSolicitud;
        idCliente = Request.QueryString["idCliente"];
        lblIdCliente.Text = idCliente;

        DataClassesDataContext scc = new DataClassesDataContext();

        try
        {
            //REalizar la consulta con link
            Cliente obj_Cliente = (
                                  from a in scc.Cliente
                                  where a.idCliente == Convert.ToInt32(idCliente)
                                  select a
                                 ).Single();//solo un dato
            //si encuentra ese cliente  a las cajas de txt se les asignan los valores
            txt_name.Text = obj_Cliente.nomCliente;
            txt_app.Text = obj_Cliente.apCliente;
            txt_apm.Text = obj_Cliente.amCliente;

        }
        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();
        }

        try
        {
            //REalizar la consulta con link
            solicitud obj_Solicitud = (
                                  from a in scc.solicitud
                                  where a.idCliente == Convert.ToInt32(idCliente)
                                  select a
                                 ).Single();//solo un dato
            //si encuentra ese cliente  a las cajas de txt se les asignan los valores
            txt_cSolicitada.Text = Convert.ToString(obj_Solicitud.cSolicitada);
            txt_modalidad.Text = Convert.ToString(obj_Solicitud.idModalidad);
            txt_fInicio.Text = obj_Solicitud.fechaInicio;
            txt_fFin.Text = obj_Solicitud.fechaFin;
            txt_ingresoMe.Text = Convert.ToString(obj_Solicitud.ingresoMensual);
            txt_gastoMens.Text = Convert.ToString(obj_Solicitud.gastoMensual);
            txt_desc.Text = obj_Solicitud.descripcionCredito;
            txt_garantias.Text = obj_Solicitud.descripcionGarantias;
            txt_montoVa.Text = Convert.ToString(obj_Solicitud.montoValuado);
            txt_credMax.Text = Convert.ToString(obj_Solicitud.creditoMaximo);
            txt_estatus.Text = obj_Solicitud.estatus;

        }
        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();
        }

    }
}
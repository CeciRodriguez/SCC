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
    }
}
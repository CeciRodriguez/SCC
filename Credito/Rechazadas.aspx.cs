using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Credito_Rechazadas : System.Web.UI.Page
{

    public string idSolicitud;

    public static string[] ARRAYLISTADO;
    public static string QUERYLISTADO;

    protected void Page_Load(object sender, EventArgs e)
    {
        idSolicitud = Request.QueryString["idSolictud"]; //obtiene el id del Pedimento (como si fuera un arreglo)

        #region Inicializa lISTADO
        /******************************************VALIDADOS*****************************************/
        ARRAYLISTADO = new string[] { "Solicitud", "Cliente", "Modalidad de pago", "Cantidad solicitada", "Estatus" };
        QUERYLISTADO = "select so.idSolicitud, clie.nomCliente+' '+clie.apCliente+' '+clie.amCliente, mo.descripcion, " +
            " so.cSolicitada, so.estatus " +
            " from cliente clie inner join solicitud so on clie.idCliente=so.idCliente " +
            " inner join modalidad mo on so.idModalidad=mo.idModalidad" +
            " where so.estatus='Rechazado' ";

        MuestraResultados resultados = new MuestraResultados();
        resultados.setDatos(ARRAYLISTADO, QUERYLISTADO);
        lblListado.Text = resultados.ConstruyeListado();

        /********************************************************************************************/
        #endregion
    }
    #region Listado

    [WebMethod]
    public static string ConstruirListado()
    {
        MuestraResultados resultados = new MuestraResultados();
        resultados.setDatos(ARRAYLISTADO, QUERYLISTADO);
        return resultados.ConstruyeListado();
    }
    #endregion
}
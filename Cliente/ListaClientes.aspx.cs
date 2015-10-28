using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Cliente_ListaClientes : System.Web.UI.Page
{

    public string idCliente;

    public static string[] ARRAYLISTADO;
    public static string QUERYLISTADO;

    protected void Page_Load(object sender, EventArgs e)
    {
        idCliente = Request.QueryString["idCliente"]; //obtiene el id del Pedimento (como si fuera un arreglo)

        #region Inicializa lISTADO
        /******************************************VALIDADOS*****************************************/
        ARRAYLISTADO = new string[] { "Nombre", "Apellido paterno", "Apellido materno", "IFE","Modificar","Solicitud" };
        QUERYLISTADO = "select clie.nomCliente, clie.apCliente, clie.amCliente, clie.numIFE, '<a href=\"ModCliente.aspx?idCliente='+convert(varchar,clie.idCliente)+'\">'+'Click aqui','<a href=\"../Credito/Solicitud.aspx?idCliente='+convert(varchar,clie.idCliente)+'\">'+'Ver' " +
            " from cliente clie ";

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
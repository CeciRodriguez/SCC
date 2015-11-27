using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class Balance_Balance : System.Web.UI.Page
{

    public static string[] ARRAYTOTAL;
    public static string QUERYTOTAL;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Inicializa 
        /******************************************VALIDADOS*****************************************/
        ARRAYTOTAL = new string[] {""};
        QUERYTOTAL = "select SUM(cSolicitada) from solicitud where estatus='Aceptado'";

        MuestraResultados resultados = new MuestraResultados();
        resultados.setDatos(ARRAYTOTAL, QUERYTOTAL);
        lblBalance.Text = resultados.ConstruyeListado();

        /********************************************************************************************/
        #endregion
    }

    [WebMethod]
    public static string ConstruirListado()
    {
        MuestraResultados resultados = new MuestraResultados();
        resultados.setDatos(ARRAYTOTAL, QUERYTOTAL);
        return resultados.ConstruyeListado();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
       Response.Redirect("Balance.aspx");
    }
    protected void txt_name_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Chart1_Load(object sender, EventArgs e)
    {

    }
}
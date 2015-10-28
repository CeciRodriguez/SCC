using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Sesion : System.Web.UI.Page
{
    /**
    protected override void InitializeCulture()
    {
        string culture = Request.QueryString["lang"];
        if (string.IsNullOrEmpty(culture))
            culture = "Auto";
        UICulture = culture;
        Culture = culture;
        if (culture != "Auto")
        {

            UICulture = culture;

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

        }
        base.InitializeCulture();
    }*/


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void boton_click(object sender, EventArgs e)
    {
        DataClassesDataContext scc = new DataClassesDataContext();

        String user = usuario.Text.Trim();
        String pass = contrasenia.Text.Trim();

        if (user.Equals("brean") && pass.Equals("brean2015f"))
        {
            Response.Redirect("Cliente/Cliente.aspx");
        }
        if (!user.Equals("brean") && !pass.Equals("brean2015f"))
        {
            lbl_Mensaje.Text = "Los datos son incorrectos";
        }
        if (!user.Equals("brean") && pass.Equals("brean2015f"))
        {
            lbl_Mensaje.Text = "El usuario es incorrecto";
        }
        if (user.Equals("brean") && !pass.Equals("brean2015f"))
        {
            lbl_Mensaje.Text = "La contraseña es incorrecta";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Cliente_EStadoCuenta : System.Web.UI.Page
{
    private static String CADENA_VACIA = "";
    private String regexpPago = @"^[0-9]*$";
    private String idCliente;

    protected void Page_Load(object sender, EventArgs e)
    {

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
            txt_estatus.Text = obj_Solicitud.estatus;

        }
        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();
        }
        
    }

   protected void btn_Estado_Click(object sender, EventArgs e)
{
//System.Web.Exception opcional para manejar datos de respuesta HTTP a un cliente
Response.Clear();
Response.ContentType ="application/pdf";
Response.Cache.SetCacheability(HttpCacheability.NoCache);

//Para crear una instancia de documento de iTextSharp con el tamaño de página y tamaño de margenes correspondientes
Document doc = new Document(PageSize.LETTER.Rotate(), 10, 10, 10, 10);
//La ruta en donde será guardado el pdf dentro del servidor
String path = this.Server.MapPath(".") + "\\EstadoCuenta.pdf";

//Utilizamos System.IO para crear o sobreescribir el archivo si existe
FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

//iTextSharp para escribir en el documento PDF
PdfWriter.GetInstance(doc, file);
doc.Open();
string imageURL = Server.MapPath(".") + "..\\tabla.png";
iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(imageURL);
imagen.BorderWidth = 0;
imagen.Alignment = Element.ALIGN_LEFT;
float percentage = 0.0f;
percentage = 700 / imagen.Width;
percentage = 400 / imagen.Height;
imagen.ScalePercent(percentage * 100);

//Agregamos  el texto que esta dentro de la etiqueta
     //Se pueden agregar varios solamente añadiendo varias sentencias doc.Add(…)    
doc.Add(new Paragraph("Nombre del Cliente: "+txt_name.Text+" "+txt_app.Text+" "+txt_apm.Text));
doc.Add(new Paragraph("Cantidad solicitada: " + txt_cSolicitada.Text));
doc.Add(new Paragraph("Fecha de inicio: " + txt_fInicio.Text));
doc.Add(new Paragraph("Fecha de fin: " + txt_fFin.Text));
doc.Add(new Paragraph(""));
doc.Add(new Paragraph("Estatus de crédito: Activo"));
doc.Add(new Paragraph(""));
doc.Add(imagen);

doc.Close();

Process.Start(path);
Response.Redirect("ListaClientesE.aspx");
}


    private int validaForm()
    {
        int result = 0;


        return result;
    }
    private int valdidaRegxp(String regexp, Label lbl, String msg, String val)
    {
        Regex reg = new Regex(regexp);
        Match match = reg.Match(val);
        if (!match.Success)
        {
            lbl.Text = msg;
            return 1;
        }
        lbl.Text = CADENA_VACIA;
        return 0;
    }
}
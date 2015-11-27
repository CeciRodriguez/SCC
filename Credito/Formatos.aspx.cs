using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Credito_FormatoGarantia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Garantia_Click(object sender, EventArgs e)
    {
        //System.Web.Exception opcional para manejar datos de respuesta HTTP a un cliente
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //Para crear una instancia de documento de iTextSharp con el tamaño de página y tamaño de margenes correspondientes
        Document doc = new Document(PageSize.LETTER.Rotate(), 10, 10, 10, 10);
        //La ruta en donde será guardado el pdf dentro del servidor
        String path = this.Server.MapPath(".") + "\\Garantia.pdf";

        //Utilizamos System.IO para crear o sobreescribir el archivo si existe
        FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

        //iTextSharp para escribir en el documento PDF
        PdfWriter.GetInstance(doc, file);
        doc.Open();
        string imageURL = Server.MapPath(".") + "..\\garantia.png";
        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(imageURL);
        imagen.BorderWidth = 0;
        imagen.Alignment = Element.ALIGN_RIGHT;
        float percentage = 0.0f;
        percentage = 800 / imagen.Width;
        imagen.ScalePercent(percentage * 100);

        //Agregamos  el texto que esta dentro de la etiqueta
        //Se pueden agregar varios solamente añadiendo varias sentencias doc.Add(…)    
        doc.Add(imagen);

        doc.Close();

        Process.Start(path);
        Response.Redirect("Formatos.aspx");
    }

    protected void btn_Pagare_Click(object sender, EventArgs e)
    {
        //System.Web.Exception opcional para manejar datos de respuesta HTTP a un cliente
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //Para crear una instancia de documento de iTextSharp con el tamaño de página y tamaño de margenes correspondientes
        Document doc = new Document(PageSize.LETTER.Rotate(), 10, 10, 10, 10);
        //La ruta en donde será guardado el pdf dentro del servidor
        String path = this.Server.MapPath(".") + "\\Pagare.pdf";

        //Utilizamos System.IO para crear o sobreescribir el archivo si existe
        FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

        //iTextSharp para escribir en el documento PDF
        PdfWriter.GetInstance(doc, file);
        doc.Open();
        string image = Server.MapPath(".") + "..\\pagare.png";
        iTextSharp.text.Image ima = iTextSharp.text.Image.GetInstance(image);
        ima.BorderWidth = 0;
        ima.Alignment = Element.ALIGN_RIGHT;
        float percentage = 0.0f;
        percentage = 750 / ima.Width;
        ima.ScalePercent(percentage * 100);

        //Agregamos  el texto que esta dentro de la etiqueta
        //Se pueden agregar varios solamente añadiendo varias sentencias doc.Add(…)    
        doc.Add(ima);

        doc.Close();

        Process.Start(path);
        Response.Redirect("Formatos.aspx");
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

public partial class Cliente_EStadoCuenta : System.Web.UI.Page
{

    private void btn_Agregar_Click(object sender, EventArgs e)
    {

        Document document = new Document();

        PdfWriter.GetInstance(document,

                      new FileStream("Prueba.pdf",

                             FileMode.OpenOrCreate));


        document.Open();

        document.Add(new Paragraph("Este es mi primer PDF al vuelo"));

        document.Close();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        
    }
   
}
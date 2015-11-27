using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


public partial class Credito_Solicitud : System.Web.UI.Page
{
    //Validaciones
    private static String CADENA_VACIA = "";
    private String regexpNom = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpApp = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpApm = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpFecNa = @"^[a-záéíóúñ]*$";
    private String regexpNumIFE = @"^[1-9]{13}$";
    private String regexpDom = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpNumDom = @"^[1-9]{4}[a-zA-ZÁÉÍÓÚÑ]{1}$";
    private String regexpSenPar = @"^[a-zA-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpTel = @"^[1-9]{10}$";
    private String regexpTela = @"^[1-9]{10}$";

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
        // txt_Nombre.Text = "";
    }

    //***************************** MÉTODO INSERTAR ******************************

    protected void btn_Solicitar_Click(object sender, EventArgs e)
    {
        DataClassesDataContext scc = new DataClassesDataContext();

        solicitud obj_Solicitud = new solicitud();

        try
        {
            //Validacion
            cleanMsgTxt();

            if (validaForm() == 0)
            {
                obj_Solicitud.idCliente = Convert.ToInt32(idCliente);
                obj_Solicitud.cSolicitada = Convert.ToInt32(txt_cSolicitada.Text.Trim());
                obj_Solicitud.idModalidad = Convert.ToByte(txt_modalidad.SelectedValue);
                //obj_Cliente.fechaNac = txt_fn.SelectedDate.ToShortDateString(
                obj_Solicitud.fechaInicio = txt_fInicio.SelectedDate.ToShortDateString();
                obj_Solicitud.fechaFin = txt_fFin.SelectedDate.ToShortDateString();
                obj_Solicitud.ingresoMensual = Convert.ToDecimal(txt_ingresoMe.Text.Trim());
                obj_Solicitud.gastoMensual = Convert.ToDecimal(txt_gastoMens.Text.Trim());
                obj_Solicitud.descripcionCredito = txt_desc.Text.Trim();
                obj_Solicitud.descripcionGarantias = txt_garantias.Text.Trim();
                obj_Solicitud.montoValuado =  Convert.ToDecimal(txt_montoVa.Text.Trim());

                if (Convert.ToDecimal(txt_ingresoMe.Text.Trim()) > Convert.ToDecimal(txt_gastoMens.Text.Trim())
                    & Convert.ToDecimal(txt_montoVa.Text.Trim()) / 3 >= Convert.ToInt32(txt_cSolicitada.Text.Trim()))
                {
                    decimal monto=0;
                    monto=Convert.ToDecimal(txt_montoVa.Text.Trim()) /3;

                    obj_Solicitud.creditoMaximo = monto;

                    obj_Solicitud.estatus = "Aceptado";
                }
                else {

                    decimal monto = 0;
                    monto = Convert.ToDecimal(txt_montoVa.Text.Trim()) / 3;

                    obj_Solicitud.creditoMaximo = monto;
                    obj_Solicitud.estatus = "Rechazado";
                }

                

                scc.solicitud.InsertOnSubmit(obj_Solicitud); //uso del metodo

                scc.SubmitChanges(); //cambioss

                lbl_Mensaje.Text = "Su solicitud ha sido registrada";

            }

        }
        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();

        }
    }



    //Validacion

    private void cleanMsgTxt()
    {
       // lblFn.Text = CADENA_VACIA;


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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cliente.aspx");
    }
    protected void txt_name_TextChanged(object sender, EventArgs e)
    {

    }
}
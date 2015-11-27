using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Cliente_ModCliente : System.Web.UI.Page
{
    //Validaciones
    private static String CADENA_VACIA = "";
    private String regexpNom = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpApp = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpApm = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpNumIFE = @"^[1-9]{13}$";
    private String regexpDom = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpNumDom = @"^[1-9]{4}[a-zA-ZÁÉÍÓÚÑ]{1}$";
    private String regexpSenPar = @"^[a-zA-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpTel = @"^[1-9]{10}$";
    private String regexpTela = @"^[1-9]{10}$";

    public string idCliente;

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
            txt_nameM.Text = obj_Cliente.nomCliente;
            txt_appM.Text = obj_Cliente.apCliente;
            txt_apmM.Text = obj_Cliente.amCliente;
            txt_sexoM.Text = obj_Cliente.idSexo.ToString();
           // obj_Cliente.fechaNac = txt_fn.SelectedDate.ToShortDateString();
            txt_fnM.Text = obj_Cliente.fechaNac;
            txt_IFEM.Text = obj_Cliente.numIFE;
            txt_DomM.Text = obj_Cliente.domicilio;
            txt_NumM.Text = obj_Cliente.num;
            txt_casaM.Text = obj_Cliente.descripCasa;
            txt_telM.Text = obj_Cliente.telefono;
            txt_telaM.Text = obj_Cliente.telefonoAlt;

        }

        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();
        }
        // txt_Nombre.Text = "";
    }

    
    protected void btn_Modificar_Click(object sender, EventArgs e)
    {
        DataClassesDataContext scc = new DataClassesDataContext();
        try
        {
            cleanMsgTxt();

            //Validacion
            if (validaForm() == 0)
            {
               Cliente obj_Cliente = (
                                      from a in scc.Cliente
                                    where a.idCliente == Convert.ToInt32(idCliente)
                                      select a
                                     ).Single();//solo un dato

                obj_Cliente.domicilio = txt_DomM.Text.Trim();
                obj_Cliente.num = txt_NumM.Text.Trim();
                obj_Cliente.descripCasa = txt_casaM.Text.Trim();
                obj_Cliente.telefono = txt_telM.Text.Trim();
                obj_Cliente.telefonoAlt = txt_telaM.Text.Trim();

                scc.SubmitChanges();

                lbl_Mensaje.Text = "El cliente se modificó correctamente";
                Response.Redirect("ListaClientes.aspx");
            }
        }
        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();
        }

        txt_nameM.Text = "";
        txt_appM.Text = "";
        txt_apmM.Text = "";
        txt_fnM.Text = "";
        txt_IFEM.Text = "";
        txt_DomM.Text = "";
        txt_NumM.Text = "";
        txt_casaM.Text = "";
        txt_telM.Text = "";
        txt_telaM.Text = "";
        
    }

    //Validacion

    private void cleanMsgTxt()
    {
        lblNom.Text = CADENA_VACIA;
        lblApp.Text = CADENA_VACIA;
        lblApm.Text = CADENA_VACIA;
        lblSexo.Text = CADENA_VACIA;
        lblFn.Text = CADENA_VACIA;
        lblIFE.Text = CADENA_VACIA;
        lblDom.Text = CADENA_VACIA;
        lblNum.Text = CADENA_VACIA;
        lblCasa.Text = CADENA_VACIA;
        lblTel.Text = CADENA_VACIA;
        lblTela.Text = CADENA_VACIA;

    }
    private int validaForm()
    {
        int result = 0;
        result += valdidaRegxp(regexpNom, lblNom, "El nombre no puede ir vacio y debe comenzar con mayúscula", txt_nameM.Text);

        result += valdidaRegxp(regexpApp, lblApp, "El apellido paterno no puede ir vacio y debe comenzar con mayúscula", txt_appM.Text);

        result += valdidaRegxp(regexpApm, lblApm, "El apellido materno no puede ir vacio y debe comenzar con mayúscula", txt_apmM.Text);

        result += valdidaRegxp(regexpNumIFE, lblIFE, "El numero de IFE no puede ir vacio y contiene 13 dígitos", txt_IFEM.Text);

        result += valdidaRegxp(regexpDom, lblDom, "El domicilio no puede ir vacio y debe comenzar con mayúscula", txt_DomM.Text);

        result += valdidaRegxp(regexpNumDom, lblNum, "El numero de domicilio no puede ir vacio, máximo 4 dígitos", txt_NumM.Text);

        result += valdidaRegxp(regexpTel, lblTel, "El numero de teléfono no puede ir vacio y contiene 10 dígitos", txt_telM.Text);

        result += valdidaRegxp(regexpTela, lblTela, "Debes ingresar un numero adicional no puede ir vacio y contiene 10 dígitos", txt_telaM.Text);


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
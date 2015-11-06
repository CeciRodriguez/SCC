<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" 
CodeFile="Rechazadas.aspx.cs" Inherits="Credito_Rechazadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Styles/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/menu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styles.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
    <script src="../js/Aceptadas.js" type="text/javascript"></script>
    <script src="../js/Cliente.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
    <script src="../js/DataTable.js" type="text/javascript"></script>
    <script src="../js/dataTable-es.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.min.js" type="text/javascript"></script>
    <style>
	body{
		font: 12px "Trebuchet MS", sans-serif;
		
	}
	.demoHeaders {
		margin-top: 2em;
	}
	#dialog-link {
		padding: .4em 1em .4em 20px;
		text-decoration: none;
		position: relative;
	}
	#dialog-link span.ui-icon {
		margin: 0 5px 0 0;
		position: absolute;
		left: .2em;
		top: 50%;
		margin-top: -8px;
	}
	#icons {
		margin: 0;
		padding: 0;
	}
	#icons li {
		margin: 2px;
		position: relative;
		padding: 4px 0;
		cursor: pointer;
		float: left;
		list-style: none;
	}
	#icons span.ui-icon {
		float: left;
		margin: 0 4px;
	}
	.fakewindowcontain .ui-widget-overlay {
		position: absolute;
	}
	select {
		width: 200px;
	}

/*aspectos generales: bordes y color de fondo de calculadora*/
.calculadora { border: 3px blue ridge; width: 200px;text-align: center;
               background-color: #6499FC; }

/*pantalla de visualización: bordes, posición, color de fondo, estilo letra.*/
#textoPantalla { width: 180px; border: 2px black solid; text-align: right; 
                 position: relative; left: 5px;  padding: 0px 5px;
                 background-color: white; font-family: "courier new"; 
                 overflow: hidden;}

/*botones normales: anchura y margen*/
.calculadora [type=button] { width: 35px; padding: 0;  }
/*botones especiales*/
.calculadora input.largo { color: red; width: 60px; }



.button { /* clase general */
  border: 1px solid #22269B;
  color: #555;
  display: inline-block;
  text-decoration: none;
}

.button.white{
  background: #f5f5f5;
  border-color: #22269B #373CD1 #4E54F0;
  box-shadow: 0 1px 1px #1A1D69, inset 0 1px 0 #fbfbfb;
  color: #555;
  text-shadow: 0 1px 0 #fff;
  background: -moz-linear-gradient(top,  #f9f9f9, #f0f0f0);
  background: -webkit-linear-gradient(top,  #f9f9f9, #f0f0f0);
  background: o-linear-gradient(top,  #f9f9f9, #f0f0f0);
  background: ms-linear-gradient(top,  #f9f9f9, #f0f0f0);
  background: linear-gradient(top,  #f9f9f9, #f0f0f0);
  filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#f9f9f9', endColorstr='#f0f0f0');
}

.button.white:hover{
    background: #f4f4f4;
    border-color: #c7c7c7 #c3c3c3 #bebebe;
    box-shadow: 0 1px 1px #ebebeb, inset 0 1px 0 #f3f3f3;
    text-shadow: 0 1px 0 #fdfdfd;
    background: -moz-linear-gradient(top,  #efefef, #f8f8f8);
    background: -webkit-linear-gradient(top,  #efefef, #f8f8f8);
    background: -o-linear-gradient(top,  #efefef, #f8f8f8);
    background: -ms-linear-gradient(top,  #efefef, #f8f8f8);
    background: linear-gradient(top,  #efefef, #f8f8f8);
    filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#efefef', endColorstr='#f8f8f8');
}

#textoPantalla{
	font
}

</style>
    <script>
        window.onload = function () { //Acciones tras cargar la página
            pantalla = document.getElementById("textoPantalla"); //elemento pantalla de salida
            document.onkeydown = teclado; //función teclado disponible
        }
        x = "0"; //guardar número en pantalla
        xi = 1; //iniciar número en pantalla: 1=si; 0=no;
        coma = 0; //estado coma decimal 0=no, 1=si;
        ni = 0; //número oculto o en espera.
        op = "no"; //operación en curso; "no" =  sin operación.

        function numero(xx) { //recoge el número pulsado en el argumento.
            if (x == "0" || xi == 1) { // inicializar un número, 
                pantalla.innerHTML = xx; //mostrar en pantalla
                x = xx; //guardar número
                if (xx == ".") { //si escribimos una coma al principio del número
                    pantalla.innerHTML = "0."; //escribimos 0.
                    x = xx; //guardar número
                    coma = 1; //cambiar estado de la coma
                }
            }
            else { //continuar escribiendo un número
                if (xx == "." && coma == 0) { //si escribimos una coma decimal pòr primera vez
                    pantalla.innerHTML += xx;
                    x += xx;
                    coma = 1; //cambiar el estado de la coma  
                }
                //si intentamos escribir una segunda coma decimal no realiza ninguna acción.
                else if (xx == "." && coma == 1) { }
                //Resto de casos: escribir un número del 0 al 9: 	 
                else {
                    pantalla.innerHTML += xx;
                    x += xx
                }
            }
            xi = 0 //el número está iniciado y podemos ampliarlo.
        }

        function operar(s) {
            ni = x //ponemos el 1º número en "numero en espera" para poder escribir el segundo.
            op = s; //guardamos tipo de operación.
            xi = 1; //inicializar pantalla.
        }

        function igualar() {
            if (op == "no") { //no hay ninguna operación pendiente.
                pantalla.innerHTML = x; //mostramos el mismo número	
            }
            else { //con operación pendiente resolvemos
                sl = ni + op + x; // escribimos la operación en una cadena
                sol = eval(sl) //convertimos la cadena a código y resolvemos
                pantalla.innerHTML = sol //mostramos la solución
                x = sol; //guardamos la solución
                op = "no"; //ya no hay operaciones pendientes
                xi = 1; //se puede reiniciar la pantalla.
            }
        }

        function raizc() {
            x = Math.sqrt(x) //resolver raíz cuadrada.
            pantalla.innerHTML = x; //mostrar en pantalla resultado
            op = "no"; //quitar operaciones pendientes.
            xi = 1; //se puede reiniciar la pantalla 
        }

        function porcent() {
            x = x / 100 //dividir por 100 el número
            pantalla.innerHTML = x; //mostrar en pantalla
            igualar() //resolver y mostrar operaciones pendientes
            xi = 1 //reiniciar la pantalla
        }

        function opuest() {
            nx = Number(x); //convertir en número
            nx = -nx; //cambiar de signo
            x = String(nx); //volver a convertir a cadena
            pantalla.innerHTML = x; //mostrar en pantalla.
        }

        function inve() {
            nx = Number(x);
            nx = (1 / nx);
            x = String(nx);
            pantalla.innerHTML = x;
            xi = 1; //reiniciar pantalla al pulsar otro número.
        }

        function retro() { //Borrar sólo el último número escrito.
            cifras = x.length; //hayar número de caracteres en pantalla
            br = x.substr(cifras - 1, cifras) //info del último caracter
            x = x.substr(0, cifras - 1) //quitar el ultimo caracter
            if (x == "") { x = "0"; } //si ya no quedan caracteres, pondremos el 0
            if (br == ".") { coma = 0; } //Si hemos quitado la coma, se permite escribirla de nuevo.
            pantalla.innerHTML = x; //mostrar resultado en pantalla	 
        }

        function borradoParcial() {
            pantalla.innerHTML = 0; //Borrado de pantalla;
            x = 0; //Borrado indicador número pantalla.
            coma = 0; //reiniciamos también la coma					
        }

        function borradoTotal() {
            pantalla.innerHTML = 0; //poner pantalla a 0
            x = "0"; //reiniciar número en pantalla
            coma = 0; //reiniciar estado coma decimal 
            ni = 0 //indicador de número oculto a 0;
            op = "no" //borrar operación en curso.
        }

        function teclado(elEvento) {
            evento = elEvento || window.event;
            k = evento.keyCode; //número de código de la tecla.
            //teclas númericas del teclado alfamunérico
            if (k > 47 && k < 58) {
                p = k - 48; //buscar número a mostrar.
                p = String(p) //convertir a cadena para poder añádir en pantalla.
                numero(p); //enviar para mostrar en pantalla
            }
            //Teclas del teclado númerico. Seguimos el mismo procedimiento que en el anterior.
            if (k > 95 && k < 106) {
                p = k - 96;
                p = String(p);
                numero(p);
            }
            if (k == 110 || k == 190) { numero(".") } //teclas de coma decimal
            if (k == 106) { operar('*') } //tecla multiplicación
            if (k == 107) { operar('+') } //tecla suma
            if (k == 109) { operar('-') } //tecla resta
            if (k == 111) { operar('/') } //tecla división
            if (k == 32 || k == 13) { igualar() } //Tecla igual: intro o barra espaciadora
            if (k == 46) { borradoTotal() } //Tecla borrado total: "supr"
            if (k == 8) { retro() } //Retroceso en escritura : tecla retroceso.
            if (k == 36) { borradoParcial() } //Tecla borrado parcial: tecla de inicio.
            if (k == 13) { igualar() } //Tecla borrado parcial: tecla de inicio.
        }


        $("#button").button();
        $("#radioset").buttonset();

        $("#dialog").dialog({
            autoOpen: false,
            width: 240,
            buttons: [
		{
		    text: "Ok",
		    click: function () {
		        $(this).dialog("close");
		    }
		}
	]
        });

        // Link to open the dialog
        $("#dialog-link").click(function (event) {
            $("#dialog").dialog("open");
            event.preventDefault();
        });


        // Hover states on the static widgets
        $("#dialog-link, #icons li").hover(
	function () {
	    $(this).addClass("ui-state-hover");
	},
	function () {
	    $(this).removeClass("ui-state-hover");
	}
);
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#ffffff" CssClass="panel">
            <div id='cssmenu'>
                <ul>
                    <li class='active'><a href='#'>Clientes</a>
                        <ul>
                            <li><a href="../Cliente/Cliente.aspx">Registro</a></li>
                            <li><a href="../Cliente/ListaClientes.aspx">Ver clientes</a></li>
                            <li><a href="../Cliente/EStadoCuenta.aspx">Estados de cuenta</a></li>
                        </ul>
                    </li>
                    <li><a href='#'>Créditos</a>
                        <ul>
                            <li><a href='#'>Solicitudes</a>
                                <ul>
                                  <li><a href="Aceptadas.aspx">Aceptadas</a></li>
                                   <li><a href="Rechazadas.aspx">Rechazadas</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <li><a href='#'>Balance</a>
                        <ul>
                            <li><a href='#'>General</a></li>
                            <li><a href='#'>Mensual</a></li>
                        </ul>
                    </li>
                    <li><a href='#'>Contactos</a></li>
                    <li><a href="#" id="dialog-link" class="ui-icon-calculator">
                <span class="ui-icon-calculator"></span><img src="../Imagenes/calculadora.png" width="20px"/> </a></li>

                </ul>
            </div>
            <div>
                <asp:Label ID="lblIdSolicitud" runat="server" CssClass="hide"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblListado" runat="server"></asp:Label>
            </div>
        </asp:Panel>
    </div>
    <!-- ui-dialog -->
    <div id="dialog" title="Calculadora Emergente" class="calculadora">
        <form action="#" id="calculadora">
        <p id="textoPantalla">
            0</p>
        <p>
            <input type="button" class="largo" value="Borrar" onclick="retro()" />
            <input type="button" class="largo" value="CE" onclick="borradoParcial()" />
            <input type="button" class="largo" value="C" onclick="borradoTotal()" />
        </p>
        <p>
            <input type="button" class="button white" value="7" onclick="numero(7)" />
            <input type="button" class="button white" value="8" onclick="numero('8')" />
            <input type="button" class="button white" value="9" onclick="numero('9')" />
            <input type="button" class="button white" value="/" onclick="operar('/')" />
            <input type="button" class="button white" value="Raiz" onclick="raizc()" />
        </p>
        <p>
            <input type="button" class="button white" value="4" onclick="numero('4')" />
            <input type="button" class="button white" value="5" onclick="numero('5')" />
            <input type="button" class="button white" value="6" onclick="numero('6')" />
            <input type="button" class="button white" value="*" onclick="operar('*')" />
            <input type="button" class="button white" value="%" onclick="porcent()" />
        </p>
        <p>
            <input type="button" class="button white" value="1" onclick="numero('1')" />
            <input type="button" class="button white" value="2" onclick="numero('2')" />
            <input type="button" class="button white" value="3" onclick="numero('3')" />
            <input type="button" class="button white" value="-" onclick="operar('-')" />
            <input type="button" class="button white" value="1/x" onclick="inve()" />
        </p>
        <p>
            <input type="button" class="button white" value="0" onclick="numero('0')" />
            <input type="button" class="button white" value="+/-" onclick="opuest()" />
            <input type="button" class="button white" value="." onclick="numero('.')" />
            <input type="button" class="button white" value="+" onclick="operar('+')" />
            <input type="button" class="button white" value="=" onclick="igualar()" />
        </p>
        </form>
    </div>
    <script>

        $("#button").button();
        $("#radioset").buttonset();

        $("#dialog").dialog({
            autoOpen: false,
            width: 240,
            buttons: [
		{
		    text: "Ok",
		    click: function () {
		        $(this).dialog("close");
		    }
		}
	]
        });

        // Link to open the dialog
        $("#dialog-link").click(function (event) {
            $("#dialog").dialog("open");
            event.preventDefault();
        });


        // Hover states on the static widgets
        $("#dialog-link, #icons li").hover(
	function () {
	    $(this).addClass("ui-state-hover");
	},
	function () {
	    $(this).removeClass("ui-state-hover");
	}
);
</script>
</asp:Content>


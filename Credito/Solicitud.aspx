<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="Solicitud.aspx.cs" Inherits="Credito_Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Styles/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/menu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styles.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
    <!-- <script src="../js/Cliente.js" type="text/javascript"></script> -->
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
    <script src="../js/DataTable.js" type="text/javascript"></script>
    <script src="../js/dataTable-es.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#ffffff" CssClass="panel">
            <div id='cssmenu'>
                <ul>
                    <li class='active'><a href='#'>Clientes</a>
                        <ul>
                            <li><a href="../Cliente/Cliente.aspx">Registro</a></li>
                            <li><a href="../Cliente/ListaClientes.aspx">Ver clientes</a></li>
                            <li><a href='#'>Estados de cuenta</a></li>
                        </ul>
                    </li>
                    <li><a href='#'>Créditos</a>
                        <ul>
                            <li><a href="Solicitud.aspx">Solicitudes</a>
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
                    <li><a href="#" id="dialog-link" class="ui-state-default ui-corner-all"><span class="ui-icon-calculator">
                    </span>Calculadora</a></span></a></li>
                </ul>
            </div>
            <table style="width: 100%;">
                <br />
                <tr>
                    <td align="right">
                        <asp:Label ID="lblIdCliente" runat="server" CssClass="hide"></asp:Label>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" Height="20px" MaxLength="50"
                            Width="149px" disabled="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_app" runat="server" CssClass="form-control" Height="20px" MaxLength="50"
                            Width="149px" disabled="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_apm" runat="server" CssClass="form-control" Height="20px" MaxLength="50"
                            Width="149px" disabled="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        Cantidad solicitada: $
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_cSolicitada" runat="server" CssClass="form-control" Height="20px"
                            MaxLength="50" Width="149px"></asp:TextBox>
                        <asp:Label ID="lbl_cSolicitada" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td align="right">
                        <br />
                        Modalidad del crédito:
                    </td>
                    <td>
                        <br />
                        <asp:DropDownList ID="txt_modalidad" runat="server" CssClass="form-control2" DataSourceID="SqlDataSource3"
                            DataTextField="descripcion" DataValueField="idModalidad">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:sccConnectionString %>"
                            SelectCommand="SELECT [idModalidad], [descripcion] FROM [modalidad]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" CssClass="hide"></asp:Label>
                        <br />
                        Fecha inicio:
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_fInicio" runat="server" CssClass="form-control" Height="20px"
                            MaxLength="50" Width="149px"></asp:TextBox>
                    </td>
                    <td align="right">
                        <br />
                        Fecha fin:
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_fFin" runat="server" CssClass="form-control" Height="20px" MaxLength="50"
                            Width="149px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" CssClass="hide"></asp:Label>
                        <br />
                        Ingreso Mensual: $
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_ingresoMe" runat="server" CssClass="form-control" Height="20px"
                            MaxLength="50" Width="149px"></asp:TextBox>
                        <asp:Label ID="lbl_ingresoMe" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td align="right">
                        <br />
                        Gasto Mensual: $
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_gastoMens" runat="server" CssClass="form-control" Height="20px"
                            MaxLength="50" Width="149px"></asp:TextBox>
                        <asp:Label ID="lbl_gastoMens" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        Descripción de crédito:
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control" Height="40px" MaxLength="100"
                            Width="580px"></asp:TextBox>
                        <asp:Label ID="lbl_desc" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        Descripción de las garantías:
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_garantias" runat="server" CssClass="form-control" Height="40px"
                            MaxLength="100" Width="580px"></asp:TextBox>
                        <asp:Label ID="lbl_garantias" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" CssClass="hide"></asp:Label>
                        <br />
                        Monto valuado: $
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_montoVa" runat="server" CssClass="form-control" Height="20px"
                            MaxLength="50" Width="149px"></asp:TextBox>
                        <asp:Label ID="lbl_montoVal" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td align="right">
                        <br />
                        Crédito máximo: $
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_credMax" runat="server" CssClass="form-control" Height="20px"
                            MaxLength="50" Width="149px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                    </td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <center>
                            <asp:Button ID="btn_Solicitar" runat="server" CssClass="btn btn-primary colorMje" OnClick="btn_Solicitar_Click"
                                Text="Solicitar" />
                        </center>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style1">
                    </td>
                    <td class="style1">
                        <asp:Label ID="lbl_Mensaje" runat="server"></asp:Label>
                    </td>
                    <td class="style3">
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

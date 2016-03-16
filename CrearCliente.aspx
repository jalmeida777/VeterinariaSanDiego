<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearCliente.aspx.cs" Inherits="CrearCliente" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="js/jquery.growl.js" type="text/javascript"></script>
<link href="css/jquery.growl.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divBusqueda">
        <table width="100%">
            <tr>
                <td>
                    <h1 class="label">
                        Cliente</h1>
                </td>
            </tr>
        </table>
    </div>
    <div class="toolbar">
        <table width="100%">
            <tr>
                <td width="65">
                    <asp:ImageButton ID="btnGuardar" runat="server" 
                                ImageUrl="~/images/Guardar.jpg" onclick="btnGuardar_Click" />
                    <cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" 
                                ConfirmText="¿Seguro de guardar los datos?" Enabled="True" 
                                TargetControlID="btnGuardar">
                    </cc1:ConfirmButtonExtender>
                </td>
                <td width="65">
                    <asp:ImageButton ID="btnSalir" runat="server" ImageUrl="~/images/Salir.jpg" 
                                onclick="btnSalir_Click" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    
     <table width="100%" runat="server" id="tblCliente"
        
        style="background-image: url('images/form_sheetbg.png'); background-repeat: repeat; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #ddd;" 
        visible="True">
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="15%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td>
            <div class="divDocumento">
                <table width="100%" cellspacing="5" >
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr id="filaCodigo" runat="server" visible = "false">
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
                                </td>
            <td style="padding-left: 5px">
                                <asp:Label ID="lblCodigo" runat="server"></asp:Label>

            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                Tipo de Cliente</td>
            <td style="padding-left: 5px">
                                <asp:DropDownList ID="ddlTipoCliente" runat="server" CssClass="combo" 
                    Width="300px">
                                </asp:DropDownList>

            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                <asp:Label ID="Label30" runat="server" Text="Nombre:"></asp:Label>

                <asp:Label runat="server" Text="*" Font-Bold="True" Font-Size="10pt" 
                            ForeColor="#18AC85" ID="Label41"></asp:Label>

            </td>
            <td style="padding-left: 5px">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="inputNormal" 
                    MaxLength="50" Width="300px"></asp:TextBox>

            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label31" runat="server" Text="Número de Documento:"></asp:Label>

                <asp:Label runat="server" Text="*" Font-Bold="True" Font-Size="10pt" 
                            ForeColor="#18AC85" ID="Label47"></asp:Label>

            </td>
            <td style="padding-left: 5px">
                <table cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td width="120">
                <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>

                        </td>
                        <td>
                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="combo" 
                    Width="180px">
                                </asp:DropDownList>

                        </td>
                    </tr>
                </table>

            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label32" runat="server" Text="Dirección:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="inputNormal" 
                    MaxLength="1000" Width="300px"></asp:TextBox>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label49" runat="server" Text="Provincia:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                                <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="combo" 
                    Width="300px" onselectedindexchanged="ddlProvincia_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                </asp:DropDownList>

            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label50" runat="server" Text="Distrito:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                                <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="combo" 
                    Width="300px">
                                </asp:DropDownList>

            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label33" runat="server" Text="Teléfono:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="inputNormal" 
                    MaxLength="20"></asp:TextBox>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label34" runat="server" Text="Email:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="inputNormal" MaxLength="50" 
                    Width="200px"></asp:TextBox>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label43" runat="server" Text="Celular:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <table cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td width="120">
                <asp:TextBox ID="txtCelular" runat="server" CssClass="inputNormal" 
                    MaxLength="50" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                                <asp:DropDownList ID="ddlCiaCelular" runat="server" CssClass="combo" 
                    Width="180px">
                                </asp:DropDownList>

                        </td>
                    </tr>
                </table>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label37" runat="server" Text="Comentario:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" 
                    Width="210px"></asp:TextBox>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr id="tblFechaRegistro" runat="server" visible="false">
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label42" runat="server" Text="Fecha Registro:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <asp:Label ID="lblFechaRegistro" runat="server"></asp:Label>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr id="tblFechaVisita" runat="server" visible="false">
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label46" runat="server" Text="Ultima Visita:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <asp:Label ID="lblFechaUltimaVisita" runat="server"></asp:Label>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label51" runat="server" Text="Puntos Acumulados:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="50">
                            <asp:Label ID="lblPuntos" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnVerDatallePuntos" runat="server" 
                                ImageUrl="~/images/search.png" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                <asp:Label ID="Label38" runat="server" Text="Estado:"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <asp:CheckBox ID="chkEstado" runat="server" Checked="True" Text="Habilitado" />
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="20">
                &nbsp;</td>
        </tr>
        </table>
        </div>

            </td>
            <td width="15%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td width="15%">
                &nbsp;</td>
        </tr>
      </table>
     
</asp:Content>


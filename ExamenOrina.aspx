<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="ExamenOrina.aspx.cs" Inherits="ExamenOrina" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .style2
    {
        width: 15%;
    }
    .style8
    {
        width: 3px;
    }

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
                        Examen Orina</h1>
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
            <td class="style2">
            &nbsp;</td>
            <td>
            &nbsp;</td>
            <td width="15%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
            &nbsp;</td>
            <td>
                <div class="divDocumento">
                    <table width="100%" cellspacing="5" >
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td colspan="3">
                            &nbsp;</td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label62" runat="server" Text="Código:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label53" runat="server" Text="Especie:" 
                                style="text-align: center"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEspecie" runat="server" CssClass="combo" 
                    Width="180px">
                                </asp:DropDownList>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr id="filaCodigo1" runat="server" visible = "true">
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label52" runat="server" Text="Fecha:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" class="style8">
                                <asp:TextBox ID="txtFechaRegistro" runat="server" 
                                CssClass="inputsFecha" placeholder="Inicio" 
                                        MaxLength="15" Width="120px"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Format="dd/MM/yyyy" TargetControlID="txtFechaRegistro">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="Label58" runat="server" Text="Cuerpo Cetonicos:" 
                                    style="text-align: left"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtCuerpo" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr id="filaCodigo" runat="server" visible = "true">
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label56" runat="server" Text="Color:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" class="style8">
                                <asp:TextBox ID="txtColor" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="Label68" runat="server" Text="Glucosa:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtGlucosa" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr id="filaCodigo2" runat="server" visible = "true">
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label1" runat="server" Text="Turbidez:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" class="style8">
                                <asp:TextBox ID="txtTurbidez" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="Label55" runat="server" Text="Hemoglobina:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtHemoglobina" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label64" runat="server" Text="Densidad:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtDensidad" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="Label65" runat="server" Text="Urobilinogeno:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtUrobilinogeno" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label66" runat="server" Text="Proteinas:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtProteinas" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="Label67" runat="server" Text="Bilirrubina:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtBilirrubina" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                                &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label59" runat="server" Text="PH:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtPH" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="Label63" runat="server" Text="Leucocitos:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtLeucocito" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                                &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label69" runat="server" Text="Otros:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" colspan="3">
                                <asp:TextBox ID="txtOtros" runat="server" TextMode="MultiLine" 
                    Width="448px" Height="51px"></asp:TextBox>
                            </td>
                            <td width="20">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                &nbsp;</td>
                            <td>
                &nbsp;</td>
                            <td colspan="3">
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
            <td class="style2">
            &nbsp;</td>
            <td>
            &nbsp;</td>
            <td width="15%">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearVacunacion.aspx.cs" Inherits="CrearVacunacion" %>

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
    .style4
    {
        width: 111px;
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
                        &nbsp;</h1>
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
                            <td colspan="4">
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
                            <td colspan="4">
                                <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr id="filaCodigo1" runat="server" visible = "true">
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label52" runat="server" Text="Fecha Vacunación:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" class="style8">
                                <asp:TextBox ID="txtFechaVacunacion" runat="server" 
                                CssClass="inputsFecha" placeholder="Inicio" 
                                        MaxLength="15" Width="120px"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Format="dd/MM/yyyy" TargetControlID="txtFechaVacunacion">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="padding-left: 5px">
                                &nbsp;</td>
                            <td style="padding-left: 5px" class="style4">
                                <asp:Label ID="Label53" runat="server" Text="Atendido por:" 
                                style="text-align: justify"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:DropDownList ID="ddlPersonal" runat="server" CssClass="combo" 
                    Width="180px">
                                </asp:DropDownList>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label59" runat="server" Text="Vacunas:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" colspan="4">
                                <asp:DropDownList ID="ddlVacunas" runat="server" CssClass="combo" 
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
                                <asp:Label ID="Label31" runat="server" Text="Marca y N° de Serie:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" colspan="4">
                                <table cellpadding="0" cellspacing="0" class="style1">
                                    <tr>
                                        <td width="120">
                                            <asp:TextBox ID="txtGeneral" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
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
                                <asp:Label ID="Label32" runat="server" Text="Revacunar a los :"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtDiasRev" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="68px"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="Label63" runat="server" Text="dias"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" colspan="2">
                                &nbsp;</td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                                <asp:Label ID="Label64" runat="server" Text="Fecha Revacunación:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" colspan="4">
                                <asp:TextBox ID="txtFechaRevacunacion" runat="server" 
                                CssClass="inputsFecha" placeholder="Inicio" 
                                        MaxLength="15" Width="120px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFechaRevacunacion_CalendarExtender" runat="server" 
                                        Format="dd/MM/yyyy" TargetControlID="txtFechaRevacunacion">
                                </cc1:CalendarExtender>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                &nbsp;</td>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                                <asp:Label ID="Label50" runat="server" Text="Proxima Vacuna:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px" colspan="4">
                                <asp:DropDownList ID="ddlVacunaProxima" runat="server" CssClass="combo" 
                    Width="300px">
                                </asp:DropDownList>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                &nbsp;</td>
                            <td>
                &nbsp;</td>
                            <td colspan="4">
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


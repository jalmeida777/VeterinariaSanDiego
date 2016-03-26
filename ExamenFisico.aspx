<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="ExamenFisico.aspx.cs" Inherits="ExamenFisico" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
    .style2
    {
        width: 15%;
    }
    .style4
    {
        width: 111px;
    }
    .style6
    {
        width: 120px;
    }
    .style8
    {
        width: 3px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divBusqueda">
    <table width="100%">
        <tr>
            <td>
                <h1 class="label">
                    Examen Fisico</h1>
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
                        <td colspan="6">
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
                        <td colspan="6">
                                <asp:Label ID="lblCodigo" runat="server"></asp:Label>

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
                        <td style="padding-left: 5px" class="style6" colspan="2">
                            &nbsp;</td>
                        <td style="padding-left: 5px" class="style4" colspan="2">
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
                    <tr id="filaCodigo" runat="server" visible = "true">
                        <td height="10" width="20">
                            &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                            <asp:Label ID="Label56" runat="server" Text="Temperatura ( °C ):"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" class="style8">
                            <asp:TextBox ID="txtTemperatura" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                        </td>
                        <td style="padding-left: 5px">
                            <asp:Label ID="Label57" runat="server" Text="Peso (Kg):"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="2">
                            <asp:TextBox ID="txtPeso" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                        </td>
                        <td style="padding-left: 5px">
                            <asp:Label ID="Label58" runat="server" Text="Hidratación:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px">
                            <asp:TextBox ID="txtHidratacion" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr id="filaCodigo2" runat="server" visible = "true">
                        <td height="10" width="20">
                            &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                            <asp:Label ID="Label1" runat="server" Text="F.C. (min) :"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" class="style8">
                            <asp:TextBox ID="txtFC" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                        </td>
                        <td style="padding-left: 5px">
                            <asp:Label ID="Label54" runat="server" Text="Pulso (min) :"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="2">
                            <asp:TextBox ID="txtPulso" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                        </td>
                        <td style="padding-left: 5px">
                            <asp:Label ID="Label55" runat="server" Text="F.R. (min)"></asp:Label>
                        </td>
                        <td style="padding-left: 5px">
                            <asp:TextBox ID="txtFR" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="100px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                            &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                            <asp:Label ID="Label59" runat="server" Text="Diagnostico:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:DropDownList ID="ddlDiagnostico" runat="server" CssClass="combo" 
                    Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right: 1px solid #339933; text-align: left;">
                            <asp:Label ID="Label60" runat="server" Text="SISTEMA" 
                                style="color: #FF6666; font-weight: 700"></asp:Label>
                        </td>
                        <td style="border-right: 1px solid #339933; text-align: left;" colspan="6">
                            <asp:Label ID="Label61" runat="server" Text="ESTADO / BREVE DESCRIPCION" 
                                style="text-align: right; color: #FF6600; font-weight: 700"></asp:Label>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label31" runat="server" Text="General:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
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
                            <asp:Label ID="Label32" runat="server" Text="Ojos-Orejas-Nariz-Garganta:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtOONG" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label49" runat="server" Text="Piel Tegumento:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtPiel" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label50" runat="server" Text="Musculo Esqueletico:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtMusculo" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label33" runat="server" Text="Cardiovascular:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtCardiovascular" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label34" runat="server" Text="Respiratorio:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtRespiratorio" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label43" runat="server" Text="Gastrointestinal:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <table cellpadding="0" cellspacing="0" class="style1">
                                <tr>
                                    <td width="120">
                                        <asp:TextBox ID="txtGastro" runat="server" CssClass="inputNormal" 
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
                            <asp:Label ID="Label37" runat="server" Text="Genital - Reproductor:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtGenital" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr id="tblFechaRegistro" runat="server" visible="true">
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label42" runat="server" Text="Neurológico:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtNeurologico" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr id="tblFechaVisita" runat="server" visible="true">
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label46" runat="server" Text="Linfático:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <asp:TextBox ID="txtLinfatico" runat="server" CssClass="inputNormal" 
                    MaxLength="11" Width="439px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933">
                            <asp:Label ID="Label51" runat="server" Text="Otros:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="50">
                                        <asp:TextBox ID="txtOtros" runat="server" CssClass="inputNormal" 
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
                            <asp:Label ID="Label38" runat="server" Text="Tratamiento:"></asp:Label>
                        </td>
                        <td style="padding-left: 5px" colspan="6">
                <asp:TextBox ID="txtTratamiento" runat="server" TextMode="MultiLine" 
                    Width="439px" Height="51px"></asp:TextBox>
                        </td>
                        <td width="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="10" width="20">
                &nbsp;</td>
                        <td>
                &nbsp;</td>
                        <td colspan="6">
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


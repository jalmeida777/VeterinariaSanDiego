<%@ Page Title="Crear Paciente" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearPaciente.aspx.cs" Inherits="CrearPaciente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="js/jquery.growl.js" type="text/javascript"></script>
<link href="css/jquery.growl.css" rel="stylesheet" type="text/css" />
    <link href="css/tabs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="divBusqueda">
        <table width="100%">
            <tr>
                <td>
                    <h1 class="label">
                        Paciente</h1>
                </td>
            </tr>
        </table>
    </div>
    <div class="toolbar">
        <table width="100%">
            <tr>
                <td width="65">
                    <asp:ImageButton ID="btnModificar" runat="server" 
                        ImageUrl="~/images/Modificar.jpg" onclick="btnModificar_Click" />
                </td>
                <td width="65">
                    <asp:ImageButton ID="btnGuardar" runat="server" 
                                ImageUrl="~/images/Guardar.jpg" onclick="btnGuardar_Click" 
                        Enabled="False" />
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
                <asp:HiddenField ID="hfCliente" runat="server" />
                                    <asp:Label runat="server" ID="lblCodigoPaciente" 
                    Visible="False"></asp:Label>

                                    <asp:Label runat="server" ID="lblRuta" Visible="False"></asp:Label>

            </td>
            <td>
                &nbsp;</td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td colspan="2">

                <asp:Label runat="server" Text="Nombre del paciente" ID="Label30"></asp:Label>
                <asp:Label runat="server" Text="*" Font-Bold="True" Font-Size="10pt" 
                    ForeColor="#18AC85" ID="Label53"></asp:Label>
                </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td colspan="2">

                <asp:TextBox runat="server" MaxLength="50" CssClass="inputNormal" Width="100%" 
                    ID="txtNombre" Font-Size="20pt" Height="40px"></asp:TextBox>
                </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td colspan="2">

                &nbsp;</td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td colspan="2">

            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" CssClass="MyTabStyle">

                    <cc1:TabPanel runat="server" HeaderText="Datos Generales" ID="TabPanel1">
                        <HeaderTemplate>
                            Paciente
                        </HeaderTemplate>
                    <ContentTemplate>

                        <table width="100%" cellpadding="5">
                            <tr>
                                <td class="label" >
                                    <asp:Label ID="Label54" runat="server" Text="Cliente"></asp:Label>
                                </td>
                                <td style="padding-left: 5px" class="label">
                                    <asp:Label ID="Label64" runat="server" Text="N° Historia"></asp:Label>
                                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td class="label" style="padding-left: 5px">
                                    <asp:Label ID="Label70" runat="server" Text="Fecha de Alta"></asp:Label>
                                </td>
                                <td runat="server" rowspan="8" style="padding-left: 5px" valign="top">
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" Text="Foto:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: 1px solid #B3B3B3">
                                                <asp:Image ID="ibImagen" runat="server" BorderColor="White" BorderStyle="Solid" 
                                                    BorderWidth="3px" Height="134px" ImageUrl="~/images/siluetadog.jpg" 
                                                    Width="164px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="130">
                                                    <tr>
                                                        <td width="130">
                                                            <asp:FileUpload ID="fu1" runat="server" Width="130px" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="ibUpload" runat="server" ImageUrl="~/images/upload.png" 
                                                                OnClick="ibUpload_Click" Width="16px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombreCliente" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtHistoria" runat="server" CssClass="inputNormal" 
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtFechaAlta" runat="server" CssClass="inputsFecha" 
                                        MaxLength="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFechaAlta_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaAlta">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <asp:Label ID="Label55" runat="server" Text="Especie"></asp:Label>
                                    <asp:Label ID="Label65" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px" class="label">
                                    <asp:Label ID="Label56" runat="server" Text="Raza"></asp:Label>
                                    <asp:Label ID="Label66" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td class="label" style="padding-left: 5px">
                                    <asp:Label ID="Label57" runat="server" Text="Sexo"></asp:Label>
                                    <asp:Label ID="Label67" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlEspecie" runat="server" AutoPostBack="True" 
                                        CssClass="combo" OnSelectedIndexChanged="ddlEspecie_SelectedIndexChanged" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlRaza" runat="server" CssClass="combo" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="combo" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <asp:Label ID="Label58" runat="server" Text="Pelaje"></asp:Label>
                                </td>
                                <td style="padding-left: 5px" class="label">
                                    <asp:Label ID="Label59" runat="server" Text="Microchip"></asp:Label>
                                </td>
                                <td class="label" style="padding-left: 5px">
                                    <asp:Label ID="Label63" runat="server" Text="Estado"></asp:Label>
                                    <asp:Label ID="Label69" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPelaje" runat="server" CssClass="inputNormal" Width="200px"></asp:TextBox>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtMicrochip" runat="server" CssClass="inputNormal" 
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="combo" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <asp:Label ID="Label60" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                                    <asp:Label ID="Label68" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px" class="label">
                                    <asp:Label ID="Label61" runat="server" Text="Edad"></asp:Label>
                                </td>
                                <td class="label" style="padding-left: 5px">
                                    <asp:Label ID="Label62" runat="server" Text="Ultima Visita"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="inputsFecha" 
                                        MaxLength="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                        Format="dd/MM/yyyy" TargetControlID="txtFechaNacimiento">
                                    </cc1:CalendarExtender>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:Label ID="lblEdad" runat="server"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:Label ID="lblUltimaVisita" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="padding-left: 5px">
                                    &nbsp;</td>
                                <td style="padding-left: 5px">
                                    &nbsp;</td>
                                <td style="padding-left: 5px">
                                    &nbsp;</td>
                            </tr>
                        </table>

                    </ContentTemplate>
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Pacientes">
                        <HeaderTemplate>
                            Historia Clínica
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="Baño y Peluquería">
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Cta.Cte.">
                    </cc1:TabPanel>

            </cc1:TabContainer>
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


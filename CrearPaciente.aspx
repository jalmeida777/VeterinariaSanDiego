<%@ Page Title="Crear Paciente" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearPaciente.aspx.cs" Inherits="CrearPaciente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="js/jquery.growl.js" type="text/javascript"></script>
<link href="css/jquery.growl.css" rel="stylesheet" type="text/css" />

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
                    <asp:Button ID="btnModificar" runat="server" Enabled="False" 
                        onclick="btnModificar_Click" Text="Modificar" />
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
                    Width="100%">

                    <cc1:TabPanel runat="server" HeaderText="Datos Generales" ID="TabPanel1">
                        <HeaderTemplate>
                            Paciente
                        </HeaderTemplate>
                    <ContentTemplate>

                        <table width="100%" cellpadding="5">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr id="filaCodigo" runat="server">
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;" 
                                    runat="server" >
                                    <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
                                </td>
                                <td style="padding-left: 5px" runat="server">
                                    <asp:Label ID="lblCodigoPaciente" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                <asp:Label ID="Label54" runat="server" Text="Cliente:"></asp:Label>
                            </td>
                            <td style="padding-left: 5px">
                                <asp:Label ID="lblNombreCliente" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label64" runat="server" Text="N° Historia:"></asp:Label>
                                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtHistoria" runat="server" CssClass="inputNormal" 
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label55" runat="server" Text="Especie:"></asp:Label>
                                    <asp:Label ID="Label65" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlEspecie" runat="server" CssClass="combo" Width="200px" 
                                        AutoPostBack="True" onselectedindexchanged="ddlEspecie_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label56" runat="server" Text="Raza:"></asp:Label>
                                    <asp:Label ID="Label66" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlRaza" runat="server" CssClass="combo" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label57" runat="server" Text="Sexo:"></asp:Label>
                                    <asp:Label ID="Label67" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="combo" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label58" runat="server" Text="Pelaje:"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtPelaje" runat="server" CssClass="inputNormal" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label59" runat="server" Text="Microchip:"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtMicrochip" runat="server" CssClass="inputNormal" 
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label60" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                                    <asp:Label ID="Label68" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="inputsFecha" 
                                        MaxLength="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" 
                                        TargetControlID="txtFechaNacimiento" Enabled="True">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label61" runat="server" Text="Edad:"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:Label ID="lblEdad" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label62" runat="server" Text="Ultima Visita:"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:Label ID="lblUltimaVisita" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933; width: 180px;">
                                    <asp:Label ID="Label63" runat="server" Text="Estado:"></asp:Label>
                                    <asp:Label ID="Label69" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="combo" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>

                    </ContentTemplate>
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Pacientes">
                        <HeaderTemplate>
                            Vacunas
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

                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Antipulgas">
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Antiparasitarios">
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Control Médico">
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="Baño y Peluquería">
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


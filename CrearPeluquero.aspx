<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearPeluquero.aspx.cs" Inherits="CrearPeluquero" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divBusqueda">
        <table width="100%">
            <tr>
                <td>
                    <h1 class="label">
                        Peluqueros</h1>
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
    <table width="100%" 
        style="background-image: url('images/form_sheetbg.png'); background-repeat: repeat; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #ddd;">
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
                            <td>
                &nbsp;</td>
                            <td>
                &nbsp;</td>
                            <td>
                &nbsp;</td>
                            <td width="20">
                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="inputNormal" placeholder="Descripción"
                    Width="300px" style="text-transform:uppercase"></asp:TextBox>
                            </td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="DNI:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDNI" runat="server" CssClass="inputNormal" placeholder="Descripción"
                    Width="136px" style="text-transform:uppercase"></asp:TextBox>
                            </td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Código:" Visible="False"></asp:Label>
                                <asp:Label ID="lblCodigo" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Telefono:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="inputNormal" placeholder="Descripción"
                    Width="136px" style="text-transform:uppercase"></asp:TextBox>
                            </td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Celular:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="inputNormal" placeholder="Descripción"
                    Width="136px" style="text-transform:uppercase"></asp:TextBox>
                            </td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Dirección:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="inputNormal" placeholder="Descripción"
                    Width="300px" style="text-transform:uppercase"></asp:TextBox>
                            </td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td width="20">
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="10" width="20">
                            &nbsp;</td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Estado:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEstado" runat="server" Checked="True" Text="Habilitado" />
                            </td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
                            <td>
                            &nbsp;</td>
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
                            <td>
                &nbsp;</td>
                            <td>
                &nbsp;</td>
                            <td>
                &nbsp;</td>
                            <td width="20">
                &nbsp;</td>
                        </tr>
                    </table>
        <tr>
            <td width="15%">
                &nbsp;</td>
            <td>
                &nbsp;</table>
</asp:Content>


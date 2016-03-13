<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="ListarCliente.aspx.cs" Inherits="ListarCliente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 133px;
        }
        .style3
        {
            padding-left: 7px;
        }
        .style4
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="divBusqueda">
            <table width="100%" cellpadding="3" cellspacing="3">
                <tr>
                    <td colspan="4">
                        <h1 class="label">
                            Administración de Clientes</h1>
                    </td>
                </tr>
                <tr>
                    <td width="60">
                        <asp:Label ID="Label2" runat="server" Text="Buscar:"></asp:Label>
                    </td>
                    <td width="85">
                        <asp:DropDownList ID="ddlBusqueda" runat="server" Width="80px">
                            <asp:ListItem>DNI</asp:ListItem>
                            <asp:ListItem>NOMBRE</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="205">
                        <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="True" 
                            CssClass="inputs" ontextchanged="txtBuscar_TextChanged" placeholder="Buscar" 
                            Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkEstado" runat="server" Checked="True" 
                                        Text="Ver Habilitados" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <table width="100%">
                <tr>
                    <td width="65">
                        <asp:ImageButton ID="btnConsultar" runat="server" 
                    ImageUrl="~/images/Buscar.jpg" onclick="btnConsultar_Click" />
                    </td>
                    <td width="65">
                        <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/images/Nuevo.jpg" 
                        onclick="btnNuevo_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnSalir" runat="server" ImageUrl="~/images/Salir.jpg" 
                        onclick="btnSalir_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <img src="images/loading.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" 
                Width="100%">
            <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="False" AllowPaging = "true"
                    CssClass="grid" DataKeyNames="i_IdCliente" 
                    onrowdatabound="gvProveedor_RowDataBound" Width="100%">
                <Columns>
                    <asp:BoundField DataField="i_IdCliente" HeaderText="Id" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="v_Nombres" HeaderText="Nombre">
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="v_Celular" HeaderText="Celular">
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="v_Telefono" HeaderText="Telefono">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="v_Email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibEditar" runat="server" ImageUrl="~/images/edit.png" 
                                    ToolTip="Editar" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


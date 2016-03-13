﻿<%@ Page Title="Orden De Compra" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="ListarOrdenCompra.aspx.cs" Inherits="ListarOrdenCompra" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
        <div class="divBusqueda">
            <table width="100%">
                <tr>
                    <td colspan="12">
                        <h1 class="label">
                            Ordenes de Compra</h1>
                    </td>
                </tr>
                <tr>
                    <td width="90" class="label">
                        <asp:Label ID="Label1" runat="server" Text="Fecha Inicial:" Font-Bold="False"></asp:Label>
                    </td>
                    <td width="110">
                        <asp:TextBox ID="txtFechaInicial" runat="server" CssClass="inputsFecha"
                            MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender 
                        ID="CalendarExtender1" 
                        runat="server" 
                        TargetControlID="txtFechaInicial" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td width="85" class="label">
                        <asp:Label ID="Label2" runat="server" Text="Fecha Final:" Font-Bold="False"></asp:Label>
                    </td>
                    <td width="110">
                        <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="inputsFecha" 
                            MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" 
                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFinal">
                        </cc1:CalendarExtender>
                    </td>
                    <td width="70" class="label">
                        
                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Sucursal:"></asp:Label>
                        
                    </td>
                    <td width="210" class="label">
                        <asp:DropDownList ID="ddlAlmacen" runat="server" 
                            Width="200px" CssClass="combo">
                        </asp:DropDownList>
                    </td>
                    <td class="label" width="70">
                        <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="Producto:"></asp:Label>
                    </td>
                    <td width="200">
                        <asp:TextBox ID="txtProducto" runat="server" 
                            CssClass="inputNormal" 
                            placeholder="Producto" Width="180px"></asp:TextBox>
                    </td>
                    <td width="110">
                        <asp:CheckBox ID="chkHabilitado" runat="server" 
                            Checked="True" Font-Bold="False" Text="Habilitados" />
                    </td>
                    <td align="right">
                        </td>
                    <td align="right" width="70">
                        &nbsp;</td>
                    <td align="right" width="70">
                        &nbsp;&nbsp;</td>
                </tr>
            </table>
            </div>
            <div class="toolbar">
            <table width="100%"><tr><td width="65">
                <asp:ImageButton ID="btnConsultar" runat="server" 
                    ImageUrl="~/images/Buscar.jpg" onclick="btnConsultar_Click" ToolTip="Buscar" />
                </td>
                <td width="65">
                    <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/images/Nuevo.jpg" 
                        onclick="btnNuevo_Click" ToolTip="Nuevo" />
                </td>
                <td>
                    <asp:ImageButton ID="btnSalir" runat="server" ImageUrl="~/images/Salir.jpg" 
                        onclick="btnSalir_Click" />
                </td>
                </tr></table>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <img src="images/loading.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" 
                Width="100%">
                <asp:GridView ID="gvOrdenCompra" runat="server" AutoGenerateColumns="False" 
                    CssClass="grid" DataKeyNames="i_IdOrdenCompra">
                    <Columns>
                        <asp:TemplateField HeaderText="N° Orden de Compra">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" 
                                    Text='<%# Bind("v_NumeroOrdenCompra") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" 
                                    ForeColor="Blue" Text='<%# Bind("v_NumeroOrdenCompra") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="d_FechaEmision" HeaderText="Fecha">
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="v_Descripcion" HeaderText="Sucursal Destino">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="v_Nombre" HeaderText="Proveedor">
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Moneda" DataField="v_DescripcionMoneda">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Usuario" HeaderText="Creado por">
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="SubTotal" DataField="f_SubTotal" 
                            DataFormatString="{0:n2}">
                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="IGV" DataField="f_IGV" DataFormatString="{0:n2}">
                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Total" DataField="f_Total" 
                            DataFormatString="{0:n2}">
                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle CssClass="footer" />
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="ListarCaniles.aspx.cs" Inherits="ListarCaniles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="divBusqueda">
                <table width="100%" cellpadding="3" cellspacing="3">
                    <tr>
                        <td colspan="2">
                            <h1 class="label">
                                Administración de Caniles</h1>
                        </td>
                    </tr>
                    <tr>
                        <td width="50" class="label">
                            <asp:Label ID="Label2" runat="server" Text="Buscar:"></asp:Label>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="225">
                                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="inputs" 
                                        placeholder="Buscar" Width="200px" AutoPostBack="True" 
                                        ontextchanged="txtBuscar_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                    &nbsp;</td>
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
                <asp:GridView ID="gvCaniles" runat="server" AutoGenerateColumns="False" 
                    CssClass="grid" DataKeyNames="i_IdCaniles" 
                    onrowdatabound="gvAlmacen_RowDataBound" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="i_IdCaniles" HeaderText="Id" Visible="False">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="v_Nombre" HeaderText="Descripcion"></asp:BoundField>
                        <asp:TemplateField HeaderText="Estado">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("b_Estado") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Bind("b_Estado") %>' 
                                    Enabled="False" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
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

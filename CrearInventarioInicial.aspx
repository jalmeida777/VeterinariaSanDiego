﻿<%@ Page Title="Inventario Inicial" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearInventarioInicial.aspx.cs" Inherits="CrearInventarioInicial" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="js/jquery.growl.js" type="text/javascript"></script>
<link href="css/jquery.growl.css" rel="stylesheet" type="text/css" />
        <style>
        .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: .8em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            margin-left:10px;
            z-index:99;
        }
        .AutoExtenderList
        {
            border-bottom: dotted 1px #006699;
            cursor: pointer;
            color: Maroon;
        }
        .AutoExtenderHighlight
        {
            color: White;
            background-color: #006699;
            cursor: pointer;
        }
        #divwidth
        {
          width: 150px !important;    
        }
        #divwidth div
       {
        width: 150px !important;   
       }
 </style>

     <script type="text/javascript">
         function ValidaEntero(e) {
             var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
             if (tecla > 31 && (tecla < 48 || tecla > 57))
                 return false;
         }

         function OnClienteSeleccionado(source, eventArgs) {

             if (source) {
                 // Get the HiddenField ID.
                 var hiddenfieldID = source.get_id().replace("txtProducto_AutoCompleteExtender", "hfIdProducto");
                 $get(hiddenfieldID).value = eventArgs.get_value();

                 __doPostBack(hiddenfieldID, "");

             }
             //alert("HiddenFieldID :" + hiddenfieldID + " HiddenFieldValue : " + $get(hiddenfieldID).value);
             //alert(" Key : " + eventArgs.get_text() + "  Value :  " + eventArgs.get_value());

         }

 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="toolbar" id="toolbar" runat="server">
        <table width="100%">
            <tr>
                <td width="65">
                    <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/images/Guardar.jpg" 
                    onclick="btnGuardar_Click" OnClientClick="if (confirm('Seguro de guardar?')) { btnGuardar.disabled = false; return true; } else { return false; }" />
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

 <table width="100%" id="tblGeneral" runat="server"
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
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="20pt" 
                    Text="Proceso: Inventario Inicial" ForeColor="#4C4C4C"></asp:Label>
            &nbsp;<asp:Label ID="lblNumero" runat="server" Font-Bold="True" Font-Size="20pt" 
                    ForeColor="#4C4C4C"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933" 
                width="120">
                <asp:Label ID="Label3" runat="server" Text="Sucursal:" ForeColor="#4C4C4C"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                <table cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td width="155">
                <asp:DropDownList ID="ddlAlmacen" runat="server" Width="150px" CssClass="combo">
                </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="ibEstablecerSucursal" runat="server" 
                                ImageUrl="~/images/auth_ok.png" onclick="ibEstablecerSucursal_Click" 
                                ToolTip="Establecer Sucursal" />
                                </td>
                    </tr>
                </table>
            </td>
            <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #339933" 
                width="100">
                <asp:Label ID="Label2" runat="server" Text="Fecha:" ForeColor="#4C4C4C"></asp:Label>
            </td>
            <td style="padding-left: 5px">
                        <asp:TextBox ID="txtFechaInicial" runat="server" CssClass="inputsFecha"
                            MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender 
                        ID="CalendarExtender1" 
                        runat="server" 
                        TargetControlID="txtFechaInicial" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
            <td style="padding-left: 5px">
                        &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                    CssClass="grid" Enabled="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <asp:TextBox ID="txtProducto" runat="server" Width="300px" 
                                    CssClass="inputNormal" Text='<%# Bind("Producto") %>' 
                                    placeholder="Ingrese Producto" AutoPostBack="True"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="txtProducto_AutoCompleteExtender" runat="server" 
                                    DelimiterCharacters="" Enabled="True" ServicePath="" 
                                    TargetControlID="txtProducto" CompletionInterval="100" 
                                    CompletionListCssClass="AutoExtender" 
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                    CompletionListItemCssClass="AutoExtenderList" 
                                    MinimumPrefixLength="2" ServiceMethod="BuscarProductos" 
                                    onclientitemselected="OnClienteSeleccionado" 
                                    ShowOnlyCurrentWordInCompletionListItem="True">
                                </cc1:AutoCompleteExtender>

                                <asp:HiddenField ID="hfIdProducto" runat="server" 
                                    onvaluechanged="hfIdProducto_ValueChanged" 
                                    Value='<%# Bind("n_IdProducto") %>' />

                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCantidad" runat="server" Width="100px" 
                                    CssClass="inputNormalMoneda" Text='<%# Bind("Cantidad") %>' onkeypress="return ValidaEntero(event);"></asp:TextBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="txtObservacion" runat="server" Height="80px" 
                    TextMode="MultiLine" Width="400px" placeholder="Comentarios"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="4">
                <table width="300">
                    <tr>
                        <td rowspan="2" width="60">
                            <asp:ImageButton ID="ibUsuarioRegistro" runat="server" Height="50px" 
                                ImageUrl="~/images/face.jpg" Width="50px" />
                        </td>
                        <td>
                            Creado por:
                            <asp:Label ID="lblUsuarioRegistro" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFechaRegistro" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
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
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div></td>
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


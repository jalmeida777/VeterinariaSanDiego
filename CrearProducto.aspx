﻿<%@ Page Title="Producto" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearProducto.aspx.cs" Inherits="CrearProducto" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register Assembly="DevExpress.Web.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="js/jquery.growl.js" type="text/javascript"></script>
<link href="css/jquery.growl.css" rel="stylesheet" type="text/css" />
    <link href="css/tabs.css" rel="stylesheet" type="text/css" />

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
        .style1
        {
            width: 100%;
        }
 </style>

      <script type="text/javascript">
         function ValidaEntero(e) {
             var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
             if (tecla > 31 && (tecla < 48 || tecla > 57))
                 return false;
         }

         function ValidaNumeros(e) {
             var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
             if (tecla > 31 && (tecla < 48 || tecla > 57) && tecla != 46)
                 return false;
         }
         </script>

         <style type="text/css">
        .InfoTable td
        {
            padding: 0 4px;
            vertical-align: top;
        }
        </style>
    <script type="text/javascript">
        var keyValue;
        function OnMoreInfoClick(element) {
            callbackPanel.SetContentHtml("");
            popup.ShowAtElement(element);
            keyValue = key;
        }
        function popup_Shown(s, e) {
            callbackPanel.PerformCallback(keyValue);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

            <div class="divBusqueda">
            <table width="100%">
                <tr>
                    <td>
                        <h1 class="label">
                            Producto / Servicio</h1>
                    </td>
                </tr>
                </table>
            </div>

     <div class="toolbar">
            <table width="100%"><tr><td width="65">
                
                
                
                                <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/images/Guardar.jpg" 
                                    onclick="btnGuardar_Click" />
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
                   
                    
                   
                    &nbsp;</td>
                </tr></table>
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
            <td colspan="5">
                <asp:Label runat="server" Text="Nombre del Producto o Servicio" ID="Label2" 
                    Font-Bold="False"></asp:Label>
                <asp:Label runat="server" Text="*" Font-Bold="True" Font-Size="10pt" 
                    ForeColor="#18AC85" ID="Label25"></asp:Label>
            </td>
            <td width="20">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="10" width="20">
                &nbsp;</td>
            <td colspan="5">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                <asp:TextBox runat="server" CssClass="inputNormal" Width="600px" 
                    ID="txtDescripcion" placeholder="Nombre del Producto" style="text-transform:uppercase" 
                    Font-Bold="True" Font-Size="20pt" Height="40px"></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" MinimumPrefixLength="2" 
                    CompletionInterval="100" ServiceMethod="BuscarProductos" ServicePath="" 
                    CompletionListCssClass="AutoExtender" 
                    CompletionListItemCssClass="AutoExtenderList" 
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                    EnableCaching="False" DelimiterCharacters="" Enabled="True" 
                    TargetControlID="txtDescripcion" ID="txtDescripcion_AutoCompleteExtender">
                </cc1:AutoCompleteExtender>
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="ibAtras" runat="server" 
                                ImageUrl="~/images/boton_Atras_blanco.jpg" onclick="ibAtras_Click" 
                                ToolTip="Anterior" Visible="False" />
&nbsp;<asp:ImageButton ID="ibSiguiente" runat="server" ImageUrl="~/images/boton_Siguiente_blanco.jpg" 
                                onclick="ibSiguiente_Click" ToolTip="Siguiente" Visible="False" />
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
            <td width="90">
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
            <td colspan="5">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                    Width="100%" CssClass="MyTabStyle">
                    <cc1:TabPanel runat="server" HeaderText="Datos Generales" ID="TabPanel1">
                    <ContentTemplate>
                    <table width="100%">
                            <tr>
            <td>
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
            <td rowspan="7" align="right" height="150" style="border: 1px solid #B3B3B3" width="200">

                                    
                           
                                
<a href="javascript:void(0);" onclick="OnMoreInfoClick(this)">
                <asp:Image ID="ibImagen" runat="server" Height="150px" 
                    ImageUrl="~/images/Prev.jpg" Width="200px" BorderColor="White" 
                    BorderStyle="Solid" BorderWidth="3px" />
                    </a>


                </td>
        </tr>
                            <tr>
                                <td class="label">
                                    <asp:Label ID="Label26" runat="server" Text="Tipo"></asp:Label>
                                </td>
                                <td class="label">
                                    <asp:Label ID="Label22" runat="server" Text="Código Interno"></asp:Label>
                                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                </td>
                                <td class="label">
                                    <asp:Label ID="Label4" runat="server" Text="Código de Barras"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rblTipo" runat="server" 
                                        RepeatDirection="Horizontal" AutoPostBack="True" 
                                        onselectedindexchanged="rblTipo_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="P">Producto</asp:ListItem>
                                        <asp:ListItem Value="S">Servicio</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodigoInterno" runat="server" CssClass="inputNormal" 
                                        MaxLength="4" onkeypress="return ValidaEntero(event);" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodigoBarras" runat="server" CssClass="inputNormal" 
                                        MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
        <tr>
            <td class="label">
                    <asp:Label ID="Label7" runat="server" Text="Precio S/."></asp:Label>
                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="10pt" 
                        ForeColor="#18AC85" Text="*"></asp:Label>
                </td>
            <td class="label">
                    <asp:Label ID="Label8" runat="server" Text="Costo S/."></asp:Label>
                </td>
            <td class="label">
                <asp:Label ID="Label9" runat="server" Text="Stock Mínimo"></asp:Label>
            </td>
        </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="inputNormalMoneda" 
                                        onkeypress="return ValidaNumeros(event);" placeholder="Precio"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCosto" runat="server" CssClass="inputNormalMoneda" 
                                        onkeypress="return ValidaNumeros(event);" placeholder="Costo"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="inputNormalMoneda" 
                                        placeholder="Stock" style="text-transform:uppercase"></asp:TextBox>
                                </td>
                            </tr>
        <tr>
            <td class="label">
                    <asp:Label ID="Label10" runat="server" Text="Marca"></asp:Label>
                </td>
            <td class="label">
                    <asp:Label ID="Label11" runat="server" Text="Modelo"></asp:Label>
                </td>
            <td class="label">
                <asp:Label ID="Label24" runat="server" Text="Vencimiento"></asp:Label>
            </td>
        </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="True" 
                                        CssClass="combo" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlModelo" runat="server" CssClass="combo" 
                                        Enabled="False" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVencimiento" runat="server" CssClass="inputsFecha" 
                                        MaxLength="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtVencimiento_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtVencimiento">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
        <tr>
            <td class="label">
                    <asp:Label ID="Label12" runat="server" Text="Categoría"></asp:Label>
                </td>
            <td class="label">
                    <asp:Label ID="Label13" runat="server" Text="Sub Categoría"></asp:Label>
                </td>
            <td class="label">
                <asp:Label ID="Label14" runat="server" Text="Proveedor"></asp:Label>
            </td>
            <td>
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:FileUpload ID="fu1" runat="server" Width="130px" />
                            </td>
                            <td align="right">
                                <asp:ImageButton ID="ibUpload" runat="server" ImageUrl="~/images/upload.png" 
                                    OnClick="ibUpload_Click" style="height: 16px" />
                            </td>
                        </tr>
                    </table>
                </td>
        </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" 
                                        CssClass="combo" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubCategoria" runat="server" CssClass="combo" 
                                        Enabled="False" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="combo" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Código:" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCodigo" runat="server" Font-Bold="True" Visible="False"></asp:Label>
                                </td>
                            </tr>
        <tr>
            <td class="label">
                    <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
                </td>
            <td class="label">
                    &nbsp;</td>
            <td class="label">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkEstado" runat="server" Checked="True" Text="Habilitado" />
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
                                    <asp:Label ID="lblRuta" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblExtension" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" Font-Bold="False" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="* Campos obligatorios"></asp:Label>
                                </td>
                            </tr>

                    </table>
                    </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Inventario">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        
<table width="100%">
                    <tr>
                    <td>
                    </td>
                    </tr>
                        <tr>
                        <td>
                            <asp:GridView ID="gvStock" runat="server" CssClass="grid" 
                                AutoGenerateColumns="False" DataKeyNames="i_IdAlmacen" 
                                onselectedindexchanged="gvStock_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="v_Descripcion" HeaderText="Almacén" />
                                    <asp:BoundField DataField="f_StockContable" HeaderText="Stock">
                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    </asp:BoundField>
                                    <asp:CommandField HeaderText="Ver Kardex" SelectText="Ver Kardex" 
                                        ShowSelectButton="True">
                                    <ItemStyle Font-Underline="True" ForeColor="#003399" HorizontalAlign="Center" 
                                        Width="70px" />
                                    </asp:CommandField>
                                </Columns>
                                <SelectedRowStyle BackColor="#99CCFF" Font-Bold="True" />
                            </asp:GridView>
                        </td>
                        </tr>

                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Kardex" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Visible="False">
                                    <asp:GridView ID="gvKardex" runat="server" AutoGenerateColumns="False" 
                                        CssClass="grid" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="d_FechaMovimiento" HeaderText="Fecha" />
                                            <asp:BoundField DataField="v_Descripcion" HeaderText="Motivo de Movimiento" />
                                            <asp:BoundField DataField="Movimiento" HeaderText="Tipo de Movimiento" />
                                            <asp:BoundField DataField="f_Cantidad" HeaderText="Cantidad">
                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="f_Saldo" HeaderText="Saldo">
                                            <ItemStyle Font-Bold="True" HorizontalAlign="Right" Width="100px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>

                    </table>

                        </ContentTemplate>
                        </asp:UpdatePanel>
                    
                    </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Ventas">
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Compras">
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







    <dx:ASPxPopupControl ID="popup" ClientInstanceName="popup" runat="server" AllowDragging="True"
        PopupHorizontalAlign="OutsideRight" HeaderText="Foto" 
                CssFilePath="~/App_Themes/PlasticBlue/{0}/styles.css" CssPostfix="PlasticBlue" 
                SpriteCssFilePath="~/App_Themes/PlasticBlue/{0}/sprite.css" Height="200px" 
                MaxHeight="400px" MaxWidth="400px" MinHeight="300px" MinWidth="300px">
        <CloseButtonStyle>
            <Paddings Padding="0px" />
        </CloseButtonStyle>
        <ContentStyle>
            <BorderBottom BorderColor="#E0E0E0" BorderStyle="Solid" BorderWidth="1px" />
        </ContentStyle>
        <HeaderStyle>
        <Paddings PaddingBottom="4px" PaddingLeft="10px" PaddingRight="4px" 
            PaddingTop="4px" />
        </HeaderStyle>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                
                           
                                       <dx:ASPxCallbackPanel ID="callbackPanel" ClientInstanceName="callbackPanel" runat="server"
                    Width="200px" Height="200px" OnCallback="callbackPanel_Callback" RenderMode="Table">
                                           <panelcollection>
                                               <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                                   <table class="style1">
                                                       <tr>
                                                           <td>
                                                               <asp:Image ID="ImagenGrande" runat="server" Height="300px" Width="300px" />
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td>
                                                               <asp:Label ID="lblCodigo0" runat="server" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td>
                                                               <asp:Label ID="lblProducto" runat="server"></asp:Label>
                                                           </td>
                                                       </tr>
                                                   </table>
                                               </dx:PanelContent>
                                           </panelcollection>
                                       </dx:ASPxCallbackPanel>
                                    
                      
                        
            </dx:PopupControlContentControl>
        </ContentCollection>
        <LoadingPanelImage Url="~/App_Themes/PlasticBlue/Web/dvLoading.gif">
        </LoadingPanelImage>
        <ClientSideEvents Shown="popup_Shown" />
    </dx:ASPxPopupControl>

                
                




    </asp:Content>


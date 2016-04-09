<%@ Page Title="Crear Paciente" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="CrearPaciente.aspx.cs" Inherits="CrearPaciente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
 </style>

             <script type="text/javascript">

                 function OnClienteSeleccionado(source, eventArgs) {

                     if (source) {
                         var hiddenfieldID = source.get_id().replace("txtVacuna_AutoCompleteExtender", "hfIdProducto");
                         $get(hiddenfieldID).value = eventArgs.get_value();

                         __doPostBack(hiddenfieldID, "");

                     }

                 }

 </script>

 <script type="text/javascript">

     function OnClienteSeleccionado2(source, eventArgs) {

         if (source) {
             var hiddenfieldID = source.get_id().replace("txtAntipulgas_AutoCompleteExtender", "hfIdProducto");
             $get(hiddenfieldID).value = eventArgs.get_value();

             __doPostBack(hiddenfieldID, "");

         }

     }

 </script>

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
                </td>
            <td>
                </td>
            <td width="15%">
                </td>
        </tr>
        <tr>
            <td width="15%">
                </td>
            <td>
            <div class="divDocumento">
                <table width="100%" cellspacing="5" >
        <tr>
            <td height="10" width="20">
                </td>
            <td width="45%">
                <asp:HiddenField ID="hfCliente" runat="server" />
                                    <asp:Label runat="server" ID="lblCodigoPaciente" 
                    Visible="False"></asp:Label>

                                    <asp:Label runat="server" ID="lblRuta" Visible="False"></asp:Label>

            </td>
            <td width="10">
                </td>
            <td width="45%">
                <asp:HiddenField ID="hfIdProducto" runat="server" />
                </td>
            <td width="20">
                </td>
        </tr>
        <tr>
            <td height="10" width="20">
                </td>
            <td>

                <asp:Label runat="server" Text="Nombre del paciente" ID="Label30"></asp:Label>
                <asp:Label runat="server" Text="*" Font-Bold="True" Font-Size="10pt" 
                    ForeColor="#18AC85" ID="Label53"></asp:Label>
                </td>
            <td>

                </td>
            <td>

                <asp:Label runat="server" Text="Cliente:" ID="Label54"></asp:Label>
                </td>
            <td width="20">
                </td>
        </tr>
        <tr>
            <td height="10" width="20">
                </td>
            <td>

                <asp:TextBox runat="server" MaxLength="50" CssClass="inputNormal" Width="100%" 
                    ID="txtNombre" Font-Size="20pt" Height="40px"></asp:TextBox>
                </td>
            <td>

                </td>
            <td>

                <asp:TextBox ID="txtCliente" runat="server" CssClass="inputNormal" 
                    Enabled="False" Font-Size="20pt" Height="40px" Width="100%"></asp:TextBox>
                </td>
            <td width="20">
                </td>
        </tr>
        <tr>
            <td height="10" width="20">
                </td>
            <td colspan="3">

                </td>
            <td width="20">
                </td>
        </tr>
        <tr>
            <td height="10" width="20">
                </td>
            <td colspan="3">

            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="3" 
                    Width="100%" CssClass="MyTabStyle">

                    <cc1:TabPanel runat="server" HeaderText="Datos Generales" ID="TabPanel1">
                        <HeaderTemplate>
                            
 
                            Paciente
 
                            
                        </HeaderTemplate>
                        
                    <ContentTemplate>

                        



                        <table width="100%" cellpadding="5">
                            

                            <tr>
                                

                                <td class="label" >
                                    

                                    <asp:Label ID="Label64" runat="server" Text="N° Historia"></asp:Label>
                                    

                                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="10pt" 
                                        ForeColor="#18AC85" Text="*"></asp:Label>
                                    

                                </td>
                                

                                <td style="padding-left: 5px" class="label">
                                    

                                    <asp:Label ID="Label70" runat="server" Text="Fecha de Alta"></asp:Label>
                                    

                                </td>
                                

                                <td class="label" style="padding-left: 5px">
                                    

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
                                

                                <td style="padding-left: 5px">
                                    

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
                                    

                                    </td>
                                

                                <td style="padding-left: 5px">
                                    

                                    </td>
                                

                                <td style="padding-left: 5px">
                                    

                                    </td>
                                

                                <td style="padding-left: 5px">
                                    

                                    </td>
                                

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
                                        

                                        </td>
                                    

                                </tr>
                                

                                <tr>
                                    

                                    <td>
                                        

                                        </td>
                                    

                                </tr>
                                

                            </table>
                            
 
                            
                        </ContentTemplate>
                        
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="Vacunas">
                        <HeaderTemplate>
                            
 
                            Vacunas
 
                            
                        </HeaderTemplate>
                        
                        <ContentTemplate>
                            

                            <table width="100%">
                                

                                <tr>
                                    

                                    <td>
                                        

                                        </td>
                                    


                                </tr>
                                

                                <tr>
                                    

                                    <td>
                                        

                                        <div class="divDocumento">
                                            <table width="100%" cellpadding="5">
                                                <tr>
                                                    <td class="label">
                                                        <asp:Label ID="Label52" runat="server" Text="Fecha de Vacunación"></asp:Label>
                                                    </td>
                                                    <td class="label">
                                                        <asp:Label ID="Label78" runat="server" Text="Sucursal"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr ID="filaCodigo1" runat="server">
                                                    <td runat="server">
                                                        <asp:TextBox ID="txtFechaVacunacion" runat="server" CssClass="inputsFecha" 
                                                            MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                                            Format="dd/MM/yyyy" TargetControlID="txtFechaVacunacion">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td runat="server">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="155">
                                                                    <asp:DropDownList ID="ddlAlmacen" runat="server" CssClass="combo" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="ibSucursal" runat="server" ImageUrl="~/images/auth_ok.png" 
                                                                        onclick="ibSucursal_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label">
                                                        <asp:Label ID="Label73" runat="server" Text="Vacuna"></asp:Label>
                                                    </td>
                                                    <td class="label">
                                                        <asp:Label ID="Label76" runat="server" Text="Precio S/."></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtVacuna" runat="server" CssClass="inputNormal" 
                                                            Font-Size="20pt" Height="40px" MaxLength="50" Width="100%"></asp:TextBox>

                                                            <cc1:AutoCompleteExtender ID="txtVacuna_AutoCompleteExtender" 
                                            runat="server" CompletionInterval="100" CompletionListCssClass="AutoExtender" 
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                            CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                            Enabled="True" OnClientItemSelected="OnClienteSeleccionado" 
                                            ServiceMethod="BuscarVacunas" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtVacuna" 
                                            UseContextKey="True">
                                        </cc1:AutoCompleteExtender>

                                                    </td>
                                                    <td class="label">
                                                        <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label">
                                                        <asp:Label ID="Label75" runat="server" Text="Observación"></asp:Label>
                                                    </td>
                                                    <td class="label">
                                                        <asp:Label ID="Label77" runat="server" Text="Médico"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtComentario" runat="server" CssClass="inputNormal" 
                                                            Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td class="label">
                                                        <asp:Label ID="lblMedico" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="70">
                                                                    <asp:ImageButton ID="ibAgregar" runat="server" 
                                                                        ImageUrl="~/images/Agregar.jpg" />
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="btnCancelar" runat="server" 
                                                                        ImageUrl="~/images/Cancelar.jpg" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        

                                    
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                                            CssClass="grid" DataKeyNames="i_IdVacunacion" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="v_Descripcion" HeaderText="Vacuna">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="d_FechaVacunacion" HeaderText="Fecha Aplicación" />
                                                <asp:BoundField HeaderText="Médico" />
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/images/edit.png" 
                                                            ToolTip="Editar" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                
                            </table>
                            

                            
                        </ContentTemplate>
                        
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Antipulgas">
                        <ContentTemplate>
                            <table cellpadding="5" width="100%">
                                <tr>
                                    <td class="label">
                                        &nbsp;</td>
                                    <td class="label">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        <asp:Label ID="Label79" runat="server" Text="Fecha de Antipulgas:"></asp:Label>
                                    </td>
                                    <td class="label">
                                        <asp:Label ID="Label80" runat="server" Text="Sucursal"></asp:Label>
                                    </td>
                                </tr>
                                <tr ID="filaCodigo2" runat="server">
                                    <td runat="server">
                                        <asp:TextBox ID="txtFechaAntipulgas" runat="server" CssClass="inputsFecha" 
                                            MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtFechaAntipulgas_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaAntipulgas">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td runat="server">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="155">
                                                    <asp:DropDownList ID="ddlAlmacenAntip" runat="server" CssClass="combo" 
                                                        Width="150px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ibSucursal1" runat="server" 
                                                        ImageUrl="~/images/auth_ok.png" OnClick="ibSucursal1_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        <asp:Label ID="Label81" runat="server" Text="Antipulgas"></asp:Label>
                                    </td>
                                    <td class="label">
                                        <asp:Label ID="Label82" runat="server" Text="Precio S/."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtAntipulgas" runat="server" CssClass="inputNormal" 
                                            Font-Size="20pt" Height="40px" MaxLength="50" Width="100%"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="txtAntipulgas_AutoCompleteExtender" 
                                            runat="server" CompletionInterval="100" CompletionListCssClass="AutoExtender" 
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                            CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                            Enabled="True" OnClientItemSelected="OnClienteSeleccionado2" 
                                            ServiceMethod="BuscarAntipulgas" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtAntipulgas" 
                                            UseContextKey="True" MinimumPrefixLength="1">
                                        </cc1:AutoCompleteExtender>
                                    </td>
                                    <td class="label">
                                        <asp:Label ID="lblPrecioAntip" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        <asp:Label ID="Label83" runat="server" Text="Observación"></asp:Label>
                                    </td>
                                    <td class="label">
                                        <asp:Label ID="Label84" runat="server" Text="Médico"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtComentarioAntip" runat="server" CssClass="inputNormal" 
                                            Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="label">
                                        <asp:Label ID="lblMedico1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="70">
                                                    <asp:ImageButton ID="ibAgregar0" runat="server" 
                                                        ImageUrl="~/images/Agregar.jpg" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnCancelar0" runat="server" 
                                                        ImageUrl="~/images/Cancelar.jpg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Antiparasitarios">
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Baño y Peluquería">
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel7" runat="server" HeaderText="Historial de Compras">
                    </cc1:TabPanel>

            </cc1:TabContainer>
                </td>
            <td width="20">
                </td>
        </tr>
        <tr>
            <td height="10" width="20">
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td width="20">
                </td>
        </tr>
        </table>
        </div>

            </td>
            <td width="15%">
                </td>
        </tr>
        <tr>
            <td width="15%">
                </td>
            <td>
                </td>
            <td width="15%">
                </td>
        </tr>
        <tr>
            <td width="15%">
                </td>
            <td>
                </td>
            <td width="15%">
                </td>
        </tr>
        <tr>
            <td width="15%">
                </td>
            <td>
                </td>
            <td width="15%">
                </td>
        </tr>
      </table>

</asp:Content>


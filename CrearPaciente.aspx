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
            .style1
            {
                width: 100%;
            }
 </style>


 <script type="text/javascript">

     function OnClienteSeleccionado(source, eventArgs) {

         var hdnValueID = "<%= hfIdProducto.ClientID %>";
         document.getElementById(hdnValueID).value = eventArgs.get_value();
         __doPostBack(hdnValueID, "");

     }

     function OnAntipulga(source, eventArgs) {

         var hdnValueID = "<%= hfAntipulga.ClientID %>";
         document.getElementById(hdnValueID).value = eventArgs.get_value();
         __doPostBack(hdnValueID, "");

     }

     function OnAntiparasito(source, eventArgs) {

         var hdnValueID = "<%= hfAntiparasito.ClientID %>";
         document.getElementById(hdnValueID).value = eventArgs.get_value();
         __doPostBack(hdnValueID, "");

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
                <asp:HiddenField ID="hfIdProducto" runat="server" 
                    onvaluechanged="hfIdProducto_ValueChanged" Value="0" />
                <asp:HiddenField ID="hfAntipulga" runat="server" 
                    onvaluechanged="hfAntipulga_ValueChanged" />
                <asp:HiddenField ID="hfAntiparasito" runat="server" 
                    onvaluechanged="hfAntiparasito_ValueChanged" />
                </td>
            <td width="20">
                </td>
        </tr>
        <tr>
            <td height="10" width="20">
                </td>
            <td>

                <asp:Label runat="server" Text="Paciente:" ID="Label96"></asp:Label>
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
                            

                            <table width="100%" style="margin-top: 0px">
                                <tr>
                                    <td>
                                        </td>
                                </tr>
                                
                                <tr>
                                    <td>

                   <cc1:TabContainer ID="tabVacunas" runat="server" Width="100%" CssClass="MyTabStyle" 
                                            ActiveTabIndex="0">

                    <cc1:TabPanel runat="server" HeaderText="Aplicar" ID="TabPanel8">
                        <HeaderTemplate>
                            Aplicar
                        </HeaderTemplate>
                        
                    <ContentTemplate>
                    <table cellpadding="5" width="100%">
                                            <tr runat="server">
                                                <td class="label" width="355" runat="server">
                                                    <asp:Label ID="Label78" runat="server" Text="Sucursal"></asp:Label>
                                                </td>
                                                <td class="label" width="160" runat="server">
                                                    <asp:Label ID="Label52" runat="server" Text="Fecha de Aplicación"></asp:Label>
                                                </td>
                                                <td class="label" runat="server">
                                                    <asp:Label ID="Label77" runat="server" Text="Médico"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td class="label" runat="server">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="350px">
                                                        <tr>
                                                            <td width="305px">
                                                                <asp:DropDownList ID="ddlAlmacen" runat="server" CssClass="combo" Width="300px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ibSucursal" runat="server" ImageUrl="~/images/auth_ok.png" 
                                                                    OnClick="ibSucursal_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td runat="server">
                                                    <asp:TextBox ID="txtFechaVacunacion" runat="server" CssClass="inputsFecha" 
                                                        Enabled="False" MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                                                        Format="dd/MM/yyyy" TargetControlID="txtFechaVacunacion">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td runat="server">
                                                    <asp:Label ID="lblMedicoVacuna" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td class="label" runat="server" colspan="3">
                                                    <asp:Label ID="Label73" runat="server" Text="Vacuna"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3">
                                                    <asp:TextBox ID="txtVacuna" runat="server" CssClass="inputNormal" 
                                                        Enabled="False" Font-Size="20pt" Height="40px" MaxLength="50" 
                                                        Width="100%"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="txtVacuna_AutoCompleteExtender" runat="server" 
                                                        CompletionInterval="100" CompletionListCssClass="AutoExtender" 
                                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                        CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                        Enabled="True" MinimumPrefixLength="1" 
                                                        OnClientItemSelected="OnClienteSeleccionado" ServiceMethod="BuscarVacunas" 
                                                        ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                                        TargetControlID="txtVacuna" UseContextKey="True">
                                                    </cc1:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" class="label" colspan="3">
                                                    <asp:Label ID="Label76" runat="server" Text="Precio S/."></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3">
                                                    <asp:Label ID="lblPrecioVacuna" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td class="label" runat="server" colspan="3">
                                                    <asp:Label ID="Label75" runat="server" Text="Observación"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td colspan="3" runat="server">
                                                    <asp:TextBox ID="txtComentarioVacunacion" runat="server" CssClass="inputNormal" 
                                                        Enabled="False" Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td colspan="3" runat="server">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="70">
                                                                <asp:ImageButton ID="ibAceptarAplicaVacuna" runat="server" Enabled="False" 
                                                                    ImageUrl="~/images/Guardar.jpg" onclick="ibAceptarAplicaVacuna_Click" />
                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender12" runat="server" 
                                ConfirmText="¿Seguro de guardar los datos?" Enabled="True" 
                                TargetControlID="ibAceptarAplicaVacuna">
                    </cc1:ConfirmButtonExtender>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                        <br />
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                            Caption="Vacunas (Aplicadas)" CssClass="grid" DataKeyNames="i_IdVacunacion" 
                            Width="100%">
                            <Columns>
                                <asp:BoundField DataField="v_Descripcion" HeaderText="Vacuna">
                                <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="d_FechaVacunacion" HeaderText="Fecha Aplicación" />
                                <asp:BoundField DataField="v_Nombre" HeaderText="Médico" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/images/edit.png" 
                                            ToolTip="Editar" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quitar">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnQuitar" runat="server" ImageUrl="~/images/delete.gif" 
                                            ToolTip="Quitar" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    </cc1:TabPanel>

                       <cc1:TabPanel ID="tabProgramar" runat="server" HeaderText="Programar">
                           <ContentTemplate>
                               <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                   <tr>
                                       <td class="label">
                                           <asp:Label ID="Label85" runat="server" Text="Fecha Programada"></asp:Label>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           <asp:TextBox ID="txtFechaVacunacionProg" runat="server" CssClass="inputsFecha" 
                                               MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                           <cc1:CalendarExtender ID="txtFechaVacunacionProg_CalendarExtender" 
                                               runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                               TargetControlID="txtFechaVacunacionProg">
                                           </cc1:CalendarExtender>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td class="label">
                                           <asp:Label ID="Label86" runat="server" Text="Vacuna"></asp:Label>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           <asp:TextBox ID="txtVacunaProg" runat="server" CssClass="inputNormal" 
                                               Font-Size="20pt" Height="40px" MaxLength="50" Width="100%"></asp:TextBox>
                                           <cc1:AutoCompleteExtender ID="txtVacunaProg_AutoCompleteExtender" 
                                               runat="server" CompletionInterval="100" CompletionListCssClass="AutoExtender" 
                                               CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                               CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                               Enabled="True" MinimumPrefixLength="1" 
                                               OnClientItemSelected="OnClienteSeleccionado" ServiceMethod="BuscarVacunas" 
                                               ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                               TargetControlID="txtVacunaProg" UseContextKey="True">
                                           </cc1:AutoCompleteExtender>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                               <tr>
                                                   <td width="70">
                                                       <asp:ImageButton ID="ibAceptarVacunaProg" runat="server" 
                                                           ImageUrl="~/images/Guardar.jpg" onclick="ibAceptarVacunaProg_Click" />
                                                       <cc1:ConfirmButtonExtender ID="ibAceptarVacunaProg_ConfirmButtonExtender" 
                                                           runat="server" ConfirmText="¿Seguro de guardar los datos?" Enabled="True" 
                                                           TargetControlID="ibAceptarVacunaProg">
                                                       </cc1:ConfirmButtonExtender>
                                                   </td>
                                                   <td>
                                                       &nbsp;</td>
                                               </tr>
                                           </table>
                                       </td>
                                   </tr>
                               </table>
                               <br />
                               <asp:GridView ID="gvProgVacuna" runat="server" Caption="Vacunas (Programación)" 
                                   CssClass="grid" AutoGenerateColumns="False" 
                                   DataKeyNames="i_IdProgramacion">
                                   <Columns>
                                       <asp:BoundField DataField="d_FechaProgramacion" HeaderText="Fecha" />
                                       <asp:BoundField DataField="SubCategoria" HeaderText="Sub Categoría" />
                                       <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                   </Columns>
                               </asp:GridView>
                           </ContentTemplate>
                       </cc1:TabPanel>

                    </cc1:TabContainer>

                                        
                                    </td>
                                </tr>
                                
                            </table>
                            

                            
                        </ContentTemplate>
                        
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Antipulgas">

                        <ContentTemplate>
                            <table style="margin-top: 0px" width="100%">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <cc1:TabContainer ID="tabAntipulga" runat="server" ActiveTabIndex="0" 
                                            CssClass="MyTabStyle" Width="100%">
                                            <cc1:TabPanel ID="TabPanel9" runat="server" HeaderText="Aplicar">
                                                <HeaderTemplate>
                                                    Aplicar
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <table cellpadding="5" width="100%">
                                                        <tr runat="server">
                                                            <td runat="server" class="label" width="355">
                                                                <asp:Label ID="Label88" runat="server" Text="Sucursal"></asp:Label>
                                                            </td>
                                                            <td runat="server" class="label" width="160">
                                                                <asp:Label ID="Label89" runat="server" Text="Fecha de Aplicación"></asp:Label>
                                                            </td>
                                                            <td runat="server" class="label">
                                                                <asp:Label ID="Label90" runat="server" Text="Médico"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" class="label">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="350px">
                                                                    <tr>
                                                                        <td width="305px">
                                                                            <asp:DropDownList ID="ddlSucursalAntipulgas" runat="server" CssClass="combo" 
                                                                                Width="300px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="ibSucursalAntipulga" runat="server" 
                                                                                ImageUrl="~/images/auth_ok.png" OnClick="ibSucursalAntipulga_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td runat="server">
                                                                <asp:TextBox ID="txtFechaAntipulga" runat="server" CssClass="inputsFecha" 
                                                                    Enabled="False" MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" 
                                                                    Format="dd/MM/yyyy" TargetControlID="txtFechaAntipulga">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td runat="server">
                                                                <asp:Label ID="lblMedicoAntipulga" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" class="label" colspan="3">
                                                                <asp:Label ID="Label91" runat="server" Text="Antipulga"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" colspan="3">
                                                                <asp:TextBox ID="txtAntipulga" runat="server" CssClass="inputNormal" 
                                                                    Enabled="False" Font-Size="20pt" Height="40px" MaxLength="50" Width="100%"></asp:TextBox>
                                                                <cc1:AutoCompleteExtender ID="txtAntipulga_AutoCompleteExtender" runat="server" 
                                                                    BehaviorID="txtAntipulga_AutoCompleteExtender" CompletionInterval="100" 
                                                                    CompletionListCssClass="AutoExtender" 
                                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                                    Enabled="True" MinimumPrefixLength="1" 
                                                                    OnClientItemSelected="OnAntipulga" ServiceMethod="BuscarAntipulgas" 
                                                                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                                                    TargetControlID="txtAntipulga" UseContextKey="True">
                                                                </cc1:AutoCompleteExtender>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" class="label" colspan="3">
                                                                <asp:Label ID="Label92" runat="server" Text="Precio S/."></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" colspan="3">
                                                                <asp:Label ID="lblPrecioAntipulga" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" class="label" colspan="3">
                                                                <asp:Label ID="Label93" runat="server" Text="Observación"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" colspan="3">
                                                                <asp:TextBox ID="txtComentarioAntipulga" runat="server" CssClass="inputNormal" 
                                                                    Enabled="False" Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" colspan="3">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td width="70">
                                                                            <asp:ImageButton ID="ibAceptarAplicaAntipulga" runat="server" Enabled="False" 
                                                                                ImageUrl="~/images/Guardar.jpg" onclick="ibAceptarAplicaAntipulga_Click" />
                                                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender13" runat="server" 
                                                                                ConfirmText="¿Seguro de guardar los datos?" Enabled="True" 
                                                                                TargetControlID="ibAceptarAplicaAntipulga">
                                                                            </cc1:ConfirmButtonExtender>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <asp:GridView ID="gvAntipulgaAplicada" runat="server" 
                                                        AutoGenerateColumns="False" Caption="Antipulga (Aplicados)" CssClass="grid" 
                                                        DataKeyNames="i_IdAntipulga" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="v_Descripcion" HeaderText="Antipulga">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="d_FechaAntipulga" HeaderText="Fecha Aplicación" />
                                                            <asp:BoundField DataField="v_Nombre" HeaderText="Médico" />
                                                            <asp:TemplateField HeaderText="Editar">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnEditar0" runat="server" ImageUrl="~/images/edit.png" 
                                                                        ToolTip="Editar" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quitar">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnQuitar0" runat="server" ImageUrl="~/images/delete.gif" 
                                                                        ToolTip="Quitar" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </cc1:TabPanel>
                                            <cc1:TabPanel ID="tabProgramar0" runat="server" HeaderText="Programar">
                                                <ContentTemplate>
                                                    <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td class="label">
                                                                <asp:Label ID="Label94" runat="server" Text="Fecha Programada"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtFechaAntipulgaProg" runat="server" CssClass="inputsFecha" 
                                                                    MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="txtFechaAntipulgaProg_CalendarExtender" 
                                                                    runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                                    TargetControlID="txtFechaAntipulgaProg">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="label">
                                                                <asp:Label ID="Label95" runat="server" Text="Vacuna"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtAntipulgaProg" runat="server" CssClass="inputNormal" 
                                                                    Font-Size="20pt" Height="40px" MaxLength="50" Width="100%"></asp:TextBox>
                                                                <cc1:AutoCompleteExtender ID="txtAntipulgaProg_AutoCompleteExtender" 
                                                                    runat="server" CompletionInterval="100" CompletionListCssClass="AutoExtender" 
                                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                                    CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                                    Enabled="True" MinimumPrefixLength="1" 
                                                                    OnClientItemSelected="OnClienteSeleccionado" ServiceMethod="BuscarAntipulgas" 
                                                                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                                                    TargetControlID="txtAntipulgaProg" UseContextKey="True">
                                                                </cc1:AutoCompleteExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td width="70">
                                                                            <asp:ImageButton ID="ibAceptarAntipulgaProg" runat="server" 
                                                                                ImageUrl="~/images/Guardar.jpg" />
                                                                            <cc1:ConfirmButtonExtender ID="ibAceptarVacunaProg_ConfirmButtonExtender0" 
                                                                                runat="server" BehaviorID="ibAceptarAntipulgasProg_ConfirmButtonExtender" 
                                                                                ConfirmText="¿Seguro de guardar los datos?" Enabled="True" 
                                                                                TargetControlID="ibAceptarAntipulgaProg">
                                                                            </cc1:ConfirmButtonExtender>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <asp:GridView ID="gvProgAntipulga" runat="server" 
                                                        Caption="Antipulga (Programación)" CssClass="grid">
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </cc1:TabPanel>
                                        </cc1:TabContainer>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>

                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Antiparasitarios">
                        <ContentTemplate>
                            <cc1:TabContainer ID="tabAntiparasito" runat="server" ActiveTabIndex="0" 
                                CssClass="MyTabStyle" Width="100%">
                                <cc1:TabPanel ID="TabPanel10" runat="server" HeaderText="Aplicar">
                                    <HeaderTemplate>
                                        Aplicar
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table cellpadding="5" width="100%">
                                            <tr runat="server">
                                                <td runat="server" class="label" width="355">
                                                    <asp:Label ID="Label97" runat="server" Text="Sucursal"></asp:Label>
                                                </td>
                                                <td runat="server" class="label" width="160">
                                                    <asp:Label ID="Label98" runat="server" Text="Fecha de Aplicación"></asp:Label>
                                                </td>
                                                <td runat="server" class="label">
                                                    <asp:Label ID="Label99" runat="server" Text="Médico"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" class="label">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="350px">
                                                        <tr>
                                                            <td width="305px">
                                                                <asp:DropDownList ID="ddlAlmacenAntiparasito" runat="server" CssClass="combo" 
                                                                    Width="300px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ibSucursalAntiparasito" runat="server" 
                                                                    ImageUrl="~/images/auth_ok.png" OnClick="ibSucursalAntiparasito_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td runat="server">
                                                    <asp:TextBox ID="txtFechaAntiparasito" runat="server" CssClass="inputsFecha" 
                                                        Enabled="False" MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" 
                                                        Format="dd/MM/yyyy" TargetControlID="txtFechaAntiparasito">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td runat="server">
                                                    <asp:Label ID="lblMedicoAntiparasito" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" class="label" colspan="3">
                                                    <asp:Label ID="Label100" runat="server" Text="Antiparásito"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3">
                                                    <asp:TextBox ID="txtAntiparasito" runat="server" CssClass="inputNormal" 
                                                        Enabled="False" Font-Size="20pt" Height="40px" MaxLength="50" Width="100%"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="txtAntiparasito_AutoCompleteExtender" 
                                                        runat="server" CompletionInterval="100" CompletionListCssClass="AutoExtender" 
                                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                        CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                        Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnAntiparasito" 
                                                        ServiceMethod="BuscarAntiparasitos" ServicePath="" 
                                                        ShowOnlyCurrentWordInCompletionListItem="True" 
                                                        TargetControlID="txtAntiparasito" UseContextKey="True">
                                                    </cc1:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" class="label" colspan="3">
                                                    <asp:Label ID="Label101" runat="server" Text="Precio S/."></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3">
                                                    <asp:Label ID="lblPrecioAntiparasito" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" class="label" colspan="3">
                                                    <asp:Label ID="Label102" runat="server" Text="Observación"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3">
                                                    <asp:TextBox ID="txtComentarioAntiparasito" runat="server" 
                                                        CssClass="inputNormal" Enabled="False" Height="50px" TextMode="MultiLine" 
                                                        Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" colspan="3">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="70">
                                                                <asp:ImageButton ID="ibAceptarAplicaAntiparasito" runat="server" 
                                                                    Enabled="False" ImageUrl="~/images/Guardar.jpg" 
                                                                    onclick="ibAceptarAplicaAntiparasito_Click" />
                                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender14" runat="server" 
                                                                    ConfirmText="¿Seguro de guardar los datos?" Enabled="True" 
                                                                    TargetControlID="ibAceptarAplicaAntiparasito">
                                                                </cc1:ConfirmButtonExtender>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:GridView ID="gvAntiparasito" runat="server" AutoGenerateColumns="False" 
                                            Caption="Antiparásito (Aplicadas)" CssClass="grid" 
                                            DataKeyNames="i_IdAntiparasito" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="v_Descripcion" HeaderText="Antiparásito">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="d_FechaAntiparasito" HeaderText="Fecha Aplicación" />
                                                <asp:BoundField DataField="v_Nombre" HeaderText="Médico" />
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEditar1" runat="server" ImageUrl="~/images/edit.png" 
                                                            ToolTip="Editar" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quitar">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnQuitar1" runat="server" ImageUrl="~/images/delete.gif" 
                                                            ToolTip="Quitar" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="tabProgramar1" runat="server" HeaderText="Programar">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                            <tr>
                                                <td class="label">
                                                    <asp:Label ID="Label103" runat="server" Text="Fecha Programada"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtFechaAntiparasitoProg" runat="server" 
                                                        CssClass="inputsFecha" MaxLength="15" placeholder="Inicio"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtFechaAntiparasitoProg_CalendarExtender" 
                                                        runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                        TargetControlID="txtFechaAntiparasitoProg">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label">
                                                    <asp:Label ID="Label104" runat="server" Text="Antiparásito"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAntiparasitoProg" runat="server" CssClass="inputNormal" 
                                                        Font-Size="20pt" Height="40px" MaxLength="50" Width="100%"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="txtAntiparasitoProg_AutoCompleteExtender" 
                                                        runat="server" CompletionInterval="100" CompletionListCssClass="AutoExtender" 
                                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                                        CompletionListItemCssClass="AutoExtenderList" DelimiterCharacters="" 
                                                        Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnAntiparasito" 
                                                        ServiceMethod="BuscarAntiparasitos" ServicePath="" 
                                                        ShowOnlyCurrentWordInCompletionListItem="True" 
                                                        TargetControlID="txtAntiparasitoProg" UseContextKey="True">
                                                    </cc1:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="70">
                                                                <asp:ImageButton ID="ibAceptarAntiparasitoProg" runat="server" 
                                                                    ImageUrl="~/images/Guardar.jpg" />
                                                                <cc1:ConfirmButtonExtender ID="ibAceptarAntiparasitoProg_ConfirmButtonExtender" 
                                                                    runat="server" ConfirmText="¿Seguro de guardar los datos?" Enabled="True" 
                                                                    TargetControlID="ibAceptarAntiparasitoProg">
                                                                </cc1:ConfirmButtonExtender>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:GridView ID="gvProgAntiparasito" runat="server" 
                                            Caption="Antiparásito (Programación)" CssClass="grid">
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>
                        </ContentTemplate>
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Baño y Peluquería">
                    </cc1:TabPanel>

                    <cc1:TabPanel ID="TabPanel7" runat="server" HeaderText="Historial de Compras">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <table class="style1">
                                            <tr>
                                                <td width="50">
                                                    <asp:Label ID="Label87" runat="server" Text="Saldo:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSaldo" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvCuentaCorriente" runat="server" AutoGenerateColumns="False" 
                                            Caption="Cuenta Corriente" CssClass="grid" ShowFooter="True">
                                            <Columns>
                                                <asp:BoundField DataField="d_FechaMovimiento" HeaderText="Fecha Movimiento" />
                                                <asp:BoundField DataField="v_Descripcion" HeaderText="Producto / Servicio" />
                                                <asp:BoundField DataField="f_Venta" DataFormatString="{0:N2}" 
                                                    HeaderText="Venta">
                                                <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="f_Pago" DataFormatString="{0:N2}" HeaderText="Pago">
                                                <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="f_Saldo" DataFormatString="{0:N2}" 
                                                    HeaderText="Saldo">
                                                <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" />
                                                <asp:BoundField DataField="TipoDocumento" HeaderText="Tipo de Documento" />
                                                <asp:BoundField DataField="v_NroDocumento" HeaderText="Nro Documento" />
                                            </Columns>
                                            <FooterStyle CssClass="footer" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
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


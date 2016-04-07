<%@ Page Title="Listar Pacientes" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="ListarPaciente.aspx.cs" Inherits="ListarPaciente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2.Export, Version=11.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="divBusqueda">
            <table width="100%" cellpadding="3" cellspacing="3">
                <tr>
                    <td colspan="3">
                        <h1 class="label">
                            Administración de Pacientes</h1>
                    </td>
                </tr>
                <tr>
                    <td width="60">
                        <asp:Label ID="Label2" runat="server" Text="Buscar:"></asp:Label>
                    </td>
                    <td width="195">
                        <asp:DropDownList ID="ddlBusqueda" runat="server" Width="190px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlBusqueda_SelectedIndexChanged" CssClass="combo">
                            <asp:ListItem Selected="True">Nombre del Paciente</asp:ListItem>
                            <asp:ListItem>Nombre del Cliente</asp:ListItem>
                            <asp:ListItem>Fecha de Nacimiento</asp:ListItem>
                            <asp:ListItem>Fecha de Ultima Visita</asp:ListItem>
                            <asp:ListItem>Especie</asp:ListItem>
                            <asp:ListItem>Raza</asp:ListItem>
                            <asp:ListItem>Sexo</asp:ListItem>
                            <asp:ListItem>Estado</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBuscar" runat="server"
                            CssClass="inputs" placeholder="Nombre del Paciente" 
                            Width="200px" MaxLength="100"></asp:TextBox>
                        <asp:TextBox ID="txtBuscarCliente" runat="server"
                            CssClass="inputs" placeholder="Nombre del Cliente" 
                            Width="200px" MaxLength="100" Visible="False"></asp:TextBox>
                        <table cellpadding="0" cellspacing="0" width="100%" id="tblFiltroFecha" runat="server" visible="false">
                            <tr>
                                <td width="110">
                                    <asp:TextBox ID="txtFechaInicial" runat="server" CssClass="inputsFecha" placeholder="Inicio" 
                                        MaxLength="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Format="dd/MM/yyyy" TargetControlID="txtFechaInicial">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="inputsFecha" placeholder="Fin"
                                        MaxLength="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" 
                                        runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                        TargetControlID="txtFechaFinal">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                        </table>

                        <table cellpadding="0" cellspacing="0" width="100%" id="tblEspecie" runat="server" visible="false">
                            <tr>
                            <td width="205">
                                <asp:DropDownList ID="ddlEspecie" runat="server" AutoPostBack="True" 
                                    CssClass="combo" onselectedindexchanged="ddlEspecie_SelectedIndexChanged" 
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>

                        <table cellpadding="0" cellspacing="0" width="100%" id="tblRaza" runat="server" visible="false">
                            <tr>
                            <td>
                                <asp:DropDownList ID="ddlRaza" runat="server" CssClass="combo" Width="200px">
                                </asp:DropDownList>
                            </td>
                            </tr>
                        </table>

                            </td>
                            </tr>
                        </table>

                        <table cellpadding="0" cellspacing="0" width="100%" id="tblSexo" runat="server" visible="false">
                            <tr>
                            <td>
                                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="combo" Width="200px">
                                </asp:DropDownList>
                            </td>
                            </tr>
                        </table>

                        <table cellpadding="0" cellspacing="0" width="100%" id="tblEstado" runat="server" visible="false">
                            <tr>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="combo" Width="200px">
                                </asp:DropDownList>
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
                        <asp:ImageButton ID="btnExportar" runat="server" 
                            ImageUrl="~/images/Exportar.jpg" onclick="btnExportar_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnSalir" runat="server" ImageUrl="~/images/Salir.jpg" 
                            onclick="btnSalir_Click" />
                    </td>
                </tr>
            </table>
        </div>

            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                FileName="Pacientes" GridViewID="gv" Landscape="True" PaperKind="A4">
            </dx:ASPxGridViewExporter>
            <dx1:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" 
                CssFilePath="~/App_Themes/PlasticBlue/{0}/styles.css" 
                CssPostfix="PlasticBlue" EnableCallbackCompression="False" 
                EnableCallBacks="False" EnableRowsCache="False" EnableTheming="False" 
                EnableViewState="False" KeyFieldName="i_IdPaciente" 
                Width="100%" 
            onbeforecolumnsortinggrouping="gv_BeforeColumnSortingGrouping" 
            onhtmlrowprepared="gv_HtmlRowPrepared">
                <TotalSummary>
                    <dx1:ASPxSummaryItem DisplayFormat="{0:C}" FieldName="f_Total" 
                        ShowInColumn="Total" ShowInGroupFooterColumn="Total" SummaryType="Sum" />
                </TotalSummary>
                <Columns>
                    <dx1:GridViewDataTextColumn Caption="Cliente" FieldName="v_Nombres" 
                        VisibleIndex="1" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Paciente" FieldName="v_NombrePaciente" 
                        VisibleIndex="0" Width="100px">
                        <DataItemTemplate>
                            <asp:LinkButton ID="lbPaciente" runat="server" 
                                Text='<%# Bind("v_NombrePaciente") %>'></asp:LinkButton>
                        </DataItemTemplate>
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Especie" FieldName="Especie" 
                        VisibleIndex="2" Width="80px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Raza" FieldName="Raza" VisibleIndex="3" 
                        Width="80px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Sexo" FieldName="Sexo" VisibleIndex="4" 
                        Width="80px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Fecha de Nacimiento" 
                        FieldName="d_FechaNacimiento" VisibleIndex="5" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Fecha Ultima Visita" 
                        FieldName="d_FechaUltimaVisita" VisibleIndex="6" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Fecha Ultimo Baño" 
                        FieldName="d_FechaUltimoBaño" VisibleIndex="7" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Fecha Ultima Vacuna" 
                        FieldName="d_FechaUltimaVacuna" VisibleIndex="8" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Fecha Ultima ATP" 
                        FieldName="d_FechaUltimaATP" VisibleIndex="9" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Fecha Ultima APG" 
                        FieldName="d_FechaUltimaAPG" VisibleIndex="10" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Microchip" FieldName="v_Microchip" 
                        VisibleIndex="11" Width="80px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Estado" FieldName="v_Estado" 
                        VisibleIndex="12" Width="80px">
                    </dx1:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AutoFilterRowInputDelay="0" />
                <SettingsPager PageSize="5" ShowDefaultImages="False">
                    <AllButton Text="All">
                    </AllButton>
                    <NextPageButton Text="Next &gt;">
                    </NextPageButton>
                    <PrevPageButton Text="&lt; Prev">
                    </PrevPageButton>
                </SettingsPager>
                <SettingsCookies StoreFiltering="False" />
                <SettingsDetail />
                <Images SpriteCssFilePath="~/App_Themes/PlasticBlue/{0}/sprite.css">
                    <LoadingPanelOnStatusBar Url="~/App_Themes/PlasticBlue/GridView/gvLoadingOnStatusBar.gif">
                    </LoadingPanelOnStatusBar>
                    <LoadingPanel Url="~/App_Themes/PlasticBlue/GridView/Loading.gif">
                    </LoadingPanel>
                </Images>
                <ImagesFilterControl>
                    <LoadingPanel Url="~/App_Themes/PlasticBlue/Editors/Loading.gif">
                    </LoadingPanel>
                </ImagesFilterControl>
                <Styles CssFilePath="~/App_Themes/PlasticBlue/{0}/styles.css" 
                    CssPostfix="PlasticBlue">
                    <Header ImageSpacing="10px" SortingImageSpacing="10px">
                    </Header>
                </Styles>
                <StylesEditors>
                    <CalendarHeader Spacing="11px">
                    </CalendarHeader>
                    <ProgressBar Height="25px">
                    </ProgressBar>
                </StylesEditors>
            </dx1:ASPxGridView>
        
</asp:Content>


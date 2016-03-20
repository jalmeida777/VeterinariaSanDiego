<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.master" AutoEventWireup="true" CodeFile="ListarCliente.aspx.cs" Inherits="ListarCliente" %>
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
                            Administración de Clientes</h1>
                    </td>
                </tr>
                <tr>
                    <td width="60">
                        <asp:Label ID="Label2" runat="server" Text="Buscar:"></asp:Label>
                    </td>
                    <td width="155">
                        <asp:DropDownList ID="ddlBusqueda" runat="server" Width="150px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlBusqueda_SelectedIndexChanged" CssClass="combo">
                            <asp:ListItem Selected="True">Nombre</asp:ListItem>
                            <asp:ListItem>Fecha de Registro</asp:ListItem>
                            <asp:ListItem>Fecha de Ultima Visita</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBuscar" runat="server"
                            CssClass="inputs" placeholder="Nombre del Cliente" 
                            Width="200px" MaxLength="100"></asp:TextBox>
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
                    </td>
                </tr>
                <tr>
                    <td width="60">
                        &nbsp;</td>
                    <td width="155">
                        &nbsp;</td>
                    <td>
                        <asp:CheckBox ID="chkEstado" runat="server" Checked="True" 
                            Text="Ver Habilitados" />
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

        <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Vertical" 
                Width="100%">
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                FileName="Clientes" GridViewID="gv" Landscape="True" PaperKind="A4">
            </dx:ASPxGridViewExporter>
            <dx1:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" 
                CssFilePath="~/App_Themes/PlasticBlue/{0}/styles.css" 
                CssPostfix="PlasticBlue" EnableCallbackCompression="False" 
                EnableCallBacks="False" EnableRowsCache="False" EnableTheming="False" 
                EnableViewState="False" KeyFieldName="i_IdCliente" SettingsDetail-ShowDetailButtons="true"
                Width="100%" 
                onbeforecolumnsortinggrouping="gv_BeforeColumnSortingGrouping" 
                onhtmlrowprepared="gv_HtmlRowPrepared">
                <TotalSummary>
                    <dx1:ASPxSummaryItem DisplayFormat="{0:C}" FieldName="f_Total" 
                        ShowInColumn="Total" ShowInGroupFooterColumn="Total" SummaryType="Sum" />
                </TotalSummary>
                <Columns>
                    <dx1:GridViewDataTextColumn Caption="Cliente" FieldName="v_Nombres" 
                        VisibleIndex="0" Width="200px">
                        <DataItemTemplate>
                            <asp:LinkButton ID="lbCliente" runat="server" Text='<%# Bind("v_Nombres") %>'></asp:LinkButton>
                        </DataItemTemplate>
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Celular" FieldName="v_Celular" 
                        VisibleIndex="1" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Teléfono" FieldName="v_Telefono" 
                        VisibleIndex="2" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Email" FieldName="v_Email" 
                        VisibleIndex="3" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Distrito" FieldName="Distrito" 
                        VisibleIndex="4" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Total Facturado" 
                        FieldName="TotalFacturado" VisibleIndex="5" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Total Pagado" FieldName="TotalPagado" 
                        VisibleIndex="6" Width="100px">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn Caption="Saldo Total" FieldName="SaldoTotal" 
                        VisibleIndex="7" Width="100px">
                    </dx1:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AutoFilterRowInputDelay="0" />
                <SettingsBehavior AutoFilterRowInputDelay="0" />
                <SettingsBehavior AutoFilterRowInputDelay="0" />
                <SettingsBehavior AutoFilterRowInputDelay="0" />
                <SettingsPager PageSize="5" ShowDefaultImages="False">
                    <AllButton Text="All">
                    </AllButton>
                    <NextPageButton Text="Next &gt;">
                    </NextPageButton>
                    <PrevPageButton Text="&lt; Prev">
                    </PrevPageButton>
                </SettingsPager>
                <Settings ShowFooter="True" />
                <SettingsCookies StoreFiltering="False" />
                <SettingsDetail ShowDetailRow="True" />
                <Settings ShowFooter="True" />
                <SettingsCookies StoreFiltering="False" />
                <SettingsDetail ShowDetailRow="True" />
                <Settings ShowFooter="True" />
                <SettingsCookies StoreFiltering="False" />
                <SettingsDetail ShowDetailRow="True" />
                <Settings ShowFooter="True" />
                <SettingsCookies StoreFiltering="False" />
                <settingsdetail showdetailbuttons="False" />
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
        </asp:Panel>

</asp:Content>


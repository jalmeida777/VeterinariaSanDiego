using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.IO;
using System.Drawing;
using DevExpress.Web.ASPxGridView;

public partial class ListarCliente : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFinal.Text = DateTime.Now.ToShortDateString();

            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Clientes";
            }
            Listar();
        }
        txtBuscar.Focus();
    }

    void Listar()
    {
        string FechaInicial = DateTime.Parse(txtFechaInicial.Text).Year.ToString("0000") + DateTime.Parse(txtFechaInicial.Text).Month.ToString("00") + DateTime.Parse(txtFechaInicial.Text).Day.ToString("00");
        string FechaFinal = DateTime.Parse(txtFechaFinal.Text).Year.ToString("0000") + DateTime.Parse(txtFechaFinal.Text).Month.ToString("00") + DateTime.Parse(txtFechaFinal.Text).Day.ToString("00");

        string Estado = "";
        if (chkEstado.Checked) { Estado = "1"; } else { Estado = "0"; }

        string consulta = "";
        consulta = consulta + "SELECT  cli.i_IdCliente,cli.v_Nombres,cli.v_Celular,cli.v_Telefono,cli.v_Email, ";
        consulta = consulta + "0 as 'TotalFacturado',0 as 'TotalPagado', 0 as 'SaldoTotal',dis.v_Descripcion as 'Distrito' ";
        consulta = consulta + "FROM Cliente cli left join Distrito dis on cli.i_IdDistrito = dis.i_IdDistrito ";

        if (ddlBusqueda.SelectedValue == "Nombre")
        {
            consulta = consulta + " where cli.v_Nombres like '%" + txtBuscar.Text.Trim() + "%' ";
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Registro")
        {
            consulta = consulta + " where convert(char(8),d_FechaRegistro,112) between '" + FechaInicial + "' and '" + FechaFinal + "' ";
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Ultima Visita")
        {
            consulta = consulta + " where convert(char(8),d_FechaUltimaVisita,112) between '" + FechaInicial + "' and '" + FechaFinal + "' ";
        }

        consulta = consulta + " and cli.b_Estado = " + Estado;
        consulta = consulta + " order by cli.v_Nombres";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
        da.Fill(dt);

        gv.DataSource = dt;
        gv.DataBind();

    }

    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CrearCliente.aspx");
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }

    protected void ddlBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBusqueda.SelectedValue == "Nombre") 
        {
            txtBuscar.Visible = true;
            tblFiltroFecha.Visible = false;
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Registro") 
        {
            txtBuscar.Visible = false;
            tblFiltroFecha.Visible = true;
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Ultima Visita") 
        {
            txtBuscar.Visible = false;
            tblFiltroFecha.Visible = true;
        }
    }

    protected void gv_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
    {
        Listar();
    }

    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
        ASPxGridViewExporter1.WriteXlsToResponse();
    }

    protected void gv_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            string i_IdCliente = e.GetValue("i_IdCliente").ToString();

            LinkButton lbCliente = new LinkButton();
            lbCliente = (LinkButton)gv.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)(gv.Columns[0]), "lbCliente");

            lbCliente.PostBackUrl = "CrearCliente.aspx?i_IdCliente=" + i_IdCliente;

        }
    }
}
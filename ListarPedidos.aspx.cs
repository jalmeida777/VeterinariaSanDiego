﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.Web.ASPxGridView;

public partial class ListarPedidos : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFinal.Text = DateTime.Now.ToShortDateString();
            ListarEmpresas();
            Listar();
        }
    }

    void Listar()
    {
        try
        {
            string FechaInicial = DateTime.Parse(txtFechaInicial.Text).Year.ToString("0000") + DateTime.Parse(txtFechaInicial.Text).Month.ToString("00") + DateTime.Parse(txtFechaInicial.Text).Day.ToString("00");
            string FechaFinal = DateTime.Parse(txtFechaFinal.Text).Year.ToString("0000") + DateTime.Parse(txtFechaFinal.Text).Month.ToString("00") + DateTime.Parse(txtFechaFinal.Text).Day.ToString("00");
            lblFechaInicial.Text = FechaInicial;
            lblFechaFinal.Text = FechaFinal;
            if (ddlEmpresa.SelectedIndex == 0)
            {
                lblEmpresa.Text = "%";
            }
            else
            {
                lblEmpresa.Text = ddlEmpresa.SelectedItem.Text;
            }
        }
        catch (Exception)
        {

        }
    }

    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
    }

    void ListarEmpresas() 
    {
        SqlDataAdapter da = new SqlDataAdapter("Faregas_Empresa_Combo", conexion);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ddlEmpresa.DataSource = dt;
        ddlEmpresa.DataTextField = "v_RazonSocial";
        ddlEmpresa.DataValueField = "i_IdEmpresa";
        ddlEmpresa.DataBind();
        ddlEmpresa.Items.Insert(0, "Todas");
    }


    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        int i_IdMenu = int.Parse(Request.QueryString["IdMenu"]);
        Response.Redirect("CrearPedido.aspx?td=1&IdMenu=" + i_IdMenu);
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }

    protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            string n_IdPedido = e.GetValue("n_IdPedido").ToString();
            int i_IdMenu = int.Parse(Request.QueryString["IdMenu"]);

            LinkButton LinkButton1 = new LinkButton();
            LinkButton1 = (LinkButton)ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)(ASPxGridView1.Columns[0]), "LinkButton1");

            LinkButton1.PostBackUrl = "CrearPedido.aspx?n_IdPedido=" + n_IdPedido + "&td=1&IdMenu=" + i_IdMenu;

        }
    }
    protected void gvDetalle_BeforePerformDataSelect(object sender, EventArgs e)
    {
        Session["n_IdPedido"] = (sender as ASPxGridView).GetMasterRowKeyValue();
    }
}
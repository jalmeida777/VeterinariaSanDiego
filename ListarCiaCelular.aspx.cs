﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ListarCiaCelular : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Compañia de Celulares";
            }
            Listar();
        }
        txtBuscar.Focus();
    }

    void Listar()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_CiaCelular_Listar '" + txtBuscar.Text.Trim() + "'", conexion);
        da.Fill(dt);
        gvCiaCelular.DataSource = dt;
        gvCiaCelular.DataBind();
    }
    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }
    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        Listar();
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CrearCiaCelular.aspx");
    }

    protected void gvAlmacen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int i_IdCiaCelular = int.Parse(gvCiaCelular.DataKeys[e.Row.RowIndex].Value.ToString());
            ImageButton btnEditar = e.Row.FindControl("ibEditar") as ImageButton;

            if (btnEditar != null)
            {
                btnEditar.PostBackUrl = "CrearCiaCelular.aspx?i_IdCiaCelular=" + i_IdCiaCelular;
            }


        }
    }
}
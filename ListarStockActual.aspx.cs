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

public partial class Procesos_ListarStockActual : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dtUsuario"] == null) 
        {
            Response.Redirect("Login.aspx");
        }
        if (Page.IsPostBack == false)
        {
            ListarSucursal();
            Permisos();
        }
    }

    void ListarSucursal()
    {
        if (Session["dtAlmacenes"] != null)
        {
            DataTable dtAlmacen = new DataTable();
            dtAlmacen = (DataTable)Session["dtAlmacenes"];
            ddlAlmacen.DataSource = dtAlmacen;
            ddlAlmacen.DataTextField = "v_Descripcion";
            ddlAlmacen.DataValueField = "n_IdAlmacen";
            ddlAlmacen.DataBind();
            ddlAlmacen.SelectedIndex = 0;
            if (dtAlmacen.Rows.Count >= 1)
            {
                ddlAlmacen.Enabled = true;
            }
            else
            {
                ddlAlmacen.Enabled = false;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Su sesión ha caducado. Vuelva a ingresar al sistema.' });</script>", false);
        }
    }

    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }

    protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/ReporteStockActual.aspx");
    }

    protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            string n_IdProducto = e.GetValue("n_IdProducto").ToString();
            int i_IdMenu = int.Parse(Request.QueryString["IdMenu"]);

            LinkButton LinkButton1 = new LinkButton();
            LinkButton1 = (LinkButton)ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)(ASPxGridView1.Columns[4]), "LinkButton1");

            LinkButton1.PostBackUrl = "ListarKardex.aspx?n_IdProducto=" + n_IdProducto + "&n_IdAlmacen=" + ddlAlmacen.SelectedValue + "&origen=sucursal&IdMenu=" + i_IdMenu;

            LinkButton lbProducto = new LinkButton();
            lbProducto = (LinkButton)ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)(ASPxGridView1.Columns[2]), "lbProducto");
            lbProducto.PostBackUrl = "CrearProducto.aspx?n_IdProducto=" + n_IdProducto + "&IdMenu=30";
            lbProducto.Enabled = chkEditar.Checked;
        }
    }

    void Permisos()
    {
        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        int i_IdRol = int.Parse(dtUsuario.Rows[0]["i_IdRol"].ToString());
        int i_IdMenu = int.Parse(Request.QueryString["IdMenu"]);

        DataTable dtPermisos = new DataTable();
        SqlDataAdapter daPermisos = new SqlDataAdapter("Play_Permisos_Select " + i_IdRol + "," + i_IdMenu, conexion);
        daPermisos.Fill(dtPermisos);

        chkEditar.Checked = bool.Parse(dtPermisos.Rows[0]["b_Estado"].ToString());

    }
    protected void callbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
        int n_IdProducto = Convert.ToInt32(e.Parameter);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("select v_RutaImagen,v_CodigoInterno,v_Descripcion from producto where n_IdProducto=" + n_IdProducto, conexion);
        da.Fill(dt);
        lblCodigo.Text = dt.Rows[0]["v_CodigoInterno"].ToString();
        lblProducto.Text = dt.Rows[0]["v_Descripcion"].ToString();
        ImagenGrande.ImageUrl = dt.Rows[0]["v_RutaImagen"].ToString();
    }
}
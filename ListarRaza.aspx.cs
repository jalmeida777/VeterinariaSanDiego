using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ListarRaza : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Razas";
            }
            ListarEspecie();
            Listar();
        }
        txtBuscar.Focus();
    }

    void ListarEspecie()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Especie_Combo", conexion);
        da.Fill(dt);

        ddlEspecie.DataSource = dt;
        ddlEspecie.DataTextField = "v_Descripcion";
        ddlEspecie.DataValueField = "i_IdEspecie";
        ddlEspecie.DataBind();
        ddlEspecie.SelectedIndex = 0;
    }

    void Listar()
    {
        string Estado = "";
        if (chkEstado.Checked) { Estado = "1"; } else { Estado = "0"; }

        string i_IdEspecie = "";
        i_IdEspecie = ddlEspecie.SelectedValue.ToString();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Raza_Listar " + i_IdEspecie + ",'" + txtBuscar.Text.Trim() + "'," + Estado, conexion);
        da.Fill(dt);

        gvRaza.DataSource = dt;
        gvRaza.DataBind();
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CrearRaza.aspx");
    }
    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
    }

    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Listar();
    }

    protected void chkEstado_CheckedChanged(object sender, EventArgs e)
    {
        Listar();
    }

    protected void gvModelo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int i_IdRaza = int.Parse(gvRaza.DataKeys[e.Row.RowIndex].Value.ToString());
            ImageButton btnEditar = e.Row.FindControl("btnEditar") as ImageButton;

            if (btnEditar != null)
            {
                btnEditar.PostBackUrl = "CrearRaza.aspx?i_IdRaza=" + i_IdRaza;
            }
        }
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        Listar();
    }
}
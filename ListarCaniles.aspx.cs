using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ListarCaniles : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Caniles";
            }
            Listar();
        }
        txtBuscar.Focus();
    }


    void Listar()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Caniles_Listar '" + txtBuscar.Text.Trim() + "'", conexion);
        da.Fill(dt);

        gvCaniles.DataSource = dt;
        gvCaniles.DataBind();
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
        Response.Redirect("CrearCaniles.aspx");
    }
    protected void gvAlmacen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int i_IdCaniles = int.Parse(gvCaniles.DataKeys[e.Row.RowIndex].Value.ToString());
            ImageButton btnEditar = e.Row.FindControl("ibEditar") as ImageButton;

            if (btnEditar != null)
            {
                btnEditar.PostBackUrl = "CrearCaniles.aspx?i_IdCaniles=" + i_IdCaniles;
            }


        }
    }
}
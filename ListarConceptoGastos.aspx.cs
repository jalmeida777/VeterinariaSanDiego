using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ListarConceptoGastos : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Conceptos de Gastos";
            }
            Listar();
        }
        txtBuscar.Focus();
    }

    void Listar()
    {
        string Estado = "";
        if (chkEstado.Checked) { Estado = "1"; } else { Estado = "0"; }
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_ConceptoGastos_Listar '" + txtBuscar.Text.Trim() + "'," + Estado, conexion);
        da.Fill(dt);

        gvConceptoGastos.DataSource = dt;
        gvConceptoGastos.DataBind();
    }

    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CrearConceptoGasto.aspx");
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }

    protected void gvCategoria_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int i_IdConceptoGastos = int.Parse(gvConceptoGastos.DataKeys[e.Row.RowIndex].Value.ToString());
            ImageButton btnEditar = e.Row.FindControl("btnEditar") as ImageButton;

            if (btnEditar != null)
            {
                btnEditar.PostBackUrl = "CrearConceptoGasto.aspx?i_IdConceptoGastos=" + i_IdConceptoGastos;
            }
        }
    }

    protected void chkEstado_CheckedChanged(object sender, EventArgs e)
    {
        Listar();
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        Listar();
    }
}
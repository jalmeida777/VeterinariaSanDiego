using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ListarTipoDocumentoCliente : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Tipo de Documentos";
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
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_TipoDocumentoCliente_Listar '" + txtBuscar.Text.Trim() + "'," + Estado, conexion);
        
        da.Fill(dt);

        gvTipoDocumento.DataSource = dt;
        gvTipoDocumento.DataBind();
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

    protected void gvAlmacen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int i_TipoDocCliente = int.Parse(gvTipoDocumento.DataKeys[e.Row.RowIndex].Value.ToString());
            ImageButton btnEditar = e.Row.FindControl("ibEditar") as ImageButton;

            if (btnEditar != null)
            {
                btnEditar.PostBackUrl = "CrearTipoDocumentoCliente.aspx?i_TipoDocCliente=" + i_TipoDocCliente;
            }


        }
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CrearTipoDocumentoCliente.aspx");
    }
    protected void chkEstado_CheckedChanged(object sender, EventArgs e)
    {
        Listar();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CrearSubCategoria : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            ListarCategoria();

            if (Request.QueryString["i_IdSubCategoria"] != null)
            {
                int i_IdSubCategoria = int.Parse(Request.QueryString["i_IdSubCategoria"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Play_SubCategoria_Seleccionar " + i_IdSubCategoria.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdSubCategoria.ToString();
                txtDescripcion.Text = dt.Rows[0]["v_Descripcion"].ToString();
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());
                ddlCategoria.SelectedValue = dt.Rows[0]["i_IdCategoria"].ToString();
            }
            else
            {
            }

            txtDescripcion.Focus();
        }
    }

    void ListarCategoria()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Categoria_Combo", conexion);
        da.Fill(dt);
        ddlCategoria.DataSource = dt;
        ddlCategoria.DataTextField = "v_Descripcion";
        ddlCategoria.DataValueField = "i_IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.SelectedIndex = 0;
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarSubCategoria.aspx");
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtDescripcion.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar la descripción' });</script>", false);
            txtDescripcion.Focus();
            return;
        }
      
        try
        {
            if (lblCodigo.Text.Trim() != "")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Play_SubCategoria_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdSubCategoria", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@i_IdCategoria", ddlCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'SubCategoria actualizada.' });</script>", false);
            }
            else
            {
                string i_IdSubCategoria = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Play_SubCategoria_Insertar";
                cmd.Parameters.AddWithValue("@i_IdCategoria", ddlCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdSubCategoria = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdSubCategoria;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'SubCategoria registrada.' });</script>", false);
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: 'El código interno ya se encuentra en uso!' });</script>", false);
        }
    }
}
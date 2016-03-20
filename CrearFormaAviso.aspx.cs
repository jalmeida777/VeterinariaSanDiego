using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CrearFormaAviso : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            if (Request.QueryString["i_IdFormaAviso"] != null)
            {
                int i_IdFormaAviso = int.Parse(Request.QueryString["i_IdFormaAviso"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETER_FormaAviso_Seleccionar " + i_IdFormaAviso.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdFormaAviso.ToString();
                txtDescripcion.Text = dt.Rows[0]["v_DescripcionAviso"].ToString();
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());
            }
            else
            {
            }

            txtDescripcion.Focus();
        }
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
                cmd.CommandText = "BDVETER_FormaAviso_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdFormaAviso", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@v_DescripcionAviso", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Forma de Aviso actualizada.' });</script>", false);
            }
            else
            {
                string i_IdFormaAviso = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_FormaAviso_Registrar";
                cmd.Parameters.AddWithValue("@v_DescripcionAviso", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdFormaAviso = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdFormaAviso;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Forma de Aviso registrada.' });</script>", false);
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: 'El código interno ya se encuentra en uso!' });</script>", false);
        }
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarFormaAviso.aspx");
    }
}
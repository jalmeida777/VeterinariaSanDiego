using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class CrearCaniles : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            if (Request.QueryString["i_IdCaniles"] != null)
            {
                int i_IdCaniles = int.Parse(Request.QueryString["i_IdCaniles"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETER_Caniles_Seleccionar " + i_IdCaniles.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdCaniles.ToString();
                txtDescripcion.Text = dt.Rows[0]["v_Nombre"].ToString();
                txtUbicacion.Text = dt.Rows[0]["v_Ubicacion"].ToString();
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
                cmd.CommandText = "BDVETER_Caniles_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdCaniles", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@v_Nombre", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Ubicacion", txtUbicacion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Canil actualizado.' });</script>", false);
            }
            else
            {
                string i_IdCaniles = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_Caniles_Registrar";
                cmd.Parameters.AddWithValue("@v_Nombre", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Ubicacion", txtUbicacion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdCaniles = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdCaniles;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Canil registrado.' });</script>", false);
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: 'El código interno ya se encuentra en uso!' });</script>", false);
        }
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarCaniles.aspx");
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtDescripcion.Text = "";
        txtUbicacion.Text = "";
    }
}
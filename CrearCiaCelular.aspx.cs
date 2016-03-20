using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CrearCiaCelular : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            if (Request.QueryString["i_IdCiaCelular"] != null)
            {
                int i_IdCiaCelular = int.Parse(Request.QueryString["i_IdCiaCelular"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETER_CiaCelular_Seleccionar " + i_IdCiaCelular.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdCiaCelular.ToString();
                txtDescripcion.Text = dt.Rows[0]["v_Descripcion"].ToString();
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
                cmd.CommandText = "BDVETER_CiaCelular_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdCiaCelular", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Compañia Celular actualizada.' });</script>", false);
            }
            else
            {
                string i_IdCiaCelular = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_CiaCelular_Registrar";
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdCiaCelular = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdCiaCelular;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Compañia Celular registrada.' });</script>", false);
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: 'El código interno ya se encuentra en uso!' });</script>", false);
        }
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarCiaCelular.aspx");
    }
}
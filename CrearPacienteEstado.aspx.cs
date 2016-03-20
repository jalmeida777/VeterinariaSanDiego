using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class CrearPacienteEstado : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            if (Request.QueryString["i_IdPacienteEstado"] != null)
            {
                int i_IdPacienteEstado = int.Parse(Request.QueryString["i_IdPacienteEstado"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETER_PacienteEstado_Seleccionar " + i_IdPacienteEstado.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdPacienteEstado.ToString();
                txtDescripcion.Text = dt.Rows[0]["v_Estado"].ToString();
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
                cmd.CommandText = "BDVETER_PacienteEstado_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdPacienteEstado", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@v_Estado", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Estado de Paciente actualizado.' });</script>", false);
            }
            else
            {
                string i_IdPacienteEstado = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_PacienteEstado_Registrar";
                cmd.Parameters.AddWithValue("@v_Estado", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdPacienteEstado = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdPacienteEstado;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Estado de Paciente registrado.' });</script>", false);
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: 'El código interno ya se encuentra en uso!' });</script>", false);
        }

    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarPacienteEstado.aspx");
    }
}
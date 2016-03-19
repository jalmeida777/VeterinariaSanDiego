using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CrearTipoDocumentoCliente : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Page.IsPostBack == false)
        {

            if (Request.QueryString["i_TipoDocCliente"] != null)
            {
                int i_TipoDocCliente = int.Parse(Request.QueryString["i_TipoDocCliente"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETER_TipoDocumentoCliente_Seleccionar " + i_TipoDocCliente.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_TipoDocCliente.ToString();
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
                cmd.CommandText = "BDVETER_TipoDocumentoCliente_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdTipoDocCliente", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Tipo de Documento de Cliente actualizado.' });</script>", false);
            }
            else
            {
                string i_IdTipoDocCliente = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_TipoDocumentoCliente_Registrar";
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdTipoDocCliente = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdTipoDocCliente;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Tipo de Documento de Cliente registrado.' });</script>", false);
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: 'El código interno ya se encuentra en uso!' });</script>", false);
        }
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarTipoDocumentoCliente.aspx");
    }
}
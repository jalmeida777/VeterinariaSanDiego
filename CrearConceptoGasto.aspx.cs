using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CrearConceptoGasto : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            if (Request.QueryString["i_IdConceptoGastos"] != null)
            {
                int i_IdConceptoGastos = int.Parse(Request.QueryString["i_IdConceptoGastos"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETER_ConceptoGastos_Seleccionar " + i_IdConceptoGastos.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdConceptoGastos.ToString();
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
                cmd.CommandText = "BDVETER_ConceptoGastos_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdConceptoGastos", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Concepto de gasto actualizado.' });</script>", false);
            }
            else
            {
                string n_IdCategoria = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_ConceptoPago_Registrar";
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                n_IdCategoria = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = n_IdCategoria;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Concepto de gasto registrado.' });</script>", false);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
        }
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarConceptoGastos.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CrearRaza : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            ListarEspecie();

            if (Request.QueryString["i_IdRaza"] != null)
            {
                int i_IdRaza = int.Parse(Request.QueryString["i_IdRaza"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETER_Raza_Seleccionar " + i_IdRaza.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdRaza.ToString();
                txtDescripcion.Text = dt.Rows[0]["v_Descripcion"].ToString();
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());

                ddlEspecie.SelectedValue = dt.Rows[0]["i_IdEspecie"].ToString();
            }
            else
            {
            }

            txtDescripcion.Focus();
        }

    }

    void ListarEspecie()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Especie_Combo", conexion);
        da.Fill(dt);

        ddlEspecie.DataSource = dt;
        ddlEspecie.DataTextField = "v_Descripcion";
        ddlEspecie.DataValueField = "i_IdEspecie";
        ddlEspecie.DataBind();
        ddlEspecie.SelectedIndex = 0;
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarRaza.aspx");
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
                cmd.CommandText = "BDVETER_Raza_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdRaza", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@i_IdEspecie", ddlEspecie.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Raza actualizada.' });</script>", false);
            }
            else
            {
                string i_IdRaza = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_Raza_Registrar";
                cmd.Parameters.AddWithValue("@i_IdEspecie", ddlEspecie.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdRaza = cmd.ExecuteScalar().ToString();
                
                conexion.Close();
                lblCodigo.Text = i_IdRaza;
                cmd.Dispose();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Raza registrada.' });</script>", false);
                                             
            
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: 'El código interno ya se encuentra en uso!' });</script>", false);
        }
      
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtDescripcion.Text = "";
        ddlEspecie.Text = "";
    }
}
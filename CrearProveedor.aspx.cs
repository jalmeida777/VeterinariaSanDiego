using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CrearProveedor : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            ListarProvincia();
            ddlProvincia_SelectedIndexChanged(null, null);
            if (Request.QueryString["i_IdProveedor"] != null)
            {
                int i_IdProveedor = int.Parse(Request.QueryString["i_IdProveedor"].ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Play_Proveedor_Seleccionar " + i_IdProveedor.ToString(), conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdProveedor.ToString();
                txtRuc.Text = dt.Rows[0]["v_Ruc"].ToString();
                txtNombre.Text = dt.Rows[0]["v_Nombre"].ToString();
                txtTelefono.Text = dt.Rows[0]["v_Telefono"].ToString();
                txtDireccion.Text = dt.Rows[0]["v_Direccion"].ToString();
                ddlProvincia.SelectedValue = dt.Rows[0]["i_IdProvincia"].ToString();
                ddlProvincia_SelectedIndexChanged(null, null);
                ddlDistrito.SelectedValue = dt.Rows[0]["i_IdDistrito"].ToString();
                txtContacto.Text = dt.Rows[0]["v_Contacto"].ToString();
                txtEmail.Text = dt.Rows[0]["v_Email"].ToString();
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());
            }
            else
            {
            }

            txtNombre.Focus();
        }
    }


    void ListarProvincia()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Provincia_Combo", conexion);
        da.Fill(dt);

        ddlProvincia.DataSource = dt;
        ddlProvincia.DataTextField = "v_Descripcion";
        ddlProvincia.DataValueField = "i_IdProvincia";
        ddlProvincia.DataBind();
        ddlProvincia.SelectedIndex = 0;
    }

    public void ListarDistrito()
    {
        string i_IdProvincia = ddlProvincia.SelectedValue;
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Distrito_Combo " + i_IdProvincia, conexion);
        DataTable dt = new DataTable();
        da.Fill(dt);

        ddlDistrito.DataSource = dt;
        ddlDistrito.DataTextField = "v_Descripcion";
        ddlDistrito.DataValueField = "i_IdDistrito";
        ddlDistrito.DataBind();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtNombre.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el nombre' });</script>", false);
            txtNombre.Focus();
            return;
        }

        try
        {
            if (lblCodigo.Text.Trim() != "")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Play_Proveedor_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdProveedor", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@v_Ruc", txtRuc.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Nombre", txtNombre.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Telefono", txtTelefono.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Direccion", txtDireccion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@i_IdProvincia", ddlProvincia.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdDistrito", ddlDistrito.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Contacto", txtContacto.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Email", txtEmail.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Proveedor actualizado.' });</script>", false);
            }
            else
            {
                string i_IdProveedor = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Play_Proveedor_Registrar";
                cmd.Parameters.AddWithValue("@v_Ruc", txtRuc.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Nombre", txtNombre.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Telefono", txtTelefono.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Direccion", txtDireccion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@i_IdProvincia", ddlProvincia.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdDistrito", ddlDistrito.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Contacto", txtContacto.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Email", txtEmail.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdProveedor = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdProveedor;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Proveedor registrado.' });</script>", false);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '"+ ex.Message +"' });</script>", false);
        }
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarProveedor.aspx");
    }
    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarDistrito();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtRuc.Text = "";
        txtTelefono.Text = "";
        txtNombre.Text = "";
        txtEmail.Text = "";
        txtDireccion.Text = "";
        txtContacto.Text = "";
        ddlDistrito.Text = "";
        ddlProvincia.Text = "";
    }
}
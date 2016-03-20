using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class CrearCliente : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            ListarTipoCliente();
            ListarTipoDocumento();
            ListarCiaCelular();
            ListarProvincia();
            ddlProvincia_SelectedIndexChanged(null, null);

            if (Request.QueryString["i_IdCliente"] != null)
            {
                btnModificar.Enabled = true;
                btnGuardar.Enabled = false;
                bloquearTodo();
                filaCodigo.Visible = true;
                tblFechaRegistro.Visible = true;
                tblFechaVisita.Visible = true;
                txtNombre.Focus();

                string i_IdCliente = Request.QueryString["i_IdCliente"];

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETERINARIASANDIEGO_Cliente_Seleccionar " + i_IdCliente, conexion);
                da.Fill(dt);

                lblCodigo.Text = i_IdCliente;
                ddlTipoCliente.SelectedValue = dt.Rows[0]["i_IdTipoCliente"].ToString();
                txtNombre.Text = dt.Rows[0]["v_Nombres"].ToString();
                txtNumeroDocumento.Text = dt.Rows[0]["v_NroDocumento"].ToString();
                ddlTipoDocumento.SelectedValue = dt.Rows[0]["i_IdTipoDocumentoCliente"].ToString();
                txtDireccion.Text = dt.Rows[0]["v_Direccion"].ToString();
                ddlProvincia.SelectedValue = dt.Rows[0]["i_IdProvincia"].ToString();
                ddlProvincia_SelectedIndexChanged(null, null);
                ddlDistrito.SelectedValue = dt.Rows[0]["i_IdDistrito"].ToString();
                txtTelefono.Text = dt.Rows[0]["v_Telefono"].ToString();
                txtEmail.Text = dt.Rows[0]["v_Email"].ToString();
                txtCelular.Text = dt.Rows[0]["v_Celular"].ToString();
                ddlCiaCelular.SelectedValue = dt.Rows[0]["i_IdCiaCelular"].ToString();

                txtComentario.Text = dt.Rows[0]["t_Comentario"].ToString();

                lblFechaRegistro.Text = dt.Rows[0]["d_FechaRegistro"].ToString();

                if (dt.Rows[0]["d_FechaUltimaVisita"].ToString() != "")
                {
                    lblFechaUltimaVisita.Text = DateTime.Parse(dt.Rows[0]["d_FechaUltimaVisita"].ToString()).ToShortDateString();
                }
                lblPuntos.Text = dt.Rows[0]["i_Puntos"].ToString();

                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());

                txtNombre.Focus();
            }
            else
            {
                //Nuevo
                lblPuntos.Text = "0";
                filaCodigo.Visible = false;
                tblFechaRegistro.Visible = false;
                tblFechaVisita.Visible = false;
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
                txtNombre.Focus();
            }
        }
    }


    void ListarTipoCliente()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETERINARIASANDIEGO_TipoCliente_Combo", conexion);
        da.Fill(dt);

        ddlTipoCliente.DataSource = dt;
        ddlTipoCliente.DataTextField = "v_Descripcion";
        ddlTipoCliente.DataValueField = "i_IdTipoCliente";
        ddlTipoCliente.DataBind();
        ddlTipoCliente.SelectedIndex = 0;
    }

    void ListarTipoDocumento()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETERINARIASANDIEGO_TipoDocumentoCliente_Combo", conexion);
        da.Fill(dt);

        ddlTipoDocumento.DataSource = dt;
        ddlTipoDocumento.DataTextField = "v_Descripcion";
        ddlTipoDocumento.DataValueField = "i_IdTipoDocumentoCliente";
        ddlTipoDocumento.DataBind();
        ddlTipoDocumento.SelectedIndex = 0;
    }

    void ListarCiaCelular()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_CiaCelular_Combo", conexion);
        da.Fill(dt);

        ddlCiaCelular.DataSource = dt;
        ddlCiaCelular.DataTextField = "v_Descripcion";
        ddlCiaCelular.DataValueField = "i_IdCiaCelular";
        ddlCiaCelular.DataBind();
        ddlCiaCelular.SelectedIndex = 0;
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

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarCliente.aspx");
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtNombre.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el nombre del cliente.' });</script>", false);
            txtNombre.Focus();
            return;
        }
        if (txtNumeroDocumento.Text.Trim() == "") 
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el documento de identidad del cliente.' });</script>", false);
            txtNumeroDocumento.Focus();
            return;
        }
        if (txtDireccion.Text.Trim() == "") 
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar la dirección del cliente.' });</script>", false);
            txtDireccion.Focus();
            return;
        }
        
        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();

        try
        {
            if (lblCodigo.Text.Trim() != "")
            {
                //Actualizar datos del cliente
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_Cliente_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdCliente", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@i_IdTipoDocumentoCliente", ddlTipoDocumento.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdTipoCliente", ddlTipoCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdCiaCelular", ddlCiaCelular.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdProvincia", ddlProvincia.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdDistrito", ddlDistrito.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Nombres", txtNombre.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_NroDocumento", txtNumeroDocumento.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Direccion", txtDireccion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Telefono", txtTelefono.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Celular", txtCelular.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Email", txtEmail.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@t_Comentario", txtComentario.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                cmd.Dispose();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Cliente actualizado satisfactoriamente' });</script>", false);
                bloquearTodo();                          
            }
            else
            {
                //Registrar cliente nuevo
                string i_IdCliente = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_Cliente_Registrar";
                cmd.Parameters.AddWithValue("@i_IdTipoDocumentoCliente", ddlTipoDocumento.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdTipoCliente", ddlTipoCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdCiaCelular", ddlCiaCelular.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdProvincia", ddlProvincia.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdDistrito", ddlDistrito.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Nombres", txtNombre.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_NroDocumento", txtNumeroDocumento.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Direccion", txtDireccion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Telefono", txtTelefono.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Celular", txtCelular.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Email", txtEmail.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@t_Comentario", txtComentario.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@n_IdUsuarioRegistra", n_IdUsuario);
                
                                
                conexion.Open();
                i_IdCliente = cmd.ExecuteScalar().ToString();
                lblCodigo.Text = i_IdCliente;
                conexion.Close();
                cmd.Dispose();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Cliente registrado satisfactoriamente' });</script>", false);
                bloquearTodo();
            }

           
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
        }
    }

    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarDistrito();
    }

    void bloquearTodo() 
    {
        ddlTipoCliente.Enabled = false;
        txtNombre.Enabled = false;
        txtNumeroDocumento.Enabled = false;
        ddlTipoDocumento.Enabled = false;
        txtDireccion.Enabled = false;
        ddlProvincia.Enabled = false;
        ddlDistrito.Enabled = false;
        txtTelefono.Enabled = false;
        txtEmail.Enabled = false;
        txtCelular.Enabled = false;
        ddlCiaCelular.Enabled = false;
        txtComentario.Enabled = false;
        chkEstado.Enabled = false;
        btnGuardar.Enabled = false;
        btnModificar.Enabled = true;
    }

    void DesbloquearTodo() 
    {
        ddlTipoCliente.Enabled = true;
        txtNombre.Enabled = true;
        txtNumeroDocumento.Enabled = true;
        ddlTipoDocumento.Enabled = true;
        txtDireccion.Enabled = true;
        ddlProvincia.Enabled = true;
        ddlDistrito.Enabled = true;
        txtTelefono.Enabled = true;
        txtEmail.Enabled = true;
        txtCelular.Enabled = true;
        ddlCiaCelular.Enabled = true;
        txtComentario.Enabled = true;
        chkEstado.Enabled = true;
        btnGuardar.Enabled = true;
        btnModificar.Enabled = false;
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        DesbloquearTodo();
    }
}
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
            txtfecReg.Text = DateTime.Now.ToShortDateString();
            
            if (Request.QueryString["i_IdCliente"] != null)
            {
                string i_IdCliente = Request.QueryString["i_IdCliente"];
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("BDVETERINARIASANDIEGO_Cliente_Seleccionar " + i_IdCliente, conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdCliente;
                ddlTipoDocumento.SelectedValue = dt.Rows[0]["i_IdTipoDocumento"].ToString();
                ddlTipoCliente.SelectedValue = dt.Rows[0]["i_IdTipoCliente"].ToString();
                ddlCiaCelular.SelectedValue = dt.Rows[0]["v_CiaCelular"].ToString();
                ddlProvincia.SelectedValue = dt.Rows[0]["v_CiaCelular"].ToString();
                txtNombre.Text = dt.Rows[0]["v_Nombres"].ToString();
                txtNumeroDocumento.Text = dt.Rows[0]["v_NroDocumento"].ToString();
                txtDireccion.Text = dt.Rows[0]["v_Direccion"].ToString();
                txtTelefono.Text = dt.Rows[0]["v_Telefono"].ToString();
                txtCelular.Text = dt.Rows[0]["v_Celular"].ToString();
                txtEmail.Text = dt.Rows[0]["v_Email"].ToString();


                if (dt.Rows[0]["d_FechaRegistro"].ToString() != "")
                {
                    txtfecReg.Text = DateTime.Parse(dt.Rows[0]["d_FechaRegistro"].ToString()).ToShortDateString();
                }

                txtUltimaVisita.Text = dt.Rows[0]["v_FechaUltimaVisita"].ToString();

                //if (dt.Rows[0]["d_FechaUltimaVisita"].ToString() != "")
                //{
                // txtfecUltVisita.Text = DateTime.Parse(dt.Rows[0]["d_FechaUltimaVisita"].ToString()).ToShortDateString();
                //}
                
                txtComentario.Text = dt.Rows[0]["t_Comentario"].ToString();
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());
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
        ddlTipoDocumento.DataValueField = "i_TipoDocCliente";
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

        if (txtfecReg.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar una fecha de Registro válida.' });</script>", false);
            txtfecReg.Focus();
            return;
        }

        if (txtfecUltVisita.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar una fecha de Visita válida.' });</script>", false);
            txtfecUltVisita.Focus();
            return;
        }

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
                cmd.Parameters.AddWithValue("@i_IdTipoDocumento", ddlTipoDocumento.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdTipoCliente", ddlTipoCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Nombres", txtNombre.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_NroDocumento", txtNumeroDocumento.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Direccion", txtDireccion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Telefono", txtTelefono.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Celular", txtCelular.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_CiaCelular", txtCiaCelular.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Email", txtEmail.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@d_FechaRegistro", DateTime.Parse(txtfecReg.Text));
                cmd.Parameters.AddWithValue("@d_FechaUltimaVisita", DateTime.Parse(txtfecUltVisita.Text));
                cmd.Parameters.AddWithValue("@t_Comentario", txtComentario.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                                             
                
                
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                cmd.Dispose();
                tblCliente.Visible = true;
                //tblGeneral.Visible = true;
                //toolbar.Visible = true;

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Cliente actualizado satisfactoriamente' });</script>", false);
                           
                                                                
            }
            else
            {
                //Registrar cliente nuevo
                string i_IdCliente = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_Cliente_Registrar";
                cmd.Parameters.AddWithValue("@i_IdTipoDocumento", ddlTipoDocumento.SelectedValue);
                cmd.Parameters.AddWithValue("@i_IdTipoCliente", ddlTipoCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@v_Nombres", txtNombre.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_NroDocumento", txtNumeroDocumento.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Direccion", txtDireccion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Telefono", txtTelefono.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Celular", txtCelular.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_CiaCelular", txtCiaCelular.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Email", txtEmail.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@d_FechaRegistro", DateTime.Parse(txtfecReg.Text));
                cmd.Parameters.AddWithValue("@d_FechaUltimaVisita", DateTime.Parse(txtfecUltVisita.Text));
                cmd.Parameters.AddWithValue("@t_Comentario", txtComentario.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                
                                
                conexion.Open();
                i_IdCliente = cmd.ExecuteScalar().ToString();
                conexion.Close();
                cmd.Dispose();
                tblCliente.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Cliente registrado satisfactoriamente' });</script>", false);

               
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
}
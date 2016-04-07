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

public partial class CrearPaciente : System.Web.UI.Page
{

    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false) 
        {
            ListarEspecies();
            ListarRazas();
            ListarSexo();
            PacienteEstado();
            if (Request.QueryString["i_IdPaciente"] != null) 
            {
                MostrarCliente();
                Bloquear();
            }
            else if (Request.QueryString["i_IdCliente"] != null) 
            {
                hfCliente.Value = Request.QueryString["i_IdCliente"];

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select v_Nombres from Cliente where i_IdCliente = " + hfCliente.Value, conexion);
                da.Fill(dt);

                txtCliente.Text = dt.Rows[0]["v_Nombres"].ToString();
                lblUltimaVisita.Text = DateTime.Now.ToShortDateString();
                txtFechaNacimiento.Text = DateTime.Now.ToShortDateString();
                TabContainer1.Tabs[1].Enabled = false;
                TabContainer1.Tabs[2].Enabled = false;
                TabContainer1.Tabs[3].Enabled = false;
                TabContainer1.Tabs[4].Enabled = false;
                TabContainer1.Tabs[5].Enabled = false;
                Desbloquear();

                txtFechaVacunacion.Text = DateTime.Now.ToShortDateString();

                txtNombre.Focus();

            }
            
        }
    }

    void MostrarCliente() 
    {
        string i_IdPaciente = Request.QueryString["i_IdPaciente"];
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Paciente_Seleccionar " + i_IdPaciente, conexion);
        da.Fill(dt);
        txtNombre.Text = dt.Rows[0]["v_NombrePaciente"].ToString();
        lblCodigoPaciente.Text = dt.Rows[0]["i_IdPaciente"].ToString();
        txtCliente.Text = dt.Rows[0]["NombreCliente"].ToString();
        txtHistoria.Text = dt.Rows[0]["v_NumeroHistoria"].ToString();
        ddlEspecie.SelectedValue = dt.Rows[0]["i_IdEspecie"].ToString();
        ddlEspecie_SelectedIndexChanged(null, null);
        ddlRaza.SelectedValue = dt.Rows[0]["i_IdRaza"].ToString();
        ddlSexo.SelectedValue = dt.Rows[0]["i_IdSexo"].ToString();
        txtPelaje.Text = dt.Rows[0]["v_Pelaje"].ToString();
        txtMicrochip.Text = dt.Rows[0]["v_Microchip"].ToString();
        txtFechaNacimiento.Text = DateTime.Parse(dt.Rows[0]["d_FechaNacimiento"].ToString()).ToShortDateString();
        txtFechaAlta.Text = DateTime.Parse(dt.Rows[0]["d_FechaRegistra"].ToString()).ToShortDateString();
        DateTime nacimiento = new DateTime(2000, 1, 25); //Fecha de nacimiento
        int edad = DateTime.Today.AddTicks(-DateTime.Parse(dt.Rows[0]["d_FechaNacimiento"].ToString()).Ticks).Year - 1;
        lblEdad.Text = edad.ToString();

        if (dt.Rows[0]["d_FechaUltimaVisita"].ToString() != "")
        {
            lblUltimaVisita.Text = DateTime.Parse(dt.Rows[0]["d_FechaUltimaVisita"].ToString()).ToShortDateString();
        }
        if (dt.Rows[0]["v_RutaImagen"].ToString() == "")
        {
            lblRuta.Text = "~/images/dog-background.jpg";
        }
        else 
        {
            lblRuta.Text = dt.Rows[0]["v_RutaImagen"].ToString();
            ibImagen.ImageUrl = dt.Rows[0]["v_RutaImagen"].ToString();
        }

        ddlEstado.SelectedValue = dt.Rows[0]["i_IdPacienteEstado"].ToString();
    }

    void ListarEspecies()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Especie_Combo", conexion);
        da.Fill(dt);
        ddlEspecie.DataSource = dt;
        ddlEspecie.DataTextField = "v_Descripcion";
        ddlEspecie.DataValueField = "i_IdEspecie";
        ddlEspecie.DataBind();
    }

    void ListarRazas()
    {
        string Especie = ddlEspecie.SelectedValue;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_RAZA_COMBO " + Especie, conexion);
        da.Fill(dt);
        ddlRaza.DataSource = dt;
        ddlRaza.DataTextField = "v_Descripcion";
        ddlRaza.DataValueField = "i_IdRaza";
        ddlRaza.DataBind();
        if (ddlRaza.Items.Count == 0)
        {
            ddlRaza.Enabled = false;
        }
        else
        {
            ddlRaza.Enabled = true;
        }
    }

    void ListarSexo()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_SEXO_Combo", conexion);
        da.Fill(dt);
        ddlSexo.DataSource = dt;
        ddlSexo.DataTextField = "v_Descripcion";
        ddlSexo.DataValueField = "i_IdSexo";
        ddlSexo.DataBind();
    }

    void PacienteEstado()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_PacienteEstado_Combo", conexion);
        da.Fill(dt);
        ddlEstado.DataSource = dt;
        ddlEstado.DataTextField = "v_Estado";
        ddlEstado.DataValueField = "i_IdPacienteEstado";
        ddlEstado.DataBind();
    }

    void Desbloquear() 
    {
        txtHistoria.Enabled = true;
        ddlEspecie.Enabled = true;
        ddlRaza.Enabled = true;
        ddlSexo.Enabled = true;
        txtPelaje.Enabled = true;
        txtMicrochip.Enabled = true;
        txtFechaNacimiento.Enabled = true;
        ddlEstado.Enabled = true;
        txtNombre.Enabled = true;
        btnGuardar.Enabled = true;
        fu1.Enabled = true;
        ibUpload.Enabled = true;
        txtFechaAlta.Enabled = true;
        btnModificar.Enabled = false;
    }

    void Bloquear() 
    {
        txtHistoria.Enabled = false;
        ddlEspecie.Enabled = false;
        ddlRaza.Enabled = false;
        ddlSexo.Enabled = false;
        txtPelaje.Enabled = false;
        txtMicrochip.Enabled = false;
        txtFechaNacimiento.Enabled = false;
        ddlEstado.Enabled = false;
        txtNombre.Enabled = false;
        btnGuardar.Enabled = false;
        fu1.Enabled = false;
        ibUpload.Enabled = false;
        txtFechaAlta.Enabled = false;
        btnModificar.Enabled = true;
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtHistoria.Text == "") 
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el número de historia.' });</script>", false);
            txtHistoria.Focus();
            return;
        }
        if (txtFechaNacimiento.Text == "") 
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar la fecha de cumpleaños.' });</script>", false);
            txtFechaNacimiento.Focus();
            return;
        }

        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();

        if (lblCodigoPaciente.Text.Trim() != "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BDVETER_Paciente_Actualizar";
            cmd.Parameters.AddWithValue("@i_IdPaciente", lblCodigoPaciente.Text);
            cmd.Parameters.AddWithValue("@v_NumeroHistoria", txtHistoria.Text);
            cmd.Parameters.AddWithValue("@v_RutaImagen", lblRuta.Text);
            cmd.Parameters.AddWithValue("@v_NombrePaciente", txtNombre.Text.ToUpper());
            cmd.Parameters.AddWithValue("@i_IdEspecie", ddlEspecie.SelectedValue);
            cmd.Parameters.AddWithValue("@i_IdRaza", ddlRaza.SelectedValue);
            cmd.Parameters.AddWithValue("@i_IdSexo", ddlSexo.SelectedValue);
            cmd.Parameters.AddWithValue("@v_Pelaje", txtPelaje.Text);
            cmd.Parameters.AddWithValue("@v_Microchip", txtMicrochip.Text);
            cmd.Parameters.AddWithValue("@d_FechaNacimiento", DateTime.Parse(txtFechaNacimiento.Text));
            cmd.Parameters.AddWithValue("@i_IdPacienteEstado", ddlEstado.SelectedValue);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
            Bloquear();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Paciente actualizado satisfactoriamente' });</script>", false);
        }
        else
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BDVETER_Paciente_Registrar";
            cmd.Parameters.AddWithValue("@i_IdCliente", hfCliente.Value);
            cmd.Parameters.AddWithValue("@v_NumeroHistoria", txtHistoria.Text);
            cmd.Parameters.AddWithValue("@v_RutaImagen", lblRuta.Text);
            cmd.Parameters.AddWithValue("@v_NombrePaciente", txtNombre.Text.ToUpper());
            cmd.Parameters.AddWithValue("@i_IdEspecie", ddlEspecie.SelectedValue);
            cmd.Parameters.AddWithValue("@i_IdRaza", ddlRaza.SelectedValue);
            cmd.Parameters.AddWithValue("@i_IdSexo", ddlSexo.SelectedValue);
            cmd.Parameters.AddWithValue("@v_Pelaje", txtPelaje.Text);
            cmd.Parameters.AddWithValue("@v_Microchip", txtMicrochip.Text);
            cmd.Parameters.AddWithValue("@d_FechaNacimiento", DateTime.Parse(txtFechaNacimiento.Text));
            cmd.Parameters.AddWithValue("@i_IdPacienteEstado", ddlEstado.SelectedValue);
            cmd.Parameters.AddWithValue("@n_IdUsuarioRegistra", n_IdUsuario);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
            Bloquear();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Paciente registrado satisfactoriamente' });</script>", false);
        }
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/ListarPaciente.aspx");
    }

    protected void ddlEspecie_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRazas();
    }

    protected void ibUpload_Click(object sender, ImageClickEventArgs e)
    {
        string filename = Path.GetFileName(fu1.FileName);
        fu1.SaveAs(Server.MapPath("~/Pacientes/Fotos/") + filename);
        ibImagen.ImageUrl = "~/Pacientes/Fotos/" + filename;
        lblRuta.Text = "~/Pacientes/Fotos/" + filename;
    }

    protected void btnModificar_Click(object sender, ImageClickEventArgs e)
    {
        Desbloquear();
    }
}
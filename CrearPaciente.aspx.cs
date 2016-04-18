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

            ListarAlmacen();
            ListarAlmacenAntipulga();
            ListarAlmacenAntiparasito();

            PacienteEstado();

            if (Request.QueryString["i_IdPaciente"] != null) 
            {
                MostrarCliente();
                MostrarCuentaCorriente();
                Bloquear();

                txtFechaVacunacion.Text = DateTime.Now.ToShortDateString();
                txtFechaVacunacionProg.Text = DateTime.Now.ToShortDateString();
                txtFechaAntipulga.Text = DateTime.Now.ToShortDateString();
                txtFechaAntipulgaProg.Text = DateTime.Now.ToShortDateString();
                txtFechaAntiparasito.Text = DateTime.Now.ToShortDateString();
                txtFechaAntiparasitoProg.Text = DateTime.Now.ToShortDateString();

                //Mostrar el médico
                if (Session["dtUsuario"] != null)
                {
                    DataTable dtUsuario = new DataTable();
                    dtUsuario = (DataTable)Session["dtUsuario"];
                    string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();
                    DataTable dtMedico = new DataTable();
                    SqlDataAdapter daMedico = new SqlDataAdapter("select v_Nombre from usuario where n_IdUsuario = " + n_IdUsuario, conexion);
                    daMedico.Fill(dtMedico);
                    lblMedicoVacuna.Text = dtMedico.Rows[0]["v_Nombre"].ToString();
                    lblMedicoAntipulga.Text = dtMedico.Rows[0]["v_Nombre"].ToString();
                    lblMedicoAntiparasito.Text = dtMedico.Rows[0]["v_Nombre"].ToString();

                    ListarVacunasAplicadas();
                    ListarAntipulgasAplicadas();
                    ListarAntiparasitariosAplicadas();

                    ListarProgramacionVacunas();
                }
            }
            else if (Request.QueryString["i_IdCliente"] != null) 
            {
                hfCliente.Value = Request.QueryString["i_IdCliente"];
                MostrarCuentaCorriente();
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
                TabContainer1.Tabs[6].Enabled = false;
                Desbloquear();

                txtFechaVacunacion.Text = DateTime.Now.ToShortDateString();
                txtFechaVacunacionProg.Text = DateTime.Now.ToShortDateString();
                txtFechaAntipulga.Text = DateTime.Now.ToShortDateString();
                txtFechaAntipulgaProg.Text = DateTime.Now.ToShortDateString();
                txtFechaAntiparasito.Text = DateTime.Now.ToShortDateString();
                txtFechaAntiparasitoProg.Text = DateTime.Now.ToShortDateString();

                txtNombre.Focus();

            }
            
        }
    }


    public void ListarAlmacen()
    {
        if (Session["dtAlmacenes"] != null)
        {
            DataTable dtAlmacen = new DataTable();
            dtAlmacen = (DataTable)Session["dtAlmacenes"];
            ddlAlmacen.DataSource = dtAlmacen;
            ddlAlmacen.DataTextField = "v_Descripcion";
            ddlAlmacen.DataValueField = "i_IdAlmacen";
            ddlAlmacen.DataBind();
            ddlAlmacen.SelectedIndex = 0;
            if (dtAlmacen.Rows.Count > 1)
            {
                ddlAlmacen.Enabled = true;
            }
            else
            {
                ddlAlmacen.Enabled = false;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Su sesión ha caducado. Vuelva a ingresar al sistema.' });</script>", false);
            Bloquear();
        }
    }

    public void ListarAlmacenAntipulga()
    {
        if (Session["dtAlmacenes"] != null)
        {
            DataTable dtAlmacen1 = new DataTable();
            dtAlmacen1 = (DataTable)Session["dtAlmacenes"];
            ddlSucursalAntipulgas.DataSource = dtAlmacen1;
            ddlSucursalAntipulgas.DataTextField = "v_Descripcion";
            ddlSucursalAntipulgas.DataValueField = "i_IdAlmacen";
            ddlSucursalAntipulgas.DataBind();
            ddlSucursalAntipulgas.SelectedIndex = 0;
            if (dtAlmacen1.Rows.Count > 1)
            {
                ddlSucursalAntipulgas.Enabled = true;
            }
            else
            {
                ddlSucursalAntipulgas.Enabled = false;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Su sesión ha caducado. Vuelva a ingresar al sistema.' });</script>", false);
            Bloquear();
        }
    }

    public void ListarAlmacenAntiparasito()
    {
        if (Session["dtAlmacenes"] != null)
        {
            DataTable dtAlmacen1 = new DataTable();
            dtAlmacen1 = (DataTable)Session["dtAlmacenes"];
            ddlAlmacenAntiparasito.DataSource = dtAlmacen1;
            ddlAlmacenAntiparasito.DataTextField = "v_Descripcion";
            ddlAlmacenAntiparasito.DataValueField = "i_IdAlmacen";
            ddlAlmacenAntiparasito.DataBind();
            ddlAlmacenAntiparasito.SelectedIndex = 0;
            if (dtAlmacen1.Rows.Count > 1)
            {
                ddlAlmacenAntiparasito.Enabled = true;
            }
            else
            {
                ddlAlmacenAntiparasito.Enabled = false;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Su sesión ha caducado. Vuelva a ingresar al sistema.' });</script>", false);
            Bloquear();
        }
    }


    void MostrarCliente() 
    {
        string i_IdPaciente = Request.QueryString["i_IdPaciente"];
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Paciente_Seleccionar " + i_IdPaciente, conexion);
        da.Fill(dt);
        hfCliente.Value = dt.Rows[0]["i_IdCliente"].ToString();
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

    void MostrarCuentaCorriente() 
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_ClienteCuenta_Listar " + hfCliente.Value, conexion);
        da.Fill(dt);
        gvCuentaCorriente.DataSource = dt;
        gvCuentaCorriente.DataBind();

        float venta = 0;
        float pago = 0;
        float saldo = 0;
        for (int i = 0; i < gvCuentaCorriente.Rows.Count; i++)
        {
            venta = venta + float.Parse(gvCuentaCorriente.Rows[i].Cells[2].Text);
            pago = pago + float.Parse(gvCuentaCorriente.Rows[i].Cells[3].Text);
        }
        saldo = venta - pago;
        gvCuentaCorriente.FooterRow.Cells[1].Text = "Totales:";
        gvCuentaCorriente.FooterRow.Cells[2].Text = venta.ToString("N2");
        gvCuentaCorriente.FooterRow.Cells[3].Text = pago.ToString("N2");
        lblSaldo.Text = saldo.ToString("N2");
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> BuscarVacunas(string prefixText, int count, string contextKey)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["conexion"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SISGEVET_Vacunas_Filtrar";
                cmd.Parameters.AddWithValue("@v_Descripcion", prefixText);
                cmd.Parameters.AddWithValue("@i_IdAlmacen", contextKey);
                cmd.Connection = conn;
                conn.Open();
                List<string> productos = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        productos.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["Nombre"].ToString(), Convert.ToString(sdr["i_IdProducto"].ToString())));
                    }
                }
                conn.Close();
                return productos;
            }
        }
    }
    
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> BuscarAntipulgas(string prefixText, int count, string contextKey)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["conexion"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SISGEVET_Antipulgas_Filtrar";
                cmd.Parameters.AddWithValue("@v_Descripcion", prefixText);
                cmd.Parameters.AddWithValue("@i_IdAlmacen", contextKey);
                cmd.Connection = conn;
                conn.Open();
                List<string> productos2 = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        productos2.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["Nombre"].ToString(), Convert.ToString(sdr["i_IdProducto"].ToString())));
                    }
                }
                conn.Close();
                return productos2;
            }
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> BuscarAntiparasitos(string prefixText, int count, string contextKey)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["conexion"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SISGEVET_Antiparasito_Filtrar";
                cmd.Parameters.AddWithValue("@v_Descripcion", prefixText);
                cmd.Parameters.AddWithValue("@i_IdAlmacen", contextKey);
                cmd.Connection = conn;
                conn.Open();
                List<string> productos2 = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        productos2.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["Nombre"].ToString(), Convert.ToString(sdr["i_IdProducto"].ToString())));
                    }
                }
                conn.Close();
                return productos2;
            }
        }
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


    protected void ibSucursal_Click(object sender, ImageClickEventArgs e)
    {
        ddlAlmacen.Enabled = false;
        txtVacuna.Enabled = true;
        txtComentarioVacunacion.Enabled = true;
        ibAceptarAplicaVacuna.Enabled = true;
        ibSucursal.Visible = false;
        string IdAlmacen = ddlAlmacen.SelectedValue;
        
        txtVacuna_AutoCompleteExtender.ContextKey = IdAlmacen;
        txtVacuna.Focus();
        ibAceptarAplicaVacuna.Enabled = true;
    }

    protected void ibSucursalAntipulga_Click(object sender, ImageClickEventArgs e)
    {
        ddlSucursalAntipulgas.Enabled = false;
        txtAntipulga.Enabled = true;
        txtComentarioAntipulga.Enabled = true;
        ibAceptarAplicaAntipulga.Enabled = true;
        ibSucursalAntipulga.Visible = false;
        string IdAlmacen = ddlSucursalAntipulgas.SelectedValue;

        txtAntipulga_AutoCompleteExtender.ContextKey = IdAlmacen;
        txtAntipulga.Focus();
        ibAceptarAplicaAntipulga.Enabled = true;
    }

    protected void ibSucursalAntiparasito_Click(object sender, ImageClickEventArgs e)
    {
        ddlAlmacenAntiparasito.Enabled = false;
        txtAntiparasito.Enabled = true;
        txtComentarioAntiparasito.Enabled = true;
        ibAceptarAplicaAntiparasito.Enabled = true;
        ibSucursalAntiparasito.Visible = false;
        string IdAlmacen = ddlAlmacenAntiparasito.SelectedValue;

        txtAntiparasito_AutoCompleteExtender.ContextKey = IdAlmacen;
        txtAntiparasito.Focus();
        ibAceptarAplicaAntiparasito.Enabled = true;
    }


    protected void hfIdProducto_ValueChanged(object sender, EventArgs e)
    {
        string id = ((HiddenField)sender).Value;
        txtVacuna.BackColor = System.Drawing.Color.FromName("#CEE7FF");
        DataTable dtPrecio = new DataTable();
        SqlDataAdapter daPrecio = new SqlDataAdapter("select f_Precio from Producto where i_IdProducto = " + id, conexion);
        daPrecio.Fill(dtPrecio);
        if (dtPrecio.Rows.Count > 0) 
        {
            lblPrecioVacuna.Text = decimal.Parse(dtPrecio.Rows[0]["f_Precio"].ToString()).ToString("N2");
        }
    }

    protected void hfAntipulga_ValueChanged(object sender, EventArgs e)
    {
        string id = ((HiddenField)sender).Value;
        txtAntipulga.BackColor = System.Drawing.Color.FromName("#CEE7FF");
        DataTable dtPrecio = new DataTable();
        SqlDataAdapter daPrecio = new SqlDataAdapter("select f_Precio from Producto where i_IdProducto = " + id, conexion);
        daPrecio.Fill(dtPrecio);
        if (dtPrecio.Rows.Count > 0)
        {
            lblPrecioAntipulga.Text = decimal.Parse(dtPrecio.Rows[0]["f_Precio"].ToString()).ToString("N2");
        }
    }

    protected void hfAntiparasito_ValueChanged(object sender, EventArgs e)
    {
        string id = ((HiddenField)sender).Value;
        txtAntiparasito.BackColor = System.Drawing.Color.FromName("#CEE7FF");
        DataTable dtPrecio = new DataTable();
        SqlDataAdapter daPrecio = new SqlDataAdapter("select f_Precio from Producto where i_IdProducto = " + id, conexion);
        daPrecio.Fill(dtPrecio);
        if (dtPrecio.Rows.Count > 0)
        {
            lblPrecioAntiparasito.Text = decimal.Parse(dtPrecio.Rows[0]["f_Precio"].ToString()).ToString("N2");
        }
    }



    protected void ibAceptarAplicaVacuna_Click(object sender, ImageClickEventArgs e)
    {
        if (hfIdProducto.Value == "0") 
        {

            return;
        }
        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();

        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();
        
        SqlTransaction tran;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            cn.Open();
            tran = cn.BeginTransaction();

            try
            {

                //Registrar Vacunación
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BDVETER_Vacunacion_Registrar";
                cmd.Parameters.AddWithValue("@d_FechaVacunacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@i_IdPaciente", i_IdPaciente);
                cmd.Parameters.AddWithValue("@n_IdUsuarioMedico", n_IdUsuario);
                cmd.Parameters.AddWithValue("@i_IdProducto", hfIdProducto.Value);
                cmd.Parameters.AddWithValue("@t_Observacion", txtComentarioVacunacion.Text);
                cmd.ExecuteNonQuery();

                string i_IdAlmacen = ddlAlmacen.SelectedValue;

                //Descontar Stock
                SqlCommand cmdStock = new SqlCommand();
                cmdStock.Connection = cn;
                cmdStock.Transaction = tran;
                cmdStock.CommandType = CommandType.StoredProcedure;
                cmdStock.CommandText = "Play_Stock_Restar_Actualizar";
                cmdStock.Parameters.AddWithValue("@i_IdAlmacen", i_IdAlmacen);
                cmdStock.Parameters.AddWithValue("@i_IdProducto", hfIdProducto.Value);
                cmdStock.Parameters.AddWithValue("@f_Cantidad", 1);
                cmdStock.ExecuteNonQuery();

                //Cuenta Corriente Cliente
                SqlCommand cmdCuenta = new SqlCommand();
                cmdCuenta.Connection = cn;
                cmdCuenta.Transaction = tran;
                cmdCuenta.CommandType = CommandType.StoredProcedure;
                cmdCuenta.CommandText = "BDVETER_ClienteCuenta_RegistrarVenta";
                cmdCuenta.Parameters.AddWithValue("@i_IdCliente", hfCliente.Value);
                cmdCuenta.Parameters.AddWithValue("@i_IdAlmacen", ddlAlmacen.SelectedValue);
                cmdCuenta.Parameters.AddWithValue("@v_Descripcion", txtVacuna.Text);
                cmdCuenta.Parameters.AddWithValue("@f_Venta", lblPrecioVacuna.Text);
                cmdCuenta.Parameters.AddWithValue("@n_IdTipoDocumento", DBNull.Value);
                cmdCuenta.Parameters.AddWithValue("@v_NroDocumento", DBNull.Value);
                cmdCuenta.ExecuteNonQuery();

                //Mover Kardex
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = cn;
                cmd4.Transaction = tran;
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.CommandText = "Play_Kardex_Insertar";
                cmd4.Parameters.AddWithValue("@d_FechaMovimiento", DateTime.Now);
                cmd4.Parameters.AddWithValue("@c_TipoMovimiento", "S");
                cmd4.Parameters.AddWithValue("@i_IdMotivoTraslado", 1);
                cmd4.Parameters.AddWithValue("@i_IdProducto", hfIdProducto.Value);
                cmd4.Parameters.AddWithValue("@i_IdAlmacen", ddlAlmacen.SelectedValue);
                cmd4.Parameters.AddWithValue("@f_Cantidad", 1);
                cmd4.Parameters.AddWithValue("@n_IdTipoDocumento", DBNull.Value);
                cmd4.Parameters.AddWithValue("@v_NumeroDocumento", DBNull.Value);
                cmd4.Parameters.AddWithValue("@i_IdCliente", hfCliente.Value);
                cmd4.Parameters.AddWithValue("@i_IdProveedor", DBNull.Value);
                cmd4.ExecuteNonQuery();

                tran.Commit();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Vacunación registrada satisfactoriamente' });</script>", false);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
            }
            finally
            {
                cn.Close();
            }

        ListarVacunasAplicadas();
        MostrarCuentaCorriente();
        ddlAlmacen.Enabled = true;
        ibSucursal.Visible = true;
        txtVacuna.Text = "";
        txtVacuna.Enabled = false;
        lblPrecioVacuna.Text = "";
        hfIdProducto.Value = "0";
        txtComentarioVacunacion.Text = "";
        txtComentarioVacunacion.Enabled = false;
        ibAceptarAplicaVacuna.Enabled = false;
    }

    protected void ibAceptarAplicaAntipulga_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();

        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();

        SqlTransaction tran;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        cn.Open();
        tran = cn.BeginTransaction();

        try
        {

            //Registrar Vacunación
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BDVETER_Antipulga_Registrar";
            cmd.Parameters.AddWithValue("@d_FechaAntipulga", DateTime.Now);
            cmd.Parameters.AddWithValue("@i_IdPaciente", i_IdPaciente);
            cmd.Parameters.AddWithValue("@n_IdUsuarioMedico", n_IdUsuario);
            cmd.Parameters.AddWithValue("@i_IdProducto", hfAntipulga.Value);
            cmd.Parameters.AddWithValue("@t_Observacion", txtComentarioAntipulga.Text);
            cmd.ExecuteNonQuery();


            //Descontar Stock
            SqlCommand cmdStock = new SqlCommand();
            cmdStock.Connection = cn;
            cmdStock.Transaction = tran;
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.CommandText = "Play_Stock_Restar_Actualizar";
            cmdStock.Parameters.AddWithValue("@i_IdAlmacen", ddlSucursalAntipulgas.SelectedValue);
            cmdStock.Parameters.AddWithValue("@i_IdProducto", hfAntipulga.Value);
            cmdStock.Parameters.AddWithValue("@f_Cantidad", 1);
            cmdStock.ExecuteNonQuery();

            //Cuenta Corriente Cliente
            SqlCommand cmdCuenta = new SqlCommand();
            cmdCuenta.Connection = cn;
            cmdCuenta.Transaction = tran;
            cmdCuenta.CommandType = CommandType.StoredProcedure;
            cmdCuenta.CommandText = "BDVETER_ClienteCuenta_RegistrarVenta";
            cmdCuenta.Parameters.AddWithValue("@i_IdCliente", hfCliente.Value);
            cmdCuenta.Parameters.AddWithValue("@i_IdAlmacen", ddlSucursalAntipulgas.SelectedValue);
            cmdCuenta.Parameters.AddWithValue("@v_Descripcion", txtAntipulga.Text);
            cmdCuenta.Parameters.AddWithValue("@f_Venta", lblPrecioAntipulga.Text);
            cmdCuenta.Parameters.AddWithValue("@n_IdTipoDocumento", DBNull.Value);
            cmdCuenta.Parameters.AddWithValue("@v_NroDocumento", DBNull.Value);
            cmdCuenta.ExecuteNonQuery();

            //Mover Kardex
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = cn;
            cmd4.Transaction = tran;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Play_Kardex_Insertar";
            cmd4.Parameters.AddWithValue("@d_FechaMovimiento", DateTime.Now);
            cmd4.Parameters.AddWithValue("@c_TipoMovimiento", "S");
            cmd4.Parameters.AddWithValue("@i_IdMotivoTraslado", 1);
            cmd4.Parameters.AddWithValue("@i_IdProducto", hfAntipulga.Value);
            cmd4.Parameters.AddWithValue("@i_IdAlmacen", ddlSucursalAntipulgas.SelectedValue);
            cmd4.Parameters.AddWithValue("@f_Cantidad", 1);
            cmd4.Parameters.AddWithValue("@n_IdTipoDocumento", DBNull.Value);
            cmd4.Parameters.AddWithValue("@v_NumeroDocumento", DBNull.Value);
            cmd4.Parameters.AddWithValue("@i_IdCliente", hfCliente.Value);
            cmd4.Parameters.AddWithValue("@i_IdProveedor", DBNull.Value);
            cmd4.ExecuteNonQuery();

            tran.Commit();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Antipulga registrada satisfactoriamente' });</script>", false);
        }
        catch (Exception ex)
        {
            tran.Rollback();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
        }
        finally
        {
            cn.Close();
        }

        ListarAntipulgasAplicadas();
        MostrarCuentaCorriente();
        ddlSucursalAntipulgas.Enabled = true;
        ibSucursalAntipulga.Visible = true;
        txtAntipulga.Text = "";
        txtAntipulga.Enabled = false;
        lblPrecioAntipulga.Text = "";
        hfAntipulga.Value = "0";
        txtComentarioAntipulga.Text = "";
        txtComentarioAntipulga.Enabled = false;
        ibAceptarAplicaAntipulga.Enabled = false;
    }

    protected void ibAceptarAplicaAntiparasito_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();

        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();

        SqlTransaction tran;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        cn.Open();
        tran = cn.BeginTransaction();

        try
        {

            //Registrar Vacunación
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BDVETER_Antiparasito_Registrar";
            cmd.Parameters.AddWithValue("@d_FechaAntiparasito", DateTime.Now);
            cmd.Parameters.AddWithValue("@i_IdPaciente", i_IdPaciente);
            cmd.Parameters.AddWithValue("@n_IdUsuarioMedico", n_IdUsuario);
            cmd.Parameters.AddWithValue("@i_IdProducto", hfAntiparasito.Value);
            cmd.Parameters.AddWithValue("@t_Observacion", txtComentarioAntiparasito.Text);
            cmd.ExecuteNonQuery();


            //Descontar Stock
            SqlCommand cmdStock = new SqlCommand();
            cmdStock.Connection = cn;
            cmdStock.Transaction = tran;
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.CommandText = "Play_Stock_Restar_Actualizar";
            cmdStock.Parameters.AddWithValue("@i_IdAlmacen", ddlAlmacenAntiparasito.SelectedValue);
            cmdStock.Parameters.AddWithValue("@i_IdProducto", hfAntiparasito.Value);
            cmdStock.Parameters.AddWithValue("@f_Cantidad", 1);
            cmdStock.ExecuteNonQuery();

            //Cuenta Corriente Cliente
            SqlCommand cmdCuenta = new SqlCommand();
            cmdCuenta.Connection = cn;
            cmdCuenta.Transaction = tran;
            cmdCuenta.CommandType = CommandType.StoredProcedure;
            cmdCuenta.CommandText = "BDVETER_ClienteCuenta_RegistrarVenta";
            cmdCuenta.Parameters.AddWithValue("@i_IdCliente", hfCliente.Value);
            cmdCuenta.Parameters.AddWithValue("@i_IdAlmacen", ddlAlmacenAntiparasito.SelectedValue);
            cmdCuenta.Parameters.AddWithValue("@v_Descripcion", txtAntiparasito.Text);
            cmdCuenta.Parameters.AddWithValue("@f_Venta", lblPrecioAntiparasito.Text);
            cmdCuenta.Parameters.AddWithValue("@n_IdTipoDocumento", DBNull.Value);
            cmdCuenta.Parameters.AddWithValue("@v_NroDocumento", DBNull.Value);
            cmdCuenta.ExecuteNonQuery();

            //Mover Kardex
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = cn;
            cmd4.Transaction = tran;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Play_Kardex_Insertar";
            cmd4.Parameters.AddWithValue("@d_FechaMovimiento", DateTime.Now);
            cmd4.Parameters.AddWithValue("@c_TipoMovimiento", "S");
            cmd4.Parameters.AddWithValue("@i_IdMotivoTraslado", 1);
            cmd4.Parameters.AddWithValue("@i_IdProducto", hfAntiparasito.Value);
            cmd4.Parameters.AddWithValue("@i_IdAlmacen", ddlAlmacenAntiparasito.SelectedValue);
            cmd4.Parameters.AddWithValue("@f_Cantidad", 1);
            cmd4.Parameters.AddWithValue("@n_IdTipoDocumento", DBNull.Value);
            cmd4.Parameters.AddWithValue("@v_NumeroDocumento", DBNull.Value);
            cmd4.Parameters.AddWithValue("@i_IdCliente", hfCliente.Value);
            cmd4.Parameters.AddWithValue("@i_IdProveedor", DBNull.Value);
            cmd4.ExecuteNonQuery();

            tran.Commit();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Antiparásito registrada satisfactoriamente' });</script>", false);
        }
        catch (Exception ex)
        {
            tran.Rollback();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
        }
        finally
        {
            cn.Close();
        }

        ListarAntiparasitariosAplicadas();
        MostrarCuentaCorriente();
        ddlAlmacenAntiparasito.Enabled = true;
        ibSucursalAntiparasito.Visible = true;
        txtAntiparasito.Text = "";
        txtAntiparasito.Enabled = false;
        lblPrecioAntiparasito.Text = "";
        hfAntiparasito.Value = "0";
        txtComentarioAntiparasito.Text = "";
        txtComentarioAntiparasito.Enabled = false;
        ibAceptarAplicaAntiparasito.Enabled = false;
    }



    void ListarVacunasAplicadas() 
    {
        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();
        DataTable dtVacunas = new DataTable();
        SqlDataAdapter daVacunas = new SqlDataAdapter("BDVETER_Vacunacion_Listar " + i_IdPaciente, conexion);
        daVacunas.Fill(dtVacunas);
        gv.DataSource = dtVacunas;
        gv.DataBind();
    }

    void ListarAntipulgasAplicadas() 
    {
        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();
        DataTable dtAntipulgas = new DataTable();
        SqlDataAdapter daAntipulgas = new SqlDataAdapter("BDVETER_Antipulga_Listar " + i_IdPaciente, conexion);
        daAntipulgas.Fill(dtAntipulgas);
        gvAntipulgaAplicada.DataSource = dtAntipulgas;
        gvAntipulgaAplicada.DataBind();
    }

    void ListarAntiparasitariosAplicadas() 
    {
        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();
        DataTable dtAntiparasitario = new DataTable();
        SqlDataAdapter daAntiparasito = new SqlDataAdapter("BDVETER_Antiparasito_Listar " + i_IdPaciente, conexion);
        daAntiparasito.Fill(dtAntiparasitario);
        gvAntiparasito.DataSource = dtAntiparasitario;
        gvAntiparasito.DataBind();
    }




    protected void ibAceptarVacunaProg_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();

        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();

        SqlTransaction tran;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        cn.Open();
        tran = cn.BeginTransaction();

        try 
        {

            //Registrar Vacunación
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BDVETER_Programacion_Registrar";
            cmd.Parameters.AddWithValue("@d_FechaProgramacion", DateTime.Parse(txtFechaVacunacionProg.Text));
            cmd.Parameters.AddWithValue("@i_IdAlmacen", 1);
            cmd.Parameters.AddWithValue("@i_IdPaciente", i_IdPaciente);
            cmd.Parameters.AddWithValue("@n_IdUsuarioMedico", n_IdUsuario);
            cmd.Parameters.AddWithValue("@i_IdProducto", hfIdProducto.Value);
            cmd.Parameters.AddWithValue("@t_Observacion", txtComentarioVacunacion.Text);
            cmd.ExecuteNonQuery();

            ListarProgramacionVacunas();
        }

        catch (Exception ex)
        {
            tran.Rollback();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
        }
        finally
        {
            cn.Close();
        }

    }

    void ListarProgramacionVacunas() 
    {
        string i_IdPaciente = Request.QueryString["i_IdPaciente"].ToString();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Programacion_Listar " + i_IdPaciente + "," + 3, conexion);
        da.Fill(dt);
        gvProgVacuna.DataSource = dt;
        gvProgVacuna.DataBind();
    }

}
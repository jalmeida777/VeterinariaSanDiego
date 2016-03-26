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

public partial class CrearVacunacion : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            
            ListarMedico();
            ListarVacuna();
            ListarVacunaProxima();
            txtFechaVacunacion.Text = DateTime.Now.ToShortDateString();
            txtFechaRevacunacion.Text = DateTime.Now.ToShortDateString();

         }
    }

    void ListarMedico()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Medico_Combo", conexion);
        da.Fill(dt);

        ddlPersonal.DataSource = dt;
        ddlPersonal.DataTextField = "v_Nombre";
        ddlPersonal.DataValueField = "i_IdMedico";
        ddlPersonal.DataBind();
        ddlPersonal.SelectedIndex = 0;
    }

    void ListarVacuna()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Vacuna_Combo", conexion);
        da.Fill(dt);

        ddlVacunas.DataSource = dt;
        ddlVacunas.DataTextField = "v_Descripcion";
        ddlVacunas.DataValueField = "i_IdProducto";
        ddlVacunas.DataBind();
        ddlVacunas.SelectedIndex = 0;
    }

    void ListarVacunaProxima()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Vacuna_Combo", conexion);
        da.Fill(dt);

        ddlVacunaProxima.DataSource = dt;
        ddlVacunaProxima.DataTextField = "v_Descripcion";
        ddlVacunaProxima.DataValueField = "i_IdProducto";
        ddlVacunaProxima.DataBind();
        ddlVacunaProxima.SelectedIndex = 0;
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        string i_IdVacunar = "";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conexion;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "BDVETER_Vacunacion_Registrar";
        cmd.Parameters.AddWithValue("@i_IdProducto", ddlVacunas.SelectedValue);
        cmd.Parameters.AddWithValue("@v_MarcaSerie", txtGeneral.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@d_FechaVacunacion", DateTime.Parse(txtFechaVacunacion.Text + " " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00")));
        cmd.Parameters.AddWithValue("@i_DiasRevacunacion", int.Parse(txtDiasRev.Text));
        cmd.Parameters.AddWithValue("@d_FechaRevacunacion", DateTime.Parse(txtFechaRevacunacion.Text + " " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00")));
        cmd.Parameters.AddWithValue("@i_IdProximaVacuna", ddlVacunaProxima.SelectedValue);           

        conexion.Open();
        i_IdVacunar = cmd.ExecuteScalar().ToString();
        lblCodigo.Text = i_IdVacunar;
        conexion.Close();
        cmd.Dispose();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Vacunación registrada satisfactoriamente' });</script>", false);
        
    }
}
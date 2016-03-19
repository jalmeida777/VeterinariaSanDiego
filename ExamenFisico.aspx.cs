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

public partial class ExamenFisico : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            ListarDiagnostico();
            txtFechaRegistro.Text = DateTime.Now.ToShortDateString();
           

         }
    }

    void ListarDiagnostico()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("BDVETER_Diagnostico_Combo", conexion);
        da.Fill(dt);

        ddlDiagnostico.DataSource = dt;
        ddlDiagnostico.DataTextField = "v_Descripcion";
        ddlDiagnostico.DataValueField = "i_IdDiagnostico";
        ddlDiagnostico.DataBind();
        ddlDiagnostico.SelectedIndex = 0;
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        string i_IdExamenFisico = "";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conexion;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "BDVETER_ExamenFisico_Registrar";
        cmd.Parameters.AddWithValue("@i_IdDiagnostico", ddlDiagnostico.SelectedValue);
        cmd.Parameters.AddWithValue("@d_FechaExamen", DateTime.Parse(txtFechaRegistro.Text + " " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00")));
        cmd.Parameters.AddWithValue("@f_Temperatura", double.Parse(txtTemperatura.Text));
        cmd.Parameters.AddWithValue("@f_Peso", double.Parse(txtPeso.Text));
        cmd.Parameters.AddWithValue("@f_Hidratacion", double.Parse(txtHidratacion.Text));
        cmd.Parameters.AddWithValue("@f_FC", double.Parse(txtFC.Text));
        cmd.Parameters.AddWithValue("@f_Pulso", double.Parse(txtPulso.Text));
        cmd.Parameters.AddWithValue("@f_FR", double.Parse(txtFR.Text));
        cmd.Parameters.AddWithValue("@v_General", txtGeneral.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_OONG", txtOONG.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_PielTegumento", txtPiel.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_MusculoEsqueletico", txtMusculo.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_Cardiovascular", txtCardiovascular.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_Respiratorio", txtRespiratorio.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_Gastrointestinal", txtGastro.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_GenitalReproductor", txtGenital.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_Neurologico", txtNeurologico.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_Linfatico", txtLinfatico.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_Otros", txtOtros.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@t_Tratamiento", txtTratamiento.Text.Trim().ToUpper());

        conexion.Open();
        i_IdExamenFisico = cmd.ExecuteScalar().ToString();
        lblCodigo.Text = i_IdExamenFisico;
        conexion.Close();
        cmd.Dispose();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Examen Fisico registrado satisfactoriamente' });</script>", false);
        
    }
}
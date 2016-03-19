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

public partial class ExamenOrina : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            ListarEspecie();
            txtFechaRegistro.Text = DateTime.Now.ToShortDateString();


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
        Response.Redirect("Principal.aspx");
    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        string i_IdExamenOrina = "";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conexion;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "BDVETER_AnalisisOrina_Registrar";

        cmd.Parameters.AddWithValue("@i_IdEspecie", ddlEspecie.SelectedValue);
        cmd.Parameters.AddWithValue("@d_FechaExamen", DateTime.Parse(txtFechaRegistro.Text + " " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00")));
        cmd.Parameters.AddWithValue("@v_Color", txtColor.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@v_Turbidez", txtTurbidez.Text.Trim().ToUpper());
        cmd.Parameters.AddWithValue("@f_Densidad", double.Parse(txtDensidad.Text));
        cmd.Parameters.AddWithValue("@f_Proteinas", double.Parse(txtProteinas.Text));
        cmd.Parameters.AddWithValue("@f_PH", double.Parse(txtPH.Text));
        cmd.Parameters.AddWithValue("@f_CuerpoCetonicos", double.Parse(txtCuerpo.Text));
        cmd.Parameters.AddWithValue("@f_Glucosa", double.Parse(txtGlucosa.Text));
        cmd.Parameters.AddWithValue("@f_Hemoglobina", double.Parse(txtHemoglobina.Text));
        cmd.Parameters.AddWithValue("@f_Urobilinogeno", double.Parse(txtUrobilinogeno.Text));
        cmd.Parameters.AddWithValue("@f_Bilirrubina", double.Parse(txtBilirrubina.Text));
        cmd.Parameters.AddWithValue("@f_Leucocitos", double.Parse(txtLeucocito.Text));
        cmd.Parameters.AddWithValue("@t_Otros", txtOtros.Text.Trim().ToUpper());

        conexion.Open();
        i_IdExamenOrina = cmd.ExecuteScalar().ToString();
        lblCodigo.Text = i_IdExamenOrina;
        conexion.Close();
        cmd.Dispose();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Analisis Orina registrado satisfactoriamente' });</script>", false);
        
    }
}
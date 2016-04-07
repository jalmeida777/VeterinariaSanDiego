using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class CrearUnidadEquivalencia : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false) 
        {
            ListarUnidad();
            if (Request.QueryString["i_IdUnidadEquivalencia"] != null) 
            {
                string i_IdUnidadEquivalencia = Request.QueryString["i_IdUnidadEquivalencia"];
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SISGEVET_UnidadEquivalencia_Seleccionar " + i_IdUnidadEquivalencia, conexion);
                da.Fill(dt);
                lblCodigo.Text = i_IdUnidadEquivalencia;
                ddlUnidadBase.SelectedValue = dt.Rows[0]["i_IdUnidadInicial"].ToString();
                ddlUnidadEquivalencia.SelectedValue = dt.Rows[0]["i_IdUnidadFinal"].ToString();
                txtFactor.Text = dt.Rows[0]["f_FactorEquivalencia"].ToString();
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());
            }
        }
    }

    void ListarUnidad() 
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("SISGEVET_Unidad_Combo", conexion);
        da.Fill(dt);
        ddlUnidadBase.DataSource = dt;
        ddlUnidadBase.DataTextField = "v_Descripcion";
        ddlUnidadBase.DataValueField = "i_IdUnidad";
        ddlUnidadBase.DataBind();

        ddlUnidadEquivalencia.DataSource = dt;
        ddlUnidadEquivalencia.DataTextField = "v_Descripcion";
        ddlUnidadEquivalencia.DataValueField = "i_IdUnidad";
        ddlUnidadEquivalencia.DataBind();
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarUnidadEquivalencia.aspx");
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtFactor.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el factor de equivalencia' });</script>", false);
            txtFactor.Focus();
            return;
        }

        try
        {
            if (lblCodigo.Text.Trim() != "")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SISGEVET_UnidadEquivalencia_Actualizar";
                cmd.Parameters.AddWithValue("@i_IdUnidadEquivalencia", lblCodigo.Text.Trim());
                cmd.Parameters.AddWithValue("@i_IdUnidadInicial", ddlUnidadBase.SelectedValue);
                cmd.Parameters.AddWithValue("@f_FactorEquivalencia", txtFactor.Text);
                cmd.Parameters.AddWithValue("@i_IdUnidadFinal", ddlUnidadEquivalencia.SelectedValue);
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Equivalencia actualizada.' });</script>", false);
            }
            else
            {
                string i_IdUnidadEquivalencia = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SISGEVET_UnidadEquivalencia_Registrar";
                cmd.Parameters.AddWithValue("@i_IdUnidadInicial", ddlUnidadBase.SelectedValue);
                cmd.Parameters.AddWithValue("@f_FactorEquivalencia", txtFactor.Text);
                cmd.Parameters.AddWithValue("@i_IdUnidadFinal", ddlUnidadEquivalencia.SelectedValue);
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                conexion.Open();
                i_IdUnidadEquivalencia = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = i_IdUnidadEquivalencia;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Equivalencia registrada.' });</script>", false);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        ddlUnidadBase.Text = "";
        txtFactor.Text = "";
        ddlUnidadEquivalencia.Text = "";

    }
}
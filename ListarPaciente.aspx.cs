using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.Web.ASPxGridView;

public partial class ListarPaciente : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFinal.Text = DateTime.Now.ToShortDateString();

            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Pacientes";
            }
            Listar();
        }
        txtBuscar.Focus();
    }

    protected void ddlBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBusqueda.SelectedValue == "Nombre del Paciente")
        {
            txtBuscar.Visible = true;
            txtBuscarCliente.Visible = false;
            tblFiltroFecha.Visible = false;
            tblEspecie.Visible = false;
            tblRaza.Visible = false;
            tblSexo.Visible = false;
            tblEstado.Visible = false;
        }
        else if (ddlBusqueda.SelectedValue == "Nombre del Cliente")
        {
            txtBuscar.Visible = false;
            txtBuscarCliente.Visible = true;
            tblFiltroFecha.Visible = false;
            tblEspecie.Visible = false;
            tblRaza.Visible = false;
            tblSexo.Visible = false;
            tblEstado.Visible = false;
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Nacimiento")
        {
            txtBuscar.Visible = false;
            txtBuscarCliente.Visible = false;
            tblFiltroFecha.Visible = true;
            tblEspecie.Visible = false;
            tblRaza.Visible = false;
            tblSexo.Visible = false;
            tblEstado.Visible = false;
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Ultima Visita")
        {
            txtBuscar.Visible = false;
            txtBuscarCliente.Visible = false;
            tblFiltroFecha.Visible = true;
            tblEspecie.Visible = false;
            tblRaza.Visible = false;
            tblSexo.Visible = false;
            tblEstado.Visible = false;
        }
        else if (ddlBusqueda.SelectedValue == "Especie")
        {
            txtBuscar.Visible = false;
            txtBuscarCliente.Visible = false;
            tblFiltroFecha.Visible = false;
            tblEspecie.Visible = true;
            tblRaza.Visible = false;
            tblSexo.Visible = false;
            tblEstado.Visible = false;
            ddlEspecie.AutoPostBack = false;
            if (ddlEspecie.Items.Count == 0)
            {
                ListarEspecies();
            }
            ddlEspecie.SelectedIndex = 0;
        }
        else if (ddlBusqueda.SelectedValue == "Raza")
        {
            txtBuscar.Visible = false;
            txtBuscarCliente.Visible = false;
            tblFiltroFecha.Visible = false;
            tblEspecie.Visible = true;
            tblRaza.Visible = true;
            tblSexo.Visible = false;
            tblEstado.Visible = false;
            ddlEspecie.AutoPostBack = true;
            if (ddlEspecie.Items.Count == 0)
            {
                ListarEspecies();
                ListarRazas();
            }
            ddlEspecie.SelectedIndex = 0;
            ListarRazas();
            if (ddlRaza.Items.Count == 0)
            {
                ddlRaza.Enabled = false;
            }
            else 
            {
                ddlRaza.Enabled = true;
                ddlRaza.SelectedIndex = 0;
            }
        }
        else if (ddlBusqueda.SelectedValue == "Sexo")
        {
            txtBuscar.Visible = false;
            txtBuscarCliente.Visible = false;
            tblFiltroFecha.Visible = false;
            tblEspecie.Visible = false;
            tblRaza.Visible = false;
            tblSexo.Visible = true;
            tblEstado.Visible = false;
            if (ddlSexo.Items.Count == 0) 
            {
                ListarSexo();
            }
            ddlSexo.SelectedIndex = 0;
        }
        else if (ddlBusqueda.SelectedValue == "Estado")
        {
            txtBuscar.Visible = false;
            txtBuscarCliente.Visible = false;
            tblFiltroFecha.Visible = false;
            tblEspecie.Visible = false;
            tblRaza.Visible = false;
            tblSexo.Visible = false;
            tblEstado.Visible = true;
            if (ddlEstado.Items.Count == 0) 
            {
                PacienteEstado();
            }
            ddlEstado.SelectedIndex = 0;
        }
        Listar();
    }

    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
    }

    void Listar() 
    {
        string FechaInicial = DateTime.Parse(txtFechaInicial.Text).Year.ToString("0000") + DateTime.Parse(txtFechaInicial.Text).Month.ToString("00") + DateTime.Parse(txtFechaInicial.Text).Day.ToString("00");
        string FechaFinal = DateTime.Parse(txtFechaFinal.Text).Year.ToString("0000") + DateTime.Parse(txtFechaFinal.Text).Month.ToString("00") + DateTime.Parse(txtFechaFinal.Text).Day.ToString("00");

        string consulta = "";
        consulta = consulta + "select pac.i_IdPaciente,cli.v_Nombres ,pac.v_NombrePaciente,esp.v_Descripcion as 'Especie',raz.v_Descripcion as 'Raza', ";
        consulta = consulta + "sex.v_Descripcion as 'Sexo',convert(varchar(10),pac.d_FechaNacimiento,103) as 'd_FechaNacimiento',convert(varchar(10),pac.d_FechaUltimaVisita,103) as 'd_FechaUltimaVisita', convert(varchar(10),pac.d_FechaUltimoBaño,103) as 'd_FechaUltimoBaño', ";
        consulta = consulta + "convert(varchar(10),pac.d_FechaUltimaVacuna,103) as 'd_FechaUltimaVacuna',convert(varchar(10),pac.d_FechaUltimaATP,103) as 'd_FechaUltimaATP',convert(varchar(10),pac.d_FechaUltimaAPG,103) as 'd_FechaUltimaAPG',pac.v_Microchip,pe.v_Estado ";
        consulta = consulta + "from Paciente pac ";
        consulta = consulta + "inner join Cliente cli on pac.i_IdCliente = cli.i_IdCliente ";
        consulta = consulta + "inner join Especie esp on esp.i_IdEspecie = pac.i_IdEspecie ";
        consulta = consulta + "inner join Raza raz on raz.i_IdRaza = pac.i_IdRaza ";
        consulta = consulta + "inner join Sexo sex on sex.i_IdSexo = pac.i_IdSexo ";
        consulta = consulta + "inner join PacienteEstado pe on pac.i_IdPacienteEstado = pe.i_IdPacienteEstado ";

        if (ddlBusqueda.SelectedValue == "Nombre del Paciente")
        {
            consulta = consulta + " where pac.v_NombrePaciente like '%" + txtBuscar.Text + "%' ";
        }
        else if (ddlBusqueda.SelectedValue == "Nombre del Cliente")
        {
            consulta = consulta + " where cli.v_Nombres like '%" + txtBuscarCliente.Text + "%' ";
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Nacimiento")
        {
            consulta = consulta + " where convert(char(8),pac.d_FechaNacimiento,112) between '" + FechaInicial + "' and '" + FechaFinal + "' ";
        }
        else if (ddlBusqueda.SelectedValue == "Fecha de Ultima Visita")
        {
            consulta = consulta + " where convert(char(8),pac.d_FechaUltimaVisita,112) between '" + FechaInicial + "' and '" + FechaFinal + "' ";
        }
        else if (ddlBusqueda.SelectedValue == "Especie") 
        {
            consulta = consulta + "and esp.v_Descripcion like '" + ddlEspecie.SelectedItem.Text + "' + '%'";
        }
        else if (ddlBusqueda.SelectedValue == "Raza") 
        {
            if (ddlRaza.Items.Count == 0)
            {
                return;
            }
            else
            {
                consulta = consulta + "and raz.v_Descripcion like '" + ddlRaza.SelectedItem.Text + "' + '%'";
            }
        }
        else if (ddlBusqueda.SelectedValue == "Sexo") 
        {
            consulta = consulta + "and sex.v_Descripcion like '" + ddlSexo.SelectedItem.Text + "' + '%'";
        }
        else if (ddlBusqueda.SelectedValue == "Estado") 
        {
            if (ddlEstado.SelectedIndex == 0) 
            {
                consulta = consulta + "and pe.v_Estado like '%'";
            }
            else
            {
                consulta = consulta + "and pe.v_Estado like '" + ddlEstado.SelectedItem.Text + "' + '%'";
            }
        }

        consulta = consulta + " order by pac.v_NombrePaciente";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
        da.Fill(dt);

        gv.DataSource = dt;
        gv.DataBind();
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

    protected void ddlEspecie_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRazas();
    }

    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
        ASPxGridViewExporter1.WriteXlsToResponse();
    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }

    protected void gv_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
    {
        Listar();
    }

    protected void gv_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            string i_IdPaciente = e.GetValue("i_IdPaciente").ToString();

            LinkButton lbPaciente = new LinkButton();
            lbPaciente = (LinkButton)gv.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)(gv.Columns[1]), "lbPaciente");

            lbPaciente.PostBackUrl = "CrearPaciente.aspx?i_IdPaciente=" + i_IdPaciente;

        }
    }
}
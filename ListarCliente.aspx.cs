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
using System.Drawing;

public partial class ListarCliente : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFinal.Text = DateTime.Now.ToShortDateString();

            txtFechaInicialVis.Text = DateTime.Now.ToShortDateString();
            txtFechaFinalVis.Text = DateTime.Now.ToShortDateString();

            Label lblTitulo = (Label)Master.FindControl("lblTitulo");
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Administración de Clientes";
            }
            Listar();
        }
        txtBuscar.Focus();
    }

    void Listar()
    {
        string FechaInicial = DateTime.Parse(txtFechaInicial.Text).Year.ToString("0000") + DateTime.Parse(txtFechaInicial.Text).Month.ToString("00") + DateTime.Parse(txtFechaInicial.Text).Day.ToString("00");
        string FechaFinal = DateTime.Parse(txtFechaFinal.Text).Year.ToString("0000") + DateTime.Parse(txtFechaFinal.Text).Month.ToString("00") + DateTime.Parse(txtFechaFinal.Text).Day.ToString("00");

        string FechaInicialVis = DateTime.Parse(txtFechaInicialVis.Text).Year.ToString("0000") + DateTime.Parse(txtFechaInicialVis.Text).Month.ToString("00") + DateTime.Parse(txtFechaInicialVis.Text).Day.ToString("00");
        string FechaFinalVis = DateTime.Parse(txtFechaFinalVis.Text).Year.ToString("0000") + DateTime.Parse(txtFechaFinalVis.Text).Month.ToString("00") + DateTime.Parse(txtFechaFinalVis.Text).Day.ToString("00");

        string Estado = "";
        if (chkEstado.Checked) { Estado = "1"; } else { Estado = "0"; }

        
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter("BDVETERINARIASANDIEGO_Cliente_Listar '" + FechaInicial + "','" + FechaFinal + "', '" + FechaInicialVis + "','" + FechaFinalVis + "', '" + txtBuscar.Text.Trim() + "'," + Estado, conexion);
        da.Fill(dt);
        gvCliente.DataSource = dt;
        gvCliente.DataBind();

    }

    protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
    {
        Listar();
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CrearCliente.aspx");
    }
    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Principal.aspx");
    }
    protected void gvProveedor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int i_IdCliente = int.Parse(gvCliente.DataKeys[e.Row.RowIndex].Value.ToString());
            ImageButton btnEditar = e.Row.FindControl("ibEditar") as ImageButton;

            if (btnEditar != null)
            {
                btnEditar.PostBackUrl = "CrearCliente.aspx?i_IdCliente=" + i_IdCliente;
            }


        }
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        Listar();
    }
    protected void chkEsTaller_CheckedChanged(object sender, EventArgs e)
    {
        Listar();
    }



    //protected void ExportToExcel(object sender, ImageClickEventArgs e)
    //{
        
    //}
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    private void ExportGridExcel()
    {
    
     Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages

            gvCliente.AllowPaging = false;
            Listar();

            gvCliente.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvCliente.HeaderRow.Cells)
            {
                cell.BackColor = gvCliente.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvCliente.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvCliente.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvCliente.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvCliente.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    
    }



}
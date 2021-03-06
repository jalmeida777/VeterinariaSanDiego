﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack == false)
             {
        txtUsuario.Focus();
        ListarAlmacenes();
        ddlAlmacenes_SelectedIndexChanged(null, null);
             }
        
    }

        public void ListarAlmacenes()
    {
          
        DataTable dt = new DataTable();
        if (dt.Rows.Count == 0)
        {
        SqlDataAdapter da = new SqlDataAdapter("CQ_Almacen_Combo", conexion);
        da.Fill(dt);

        ddlAlmacenes.DataSource = dt;
        ddlAlmacenes.DataTextField = "v_Descripcion";
        ddlAlmacenes.DataValueField = "i_IdAlmacen";
        ddlAlmacenes.DataBind();
            }

        else { }  
    }
    protected void btnEntrar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtUsuario.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el usuario' });</script>", false);
            txtUsuario.Focus();
            return;
        }
        if (txtContraseña.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar su contraseña' });</script>", false);
            txtContraseña.Focus();
            return;
        }

    

        DataTable dtUsuario = new DataTable();
        SqlDataAdapter daUsuario = new SqlDataAdapter("Play_Usuario_Select '" + txtUsuario.Text.Trim().ToUpper() + "','" + txtContraseña.Text.Trim() + "','" + ddlAlmacenes.SelectedValue.Trim() + "'", conexion);
        daUsuario.Fill(dtUsuario);
        if (dtUsuario != null) 
        {
            if (dtUsuario.Rows.Count == 1) 
            {
                //Guardar datos del Usuario en la sesión
                string Usuario = dtUsuario.Rows[0]["v_Usuario"].ToString();
                //string Almacen = dtUsuario.Rows[0]["i_IdAlmacen"].ToString();
                string n_IdUsuario = dtUsuario.Rows[0]["n_IdUsuario"].ToString();
                Session["dtUsuario"] = dtUsuario;

                //Guardar almacenes permitidos el usuario en la sesión
                DataTable dtAlmacenes = new DataTable();
                //string i_IdAlmacen = ddlAlmacenes.SelectedValue;
                SqlDataAdapter daAlmacenes = new SqlDataAdapter("Play_Almacen_Select '" + ddlAlmacenes.SelectedValue.Trim() + "'", conexion);
                daAlmacenes.Fill(dtAlmacenes);
                if (dtAlmacenes.Rows.Count > 0)
                {
                    string Almacen = dtAlmacenes.Rows[0]["v_Descripcion"].ToString();
                    string i_IdAlmacen = dtAlmacenes.Rows[0]["i_IdAlmacen"].ToString();
                    Session["dtAlmacenes"] = dtAlmacenes;
                }
                else 
                { 
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'No hay sucursales vinculadas con su usuario' });</script>", false);
                    return;
                }

                ////Verificar que el tipo de cambio se encuentre registrado para el día de hoy.
                //int año = DateTime.Now.Year;
                //int mes = DateTime.Now.Month;
                //int dia = DateTime.Now.Day;
                //bool existe = false;
                //double f_TC = 0;
                //double f_TCPlay = 0;
                //SqlDataAdapter da = new SqlDataAdapter("Play_TC_Existencia " + año + "," + mes + "," + dia, conexion);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //if (dt != null)
                //{
                //    if (dt.Rows.Count > 0)
                //    {
                //        existe = true;
                //    }
                //    else 
                //    {
                //        existe = false;
                //    }
                //}
                //else 
                //{
                //    existe = false;
                //}

                //if (existe == true)
                //{
                //    f_TC = double.Parse(dt.Rows[0]["f_TC"].ToString());
                //    f_TCPlay = double.Parse(dt.Rows[0]["f_TCPlay"].ToString());
                //    dtUsuario.Rows[0]["f_TC"] = f_TC;
                //    dtUsuario.Rows[0]["f_TCPlay"] = f_TCPlay;
                    //Session["dtUsuario"] = dtUsuario;


                    FormsAuthentication.RedirectFromLoginPage(Usuario, false);
              
                //}
                //else 
                //{
                //    Response.Redirect("TipoCambio.aspx");
                //}
                
            }
            string myStringVariable = string.Empty;

            myStringVariable = "Usuario, contraseña o sucursal Incorrecta";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

    }
    protected void ddlAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.Web.ASPxNavBar;
using DevExpress.Web.ASPxMenu;

public partial class Plantilla : System.Web.UI.MasterPage
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false) 
        {
            ListarMenu();
        }

    }


    //void ListarTipoCambioDelDia() 
    //{
    //    int dia = DateTime.Now.Day;
    //    int mes = DateTime.Now.Month;
    //    int año = DateTime.Now.Year;
    //    bool existe = false;
    //    SqlDataAdapter da = new SqlDataAdapter("Play_TC_Existencia " + año + "," + mes + "," + dia, conexion);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    if (dt != null)
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            existe = true;
    //        }
    //        else
    //        {
    //            existe = false;
    //        }
    //    }
    //    else
    //    {
    //        existe = false;
    //    }

    //    if (existe == true)
    //    {
    //        lblTC.Text = dt.Rows[0]["f_TC"].ToString();
    //    }
    //    else 
    //    {
    //        lblTC.Text = "0.00";
    //    }
    //}



    protected void ListarMenu()
    {

        if (Session["dtUsuario"] != null)
        {
            DataTable dtUsuario = new DataTable();
            dtUsuario = (DataTable)Session["dtUsuario"];
            string i_IdRol = dtUsuario.Rows[0]["i_IdRol"].ToString();
                
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Play_Menus_Menu " + i_IdRol, conexion);
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string i_IdMenu = dt.Rows[i]["i_IdMenu"].ToString();
                string v_Nombre = dt.Rows[i]["v_Nombre"].ToString();

                DevExpress.Web.ASPxMenu.MenuItem mi = new DevExpress.Web.ASPxMenu.MenuItem();
                mi.Text = v_Nombre;

                DataTable dtHijos = new DataTable();
                SqlDataAdapter daHijos = new SqlDataAdapter("Play_Menus_Menu_Hijos " + i_IdRol + "," + i_IdMenu, conexion);
                daHijos.Fill(dtHijos);

                for (int x = 0; x < dtHijos.Rows.Count; x++)
                {
                    string i_IdMenuHijo = dtHijos.Rows[x]["i_IdMenu"].ToString();
                    string v_NombreHijo = dtHijos.Rows[x]["v_Nombre"].ToString();
                    string v_UrlHijo = dtHijos.Rows[x]["v_Url"].ToString();

                    DevExpress.Web.ASPxMenu.MenuItem mo = new DevExpress.Web.ASPxMenu.MenuItem();
                    mo.Text = v_NombreHijo;
                    mo.NavigateUrl = v_UrlHijo;

                    mi.Items.Add(mo);

                }

                Menu.Items.Add(mi);
            }
            
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Session.Abandon();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class CrearProducto : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            ListarMarcas();
            ddlModelo.Items.Insert(0, "SELECCIONAR");
            ListarCategoria();
            ddlSubCategoria.Items.Insert(0, "SELECCIONAR");
            ListarProveedor();
            ListarEdad();
            ListarBaterias();
            

            if (Request.QueryString["n_IdProducto"] != null)
            {
                string n_IdProducto = Request.QueryString["n_IdProducto"];
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Play_Producto_Seleccionar " + n_IdProducto, conexion);
                da.Fill(dt);
                lblCodigo.Text = n_IdProducto;
                lblCodigoBarras.Text = dt.Rows[0]["v_CodigoBarras"].ToString();
                txtDescripcion.Text = dt.Rows[0]["v_Descripcion"].ToString();
                txtPresentacion.Text = dt.Rows[0]["v_Presentacion"].ToString();

                if (dt.Rows[0]["v_RutaImagen"].ToString().Trim() == "")
                {
                    lblRuta.Text = "~/images/Prev.jpg";
                }
                else
                {
                    lblRuta.Text = dt.Rows[0]["v_RutaImagen"].ToString();
                }
                //ibImagen.ImageUrl = lblRuta.Text;
                ibImagen.ImageUrl = "~/Productos/Redimensionada/" + lblCodigo.Text + ".jpg";

                txtPrecio.Text = float.Parse(dt.Rows[0]["f_Precio"].ToString()).ToString("N2");
                txtCosto.Text = float.Parse(dt.Rows[0]["f_Costo"].ToString()).ToString("N2");
                txtStockMinimo.Text = float.Parse(dt.Rows[0]["f_StockMinimo"].ToString()).ToString("N2");
                rblSexo.SelectedValue = dt.Rows[0]["c_Sexo"].ToString();

                if (dt.Rows[0]["n_IdEdad"].ToString() != "") { ddlEdad.SelectedValue = dt.Rows[0]["n_IdEdad"].ToString(); }
                if (dt.Rows[0]["n_IdProveedor"].ToString() != "") { ddlProveedor.SelectedValue = dt.Rows[0]["n_IdProveedor"].ToString(); }
                if (dt.Rows[0]["n_IdMarca"].ToString() != "") { ddlMarca.SelectedValue = dt.Rows[0]["n_IdMarca"].ToString(); ddlMarca_SelectedIndexChanged(null, null); }
                if (dt.Rows[0]["n_IdModelo"].ToString() != "") { ddlModelo.SelectedValue = dt.Rows[0]["n_IdModelo"].ToString(); }
                if (dt.Rows[0]["n_IdCategoria"].ToString() != "") { ddlCategoria.SelectedValue = dt.Rows[0]["n_IdCategoria"].ToString(); ddlCategoria_SelectedIndexChanged(null, null); }
                if (dt.Rows[0]["n_IdSubCategoria"].ToString() != "") { ddlSubCategoria.SelectedValue = dt.Rows[0]["n_IdSubCategoria"].ToString(); }
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());

                if (dt.Rows[0]["n_IdPilas"].ToString() != "") { ddlBateria.SelectedValue = dt.Rows[0]["n_IdPilas"].ToString(); ddlBateria_SelectedIndexChanged(null, null); }
                txtCantidadBaterias.Text = dt.Rows[0]["i_CantidadPilas"].ToString();
                txtCodigoInterno.Text = dt.Rows[0]["v_CodigoInterno"].ToString();

                ListarStock();
                ibAtras.Visible = true;
                ibSiguiente.Visible = true;
                ibEliminar.Visible = true;
            }
            else 
            {
                txtPrecio.Text = "0.00";
                txtCosto.Text = "0.00";
                txtStockMinimo.Text = "0.00";
                ibEliminar.Visible = false;
            }
            Permisos();
        }
        //txtDescripcion.Focus();
    }

    void ListarMarcas() 
    {
        DataTable dt = new System.Data.DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Marca_Combo", conexion);
        da.Fill(dt);
        ddlMarca.DataSource = dt;
        ddlMarca.DataTextField = "v_DescripcionMarca";
        ddlMarca.DataValueField = "n_IdMarca";
        ddlMarca.DataBind();
        ddlMarca.Items.Insert(0, "SELECCIONAR");
        ddlMarca.SelectedIndex = 0;
    }

    void ListarProveedor() 
    {
        DataTable dt = new System.Data.DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Proveedor_Combo", conexion);
        da.Fill(dt);
        ddlProveedor.DataSource = dt;
        ddlProveedor.DataTextField = "v_Nombre";
        ddlProveedor.DataValueField = "n_IdProveedor";
        ddlProveedor.DataBind();
        ddlProveedor.Items.Insert(0, "SELECCIONAR");
        ddlProveedor.SelectedIndex = 0;
    }

    void ListarCategoria()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Categoria_Combo", conexion);
        da.Fill(dt);
        ddlCategoria.DataSource = dt;
        ddlCategoria.DataTextField = "v_Descripcion";
        ddlCategoria.DataValueField = "n_IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, "SELECCIONAR");
        ddlCategoria.SelectedIndex = 0;
    }

    void ListarEdad() 
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Edad_Combo", conexion);
        da.Fill(dt);
        ddlEdad.DataSource = dt;
        ddlEdad.DataTextField = "v_Descripcion";
        ddlEdad.DataValueField = "n_IdEdad";
        ddlEdad.DataBind();
        ddlEdad.Items.Insert(0, "SELECCIONAR");
        ddlEdad.SelectedIndex = 0;
    }

    void ListarModelos() 
    {
        if (ddlMarca.SelectedIndex > 0)
        {
            string n_IdMarca = ddlMarca.SelectedValue.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Play_Modelo_Combo " + n_IdMarca, conexion);
            da.Fill(dt);
            ddlModelo.DataSource = dt;
            ddlModelo.DataTextField = "v_DescripcionModelo";
            ddlModelo.DataValueField = "n_IdModelo";
            ddlModelo.DataBind();
            ddlModelo.Items.Insert(0, "SELECCIONAR");
            ddlModelo.Enabled = true;
        }
        else 
        {
            ddlModelo.SelectedIndex = 0;
            ddlModelo.Enabled = false;
        }
    }

    void ListarSubCategorias() 
    {
        if (ddlCategoria.SelectedIndex > 0)
        {
            string n_IdCategoria = ddlCategoria.SelectedValue.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Play_SubCategoria_Combo " + n_IdCategoria, conexion);
            da.Fill(dt);
            ddlSubCategoria.DataSource = dt;
            ddlSubCategoria.DataTextField = "v_Descripcion";
            ddlSubCategoria.DataValueField = "n_IdSubCategoria";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, "SELECCIONAR");
            ddlSubCategoria.Enabled = true;
        }
        else 
        {
            ddlSubCategoria.SelectedIndex = 0;
            ddlSubCategoria.Enabled = false;
        }
    }

    void ListarBaterias() 
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Pilas_Combo", conexion);
        da.Fill(dt);
        ddlBateria.DataSource = dt;
        ddlBateria.DataTextField = "v_Descripcion";
        ddlBateria.DataValueField = "n_IdPilas";
        ddlBateria.DataBind();
        ddlBateria.Items.Insert(0, "NINGUNO");
        ddlBateria.SelectedIndex = 0;
    }

    void ListarStock() 
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Stock_Almacen " + lblCodigo.Text, conexion);
        da.Fill(dt);
        gvStock.DataSource = dt;
        gvStock.DataBind();
    }

    void ListarKardex()
    {
        string n_IdProducto = lblCodigo.Text;
        string n_IdAlmacen = gvStock.SelectedDataKey.Value.ToString();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Kardex_Listar " + n_IdProducto + "," + n_IdAlmacen, conexion);
        da.Fill(dt);
        gvKardex.DataSource = dt;
        gvKardex.DataBind();
        Label21.Visible = true;
        Panel1.Visible = true;
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtDescripcion.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar la descripción' });</script>", false);
            txtDescripcion.Focus();
            return;
        }
        if (txtPrecio.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el precio' });</script>", false);
            txtPrecio.Focus();
            return;
        }
        if (txtCodigoInterno.Text.Trim() == "") 
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'Debe ingresar el código interno' });</script>", false);
            txtCodigoInterno.Focus();
            return;
        }
        if (lblCodigo.Text.Trim() == "")
        {
           
            string resultado = "";

            //Validar que el no exista el producto con el mismo nombre
            SqlDataAdapter daProducto = new SqlDataAdapter("select count(1) from producto where v_Descripcion = '" + txtDescripcion.Text.Trim() + "'", conexion);
            DataTable dtProducto = new DataTable();
            daProducto.Fill(dtProducto);
            int cantidad = int.Parse(dtProducto.Rows[0][0].ToString());
            if (cantidad == 0)
            {

                try
                {
                    //Registrar Producto
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Play_Producto_Insertar";
                    cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@v_Presentacion", txtPresentacion.Text.Trim().ToUpper());
                    if (ddlEdad.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdEdad", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdEdad", ddlEdad.SelectedValue.ToString()); }
                    cmd.Parameters.AddWithValue("@c_Sexo", rblSexo.SelectedValue);
                    cmd.Parameters.AddWithValue("@v_RutaImagen", lblRuta.Text.Trim().ToUpper());
                    cmd.Parameters.AddWithValue("@f_Precio", txtPrecio.Text);
                    cmd.Parameters.AddWithValue("@f_Costo", txtCosto.Text);
                    cmd.Parameters.AddWithValue("@f_StockMinimo", txtStockMinimo.Text);
                    if (ddlProveedor.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdProveedor", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdProveedor", ddlProveedor.SelectedValue.ToString()); }
                    if (ddlMarca.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdMarca", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdMarca", ddlMarca.SelectedValue.ToString()); }
                    if (ddlModelo.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdModelo", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdModelo", ddlModelo.SelectedValue.ToString()); }
                    if (ddlCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdCategoria", ddlCategoria.SelectedValue.ToString()); }
                    if (ddlSubCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdSubCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdSubCategoria", ddlSubCategoria.SelectedValue.ToString()); }
                    cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                    if (ddlBateria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdPilas", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdPilas", ddlBateria.SelectedValue); }
                    cmd.Parameters.AddWithValue("@i_CantidadPilas", txtCantidadBaterias.Text);
                    cmd.Parameters.AddWithValue("@v_CodigoInterno", txtCodigoInterno.Text);
                    conexion.Open();
                    resultado = cmd.ExecuteScalar().ToString();
                    conexion.Close();
                    lblCodigo.Text = resultado;

                    //Obtener código de barras
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("select v_CodigoBarras from Producto where n_IdProducto=" + resultado, conexion);
                    da.Fill(dt);
                    lblCodigoBarras.Text = dt.Rows[0]["v_CodigoBarras"].ToString();

                    //Guardar imagen con id del producto
                    if (lblRuta.Text.Trim() != "")
                    {
                        string fullPath = Request.MapPath(lblRuta.Text.Trim());
                        string fullPathDestino = Request.MapPath("~/Productos/");

                        File.Copy(fullPath, fullPathDestino + lblCodigo.Text + lblExtension.Text.Trim(), true);
                        //Limpiar carpeta temp
                        File.Delete(fullPath);

                        string nuevaRuta = "~/Productos/" + lblCodigo.Text.Trim() + lblExtension.Text;
                        lblRuta.Text = nuevaRuta;

                        ibImagen.ImageUrl = lblRuta.Text;

                        //Crear imagen redimensionada
                        string path = HttpContext.Current.Server.MapPath(lblRuta.Text);
                        byte[] binaryImage = File.ReadAllBytes(path);
                        HandleImageUpload(binaryImage, "~/Productos/Redimensionada/" + lblCodigo.Text.Trim() + lblExtension.Text);

                        //Actualizar la ruta en la base de datos
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = conexion;
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.CommandText = "Play_Producto_RutaImagen_Actualizar";
                        cmd2.Parameters.AddWithValue("@n_IdProducto", resultado);
                        cmd2.Parameters.AddWithValue("@v_RutaImagen", nuevaRuta);
                        conexion.Open();
                        cmd2.ExecuteNonQuery();
                        conexion.Close();
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Producto registrado.' });</script>", false);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'El nombre del producto ya existe!' });</script>", false);
            }
        }
        else
        {
            try
            {
                string resultado = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Play_Producto_Actualizar";
                cmd.Parameters.AddWithValue("@n_IdProducto", lblCodigo.Text.Trim());
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_Presentacion", txtPresentacion.Text.Trim().ToUpper());
                if (ddlEdad.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdEdad", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdEdad", ddlEdad.SelectedValue.ToString()); }
                cmd.Parameters.AddWithValue("@c_Sexo", rblSexo.SelectedValue);
                cmd.Parameters.AddWithValue("@v_RutaImagen", lblRuta.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@f_Precio", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@f_Costo", txtCosto.Text);
                cmd.Parameters.AddWithValue("@f_StockMinimo", txtStockMinimo.Text);
                if (ddlProveedor.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdProveedor", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdProveedor", ddlProveedor.SelectedValue.ToString()); }
                if (ddlMarca.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdMarca", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdMarca", ddlMarca.SelectedValue.ToString()); }
                if (ddlModelo.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdModelo", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdModelo", ddlModelo.SelectedValue.ToString()); }
                if (ddlCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdCategoria", ddlCategoria.SelectedValue.ToString()); }
                if (ddlSubCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdSubCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdSubCategoria", ddlSubCategoria.SelectedValue.ToString()); }
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                if (ddlBateria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@n_IdPilas", DBNull.Value); } else { cmd.Parameters.AddWithValue("@n_IdPilas", ddlBateria.SelectedValue); }
                cmd.Parameters.AddWithValue("@i_CantidadPilas", txtCantidadBaterias.Text);
                cmd.Parameters.AddWithValue("@v_CodigoInterno", txtCodigoInterno.Text);
                conexion.Open();
                resultado = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = resultado;

                //Obtener código de barras
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select v_CodigoBarras from Producto where n_IdProducto=" + resultado, conexion);
                da.Fill(dt);
                lblCodigoBarras.Text = dt.Rows[0]["v_CodigoBarras"].ToString();

                //Crear imagen redimensionada
                string path = HttpContext.Current.Server.MapPath(lblRuta.Text.Trim().ToUpper());
                byte[] binaryImage = File.ReadAllBytes(path);
                HandleImageUpload(binaryImage, "~/Productos/Redimensionada/" + lblCodigo.Text.Trim() + ".jpg");

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Producto actualizado.' });</script>", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
            }
        }
        

    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        int i_IdMenu = int.Parse(Request.QueryString["IdMenu"]);
        Response.Redirect("ListarProducto.aspx?IdMenu=" + i_IdMenu);
    }

    protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarModelos();
    }

    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarSubCategorias();
    }

    protected void ibUpload_Click(object sender, ImageClickEventArgs e)
    {
        if (lblCodigo.Text.Trim() == "")
        {
            string filename = Path.GetFileName(fu1.FileName);
            fu1.SaveAs(Server.MapPath("~/temp/") + filename);
            ibImagen.ImageUrl = "~/temp/" + filename;
            lblRuta.Text = "~/temp/" + filename;
            string extension = Path.GetExtension(fu1.FileName);
            lblExtension.Text = extension;
        }
        else 
        {
            try
            {
                //obtener extensión del archivo
                string extension = Path.GetExtension(fu1.FileName);
                lblExtension.Text = extension;
                fu1.SaveAs(Server.MapPath("~/Productos/") + lblCodigo.Text.Trim() + extension);
                ibImagen.ImageUrl = "~/Productos/" + lblCodigo.Text.Trim() + extension;
                lblRuta.Text = "~/Productos/" + lblCodigo.Text.Trim() + extension;

                //Crear imagen redimensionada
                string path = HttpContext.Current.Server.MapPath(lblRuta.Text);
                byte[] binaryImage = File.ReadAllBytes(path);
                HandleImageUpload(binaryImage, "~/Productos/Redimensionada/" + lblCodigo.Text.Trim() + lblExtension.Text);

                //Actualizar la ruta en la base de datos
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Play_Producto_RutaImagen_Actualizar";
                cmd.Parameters.AddWithValue("@n_IdProducto", lblCodigo.Text.Trim());
                cmd.Parameters.AddWithValue("@v_RutaImagen", lblRuta.Text.Trim().ToUpper());
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
            }
        }
    }

    protected void ddlBateria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBateria.SelectedIndex == 0)
        {
            txtCantidadBaterias.Text = "0";
            txtCantidadBaterias.Enabled = false;
        }
        else 
        {
            txtCantidadBaterias.Text = "0";
            txtCantidadBaterias.Enabled = true;
            txtCantidadBaterias.Focus();
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> BuscarProductos(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["conexion"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select v_Descripcion from Producto where v_Descripcion like '%' + @SearchText + '%' order by v_Descripcion";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> productos = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        productos.Add(sdr["v_Descripcion"].ToString());
                    }
                }
                conn.Close();
                return productos;
            }
        }
    }

    protected void gvStock_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarKardex();
    }

    private System.Drawing.Image RezizeImage(System.Drawing.Image img, int maxWidth, int maxHeight)
    {
        if (img.Height < maxHeight && img.Width < maxWidth) return img;
        using (img)
        {
            Double xRatio = (double)img.Width / maxWidth;
            Double yRatio = (double)img.Height / maxHeight;
            Double ratio = Math.Max(xRatio, yRatio);
            int nnx = (int)Math.Floor(img.Width / ratio);
            int nny = (int)Math.Floor(img.Height / ratio);
            Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
            using (Graphics gr = Graphics.FromImage(cpy))
            {
                gr.Clear(Color.Transparent);

                // This is said to give best quality when resizing images
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                gr.DrawImage(img,
                    new Rectangle(0, 0, nnx, nny),
                    new Rectangle(0, 0, img.Width, img.Height),
                    GraphicsUnit.Pixel);
            }
            return cpy;
        }

    }

    private MemoryStream BytearrayToStream(byte[] arr)
    {
        return new MemoryStream(arr, 0, arr.Length);
    }

    private void HandleImageUpload(byte[] binaryImage, string NuevoNombre)
    {
        System.Drawing.Image img = RezizeImage(System.Drawing.Image.FromStream(BytearrayToStream(binaryImage)), 100, 100);
        img.Save(Server.MapPath(NuevoNombre), System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    protected void ibSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["n_IdProducto"] != null)
        {
            string n_IdProducto = Request.QueryString["n_IdProducto"];
            string siguiente = "";
            SqlDataAdapter da = new SqlDataAdapter("select n_IdProducto from Producto order by v_Descripcion asc", conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["n_IdProducto"].ToString().ToUpper() == n_IdProducto)
                {
                    if ((i + 1) == dt.Rows.Count) { break; }
                    else
                    {
                        siguiente = dt.Rows[i + 1]["n_IdProducto"].ToString();
                        break;
                    }
                }
            }
            if (siguiente != "")
            {
                Response.Redirect("CrearProducto.aspx?n_IdProducto=" + siguiente);
            }
        }
    }

    protected void ibAtras_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["n_IdProducto"] != null)
        {
            string n_IdProducto = Request.QueryString["n_IdProducto"];
            string anterior = "";
            SqlDataAdapter da = new SqlDataAdapter("select n_IdProducto from Producto order by v_Descripcion asc", conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["n_IdProducto"].ToString().ToUpper() == n_IdProducto)
                {
                    if ((i - 1) == -1) { break; }
                    else
                    {
                        anterior = dt.Rows[i - 1]["n_IdProducto"].ToString();
                        break;
                    }
                }
            }
            if (anterior != "")
            {
                Response.Redirect("CrearProducto.aspx?n_IdProducto=" + anterior);
            }
        }
    }

    protected void ibEliminar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Play_Producto_Eliminar";
            cmd.Parameters.AddWithValue("@n_IdProducto", lblCodigo.Text);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

            btnGuardar.Enabled = false;
            ibEliminar.Visible = false;
            BloquearProducto();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Producto Eliminado Satisfactoriamente' });</script>", false);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
        }
    }

    void BloquearProducto() 
    {
        txtDescripcion.Enabled = false;
        ibAtras.Enabled = false;
        ibSiguiente.Enabled = false;
        txtPresentacion.Enabled = false;
        ddlEdad.Enabled = false;
        rblSexo.Enabled = false;
        ddlBateria.Enabled = false;
        txtCantidadBaterias.Enabled = false;
        txtPrecio.Enabled = false;
        txtCosto.Enabled = false;
        fu1.Enabled = false;
        ibUpload.Enabled = false;
        txtStockMinimo.Enabled = false;
        ddlMarca.Enabled = false;
        ddlModelo.Enabled = false;
        ddlCategoria.Enabled = false;
        ddlSubCategoria.Enabled = false;
        ddlProveedor.Enabled = false;
        chkEstado.Enabled = false;
        TabContainer1.Enabled = false;
    }

    void Permisos() 
    {
        DataTable dtUsuario = new DataTable();
        dtUsuario = (DataTable)Session["dtUsuario"];
        int i_IdRol = int.Parse(dtUsuario.Rows[0]["i_IdRol"].ToString());
        int i_IdMenu = int.Parse(Request.QueryString["IdMenu"]);

        DataTable dtPermisos = new DataTable();
        SqlDataAdapter daPermisos = new SqlDataAdapter("Play_Permisos_Select " + i_IdRol + "," + i_IdMenu, conexion);
        daPermisos.Fill(dtPermisos);
        if (dtPermisos.Rows[0]["v_NombreAccion"].ToString() == "Registrar") 
        {
            btnGuardar.Enabled = bool.Parse(dtPermisos.Rows[0]["b_Estado"].ToString());
            ibEliminar.Enabled = bool.Parse(dtPermisos.Rows[2]["b_Estado"].ToString());
        }

    }

    protected void callbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
        if (Request.QueryString["n_IdProducto"] != null)
        {
            string n_IdProducto = Request.QueryString["n_IdProducto"];
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select v_RutaImagen,v_CodigoInterno,v_Descripcion from producto where n_IdProducto=" + n_IdProducto, conexion);
            da.Fill(dt);
            lblCodigo0.Text = dt.Rows[0]["v_CodigoInterno"].ToString();
            lblProducto.Text = dt.Rows[0]["v_Descripcion"].ToString();
            ImagenGrande.ImageUrl = dt.Rows[0]["v_RutaImagen"].ToString();
        }
    }
}
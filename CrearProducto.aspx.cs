using System;
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
            txtVencimiento.Text = DateTime.Now.ToShortDateString();

            if (Request.QueryString["i_IdProducto"] != null)
            {
                string n_IdProducto = Request.QueryString["i_IdProducto"];
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Play_Producto_Seleccionar " + n_IdProducto, conexion);
                da.Fill(dt);

                rblTipo.SelectedValue = dt.Rows[0]["c_Tipo"].ToString();
                rblTipo_SelectedIndexChanged(null, null);
                lblCodigo.Text = n_IdProducto;
                txtCodigoInterno.Text = dt.Rows[0]["v_CodigoInterno"].ToString();
                txtCodigoBarras.Text = dt.Rows[0]["v_CodigoBarras"].ToString();
                txtDescripcion.Text = dt.Rows[0]["v_Descripcion"].ToString();

                if (dt.Rows[0]["v_RutaImagen"].ToString().Trim() == "")
                {
                    lblRuta.Text = "~/images/Prev.jpg";
                }
                else
                {
                    lblRuta.Text = dt.Rows[0]["v_RutaImagen"].ToString();
                }
                ibImagen.ImageUrl = "~/Productos/Redimensionada/" + lblCodigo.Text + ".jpg";

                txtPrecio.Text = float.Parse(dt.Rows[0]["f_Precio"].ToString()).ToString("N2");
                txtCosto.Text = float.Parse(dt.Rows[0]["f_Costo"].ToString()).ToString("N2");
                txtStockMinimo.Text = float.Parse(dt.Rows[0]["f_StockMinimo"].ToString()).ToString("N2");

                if (dt.Rows[0]["i_IdProveedor"].ToString() != "") { ddlProveedor.SelectedValue = dt.Rows[0]["i_IdProveedor"].ToString(); }
                if (dt.Rows[0]["i_IdMarca"].ToString() != "") { ddlMarca.SelectedValue = dt.Rows[0]["i_IdMarca"].ToString(); ddlMarca_SelectedIndexChanged(null, null); }
                if (dt.Rows[0]["i_IdModelo"].ToString() != "") { ddlModelo.SelectedValue = dt.Rows[0]["i_IdModelo"].ToString(); }
                if (dt.Rows[0]["i_IdCategoria"].ToString() != "") { ddlCategoria.SelectedValue = dt.Rows[0]["i_IdCategoria"].ToString(); ddlCategoria_SelectedIndexChanged(null, null); }
                if (dt.Rows[0]["i_IdSubCategoria"].ToString() != "") { ddlSubCategoria.SelectedValue = dt.Rows[0]["i_IdSubCategoria"].ToString(); }
                chkEstado.Checked = bool.Parse(dt.Rows[0]["b_Estado"].ToString());
                txtVencimiento.Text = DateTime.Parse(dt.Rows[0]["d_FechaVencimiento"].ToString()).ToShortDateString();
                

                ListarStock();
                ibAtras.Visible = true;
                ibSiguiente.Visible = true;
            }
            else 
            {
                txtPrecio.Text = "0.00";
                txtCosto.Text = "0.00";
                txtStockMinimo.Text = "0.00";
            }
        }
        //txtDescripcion.Focus();
    }

    void ListarMarcas() 
    {
        DataTable dt = new System.Data.DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Marca_Combo", conexion);
        da.Fill(dt);
        ddlMarca.DataSource = dt;
        ddlMarca.DataTextField = "v_NombreMarca";
        ddlMarca.DataValueField = "i_IdMarca";
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
        ddlProveedor.DataValueField = "i_IdProveedor";
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
        ddlCategoria.DataTextField = "v_Categoria";
        ddlCategoria.DataValueField = "i_IdCategoria";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, "SELECCIONAR");
        ddlCategoria.SelectedIndex = 0;
    }

    void ListarModelos() 
    {
        if (ddlMarca.SelectedIndex > 0)
        {
            string i_IdMarca = ddlMarca.SelectedValue.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Play_Modelo_Combo " + i_IdMarca, conexion);
            da.Fill(dt);
            ddlModelo.DataSource = dt;
            ddlModelo.DataTextField = "v_NombreModelo";
            ddlModelo.DataValueField = "i_IdModelo";
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
            string i_IdCategoria = ddlCategoria.SelectedValue.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Play_SubCategoria_Combo " + i_IdCategoria, conexion);
            da.Fill(dt);
            ddlSubCategoria.DataSource = dt;
            ddlSubCategoria.DataTextField = "v_Descripcion";
            ddlSubCategoria.DataValueField = "i_IdSubCategoria";
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
        string i_IdProducto = lblCodigo.Text;
        string i_IdAlmacen = gvStock.SelectedDataKey.Value.ToString();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Play_Kardex_Listar " + i_IdProducto + "," + i_IdAlmacen, conexion);
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
                    cmd.Parameters.AddWithValue("@c_Tipo", rblTipo.SelectedValue);
                    cmd.Parameters.AddWithValue("@v_CodigoInterno", txtCodigoInterno.Text);
                    cmd.Parameters.AddWithValue("@v_CodigoBarras", txtCodigoBarras.Text);
                    cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                    if (lblRuta.Text.Trim() == "") 
                    {
                        cmd.Parameters.AddWithValue("@v_RutaImagen", "~/images/Prev.jpg");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@v_RutaImagen", lblRuta.Text.Trim().ToUpper());
                    }
                    cmd.Parameters.AddWithValue("@f_Precio", txtPrecio.Text);
                    cmd.Parameters.AddWithValue("@f_Costo", txtCosto.Text);
                    cmd.Parameters.AddWithValue("@f_StockMinimo", txtStockMinimo.Text);
                    if (ddlProveedor.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdProveedor", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdProveedor", ddlProveedor.SelectedValue.ToString()); }
                    if (ddlMarca.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdMarca", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdMarca", ddlMarca.SelectedValue.ToString()); }
                    if (ddlModelo.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdModelo", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdModelo", ddlModelo.SelectedValue.ToString()); }
                    if (ddlCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdCategoria", ddlCategoria.SelectedValue.ToString()); }
                    if (ddlSubCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdSubCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdSubCategoria", ddlSubCategoria.SelectedValue.ToString()); }
                    cmd.Parameters.AddWithValue("@d_FechaVencimiento", DateTime.Parse(txtVencimiento.Text));
                    cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                    
                    conexion.Open();
                    resultado = cmd.ExecuteScalar().ToString();
                    conexion.Close();
                    lblCodigo.Text = resultado;


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
                        cmd2.Parameters.AddWithValue("@i_IdProducto", resultado);
                        cmd2.Parameters.AddWithValue("@v_RutaImagen", nuevaRuta);
                        conexion.Open();
                        cmd2.ExecuteNonQuery();
                        conexion.Close();
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Producto / Servicio registrado.' });</script>", false);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.warning({ message: 'El nombre del producto / servicio ya existe!' });</script>", false);
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
                cmd.Parameters.AddWithValue("@i_IdProducto", lblCodigo.Text.Trim());
                cmd.Parameters.AddWithValue("@c_Tipo", rblTipo.SelectedValue);
                cmd.Parameters.AddWithValue("@v_CodigoInterno", txtCodigoInterno.Text);
                cmd.Parameters.AddWithValue("@v_CodigoBarras", txtCodigoBarras.Text);
                cmd.Parameters.AddWithValue("@v_Descripcion", txtDescripcion.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@v_RutaImagen", lblRuta.Text.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@f_Precio", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@f_Costo", txtCosto.Text);
                cmd.Parameters.AddWithValue("@f_StockMinimo", txtStockMinimo.Text);
                if (ddlProveedor.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdProveedor", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdProveedor", ddlProveedor.SelectedValue.ToString()); }
                if (ddlMarca.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdMarca", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdMarca", ddlMarca.SelectedValue.ToString()); }
                if (ddlModelo.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdModelo", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdModelo", ddlModelo.SelectedValue.ToString()); }
                if (ddlCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdCategoria", ddlCategoria.SelectedValue.ToString()); }
                if (ddlSubCategoria.SelectedIndex == 0) { cmd.Parameters.AddWithValue("@i_IdSubCategoria", DBNull.Value); } else { cmd.Parameters.AddWithValue("@i_IdSubCategoria", ddlSubCategoria.SelectedValue.ToString()); }
                cmd.Parameters.AddWithValue("@d_FechaVencimiento", DateTime.Parse(txtVencimiento.Text));
                cmd.Parameters.AddWithValue("@b_Estado", chkEstado.Checked);
                
                conexion.Open();
                resultado = cmd.ExecuteScalar().ToString();
                conexion.Close();
                lblCodigo.Text = resultado;

                //Crear imagen redimensionada
                string path = HttpContext.Current.Server.MapPath(lblRuta.Text.Trim().ToUpper());
                byte[] binaryImage = File.ReadAllBytes(path);
                HandleImageUpload(binaryImage, "~/Productos/Redimensionada/" + lblCodigo.Text.Trim() + ".jpg");

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.notice({ message: 'Producto / Servicio actualizado.' });</script>", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>$.growl.error({ message: '" + ex.Message + "' });</script>", false);
            }
        }
        

    }

    protected void btnSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListarProducto.aspx");
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
                cmd.Parameters.AddWithValue("@i_IdProducto", lblCodigo.Text.Trim());
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
        if (Request.QueryString["i_IdProducto"] != null)
        {
            string n_IdProducto = Request.QueryString["i_IdProducto"];
            string siguiente = "";
            SqlDataAdapter da = new SqlDataAdapter("select i_IdProducto from Producto order by v_Descripcion asc", conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["i_IdProducto"].ToString().ToUpper() == n_IdProducto)
                {
                    if ((i + 1) == dt.Rows.Count) { break; }
                    else
                    {
                        siguiente = dt.Rows[i + 1]["i_IdProducto"].ToString();
                        break;
                    }
                }
            }
            if (siguiente != "")
            {
                Response.Redirect("CrearProducto.aspx?i_IdProducto=" + siguiente);
            }
        }
    }

    protected void ibAtras_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["i_IdProducto"] != null)
        {
            string n_IdProducto = Request.QueryString["i_IdProducto"];
            string anterior = "";
            SqlDataAdapter da = new SqlDataAdapter("select i_IdProducto from Producto order by v_Descripcion asc", conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["i_IdProducto"].ToString().ToUpper() == n_IdProducto)
                {
                    if ((i - 1) == -1) { break; }
                    else
                    {
                        anterior = dt.Rows[i - 1]["i_IdProducto"].ToString();
                        break;
                    }
                }
            }
            if (anterior != "")
            {
                Response.Redirect("CrearProducto.aspx?i_IdProducto=" + anterior);
            }
        }
    }

    void BloquearProducto() 
    {
        txtDescripcion.Enabled = false;
        ibAtras.Enabled = false;
        ibSiguiente.Enabled = false;
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

    protected void callbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
        if (Request.QueryString["i_IdProducto"] != null)
        {
            string i_IdProducto = Request.QueryString["i_IdProducto"];
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select v_RutaImagen,v_CodigoInterno,v_Descripcion from producto where i_IdProducto=" + i_IdProducto, conexion);
            da.Fill(dt);
            lblCodigo0.Text = dt.Rows[0]["v_CodigoInterno"].ToString();
            lblProducto.Text = dt.Rows[0]["v_Descripcion"].ToString();
            ImagenGrande.ImageUrl = dt.Rows[0]["v_RutaImagen"].ToString();
        }
    }

    protected void rblTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblTipo.SelectedValue == "S")
        {
            txtStockMinimo.Text = "0";
            txtStockMinimo.Enabled = false;
            txtVencimiento.Enabled = false;
            TabContainer1.Tabs[1].Visible = false;
        }
        else 
        {
            txtStockMinimo.Enabled = true;
            txtVencimiento.Enabled = true;
            TabContainer1.Tabs[1].Visible = true;
        }
    }
}
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;

namespace Practica.sources.pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID= Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch(sOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "Ingresar nuevo producto";
                            this.btnCrear.Visible= true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de producto";
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar producto";
                            btnActualizar.Visible= true;
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar producto";
                            this.btnEliminar.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("LeerProducto", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id_Producto", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row= dt.Rows[0];
            tbNombre.Text = row[1].ToString();
            tbTipo.Text = row[2].ToString();
            tbPrecio.Text = row[3].ToString();
            con.Close();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("CrearProductos", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value= tbNombre.Text;
            cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = tbTipo.Text;
            cmd.Parameters.Add("@Precio", SqlDbType.Int).Value = tbPrecio.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/sources/pages/FormIndex.aspx");
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("ActualizarProductos", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Id_Producto", SqlDbType.Int).Value= sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = tbTipo.Text;
            cmd.Parameters.Add("@Precio", SqlDbType.Int).Value = tbPrecio.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/sources/pages/FormIndex.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("EliminarProductos", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Id_Producto", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/sources/pages/FormIndex.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/sources/pages/FormIndex.aspx");
        }
    }
}
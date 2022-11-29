using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Practica.sources.pages
{
    public partial class CRUD_Emp : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                LlenarDropDownList();
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "Ingresar nuevo empleado";
                            this.btnCrear.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de empleados";
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar empleado";
                            btnActualizar.Visible = true;
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar empleado";
                            this.btnEliminar.Visible = true;
                            break;
                    }
                }
            }
        }

        

        void LlenarDropDownList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id_Producto, Nombre FROM Productos ORDER BY Id_producto", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            tbProducto.DataSource= ds;
            tbProducto.DataValueField= "Nombre";
            tbProducto.DataBind();
            tbProducto.Items.Insert(0, new ListItem("Selecciona el producto", "0"));
            con.Close();
        }

        void CargarDatos()
        {
            con.Open();
            
            SqlDataAdapter da = new SqlDataAdapter("LeerEmpleados", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id_Empleado", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbNombre.Text = row[1].ToString();
            tbApellido.Text = row[2].ToString();
            tbEdad.Text = row[3].ToString();
            tbEmail.Text = row[4].ToString();
            tbProducto.Text = row[5].ToString();
            con.Close();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("CrearEmpleados", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = tbApellido.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Email", SqlDbType.Text).Value = tbEmail.Text;
            cmd.Parameters.Add("@Producto", SqlDbType.Text).Value = tbProducto.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/sources/pages/FormEmpleados.aspx");
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("ActualizarEmpleados", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Id_Empleado", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = tbApellido.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Email", SqlDbType.Text).Value = tbEmail.Text;
            cmd.Parameters.Add("@Producto", SqlDbType.Text).Value = tbProducto.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/sources/pages/FormEmpleados.aspx");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("EliminarEmpleados", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Id_Empleado", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("/sources/pages/FormEmpleados.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/sources/pages/FormEmpleados.aspx");
        }
    }
    
}
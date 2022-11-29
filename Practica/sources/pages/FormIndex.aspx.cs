using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Practica.sources.pages
{
    public partial class FormIndex : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        int id_rol = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["usuariologueado"]!=null)
            {
                id_rol = Convert.ToInt32(Session["Id_rol"].ToString());
                CargarTabla();
                Permisos(id_rol);
            }
            
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("CargarProductos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvUsuarios.DataSource = dt;
            gvUsuarios.DataBind();
            con.Close();
        }

        void Permisos(int id_rol)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Permisos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id_rol", SqlDbType.Int).Value= id_rol;
                con.Open();
                SqlDataReader reader= cmd.ExecuteReader();

                bool Create, Read, Update, Delete;
                while (reader.Read())
                {

                    foreach (GridViewRow fila in gvUsuarios.Rows)
                {
                    
                        switch (reader[0].ToString())
                        {
                            case "Create":
                                Create = Convert.ToBoolean(reader[1].ToString());
                                
                                if(Create)
                                {
                                    btnCrear.Visible= true;
                                }
                                else
                                {
                                    btnCrear.Visible= false;
                                }
                                break;
                            case "Read":
                                Read = Convert.ToBoolean(reader[1].ToString());
                                Button btn1 = fila.FindControl("btnLeer") as Button;
                                if (Read)
                                
                                {
                                    btn1.Visible = true;
                                    gvUsuarios.Visible = true;
                                }
                                else
                                {
                                    btn1.Visible = false;
                                    gvUsuarios.Visible = false;
                                }

                                break;
                            case "Update":
                                Update = Convert.ToBoolean(reader[1].ToString());
                                Button btn2 = fila.FindControl("btnActualizar") as Button;

                                if (Update)
                                {
                                    btn2.Visible = true;
                                }
                                else
                                {
                                    btn2.Visible = false;
                                }
                                break;
                            case "Delete":
                                Delete = Convert.ToBoolean(reader[1].ToString());
                                Button btn3 = fila.FindControl("btnEliminar") as Button;

                                if (Delete)
                                {
                                    btn3.Visible = true;
                                }
                                else
                                {
                                    btn3.Visible = false;
                                }
                                break;
                        }
                    }
                }
                con.Close();    
                reader.Close();
            }   
            catch(Exception)
            {
                throw;
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUD.aspx?op=C");
        }
        protected void btnLeer_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("CRUD.aspx?id=" + id+"&op=R");
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("CRUD.aspx?id=" + id + "&op=U");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("CRUD.aspx?id=" + id + "&op=D");
        }
    }
}
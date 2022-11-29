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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                int ID = int.Parse(Session["usuariologueado"].ToString());
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Perfil", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        dr.Read();
                        this.lblUsuario.Text = dr["Apellidos"].ToString()+", " +dr["Nombres"].ToString();
                        imgPerfil.ImageUrl = "/sources/pages/FormImagen.aspx?id="+ID;
                        
                    }
                } 
            }
            else
            {
                Response.Redirect("/sources/pages/FormLogin.aspx");
            }
        }

        protected void Perfil(object sender, EventArgs e)
        {
            Response.Redirect("/sources/pages/FormPerfil.aspx");
        }

        protected void Salir (object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Session.Remove("Id_rol");
            Response.Redirect("/sources/pages/FormLogin.aspx");
        }
    }
}
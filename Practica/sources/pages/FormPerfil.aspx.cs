using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services.Discovery;
using System.Text.RegularExpressions;

namespace Practica.sources.pages
{
    public partial class FormPerfil : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Session["usuariologueado"].ToString());
            if (Session["usuariologueado"]==null){

                Response.Redirect("/sources/pages/FormLogin.aspx");
            }
            else
            {                           
                 SqlCommand cmd = new SqlCommand("Perfil", con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                 con.Open();
                 SqlDataReader dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                   Image.ImageUrl = "/sources/pages/FormImagen.aspx?id="+id;
                   this.tbNombres.Text = dr["Nombres"].ToString();
                   this.tbApellidos.Text = dr["Apellidos"].ToString();
                    this.tbFecha.Text = dr["Fecha"].ToString();
                    //tbFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    this.TbUsuario.Text = dr["Usuario"].ToString();    
                    dr.Close(); 
                 }
                 con.Close();                                     
            }
        }

        void MetodoOcultar()
        {
            if (contrasena.Visible == false)
            {
                contrasena.Visible = true;
                btnGuardar.Visible = true;
                btnCambiar.Text = "Cancelar";
                lblErrorClave.Text = "";
            }
            else
            {
                contrasena.Visible = false;
                btnGuardar.Visible = false;
                btnCambiar.Text = "Cambiar contraseña";
                lblErrorClave.Text = "";
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            int tamanoArchivo;
            byte[] imagen = FuImage.FileBytes;
            tamanoArchivo = int.Parse(FuImage.FileContent.Length.ToString());
            if (tamanoArchivo>2097151000)
            {
                lblError.Text = "El tamaño de la imagen debe ser menor a 10mb";
            }
            else if(FuImage.HasFile)
            {
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("CambiarImagen", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = imagen;
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            lblError.Text = "";
                        }
                    }
                }
                catch (Exception exx)
                {
                    lblError.Text = exx.Message;
                }
                
            }
            else
            {
                lblError.Text = "No se ha cargado la imagen.";
            }
        }

        protected void btnCambiar_Click(Object sender, EventArgs e)
        {
            MetodoOcultar();

        }

        protected void Eliminar(object sender, EventArgs e)
        {
            using (con)
            {
                using(SqlCommand cmd = new SqlCommand("Eliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value=id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Remove("usuariologueado");
                    Response.Redirect("/sources/pages/FormLogin.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string clavesinVerificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");
            if (tbClave.Text == "" || tbClave2.Text == "")
            {
                lblError.Text = "Los campos no pueden quedar vacios";
            }
            else if (tbClave.Text != tbClave2.Text)
            {
                lblError.Text = "Las contraseñas no coinciden";
            }
            else if (!letras.IsMatch(clavesinVerificar))
            {
                lblError.Text = "La contraseña debe de tener letras.";
            }
            else if (!numeros.IsMatch(clavesinVerificar))
            {
                lblError.Text = "La contraseña debe de tener numeros.";
            }
            else if (!especiales.IsMatch(clavesinVerificar))
            {
                lblError.Text = "La contraseña debe de tener caracteres especiales.";
            }
            else
            {
                try
                {
                    using (con)
                    {
                        using(SqlCommand cmd = new SqlCommand("CambiarClave", con))
                        {
                            string patron = "InfoToolsSV";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                            cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MetodoOcultar();
                            lblErrorClave.Text = "";
                        }
                    }
                }
                catch(Exception ex)
                {
                    lblErrorClave.Text = ex.Message;
                }
            }   
        }
    }
}
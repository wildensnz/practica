using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace Practica.sources.pages
{
    public partial class FormRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("/sources/pages/FormLogin.aspx");
        }

        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Registrar(object sender, EventArgs e)
        {
            int tamanoImagen = int.Parse(FuImage.FileContent.Length.ToString());
            string clavesinVerificar = tbContra.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");
            con.Open();
            SqlCommand usuario = new SqlCommand("ContarUsuario", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            usuario.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
            int user = Convert.ToInt32(usuario.ExecuteScalar());

            if (tbNombres.Text == "" || tbApellidos.Text == "" || tbFecha.Text == "" || tbUsuario.Text == "")
            {
                lblError.Text = "No puede haber campos vacios!!";
            }
            else if (user>=1)
            {
                lblError.Text = "El usuario" +tbUsuario.Text+ "ya existe.";
            }
            else if (tbContra.Text!=tbRepetir.Text)
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
            else if (!FuImage.HasFile)
            {
                lblError.Text = "No se ha cargado una imagen de perfil.";
            }
            else if (tamanoImagen>= 2097151000)
            {
                lblError.Text = "La imagen tiene un tamaño mayor a 10mb, por favor insertar una mas pequeña";
            }
            else
            {
                byte[] imagen = FuImage.FileBytes;
                string patron = "InfoToolsSV";
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Registrar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = tbNombres.Text;
                        cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = tbApellidos.Text;
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbFecha.Text;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                        cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = tbContra.Text;
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = imagen;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = 0;
                        cmd.ExecuteNonQuery();


                    }
                    con.Close();
                    Response.Redirect("/sources/pages/FormLogin.aspx");
                    
                
                }
            }
        }

    }
}
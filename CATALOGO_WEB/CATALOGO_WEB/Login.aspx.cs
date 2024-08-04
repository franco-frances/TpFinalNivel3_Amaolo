using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CATALOGO_WEB
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUser.Attributes["placeholder"] = "Usuario";
            txtPass.Attributes["placeholder"] = "Contraseña";

            
                
              imgAvatar.ImageUrl = "~/img/user-login-icon-14.png";

            



        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            FavoritoNegocio favnegocio = new FavoritoNegocio();
            List<Articulo> lista = new List<Articulo>();
            try
            {


                usuario.Email = txtUser.Text;
                usuario.Pass = txtPass.Text;
                if (negocio.loguear(usuario))
                {
                    //Tengo una session con el usuario y una lista de articulos favoritos de ese usuario
                    Session.Add("Usuario", usuario);
                    lista=favnegocio.ListarFavoritos(((Usuario)Session["Usuario"]).Id);
                    Session.Add("Favoritos", lista);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

    }
}
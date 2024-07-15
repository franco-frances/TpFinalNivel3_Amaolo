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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();


                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;
                usuario.Id = usuarioNegocio.insertarNuevo(usuario);
                Session.Add("Usuario", usuario);


                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }


        }
    }
}
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
            txtEmail.Attributes["placeholder"] = "E-mail";
            txtPassword.Attributes["placeholder"] = "Password";
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

            try
            {
                customValidator();


                Page.Validate();
                if (!Page.IsValid)
                    return;

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
                Response.Redirect("Error.aspx");
            }

        }
        protected void customValidator()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                requiredValidator.Visible = true;
                reValidator.Visible = false;
            }
            else
            {
                requiredValidator.Visible = false;
                reValidator.Visible = true;
            }


        }
    }
}
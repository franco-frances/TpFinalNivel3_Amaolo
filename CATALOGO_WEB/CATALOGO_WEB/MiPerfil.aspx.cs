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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["Usuario"]))
                    {
                        Usuario user = (Usuario)Session["Usuario"];
                        txtEmail.Text = user.Email;
                        //txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/img/" + user.ImagenPerfil + "?t=" + DateTime.Now.Ticks.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["Usuario"];
                //Escribir img
                //obtiene ruta fisica de la imagen

                if (txtImagen.PostedFile.FileName != "")//si no se selecciona una imagen no se vuelve a guardar
                {
                    string ruta = Server.MapPath("./img/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";

                }


                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                //guarda datos de perfil
                negocio.actualizar(usuario);

                //linea para acceder a un control de otra ventana(imagenAvatar- MasterPage)
                //leer img
                Image imagenAvatar = (Image)Master.FindControl("imgAvatar");
                imagenAvatar.ImageUrl = "~/img/" + usuario.ImagenPerfil + "?t=" + DateTime.Now.Ticks.ToString();
                imgNuevoPerfil.ImageUrl = "~/img/" + usuario.ImagenPerfil + "?t=" + DateTime.Now.Ticks.ToString();



            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

    }
}
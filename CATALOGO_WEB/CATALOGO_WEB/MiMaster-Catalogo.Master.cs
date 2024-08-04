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
    public partial class MiMaster_Catalogo : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //VALIDA SI EL USUARIO TIENE PERMISO PARA ENTRAR EN LAS SIGUIENTES PAGINAS
                if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
                    if (!(Seguridad.sesionActiva(Session["Usuario"])))
                        Response.Redirect("Login.aspx",false);



                //VALIDA SI LA SESSION  CARGA EL AVATAR O CARGA LA IMAGEN DE VACIO
                if (Seguridad.sesionActiva(Session["Usuario"]) && !(((Usuario)Session["Usuario"]).ImagenPerfil == null))
                {
                    imgAvatar.ImageUrl = "~/img/" + ((Usuario)Session["Usuario"]).ImagenPerfil + "?t=" + DateTime.Now.Ticks.ToString(); ;
                }
                else
                {
                    imgAvatar.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrRD2l0XfDG_4S7e4pSAsGL-ruHuEYlVTZDx-Y_TVLfg&s";

                }

                if (Seguridad.sesionActiva(Session["Usuario"]) == true)
                {
                    lblUser.Text = "Bienvenido " + ((Usuario)Session["Usuario"]).Email;
                    lblUser.ForeColor = System.Drawing.Color.White;

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }


    }
}
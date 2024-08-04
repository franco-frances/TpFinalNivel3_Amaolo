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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> lista { get; set; } = new List<Articulo>();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    FavoritoNegocio negocio = new FavoritoNegocio();

                    //validacion para que no me salte error cuando ingreso a la pagina de favoritos sin usuario
                    int? idUser = null;
                    Usuario usuario = (Usuario)Session["Usuario"];
                    if (usuario != null)
                    {
                        idUser = usuario.Id;
                        lista = negocio.ListarFavoritos(idUser);
                        Repetidor.DataSource = lista;
                        Repetidor.DataBind();
                    }



                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
            

            

        }
        
        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            Favorito favorito = new Favorito();
            FavoritoNegocio negocio = new FavoritoNegocio();
            
            
            favorito.IdArticulo = int.Parse(((Button)sender).CommandArgument.ToString());
            favorito.IdUsuario = ((Usuario)Session["Usuario"]).Id;

            negocio.eliminarFavorito(favorito);
           // Como acceder a botones del front que estan metidos dentro de un Repeater
            Button btnEliminar = (Button)sender;

            RepeaterItem item = (RepeaterItem)btnEliminar.NamingContainer;

            Label lblEliminado = (Label)item.FindControl("lblEliminado");

            lblEliminado.Visible = true;
            btnEliminar.Visible = false;

           
        }
    }
}
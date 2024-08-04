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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> lista { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    FavoritoNegocio favortio = new FavoritoNegocio();

                    if (Seguridad.sesionActiva(Session["Usuario"]))
                    {


                        int idUsuario = ((Usuario)Session["Usuario"]).Id;
                        lista = negocio.Listar();
                        favortio.verificarFavoritos(lista, idUsuario);


                        Repetidor.DataSource = lista;
                        Repetidor.DataBind();
                        return;


                    }





                    lista = negocio.Listar();

                    if (!IsPostBack)
                    {
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

        protected void btnFavorito_Click(object sender, EventArgs e)
        {

            try
            {
                //si no hay usuario no se puede agregar a favoritos
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx",false);
                    return;
                }


                Favorito favorito = new Favorito();
                FavoritoNegocio negocio = new FavoritoNegocio();
                ArticuloNegocio articulo = new ArticuloNegocio();

                lista = articulo.Listar();

                favorito.IdArticulo = int.Parse(((Button)sender).CommandArgument.ToString());
                favorito.IdUsuario = ((Usuario)Session["Usuario"]).Id;


                negocio.agregar(favorito);
                negocio.verificarFavoritos(lista, favorito.IdUsuario);

                Repetidor.DataSource = lista;
                Repetidor.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
            
            





        }

    }
}
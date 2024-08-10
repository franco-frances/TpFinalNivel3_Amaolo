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

                    //si session activa imprimo la lista con los favoritos del usuario
                    if (Seguridad.sesionActiva(Session["Usuario"]))
                    {


                        int idUsuario = ((Usuario)Session["Usuario"]).Id;
                        lista = negocio.Listar();
                        Session.Add("listaArticulos", lista);
                        favortio.verificarFavoritos(lista, idUsuario);


                        Repetidor.DataSource = lista;
                        Repetidor.DataBind();
                        return;


                    }



                    //si session inactiva imprimo articulos sin favoritos

                    lista = negocio.Listar();
                    Session.Add("listaArticulos", lista);

                    if (!IsPostBack)
                    {
                        //Para que empiece cargado el ddl de campo
                        ddlCriterio.Items.Add("Empieza con");
                        ddlCriterio.Items.Add("Termina con");
                        ddlCriterio.Items.Add("Contiene");

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
                //Capturo ID del articulo y usuario  
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

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltrar.Enabled = !chkFiltroAvanzado.Checked;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                    return;


                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.Listar(ddlCampo.SelectedValue.ToString(), ddlCriterio.SelectedValue.ToString(), txtFiltroAvanzado.Text);
                Repetidor.DataSource = lista;
                Repetidor.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            txtFiltroAvanzado.Text = "";
            txtFiltrar.Text = "";
            //Para que empiece cargado el ddl de campo
            if (ddlCampo.SelectedValue != "Precio")
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");

            }
            else
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }

            Repetidor.DataSource = Session["listaArticulos"];
            Repetidor.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedValue != "Precio")
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
                reValidator.Enabled = false;
                txtFiltroAvanzado.Attributes["placeholder"] = "";


            }
            else
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
                reValidator.Enabled = true;
                txtFiltroAvanzado.Attributes["placeholder"] = "Ingrese un precio";


            }
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lista = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
                Repetidor.DataSource = listaFiltrada;
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
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
    public partial class Formulario : System.Web.UI.Page
    {
        public bool confirmarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            confirmarEliminacion = false;

            txtCodigo.Attributes["placeholder"] = "Ingrese código";
            txtNombre.Attributes["placeholder"] = "Ingrese nombre";
            txtPrecio.Attributes["placeholder"] = "Ingrese precio";
            txtDescripción.Attributes["placeholder"] = "Ingrese descripcion";
            txtUrlImagen.Attributes["placeholder"] = "Ingrese URL de imagen";


            try
            {

                if (!IsPostBack)
                {

                    CategoriaNegocio negocio = new CategoriaNegocio();

                    List<Categoria> lista = negocio.listar();

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> listaMarca = marcaNegocio.listar();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                if (Request.QueryString["Id"] != null && !(IsPostBack))
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> lista = negocio.Listar(Request.QueryString["Id"].ToString());
                    Articulo seleccionado = lista[0];

                    // pre cargo lo campos del formulario

                    txtCodigo.Text = seleccionado.CodigoArticulo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripción.Text = seleccionado.Descripcion;
                    txtPrecio.Text = Math.Round(seleccionado.Precio, 0).ToString();
                    txtUrlImagen.Text = seleccionado.UrlImagen;

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();


                    txtUrlImagen_TextChanged(sender, e);


                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }






        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //para que no se aparezcan desplazadas los textos de los validator
                customValidator();


                Page.Validate();
                if (!Page.IsValid)
                    return;

                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.CodigoArticulo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripción.Text;
                nuevo.Precio =decimal.Parse(txtPrecio.Text);
                nuevo.UrlImagen = txtUrlImagen.Text;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                //PREGUNTO SI LLEGO UN ID POR LA URL Y ASI SABER SI EL BOTON ACEPTAR VA A AGREGAR O MODIFICAR
                if (Request.QueryString["Id"] != null)
                {
                    //Tengo que meter el id lpmmmm
                    nuevo.Id = int.Parse(Request.QueryString["Id"]);

                    negocio.modificar(nuevo);

                }
                else

                    negocio.agregar(nuevo);

                Response.Redirect("Lista.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }
        }


        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                if (chkConfirmar.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(Request.QueryString["id"].ToString()));
                    Response.Redirect("Lista.aspx",false);

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }

        protected void customValidator()
        {
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
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
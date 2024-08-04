using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace CATALOGO_WEB
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.esAdmin(Session["Usuario"]))
                {
                    Session.Add("error", "Tenes que ser admin para ingresar a esta página");
                    Response.Redirect("Error.aspx", false);
                }


                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("listaArticulos", negocio.Listar());
                    dgvArticulos.DataSource = Session["listaArticulos"];
                    dgvArticulos.DataBind();

                    //Para que empiece cargado el ddl de campo
                    ddlCriterio.Items.Add("Empieza con");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Contiene");

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
            
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?Id=" + id);
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                    return;


                ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista = negocio.Listar(ddlCampo.SelectedValue.ToString(), ddlCriterio.SelectedValue.ToString(), txtFiltroAvanzado.Text);
            dgvArticulos.DataSource = lista;
            dgvArticulos.DataBind();

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

            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }
    }
}
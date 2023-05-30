using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class Default : Page
    {
        private NegocioArticulo negocio;
        private Articulo articulo;
        public List<Articulo> listaArticulos { get; set; }
        //TODO: LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new NegocioArticulo();
            listaArticulos = negocio.Leer();
            try
            {
                if (!IsPostBack && Session["listaPrincipal"] == null)
                {
                    negocio = new NegocioArticulo();
                    Session.Add("listaPrincipal", negocio.Leer());

                }
                //Carga de filtros
                ddlFiltroMarca.DataSource = negocio.LeerMarcas();
                ddlFiltroMarca.DataBind();
                ddlFiltroMarca.DataValueField= "IdMarca";
                ddlFiltroMarca.DataTextField = "marca";
                ddlFiltroCategoria.DataSource = negocio.LeerCategorias();
                ddlFiltroCategoria.DataBind();
                ddlFiltroCategoria.DataValueField = "IdCategoria";
                ddlFiltroCategoria.DataTextField = "categoria";

                listaArticulos = (List<Articulo>)Session["listaPrincipal"];
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void tbFiltroRapido_TextChanged(object sender, EventArgs e)//REVISAR PARA QUE FUNCIONE
        {
            List<Articulo> listaFiltrada;
            string filtro = tbFiltroRapido.Text;

            //Si tiene datos aplica el filtro, sino muestra todos los artículos
            if (filtro.Length > 2)
            {
                //el constains valida por silabas o letras las palabras sin tener que poner la palabra exacta.
                listaFiltrada = listaArticulos.FindAll(
                    x => (x.nombre.ToUpperInvariant().Contains(filtro.ToUpperInvariant()) ||
                    x.codigo.ToUpperInvariant().Contains(filtro.ToUpperInvariant())));
            }
            else
            {
                listaFiltrada = listaArticulos;
                
            }

            //CargarTabla(listaFiltrada);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // nada por ahora ...
        }
    }
}
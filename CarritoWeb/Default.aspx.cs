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
        public int countArticulos { get; set; } = 0;
        public List<Articulo> listaArticulos { get; set; }
        //TODO: LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            //negocio = new NegocioArticulo();
            //listaArticulos = negocio.Leer();
            try
            {
                if (!IsPostBack)
                {
                    negocio = new NegocioArticulo();
                    cargarFiltros();

                    if (Session["listaPrincipal"] == null)
                        Session.Add("listaPrincipal", negocio.Leer());

                    listaArticulos = (List<Articulo>)Session["listaPrincipal"];
                    cargarListaPrincipal(listaArticulos);
                }
                listaArticulos = (List<Articulo>)Session["listaPrincipal"];

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        //TODO: FILTRO RAPIDO EVENTO
        protected void tbFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = tbFiltroRapido.Text;

            try
            {
                //Si tiene datos aplica el filtro, sino muestra todos los artículos
                if (filtro.Length > 2)
                {
                    //el constains valida por silabas o letras las palabras sin tener que poner la palabra exacta.
                    listaFiltrada = listaArticulos.FindAll(
                        x => (x.nombre.ToUpperInvariant().Contains(filtro.ToUpperInvariant()) ||
                        x.codigo.ToUpperInvariant().Contains(filtro.ToUpperInvariant())));
                    listaArticulos = listaFiltrada;
                }
                cargarListaPrincipal(listaArticulos);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        //TODO: BOTON AGREGAR ARTICULOS
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Articulo> lsPrincipal;
            List<Articulo> lsTemporal;
            var btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);
            try
            {
                lsPrincipal = (List<Articulo>)Session["listaPrincipal"];
                if (Session["selected"] == null)
                {
                    lsTemporal = lsPrincipal.FindAll(itm => itm.id == id);
                    Session.Add("selected", lsTemporal);
                    Session.Add("countSelected", ++countArticulos);
                }
                else
                {
                    countArticulos = (int)Session["countSelected"];
                    Session["countSelected"] = ++countArticulos;
                    lsTemporal = (List<Articulo>)Session["selected"];
                    lsTemporal.AddRange(lsPrincipal.FindAll(itm => itm.id == id));
                }
                
                cargarListaPrincipal(listaArticulos);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //METODOS:
        //TODO: Cargar Filtros
        private void cargarFiltros()
        {
            ddlFiltroMarca.DataSource = negocio.LeerMarcas();
            ddlFiltroMarca.DataBind();
            ddlFiltroMarca.DataValueField = "IdMarca";
            ddlFiltroMarca.DataTextField = "marca";
            ddlFiltroCategoria.DataSource = negocio.LeerCategorias();
            ddlFiltroCategoria.DataBind();
            ddlFiltroCategoria.DataValueField = "IdCategoria";
            ddlFiltroCategoria.DataTextField = "categoria";
        }
        //TODO: Cargar Lista Principal
        private void cargarListaPrincipal(List<Articulo> list)
        {
            repListaPrincipal.DataSource = list;
            repListaPrincipal.DataBind();
        }

    }//fin
}
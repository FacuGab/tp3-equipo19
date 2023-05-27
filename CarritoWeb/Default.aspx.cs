using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb.Vistas
{
    public partial class Default : System.Web.UI.Page
    {
        private NegocioArticulo negocio;
        private Articulo articulo;
        private List<Articulo> listaArticulos;
        //TODO: LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                negocio = new NegocioArticulo();
                listaArticulos = negocio.Leer();

            }
            dgvListaPrincipal.DataSource = listaArticulos;
            dgvListaPrincipal.DataBind();
        }
    }//fin
}
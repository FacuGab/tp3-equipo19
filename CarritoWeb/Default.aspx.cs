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
        } 
    }
}
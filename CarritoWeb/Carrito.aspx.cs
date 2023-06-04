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
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            //NegocioArticulo negocio = new NegocioArticulo();            
            //List<Articulo> list = negocio.ListarSP();
            //Articulo art = list[0];
            //art.imagenes = new List<string> { "https://assets.pokemon.com/assets/cms2/img/pokedex/full/340.png", "https://assets.pokemon.com/assets/cms2/img/pokedex/full/341.png", "https://assets.pokemon.com/assets/cms2/img/pokedex/full/342.png" };
            //lista = list;

            //repEjemplo.DataSource = list;
            //repEjemplo.DataBind();
        }
    }
}
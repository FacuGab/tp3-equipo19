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
            try
            {
                if (!IsPostBack && Session["listaPrincipal"] == null)
                {
                    negocio = new NegocioArticulo();
                    Session.Add("listaPrincipal", negocio.Leer());
                }
                listaArticulos = (List<Articulo>)Session["listaPrincipal"];
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // nada por ahora ...
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CarritoComprasLopta
{
    public partial class About : Page
    {
        private NegocioArticulo negocio;
        private List<Articulo> listaArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Grilla articulos";
            try
            {
                if (!IsPostBack && Session["listaPrincipal"] == null)
                {
                    negocio = new NegocioArticulo();
                    Session.Add("listaPrincipal", negocio.Leer());
                }
                listaArticulos = (List<Articulo>)Session["listaPrincipal"];
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }
    }
}
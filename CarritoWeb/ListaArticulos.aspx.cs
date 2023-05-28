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
        private Articulo articulo;
        private List<Articulo> listaArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Grilla articulos";
            try
            {
                if (!IsPostBack)
                {
                    negocio = new NegocioArticulo();
                    listaArticulos = negocio.Leer();
                    // hay que meter la lista en session para evitar perder la info y poder manejar la lista (hacer mas adelante)
                }
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }
        // SOLO DE EJEMPLO PARA PROBAR EL SP (sacar mas adelante)
        protected void btnListarSP_Click(object sender, EventArgs e)
        {
            try
            {
                negocio = new NegocioArticulo();
                listaArticulos = negocio.ListarSP();
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
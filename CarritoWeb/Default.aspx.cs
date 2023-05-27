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
            try
            {
                if(!IsPostBack)
                {
                    negocio = new NegocioArticulo();
                    listaArticulos = negocio.Leer();
                    // hay que meter la lista en session para evitar perder la info y poder manejar la lista (hacer mas adelante)
                }
                dgvListaPrincipal.DataSource = listaArticulos;
                dgvListaPrincipal.DataBind();
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
                dgvEjemploSP.DataSource = listaArticulos;
                dgvEjemploSP.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }//fin
}
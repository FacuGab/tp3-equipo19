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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        List<Articulo> lsCarrito;
        List<CarritoItem> lsCarritoItem;
        CarritoItem CarritoItem;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                lsCarrito = new List<Articulo>();
                lsCarritoItem= new List<CarritoItem>();
                lsCarrito = (List<Articulo>)Session["selected"];
                
                foreach (Dominio.Articulo art in lsCarrito)
                {
                    CarritoItem itemExistente = new CarritoItem();
                    // Verificar si el artículo ya existe en el carrito
                    itemExistente = lsCarritoItem.Find(item => item.Id == art.id);

                    if (itemExistente != null)
                    {
                        // El artículo ya existe, aumentar su cantidad
                        CarritoItem.Cantidad++;
                    }
                    else
                    {
                        CarritoItem = new CarritoItem();
                        // El artículo no existe, agregarlo al carrito
                        CarritoItem.Id = art.id;
                        CarritoItem.Nombre = art.nombre;
                        CarritoItem.Precio = art.precio;
                        CarritoItem.Cantidad = 1;
                    }
                    lsCarritoItem.Add(CarritoItem);
                }
            //    dgvCarrito.DataSource = Session["selected"];
            //    dgvCarrito.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}
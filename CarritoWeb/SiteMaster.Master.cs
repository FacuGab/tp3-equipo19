using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
                if(!IsPostBack)
                {
                    
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        //METODOS
        
        //private void cargarListaCarrito(List<Articulo> ls) 
        //{
        //    // SACAR, no tiene mucho sentido mostrar una lista que no se va a usar, ( se va a mostrar CarritoItem no Session[selected] )
        //    if (Session["selected"] != null)
        //    {
        //        ls = (List<Articulo>)Session["selected"];
        //        dgvCarrito.DataSource = ls;
        //        dgvCarrito.DataBind();
        //    }
        //}

        ////TODO: crear lista CarritoItem
        ////private void cargarListaCarritoItem(List<Articulo> lsSelected)
        ////{
        ////    if (Session["carritoItem"] != null && lsSelected != null)
        ////    {
        ////        List<int> idArticulos = lsSelected.Select(x => x.id).ToList();
        ////        lsCarritoItem = (List<CarritoItem>)Session["carritoItem"];
        ////        List<Articulo> lsSinRep  = lsSelected.Distinct().ToList();

        ////        if(lsCarritoItem.Count == 0) 
        ////        {
        ////            lsSinRep.ForEach( x => { lsCarritoItem.Add(new CarritoItem(x, 1) ); });
        ////        }
        ////        else
        ////        {
        ////            int count = 0;
        ////            foreach (Articulo art in lsSelected)
        ////            {
        ////                var artItm = lsCarritoItem.Find(itm => itm.Id == art.id);
        ////                if (artItm != null && art.id == artItm.Id)
        ////                {
        ////                    count++;
        ////                }
        ////            }
        ////        }

        ////    }
        ////}
    }
}
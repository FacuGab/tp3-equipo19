using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> lista;
        public List<CarritoItem> itemList;
        public Dictionary<int,int> items_x_articulo;
        public int countItemCarrito = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                var ls = (List<Articulo>)Session["selected"];
                mostrarListaCarritoItem( cargarListaCarritoItem(ls) );
            }
        }

        //TODO: Cargar Lista de Carrito
        private List<CarritoItem> cargarListaCarritoItem(List<Articulo> lsSelected)
        {
            itemList = (List<CarritoItem>)Session["carritoItem"];
            if (lsSelected == null) return null;

            if (itemList != null && lsSelected.Count > 0)
            {
                //Creamos Dic cantidad x Item, <key, value>, donde el key es el id de art y el value la cantidad del art
                items_x_articulo = new Dictionary<int, int>();

                //Calculamos cuantas unidades x articulo tenemos
                foreach (Articulo art in lsSelected)
                {
                    if (items_x_articulo.ContainsKey(art.id))
                        items_x_articulo[art.id]++;
                    else
                        items_x_articulo.Add(art.id, 1);
                }

                //Calculamos la cantidad total de articulos en carrito
                foreach (var item in items_x_articulo)
                {
                    countItemCarrito += item.Value;
                }
                Session["countCarrito"] = countItemCarrito;

                //Si lista de items carrito no tiene nada:
                if (itemList.Count == 0)
                {
                    //Cargamos lista items carrito
                    foreach (var item in items_x_articulo)
                    {
                        var art = lsSelected.Find(x => x.id == item.Key); // buscamos art x id, el id es unico por cada key
                        itemList.Add(new CarritoItem(art, item.Value)); // creamos el item del carrito con su art y su cantidad
                    }
                }
                else //Si lista tiene articulos previos:
                {
                    //Acumulamos la cantidad de unidades x articulos
                    foreach (CarritoItem item in itemList)
                    {
                        if (items_x_articulo.ContainsKey(item.Id))
                            item.Cantidad += items_x_articulo[item.Id];
                    }
                }
            }
            return itemList;
        }
        //TODO: Mostrar Lista de Carrito
        private void mostrarListaCarritoItem(List<CarritoItem> ls)
        {
            //( se va a mostrar CarritoItem no Session[selected] )
            if (ls != null)
            {
                dgvCarrito.DataSource = ls;
                dgvCarrito.DataBind();
                //lblCantArtCarrito.Text = countItemCarrito.ToString();
            }
        }


        //public void cargarcarrito()
        //{
        //    GridView1.DataSource = Session["pedido"];
        //    GridView1.DataBind();
        //    Button1_Click(Button1, null);
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    int i;
        //    decimal total = 0, prec, subtotal = 0, igv;
        //    string cod, url,marca,descrip;
        //    int cant;

        //    var items = (DataTable)Session["pedido"];
        //    for (i = 0; i < GridView1.Rows.Count; i++)
        //    {
        //        cod = (GridView1.Rows[i].Cells[1].Text);
        //        url = (GridView1.Rows[i].Cells[2].Text);
        //        marca = (GridView1.Rows[i].Cells[3].Text);
        //        descrip = (GridView1.Rows[i].Cells[4].Text);
        //        prec = System.Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);
        //        cant = System.Convert.ToInt16(((TextBox)this.GridView1.Rows[i].Cells[4].FindControl("TextBox1")).Text);
        //        decimal prec1 = System.Convert.ToDecimal(prec);
        //        subtotal = cant * prec1;
        //        GridView1.Rows[i].Cells[5].Text = subtotal.ToString();
        //        foreach (DataRow dr in items.Rows)
        //        {
        //            if (dr["codproducto"].ToString() == cod.ToString())
        //            {
        //                dr["canproducto"] = cant;
        //                dr["subtotal"] = subtotal;
        //            }
        //        }
        //        total = total + subtotal;
        //    }

        //    subtotal = total;
        //    lblSubTotal.Text = subtotal.ToString("0.00");
        //    lblTotal.Text = total.ToString("0.00");
        //}

        //public decimal TotalCarrito(DataTable dt)
        //{
        //    decimal tot = 0;
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        tot += Convert.ToDecimal(item[4]);
        //    }
        //    return 0;
        //}
        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Borrar")
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        DataTable ocar = new DataTable();
        //        ocar = (DataTable)Session["pedido"];
        //        ocar.Rows[index].Delete();
        //        lblTotal.Text = TotalCarrito(ocar).ToString();
        //        GridView1.DataSource = ocar;
        //        GridView1.DataBind();
        //        cargarcarrito();
        //    }

        //}
        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.RowIndex);
        //    string id = GridView1.DataKeys[index].Value.ToString();

        //    DataTable dt1 = Session["pedido"] as DataTable;

        //    DataRow[] rows = dt1.Select(string.Format("id = {0}", id));
        //    if (rows.Count() > 0)
        //    {
        //        dt1.Rows.Remove(rows[0]);
        //    }

        //    Session["pedido"] = dt1;

        //    GridView1.DataSource = dt1;
        //    GridView1.DataBind();
        //}
    }
}
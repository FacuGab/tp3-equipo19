using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> lista;
        public List<CarritoItem> itemList;
        public Dictionary<int,int> items_x_articulo;
        public Dictionary<int,decimal> totalParcial;
        public int countItemCarrito = 0;
        private decimal total;
        public string totalFinal
        {
            get { return string.Format("{000:0.00}", total); }
        }

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["countCarrito"] == null)
                    Session.Add("countCarrito", 0);
                else
                    countItemCarrito = (int)Session["countCarrito"];

                if (Session["totalCarrito"] == null)
                    Session.Add("totalCarrito", total);
                else
                    total = Convert.ToDecimal(Session["totalCarrito"]);

                var ls = (List<Articulo>)Session["selected"];
                mostrarListaCarritoItem( cargarListaCarritoItem(ls) );
            }
        }

        //TODO: Cargar Lista de Carrito (calcula tota, total unidades y carga lista)
        private List<CarritoItem> cargarListaCarritoItem(List<Articulo> lsSelected)
        {
            if (lsSelected == null) 
                return null;
            itemList = (List<CarritoItem>)Session["carritoItem"];

            if (itemList != null && lsSelected.Count > 0)
            {
                //Parcial para calcular el total
                totalParcial = new Dictionary<int, decimal>();

                //Creamos Dic cantidad x Item, <key, value>, donde el key es el id de art y el value la cantidad del art
                items_x_articulo = new Dictionary<int, int>();

                //Calculamos cuantas unidades x articulo tenemos y acumulamos el total en costo
                foreach (Articulo art in lsSelected)
                {
                    if (items_x_articulo.ContainsKey(art.id))
                    {
                        items_x_articulo[art.id]++;
                        totalParcial[art.id] += art.precio;
                    }
                    else
                    {
                        items_x_articulo.Add(art.id, 1);
                        totalParcial.Add(art.id, art.precio);
                    }
                }

                //Calculamos la cantidad total de articulos en carrito
                foreach (var item in items_x_articulo)
                {
                    countItemCarrito += item.Value;
                }
                Session["countCarrito"] = countItemCarrito;

                //Calculamos el total en carrito
                foreach (var item in totalParcial)
                {
                    total += item.Value;
                }
                Session["totalCarrito"] = total;

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
                    //(es medio una flasheada el bucle, no se si es buena practica o no utilizarlo asi, quizas un for para utilizar i ...)
                    foreach (var item in items_x_articulo)
                    {
                        if (itemList.Exists(art => art.Id == item.Key))
                        {
                            itemList[ itemList.FindIndex(art => art.Id == item.Key) ].Cantidad += item.Value;
                        }
                        else
                        {
                            var newArt = lsSelected.Find(art => art.id == item.Key);
                            itemList.Add(new CarritoItem(newArt, 1));
                        }
                    }
                }
            }
            lsSelected.Clear();
            return itemList;
        }

        //TODO: Mostrar Lista de Carrito
        private void mostrarListaCarritoItem(List<CarritoItem> ls)
        {
            //( se va a mostrar CarritoItem )
            if (ls != null)
            {
                dgvCarrito.DataSource = ls;
                dgvCarrito.DataBind();
            }
        }
        
        //TODO: Boton ELMINAR
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["carritoItem"] != null)
                {
                    Session.Remove("carritoItem");
                    Session.Add("carritoItem", new List<CarritoItem>());
                }
                if (Session["countCarrito"] != null)
                {
                    Session.Remove("countCarrito");
                    Session.Add("countCarrito", 0);
                }
                if (Session["totalCarrito"] != null)
                {
                    Session.Remove("totalCarrito");
                    Session.Add("totalCarrito", 0);
                }
                Response.Redirect("Carrito.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //TODO: Boton Eliminar Item de lista Carrito
        protected void ibtEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                if (Session["carritoItem"] == null)
                    return;

                //Cargamos variables y el id del item a quitar
                itemList = (List<CarritoItem>)Session["carritoItem"];
                var btn = (ImageButton)sender;
                int idItem = int.Parse(btn.CommandArgument);

                //Buscamos el item en lista CarritoItem y lo quitamos
                //restamos cantidad y total del carrito
                CarritoItem item = itemList.Find(itm => itm.Id == idItem);
                if(item != null)
                {
                    int countCarrito = (int)Session["countCarrito"];
                    decimal totalParcial = (decimal)Session["totalCarrito"];

                    countCarrito -= item.Cantidad;
                    totalParcial -= ( Convert.ToDecimal(item.Cantidad) * item.Precio );

                    //Re-asignamos nuevos valores
                    Session["countCarrito"] = countCarrito;
                    Session["totalCarrito"] = totalParcial;
                    total = totalParcial;
                    countItemCarrito = countCarrito;
                    itemList.Remove(item);
                }
                //Volvemos a cargar la lista en el dgv
                mostrarListaCarritoItem(itemList);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Link ir Detalle
        protected void linkDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((LinkButton)sender).CommandArgument);
                Response.Redirect($"Detalle.aspx?id={id}", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // --------------------------------------------------------------------------------------------------------------------------------
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
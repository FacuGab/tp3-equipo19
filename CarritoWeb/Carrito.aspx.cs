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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cargarcarrito();
                //Ultimo();
                lblFecha.Text = DateTime.Now.Date.ToString().Substring(0, 10);
            }
        }

        private void Ultimo()
        {
            //VentasCN cnper = new VentasCN();
            //List<Ventas> per = cnper.UltimoEmp();
            //foreach (Ventas ma in per)
            //{
            //    int codigo = 0;
            //    codigo = Convert.ToInt32(ma.Codigo);
            //    codigo = codigo + 1;
            //    if (codigo < 10)
            //    {
            //        ma.Codigo = "000" + codigo.ToString();
            //    }
            //    if (codigo < 100 && codigo > 9)
            //    {
            //        ma.Codigo = "00" + codigo.ToString();
            //    }
            //    if (codigo < 1000 && codigo > 99)
            //    {
            //        ma.Codigo = "0" + codigo.ToString();
            //    }
            //    txtCodigo.Text = ma.Codigo;
            //}
        }

        public void cargarcarrito()
        {
            GridView GV = new GridView();
            GridView1.DataSource = Session["pedido"];
            GridView1.DataBind();
            Button1_Click(Button1, null);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i;
            //double total = 0, prec, subtotal = 0, igv;
            string cod, url,marca,descrip;
            //int cant;

            var items = (DataTable)Session["pedido"];
            for (i = 0; i < GridView1.Rows.Count; i++)
            {
                cod = (GridView1.Rows[i].Cells[1].Text);
                url = (GridView1.Rows[i].Cells[2].Text);
                marca = (GridView1.Rows[i].Cells[3].Text);
                descrip = (GridView1.Rows[i].Cells[4].Text);
                //prec = System.Convert.ToDouble(GridView1.Rows[i].Cells[3].Text);
                //cant = System.Convert.ToInt16(((TextBox)this.GridView1.Rows[i].Cells[4].FindControl("TextBox1")).Text);
                //double prec1 = System.Convert.ToDouble(prec);
                //subtotal = cant * prec1;
                //GridView1.Rows[i].Cells[5].Text = subtotal.ToString();
                //foreach (DataRow dr in items.Rows)
                //{
                //    if (dr["codproducto"].ToString() == cod.ToString())
                //    {
                //        dr["canproducto"] = cant;
                //        dr["subtotal"] = subtotal;
                //    }
                //}
                //total = total + subtotal;
            }

            //igv = total * 0.18;
            //subtotal = total - igv;

            //lblIGV.Text = igv.ToString("0.00");
            //lblSubTotal.Text = subtotal.ToString("0.00");
            //lblTotal.Text = total.ToString("0.00");
        }

        public double TotalCarrito(DataTable dt)
        {
            //double tot = 0;
            //foreach (DataRow item in dt.Rows)
            //{
            //    tot += Convert.ToDouble(item[4]);
            //}
            return 0;
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable ocar = new DataTable();
                ocar = (DataTable)Session["pedido"];
                ocar.Rows[index].Delete();
                lblTotal.Text = TotalCarrito(ocar).ToString();
                GridView1.DataSource = ocar;
                GridView1.DataBind();
                cargarcarrito();
            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            string id = GridView1.DataKeys[index].Value.ToString();

            DataTable dt1 = Session["pedido"] as DataTable;

            DataRow[] rows = dt1.Select(string.Format("id = {0}", id));
            if (rows.Count() > 0)
            {
                dt1.Rows.Remove(rows[0]);
            }

            Session["pedido"] = dt1;

            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
    }
}
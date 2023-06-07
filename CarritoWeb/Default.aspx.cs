using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace CarritoWeb
{
    public partial class Default : Page
    {
        private NegocioArticulo negocio;
        public Dictionary<int, int> cantidadXitem;
        DataTable dtb;

        public int countArticulos { get; set; } = 0;
        public int countItemCarrito { get; set; } = 0;
        public List<Articulo> listaArticulos { get; set; }
        public List<Articulo> lsCarrito { get; set; }

        //TODO: LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //SI NO ES Postback
                if (!IsPostBack)
                {
                    negocio = new NegocioArticulo();
                    cargarFiltros();

                    //Traemos a obj de session una lista con todos los articulos en bd
                    if (Session["listaPrincipal"] == null)
                        Session.Add("listaPrincipal", negocio.Leer());

                    //Iniciamos a 0 el contador de articulos agregadoss
                    if (Session["countSelected"] != null)
                        Session["countSelected"] = 0;

                    //Iniciamos la lista del Carrito
                    if (Session["carritoItem"] == null)
                        Session.Add("carritoItem", new List<CarritoItem>());

                    //Iniciamos la cantidad total de articulos en carrito
                    if (Session["countCarrito"] == null)
                        Session.Add("countCarrito", 0);

                    //Apuntamos a la lista principal de articulos en bd y cargamos datos en rep
                    listaArticulos = (List<Articulo>)Session["listaPrincipal"];
                    cargarListaPrincipal(listaArticulos);

                    //PRUEBA
                    CargarDetalle();
                }

                //SI ES Postback, apuntamos a lista principal de art en bd
                listaArticulos = (List<Articulo>)Session["listaPrincipal"];
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //EVENTOS:
        //TODO: BOTON FILTRO
        protected void btnAgregarFiltro_Click(object sender, EventArgs e)
        {
            listaArticulos = (List<Articulo>)Session["listaPrincipal"];
            List<Articulo> listaFiltrada = new List<Articulo>();

            try
            {
                foreach (var articulo in listaArticulos)
                {
                    if (ddlCriterio.Text == "Solo categoria")
                    {
                        // valida que el contenido del combo categoria sea igual o similar
                        listaFiltrada.AddRange(listaArticulos.FindAll(x => x.categoria.categoria.Contains(ddlFiltroCategoria.Text)));
                    }
                    else if (ddlCriterio.Text == "Solo marca")
                    {
                        // valida que el contenido del combo marca sea igual o similar
                        listaFiltrada.AddRange(listaArticulos.FindAll(x => x.marca.marca.Contains(ddlFiltroMarca.Text)));
                    }
                    else
                    {
                        // valida que el contenido de los dos combos sean iguales
                        listaFiltrada.AddRange(listaArticulos.FindAll(x =>
                            x.categoria.categoria.Contains(ddlFiltroCategoria.Text)
                            && x.marca.marca.Contains(ddlFiltroMarca.Text)));
                    }
                }
                // Eliminar duplicados en la lista filtrada
                listaFiltrada = listaFiltrada.Distinct().ToList();
                cargarListaPrincipal(listaFiltrada);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //TODO: FILTRO RAPIDO EVENTO
        protected void tbFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = tbFiltroRapido.Text;

            try
            {
                //Verificamos que no sea un string no valido
                if (string.IsNullOrEmpty(filtro))
                    return;
                if (filtro.All(s => !char.IsDigit(s)) == false)
                    return;

                //Si tiene datos aplica el filtro, sino muestra todos los artículos
                if (filtro.Length > 2)
                {
                    //el constains valida por silabas o letras las palabras sin tener que poner la palabra exacta.
                    listaFiltrada = listaArticulos.FindAll(
                        x => (x.nombre.ToUpperInvariant().Contains(filtro.ToUpperInvariant()) ||
                        x.codigo.ToUpperInvariant().Contains(filtro.ToUpperInvariant())));
                    listaArticulos = listaFiltrada;
                }
                cargarListaPrincipal(listaArticulos);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //TODO: BOTON AGREGAR ARTICULOS
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Articulo> lsPrincipal;
            List<Articulo> lsTemporal;
            var btn = (Button)sender;
            int idArticulo = int.Parse(btn.CommandArgument);
            try
            {
                //Apuntamos a lista principal
                lsPrincipal = (List<Articulo>)Session["listaPrincipal"];

                //si es la primera vez, osea nulo, creamos objetos
                if (Session["selected"] == null)
                {
                    //buscamos todos los art que tengan el mismo id y creamos selected, y conteo
                    lsTemporal = lsPrincipal.FindAll(itm => itm.id == idArticulo);
                    Session.Add("selected", lsTemporal);
                    Session.Add("countSelected", ++countArticulos);
                }
                else
                {//si no es la primera, contamos y agregamos a la lista selected todo art seleccionado por el usuario
                    countArticulos = (int)Session["countSelected"];
                    Session["countSelected"] = ++countArticulos;
                    lsTemporal = (List<Articulo>)Session["selected"];
                    lsTemporal.AddRange(lsPrincipal.FindAll(itm => itm.id == idArticulo));
                }
                cargarListaPrincipal(listaArticulos);
                //lblAgregado.Text = "Articulo Agregado";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //TODO: BOTON BORRAR FILTROS
        protected void btnEliminarFiltro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        //METODOS:
        //TODO Cargar filtros
        private void cargarFiltros()
        {
            ddlFiltroMarca.DataSource = negocio.LeerMarcas();
            ddlFiltroMarca.DataBind();
            ddlFiltroMarca.DataValueField = "IdMarca";
            ddlFiltroMarca.DataTextField = "marca";
            ddlFiltroCategoria.DataSource = negocio.LeerCategorias();
            ddlFiltroCategoria.DataBind();
            ddlFiltroCategoria.DataValueField = "IdCategoria";
            ddlFiltroCategoria.DataTextField = "categoria";
            ddlCriterio.Items.Add("Solo categoría");
            ddlCriterio.Items.Add("Solo marca");
            ddlCriterio.Items.Add("Ambos");
            ddlCriterio.SelectedIndex = 2;
        }

        //TODO: Cargar Lista Principal
        private void cargarListaPrincipal(List<Articulo> list)
        {
            //repListaPrincipal.DataSource = list;
            //repListaPrincipal.DataBind();
            DataList1.DataSource = list;
            DataList1.DataBind();
        }

        ///TODO: DATA TABLE (tiene codigo sin uso, ver)
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string nom, url, marca, descrip;
            decimal precio = 0;
            if (e.CommandName == "Seleccionar")
            {
                DataList1.SelectedIndex = e.Item.ItemIndex;

                nom = ((Label)this.DataList1.SelectedItem.FindControl("nomProdLabel")).Text;
                url = ((Label)this.DataList1.SelectedItem.FindControl("urlLabel")).Text;
                marca = ((Label)this.DataList1.SelectedItem.FindControl("marcaProdLabel")).Text;
                descrip = ((Label)this.DataList1.SelectedItem.FindControl("descripProdLabel")).Text;
                precio = Convert.ToDecimal(((Label)this.DataList1.SelectedItem.FindControl("precioProdLabel")).Text);
                //AgregarItem(nom, url, marca, descrip, precio);
                //lblAgregado.Text = "Producto Agregado: " + nom + " " + descrip;
            }
        }
        public void CargarDetalle()
        {
            dtb = new DataTable("Carrito");
            dtb.Columns.Add("nombre", System.Type.GetType("System.String"));
            dtb.Columns.Add("urlImagen", System.Type.GetType("System.String"));
            dtb.Columns.Add("marca", System.Type.GetType("System.String"));
            dtb.Columns.Add("descripicion", System.Type.GetType("System.String"));
            dtb.Columns.Add("precio", System.Type.GetType("System.Int32"));

            Session["pedido"] = dtb;
        }
        //public void AgregarItem(string nom, string url, string marca, string descip, decimal precio)
        //{
        //    decimal total;
        //    int cantidad = 1;
        //    total = precio * cantidad;
        //    carrito = (DataTable)Session["pedido"];
        //    DataRow fila = carrito.NewRow();
        //    fila[0] = nom;
        //    fila[1] = url;
        //    fila[2] = marca;
        //    fila[3] = descip;
        //    fila[4] = total;
        //    carrito.Rows.Add(fila);
        //    Session["pedido"] = carrito; // esto esta mal mepa, estas referenciando una referencia ¿?
        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            //trash, sacar
        }
    }//fin
}
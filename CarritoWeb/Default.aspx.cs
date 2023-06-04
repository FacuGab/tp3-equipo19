﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
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
        private Articulo articulo;
        private List<CarritoItem> itemList;
        private List<CarritoItem> itmAux;
        public Dictionary<int, int> cantidadXitem;
        private CarritoItem carritoItem;
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
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            // hacer ..... 
        }
        //TODO: FILTRO RAPIDO EVENTO
        protected void tbFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = tbFiltroRapido.Text;

            try
            {
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
            int id = int.Parse(btn.CommandArgument);
            try
            {
                lsPrincipal = (List<Articulo>)Session["listaPrincipal"];
                if (Session["selected"] == null)
                {
                    lsTemporal = lsPrincipal.FindAll(itm => itm.id == id);
                    Session.Add("selected", lsTemporal);
                    Session.Add("countSelected", ++countArticulos);
                }
                else
                {
                    countArticulos = (int)Session["countSelected"];
                    Session["countSelected"] = ++countArticulos;
                    lsTemporal = (List<Articulo>)Session["selected"];
                    lsTemporal.AddRange(lsPrincipal.FindAll(itm => itm.id == id));
                }

                cargarListaPrincipal(listaArticulos);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        //TOOD: BOTON ELIMINAR LISTA ITEMS CARRITO
        protected void btnEliminarLsCarrito_Click(object sender, EventArgs e)
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
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        //TODO: BOTON CARGAR CARRITO
        protected void btnCargarCarrito_Click1(object sender, EventArgs e)
        {
            //Apuntamos a la lista de art selecionados por el usuario y cargamos datos en grid(temporal)
            try
            {
                lsCarrito = (List<Articulo>)Session["selected"];
                mostrarListaCarritoItem(cargarListaCarritoItem(lsCarrito));
                lsCarrito.Clear();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //METODOS:
        //TODO: Cargar Filtros
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
        }
        //TODO: Cargar Lista Principal
        private void cargarListaPrincipal(List<Articulo> list)
        {
            repListaPrincipal.DataSource = list;
            repListaPrincipal.DataBind();
        }
        //TODO: Cargar Lista de Carrito
        private List<CarritoItem> cargarListaCarritoItem(List<Articulo> lsSelected)
        {
            itemList = (List<CarritoItem>)Session["carritoItem"];
            if (lsSelected == null) return null;

            if (itemList != null  && lsSelected.Count > 0)
            {
                //Creamos Dic cantidad x Item, <key, value>, donde el key es el id de art y el value la cantidad del art
                cantidadXitem = new Dictionary<int, int>();

                //Calculamos cuantas unidades x articulo tenemos
                foreach (Articulo art in lsSelected)
                {
                    if (cantidadXitem.ContainsKey(art.id))
                        cantidadXitem[art.id]++;
                    else
                        cantidadXitem.Add(art.id, 1);
                }

                //Calculamos la cantidad total de articulos en carrito
                foreach (var item in cantidadXitem) 
                { 
                    countItemCarrito += item.Value; 
                }
                Session["countCarrito"] = countItemCarrito;

                //Si lista de items carrito no tiene nada:
                if (itemList.Count == 0)
                {
                    //Cargamos lista items carrito
                    foreach (var item in cantidadXitem)
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
                        if (cantidadXitem.ContainsKey(item.Id))
                            item.Cantidad += cantidadXitem[item.Id];
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
                lblCantArtCarrito.Text = countItemCarrito.ToString();
            }
        }
    }//fin
}
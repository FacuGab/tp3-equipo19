using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class Detalle : System.Web.UI.Page
    {
        public int Id { get; set; }
        public Articulo articulo { get; set; }
        public List<string> imagenes_x_articulo;

        //Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack == false)
                {
                    //ClientScritManager es un obj para cargar un espacio para guardar scripts de la pagina a utilizar (?¿)
                    ClientScriptManager cs = Page.ClientScript;

                    if (Session["listaPrincipal"] == null)
                    {
                        cs.RegisterClientScriptBlock(this.GetType(), "AlertScript","alert('No hay lista de articulos cargada, vuelve a pagina principal')", true );
                        return;
                    }

                    if (Page.Request.Params["id"] != null)
                    {
                        Id = int.Parse(Request.Params["id"]);
                        if (Session["articuloDetalle"] == null)
                        { 
                            articulo = ((List<Articulo>)Session["listaPrincipal"]).Find(art => art.id == Id);
                            Session.Add("articuloDetalle", articulo);
                        }
                        else
                        {
                            articulo = (Articulo)Session["articuloDetalle"];
                        }

                        cargarImg(Id);
                        Session.Add("articuloImagenes", imagenes_x_articulo);

                    }
                    else
                    {
                        // Registrar un bloque de código JavaScript que muestra un mensaje de alerta
                        cs.RegisterClientScriptBlock(this.GetType(), "AlertScript", "alert('ARTICULO NO CARGADO. Solo puedes ver detalle desde el carrito')", true);
                        articulo = new Articulo()
                        {
                            nombre = "xxx",
                            descripicion = "xxxx xxxxxx xxxxxx xxxxxx",
                            categoria = new Categoria("xxxx"),
                            marca = new Marca("xxxx"),
                            precio = 0
                        };
                    }
                }
                else
                {
                    if (Session["articuloImagenes"] != null)
                        imagenes_x_articulo = (List<string>)Session["articuloImagenes"];
                    if (Session["articuloDetalle"] != null)
                        articulo = (Articulo)Session["articuloDetalle"];
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        //Cargar Imagenes por articulo selecionado
        private void cargarImg(int id)
        {
            NegocioArticulo negocio = new NegocioArticulo();

            imagenes_x_articulo = new List<string>(
                negocio.CargarImgXart(id)
                );
        }
    }//Fin
}
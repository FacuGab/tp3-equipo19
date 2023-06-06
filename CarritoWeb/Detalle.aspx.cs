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
            if(IsPostBack == false)
            {
                //ClientScritManager es un obj para cargar un espacio para guardar scripts de la pagina a utilizar (?¿)
                ClientScriptManager cs = Page.ClientScript;

                if (Page.Request.Params["id"] != null)
                {
                    Id = int.Parse( Request.Params["id"]);
                    articulo = ((List<Articulo>)Session["listaPrincipal"]).Find(art => art.id == Id);
                    cargarImg(Id);
                }
                else
                {
                    // Registrar un bloque de código JavaScript que muestra un mensaje de alerta
                    cs.RegisterClientScriptBlock( this.GetType(), "AlertScript", "alert('ARTICULO NO CARGADO. Solo puedes ver detalle desde el carrito')", true);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarritoItem
    {
        public CarritoItem() { }
        public CarritoItem(Articulo art, int cant) 
        {
            Id = art.id;
            Nombre = art.nombre;
            Precio = art.precio;
            Cantidad = cant;
            urlImagen = art.UrlImagen;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string urlImagen { get; set; }
        public string roundPrecio { get { return string.Format("{000:0.00}", Precio); } }
    }
}

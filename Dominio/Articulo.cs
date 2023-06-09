﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Articulo
    {
        public Articulo() 
        { 
            marca = new Marca();
            categoria = new Categoria();
        }

        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Código")]//TODO: Cambiar nombre del encabezado de la columna
        public string codigo { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripicion{ get; set; }
        [DisplayName("Marca")]
        public Marca marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria categoria { get; set; }
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [DisplayName("Imagenes")]
        public List<string> imagenes { get; set; }
        [DisplayName("URL")] 
        public string UrlImagen { get; set; }

        public string roundPrecio { 
            get { return string.Format("{000:0.00}", precio); } 
        }
    }
}

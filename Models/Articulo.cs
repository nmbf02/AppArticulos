using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArticulos.Models
{
    public class Articulo
    {
        public int id_articulo { get; set; }
        public string? articulo { get; set; }
        public string? codigo_barra { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public string? tipo { get; set; }
        public string? itbis { get; set; }
        public double monto_itbis { get; set; }
        public string? ubicacion { get; set; }
        public double costo { get; set; }
        public double precio { get; set; }
        public string? precios { get; set; }
        public int existencia { get; set; }
        public string? existencia_texto { get; set; }
    }

    public class ArticuloResponse
    {
        public List<Articulo>? articulos { get; set; }
    }
    public class RootObject
    {
        public List<Articulo> articulos { get; set; } = new();
    }
}

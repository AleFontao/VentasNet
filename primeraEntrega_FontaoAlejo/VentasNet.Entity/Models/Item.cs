using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasNet.Entity.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string ImporteProducto { get; set; }
        public bool Estado { get; set; }
        public string Codigo { get; set; }
        public int Cantidad {  get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasNet.Entity.Models
{
    public class Item
    {
        public Producto Producto;
        public int Cantidad {  get; set; }
        public int SubtotalItem { get; set; }
    }
}

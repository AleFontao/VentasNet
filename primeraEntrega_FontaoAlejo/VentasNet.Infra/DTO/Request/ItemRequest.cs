using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;

namespace VentasNet.Infra.DTO.Request
{
    public class ItemRequest
    {
        public ProductoRequest Producto { get; set; }
        public int Cantidad { get; set; }
        public int SubtotalItem { get; set; }
    }
}

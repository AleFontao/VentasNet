using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasNet.Infra.DTO.Request
{
    public class ClienteBusquedaRequest
    {
        public string Cuit { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}

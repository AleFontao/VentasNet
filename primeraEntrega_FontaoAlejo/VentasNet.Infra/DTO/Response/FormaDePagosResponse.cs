using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Common;

namespace VentasNet.Infra.DTO.Response
{
    public class FormaDePagosResponse : Mensaje
    {
        public int Id { get; set; }
        public int IdTipoPago { get; set; }
        public string Entidad { get; set; }
        public int IdFinanciacion { get; set; }
        public string Descripcion { get; set; }
    }
}

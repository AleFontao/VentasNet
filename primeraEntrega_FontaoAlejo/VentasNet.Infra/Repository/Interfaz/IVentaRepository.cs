using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Repository.Interfaz
{
    public interface IVentaRepository
    {
        Response AgregarVenta(List<ItemRequest> entity);
    }
}

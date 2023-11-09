using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VentasNet.Entity.Data;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Repository.Interfaz;

namespace VentasNet.Infra.Repository
{
    public class VentaRepository : IVentaRepository
    {
        private readonly VentasNetContext _context;
        private readonly IMapper _mapper;
        public VentaRepository(VentasNetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Response AgregarVenta(List<ItemRequest> entity)
        {
            Response response = new Response();
            return response;
        }
    }
}

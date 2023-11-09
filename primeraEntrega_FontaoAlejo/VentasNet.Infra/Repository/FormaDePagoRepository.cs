using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Repository.Interfaz;

namespace VentasNet.Infra.Repository
{
    public class FormaDePagoRepository : IFormaDePagoRepository
    {
        private readonly VentasNetContext _context;
        private readonly IMapper _mapper;
        public FormaDePagoRepository(VentasNetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<FormaDePagosResponse> ObtenerTodos()
        {
            var lista = _context.FormaDePagos.ToList();
            List<FormaDePagosResponse> listadoFormasDePago = new List<FormaDePagosResponse>();
            foreach (var item in lista)
            {
                listadoFormasDePago.Add(_mapper.Map<FormaDePagosResponse>(item));
            }
            return listadoFormasDePago;
        }
    }
}

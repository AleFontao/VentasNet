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
        
            Response ventaResponse = new Response();
            try
            {
                Venta venta = new Venta();
                venta.FormaPago = entity[0].FormaDePago.Id;
                entity.ForEach(item =>
                {
                    venta.CantidadProductos += (Convert.ToInt64(venta.CantidadProductos) + Convert.ToInt64(item.Cantidad)).ToString();
                    venta.ImporteTotal = (Convert.ToInt64(venta.ImporteTotal) + Convert.ToInt64(item.SubtotalItem)).ToString();
                });
                _context.Venta.Add(venta);
                _context.SaveChanges();
                int id = venta.IdVenta;

                entity.ForEach((item) =>
                {
                    DetalleVenta detalle = new DetalleVenta
                    {
                        IdProducto = item.Producto.Id,
                        Cantidad = item.Cantidad,
                        IdVenta = id,
                        Subtotal = item.SubtotalItem
                    };
                    _context.DetalleVenta.Add(detalle);
                    
                });
               _context.SaveChanges();
                ventaResponse.TextMensaje = "Venta agregada.";
                ventaResponse.Guardar = true;
               
            }
            catch (Exception ex)
            {
                ventaResponse.TextMensaje = "Error al agregar la venta.";
                ventaResponse.Guardar = false;
                Console.WriteLine(ex.ToString());
            } return ventaResponse;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Repository;
using VentasNet.Infra.Repository.Interfaz;

namespace VentasNet.Controllers
{
    public class VentaController : Controller
    {
        private List<Producto> _carrito = new List<Producto>();
        private IEnumerable<ProductoRequest> _productos = new List<ProductoRequest>();
        private readonly IProductoRepository _productoRepository;
        private readonly IVentaRepository _ventaRepository;
        private readonly IFormaDePagoRepository _formaDePagoRepository;
        public VentaController(IProductoRepository productoRepository, IVentaRepository ventaRepository, IFormaDePagoRepository formaDePagoRepository)
        {
            _productoRepository = productoRepository;
            _ventaRepository = ventaRepository;
            _formaDePagoRepository = formaDePagoRepository;
        }
        public IActionResult Venta()
        {

            return View();
        }

        public IActionResult ListaProducto()
        {
            _productos = _productoRepository.ObtenerTodos();
            ViewBag.FormasDePago = _formaDePagoRepository.ObtenerTodos();
            ViewBag.Producto = _productos;
            return View();
        }

        public IEnumerable<ProductoRequest> BuscarPorNombre(string nombre)
        {
            return _productoRepository.ObtenerPorNombreLista(nombre);
        }

        [HttpPost]
        public IActionResult GenerarVenta([FromBody] List<ItemRequest> elementosCarrito)
        {
            _ventaRepository.AgregarVenta(elementosCarrito);
            return Ok();
        }
    }
}

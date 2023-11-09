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

        public VentaController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public IActionResult Venta()
        {
           
            return View();
        }

        public IActionResult ListaProducto()
        {
            _productos =  _productoRepository.ObtenerTodos();
            ViewBag.Producto = _productos;
            return View();
        }

        public IEnumerable<ProductoRequest> BuscarPorNombre(string nombre)
        {
            return _productoRepository.ObtenerPorNombreLista(nombre);
        }
    
    }
}

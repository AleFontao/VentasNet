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
        private List<ProductoRequest> _carrito = new List<ProductoRequest>();
        private IEnumerable<ProductoRequest> _productos = new List<ProductoRequest>();
        private readonly IProductoRepository _productoRepository;

        public VentaController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public IActionResult Venta()
        {
            //ViewBag.Producto productos = _productoRepository.ObtenerTodos();
            return View();
        }

        public IActionResult ListaProducto()
        {
            _productos =  _productoRepository.ObtenerTodos();
            ViewBag.Producto = _productos;
            return View();
        }
        [HttpPost]
        public IActionResult AgregarProducto(int id)
        {
            // Lógica para obtener el producto de la tabla Producto
            var producto = _productos.First(p => p.Id == id);


            _carrito.Add(producto);
            ViewBag.Carrito = _carrito;

            return RedirectToAction("Venta", "ListaProducto");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Repository.Interfaz;

namespace TrabajoPractico1.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaProducto()
        {
            ViewBag.Producto = _productoRepository.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(ProductoRequest producto)
        {
            _productoRepository.Agregar(producto);
            return RedirectToAction("ListaProducto");
        }

        [HttpPost]
        public IActionResult ModificarProducto(ProductoRequest producto)
        {
            _productoRepository.Modificar(producto);
            return RedirectToAction("ListaProducto");
        }

        [HttpPost]
        public IActionResult EliminarProducto(ProductoRequest productoAEliminar)
        {
            
            if (productoAEliminar != null)
            {
                _productoRepository.Eliminar(productoAEliminar);
            }

            return RedirectToAction("ListaProducto");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Repository;
using VentasNet.Infra.Repository.Interfaz;

namespace TrabajoPractico1.Controllers
{
    public class ProveedorController : Controller
    {

        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaProveedor()
        {
            ViewBag.Proveedor = _proveedorRepository.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProveedor(ProveedorRequest proveedor)
        {
            _proveedorRepository.Agregar(proveedor);
            return RedirectToAction("ListaProveedor");
        }

        [HttpPost]
        public IActionResult ModificarProveedor(ProveedorRequest proveedor)
        {
            _proveedorRepository.Modificar(proveedor);
            return RedirectToAction("ListaProveedor");
        }

        [HttpPost]
        public IActionResult EliminarProveedor(ProveedorRequest proveedorAEliminar)
        {
          
            if (proveedorAEliminar != null)
            {
                _proveedorRepository.Eliminar(proveedorAEliminar);
            }

            return RedirectToAction("ListaProveedor");
        }
    }
}

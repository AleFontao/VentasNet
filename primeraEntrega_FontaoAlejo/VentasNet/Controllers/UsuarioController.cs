using Microsoft.AspNetCore.Mvc;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Repository;
using VentasNet.Infra.Repository.Interfaz;

namespace TrabajoPractico1.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult ListaUsuario()
        {
            ViewBag.Usuario = _usuarioRepository.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult AgregarUsuario(UsuarioRequest usuario)
        {
            _usuarioRepository.Agregar(usuario);
            return RedirectToAction("ListaUsuario");
        }

        [HttpPost]
        public IActionResult ModificarUsuario(int IdUsuario, string contraseniaAntigua, UsuarioRequest usuario)
        {
            var usuarioPass = _usuarioRepository.ObtenerById(IdUsuario).Password;
            if (usuarioPass == contraseniaAntigua)
            {
                _usuarioRepository.Modificar(usuario);
                return RedirectToAction("ListaUsuario");
            }
            else
            {
                TempData["Error"] = "Contraseña incorrecta";
                return RedirectToAction("ListaUsuario");
            }
        }

        [HttpPost]
        public IActionResult EliminarUsuario(UsuarioRequest usuarioAEliminar)
        {
          
            if (usuarioAEliminar != null)
            {
                _usuarioRepository.Eliminar(usuarioAEliminar);
            }

            return RedirectToAction("ListaUsuario");
        }
    }
}

using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using VentasNet.Entity.Models;
using VentasNet.Infra.Repository.Interfaz;

namespace TrabajoPractico1.Controllers
{
    public class LoginController : Controller
    {


        private IAuth<Usuario> _usuarioAuth;
        public LoginController(IAuth<Usuario> usuarioRepository)
        {
            _usuarioAuth = usuarioRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Usuario usuario)
        {
            //string token = await usuario.IniciarSesionAsync();
            usuario = _usuarioAuth.IniciarSesion(usuario.Email, usuario.Password);
            if (usuario != null)
            {
                HttpContext.Session.SetString("userEmail", usuario.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Credenciales incorrectas. Inicio de sesión fallido.";
                return RedirectToAction("Index", "Login");
            }
           
        }
    }
}

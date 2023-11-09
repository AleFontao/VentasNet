using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VentasNet.Infra.Repository.Interfaz;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace TrabajoPractico1.Controllers
{
    public class ClienteController : Controller
    {
       
        private readonly IWebHostEnvironment _host;
        private readonly IClienteRepository _clienteRepository;

		public ClienteController(IClienteRepository clienteRepository, IWebHostEnvironment host)
        {
            _clienteRepository = clienteRepository;
			_host = host;
        }
        
        public IActionResult ListaClientes()
        {
			ViewBag.Cliente = _clienteRepository.ObtenerTodos();
			return View();
		}

        [HttpPost]
        public IActionResult AgregarCliente(ClienteRequest cliente)
        {
			var result = _clienteRepository.Agregar(cliente);
			return RedirectToAction("ListaClientes");
		}

        [HttpPost]
        public IActionResult ModificarCliente(ClienteRequest cliente)
        {
            _clienteRepository.Modificar(cliente);
            return RedirectToAction("ListaClientes");
        }

        [HttpPost]
        public IActionResult EliminarCliente(ClienteRequest clienteAEliminar)
        {
      
            if (clienteAEliminar != null)
            {
                _clienteRepository.Eliminar(clienteAEliminar);
            }

            return RedirectToAction("ListaClientes");
        }

        [HttpGet]
        public IActionResult ObtenerClienteByCuit()
        {
            ViewBag.Cliente = _clienteRepository.ObtenerTodos();
            return View();
        }
    }
}

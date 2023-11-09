using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Repository.Interfaz;

namespace VentasNet.Infra.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly VentasNetContext _context;
        private readonly IMapper _mapper;
        public ProveedorRepository(VentasNetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Response Agregar(ProveedorRequest entity)
        {
            Response proveedorResponse = new Response();
            if (ObtenerByCuit(entity.Cuit) == null)
            {
                try
                {
                    var proveedorMapeado = MapeoProveedor(entity);
                    proveedorMapeado.FechaAlta = DateTime.Now;
                    proveedorMapeado.Estado = true;
                    _context.Add(proveedorMapeado);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.Property = entity.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.TextMensaje = "Error al agregar el proveedor.";
                    proveedorResponse.Guardar = false;
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                proveedorResponse.TextMensaje = "Ya existe un proveedor con el mismo CUIT.";
                proveedorResponse.Guardar = false;
            }
            return proveedorResponse;
        }

        public Response Eliminar(ProveedorRequest entity)
        {
            Response proveedorResponse = new Response();
            var existeCliente = ObtenerByCuit(entity.Cuit);
            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Estado = false;
                    _context.Update(existeCliente);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.Property = entity.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.TextMensaje = "Ocurrió un error al eliminar proveedor";
                    proveedorResponse.Guardar = false;
                }
            }
            else
            {
                proveedorResponse.TextMensaje = "No existe el proveedor que quiere eliminar.";
                proveedorResponse.Guardar = false;
            }
            return proveedorResponse;
        }

        public Response Modificar(ProveedorRequest entity)
        {

            Response proveedorResponse = new Response();
            var existeCliente = ObtenerById(entity.IdProveedor);
            if (existeCliente != null)
            {
                try
                {
                    var proveedorMapeado = MapeoProveedor(entity);               
                    existeCliente.Provincia = proveedorMapeado.Provincia;
                    existeCliente.Domicilio = proveedorMapeado.Domicilio;
                    existeCliente.Estado = true;
                    existeCliente.Cuit = proveedorMapeado.Cuit;
                    _context.Update(existeCliente);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.Property = entity.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.TextMensaje = "Ocurrió un error al modificar proveedor";
                    proveedorResponse.Guardar = false;
                }
            }
            else
            {
                proveedorResponse.TextMensaje = "No existe el proveedor que quiere modificar.";
                proveedorResponse.Guardar = false;
            }
            return proveedorResponse;
        }

        public Proveedor ObtenerByCuit(string cuit)
        {
            return _context.Proveedor.Where(c => c.Cuit == cuit).FirstOrDefault();
        }
        public Proveedor ObtenerById(int id)
        {
            return _context.Proveedor.Where(c => c.IdProveedor == id).FirstOrDefault();
        }

        public IEnumerable<ProveedorRequest> ObtenerTodos()
        {
            var lista = _context.Proveedor.Where(x => x.Estado != false).ToList();
            List<ProveedorRequest> listadoProveedorRequest = new List<ProveedorRequest>();
            foreach (var item in lista)
            {
                listadoProveedorRequest.Add(_mapper.Map<ProveedorRequest>(item));
            }
            return listadoProveedorRequest;
        }

        public Proveedor MapeoProveedor(ProveedorRequest proveedor)
        {
			Proveedor proveedorMapeado = _mapper.Map<Proveedor>(proveedor);
            return proveedorMapeado;
        }

    
    }
}

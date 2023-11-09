using AutoMapper;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Repository.Interfaz;

namespace VentasNet.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VentasNetContext _context;
		private readonly IMapper _mapper;
		public ClienteRepository(VentasNetContext context, IMapper mapper)
		{
			_context = context;
            _mapper = mapper;
		}
		public Response Agregar(ClienteRequest entity)
        {
			Response clienteResponse = new Response();
            if (ObtenerByCuit(entity.Cuit) == null)
            {	
				try
                {
                    var clienteMapeado = MapeoCliente(entity);
					clienteMapeado.FechaAlta = DateTime.Now;
					clienteMapeado.Estado = true;
                    _context.Add(clienteMapeado);
                    _context.SaveChanges();
					clienteResponse.Guardar = true;
					clienteResponse.Property = entity.RazonSocial;
				}
				catch (Exception ex)
                {
                    clienteResponse.TextMensaje = "Error al agregar el cliente.";
                    clienteResponse.Guardar = false;
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                clienteResponse.TextMensaje = "Ya existe un cliente con el mismo CUIT.";
                clienteResponse.Guardar = false;
            }
            return clienteResponse;
        }

        public Response Eliminar(ClienteRequest entity)
        {
			Response clienteResponse = new Response();
			var existeCliente = ObtenerByCuit(entity.Cuit);
			if (existeCliente != null){ 
				try
                {
					existeCliente.Estado = false;
					_context.Update(existeCliente);
                    _context.SaveChanges();
                    clienteResponse.Guardar = true;
                    clienteResponse.Property = entity.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.TextMensaje = "Ocurrió un error al eliminar cliente";
                    clienteResponse.Guardar = false;
                }
            }
            else
            {
                clienteResponse.TextMensaje = "No existe el cliente que quiere eliminar.";
                clienteResponse.Guardar = false;
            }
            return clienteResponse;
        }

        public Response Modificar(ClienteRequest entity)
        {

			Response clienteResponse = new Response();
            var existeCliente = ObtenerByCuit(entity.Cuit);
			if (existeCliente != null)
			{
				try
				{
					var clienteMapeado = MapeoCliente(entity);
                    existeCliente.Apellido = clienteMapeado.Apellido;
                    existeCliente.Nombre = clienteMapeado.Nombre;
                    existeCliente.Provincia = clienteMapeado.Provincia;
                    existeCliente.Domicilio = clienteMapeado.Domicilio;
					existeCliente.Estado = true;
					_context.Update(existeCliente);
					_context.SaveChanges();
					clienteResponse.Guardar = true;
					clienteResponse.Property = entity.RazonSocial;
				}
				catch (Exception ex)
				{
					clienteResponse.TextMensaje = "Ocurrió un error al modificar cliente";
					clienteResponse.Guardar = false;
				}
			}
			else
			{
				clienteResponse.TextMensaje = "No existe el cliente que quiere modificar.";
				clienteResponse.Guardar = false;
			}
			return clienteResponse;
		}

		public Cliente ObtenerByCuit(string cuit)
        {
			return _context.Cliente.Where(c => c.Cuit == cuit).FirstOrDefault();
		}
        public Cliente ObtenerById(int id)
        {
            return _context.Cliente.Where(c => c.IdCliente == id).FirstOrDefault();
        }

        public IEnumerable<ClienteRequest> ObtenerTodos()
        {			
			var lista = _context.Cliente.Where(x => x.Estado != false).ToList();
            List<ClienteRequest> listadoClienteRequest = new List<ClienteRequest>();
            foreach (var item in lista)
            { 
                listadoClienteRequest.Add(_mapper.Map<ClienteRequest>(item));
            }
			return listadoClienteRequest;
		}

		public Cliente MapeoCliente(ClienteRequest cliente)
		{
			Cliente clienteMapeado = _mapper.Map<Cliente>(cliente);
			return clienteMapeado;
		}

        public List<Cliente> ObtenerClienteByDato(ClienteBusquedaRequest clienteBusquedaRequest)
        {
            var lista = _context.Cliente.Where(x => x.Estado != false).ToList();
            List<Cliente> listadoClienteRequest = new List<Cliente>();
            foreach (var item in lista)
            {
                if ((string.IsNullOrEmpty(clienteBusquedaRequest.Nombre) || item.Nombre == clienteBusquedaRequest.Nombre) &&
                   (string.IsNullOrEmpty(clienteBusquedaRequest.Apellido) || item.Apellido == clienteBusquedaRequest.Apellido) &&
                   (string.IsNullOrEmpty(clienteBusquedaRequest.Cuit) || item.Cuit == clienteBusquedaRequest.Cuit))
                {
                    listadoClienteRequest.Add(_mapper.Map<Cliente>(item));
                }
            }
            return listadoClienteRequest;
        }
    }
}

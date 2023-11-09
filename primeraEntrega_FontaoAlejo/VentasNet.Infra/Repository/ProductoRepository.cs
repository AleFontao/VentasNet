using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Repository.Interfaz;

namespace VentasNet.Infra.Repository
{
    public class ProductoRepository : IProductoRepository
    {

		private readonly VentasNetContext _context;
		private readonly IMapper _mapper;
		public ProductoRepository(VentasNetContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public Response Agregar(ProductoRequest entity)
        {
			Response productoResponse = new Response();
			if (ObtenerById(entity.Id) == null)
			{
				try
				{
					var productoMapeado = MapeoProducto(entity);
					productoMapeado.Estado = true;
					_context.Add(productoMapeado);
					_context.SaveChanges();
					productoResponse.Guardar = true;
					productoResponse.Property = entity.NombreProducto;
				}
				catch (Exception ex)
				{
					productoResponse.TextMensaje = "Error al agregar el producto.";
					productoResponse.Guardar = false;
					Console.WriteLine(ex.ToString());
				}
			}
			else
			{
				productoResponse.TextMensaje = "Ya existe un producto con el mismo ID.";
				productoResponse.Guardar = false;
			}
			return productoResponse;
		}

        public Response Eliminar(ProductoRequest entity)
        {
			Response productoResponse = new Response();
			var existeProducto = ObtenerById(entity.Id);
			if (existeProducto != null)
			{
				try
				{
					existeProducto.Estado = false;
					_context.Update(existeProducto);
					_context.SaveChanges();
					productoResponse.Guardar = true;
					productoResponse.Property = entity.NombreProducto;
				}
				catch (Exception ex)
				{
					productoResponse.TextMensaje = "Ocurrió un error al eliminar producto";
					productoResponse.Guardar = false;
				}
			}
			else
			{
				productoResponse.TextMensaje = "No existe el producto que quiere eliminar.";
				productoResponse.Guardar = false;
			}
			return productoResponse;
		}

		public Response Modificar(ProductoRequest entity)
        {
			Response productoResponse = new Response();
			var existeProducto = ObtenerById(entity.Id);
			if (existeProducto != null)
			{
				try
				{
					var productoMapeado = MapeoProducto(entity);
					existeProducto.NombreProducto = productoMapeado.NombreProducto;
					existeProducto.Descripcion = productoMapeado.Descripcion;
					existeProducto.ImporteProducto = productoMapeado.ImporteProducto;
					existeProducto.Estado = true;
					_context.Update(existeProducto);
					_context.SaveChanges();
					productoResponse.Guardar = true;
					productoResponse.Property = entity.NombreProducto;
				}
				catch (Exception ex)
				{
					productoResponse.TextMensaje = "Ocurrió un error al modificar producto";
					productoResponse.Guardar = false;
				}
			}
			else
			{
				productoResponse.TextMensaje = "No existe el producto que quiere modificar.";
				productoResponse.Guardar = false;
			}
			return productoResponse;
		}

        public Producto ObtenerById(int id)
        {
			return _context.Producto.Where(p => p.Id == id).FirstOrDefault();
		}

        public IEnumerable<ProductoRequest> ObtenerTodos()
        {
			var lista = _context.Producto.Where(x => x.Estado != false).ToList();
			List<ProductoRequest> listadoProductoRequest = new List<ProductoRequest>();
			foreach (var item in lista)
			{
				listadoProductoRequest.Add(_mapper.Map<ProductoRequest>(item));
			}
			return listadoProductoRequest;
		}

		public Producto MapeoProducto(ProductoRequest producto)
		{
			Producto productoMapeado = _mapper.Map<Producto>(producto);
			return productoMapeado;
		}

        public IEnumerable<ProductoRequest> ObtenerPorNombreLista(string nombre)
        {
			var productos = _context.Producto.Where(x => x.NombreProducto.StartsWith(nombre));
            List<ProductoRequest> listadoProductoRequest = new List<ProductoRequest>();
            foreach (var item in productos)
            {
                listadoProductoRequest.Add(_mapper.Map<ProductoRequest>(item));
            }
            return listadoProductoRequest;
        }
    }
}

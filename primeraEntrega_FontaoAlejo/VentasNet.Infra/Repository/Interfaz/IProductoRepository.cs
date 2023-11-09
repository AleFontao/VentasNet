using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Repository.Interfaz
{
	public interface IProductoRepository
	{
		Producto ObtenerById(int id);
		Response Agregar(ProductoRequest entity);
		Response Modificar(ProductoRequest entity);
		Response Eliminar(ProductoRequest entity);
		IEnumerable<ProductoRequest> ObtenerTodos();
	}
}

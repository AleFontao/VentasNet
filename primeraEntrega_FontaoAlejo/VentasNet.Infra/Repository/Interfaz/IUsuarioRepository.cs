using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Repository.Interfaz
{
    public interface IUsuarioRepository
    {
        //Defino una interfaz para todos las clases repository para tener un "esquema de persistencia"
        Usuario ObtenerById(int id);
        Response Agregar(UsuarioRequest entity);
		Response Modificar(UsuarioRequest entity);
		Response Eliminar(UsuarioRequest entity);
        IEnumerable<UsuarioRequest> ObtenerTodos();
    }
}

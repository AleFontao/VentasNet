
using AutoMapper;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Repository.Interfaz;

namespace VentasNet.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository, IAuth<Usuario>
    {
        private readonly VentasNetContext _context;
        private readonly IMapper _mapper;
        public UsuarioRepository(VentasNetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Response Agregar(UsuarioRequest entity)
        {
            Response usuarioResponse = new Response();
            if (ObtenerById(entity.IdUsuario) == null)
            {
                try
                {
                    var usuarioMapeado = MapeoUsuario(entity);
                    usuarioMapeado.FechaAlta = DateTime.Now;
                    usuarioMapeado.Estado = true;
                    _context.Add(usuarioMapeado);
                    _context.SaveChanges();
                    usuarioResponse.Guardar = true;
                    usuarioResponse.Property = entity.Email;
                }
                catch (Exception ex)
                {
                    usuarioResponse.TextMensaje = "Error al agregar el cliente.";
                    usuarioResponse.Guardar = false;
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                usuarioResponse.TextMensaje = "Ya existe un cliente con el mismo CUIT.";
                usuarioResponse.Guardar = false;
            }
            return usuarioResponse;
        }

        public Response Eliminar(UsuarioRequest entity)
        {
            Response usuarioResponse = new Response();
            var existeCliente = ObtenerById(entity.IdUsuario);
            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Estado = false;
                    _context.Update(existeCliente);
                    _context.SaveChanges();
                    usuarioResponse.Guardar = true;
                    usuarioResponse.Property = entity.Email;
                }
                catch (Exception ex)
                {
                    usuarioResponse.TextMensaje = "Ocurrió un error al eliminar usuario";
                    usuarioResponse.Guardar = false;
                }
            }
            else
            {
                usuarioResponse.TextMensaje = "No existe el usuario que quiere eliminar.";
                usuarioResponse.Guardar = false;
            }
            return usuarioResponse;
        }

        public Response Modificar(UsuarioRequest entity)
        {

            Response usuarioResponse = new Response();
            var existeCliente = ObtenerById(entity.IdUsuario);
            if (existeCliente != null)
            {
                try
                {
                    var usuarioMapeado = MapeoUsuario(entity);
                    existeCliente.Password = usuarioMapeado.Password;
                    existeCliente.Email = usuarioMapeado.Email;
                    existeCliente.Estado = true;
                    _context.Update(existeCliente);
                    _context.SaveChanges();
                    usuarioResponse.Guardar = true;
                    usuarioResponse.Property = entity.Email;
                }
                catch (Exception ex)
                {
                    usuarioResponse.TextMensaje = "Ocurrió un error al modificar usuario";
                    usuarioResponse.Guardar = false;
                }
            }
            else
            {
                usuarioResponse.TextMensaje = "No existe el usuario que quiere modificar.";
                usuarioResponse.Guardar = false;
            }
            return usuarioResponse;
        }
        public Usuario ObtenerById(int id)
        {
            return _context.Usuario.Where(c => c.IdUsuario == id).FirstOrDefault();
        }

        public IEnumerable<UsuarioRequest> ObtenerTodos()
        {
            var lista = _context.Usuario.Where(x => x.Estado != false).ToList();
            List<UsuarioRequest> listadoUsuarioRequest = new List<UsuarioRequest>();
            foreach (var item in lista)
            {
                listadoUsuarioRequest.Add(_mapper.Map<UsuarioRequest>(item));
            }
            return listadoUsuarioRequest;
        }

        public Usuario MapeoUsuario(UsuarioRequest usuario)
        {
            Usuario usuarioMapeado = _mapper.Map<Usuario>(usuario);
            return usuarioMapeado;
        }


        Usuario IAuth<Usuario>.IniciarSesion(string Credencial, string Contrasenia)
        {
            try
            {
                return _context.Usuario.First(u => (u.Email == Credencial || u.UserName == Credencial) && u.Password == Contrasenia);
            }catch(Exception ex)
            {
                return null;
            }
		}

   
    }
}

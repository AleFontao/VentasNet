using VentasNet.Entity.Models;

namespace VentasNet.Infra.Repository.Interfaz
{
    public interface IAuth<T>
    {
        T IniciarSesion(string Email, string Contrasenia);
    }
}

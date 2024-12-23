using Modelos;

namespace MSClientes.ServiciosExternos
{
    public interface IServicioCuentas
    {
        Task<Cuenta> obtenerCuentaDeTarjeta(int idTarjeta);
    }
}
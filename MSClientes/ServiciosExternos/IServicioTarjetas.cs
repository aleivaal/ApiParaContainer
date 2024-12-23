using Modelos;

namespace MSClientes.ServiciosExternos
{
    public interface IServicioTarjetas
    {
        Task<List<Tarjeta>> obtenerTarjetasDeCliente(int idCliente);
    }
}
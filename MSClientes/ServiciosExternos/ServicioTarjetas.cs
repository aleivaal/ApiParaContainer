using Modelos;

namespace MSClientes.ServiciosExternos
{
    public class ServicioTarjetas : IServicioTarjetas
    {

        public Task<List<Tarjeta>> obtenerTarjetasDeCliente(int idCliente)
        {
            return UtilitarioHTTPClient.InvocarApiAsync<List<Tarjeta>>($"http://localhost:5029/api/Tarjetas/{idCliente}");
        }
    }
}

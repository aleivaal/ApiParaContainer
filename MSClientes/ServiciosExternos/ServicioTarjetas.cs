using Modelos;

namespace MSClientes.ServiciosExternos
{
    public class ServicioTarjetas : IServicioTarjetas
    {

        public Task<List<Tarjeta>> obtenerTarjetasDeCliente(int idCliente)
        {
            var urlServicio = $"http://tarjeta_api:8080/api/Tarjetas/{idCliente}";
            Console.WriteLine($"Invocando... {urlServicio}");
            return UtilitarioHTTPClient.InvocarApiAsync<List<Tarjeta>>(urlServicio);
        }
    }
}

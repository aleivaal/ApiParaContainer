using Modelos;

namespace MSClientes.ServiciosExternos
{
    public class ServicioCuentas : IServicioCuentas
    {

        public Task<Cuenta> obtenerCuentaDeTarjeta(int idTarjeta)
        {
            var urlServicio = $"http://cuenta_api:8080/api/Cuentas/{idTarjeta}";
            Console.WriteLine($"Invocando... {urlServicio}");
            return UtilitarioHTTPClient.InvocarApiAsync<Cuenta>(urlServicio);
        }
    }
}

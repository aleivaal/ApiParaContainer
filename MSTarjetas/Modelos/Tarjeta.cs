namespace Modelos
{

    public class Tarjeta
    {
        public int  idTarjeta { get; set; }
        public int IdCliente { get; set; }
        public string? NumeroTarjeta { get; set; }

        public string? TipoTarjeta { get; set; }
    }

}
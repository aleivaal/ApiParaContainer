namespace Modelos
{

    public class Cuenta
    {
        public int  idCuenta { get; set; }
        public int idTarjeta { get; set; }
        public string? CuentaIBAN { get; set; }

        public int? Saldo { get; set; }
    }

}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{

    public class Tarjeta
    {
        public int  idTarjeta { get; set; }
        public int IdCliente { get; set; }
        public string? NumeroTarjeta { get; set; }

        public string? TipoTarjeta { get; set; }

        [NotMapped]
        public Cuenta? CuentaAsociada  {  get; set; }
    }

}
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{

    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        [NotMapped]
        public List<Tarjeta>? Tarjetas { get; set; }


        //public ICollection<Tarjeta>? Tarjetas { get; set; } //
    }

}
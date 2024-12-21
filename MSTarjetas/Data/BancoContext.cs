using Microsoft.EntityFrameworkCore;
using Modelos;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace AccesoDatos
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }


        public DbSet<Tarjeta> Tarjetas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.idTarjeta);
                entity.Property(e => e.IdCliente).IsRequired();
                entity.Property(e => e.NumeroTarjeta).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TipoTarjeta).IsRequired().HasMaxLength(255);

            });

            modelBuilder.Entity<Tarjeta>().HasData(
                new Tarjeta { idTarjeta=1, IdCliente = 1, NumeroTarjeta = "5897 8525 4569 4521", TipoTarjeta = "Master Card" },
                new Tarjeta { idTarjeta = 2, IdCliente = 1, NumeroTarjeta = "6985 3247 4569 7852", TipoTarjeta = "Visa" },
                new Tarjeta { idTarjeta = 3, IdCliente = 2, NumeroTarjeta = "3697 1497 6347 2674", TipoTarjeta = "American Express" }
            );
        }
    }
}
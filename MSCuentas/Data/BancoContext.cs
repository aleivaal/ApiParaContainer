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


        public DbSet<Cuenta> Cuentas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.idCuenta);
                entity.Property(e => e.idTarjeta).IsRequired();
                entity.Property(e => e.CuentaIBAN).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Saldo).IsRequired().HasMaxLength(255);

            });

            modelBuilder.Entity<Cuenta>().HasData(
                new Cuenta { idCuenta=1, idTarjeta = 1, CuentaIBAN = "CR1234567890", Saldo = 100 },
                new Cuenta { idCuenta = 2, idTarjeta = 2, CuentaIBAN = "CR9876543210", Saldo = 200 },
                new Cuenta { idCuenta = 3, idTarjeta = 3, CuentaIBAN = "CR777777777", Saldo = 300 }
            );
        }
    }
}
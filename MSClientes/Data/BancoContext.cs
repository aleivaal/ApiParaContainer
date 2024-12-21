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


        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { IdCliente = 1, Nombre = "John Doe", Direccion = "123 Elm St" },
                new Cliente { IdCliente = 2, Nombre = "Jane Smith", Direccion = "456 Oak St" },
                new Cliente { IdCliente = 3, Nombre = "William Johnson", Direccion = "789 Pine St" }
            );
        }
    }
}
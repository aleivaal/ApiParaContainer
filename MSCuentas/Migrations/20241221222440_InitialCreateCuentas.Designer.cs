﻿// <auto-generated />
using System;
using AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSCuentas.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20241221222440_InitialCreateCuentas")]
    partial class InitialCreateCuentas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Modelos.Cuentas", b =>
                {
                    b.Property<int>("idCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCuenta"));

                    b.Property<string>("CuentaIBAN")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Saldo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<int>("idTarjeta")
                        .HasColumnType("int");

                    b.HasKey("idCuenta");

                    b.ToTable("Cuentas");

                    b.HasData(
                        new
                        {
                            idCuenta = 1,
                            CuentaIBAN = "CR1234567890",
                            Saldo = 100,
                            idTarjeta = 1
                        },
                        new
                        {
                            idCuenta = 2,
                            CuentaIBAN = "CR9876543210",
                            Saldo = 200,
                            idTarjeta = 2
                        },
                        new
                        {
                            idCuenta = 3,
                            CuentaIBAN = "CR777777777",
                            Saldo = 300,
                            idTarjeta = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
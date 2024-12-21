using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSCuentas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateCuentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    idCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTarjeta = table.Column<int>(type: "int", nullable: false),
                    CuentaIBAN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Saldo = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.idCuenta);
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "idCuenta", "CuentaIBAN", "Saldo", "idTarjeta" },
                values: new object[,]
                {
                    { 1, "CR1234567890", 100, 1 },
                    { 2, "CR9876543210", 200, 2 },
                    { 3, "CR777777777", 300, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}

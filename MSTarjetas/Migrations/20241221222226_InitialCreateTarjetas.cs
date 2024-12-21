using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSTarjetas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTarjetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    idTarjeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoTarjeta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.idTarjeta);
                });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "idTarjeta", "IdCliente", "NumeroTarjeta", "TipoTarjeta" },
                values: new object[,]
                {
                    { 1, 1, "5897 8525 4569 4521", "Master Card" },
                    { 2, 1, "6985 3247 4569 7852", "Visa" },
                    { 3, 2, "3697 1497 6347 2674", "American Express" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarjetas");
        }
    }
}

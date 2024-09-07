using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiHumanos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humanos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humanos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Humanos",
                columns: new[] { "Id", "Altura", "Edad", "Nombre", "Peso", "Sexo" },
                values: new object[,]
                {
                    { 1, 1.6499999999999999, 28, "Marcos Palomino", 70.0, "M" },
                    { 2, 1.0, 1, "Cami Palomino", 10.0, "F" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humanos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "A",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    One = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Two = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Three = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "B",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    One = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Two = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Three = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_A_AId",
                        column: x => x.AId,
                        principalTable: "A",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_B_AId",
                table: "B",
                column: "AId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B");

            migrationBuilder.DropTable(
                name: "A");
        }
    }
}

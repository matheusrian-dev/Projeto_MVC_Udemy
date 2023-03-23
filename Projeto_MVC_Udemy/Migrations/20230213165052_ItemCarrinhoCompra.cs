using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLanchesMacUdemy.Migrations
{
    /// <inheritdoc />
    public partial class ItemCarrinhoCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCarrinhoCompra",
                columns: table => new
                {
                    ItemCarrinhoCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LancheId = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoCompraId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinhoCompra", x => x.ItemCarrinhoCompraId);
                    table.ForeignKey(
                        name: "FK_ItemCarrinhoCompra_Lanche_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanche",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinhoCompra_LancheId",
                table: "ItemCarrinhoCompra",
                column: "LancheId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarrinhoCompra");
        }
    }
}

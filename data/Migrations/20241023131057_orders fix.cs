using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    public partial class ordersfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Orders_OrderId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_OrderId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "MaterialOrder",
                columns: table => new
                {
                    UsedInOrdersId = table.Column<int>(type: "integer", nullable: false),
                    UsedMaterialsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialOrder", x => new { x.UsedInOrdersId, x.UsedMaterialsId });
                    table.ForeignKey(
                        name: "FK_MaterialOrder_Materials_UsedMaterialsId",
                        column: x => x.UsedMaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialOrder_Orders_UsedInOrdersId",
                        column: x => x.UsedInOrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOrder_UsedMaterialsId",
                table: "MaterialOrder",
                column: "UsedMaterialsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialOrder");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Materials",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_OrderId",
                table: "Materials",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Orders_OrderId",
                table: "Materials",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}

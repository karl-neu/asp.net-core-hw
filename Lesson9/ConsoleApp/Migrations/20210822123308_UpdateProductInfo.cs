using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.Migrations
{
    public partial class UpdateProductInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfos_Products_ProductId",
                table: "ProductInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProductInfos_ProductId",
                table: "ProductInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfos_ProductId",
                table: "ProductInfos",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfos_Products_ProductId",
                table: "ProductInfos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfos_Products_ProductId",
                table: "ProductInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProductInfos_ProductId",
                table: "ProductInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfos_ProductId",
                table: "ProductInfos",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfos_Products_ProductId",
                table: "ProductInfos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

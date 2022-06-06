using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddania.Data.Migrations
{
    public partial class obrazy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Identity",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "Identity",
                table: "Items",
                newName: "OwnerName");

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                schema: "Identity",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => new { x.CategoriesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CategoryItem_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "Identity",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalSchema: "Identity",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Identity",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_ItemsId",
                schema: "Identity",
                table: "CategoryItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ItemId",
                schema: "Identity",
                table: "Images",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItem",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "Identity");

            migrationBuilder.RenameColumn(
                name: "OwnerName",
                schema: "Identity",
                table: "Items",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "Identity",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "Identity",
                table: "Items",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                schema: "Identity",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                schema: "Identity",
                table: "Items",
                column: "CategoryId",
                principalSchema: "Identity",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddania.Data.Migrations
{
    public partial class item_owner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestedUsers",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                schema: "Identity",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                schema: "Identity",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OwnerId",
                schema: "Identity",
                table: "Items",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_User_OwnerId",
                schema: "Identity",
                table: "Items",
                column: "OwnerId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_User_OwnerId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OwnerId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "Identity",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                schema: "Identity",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InterestedUsers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestedUsers_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Identity",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestedUsers_ItemId",
                schema: "Identity",
                table: "InterestedUsers",
                column: "ItemId");
        }
    }
}

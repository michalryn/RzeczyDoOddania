using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddania.Data.Migrations
{
    public partial class interest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                schema: "Identity",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReservedFor",
                schema: "Identity",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserItem",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItem", x => new { x.ItemId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Identity",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItem_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserItem_UserId",
                schema: "Identity",
                table: "UserItem",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserItem",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "Completed",
                schema: "Identity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ReservedFor",
                schema: "Identity",
                table: "Items");
        }
    }
}

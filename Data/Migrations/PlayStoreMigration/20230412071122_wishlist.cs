using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayStore.Data.Migrations.PlayStoreMigration
{
    public partial class wishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserId1",
                table: "Item",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserId1",
                table: "Item",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserId1",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserId1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Item");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayStore.Data.Migrations.PlayStoreMigration
{
    public partial class typeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Item");
        }
    }
}

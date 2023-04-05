using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayStore.Data.Migrations.PlayStoreMigration
{
    public partial class ReplyReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Review_ReviewId",
                table: "Reply");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewId",
                table: "Reply",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Review_ReviewId",
                table: "Reply",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Review_ReviewId",
                table: "Reply");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewId",
                table: "Reply",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Review_ReviewId",
                table: "Reply",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "Id");
        }
    }
}

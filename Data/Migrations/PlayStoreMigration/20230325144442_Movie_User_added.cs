using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayStore.Data.Migrations.PlayStoreMigration
{
    public partial class Movie_User_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_App_AppId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App",
                table: "App");

            migrationBuilder.RenameTable(
                name: "App",
                newName: "Item");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "Review",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_AppId",
                table: "Review",
                newName: "IX_Review_ItemId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrailerLink",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actor_Item_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrewMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewMember_Item_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile_pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recv_emails = table.Column<bool>(type: "bit", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserId",
                table: "Item",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actor_MovieId",
                table: "Actor",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_MovieId",
                table: "CrewMember",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserId",
                table: "Item",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Item_ItemId",
                table: "Review",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Item_ItemId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "CrewMember");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "TrailerLink",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "App");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Review",
                newName: "AppId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ItemId",
                table: "Review",
                newName: "IX_Review_AppId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App",
                table: "App",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_App_AppId",
                table: "Review",
                column: "AppId",
                principalTable: "App",
                principalColumn: "Id");
        }
    }
}

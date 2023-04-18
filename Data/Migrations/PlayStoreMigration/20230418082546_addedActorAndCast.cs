using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayStore.Data.Migrations.PlayStoreMigration
{
    public partial class addedActorAndCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Item_MovieId",
                table: "Actor");

            migrationBuilder.DropForeignKey(
                name: "FK_CrewMember_Item_MovieId",
                table: "CrewMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrewMember",
                table: "CrewMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "CrewMember",
                newName: "Credits");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actors");

            migrationBuilder.RenameIndex(
                name: "IX_CrewMember_MovieId",
                table: "Credits",
                newName: "IX_Credits_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_MovieId",
                table: "Actors",
                newName: "IX_Actors_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credits",
                table: "Credits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Item_MovieId",
                table: "Actors",
                column: "MovieId",
                principalTable: "Item",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Item_MovieId",
                table: "Credits",
                column: "MovieId",
                principalTable: "Item",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Item_MovieId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Item_MovieId",
                table: "Credits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credits",
                table: "Credits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Credits",
                newName: "CrewMember");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actor");

            migrationBuilder.RenameIndex(
                name: "IX_Credits_MovieId",
                table: "CrewMember",
                newName: "IX_CrewMember_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Actors_MovieId",
                table: "Actor",
                newName: "IX_Actor_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrewMember",
                table: "CrewMember",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Item_MovieId",
                table: "Actor",
                column: "MovieId",
                principalTable: "Item",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMember_Item_MovieId",
                table: "CrewMember",
                column: "MovieId",
                principalTable: "Item",
                principalColumn: "Id");
        }
    }
}

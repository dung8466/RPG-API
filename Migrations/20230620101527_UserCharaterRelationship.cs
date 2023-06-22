using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api.Migrations
{
    /// <inheritdoc />
    public partial class UserCharaterRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Charaters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charaters_UserId",
                table: "Charaters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charaters_Users_UserId",
                table: "Charaters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charaters_Users_UserId",
                table: "Charaters");

            migrationBuilder.DropIndex(
                name: "IX_Charaters_UserId",
                table: "Charaters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Charaters");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "User",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "varchar(60) CHARACTER SET utf8mb4",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}

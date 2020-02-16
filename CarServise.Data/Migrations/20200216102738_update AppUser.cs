using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServise.Data.Migrations
{
    public partial class updateAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FIO",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FIO",
                table: "AspNetUsers");
        }
    }
}

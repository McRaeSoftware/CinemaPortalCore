using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaPortalCore.Migrations
{
    public partial class addedJobroleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Jobrole",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jobrole",
                table: "Employees");
        }
    }
}

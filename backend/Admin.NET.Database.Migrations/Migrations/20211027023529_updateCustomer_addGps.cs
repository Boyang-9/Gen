using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class updateCustomer_addGps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gps",
                table: "Customer",
                type: "text",
                nullable: true,
                comment: "GPS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gps",
                table: "Customer");
        }
    }
}

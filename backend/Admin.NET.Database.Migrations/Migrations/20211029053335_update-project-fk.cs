using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class updateprojectfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customer_CustomerGroupId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customer_CustomerMineId",
                table: "Project");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerMineId",
                table: "Project",
                type: "bigint",
                nullable: true,
                comment: "客户煤矿编号",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "客户煤矿编号");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerGroupId",
                table: "Project",
                type: "bigint",
                nullable: true,
                comment: "客户集团编号",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "客户集团编号");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerGroupId",
                table: "Project",
                column: "CustomerGroupId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerMineId",
                table: "Project",
                column: "CustomerMineId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customer_CustomerGroupId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Customer_CustomerMineId",
                table: "Project");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerMineId",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "客户煤矿编号",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "客户煤矿编号");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerGroupId",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "客户集团编号",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "客户集团编号");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerGroupId",
                table: "Project",
                column: "CustomerGroupId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Customer_CustomerMineId",
                table: "Project",
                column: "CustomerMineId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

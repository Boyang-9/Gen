using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class addproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Types = table.Column<string>(type: "text", nullable: true),
                    UserIds = table.Column<string>(type: "text", nullable: true),
                    SupportType = table.Column<string>(type: "text", nullable: true),
                    SupportModel = table.Column<string>(type: "text", nullable: true),
                    ProjectDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CustomerGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerMineId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Customer_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Customer_CustomerMineId",
                        column: x => x.CustomerMineId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "项目信息");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerGroupId",
                table: "Project",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerMineId",
                table: "Project",
                column: "CustomerMineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}

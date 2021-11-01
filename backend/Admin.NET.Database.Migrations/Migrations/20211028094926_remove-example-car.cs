using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class removeexamplecar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    CarName = table.Column<string>(type: "text", nullable: true),
                    CarNo = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "创建者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "修改者名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                },
                comment: "车辆信息");
        }
    }
}

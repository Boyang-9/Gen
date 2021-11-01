using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.NET.Database.Migrations.Migrations.MultiTenantDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_tenant",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, comment: "公司名称"),
                    AdminName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "管理员名称"),
                    Host = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "主机"),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "电子邮箱"),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "电话"),
                    Connection = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "数据库连接"),
                    Schema = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "架构"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
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
                    table.PrimaryKey("PK_sys_tenant", x => x.Id);
                },
                comment: "租户表");

            migrationBuilder.InsertData(
                table: "sys_tenant",
                columns: new[] { "Id", "AdminName", "Connection", "CreatedTime", "CreatedUserId", "CreatedUserName", "Email", "Host", "IsDeleted", "Name", "Phone", "Remark", "Schema", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { 142307070918780L, "SuperAdmin", "", new DateTimeOffset(new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, "515096995@163.com", "", false, "平台开发", "18020030720", null, null, null, null, null },
                    { 142307070918781L, "Admin", "", new DateTimeOffset(new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, "zuohuaijun@163.com", "", false, "公司1租户", "18020030720", null, null, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_tenant");
        }
    }
}

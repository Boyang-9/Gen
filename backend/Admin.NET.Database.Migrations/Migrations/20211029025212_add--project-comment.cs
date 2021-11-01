using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class addprojectcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserIds",
                table: "Project",
                type: "text",
                nullable: true,
                comment: "负责人",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Types",
                table: "Project",
                type: "text",
                nullable: true,
                comment: "项目类型",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportType",
                table: "Project",
                type: "text",
                nullable: true,
                comment: "支架型式",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportModel",
                table: "Project",
                type: "text",
                nullable: true,
                comment: "支架型号",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "Project",
                type: "text",
                nullable: true,
                comment: "项目备注",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ProjectDate",
                table: "Project",
                type: "timestamp with time zone",
                nullable: true,
                comment: "立项日期",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                type: "text",
                nullable: true,
                comment: "项目名称",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerMineId",
                table: "Project",
                type: "bigint",
                nullable: false,
                comment: "客户煤矿编号",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerGroupId",
                table: "Project",
                type: "bigint",
                nullable: false,
                comment: "客户集团编号",
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserIds",
                table: "Project",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "负责人");

            migrationBuilder.AlterColumn<string>(
                name: "Types",
                table: "Project",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "项目类型");

            migrationBuilder.AlterColumn<string>(
                name: "SupportType",
                table: "Project",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "支架型式");

            migrationBuilder.AlterColumn<string>(
                name: "SupportModel",
                table: "Project",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "支架型号");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "Project",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "项目备注");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ProjectDate",
                table: "Project",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "立项日期");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "项目名称");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerMineId",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "客户煤矿编号");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerGroupId",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "客户集团编号");
        }
    }
}

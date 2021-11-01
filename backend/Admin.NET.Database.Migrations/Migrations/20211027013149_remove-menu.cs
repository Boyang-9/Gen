using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class removemenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070914671L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070914672L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070914673L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070914674L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070914675L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070914676L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070914677L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918731L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918739L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918740L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918741L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918742L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918743L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918744L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918745L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "Application", "Code", "Component", "CreatedTime", "CreatedUserId", "CreatedUserName", "Icon", "IsDeleted", "Link", "Name", "OpenType", "Permission", "Pid", "Pids", "Redirect", "Remark", "Router", "Sort", "Status", "Type", "UpdatedTime", "UpdatedUserId", "UpdatedUserName", "Visible", "Weight" },
                values: new object[,]
                {
                    { 142307070914671L, "system", "sys_email_mgr", "system/email/index", null, null, null, null, false, null, "邮件发送", 1, null, 142307070914662L, "[0],[142307070914662],", null, null, "/email", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914672L, "system", "sys_email_mgr_send_email", null, null, null, null, null, false, null, "发送文本邮件", 0, "email:sendEmail", 142307070914671L, "[0],[142307070914662],[142307070914671],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914673L, "system", "sys_email_mgr_send_email_html", null, null, null, null, null, false, null, "发送html邮件", 0, "email:sendEmailHtml", 142307070914671L, "[0],[142307070914662],[142307070914671],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914674L, "system", "sys_sms_mgr", "system/sms/index", null, null, null, null, false, null, "短信管理", 1, null, 142307070914662L, "[0],[142307070914662],", null, null, "/sms", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914675L, "system", "sys_sms_mgr_page", null, null, null, null, null, false, null, "短信发送查询", 0, "sms:page", 142307070914674L, "[0],[142307070914662],[142307070914674],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914676L, "system", "sys_sms_mgr_send_login_message", null, null, null, null, null, false, null, "发送验证码短信", 0, "sms:sendLoginMessage", 142307070914674L, "[0],[142307070914662],[142307070914674],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914677L, "system", "sys_sms_mgr_validate_message", null, null, null, null, null, false, null, "验证短信验证码", 0, "sms:validateMessage", 142307070914674L, "[0],[142307070914662],[142307070914674],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918731L, "system", "sys_swagger_mgr", "Iframe", null, null, null, null, false, "http://localhost:5566/", "接口文档", 2, null, 142307070914662L, "[0],[142307070914662],", null, null, "/swagger", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918739L, "system", "sys_monitor_mgr", "PageView", null, null, null, "deployment-unit", false, null, "系统监控", 0, null, 0L, "[0],", null, null, "/monitor", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070918740L, "system", "sys_monitor_mgr_machine_monitor", "system/machine/index", null, null, null, null, false, null, "服务监控", 1, null, 142307070918739L, "[0],[142307070918739],", null, null, "/machine", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918741L, "system", "sys_monitor_mgr_machine_monitor_query", null, null, null, null, null, false, null, "服务监控查询", 0, "sysMachine:query", 142307070918740L, "[0],[142307070918739],[142307070918740],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918742L, "system", "sys_monitor_mgr_online_user", "system/onlineUser/index", null, null, null, null, false, null, "在线用户", 1, null, 142307070918739L, "[0],[142307070918739],", null, null, "/onlineUser", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918743L, "system", "sys_monitor_mgr_online_user_page", null, null, null, null, null, false, null, "在线用户查询", 0, "sysOnlineUser:page", 142307070918742L, "[0],[142307070918739],[142307070918742],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918744L, "system", "sys_monitor_mgr_online_user_force_exist", null, null, null, null, null, false, null, "在线用户强退", 0, "sysOnlineUser:forceExist", 142307070918742L, "[0],[142307070918739],[142307070918742],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918745L, "system", "sys_monitor_mgr_druid", "Iframe", null, null, null, null, false, "http://localhost:82/druid/login.html", "数据监控", 2, null, 142307070918739L, "[0],[142307070918739],", null, null, "/druid", 100, 0, 1, null, null, null, "N", 1 }
                });
        }
    }
}

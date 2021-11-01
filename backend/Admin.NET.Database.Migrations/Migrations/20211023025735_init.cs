using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    CarName = table.Column<string>(type: "text", nullable: true),
                    CarNo = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Car", x => x.Id);
                },
                comment: "车辆信息");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Pid = table.Column<long>(type: "bigint", nullable: false, comment: "父Id"),
                    Pids = table.Column<string>(type: "text", nullable: true, comment: "父Ids"),
                    MineGroupId = table.Column<long>(type: "bigint", nullable: false, comment: "煤矿所属集团"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "名称"),
                    CustomerType = table.Column<int>(type: "integer", nullable: false, comment: "客户组织类型"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
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
                    table.PrimaryKey("PK_Customer", x => x.Id);
                },
                comment: "客户组织机构表");

            migrationBuilder.CreateTable(
                name: "sys_app",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编码"),
                    Active = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "是否默认激活"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
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
                    table.PrimaryKey("PK_sys_app", x => x.Id);
                },
                comment: "系统应用表");

            migrationBuilder.CreateTable(
                name: "sys_code_gen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    AuthorName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "作者姓名"),
                    TablePrefix = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "是否移除表前缀"),
                    GenerateType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "生成方式"),
                    TableName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "数据库表名"),
                    NameSpace = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "命名空间"),
                    BusName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "业务名"),
                    MenuApplication = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "菜单应用分类"),
                    MenuPid = table.Column<long>(type: "bigint", nullable: false, comment: "菜单编码"),
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
                    table.PrimaryKey("PK_sys_code_gen", x => x.Id);
                },
                comment: "代码生成表");

            migrationBuilder.CreateTable(
                name: "sys_code_gen_config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    CodeGenId = table.Column<long>(type: "bigint", nullable: false, comment: "代码生成主表ID"),
                    ColumnName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "数据库字段名"),
                    ColumnComment = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "字段描述"),
                    NetType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: ".NET数据类型"),
                    EffectType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "作用类型"),
                    FkEntityName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "外键实体名称"),
                    FkColumnName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "外键显示字段"),
                    FkColumnNetType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "外键显示字段.NET类型"),
                    DictTypeCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "字典Code"),
                    WhetherRetract = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "列表是否缩进"),
                    WhetherRequired = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "是否必填"),
                    QueryWhether = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "是否是查询条件"),
                    QueryType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "查询方式"),
                    WhetherTable = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "列表显示"),
                    WhetherOrderBy = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "列表是否排序"),
                    WhetherAddUpdate = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "增改"),
                    ColumnKey = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "主键"),
                    DataType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "数据库中类型"),
                    WhetherCommon = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "是否通用字段"),
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
                    table.PrimaryKey("PK_sys_code_gen_config", x => x.Id);
                },
                comment: "代码生成字段配置表");

            migrationBuilder.CreateTable(
                name: "sys_config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编码"),
                    Value = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "属性值"),
                    SysFlag = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "是否是系统参数"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
                    GroupCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "常量所属分类的编码"),
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
                    table.PrimaryKey("PK_sys_config", x => x.Id);
                },
                comment: "参数配置表");

            migrationBuilder.CreateTable(
                name: "sys_dict_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编码"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
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
                    table.PrimaryKey("PK_sys_dict_type", x => x.Id);
                },
                comment: "字典类型表");

            migrationBuilder.CreateTable(
                name: "sys_emp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    JobNum = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true, comment: "工号"),
                    OrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id"),
                    OrgName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "机构名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_emp", x => x.Id);
                },
                comment: "员工表");

            migrationBuilder.CreateTable(
                name: "sys_file",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    FileLocation = table.Column<int>(type: "integer", nullable: false, comment: "文件存储位置"),
                    FileBucket = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "文件仓库"),
                    FileOriginName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "文件名称"),
                    FileSuffix = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "文件后缀"),
                    FileSizeKb = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "文件大小kb"),
                    FileSizeInfo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "文件大小信息"),
                    FileObjectName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "存储到bucket的名称"),
                    FilePath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "存储路径"),
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
                    table.PrimaryKey("PK_sys_file", x => x.Id);
                },
                comment: "文件信息表");

            migrationBuilder.CreateTable(
                name: "sys_log_audit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "表名"),
                    ColumnName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "列名"),
                    NewValue = table.Column<string>(type: "text", nullable: true, comment: "新值"),
                    OldValue = table.Column<string>(type: "text", nullable: true, comment: "旧值"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "操作时间"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "操作人Id"),
                    UserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "操作人名称"),
                    Operate = table.Column<int>(type: "integer", nullable: false, comment: "操作方式"),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_audit", x => x.Id);
                },
                comment: "审计日志表");

            migrationBuilder.CreateTable(
                name: "sys_log_ex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Account = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "操作人"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "名称"),
                    ClassName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "类名"),
                    MethodName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "方法名"),
                    ExceptionName = table.Column<string>(type: "text", nullable: true, comment: "异常名称"),
                    ExceptionMsg = table.Column<string>(type: "text", nullable: true, comment: "异常信息"),
                    ExceptionSource = table.Column<string>(type: "text", nullable: true, comment: "异常源"),
                    StackTrace = table.Column<string>(type: "text", nullable: true, comment: "堆栈信息"),
                    ParamsObj = table.Column<string>(type: "text", nullable: true, comment: "参数对象"),
                    ExceptionTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "异常时间"),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_ex", x => x.Id);
                },
                comment: "异常日志表");

            migrationBuilder.CreateTable(
                name: "sys_log_op",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "名称"),
                    Success = table.Column<int>(type: "integer", nullable: false, comment: "是否执行成功"),
                    Message = table.Column<string>(type: "text", nullable: true, comment: "具体消息"),
                    Ip = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "IP"),
                    Location = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "地址"),
                    Browser = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "浏览器"),
                    Os = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "操作系统"),
                    Url = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "请求地址"),
                    ClassName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "类名称"),
                    MethodName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "方法名称"),
                    ReqMethod = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "请求方式"),
                    Param = table.Column<string>(type: "text", nullable: true, comment: "请求参数"),
                    Result = table.Column<string>(type: "text", nullable: true, comment: "返回结果"),
                    ElapsedTime = table.Column<long>(type: "bigint", nullable: false, comment: "耗时"),
                    OpTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "操作时间"),
                    Account = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "操作人"),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_op", x => x.Id);
                },
                comment: "操作日志表");

            migrationBuilder.CreateTable(
                name: "sys_log_vis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "名称"),
                    Success = table.Column<int>(type: "integer", nullable: false, comment: "是否执行成功"),
                    Message = table.Column<string>(type: "text", nullable: true, comment: "具体消息"),
                    Ip = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "IP"),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "地址"),
                    Browser = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "浏览器"),
                    Os = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "操作系统"),
                    VisType = table.Column<int>(type: "integer", nullable: false, comment: "访问类型"),
                    VisTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "访问时间"),
                    Account = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "访问人"),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_log_vis", x => x.Id);
                },
                comment: "访问日志表");

            migrationBuilder.CreateTable(
                name: "sys_menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Pid = table.Column<long>(type: "bigint", nullable: false, comment: "父Id"),
                    Pids = table.Column<string>(type: "text", nullable: true, comment: "父Ids"),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编码"),
                    Type = table.Column<int>(type: "integer", nullable: false, comment: "菜单类型"),
                    Icon = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "图标"),
                    Router = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "路由地址"),
                    Component = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "组件地址"),
                    Permission = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "权限标识"),
                    Application = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "应用分类"),
                    OpenType = table.Column<int>(type: "integer", nullable: false, comment: "打开方式"),
                    Visible = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "是否可见"),
                    Link = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "内链地址"),
                    Redirect = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "重定向地址"),
                    Weight = table.Column<int>(type: "integer", nullable: false, comment: "权重"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_sys_menu", x => x.Id);
                },
                comment: "菜单表");

            migrationBuilder.CreateTable(
                name: "sys_notice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "标题"),
                    Content = table.Column<string>(type: "text", nullable: false, comment: "内容"),
                    Type = table.Column<int>(type: "integer", nullable: false, comment: "类型"),
                    PublicUserId = table.Column<long>(type: "bigint", nullable: false, comment: "发布人Id"),
                    PublicUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "发布人姓名"),
                    PublicOrgId = table.Column<long>(type: "bigint", nullable: false, comment: "发布机构Id"),
                    PublicOrgName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "发布机构名称"),
                    PublicTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "发布时间"),
                    CancelTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "撤回时间"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
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
                    table.PrimaryKey("PK_sys_notice", x => x.Id);
                },
                comment: "通知公告表");

            migrationBuilder.CreateTable(
                name: "sys_notice_user",
                columns: table => new
                {
                    NoticeId = table.Column<long>(type: "bigint", nullable: false, comment: "通知公告Id"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    ReadTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "阅读时间"),
                    ReadStatus = table.Column<int>(type: "integer", nullable: false, comment: "状态")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_notice_user", x => new { x.NoticeId, x.UserId });
                },
                comment: "通知公告用户表");

            migrationBuilder.CreateTable(
                name: "sys_oauth_user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Uuid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "UUID"),
                    AccessToken = table.Column<string>(type: "text", nullable: true, comment: "Token"),
                    NickName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "昵称"),
                    Avatar = table.Column<string>(type: "text", nullable: true, comment: "头像"),
                    Gender = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true, comment: "性别"),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "电话"),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "邮箱"),
                    Location = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "位置"),
                    Blog = table.Column<string>(type: "text", nullable: true, comment: "用户网址"),
                    Company = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "所在公司"),
                    Source = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "用户来源"),
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
                    table.PrimaryKey("PK_sys_oauth_user", x => x.Id);
                },
                comment: "Oauth登录用户表");

            migrationBuilder.CreateTable(
                name: "sys_org",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Pid = table.Column<long>(type: "bigint", nullable: false, comment: "父Id"),
                    Pids = table.Column<string>(type: "text", nullable: true, comment: "父Ids"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编码"),
                    Contacts = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "联系人"),
                    Tel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "电话"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
                    OrgType = table.Column<int>(type: "integer", nullable: false, comment: "机构类型-品牌_1、总店(加盟/直营)_2、直营店_3、加盟店_4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记"),
                    TenantId = table.Column<long>(type: "bigint", nullable: true, comment: "租户id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_org", x => x.Id);
                },
                comment: "组织机构表");

            migrationBuilder.CreateTable(
                name: "sys_pos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编码"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记"),
                    TenantId = table.Column<long>(type: "bigint", nullable: true, comment: "租户id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_pos", x => x.Id);
                },
                comment: "职位表");

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "编码"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
                    DataScopeType = table.Column<int>(type: "integer", nullable: false, comment: "数据范围类型"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
                    RoleType = table.Column<int>(type: "integer", nullable: false, comment: "角色类型-集团角色_0、加盟商角色_1、门店角色_2"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记"),
                    TenantId = table.Column<long>(type: "bigint", nullable: true, comment: "租户id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.Id);
                },
                comment: "角色表");

            migrationBuilder.CreateTable(
                name: "sys_timer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    JobName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "任务名称"),
                    DoOnce = table.Column<bool>(type: "boolean", nullable: false, comment: "只执行一次"),
                    StartNow = table.Column<bool>(type: "boolean", nullable: false, comment: "立即执行"),
                    ExecuteType = table.Column<int>(type: "integer", nullable: false, comment: "执行类型"),
                    Interval = table.Column<int>(type: "integer", nullable: true, comment: "间隔时间"),
                    Cron = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "Cron表达式"),
                    TimerType = table.Column<int>(type: "integer", nullable: false, comment: "定时器类型"),
                    RequestUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true, comment: "请求url"),
                    RequestParameters = table.Column<string>(type: "text", nullable: true, comment: "请求参数"),
                    Headers = table.Column<string>(type: "text", nullable: true, comment: "Headers"),
                    RequestType = table.Column<int>(type: "integer", nullable: false, comment: "请求类型"),
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
                    table.PrimaryKey("PK_sys_timer", x => x.Id);
                },
                comment: "定时任务表");

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Account = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "账号"),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "密码"),
                    NickName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "昵称"),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "姓名"),
                    Avatar = table.Column<string>(type: "text", nullable: true, comment: "头像"),
                    Birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "生日"),
                    Sex = table.Column<int>(type: "integer", nullable: false, comment: "性别-男_1、女_2"),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "邮箱"),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "手机"),
                    Tel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "电话"),
                    LastLoginIp = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "最后登录IP"),
                    LastLoginTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "最后登录时间"),
                    AdminType = table.Column<int>(type: "integer", nullable: false, comment: "管理员类型-超级管理员_1、管理员_2、普通账号_3"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态-正常_0、停用_1、删除_2"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记"),
                    TenantId = table.Column<long>(type: "bigint", nullable: true, comment: "租户id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.Id);
                },
                comment: "用户表");

            migrationBuilder.CreateTable(
                name: "sys_dict_data",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    TypeId = table.Column<long>(type: "bigint", nullable: false, comment: "字典类型Id"),
                    Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "值"),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "编码"),
                    Sort = table.Column<int>(type: "integer", nullable: false, comment: "排序"),
                    Remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "备注"),
                    Status = table.Column<int>(type: "integer", nullable: false, comment: "状态"),
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
                    table.PrimaryKey("PK_sys_dict_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_dict_data_sys_dict_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "sys_dict_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "字典值表");

            migrationBuilder.CreateTable(
                name: "sys_emp_ext_org_pos",
                columns: table => new
                {
                    SysEmpId = table.Column<long>(type: "bigint", nullable: false, comment: "员工Id"),
                    SysOrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id"),
                    SysPosId = table.Column<long>(type: "bigint", nullable: false, comment: "职位Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_emp_ext_org_pos", x => new { x.SysEmpId, x.SysOrgId, x.SysPosId });
                    table.ForeignKey(
                        name: "FK_sys_emp_ext_org_pos_sys_emp_SysEmpId",
                        column: x => x.SysEmpId,
                        principalTable: "sys_emp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_emp_ext_org_pos_sys_org_SysOrgId",
                        column: x => x.SysOrgId,
                        principalTable: "sys_org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_emp_ext_org_pos_sys_pos_SysPosId",
                        column: x => x.SysPosId,
                        principalTable: "sys_pos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工附属机构职位表");

            migrationBuilder.CreateTable(
                name: "sys_emp_pos",
                columns: table => new
                {
                    SysEmpId = table.Column<long>(type: "bigint", nullable: false, comment: "员工Id"),
                    SysPosId = table.Column<long>(type: "bigint", nullable: false, comment: "职位Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_emp_pos", x => new { x.SysEmpId, x.SysPosId });
                    table.ForeignKey(
                        name: "FK_sys_emp_pos_sys_emp_SysEmpId",
                        column: x => x.SysEmpId,
                        principalTable: "sys_emp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_emp_pos_sys_pos_SysPosId",
                        column: x => x.SysPosId,
                        principalTable: "sys_pos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "员工职位表");

            migrationBuilder.CreateTable(
                name: "sys_role_data_scope",
                columns: table => new
                {
                    SysRoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id"),
                    SysOrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role_data_scope", x => new { x.SysRoleId, x.SysOrgId });
                    table.ForeignKey(
                        name: "FK_sys_role_data_scope_sys_org_SysOrgId",
                        column: x => x.SysOrgId,
                        principalTable: "sys_org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_role_data_scope_sys_role_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "sys_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色数据范围表");

            migrationBuilder.CreateTable(
                name: "sys_role_menu",
                columns: table => new
                {
                    SysRoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id"),
                    SysMenuId = table.Column<long>(type: "bigint", nullable: false, comment: "菜单Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role_menu", x => new { x.SysRoleId, x.SysMenuId });
                    table.ForeignKey(
                        name: "FK_sys_role_menu_sys_menu_SysMenuId",
                        column: x => x.SysMenuId,
                        principalTable: "sys_menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_role_menu_sys_role_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "sys_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色菜单表");

            migrationBuilder.CreateTable(
                name: "sys_user_data_scope",
                columns: table => new
                {
                    SysUserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    SysOrgId = table.Column<long>(type: "bigint", nullable: false, comment: "机构Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_data_scope", x => new { x.SysUserId, x.SysOrgId });
                    table.ForeignKey(
                        name: "FK_sys_user_data_scope_sys_org_SysOrgId",
                        column: x => x.SysOrgId,
                        principalTable: "sys_org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_user_data_scope_sys_user_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "sys_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户数据范围表");

            migrationBuilder.CreateTable(
                name: "sys_user_role",
                columns: table => new
                {
                    SysUserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户Id"),
                    SysRoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_role", x => new { x.SysUserId, x.SysRoleId });
                    table.ForeignKey(
                        name: "FK_sys_user_role_sys_role_SysRoleId",
                        column: x => x.SysRoleId,
                        principalTable: "sys_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_user_role_sys_user_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "sys_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户角色表");

            migrationBuilder.InsertData(
                table: "sys_app",
                columns: new[] { "Id", "Active", "Code", "CreatedTime", "CreatedUserId", "CreatedUserName", "IsDeleted", "Name", "Sort", "Status", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { 142307070898245L, "Y", "system", null, null, null, false, "平台管理", 100, 0, null, null, null },
                    { 142307070922826L, "N", "platform", null, null, null, false, "运营管理", 200, 1, null, null, null },
                    { 142307070902341L, "N", "manage", null, null, null, false, "系统管理", 300, 0, null, null, null },
                    { 142307070922869L, "N", "busiapp", null, null, null, false, "业务应用", 400, 0, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "sys_config",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "CreatedUserName", "GroupCode", "IsDeleted", "Name", "Remark", "Status", "SysFlag", "UpdatedTime", "UpdatedUserId", "UpdatedUserName", "Value" },
                values: new object[,]
                {
                    { 142307070902360L, "DILON_EMAIL_FROM", null, null, null, "EMAIL", false, "邮箱发件人", "邮箱发件人", 0, "Y", null, null, null, "test@126.com" },
                    { 142307070902362L, "DILON_FILE_UPLOAD_PATH_FOR_LINUX", null, null, null, "FILE_PATH", false, "Linux/Mac本地上传文件路径", "Linux/Mac本地上传文件路径", 0, "Y", null, null, null, "/tmp" },
                    { 142307070902363L, "DILON_UN_XSS_FILTER_URL", null, null, null, "DEFAULT", false, "放开XSS过滤的接口", "多个url可以用英文逗号隔开", 0, "Y", null, null, null, "/demo/xssfilter,/demo/unxss" },
                    { 142307070902364L, "DILON_ENABLE_SINGLE_LOGIN", null, null, null, "DEFAULT", false, "单用户登陆的开关", "true-打开，false-关闭，如果一个人登录两次，就会将上一次登陆挤下去", 0, "Y", null, null, null, "false" },
                    { 142307070902365L, "DILON_CAPTCHA_OPEN", null, null, null, "DEFAULT", false, "登录验证码的开关", "true-打开，false-关闭", 0, "Y", null, null, null, "false" },
                    { 142307070902366L, "DILON_DRUID_USERNAME", null, null, null, "DEFAULT", false, "Druid监控登录账号", "Druid监控登录账号", 0, "Y", null, null, null, "superAdmin" },
                    { 142307070902367L, "DILON_DRUID_PASSWORD", null, null, null, "DEFAULT", false, "Druid监控界面登录密码", "Druid监控界面登录密码", 0, "Y", null, null, null, "123456" },
                    { 142307070902369L, "DILON_IP_GEO_APP_CODE", null, null, null, "DEFAULT", false, "阿里云定位appCode", "阿里云定位appCode", 0, "Y", null, null, null, "461535aabeae4f34861884d392f5d452" },
                    { 142307070902359L, "DILON_EMAIL_SSL", null, null, null, "EMAIL", false, "邮箱是否开启ssl", "邮箱是否开启ssl", 0, "Y", null, null, null, "true" },
                    { 142307070902370L, "DILON_ENABLE_OAUTH_LOGIN", null, null, null, "OAUTH", false, "Oauth用户登录的开关", "Oauth用户登录的开关", 0, "Y", null, null, null, "true" },
                    { 142307070902371L, "DILON_OAUTH_GITEE_CLIENT_ID", null, null, null, "OAUTH", false, "Oauth码云登录ClientId", "Oauth码云登录ClientId", 0, "Y", null, null, null, "你的clientId" },
                    { 142307070902372L, "DILON_OAUTH_GITEE_CLIENT_SECRET", null, null, null, "OAUTH", false, "Oauth码云登录ClientSecret", "Oauth码云登录ClientSecret", 0, "Y", null, null, null, "你的clientSecret" },
                    { 142307070902373L, "DILON_OAUTH_GITEE_REDIRECT_URI", null, null, null, "OAUTH", false, "Oauth码云登录回调地址", "Oauth码云登录回调地址", 0, "Y", null, null, null, "http://127.0.0.1:5566/oauth/callback/gitee" },
                    { 142307070902374L, "DILON_DEMO_ENV_FLAG", null, null, null, "DEFAULT", false, "演示环境", "演示环境的开关,true-打开，false-关闭，如果演示环境开启，则只能读数据不能写数据", 0, "Y", null, null, null, "false" },
                    { 142307070902368L, "DILON_IP_GEO_API", null, null, null, "DEFAULT", false, "阿里云定位api接口地址", "阿里云定位api接口地址", 0, "Y", null, null, null, "http://api01.aliyun.venuscn.com/ip?ip=%s" },
                    { 142307070902358L, "DILON_EMAIL_PORT", null, null, null, "EMAIL", false, "邮箱端口", "邮箱端口", 0, "Y", null, null, null, "465" },
                    { 142307070902361L, "DILON_FILE_UPLOAD_PATH_FOR_WINDOWS", null, null, null, "FILE_PATH", false, "Win本地上传文件路径", "Win本地上传文件路径", 0, "Y", null, null, null, "D:/tmp" },
                    { 142307070902356L, "DILON_EMAIL_USERNAME", null, null, null, "EMAIL", false, "邮箱用户名", "邮箱用户名", 0, "Y", null, null, null, "test@126.com" },
                    { 142307070902342L, "DILON_JWT_SECRET", null, null, null, "DEFAULT", false, "jwt密钥", "（重要）jwt密钥，默认为空，自行设置", 0, "Y", null, null, null, "xiaonuo" },
                    { 142307070902343L, "DILON_DEFAULT_PASSWORD", null, null, null, "DEFAULT", false, "默认密码", "默认密码", 0, "Y", null, null, null, "123456" },
                    { 142307070902357L, "DILON_EMAIL_PASSWORD", null, null, null, "EMAIL", false, "邮箱密码", "邮箱密码", 0, "Y", null, null, null, "你的邮箱密码" },
                    { 142307070902345L, "DILON_SESSION_EXPIRE", null, null, null, "DEFAULT", false, "session会话过期时间", "session会话过期时间（单位：秒）", 0, "Y", null, null, null, "7200" },
                    { 142307070902346L, "DILON_ALIYUN_SMS_ACCESSKEY_ID", null, null, null, "ALIYUN_SMS", false, "阿里云短信keyId", "阿里云短信keyId", 0, "Y", null, null, null, "你的keyId" },
                    { 142307070902347L, "DILON_ALIYUN_SMS_ACCESSKEY_SECRET", null, null, null, "ALIYUN_SMS", false, "阿里云短信secret", "阿里云短信secret", 0, "Y", null, null, null, "你的secret" },
                    { 142307070902348L, "DILON_ALIYUN_SMS_SIGN_NAME", null, null, null, "ALIYUN_SMS", false, "阿里云短信签名", "阿里云短信签名", 0, "Y", null, null, null, "你的签名" },
                    { 142307070902344L, "DILON_TOKEN_EXPIRE", null, null, null, "DEFAULT", false, "token过期时间", "token过期时间（单位：秒）", 0, "Y", null, null, null, "86400" },
                    { 142307070902350L, "DILON_ALIYUN_SMS_INVALIDATE_MINUTES", null, null, null, "ALIYUN_SMS", false, "阿里云短信默认失效时间", "阿里云短信默认失效时间（单位：分钟）", 0, "Y", null, null, null, "5" },
                    { 142307070902351L, "DILON_TENCENT_SMS_SECRET_ID", null, null, null, "TENCENT_SMS", false, "腾讯云短信secretId", "腾讯云短信secretId", 0, "Y", null, null, null, "你的secretId" },
                    { 142307070902352L, "DILON_TENCENT_SMS_SECRET_KEY", null, null, null, "TENCENT_SMS", false, "腾讯云短信secretKey", "腾讯云短信secretKey", 0, "Y", null, null, null, "你的secretkey" },
                    { 142307070902353L, "DILON_TENCENT_SMS_SDK_APP_ID", null, null, null, "TENCENT_SMS", false, "腾讯云短信sdkAppId", "腾讯云短信sdkAppId", 0, "Y", null, null, null, "1400375123" },
                    { 142307070902354L, "DILON_TENCENT_SMS_SIGN", null, null, null, "TENCENT_SMS", false, "腾讯云短信签名", "腾讯云短信签名", 0, "Y", null, null, null, "你的签名" },
                    { 142307070902355L, "DILON_EMAIL_HOST", null, null, null, "EMAIL", false, "邮箱host", "邮箱host", 0, "Y", null, null, null, "smtp.126.com" },
                    { 142307070902349L, "DILON_ALIYUN_SMS_LOGIN_TEMPLATE_CODE", null, null, null, "ALIYUN_SMS", false, "阿里云短信-登录模板号", "阿里云短信-登录模板号", 0, "Y", null, null, null, "SMS_1877123456" }
                });

            migrationBuilder.InsertData(
                table: "sys_dict_type",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "CreatedUserName", "IsDeleted", "Name", "Remark", "Sort", "Status", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { 142307070910534L, "notice_type", null, null, null, false, "通知公告类型", "通知公告类型", 100, 0, null, null, null },
                    { 142307070910535L, "notice_status", null, null, null, false, "通知公告状态", "通知公告状态", 100, 0, null, null, null },
                    { 142307070910536L, "yes_true_false", null, null, null, false, "是否boolean", "是否boolean", 100, 0, null, null, null },
                    { 142307070910538L, "request_type", null, null, null, false, "请求方式", "请求方式", 100, 0, null, null, null },
                    { 142307070926941L, "role_type", null, null, null, false, "角色类型", "角色类型", 100, 0, null, null, null },
                    { 142307070922828L, "code_gen_query_type", null, null, null, false, "代码生成查询类型", "代码生成查询类型", 100, 0, null, null, null },
                    { 142307070922829L, "code_gen_net_type", null, null, null, false, "代码生成.NET类型", "代码生成.NET类型", 100, 0, null, null, null },
                    { 142307070926942L, "org_type", null, null, null, false, "机构类型", "机构类型", 100, 0, null, null, null },
                    { 142307070910533L, "run_status", null, null, null, false, "运行状态", "定时任务运行状态", 100, 0, null, null, null },
                    { 142307070922827L, "code_gen_effect_type", null, null, null, false, "代码生成作用类型", "代码生成作用类型", 100, 0, null, null, null },
                    { 142307070906495L, "file_storage_location", null, null, null, false, "文件存储位置", "文件存储位置", 100, 0, null, null, null },
                    { 142307070910537L, "code_gen_create_type", null, null, null, false, "代码生成方式", "代码生成方式", 100, 0, null, null, null },
                    { 142307070906493L, "sms_send_source", null, null, null, false, "短信发送来源", "短信发送来源", 100, 0, null, null, null },
                    { 142307070906492L, "data_scope_type", null, null, null, false, "数据范围类型", "数据范围类型", 100, 0, null, null, null },
                    { 142307070906491L, "menu_weight", null, null, null, false, "菜单权重", "菜单权重", 100, 0, null, null, null },
                    { 142307070906490L, "open_type", null, null, null, false, "打开方式", "打开方式", 100, 0, null, null, null },
                    { 142307070906489L, "send_type", null, null, null, false, "发送类型", "发送类型", 100, 0, null, null, null },
                    { 142307070906494L, "op_type", null, null, null, false, "操作类型", "操作类型", 100, 0, null, null, null },
                    { 142307070906488L, "menu_type", null, null, null, false, "菜单类型", "菜单类型", 100, 0, null, null, null },
                    { 142307070906487L, "vis_type", null, null, null, false, "访问类型", "访问类型", 100, 0, null, null, null },
                    { 142307070906486L, "yes_or_no", null, null, null, false, "是否", "是否", 100, 0, null, null, null },
                    { 142307070906485L, "consts_type", null, null, null, false, "常量的分类", "常量的分类，用于区别一组配置", 100, 0, null, null, null },
                    { 142307070906484L, "sex", null, null, null, false, "性别", "性别字典", 100, 0, null, null, null },
                    { 142307070906483L, "common_status", null, null, null, false, "通用状态", "通用状态", 100, 0, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "sys_emp",
                columns: new[] { "Id", "JobNum", "OrgId", "OrgName" },
                values: new object[,]
                {
                    { 142307070910559L, "D1003", 142307070910548L, "租户2公司" },
                    { 142307070910557L, "D1001", 142307070910548L, "租户2公司" },
                    { 142307070910556L, "D1003", 142307070910547L, "租户1公司" },
                    { 142307070910555L, "D1002", 142307070910547L, "租户1公司" },
                    { 142307070910558L, "D1002", 142307070910548L, "租户2公司" },
                    { 142307070910553L, "D1003", 142307070910539L, "华夏集团" },
                    { 142307070910552L, "D1002", 142307070910539L, "华夏集团" },
                    { 142307070910551L, "D1001", 142307070910539L, "华夏集团" },
                    { 142307070910554L, "D1001", 142307070910547L, "租户1公司" }
                });

            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "Application", "Code", "Component", "CreatedTime", "CreatedUserId", "CreatedUserName", "Icon", "IsDeleted", "Link", "Name", "OpenType", "Permission", "Pid", "Pids", "Redirect", "Remark", "Router", "Sort", "Status", "Type", "UpdatedTime", "UpdatedUserId", "UpdatedUserName", "Visible", "Weight" },
                values: new object[,]
                {
                    { 142307070911740L, "manage", "sys_log_mgr_ex_log_page", null, null, null, null, null, false, null, "异常日志查询", 0, "sysExLog:page", 142307070911739L, "[0],[142307070918732],[142307070911739],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070911741L, "manage", "sys_log_mgr_ex_log_delete", null, null, null, null, null, false, null, "异常日志清空", 0, "sysExLog:delete", 142307070911739L, "[0],[142307070918732],[142307070911739],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918739L, "system", "sys_monitor_mgr", "PageView", null, null, null, "deployment-unit", false, null, "系统监控", 0, null, 0L, "[0],", null, null, "/monitor", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070918740L, "system", "sys_monitor_mgr_machine_monitor", "system/machine/index", null, null, null, null, false, null, "服务监控", 1, null, 142307070918739L, "[0],[142307070918739],", null, null, "/machine", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918741L, "system", "sys_monitor_mgr_machine_monitor_query", null, null, null, null, null, false, null, "服务监控查询", 0, "sysMachine:query", 142307070918740L, "[0],[142307070918739],[142307070918740],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918742L, "system", "sys_monitor_mgr_online_user", "system/onlineUser/index", null, null, null, null, false, null, "在线用户", 1, null, 142307070918739L, "[0],[142307070918739],", null, null, "/onlineUser", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918743L, "system", "sys_monitor_mgr_online_user_page", null, null, null, null, null, false, null, "在线用户查询", 0, "sysOnlineUser:page", 142307070918742L, "[0],[142307070918739],[142307070918742],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918752L, "manage", "sys_notice_mgr_detail", null, null, null, null, null, false, null, "公告查看", 0, "sysNotice:detail", 142307070918747L, "[0],[142307070918746],[142307070918747],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918745L, "system", "sys_monitor_mgr_druid", "Iframe", null, null, null, null, false, "http://localhost:82/druid/login.html", "数据监控", 2, null, 142307070918739L, "[0],[142307070918739],", null, null, "/druid", 100, 0, 1, null, null, null, "N", 1 },
                    { 142307070918746L, "manage", "sys_notice", "PageView", null, null, null, "sound", false, null, "通知公告", 0, null, 0L, "[0],", null, null, "/notice", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070918747L, "manage", "sys_notice_mgr", "system/notice/index", null, null, null, null, false, null, "公告管理", 1, null, 142307070918746L, "[0],[142307070918746],", null, null, "/notice", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918748L, "manage", "sys_notice_mgr_page", null, null, null, null, null, false, null, "公告查询", 0, "sysNotice:page", 142307070918747L, "[0],[142307070918746],[142307070918747],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918749L, "manage", "sys_notice_mgr_add", null, null, null, null, null, false, null, "公告增加", 0, "sysNotice:add", 142307070918747L, "[0],[142307070918746],[142307070918747],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918750L, "manage", "sys_notice_mgr_edit", null, null, null, null, null, false, null, "公告编辑", 0, "sysNotice:edit", 142307070918747L, "[0],[142307070918746],[142307070918747],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918751L, "manage", "sys_notice_mgr_delete", null, null, null, null, null, false, null, "公告删除", 0, "sysNotice:delete", 142307070918747L, "[0],[142307070918746],[142307070918747],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070911739L, "manage", "sys_log_mgr_ex_log", "system/log/exlog/index", null, null, null, null, false, null, "异常日志", 1, null, 142307070918732L, "[0],[142307070918732],", null, null, "/exlog", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918744L, "system", "sys_monitor_mgr_online_user_force_exist", null, null, null, null, null, false, null, "在线用户强退", 0, "sysOnlineUser:forceExist", 142307070918742L, "[0],[142307070918739],[142307070918742],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918738L, "manage", "sys_log_mgr_op_log_delete", null, null, null, null, null, false, null, "操作日志清空", 0, "sysOpLog:delete", 142307070918736L, "[0],[142307070918732],[142307070918736],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918727L, "system", "sys_dict_mgr_dict_delete", null, null, null, null, null, false, null, "字典值删除", 0, "sysDictData:delete", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918736L, "manage", "sys_log_mgr_op_log", "system/log/oplog/index", null, null, null, null, false, null, "操作日志", 1, null, 142307070918732L, "[0],[142307070918732],", null, null, "/oplog", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918753L, "manage", "sys_notice_mgr_changeStatus", null, null, null, null, null, false, null, "公告修改状态", 0, "sysNotice:changeStatus", 142307070918747L, "[0],[142307070918746],[142307070918747],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914682L, "system", "sys_dict_mgr_dict_type_delete", null, null, null, null, null, false, null, "字典类型删除", 0, "sysDictType:delete", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914683L, "system", "sys_dict_mgr_dict_type_edit", null, null, null, null, null, false, null, "字典类型编辑", 0, "sysDictType:edit", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914684L, "system", "sys_dict_mgr_dict_type_detail", null, null, null, null, null, false, null, "字典类型详情", 0, "sysDictType:detail", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914685L, "system", "sys_dict_mgr_dict_type_drop_down", null, null, null, null, null, false, null, "字典类型下拉", 0, "sysDictType:dropDown", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914686L, "system", "sys_dict_mgr_dict_type_change_status", null, null, null, null, null, false, null, "字典类型修改状态", 0, "sysDictType:changeStatus", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914687L, "system", "sys_dict_mgr_dict_page", null, null, null, null, null, false, null, "字典值查询", 0, "sysDictData:page", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918725L, "system", "sys_dict_mgr_dict_list", null, null, null, null, null, false, null, "字典值列表", 0, "sysDictData:list", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918726L, "system", "sys_dict_mgr_dict_add", null, null, null, null, null, false, null, "字典值增加", 0, "sysDictData:add", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918728L, "system", "sys_dict_mgr_dict_edit", null, null, null, null, null, false, null, "字典值编辑", 0, "sysDictData:edit", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918729L, "system", "sys_dict_mgr_dict_detail", null, null, null, null, null, false, null, "字典值详情", 0, "sysDictData:detail", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918730L, "system", "sys_dict_mgr_dict_change_status", null, null, null, null, null, false, null, "字典值修改状态", 0, "sysDictData:changeStatus", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918731L, "system", "sys_swagger_mgr", "Iframe", null, null, null, null, false, "http://localhost:5566/", "接口文档", 2, null, 142307070914662L, "[0],[142307070914662],", null, null, "/swagger", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918732L, "manage", "sys_log_mgr", "PageView", null, null, null, "read", false, null, "日志管理", 0, null, 0L, "[0],", null, null, "/log", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070918733L, "manage", "sys_log_mgr_vis_log", "system/log/vislog/index", null, null, null, null, false, null, "访问日志", 1, null, 142307070918732L, "[0],[142307070918732],", null, null, "/vislog", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918734L, "manage", "sys_log_mgr_vis_log_page", null, null, null, null, null, false, null, "访问日志查询", 0, "sysVisLog:page", 142307070918733L, "[0],[142307070918732],[142307070918733],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918735L, "manage", "sys_log_mgr_vis_log_delete", null, null, null, null, null, false, null, "访问日志清空", 0, "sysVisLog:delete", 142307070918733L, "[0],[142307070918732],[142307070918733],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918737L, "manage", "sys_log_mgr_op_log_page", null, null, null, null, null, false, null, "操作日志查询", 0, "sysOpLog:page", 142307070918736L, "[0],[142307070918732],[142307070918736],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918754L, "manage", "sys_notice_mgr_received", "system/noticeReceived/index", null, null, null, null, false, null, "已收公告", 1, null, 142307070918746L, "[0],[142307070918746],", null, null, "/noticeReceived", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070922827L, "platform", "sys_tenant_mgr_reset_pwd", null, null, null, null, null, false, null, "重置租户密码", 0, "sysTenant:resetPwd", 142307070918783L, "[0],[142307070918782],[142307070918783],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918756L, "manage", "sys_file_mgr", "PageView", null, null, null, "file", false, null, "文件管理", 0, null, 0L, "[0],", null, null, "/file", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070918775L, "system", "sys_timers_mgr_stop", null, null, null, null, null, false, null, "定时任务关闭", 0, "sysTimers:stop", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918776L, "system", "code_gen", "gen/codeGenerate/index", null, null, null, "thunderbolt", false, null, "代码生成", 0, null, 0L, "[0],", null, null, "/codeGenerate/index", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070922870L, "system", "form_design", "system/formDesign/index", null, null, null, "robot", false, null, "表单设计", 0, null, 0L, "[0],", null, null, "/formDesign/index", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918782L, "platform", "sys_tenant", "PageView", null, null, null, "switcher", false, null, "SaaS租户", 0, null, 0L, "[0],", null, null, "/tenant", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918783L, "platform", "sys_tenant_mgr", "system/tenant/index", null, null, null, null, false, null, "租户管理", 1, null, 142307070918782L, "[0],[142307070918782],", null, null, "/tenant", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070922821L, "platform", "sys_tenant_mgr_page", null, null, null, null, null, false, null, "租户查询", 0, "sysTenant:page", 142307070918783L, "[0],[142307070918782],[142307070918783],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922822L, "platform", "sys_tenant_mgr_detail", null, null, null, null, null, false, null, "租户详情", 0, "sysTenant:detail", 142307070918783L, "[0],[142307070918782],[142307070918783],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922823L, "platform", "sys_tenant_mgr_add", null, null, null, null, null, false, null, "租户增加", 0, "sysTenant:add", 142307070918783L, "[0],[142307070918782],[142307070918783],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922824L, "platform", "sys_tenant_mgr_delete", null, null, null, null, null, false, null, "租户删除", 0, "sysTenant:delete", 142307070918783L, "[0],[142307070918782],[142307070918783],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922825L, "platform", "sys_tenant_mgr_edit", null, null, null, null, null, false, null, "租户编辑", 0, "sysTenant:edit", 142307070918783L, "[0],[142307070918782],[142307070918783],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922826L, "platform", "sys_tenant_mgr_grant_menu", null, null, null, null, null, false, null, "授权租户菜单", 0, "sysTenant:grantMenu", 142307070918783L, "[0],[142307070918782],[142307070918783],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914681L, "system", "sys_dict_mgr_dict_type_add", null, null, null, null, null, false, null, "字典类型增加", 0, "sysDictType:add", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910560L, "busiapp", "system_index", "RouteView", null, null, null, "home", false, null, "主控面板", 0, null, 0L, "[0],", "/analysis", null, "/", 1, 0, 0, null, null, null, "Y", 2 },
                    { 142307070910561L, "busiapp", "system_index_dashboard", "system/dashboard/Analysis", null, null, null, null, false, null, "分析页", 0, null, 142307070910560L, "[0],[142307070910560],", null, null, "analysis", 100, 0, 1, null, null, null, "Y", 2 },
                    { 142307070910562L, "busiapp", "system_index_workplace", "system/dashboard/Workplace", null, null, null, null, false, null, "工作台", 0, null, 142307070910560L, "[0],[142307070910560],", null, null, "workplace", 100, 0, 1, null, null, null, "Y", 2 },
                    { 142307070922877L, "busiapp", "main_screen_monitor", "main/screenMonitor/index", null, null, null, "desktop", false, null, "大屏监控", 0, null, 0L, "[0],", null, null, "/monitor", 100, 0, 1, null, null, null, "Y", 2 },
                    { 142307070922878L, "busiapp", "main_map", "main/map/index", null, null, null, "global", false, null, "地理信息", 0, null, 0L, "[0],", null, null, "/map", 100, 0, 1, null, null, null, "Y", 2 },
                    { 142307070918774L, "system", "sys_timers_mgr_start", null, null, null, null, null, false, null, "定时任务启动", 0, "sysTimers:start", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918755L, "manage", "sys_notice_mgr_received_page", null, null, null, null, null, false, null, "已收公告查询", 0, "sysNotice:received", 142307070918754L, "[0],[142307070918746],[142307070918754],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918773L, "system", "sys_timers_mgr_get_action_classes", null, null, null, null, null, false, null, "定时任务可执行列表", 0, "sysTimers:getActionClasses", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918771L, "system", "sys_timers_mgr_delete", null, null, null, null, null, false, null, "定时任务删除", 0, "sysTimers:delete", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918757L, "manage", "sys_file_mgr_sys_file", "system/file/index", null, null, null, null, false, null, "系统文件", 1, null, 142307070918756L, "[0],[142307070918756],", null, null, "/file", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918758L, "manage", "sys_file_mgr_sys_file_page", null, null, null, null, null, false, null, "文件查询", 0, "sysFileInfo:page", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918759L, "manage", "sys_file_mgr_sys_file_list", null, null, null, null, null, false, null, "文件列表", 0, "sysFileInfo:list", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918760L, "manage", "sys_file_mgr_sys_file_delete", null, null, null, null, null, false, null, "文件删除", 0, "sysFileInfo:delete", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918761L, "manage", "sys_file_mgr_sys_file_detail", null, null, null, null, null, false, null, "文件详情", 0, "sysFileInfo:detail", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918762L, "manage", "sys_file_mgr_sys_file_upload", null, null, null, null, null, false, null, "文件上传", 0, "sysFileInfo:upload", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918763L, "manage", "sys_file_mgr_sys_file_download", null, null, null, null, null, false, null, "文件下载", 0, "sysFileInfo:download", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918764L, "manage", "sys_file_mgr_sys_file_preview", null, null, null, null, null, false, null, "图片预览", 0, "sysFileInfo:preview", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922874L, "manage", "sys_file_mgr_sys_file_upload_avatar", null, null, null, null, null, false, null, "头像上传", 0, "sysFileInfo:uploadAvatar", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922875L, "manage", "sys_file_mgr_sys_file_upload_document", null, null, null, null, null, false, null, "文档上传", 0, "sysFileInfo:uploadDocument", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070922876L, "manage", "sys_file_mgr_sys_file_upload_shop", null, null, null, null, null, false, null, "商城上传", 0, "sysFileInfo:uploadShop", 142307070918757L, "[0],[142307070918756],[142307070918757],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918765L, "system", "sys_timers", "PageView", null, null, null, "dashboard", false, null, "任务调度", 0, null, 0L, "[0],", null, null, "/timers", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070918766L, "system", "sys_timers_mgr", "system/timers/index", null, null, null, null, false, null, "任务管理", 1, null, 142307070918765L, "[0],[142307070918765],", null, null, "/timers", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918767L, "system", "sys_timers_mgr_page", null, null, null, null, null, false, null, "定时任务查询", 0, "sysTimers:page", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918768L, "system", "sys_timers_mgr_list", null, null, null, null, null, false, null, "定时任务列表", 0, "sysTimers:list", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918769L, "system", "sys_timers_mgr_detail", null, null, null, null, null, false, null, "定时任务详情", 0, "sysTimers:detail", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918770L, "system", "sys_timers_mgr_add", null, null, null, null, null, false, null, "定时任务增加", 0, "sysTimers:add", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918772L, "system", "sys_timers_mgr_edit", null, null, null, null, null, false, null, "定时任务编辑", 0, "sysTimers:edit", 142307070918766L, "[0],[142307070918765],[142307070918766],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914680L, "system", "sys_dict_mgr_dict_type_list", null, null, null, null, null, false, null, "字典类型列表", 0, "sysDictType:list", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914646L, "system", "sys_menu_mgr_delete", null, null, null, null, null, false, null, "菜单删除", 0, "sysMenu:delete", 142307070914642L, "[0],[142307070914633],[142307070914642],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914678L, "system", "sys_dict_mgr", "system/dict/index", null, null, null, null, false, null, "字典管理", 1, null, 142307070914662L, "[0],[142307070914662],", null, null, "/dict", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070910568L, "manage", "sys_user_mgr_delete", null, null, null, null, null, false, null, "用户删除", 0, "sysUser:delete", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910569L, "manage", "sys_user_mgr_detail", null, null, null, null, null, false, null, "用户详情", 0, "sysUser:detail", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910570L, "manage", "sys_user_mgr_export", null, null, null, null, null, false, null, "用户导出", 0, "sysUser:export", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914679L, "system", "sys_dict_mgr_dict_type_page", null, null, null, null, null, false, null, "字典类型查询", 0, "sysDictType:page", 142307070914678L, "[0],[142307070914662],[142307070914678],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910572L, "manage", "sys_user_mgr_grant_role", null, null, null, null, null, false, null, "用户授权角色", 0, "sysUser:grantRole", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910573L, "manage", "sys_user_mgr_own_role", null, null, null, null, null, false, null, "用户拥有角色", 0, "sysUser:ownRole", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910574L, "manage", "sys_user_mgr_grant_data", null, null, null, null, null, false, null, "用户授权数据", 0, "sysUser:grantData", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910567L, "manage", "sys_user_mgr_add", null, null, null, null, null, false, null, "用户增加", 0, "sysUser:add", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910575L, "manage", "sys_user_mgr_own_data", null, null, null, null, null, false, null, "用户拥有数据", 0, "sysUser:ownData", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910577L, "manage", "sys_user_mgr_update_pwd", null, null, null, null, null, false, null, "用户修改密码", 0, "sysUser:updatePwd", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910578L, "manage", "sys_user_mgr_change_status", null, null, null, null, null, false, null, "用户修改状态", 0, "sysUser:changeStatus", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910579L, "manage", "sys_user_mgr_update_avatar", null, null, null, null, null, false, null, "用户修改头像", 0, "sysUser:updateAvatar", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910580L, "manage", "sys_user_mgr_reset_pwd", null, null, null, null, null, false, null, "用户重置密码", 0, "sysUser:resetPwd", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070918777L, "manage", "sys_user_mgr_login", null, null, null, null, null, false, null, "用户登录信息", 0, "getLoginUser", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 1, 2, null, null, null, "N", 1 },
                    { 142307070914651L, "manage", "sys_role_mgr", "system/role/index", null, null, null, null, false, null, "角色管理", 1, null, 142307070910563L, "[0],[142307070910563],", null, null, "/role", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914652L, "manage", "sys_role_mgr_page", null, null, null, null, null, false, null, "角色查询", 0, "sysRole:page", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910576L, "manage", "sys_user_mgr_update_info", null, null, null, null, null, false, null, "用户更新信息", 0, "sysUser:updateInfo", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910566L, "manage", "sys_user_mgr_edit", null, null, null, null, null, false, null, "用户编辑", 0, "sysUser:edit", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910565L, "manage", "sys_user_mgr_page", null, null, null, null, null, false, null, "用户查询", 0, "sysUser:page", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910564L, "manage", "sys_user_mgr", "system/user/index", null, null, null, null, false, null, "用户管理", 1, null, 142307070910563L, "[0],[142307070910563],", null, null, "/mgr_user", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307000914633L, "manage", "sys_mgr", "PageView", null, null, null, "team", false, null, "组织架构", 0, null, 0L, "[0],", null, null, "/sys", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070910581L, "manage", "sys_org_mgr", "system/org/index", null, null, null, null, false, null, "机构管理", 1, null, 142307000914633L, "[0],[142307000914633],", null, null, "/org", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070910582L, "manage", "sys_org_mgr_page", null, null, null, null, null, false, null, "机构查询", 0, "sysOrg:page", 142307070910581L, "[0],[142307000914633],[142307070910581],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910583L, "manage", "sys_org_mgr_list", null, null, null, null, null, false, null, "机构列表", 0, "sysOrg:list", 142307070910581L, "[0],[142307000914633],[142307070910581],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910584L, "manage", "sys_org_mgr_add", null, null, null, null, null, false, null, "机构增加", 0, "sysOrg:add", 142307070910581L, "[0],[142307000914633],[142307070910581],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910585L, "manage", "sys_org_mgr_edit", null, null, null, null, null, false, null, "机构编辑", 0, "sysOrg:edit", 142307070910581L, "[0],[142307000914633],[142307070910581],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910586L, "manage", "sys_org_mgr_delete", null, null, null, null, null, false, null, "机构删除", 0, "sysOrg:delete", 142307070910581L, "[0],[142307000914633],[142307070910581],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910587L, "manage", "sys_org_mgr_detail", null, null, null, null, null, false, null, "机构详情", 0, "sysOrg:detail", 142307070910581L, "[0],[142307000914633],[142307070910581],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910588L, "manage", "sys_org_mgr_tree", null, null, null, null, null, false, null, "机构树", 0, "sysOrg:tree", 142307070910581L, "[0],[142307000914633],[142307070910581],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910589L, "manage", "sys_pos_mgr", "system/pos/index", null, null, null, null, false, null, "职位管理", 1, null, 142307000914633L, "[0],[142307000914633],", null, null, "/pos", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070910590L, "manage", "sys_pos_mgr_page", null, null, null, null, null, false, null, "职位查询", 0, "sysPos:page", 142307070910589L, "[0],[142307000914633],[142307070910589],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910591L, "manage", "sys_pos_mgr_list", null, null, null, null, null, false, null, "职位列表", 0, "sysPos:list", 142307070910589L, "[0],[142307000914633],[142307070910589],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914629L, "manage", "sys_pos_mgr_add", null, null, null, null, null, false, null, "职位增加", 0, "sysPos:add", 142307070910589L, "[0],[142307000914633],[142307070910589],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914630L, "manage", "sys_pos_mgr_edit", null, null, null, null, null, false, null, "职位编辑", 0, "sysPos:edit", 142307070910589L, "[0],[142307000914633],[142307070910589],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914631L, "manage", "sys_pos_mgr_delete", null, null, null, null, null, false, null, "职位删除", 0, "sysPos:delete", 142307070910589L, "[0],[142307000914633],[142307070910589],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914632L, "manage", "sys_pos_mgr_detail", null, null, null, null, null, false, null, "职位详情", 0, "sysPos:detail", 142307070910589L, "[0],[142307000914633],[142307070910589],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910563L, "manage", "auth_manager", "PageView", null, null, null, "safety-certificate", false, null, "权限管理", 0, null, 0L, "[0],", null, null, "/auth", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070914653L, "manage", "sys_role_mgr_add", null, null, null, null, null, false, null, "角色增加", 0, "sysRole:add", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914654L, "manage", "sys_role_mgr_edit", null, null, null, null, null, false, null, "角色编辑", 0, "sysRole:edit", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070910571L, "manage", "sys_user_mgr_selector", null, null, null, null, null, false, null, "用户选择器", 0, "sysUser:selector", 142307070910564L, "[0],[142307070910563],[142307070910564],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914656L, "manage", "sys_role_mgr_detail", null, null, null, null, null, false, null, "角色详情", 0, "sysRole:detail", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914650L, "system", "sys_menu_mgr_change", null, null, null, null, null, false, null, "菜单切换", 0, "sysMenu:change", 142307070914642L, "[0],[142307070914633],[142307070914642],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914662L, "system", "system_tools", "PageView", null, null, null, "euro", false, null, "开发管理", 0, null, 0L, "[0],", null, null, "/tools", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070914663L, "system", "system_tools_config", "system/config/index", null, null, null, null, false, null, "系统配置", 1, null, 142307070914662L, "[0],[142307070914662],", null, null, "/config", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914664L, "system", "system_tools_config_page", null, null, null, null, null, false, null, "配置查询", 0, "sysConfig:page", 142307070914663L, "[0],[142307070914662],[142307070914663],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914665L, "system", "system_tools_config_list", null, null, null, null, null, false, null, "配置列表", 0, "sysConfig:list", 142307070914663L, "[0],[142307070914662],[142307070914663],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914666L, "system", "system_tools_config_add", null, null, null, null, null, false, null, "配置增加", 0, "sysConfig:add", 142307070914663L, "[0],[142307070914662],[142307070914663],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914667L, "system", "system_tools_config_edit", null, null, null, null, null, false, null, "配置编辑", 0, "sysConfig:edit", 142307070914663L, "[0],[142307070914662],[142307070914663],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914647L, "system", "sys_menu_mgr_detail", null, null, null, null, null, false, null, "菜单详情", 0, "sysMenu:detail", 142307070914642L, "[0],[142307070914633],[142307070914642],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914668L, "system", "system_tools_config_delete", null, null, null, null, null, false, null, "配置删除", 0, "sysConfig:delete", 142307070914663L, "[0],[142307070914662],[142307070914663],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914671L, "system", "sys_email_mgr", "system/email/index", null, null, null, null, false, null, "邮件发送", 1, null, 142307070914662L, "[0],[142307070914662],", null, null, "/email", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914672L, "system", "sys_email_mgr_send_email", null, null, null, null, null, false, null, "发送文本邮件", 0, "email:sendEmail", 142307070914671L, "[0],[142307070914662],[142307070914671],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914673L, "system", "sys_email_mgr_send_email_html", null, null, null, null, null, false, null, "发送html邮件", 0, "email:sendEmailHtml", 142307070914671L, "[0],[142307070914662],[142307070914671],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914655L, "manage", "sys_role_mgr_delete", null, null, null, null, null, false, null, "角色删除", 0, "sysRole:delete", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914675L, "system", "sys_sms_mgr_page", null, null, null, null, null, false, null, "短信发送查询", 0, "sms:page", 142307070914674L, "[0],[142307070914662],[142307070914674],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914676L, "system", "sys_sms_mgr_send_login_message", null, null, null, null, null, false, null, "发送验证码短信", 0, "sms:sendLoginMessage", 142307070914674L, "[0],[142307070914662],[142307070914674],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914677L, "system", "sys_sms_mgr_validate_message", null, null, null, null, null, false, null, "验证短信验证码", 0, "sms:validateMessage", 142307070914674L, "[0],[142307070914662],[142307070914674],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914669L, "system", "system_tools_config_detail", null, null, null, null, null, false, null, "配置详情", 0, "sysConfig:detail", 142307070914663L, "[0],[142307070914662],[142307070914663],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914645L, "system", "sys_menu_mgr_edit", null, null, null, null, null, false, null, "菜单编辑", 0, "sysMenu:edit", 142307070914642L, "[0],[142307070914633],[142307070914642],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914674L, "system", "sys_sms_mgr", "system/sms/index", null, null, null, null, false, null, "短信管理", 1, null, 142307070914662L, "[0],[142307070914662],", null, null, "/sms", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914643L, "system", "sys_menu_mgr_list", null, null, null, null, null, false, null, "菜单列表", 0, "sysMenu:list", 142307070914642L, "[0],[142307070914633],[142307070914642],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914657L, "manage", "sys_role_mgr_drop_down", null, null, null, null, null, false, null, "角色下拉", 0, "sysRole:dropDown", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914658L, "manage", "sys_role_mgr_grant_menu", null, null, null, null, null, false, null, "角色授权菜单", 0, "sysRole:grantMenu", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914659L, "manage", "sys_role_mgr_own_menu", null, null, null, null, null, false, null, "角色拥有菜单", 0, "sysRole:ownMenu", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914660L, "manage", "sys_role_mgr_grant_data", null, null, null, null, null, false, null, "角色授权数据", 0, "sysRole:grantData", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914661L, "manage", "sys_role_mgr_own_data", null, null, null, null, null, false, null, "角色拥有数据", 0, "sysRole:ownData", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914648L, "manage", "sys_menu_mgr_grant_tree", null, null, null, null, null, false, null, "菜单授权树", 0, "sysMenu:treeForGrant", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914649L, "manage", "sys_menu_mgr_tree", null, null, null, null, null, false, null, "菜单树", 0, "sysMenu:tree", 142307070914651L, "[0],[142307070910563],[142307070914651],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914644L, "system", "sys_menu_mgr_add", null, null, null, null, null, false, null, "菜单增加", 0, "sysMenu:add", 142307070914642L, "[0],[142307070914633],[142307070914642],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914634L, "system", "sys_app_mgr", "system/app/index", null, null, null, null, false, null, "应用管理", 1, null, 142307070914633L, "[0],[142307070914633],", null, null, "/app", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914633L, "system", "sys_platform", "PageView", null, null, null, "safety-certificate", false, null, "平台管理", 0, null, 0L, "[0],", null, null, "/platform", 100, 0, 0, null, null, null, "Y", 1 },
                    { 142307070914636L, "system", "sys_app_mgr_list", null, null, null, null, null, false, null, "应用列表", 0, "sysApp:list", 142307070914634L, "[0],[142307070914633],[142307070914634],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914637L, "system", "sys_app_mgr_add", null, null, null, null, null, false, null, "应用增加", 0, "sysApp:add", 142307070914634L, "[0],[142307070914633],[142307070914634],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914638L, "system", "sys_app_mgr_edit", null, null, null, null, null, false, null, "应用编辑", 0, "sysApp:edit", 142307070914634L, "[0],[142307070914633],[142307070914634],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914639L, "system", "sys_app_mgr_delete", null, null, null, null, null, false, null, "应用删除", 0, "sysApp:delete", 142307070914634L, "[0],[142307070914633],[142307070914634],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914640L, "system", "sys_app_mgr_detail", null, null, null, null, null, false, null, "应用详情", 0, "sysApp:detail", 142307070914634L, "[0],[142307070914633],[142307070914634],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914641L, "system", "sys_app_mgr_set_as_default", null, null, null, null, null, false, null, "设为默认应用", 0, "sysApp:setAsDefault", 142307070914634L, "[0],[142307070914633],[142307070914634],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 },
                    { 142307070914642L, "system", "sys_menu_mgr", "system/menu/index", null, null, null, null, false, null, "菜单管理", 1, null, 142307070914633L, "[0],[142307070914633],", null, null, "/menu", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070914635L, "system", "sys_app_mgr_page", null, null, null, null, null, false, null, "应用查询", 0, "sysApp:page", 142307070914634L, "[0],[142307070914633],[142307070914634],", null, null, null, 100, 0, 2, null, null, null, "Y", 1 }
                });

            migrationBuilder.InsertData(
                table: "sys_org",
                columns: new[] { "Id", "Code", "Contacts", "CreatedTime", "CreatedUserId", "CreatedUserName", "IsDeleted", "Name", "OrgType", "Pid", "Pids", "Remark", "Sort", "Status", "Tel", "TenantId", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { 142307070910548L, "gsmc", null, null, null, null, false, "租户2公司", 0, 0L, "[0],", "公司名称", 100, 0, null, 142307070918782L, null, null, null },
                    { 142307070910547L, "gsmc", null, null, null, null, false, "租户1公司", 0, 0L, "[0],", "公司名称", 100, 0, null, 142307070918781L, null, null, null },
                    { 142307070910546L, "hxjt_cd_scb_2b", null, null, null, null, false, "市场部二部", 0, 142307070910544L, "[0],[142307070910539],[142307070910541],[142307070910544],", "华夏集团成都分公司市场部二部", 100, 0, null, 142307070918780L, null, null, null },
                    { 142307070910544L, "hxjt_cd_scb", null, null, null, null, false, "市场部", 0, 142307070910541L, "[0],[142307070910539],[142307070910541],", "华夏集团成都分公司市场部", 100, 0, null, 142307070918780L, null, null, null },
                    { 142307070910545L, "hxjt_cd_cwb", null, null, null, null, false, "财务部", 0, 142307070910541L, "[0],[142307070910539],[142307070910541],", "华夏集团成都分公司财务部", 100, 0, null, 142307070918780L, null, null, null },
                    { 142307070910542L, "hxjt_bj_yfb", null, null, null, null, false, "研发部", 0, 142307070910540L, "[0],[142307070910539],[142307070910540],", "华夏集团北京分公司研发部", 100, 0, null, 142307070918780L, null, null, null },
                    { 142307070910541L, "hxjt_cd", null, null, null, null, false, "华夏集团成都分公司", 0, 142307070910539L, "[0],[142307070910539],", "华夏集团成都分公司", 100, 0, null, 142307070918780L, null, null, null },
                    { 142307070910540L, "hxjt_bj", null, null, null, null, false, "华夏集团北京分公司", 0, 142307070910539L, "[0],[142307070910539],", "华夏集团北京分公司", 100, 0, null, 142307070918780L, null, null, null },
                    { 142307070910539L, "hxjt", null, null, null, null, false, "华夏集团", 0, 0L, "[0],", "华夏集团", 100, 0, null, 142307070918780L, null, null, null },
                    { 142307070910543L, "hxjt_bj_qhb", null, null, null, null, false, "企划部", 0, 142307070910540L, "[0],[142307070910539],[142307070910540],", "华夏集团北京分公司企划部", 100, 0, null, 142307070918780L, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "sys_pos",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "CreatedUserName", "IsDeleted", "Name", "Remark", "Sort", "Status", "TenantId", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { 142307070910558L, "gzry", null, null, null, false, "工作人员", "工作人员", 103, 0, 142307070918782L, null, null, null },
                    { 142307070910557L, "bmjl", null, null, null, false, "部门经理", "部门经理", 102, 0, 142307070918782L, null, null, null },
                    { 142307070910556L, "fzjl", null, null, null, false, "副总经理", "副总经理", 101, 0, 142307070918782L, null, null, null },
                    { 142307070910554L, "gzry", null, null, null, false, "工作人员", "工作人员", 103, 0, 142307070918781L, null, null, null },
                    { 142307070910553L, "bmjl", null, null, null, false, "部门经理", "部门经理", 102, 0, 142307070918781L, null, null, null },
                    { 142307070910555L, "zjl", null, null, null, false, "总经理", "总经理", 100, 0, 142307070918782L, null, null, null },
                    { 142307070910551L, "zjl", null, null, null, false, "总经理", "总经理", 100, 0, 142307070918781L, null, null, null },
                    { 142307070910550L, "gzry", null, null, null, false, "工作人员", "工作人员", 103, 0, 142307070918780L, null, null, null },
                    { 142307070910549L, "bmjl", null, null, null, false, "部门经理", "部门经理", 102, 0, 142307070918780L, null, null, null },
                    { 142307070910548L, "fzjl", null, null, null, false, "副总经理", "副总经理", 101, 0, 142307070918780L, null, null, null },
                    { 142307070910547L, "zjl", null, null, null, false, "总经理", "总经理", 100, 0, 142307070918780L, null, null, null },
                    { 142307070910552L, "fzjl", null, null, null, false, "副总经理", "副总经理", 101, 0, 142307070918781L, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "sys_role",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "CreatedUserName", "DataScopeType", "IsDeleted", "Name", "Remark", "RoleType", "Sort", "Status", "TenantId", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { 142307070910554L, "sys_manager_role", null, null, null, 1, false, "系统管理员", "系统管理员", 0, 100, 0, 142307070918780L, null, null, null },
                    { 142307070910555L, "common_role", null, null, null, 5, false, "普通用户", "普通用户", 0, 101, 0, 142307070918780L, null, null, null },
                    { 142307070910556L, "sys_manager_role", null, null, null, 5, false, "系统管理员", "系统管理员", 0, 100, 0, 142307070918781L, null, null, null },
                    { 142307070910557L, "common_role", null, null, null, 5, false, "普通用户", "普通用户", 0, 101, 0, 142307070918781L, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "sys_timer",
                columns: new[] { "Id", "CreatedTime", "CreatedUserId", "CreatedUserName", "Cron", "DoOnce", "ExecuteType", "Headers", "Interval", "IsDeleted", "JobName", "Remark", "RequestParameters", "RequestType", "RequestUrl", "StartNow", "TimerType", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[] { 142307070910556L, null, null, null, null, false, 1, null, 5, false, "百度api", "接口API", null, 2, "https://www.baidu.com", false, 0, null, null, null });

            migrationBuilder.InsertData(
                table: "sys_user",
                columns: new[] { "Id", "Account", "AdminType", "Avatar", "Birthday", "CreatedTime", "CreatedUserId", "CreatedUserName", "Email", "IsDeleted", "LastLoginIp", "LastLoginTime", "Name", "NickName", "Password", "Phone", "Sex", "Status", "Tel", "TenantId", "UpdatedTime", "UpdatedUserId", "UpdatedUserName" },
                values: new object[,]
                {
                    { 142307070910554L, "zuohuaijun@163.com", 2, null, new DateTimeOffset(new DateTime(1986, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, false, null, null, "系统管理员", "admin", "e10adc3949ba59abbe56e057f20f883e", "18020030720", 1, 0, null, 142307070918781L, null, null, null },
                    { 142307070910551L, "superAdmin", 1, null, new DateTimeOffset(new DateTime(1986, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, false, null, null, "超级管理员", "superAdmin", "e10adc3949ba59abbe56e057f20f883e", "18020030720", 1, 0, null, 142307070918780L, null, null, null },
                    { 142307070910552L, "admin", 2, null, new DateTimeOffset(new DateTime(1986, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, false, null, null, "系统管理员", "admin", "e10adc3949ba59abbe56e057f20f883e", "18020030720", 1, 0, null, 142307070918780L, null, null, null },
                    { 142307070910553L, "zuohuaijun", 3, null, new DateTimeOffset(new DateTime(1986, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, false, null, null, "普通用户", "zuohuaijun", "e10adc3949ba59abbe56e057f20f883e", "18020030720", 1, 0, null, 142307070918780L, null, null, null },
                    { 142307070910556L, "dilon@163.com", 3, null, new DateTimeOffset(new DateTime(1986, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), null, null, null, null, false, null, null, "普通用户", "dilon", "e10adc3949ba59abbe56e057f20f883e", "18020030720", 1, 0, null, 142307070918781L, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "sys_dict_data",
                columns: new[] { "Id", "Code", "CreatedTime", "CreatedUserId", "CreatedUserName", "IsDeleted", "Remark", "Sort", "Status", "TypeId", "UpdatedTime", "UpdatedUserId", "UpdatedUserName", "Value" },
                values: new object[,]
                {
                    { 142307070902384L, "0", null, null, null, false, "正常", 100, 0, 142307070906483L, null, null, null, "正常" },
                    { 142307070922834L, "switch", null, null, null, false, "开关", 100, 0, 142307070922827L, null, null, null, "开关" },
                    { 142307070922833L, "radio", null, null, null, false, "单选框", 100, 0, 142307070922827L, null, null, null, "单选框" },
                    { 142307070922832L, "select", null, null, null, false, "下拉框", 100, 0, 142307070922827L, null, null, null, "下拉框" },
                    { 142307070922831L, "datepicker", null, null, null, false, "时间选择", 100, 0, 142307070922827L, null, null, null, "时间选择" },
                    { 142307070922830L, "input", null, null, null, false, "输入框", 100, 0, 142307070922827L, null, null, null, "输入框" },
                    { 142307070922829L, "fk", null, null, null, false, "外键", 100, 0, 142307070922827L, null, null, null, "外键" },
                    { 142307070906482L, "4", null, null, null, false, "DELETE", 100, 0, 142307070910538L, null, null, null, "DELETE" },
                    { 142307070906481L, "3", null, null, null, false, "PUT", 100, 0, 142307070910538L, null, null, null, "PUT" },
                    { 142307070906480L, "2", null, null, null, false, "POST", 100, 0, 142307070910538L, null, null, null, "POST" },
                    { 142307070906479L, "1", null, null, null, false, "GET", 100, 0, 142307070910538L, null, null, null, "GET" },
                    { 142307070922835L, "checkbox", null, null, null, false, "多选框", 100, 0, 142307070922827L, null, null, null, "多选框" },
                    { 142307070906478L, "2", null, null, null, false, "生成到本项目", 100, 0, 142307070910537L, null, null, null, "生成到本项目" },
                    { 142307070906476L, "false", null, null, null, false, "否", 100, 0, 142307070910536L, null, null, null, "否" },
                    { 142307070906475L, "true", null, null, null, false, "是", 100, 0, 142307070910536L, null, null, null, "是" },
                    { 142307070906474L, "3", null, null, null, false, "删除", 100, 0, 142307070910535L, null, null, null, "删除" },
                    { 142307070906473L, "2", null, null, null, false, "撤回", 100, 0, 142307070910535L, null, null, null, "撤回" },
                    { 142307070906472L, "1", null, null, null, false, "发布", 100, 0, 142307070910535L, null, null, null, "发布" },
                    { 142307070906471L, "0", null, null, null, false, "草稿", 100, 0, 142307070910535L, null, null, null, "草稿" },
                    { 142307070906470L, "2", null, null, null, false, "公告", 100, 0, 142307070910534L, null, null, null, "公告" },
                    { 142307070906469L, "1", null, null, null, false, "通知", 100, 0, 142307070910534L, null, null, null, "通知" },
                    { 142307070906468L, "2", null, null, null, false, "停止", 100, 0, 142307070910533L, null, null, null, "停止" },
                    { 142307070906467L, "1", null, null, null, false, "运行", 100, 0, 142307070910533L, null, null, null, "运行" },
                    { 142307070906477L, "1", null, null, null, false, "下载压缩包", 100, 0, 142307070910537L, null, null, null, "下载压缩包" },
                    { 142307070922836L, "inputnumber", null, null, null, false, "数字输入框", 100, 0, 142307070922827L, null, null, null, "数字输入框" },
                    { 142307070922837L, "textarea", null, null, null, false, "文本域", 100, 0, 142307070922827L, null, null, null, "文本域" },
                    { 142307070922838L, "==", null, null, null, false, "等于", 1, 0, 142307070922828L, null, null, null, "等于" },
                    { 142307070926949L, "4", null, null, null, false, "加盟店", 100, 0, 142307070926942L, null, null, null, "加盟店" },
                    { 142307070926948L, "3", null, null, null, false, "直营店", 100, 0, 142307070926942L, null, null, null, "直营店" },
                    { 142307070926947L, "2", null, null, null, false, "总店(加盟/直营)", 100, 0, 142307070926942L, null, null, null, "总店(加盟/直营)" },
                    { 142307070926946L, "1", null, null, null, false, "品牌", 100, 0, 142307070926942L, null, null, null, "品牌" },
                    { 142307070926945L, "2", null, null, null, false, "门店角色", 100, 0, 142307070926941L, null, null, null, "门店角色" },
                    { 142307070926944L, "1", null, null, null, false, "加盟商角色", 100, 0, 142307070926941L, null, null, null, "加盟商角色" },
                    { 142307070926943L, "0", null, null, null, false, "集团角色", 100, 0, 142307070926941L, null, null, null, "集团角色" },
                    { 142307070922864L, "DateTimeOffset", null, null, null, false, "DateTimeOffset", 100, 0, 142307070922829L, null, null, null, "DateTimeOffset" },
                    { 142307070922863L, "Guid", null, null, null, false, "Guid", 100, 0, 142307070922829L, null, null, null, "Guid" },
                    { 142307070922862L, "decimal", null, null, null, false, "decimal", 100, 0, 142307070922829L, null, null, null, "decimal" },
                    { 142307070922861L, "float", null, null, null, false, "float", 100, 0, 142307070922829L, null, null, null, "float" },
                    { 142307070922848L, "DateTime", null, null, null, false, "DateTime", 100, 0, 142307070922829L, null, null, null, "DateTime" },
                    { 142307070922852L, "double", null, null, null, false, "double", 100, 0, 142307070922829L, null, null, null, "double" },
                    { 142307070922850L, "bool", null, null, null, false, "bool", 100, 0, 142307070922829L, null, null, null, "bool" },
                    { 142307070922847L, "string", null, null, null, false, "string", 100, 0, 142307070922829L, null, null, null, "string" },
                    { 142307070922846L, "long", null, null, null, false, "long", 100, 0, 142307070922829L, null, null, null, "long" },
                    { 142307070922851L, "int", null, null, null, false, "int", 100, 0, 142307070922829L, null, null, null, "int" },
                    { 142307070922844L, "<=", null, null, null, false, "小于等于", 7, 0, 142307070922828L, null, null, null, "小于等于" },
                    { 142307070922843L, ">=", null, null, null, false, "大于等于", 6, 0, 142307070922828L, null, null, null, "大于等于" },
                    { 142307070922842L, "!=", null, null, null, false, "不等于", 5, 0, 142307070922828L, null, null, null, "不等于" },
                    { 142307070922841L, "<", null, null, null, false, "小于", 4, 0, 142307070922828L, null, null, null, "小于" },
                    { 142307070922840L, ">", null, null, null, false, "大于", 3, 0, 142307070922828L, null, null, null, "大于" },
                    { 142307070922839L, "like", null, null, null, false, "模糊", 2, 0, 142307070922828L, null, null, null, "模糊" },
                    { 142307070906466L, "4", null, null, null, false, "本地", 100, 0, 142307070906495L, null, null, null, "本地" },
                    { 142307070906465L, "3", null, null, null, false, "minio", 100, 0, 142307070906495L, null, null, null, "minio" },
                    { 142307070922845L, "isNotNull", null, null, null, false, "不为空", 8, 0, 142307070922828L, null, null, null, "不为空" },
                    { 142307070906463L, "1", null, null, null, false, "阿里云", 100, 0, 142307070906495L, null, null, null, "阿里云" },
                    { 142307070902398L, "0", null, null, null, false, "无", 100, 0, 142307070906490L, null, null, null, "无" },
                    { 142307070902397L, "3", null, null, null, false, "失效", 100, 0, 142307070906489L, null, null, null, "失效" },
                    { 142307070902396L, "2", null, null, null, false, "发送失败", 100, 0, 142307070906489L, null, null, null, "发送失败" },
                    { 142307070906464L, "2", null, null, null, false, "腾讯云", 100, 0, 142307070906495L, null, null, null, "腾讯云" },
                    { 142307070902394L, "0", null, null, null, false, "未发送", 100, 0, 142307070906489L, null, null, null, "未发送" },
                    { 142307070902393L, "2", null, null, null, false, "按钮", 100, 0, 142307070906488L, null, null, null, "按钮" },
                    { 142307070902392L, "1", null, null, null, false, "菜单", 100, 0, 142307070906488L, null, null, null, "菜单" },
                    { 142307070902391L, "0", null, null, null, false, "目录", 100, 0, 142307070906488L, null, null, null, "目录" },
                    { 142307070902390L, "2", null, null, null, false, "登出", 100, 0, 142307070906487L, null, null, null, "登出" },
                    { 142307070902389L, "1", null, null, null, false, "登录", 100, 0, 142307070906487L, null, null, null, "登录" },
                    { 142307070902388L, "Y", null, null, null, false, "是", 100, 0, 142307070906486L, null, null, null, "是" },
                    { 142307070902387L, "N", null, null, null, false, "否", 100, 0, 142307070906486L, null, null, null, "否" },
                    { 142307070902383L, "OAUTH", null, null, null, false, "Oauth配置", 100, 0, 142307070906485L, null, null, null, "Oauth配置" },
                    { 142307070902382L, "FILE_PATH", null, null, null, false, "文件上传路径", 100, 0, 142307070906485L, null, null, null, "文件上传路径" },
                    { 142307070902381L, "EMAIL", null, null, null, false, "邮件配置", 100, 0, 142307070906485L, null, null, null, "邮件配置" },
                    { 142307070902380L, "TENCENT_SMS", null, null, null, false, "腾讯云短信", 100, 0, 142307070906485L, null, null, null, "腾讯云短信" },
                    { 142307070902379L, "ALIYUN_SMS", null, null, null, false, "阿里云短信配置", 100, 0, 142307070906485L, null, null, null, "阿里云短信" },
                    { 142307070902378L, "DEFAULT", null, null, null, false, "默认常量，都以XIAONUO_开头的", 100, 0, 142307070906485L, null, null, null, "默认常量" },
                    { 142307070902377L, "3", null, null, null, false, "未知性别", 100, 0, 142307070906484L, null, null, null, "未知" },
                    { 142307070902376L, "2", null, null, null, false, "女性", 100, 0, 142307070906484L, null, null, null, "女" },
                    { 142307070902375L, "1", null, null, null, false, "男性", 100, 0, 142307070906484L, null, null, null, "男" },
                    { 142307070902386L, "2", null, null, null, false, "删除", 100, 0, 142307070906483L, null, null, null, "删除" },
                    { 142307070902385L, "1", null, null, null, false, "停用", 100, 0, 142307070906483L, null, null, null, "停用" },
                    { 142307070902399L, "1", null, null, null, false, "组件", 100, 0, 142307070906490L, null, null, null, "组件" },
                    { 142307070906437L, "2", null, null, null, false, "内链", 100, 0, 142307070906490L, null, null, null, "内链" },
                    { 142307070902395L, "1", null, null, null, false, "发送成功", 100, 0, 142307070906489L, null, null, null, "发送成功" },
                    { 142307070906439L, "1", null, null, null, false, "系统权重", 100, 0, 142307070906491L, null, null, null, "系统权重" },
                    { 142307070906462L, "13", null, null, null, false, "修改状态", 100, 0, 142307070906494L, null, null, null, "修改状态" },
                    { 142307070906461L, "12", null, null, null, false, "清空", 100, 0, 142307070906494L, null, null, null, "清空" },
                    { 142307070906460L, "11", null, null, null, false, "强退", 100, 0, 142307070906494L, null, null, null, "强退" },
                    { 142307070906459L, "10", null, null, null, false, "授权", 100, 0, 142307070906494L, null, null, null, "授权" },
                    { 142307070906458L, "9", null, null, null, false, "导出", 100, 0, 142307070906494L, null, null, null, "导出" },
                    { 142307070906457L, "8", null, null, null, false, "导入", 100, 0, 142307070906494L, null, null, null, "导入" },
                    { 142307070906456L, "7", null, null, null, false, "树", 100, 0, 142307070906494L, null, null, null, "树" },
                    { 142307070906438L, "3", null, null, null, false, "外链", 100, 0, 142307070906490L, null, null, null, "外链" },
                    { 142307070906454L, "5", null, null, null, false, "查询", 100, 0, 142307070906494L, null, null, null, "查询" },
                    { 142307070906453L, "4", null, null, null, false, "更新", 100, 0, 142307070906494L, null, null, null, "更新" },
                    { 142307070906452L, "3", null, null, null, false, "编辑", 100, 0, 142307070906494L, null, null, null, "编辑" },
                    { 142307070906451L, "2", null, null, null, false, "删除", 100, 0, 142307070906494L, null, null, null, "删除" },
                    { 142307070906455L, "6", null, null, null, false, "详情", 100, 0, 142307070906494L, null, null, null, "详情" },
                    { 142307070906449L, "0", null, null, null, false, "其它", 100, 0, 142307070906494L, null, null, null, "其它" },
                    { 142307070906450L, "1", null, null, null, false, "增加", 100, 0, 142307070906494L, null, null, null, "增加" },
                    { 142307070906441L, "1", null, null, null, false, "全部数据", 100, 0, 142307070906492L, null, null, null, "全部数据" },
                    { 142307070906442L, "2", null, null, null, false, "本部门及以下数据", 100, 0, 142307070906492L, null, null, null, "本部门及以下数据" },
                    { 142307070906443L, "3", null, null, null, false, "本部门数据", 100, 0, 142307070906492L, null, null, null, "本部门数据" },
                    { 142307070906444L, "4", null, null, null, false, "仅本人数据", 100, 0, 142307070906492L, null, null, null, "仅本人数据" },
                    { 142307070906440L, "2", null, null, null, false, "业务权重", 100, 0, 142307070906491L, null, null, null, "业务权重" },
                    { 142307070906446L, "1", null, null, null, false, "app", 100, 0, 142307070906493L, null, null, null, "app" },
                    { 142307070906447L, "2", null, null, null, false, "pc", 100, 0, 142307070906493L, null, null, null, "pc" },
                    { 142307070906448L, "3", null, null, null, false, "其他", 100, 0, 142307070906493L, null, null, null, "其他" },
                    { 142307070906445L, "5", null, null, null, false, "自定义数据", 100, 0, 142307070906492L, null, null, null, "自定义数据" }
                });

            migrationBuilder.InsertData(
                table: "sys_emp_ext_org_pos",
                columns: new[] { "SysEmpId", "SysOrgId", "SysPosId" },
                values: new object[,]
                {
                    { 142307070910551L, 142307070910539L, 142307070910547L },
                    { 142307070910553L, 142307070910542L, 142307070910547L },
                    { 142307070910551L, 142307070910540L, 142307070910548L },
                    { 142307070910551L, 142307070910541L, 142307070910549L },
                    { 142307070910551L, 142307070910542L, 142307070910550L }
                });

            migrationBuilder.InsertData(
                table: "sys_emp_pos",
                columns: new[] { "SysEmpId", "SysPosId" },
                values: new object[,]
                {
                    { 142307070910558L, 142307070910557L },
                    { 142307070910557L, 142307070910556L },
                    { 142307070910559L, 142307070910555L },
                    { 142307070910557L, 142307070910555L },
                    { 142307070910555L, 142307070910553L },
                    { 142307070910554L, 142307070910552L },
                    { 142307070910554L, 142307070910551L },
                    { 142307070910552L, 142307070910549L },
                    { 142307070910551L, 142307070910547L },
                    { 142307070910555L, 142307070910551L },
                    { 142307070910551L, 142307070910548L },
                    { 142307070910553L, 142307070910547L }
                });

            migrationBuilder.InsertData(
                table: "sys_role_menu",
                columns: new[] { "SysMenuId", "SysRoleId" },
                values: new object[,]
                {
                    { 142307070910574L, 142307070910556L },
                    { 142307070910575L, 142307070910556L },
                    { 142307070910576L, 142307070910556L },
                    { 142307070910577L, 142307070910556L },
                    { 142307070910578L, 142307070910556L },
                    { 142307070910579L, 142307070910556L },
                    { 142307070910580L, 142307070910556L },
                    { 142307070918777L, 142307070910556L },
                    { 142307070914651L, 142307070910556L },
                    { 142307070914652L, 142307070910556L },
                    { 142307070914653L, 142307070910556L },
                    { 142307070914654L, 142307070910556L },
                    { 142307070910573L, 142307070910556L },
                    { 142307070914657L, 142307070910556L },
                    { 142307070914658L, 142307070910556L },
                    { 142307070914659L, 142307070910556L },
                    { 142307070914660L, 142307070910556L },
                    { 142307070914661L, 142307070910556L },
                    { 142307070910560L, 142307070910556L },
                    { 142307070910561L, 142307070910556L },
                    { 142307070910562L, 142307070910556L },
                    { 142307070914648L, 142307070910556L },
                    { 142307070922874L, 142307070910556L },
                    { 142307070914655L, 142307070910556L },
                    { 142307070914656L, 142307070910556L },
                    { 142307070910571L, 142307070910556L },
                    { 142307070910570L, 142307070910556L },
                    { 142307070910563L, 142307070910556L },
                    { 142307070910581L, 142307070910556L },
                    { 142307070910582L, 142307070910556L },
                    { 142307070910583L, 142307070910556L },
                    { 142307070910584L, 142307070910556L },
                    { 142307070910585L, 142307070910556L },
                    { 142307070910586L, 142307070910556L },
                    { 142307070910587L, 142307070910556L },
                    { 142307070910588L, 142307070910556L },
                    { 142307070910589L, 142307070910556L },
                    { 142307070910572L, 142307070910556L },
                    { 142307070910590L, 142307070910556L },
                    { 142307070914629L, 142307070910556L },
                    { 142307070914630L, 142307070910556L },
                    { 142307070914631L, 142307070910556L },
                    { 142307070914632L, 142307070910556L },
                    { 142307000914633L, 142307070910556L },
                    { 142307070910564L, 142307070910556L },
                    { 142307070910565L, 142307070910556L },
                    { 142307070910566L, 142307070910556L },
                    { 142307070910567L, 142307070910556L },
                    { 142307070910568L, 142307070910556L },
                    { 142307070910569L, 142307070910556L },
                    { 142307070910591L, 142307070910556L }
                });

            migrationBuilder.InsertData(
                table: "sys_user_data_scope",
                columns: new[] { "SysOrgId", "SysUserId" },
                values: new object[] { 142307070910547L, 142307070910554L });

            migrationBuilder.InsertData(
                table: "sys_user_role",
                columns: new[] { "SysRoleId", "SysUserId" },
                values: new object[,]
                {
                    { 142307070910554L, 142307070910552L },
                    { 142307070910556L, 142307070910554L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_sys_dict_data_TypeId",
                table: "sys_dict_data",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_emp_ext_org_pos_SysOrgId",
                table: "sys_emp_ext_org_pos",
                column: "SysOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_emp_ext_org_pos_SysPosId",
                table: "sys_emp_ext_org_pos",
                column: "SysPosId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_emp_pos_SysPosId",
                table: "sys_emp_pos",
                column: "SysPosId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_role_data_scope_SysOrgId",
                table: "sys_role_data_scope",
                column: "SysOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_role_menu_SysMenuId",
                table: "sys_role_menu",
                column: "SysMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_user_data_scope_SysOrgId",
                table: "sys_user_data_scope",
                column: "SysOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_user_role_SysRoleId",
                table: "sys_user_role",
                column: "SysRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "sys_app");

            migrationBuilder.DropTable(
                name: "sys_code_gen");

            migrationBuilder.DropTable(
                name: "sys_code_gen_config");

            migrationBuilder.DropTable(
                name: "sys_config");

            migrationBuilder.DropTable(
                name: "sys_dict_data");

            migrationBuilder.DropTable(
                name: "sys_emp_ext_org_pos");

            migrationBuilder.DropTable(
                name: "sys_emp_pos");

            migrationBuilder.DropTable(
                name: "sys_file");

            migrationBuilder.DropTable(
                name: "sys_log_audit");

            migrationBuilder.DropTable(
                name: "sys_log_ex");

            migrationBuilder.DropTable(
                name: "sys_log_op");

            migrationBuilder.DropTable(
                name: "sys_log_vis");

            migrationBuilder.DropTable(
                name: "sys_notice");

            migrationBuilder.DropTable(
                name: "sys_notice_user");

            migrationBuilder.DropTable(
                name: "sys_oauth_user");

            migrationBuilder.DropTable(
                name: "sys_role_data_scope");

            migrationBuilder.DropTable(
                name: "sys_role_menu");

            migrationBuilder.DropTable(
                name: "sys_timer");

            migrationBuilder.DropTable(
                name: "sys_user_data_scope");

            migrationBuilder.DropTable(
                name: "sys_user_role");

            migrationBuilder.DropTable(
                name: "sys_dict_type");

            migrationBuilder.DropTable(
                name: "sys_emp");

            migrationBuilder.DropTable(
                name: "sys_pos");

            migrationBuilder.DropTable(
                name: "sys_menu");

            migrationBuilder.DropTable(
                name: "sys_org");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_user");
        }
    }
}

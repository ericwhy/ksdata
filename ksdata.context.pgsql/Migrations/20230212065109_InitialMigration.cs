using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ksdata.context.pgsql.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ks");

            migrationBuilder.CreateTable(
                name: "ks_user",
                schema: "ks",
                columns: table => new
                {
                    ksuserid = table.Column<string>(name: "ks_user_id", type: "character(60)", unicode: false, fixedLength: true, maxLength: 60, nullable: false),
                    displayname = table.Column<string>(name: "display_name", type: "character varying(750)", unicode: false, maxLength: 750, nullable: true),
                    emailaddress = table.Column<string>(name: "email_address", type: "character varying(750)", unicode: false, maxLength: 750, nullable: true),
                    passwordhints = table.Column<string>(name: "password_hints", type: "character(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    password = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    passwordsalt = table.Column<string>(name: "password_salt", type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    passworddt = table.Column<DateTime>(name: "password_dt", type: "timestamp with time zone", nullable: false, defaultValueSql: "(now())"),
                    allowaccessflg = table.Column<string>(name: "allow_access_flg", type: "character(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    integratedauth = table.Column<string>(name: "integrated_auth", type: "character(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
                    authprompt = table.Column<string>(name: "auth_prompt", type: "character(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('Y')"),
                    pwresetflg = table.Column<string>(name: "pwreset_flg", type: "character(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
                    failedlogincnt = table.Column<byte>(name: "failed_login_cnt", type: "smallint", nullable: true),
                    failedlogindt = table.Column<DateTime>(name: "failed_login_dt", type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ks_user_PK", x => x.ksuserid);
                });

            migrationBuilder.CreateTable(
                name: "ks_user_login_failure",
                schema: "ks",
                columns: table => new
                {
                    ksuserid = table.Column<string>(name: "ks_user_id", type: "character(60)", unicode: false, fixedLength: true, maxLength: 60, nullable: false),
                    faildt = table.Column<DateTime>(name: "fail_dt", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ks_user_login_failure_PK", x => new { x.ksuserid, x.faildt });
                    table.ForeignKey(
                        name: "ks_user_ks_user_login_failure_FK1",
                        column: x => x.ksuserid,
                        principalSchema: "ks",
                        principalTable: "ks_user",
                        principalColumn: "ks_user_id");
                });

            migrationBuilder.CreateTable(
                name: "ks_user_role",
                schema: "ks",
                columns: table => new
                {
                    ksuserid = table.Column<string>(name: "ks_user_id", type: "character(60)", unicode: false, fixedLength: true, maxLength: 60, nullable: false),
                    resourcetype = table.Column<string>(name: "resource_type", type: "character(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    resourcename = table.Column<string>(name: "resource_name", type: "character(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    roleno = table.Column<int>(name: "role_no", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ks_user_role", x => new { x.ksuserid, x.resourcetype, x.resourcename, x.roleno });
                    table.ForeignKey(
                        name: "fk_ks_user_role_ks_user",
                        column: x => x.ksuserid,
                        principalSchema: "ks",
                        principalTable: "ks_user",
                        principalColumn: "ks_user_id");
                });

            migrationBuilder.CreateTable(
                name: "ks_user_token",
                schema: "ks",
                columns: table => new
                {
                    tokenno = table.Column<int>(name: "token_no", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ksuserid = table.Column<string>(name: "ks_user_id", type: "character(60)", unicode: false, fixedLength: true, maxLength: 60, nullable: false),
                    selector = table.Column<Guid>(type: "uuid", nullable: false),
                    validatorhash = table.Column<byte[]>(name: "validator_hash", type: "bytea", fixedLength: true, maxLength: 32, nullable: false),
                    expirationdt = table.Column<DateTime>(name: "expiration_dt", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ks_user_token", x => x.tokenno);
                    table.ForeignKey(
                        name: "ks_user_ks_user_token_FK1",
                        column: x => x.ksuserid,
                        principalSchema: "ks",
                        principalTable: "ks_user",
                        principalColumn: "ks_user_id");
                });

            migrationBuilder.CreateTable(
                name: "password_history",
                schema: "ks",
                columns: table => new
                {
                    ksuserid = table.Column<string>(name: "ks_user_id", type: "character(60)", unicode: false, fixedLength: true, maxLength: 60, nullable: false),
                    password = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: false),
                    passwordsalt = table.Column<string>(name: "password_salt", type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    createdt = table.Column<DateTime>(name: "create_dt", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("password_history_PK", x => new { x.ksuserid, x.password });
                    table.ForeignKey(
                        name: "ks_user_password_history_FK1",
                        column: x => x.ksuserid,
                        principalSchema: "ks",
                        principalTable: "ks_user",
                        principalColumn: "ks_user_id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_ks_user__email_address",
                schema: "ks",
                table: "ks_user",
                column: "email_address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ks_user_token_ks_user_id",
                schema: "ks",
                table: "ks_user_token",
                column: "ks_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ks_user_login_failure",
                schema: "ks");

            migrationBuilder.DropTable(
                name: "ks_user_role",
                schema: "ks");

            migrationBuilder.DropTable(
                name: "ks_user_token",
                schema: "ks");

            migrationBuilder.DropTable(
                name: "password_history",
                schema: "ks");

            migrationBuilder.DropTable(
                name: "ks_user",
                schema: "ks");
        }
    }
}

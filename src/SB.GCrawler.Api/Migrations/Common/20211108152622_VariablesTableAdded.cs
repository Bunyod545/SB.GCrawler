using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SB.GCrawler.Api.Migrations.Common
{
    public partial class VariablesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastCrawlDate",
                schema: "public",
                table: "sites",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RobotsFileLastUpdateDate",
                schema: "public",
                table: "sites",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "variables",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variables", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "variables",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "LastCrawlDate",
                schema: "public",
                table: "sites");

            migrationBuilder.DropColumn(
                name: "RobotsFileLastUpdateDate",
                schema: "public",
                table: "sites");
        }
    }
}

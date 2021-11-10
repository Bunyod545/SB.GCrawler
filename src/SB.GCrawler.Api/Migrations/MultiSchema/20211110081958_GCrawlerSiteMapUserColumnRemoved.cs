using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.GCrawler.Api.Migrations.MultiSchema
{
    public partial class GCrawlerSiteMapUserColumnRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_site_maps_users_user_id",
                table: "site_maps");

            migrationBuilder.DropIndex(
                name: "IX_site_maps_user_id",
                table: "site_maps");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "site_maps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "site_maps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_site_maps_user_id",
                table: "site_maps",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_site_maps_users_user_id",
                table: "site_maps",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

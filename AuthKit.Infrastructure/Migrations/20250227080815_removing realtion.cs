using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthKit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removingrealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_DashboardUsers_DashboardUserId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "DashboardUserId",
                table: "Applications",
                newName: "DashboardUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_DashboardUserId",
                table: "Applications",
                newName: "IX_Applications_DashboardUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_DashboardUsers_DashboardUserId1",
                table: "Applications",
                column: "DashboardUserId1",
                principalTable: "DashboardUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_DashboardUsers_DashboardUserId1",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "DashboardUserId1",
                table: "Applications",
                newName: "DashboardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_DashboardUserId1",
                table: "Applications",
                newName: "IX_Applications_DashboardUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_DashboardUsers_DashboardUserId",
                table: "Applications",
                column: "DashboardUserId",
                principalTable: "DashboardUsers",
                principalColumn: "Id");
        }
    }
}

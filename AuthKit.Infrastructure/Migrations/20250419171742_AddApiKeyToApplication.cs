using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthKit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddApiKeyToApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Organiztions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Organiztions");

            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "Applications");
        }
    }
}

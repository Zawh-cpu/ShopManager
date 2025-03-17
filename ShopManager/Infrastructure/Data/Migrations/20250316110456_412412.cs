using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _412412 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "LoginHistories");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceInfo",
                table: "LoginHistories",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeviceInfo",
                table: "LoginHistories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LoginHistories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class expandedDeviceInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeviceInfo",
                table: "LoginHistories",
                type: "character varying(225)",
                maxLength: 225,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeviceInfo",
                table: "LoginHistories",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(225)",
                oldMaxLength: 225,
                oldNullable: true);
        }
    }
}

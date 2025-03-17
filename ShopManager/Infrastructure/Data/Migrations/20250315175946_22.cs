using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenData",
                table: "Tokens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenData",
                table: "Tokens",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

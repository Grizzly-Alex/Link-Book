using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkBook.Services.UrlAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoriteToLinksDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Favorite",
                table: "Links",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Links");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Websitemanagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class add_maintext_News_Field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsMainDescryption",
                table: "Newscategories",
                type: "nvarchar(max)",
                maxLength: 6000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsMainDescryption",
                table: "Newscategories");
        }
    }
}

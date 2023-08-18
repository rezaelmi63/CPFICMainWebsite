using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Websitemanagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Newstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Newscategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NewsHeaderDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NewsHeaderPictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NewsHeaderPictureAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NewsHeaderPictureUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    KeyWords = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newscategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlideCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HavePriceInfo = table.Column<bool>(type: "bit", nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ShowLastPriceHead = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShowLastPrice = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HeadingDescryption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlideCategories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newscategories");

            migrationBuilder.DropTable(
                name: "SlideCategories");
        }
    }
}

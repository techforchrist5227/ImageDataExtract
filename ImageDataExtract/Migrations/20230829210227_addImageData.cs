using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageDataExtract.Migrations
{
    public partial class addImageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imageDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GpsLatitude = table.Column<double>(type: "float", nullable: true),
                    GpsLongitude = table.Column<double>(type: "float", nullable: true),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageDatas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Zotik.Migrations
{
    public partial class ImageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Pads");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pads");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Pads",
                nullable: true);
        }
    }
}

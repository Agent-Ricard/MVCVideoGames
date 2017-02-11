using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCVideoGames.Data.Migrations
{
    public partial class vgdevelopers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "VideoGame");

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.ID);
                });

            migrationBuilder.AddColumn<int>(
                name: "DeveloperID",
                table: "VideoGame",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_DeveloperID",
                table: "VideoGame",
                column: "DeveloperID");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGame_Developer_DeveloperID",
                table: "VideoGame",
                column: "DeveloperID",
                principalTable: "Developer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGame_Developer_DeveloperID",
                table: "VideoGame");

            migrationBuilder.DropIndex(
                name: "IX_VideoGame_DeveloperID",
                table: "VideoGame");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "VideoGame");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "VideoGame",
                nullable: true);
        }
    }
}

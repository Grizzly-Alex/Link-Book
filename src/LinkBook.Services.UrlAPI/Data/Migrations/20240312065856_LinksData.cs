﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkBook.Services.UrlAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinksData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    AliasUrl = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    OriginalUrl = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    Tag = table.Column<string>(type: "NVARCHAR(max)", nullable: true),
                    Favorite = table.Column<byte>(type: "TINYINT", maxLength: 1, nullable: false, defaultValue: (byte)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}

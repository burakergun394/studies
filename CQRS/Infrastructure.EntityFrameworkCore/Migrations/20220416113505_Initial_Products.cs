using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class Initial_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedTime", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "P-1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-1", null },
                    { 2, "P-2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-2", null },
                    { 3, "P-3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-3", null },
                    { 4, "P-4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-4", null },
                    { 5, "P-5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-5", null },
                    { 6, "P-6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-6", null },
                    { 7, "P-7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-7", null },
                    { 8, "P-8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-8", null },
                    { 9, "P-9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-9", null },
                    { 10, "P-10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product-10", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

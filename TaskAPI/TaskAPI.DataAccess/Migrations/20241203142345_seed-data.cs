using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskAPI.DataAccess.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "AddressNo", "City", "FullName", "Street" },
                values: new object[,]
                {
                    { 1, "100", "Balangoda", "Saman Ekanayake", "Street 1" },
                    { 2, "2/E", "Matara", "Janaka Haren", "Main Street" },
                    { 3, "100/2", "Matara", "Aruna Shantha", "Flower Street" },
                    { 4, "300/a", "Colombo", "Piyal Perera", "Street 1" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "Due", "Status", "Title" },
                values: new object[] { 1, 1, new DateTime(2024, 12, 3, 19, 53, 45, 133, DateTimeKind.Local).AddTicks(5283), "Need to go bank for some deposits", new DateTime(2024, 12, 8, 19, 53, 45, 133, DateTimeKind.Local).AddTicks(5289), 0, "Go to Bank" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

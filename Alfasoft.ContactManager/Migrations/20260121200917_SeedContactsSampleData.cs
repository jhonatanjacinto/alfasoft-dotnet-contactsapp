using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alfasoft.ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class SeedContactsSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "Name", "Phone", "Status" },
                values: new object[,]
                {
                    { 1u, "johndoe@gmail.com", "John Doe", "123456789", "Active" },
                    { 2u, "janesmith@gmail.com", "Jane Smith", "333666444", "Active" },
                    { 3u, "alicejohnson@outlook.com", "Alice Johnson", "111555777", "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3u);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"), "Medium" },
                    { new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"), "Easy" },
                    { new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("390b81b6-0879-481a-8720-42f5b8637c41"), "NSN", "Nelson", "https://test.com/image5.png" },
                    { new Guid("51440791-8a91-4e61-8f6d-602860252f93"), "WGN", "Wellington", "https://test.com/image4.png" },
                    { new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"), "BOP", "Bay of Plenty", "https://test.com/image3.png" },
                    { new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"), "NTL", "NorthLand", "https://test.com/image2.png" },
                    { new Guid("b082d575-2826-4277-91f5-d300ddcf3438"), "AKL", "AuckLand", "https://test.com/image1.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("390b81b6-0879-481a-8720-42f5b8637c41"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("51440791-8a91-4e61-8f6d-602860252f93"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b082d575-2826-4277-91f5-d300ddcf3438"));
        }
    }
}

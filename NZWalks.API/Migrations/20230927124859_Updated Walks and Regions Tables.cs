using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedWalksandRegionsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Difficulties");

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1739), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1739) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1729), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1742), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1743) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("390b81b6-0879-481a-8720-42f5b8637c41"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1838), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("51440791-8a91-4e61-8f6d-602860252f93"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1835), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1836) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1832), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1828), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1829) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b082d575-2826-4277-91f5-d300ddcf3438"),
                columns: new[] { "AddedDate", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1822), 1, new DateTime(2023, 9, 27, 12, 48, 59, 476, DateTimeKind.Utc).AddTicks(1823) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Walks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Regions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Difficulties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(947), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(947) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(922), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(949), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("390b81b6-0879-481a-8720-42f5b8637c41"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1038), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1038) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("51440791-8a91-4e61-8f6d-602860252f93"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1036), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1033), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1030), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b082d575-2826-4277-91f5-d300ddcf3438"),
                columns: new[] { "AddedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1023), false, 0, new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1024) });
        }
    }
}

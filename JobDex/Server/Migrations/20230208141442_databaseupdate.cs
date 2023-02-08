using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobDex.Server.Migrations
{
    public partial class Databaseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 746, DateTimeKind.Local).AddTicks(1505), new DateTime(2023, 2, 8, 22, 14, 41, 746, DateTimeKind.Local).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 746, DateTimeKind.Local).AddTicks(1512), new DateTime(2023, 2, 8, 22, 14, 41, 746, DateTimeKind.Local).AddTicks(1513) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(4813), new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(4822), new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(8818), new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(8827), new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(8828) });

            migrationBuilder.UpdateData(
                table: "StaffDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(1578), new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "StaffDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(1588), new DateTime(2023, 2, 8, 22, 14, 41, 745, DateTimeKind.Local).AddTicks(1588) });

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 743, DateTimeKind.Local).AddTicks(4964), new DateTime(2023, 2, 8, 22, 14, 41, 744, DateTimeKind.Local).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 14, 41, 744, DateTimeKind.Local).AddTicks(1802), new DateTime(2023, 2, 8, 22, 14, 41, 744, DateTimeKind.Local).AddTicks(1806) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(5887), new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(5897), new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(5898) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(8558), new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(8569), new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(8570) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(2673), new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(2679) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(2683), new DateTime(2023, 2, 8, 22, 3, 16, 382, DateTimeKind.Local).AddTicks(2684) });

            migrationBuilder.UpdateData(
                table: "StaffDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(4318), new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "StaffDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(4343), new DateTime(2023, 2, 8, 22, 3, 16, 381, DateTimeKind.Local).AddTicks(4344) });

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 378, DateTimeKind.Local).AddTicks(6078), new DateTime(2023, 2, 8, 22, 3, 16, 379, DateTimeKind.Local).AddTicks(6893) });

            migrationBuilder.UpdateData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 8, 22, 3, 16, 379, DateTimeKind.Local).AddTicks(8197), new DateTime(2023, 2, 8, 22, 3, 16, 379, DateTimeKind.Local).AddTicks(8205) });
        }
    }
}

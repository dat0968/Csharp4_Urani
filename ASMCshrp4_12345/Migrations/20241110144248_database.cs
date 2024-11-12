using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sdt",
                table: "Nhacungcaps",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD002",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 13) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD003",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 11) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD004",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 15) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD005",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD006",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 13) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD007",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 14) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD008",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD009",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 15) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD010",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 13) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD011",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD012",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 15) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD013",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD014",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 13) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD015",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 14) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD016",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD017",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 13) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD018",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 14) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD019",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD020",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 13) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sdt",
                table: "Nhacungcaps",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD002",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD003",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD004",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD005",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD006",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD007",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 11) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD008",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD009",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD010",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD011",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD012",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 12) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD013",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD014",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD015",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 11) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD016",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD017",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD018",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 11) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD019",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD020",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 7), new DateOnly(2024, 11, 10) });
        }
    }
}

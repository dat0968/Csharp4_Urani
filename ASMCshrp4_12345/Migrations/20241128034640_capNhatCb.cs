using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class capNhatCb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenChatLieu",
                table: "CtComBos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenKichThuoc",
                table: "CtComBos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenMau",
                table: "CtComBos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaComBo_ThuocTinhSuyDien",
                table: "Chitiethoadons",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 28, 9, 46, 37, 648, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 28, 8, 46, 37, 648, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 10, 46, 37, 648, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 26, 10, 46, 37, 648, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 10, 46, 37, 648, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 1,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 2,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 3,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 4,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 5,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 6,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 7,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 8,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 9,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chitiethoadons",
                keyColumn: "MaChiTietHoaDon",
                keyValue: 10,
                column: "MaComBo_ThuocTinhSuyDien",
                value: null);

            migrationBuilder.UpdateData(
                table: "CtComBos",
                keyColumn: "MaCtComBo",
                keyValue: 1,
                columns: new[] { "TenChatLieu", "TenKichThuoc", "TenMau" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "CtComBos",
                keyColumn: "MaCtComBo",
                keyValue: 2,
                columns: new[] { "TenChatLieu", "TenKichThuoc", "TenMau" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD002",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD003",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD004",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 3) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD005",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD006",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD007",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 2) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD008",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD009",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 3) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD010",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD011",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD012",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 3) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD013",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD014",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD015",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 2) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD016",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD017",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD018",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 2) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD019",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD020",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 28, 10, 31, 37, 648, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 28, 10, 16, 37, 648, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 28, 10, 1, 37, 648, DateTimeKind.Local).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 28, 9, 46, 37, 648, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 28, 9, 16, 37, 648, DateTimeKind.Local).AddTicks(8293));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenChatLieu",
                table: "CtComBos");

            migrationBuilder.DropColumn(
                name: "TenKichThuoc",
                table: "CtComBos");

            migrationBuilder.DropColumn(
                name: "TenMau",
                table: "CtComBos");

            migrationBuilder.DropColumn(
                name: "MaComBo_ThuocTinhSuyDien",
                table: "Chitiethoadons");

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 21, 25, 24, 427, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 20, 25, 24, 427, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 26, 22, 25, 24, 427, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 22, 25, 24, 427, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 24, 22, 25, 24, 427, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD002",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD003",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 28) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD004",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 12, 2) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD005",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD006",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD007",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD008",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD009",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 12, 2) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD010",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD011",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD012",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 12, 2) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD013",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD014",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD015",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD016",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD017",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD018",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD019",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD020",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 22, 10, 24, 427, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 21, 55, 24, 427, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 21, 40, 24, 427, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 21, 25, 24, 427, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 27, 20, 55, 24, 427, DateTimeKind.Local).AddTicks(8108));
        }
    }
}

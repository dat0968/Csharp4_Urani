using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class addDataBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "NgaySinh",
                table: "Nhanviens",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "Nhanviens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cccd",
                table: "Nhanviens",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Hoadons",
                columns: new[] { "MaHoaDon", "DiaChiNhanHang", "Hoten", "Httt", "MaKh", "MaNv", "MoTa", "NgayTao", "Sdt", "ThoiGianDat", "ThoiGianGiao", "TinhTrang" },
                values: new object[] { "HD001", "123 Đường A, Quận B, Thành phố C", "Nguyễn Văn A", "Tiền mặt", "KH425", "NV001", null, new DateOnly(2024, 1, 10), "0123456789", new DateOnly(2024, 1, 9), null, "Đang xử lý" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "NgaySinh",
                table: "Nhanviens",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "Nhanviens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cccd",
                table: "Nhanviens",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}

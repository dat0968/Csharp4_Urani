using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietchatlieu_Chatlieus_MaChatLieu",
                table: "Chitietchatlieu");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietchatlieu_Sanphams_MaSp",
                table: "Chitietchatlieu");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietkichthuoc_Kichthuocs_MaKichThuoc",
                table: "Chitietkichthuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietkichthuoc_Sanphams_MaSp",
                table: "Chitietkichthuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietmausac_Mausacs_MaMau",
                table: "Chitietmausac");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietmausac_Sanphams_MaSp",
                table: "Chitietmausac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietmausac",
                table: "Chitietmausac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietkichthuoc",
                table: "Chitietkichthuoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietchatlieu",
                table: "Chitietchatlieu");

            migrationBuilder.RenameTable(
                name: "Chitietmausac",
                newName: "Chitietmausacs");

            migrationBuilder.RenameTable(
                name: "Chitietkichthuoc",
                newName: "Chitietkichthuocs");

            migrationBuilder.RenameTable(
                name: "Chitietchatlieu",
                newName: "Chitietchatlieus");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietmausac_MaSp",
                table: "Chitietmausacs",
                newName: "IX_Chitietmausacs_MaSp");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietkichthuoc_MaSp",
                table: "Chitietkichthuocs",
                newName: "IX_Chitietkichthuocs_MaSp");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietchatlieu_MaSp",
                table: "Chitietchatlieus",
                newName: "IX_Chitietchatlieus_MaSp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietmausacs",
                table: "Chitietmausacs",
                columns: new[] { "MaMau", "MaSp" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietkichthuocs",
                table: "Chitietkichthuocs",
                columns: new[] { "MaKichThuoc", "MaSp" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietchatlieus",
                table: "Chitietchatlieus",
                columns: new[] { "MaChatLieu", "MaSp" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietchatlieus_Chatlieus_MaChatLieu",
                table: "Chitietchatlieus",
                column: "MaChatLieu",
                principalTable: "Chatlieus",
                principalColumn: "MaChatLieu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietchatlieus_Sanphams_MaSp",
                table: "Chitietchatlieus",
                column: "MaSp",
                principalTable: "Sanphams",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietkichthuocs_Kichthuocs_MaKichThuoc",
                table: "Chitietkichthuocs",
                column: "MaKichThuoc",
                principalTable: "Kichthuocs",
                principalColumn: "MaKichThuoc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietkichthuocs_Sanphams_MaSp",
                table: "Chitietkichthuocs",
                column: "MaSp",
                principalTable: "Sanphams",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietmausacs_Mausacs_MaMau",
                table: "Chitietmausacs",
                column: "MaMau",
                principalTable: "Mausacs",
                principalColumn: "MaMau",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietmausacs_Sanphams_MaSp",
                table: "Chitietmausacs",
                column: "MaSp",
                principalTable: "Sanphams",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietchatlieus_Chatlieus_MaChatLieu",
                table: "Chitietchatlieus");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietchatlieus_Sanphams_MaSp",
                table: "Chitietchatlieus");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietkichthuocs_Kichthuocs_MaKichThuoc",
                table: "Chitietkichthuocs");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietkichthuocs_Sanphams_MaSp",
                table: "Chitietkichthuocs");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietmausacs_Mausacs_MaMau",
                table: "Chitietmausacs");

            migrationBuilder.DropForeignKey(
                name: "FK_Chitietmausacs_Sanphams_MaSp",
                table: "Chitietmausacs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietmausacs",
                table: "Chitietmausacs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietkichthuocs",
                table: "Chitietkichthuocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietchatlieus",
                table: "Chitietchatlieus");

            migrationBuilder.RenameTable(
                name: "Chitietmausacs",
                newName: "Chitietmausac");

            migrationBuilder.RenameTable(
                name: "Chitietkichthuocs",
                newName: "Chitietkichthuoc");

            migrationBuilder.RenameTable(
                name: "Chitietchatlieus",
                newName: "Chitietchatlieu");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietmausacs_MaSp",
                table: "Chitietmausac",
                newName: "IX_Chitietmausac_MaSp");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietkichthuocs_MaSp",
                table: "Chitietkichthuoc",
                newName: "IX_Chitietkichthuoc_MaSp");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietchatlieus_MaSp",
                table: "Chitietchatlieu",
                newName: "IX_Chitietchatlieu_MaSp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietmausac",
                table: "Chitietmausac",
                columns: new[] { "MaMau", "MaSp" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietkichthuoc",
                table: "Chitietkichthuoc",
                columns: new[] { "MaKichThuoc", "MaSp" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietchatlieu",
                table: "Chitietchatlieu",
                columns: new[] { "MaChatLieu", "MaSp" });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD002",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD003",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 7) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD004",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 11) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD005",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD006",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD007",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD008",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD009",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 11) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD010",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD011",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD012",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 11) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD013",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD014",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD015",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD016",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD017",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD018",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 10) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD019",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD020",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9) });

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietchatlieu_Chatlieus_MaChatLieu",
                table: "Chitietchatlieu",
                column: "MaChatLieu",
                principalTable: "Chatlieus",
                principalColumn: "MaChatLieu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietchatlieu_Sanphams_MaSp",
                table: "Chitietchatlieu",
                column: "MaSp",
                principalTable: "Sanphams",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietkichthuoc_Kichthuocs_MaKichThuoc",
                table: "Chitietkichthuoc",
                column: "MaKichThuoc",
                principalTable: "Kichthuocs",
                principalColumn: "MaKichThuoc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietkichthuoc_Sanphams_MaSp",
                table: "Chitietkichthuoc",
                column: "MaSp",
                principalTable: "Sanphams",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietmausac_Mausacs_MaMau",
                table: "Chitietmausac",
                column: "MaMau",
                principalTable: "Mausacs",
                principalColumn: "MaMau",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietmausac_Sanphams_MaSp",
                table: "Chitietmausac",
                column: "MaSp",
                principalTable: "Sanphams",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

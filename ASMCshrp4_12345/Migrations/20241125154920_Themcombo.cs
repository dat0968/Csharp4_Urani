using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class Themcombo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComBos",
                columns: table => new
                {
                    MaComBo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenComBo = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComBos", x => x.MaComBo);
                });

            migrationBuilder.CreateTable(
                name: "CtComBos",
                columns: table => new
                {
                    MaCtComBo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaComBo = table.Column<int>(type: "int", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CtComBos", x => x.MaCtComBo);
                    table.ForeignKey(
                        name: "FK_CtComBos_ComBos_MaComBo",
                        column: x => x.MaComBo,
                        principalTable: "ComBos",
                        principalColumn: "MaComBo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CtComBos_Sanphams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "Sanphams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 21, 49, 18, 681, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 20, 49, 18, 681, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 24, 22, 49, 18, 681, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 23, 22, 49, 18, 681, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 22, 22, 49, 18, 681, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.InsertData(
                table: "ComBos",
                columns: new[] { "MaComBo", "DonGia", "SoLuong", "TenComBo" },
                values: new object[] { 1, 1000000.0, 2, "Combo test" });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD002",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 28) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD003",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 26) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD004",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD005",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD006",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 28) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD007",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD008",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD009",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD010",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 28) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD011",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD012",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 30) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD013",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD014",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 28) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD015",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD016",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD017",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 28) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD018",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD019",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD020",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 28) });

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 22, 34, 18, 681, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 22, 19, 18, 681, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 22, 4, 18, 681, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 21, 49, 18, 681, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 25, 21, 19, 18, 681, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.InsertData(
                table: "CtComBos",
                columns: new[] { "MaCtComBo", "DonGia", "MaComBo", "MaSp", "SoLuong" },
                values: new object[,]
                {
                    { 1, 600000.0, 1, "SP001", 1 },
                    { 2, 600000.0, 1, "SP002", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CtComBos_MaComBo",
                table: "CtComBos",
                column: "MaComBo");

            migrationBuilder.CreateIndex(
                name: "IX_CtComBos_MaSp",
                table: "CtComBos",
                column: "MaSp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CtComBos");

            migrationBuilder.DropTable(
                name: "ComBos");

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 18, 22, 10, 14, 72, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 18, 21, 10, 14, 72, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 17, 23, 10, 14, 72, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 16, 23, 10, 14, 72, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Binhluans",
                keyColumn: "IdBinhLuan",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 15, 23, 10, 14, 72, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD001",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 20) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD002",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 21) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD003",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 19) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD004",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 23) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD005",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 20) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD006",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 21) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD007",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 22) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD008",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 20) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD009",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 23) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD010",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 21) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD011",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 20) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD012",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 23) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD013",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 20) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD014",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 21) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD015",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 22) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD016",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 20) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD017",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 21) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD018",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 22) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD019",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 20) });

            migrationBuilder.UpdateData(
                table: "Hoadons",
                keyColumn: "MaHoaDon",
                keyValue: "HD020",
                columns: new[] { "NgayTao", "ThoiGianDat", "ThoiGianGiao" },
                values: new object[] { new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 18), new DateOnly(2024, 11, 21) });

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 18, 22, 55, 14, 72, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 18, 22, 40, 14, 72, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 18, 22, 25, 14, 72, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 18, 22, 10, 14, 72, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Traloibinhluans",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThoiGian",
                value: new DateTime(2024, 11, 18, 21, 40, 14, 72, DateTimeKind.Local).AddTicks(1341));
        }
    }
}

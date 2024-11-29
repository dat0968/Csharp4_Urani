using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class AnhComBo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "ComBos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnhComBos",
                columns: table => new
                {
                    IdAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaComBo = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhComBos", x => x.IdAnh);
                    table.ForeignKey(
                        name: "FK_AnhComBos_ComBos_MaComBo",
                        column: x => x.MaComBo,
                        principalTable: "ComBos",
                        principalColumn: "MaComBo",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "ComBos",
                keyColumn: "MaComBo",
                keyValue: 1,
                column: "MoTa",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_AnhComBos_MaComBo",
                table: "AnhComBos",
                column: "MaComBo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhComBos");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "ComBos");

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
        }
    }
}

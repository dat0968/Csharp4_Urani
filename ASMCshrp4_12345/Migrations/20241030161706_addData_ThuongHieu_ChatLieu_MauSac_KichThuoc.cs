using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class addData_ThuongHieu_ChatLieu_MauSac_KichThuoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chatlieus",
                columns: new[] { "MaChatLieu", "IsDelete", "TenChatLieu" },
                values: new object[,]
                {
                    { "CL001", false, "Da Thật" },
                    { "CL002", false, "Vải" },
                    { "CL003", false, "Nhựa" },
                    { "CL004", false, "Toàn Bộ" },
                    { "CL005", false, "Cotton" }
                });

            migrationBuilder.InsertData(
                table: "Kichthuocs",
                columns: new[] { "MaKichThuoc", "IsDelete", "KichThuoc1", "TenKichThuoc" },
                values: new object[,]
                {
                    { "KT001", false, "20 x 15 x 10", "Nhỏ" },
                    { "KT002", false, "30 x 25 x 15", "Trung Bình" },
                    { "KT003", false, "40 x 30 x 20", "Lớn" }
                });

            migrationBuilder.InsertData(
                table: "Mausacs",
                columns: new[] { "MaMau", "IsDelete", "TenMau" },
                values: new object[,]
                {
                    { "MM001", false, "Đỏ" },
                    { "MM002", false, "Xanh" },
                    { "MM003", false, "Vàng" },
                    { "MM004", false, "Trắng" },
                    { "MM005", false, "Đen" }
                });

            migrationBuilder.InsertData(
                table: "Thuonghieus",
                columns: new[] { "MaThuongHieu", "IsDelete", "TenThuongHieu" },
                values: new object[,]
                {
                    { "TH001", false, "Gucci" },
                    { "TH002", false, "Louis Vuitton" },
                    { "TH003", false, "Chanel" },
                    { "TH004", false, "Prada" },
                    { "TH005", false, "Michael Kors" },
                    { "TH006", false, "Hermès" },
                    { "TH007", false, "Coach" },
                    { "TH008", false, "Kate Spade" },
                    { "TH009", false, "Fossil" },
                    { "TH010", false, "Calvin Klein" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chatlieus",
                keyColumn: "MaChatLieu",
                keyValue: "CL001");

            migrationBuilder.DeleteData(
                table: "Chatlieus",
                keyColumn: "MaChatLieu",
                keyValue: "CL002");

            migrationBuilder.DeleteData(
                table: "Chatlieus",
                keyColumn: "MaChatLieu",
                keyValue: "CL003");

            migrationBuilder.DeleteData(
                table: "Chatlieus",
                keyColumn: "MaChatLieu",
                keyValue: "CL004");

            migrationBuilder.DeleteData(
                table: "Chatlieus",
                keyColumn: "MaChatLieu",
                keyValue: "CL005");

            migrationBuilder.DeleteData(
                table: "Kichthuocs",
                keyColumn: "MaKichThuoc",
                keyValue: "KT001");

            migrationBuilder.DeleteData(
                table: "Kichthuocs",
                keyColumn: "MaKichThuoc",
                keyValue: "KT002");

            migrationBuilder.DeleteData(
                table: "Kichthuocs",
                keyColumn: "MaKichThuoc",
                keyValue: "KT003");

            migrationBuilder.DeleteData(
                table: "Mausacs",
                keyColumn: "MaMau",
                keyValue: "MM001");

            migrationBuilder.DeleteData(
                table: "Mausacs",
                keyColumn: "MaMau",
                keyValue: "MM002");

            migrationBuilder.DeleteData(
                table: "Mausacs",
                keyColumn: "MaMau",
                keyValue: "MM003");

            migrationBuilder.DeleteData(
                table: "Mausacs",
                keyColumn: "MaMau",
                keyValue: "MM004");

            migrationBuilder.DeleteData(
                table: "Mausacs",
                keyColumn: "MaMau",
                keyValue: "MM005");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH001");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH002");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH003");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH004");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH005");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH006");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH007");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH008");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH009");

            migrationBuilder.DeleteData(
                table: "Thuonghieus",
                keyColumn: "MaThuongHieu",
                keyValue: "TH010");
        }
    }
}

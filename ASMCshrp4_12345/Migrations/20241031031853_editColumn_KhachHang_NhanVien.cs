using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class editColumn_KhachHang_NhanVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Nhanviens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Khachhangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Nhanviens",
                keyColumn: "MaNv",
                keyValue: "NV001",
                column: "Avatar",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Nhanviens");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Khachhangs");
        }
    }
}

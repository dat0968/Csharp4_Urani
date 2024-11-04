using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class createDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatlieus",
                columns: table => new
                {
                    MaChatLieu = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TenChatLieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatlieus", x => x.MaChatLieu);
                });

            migrationBuilder.CreateTable(
                name: "Khachhangs",
                columns: table => new
                {
                    MaKh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhangs", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "Kichthuocs",
                columns: table => new
                {
                    MaKichThuoc = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TenKichThuoc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    KichThuoc1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kichthuocs", x => x.MaKichThuoc);
                });

            migrationBuilder.CreateTable(
                name: "Mausacs",
                columns: table => new
                {
                    MaMau = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TenMau = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mausacs", x => x.MaMau);
                });

            migrationBuilder.CreateTable(
                name: "Nhacungcaps",
                columns: table => new
                {
                    MaNhaCc = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TenNhaCc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhacungcaps", x => x.MaNhaCc);
                });

            migrationBuilder.CreateTable(
                name: "Nhanviens",
                columns: table => new
                {
                    MaNv = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayVaoLam = table.Column<DateOnly>(type: "date", nullable: false),
                    Luong = table.Column<int>(type: "int", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanviens", x => x.MaNv);
                });

            migrationBuilder.CreateTable(
                name: "Phieunhaps",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ThoiGianNhap = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieunhaps", x => x.MaPhieuNhap);
                });

            migrationBuilder.CreateTable(
                name: "Thuonghieus",
                columns: table => new
                {
                    MaThuongHieu = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuonghieus", x => x.MaThuongHieu);
                });

            migrationBuilder.CreateTable(
                name: "Hoadons",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DiaChiNhanHang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgayTao = table.Column<DateOnly>(type: "date", nullable: false),
                    Httt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaNv = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MaKh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hoten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    ThoiGianDat = table.Column<DateOnly>(type: "date", nullable: false),
                    ThoiGianGiao = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadons", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_Hoadons_Khachhangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "Khachhangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hoadons_Nhanviens_MaNv",
                        column: x => x.MaNv,
                        principalTable: "Nhanviens",
                        principalColumn: "MaNv");
                });

            migrationBuilder.CreateTable(
                name: "Sanphams",
                columns: table => new
                {
                    MaSp = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SoLuongBan = table.Column<int>(type: "int", nullable: false),
                    DonGiaBan = table.Column<double>(type: "float", nullable: false),
                    MaThuongHieu = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySanXuat = table.Column<DateOnly>(type: "date", nullable: false),
                    MaNhaCc = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MaChatLieu = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MaMau = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MaKichThuoc = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanphams", x => x.MaSp);
                    table.ForeignKey(
                        name: "FK_Sanphams_Chatlieus_MaChatLieu",
                        column: x => x.MaChatLieu,
                        principalTable: "Chatlieus",
                        principalColumn: "MaChatLieu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanphams_Kichthuocs_MaKichThuoc",
                        column: x => x.MaKichThuoc,
                        principalTable: "Kichthuocs",
                        principalColumn: "MaKichThuoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanphams_Mausacs_MaMau",
                        column: x => x.MaMau,
                        principalTable: "Mausacs",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanphams_Nhacungcaps_MaNhaCc",
                        column: x => x.MaNhaCc,
                        principalTable: "Nhacungcaps",
                        principalColumn: "MaNhaCc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sanphams_Thuonghieus_MaThuongHieu",
                        column: x => x.MaThuongHieu,
                        principalTable: "Thuonghieus",
                        principalColumn: "MaThuongHieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitiethoadons",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SoLuongMua = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitiethoadons", x => new { x.MaHoaDon, x.MaSp });
                    table.ForeignKey(
                        name: "FK_Chitiethoadons_Hoadons_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "Hoadons",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitiethoadons_Sanphams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "Sanphams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitietphieunhaps",
                columns: table => new
                {
                    MaCtpn = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    SoluongNhap = table.Column<int>(type: "int", nullable: false),
                    DonGiaNhap = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietphieunhaps", x => x.MaCtpn);
                    table.ForeignKey(
                        name: "FK_Chitietphieunhaps_Phieunhaps_MaPhieuNhap",
                        column: x => x.MaPhieuNhap,
                        principalTable: "Phieunhaps",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietphieunhaps_Sanphams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "Sanphams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hinhanhs",
                columns: table => new
                {
                    MaHinhAnh = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinhanhs", x => x.MaHinhAnh);
                    table.ForeignKey(
                        name: "FK_Hinhanhs_Sanphams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "Sanphams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nhanviens",
                columns: new[] { "MaNv", "Cccd", "DiaChi", "Email", "GioiTinh", "HoTen", "IsDelete", "Luong", "MatKhau", "NgaySinh", "NgayVaoLam", "Sdt", "TenTaiKhoan", "TinhTrang", "VaiTro" },
                values: new object[] { "NV001", "123456789", "BMT", "thanhdat0968367@gmail.com", "Nam", "Admin", false, 10000000, "Admin123", new DateOnly(2005, 2, 23), new DateOnly(2023, 1, 1), "0123456789", "Admin", "Hoạt động", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Chitiethoadons_MaSp",
                table: "Chitiethoadons",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietphieunhaps_MaPhieuNhap",
                table: "Chitietphieunhaps",
                column: "MaPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietphieunhaps_MaSp",
                table: "Chitietphieunhaps",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_Hinhanhs_MaSp",
                table: "Hinhanhs",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_MaKh",
                table: "Hoadons",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_MaNv",
                table: "Hoadons",
                column: "MaNv");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_MaChatLieu",
                table: "Sanphams",
                column: "MaChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_MaKichThuoc",
                table: "Sanphams",
                column: "MaKichThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_MaMau",
                table: "Sanphams",
                column: "MaMau");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_MaNhaCc",
                table: "Sanphams",
                column: "MaNhaCc");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_MaThuongHieu",
                table: "Sanphams",
                column: "MaThuongHieu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitiethoadons");

            migrationBuilder.DropTable(
                name: "Chitietphieunhaps");

            migrationBuilder.DropTable(
                name: "Hinhanhs");

            migrationBuilder.DropTable(
                name: "Hoadons");

            migrationBuilder.DropTable(
                name: "Phieunhaps");

            migrationBuilder.DropTable(
                name: "Sanphams");

            migrationBuilder.DropTable(
                name: "Khachhangs");

            migrationBuilder.DropTable(
                name: "Nhanviens");

            migrationBuilder.DropTable(
                name: "Chatlieus");

            migrationBuilder.DropTable(
                name: "Kichthuocs");

            migrationBuilder.DropTable(
                name: "Mausacs");

            migrationBuilder.DropTable(
                name: "Nhacungcaps");

            migrationBuilder.DropTable(
                name: "Thuonghieus");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASMCshrp4_12345.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatlieus",
                columns: table => new
                {
                    MaChatLieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    MaKichThuoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    MaMau = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cccd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanphams", x => x.MaSp);
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
                name: "Chitietchatlieu",
                columns: table => new
                {
                    MaChatLieu = table.Column<int>(type: "int", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietchatlieu", x => new { x.MaChatLieu, x.MaSp });
                    table.ForeignKey(
                        name: "FK_Chitietchatlieu_Chatlieus_MaChatLieu",
                        column: x => x.MaChatLieu,
                        principalTable: "Chatlieus",
                        principalColumn: "MaChatLieu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietchatlieu_Sanphams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "Sanphams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitiethoadons",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MauSac_ThuocTinhSuyDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KichThuoc_ThuocTinhSuyDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChatLieu_ThuocTinhSuyDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Chitietkichthuoc",
                columns: table => new
                {
                    MaKichThuoc = table.Column<int>(type: "int", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietkichthuoc", x => new { x.MaKichThuoc, x.MaSp });
                    table.ForeignKey(
                        name: "FK_Chitietkichthuoc_Kichthuocs_MaKichThuoc",
                        column: x => x.MaKichThuoc,
                        principalTable: "Kichthuocs",
                        principalColumn: "MaKichThuoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietkichthuoc_Sanphams_MaSp",
                        column: x => x.MaSp,
                        principalTable: "Sanphams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitietmausac",
                columns: table => new
                {
                    MaMau = table.Column<int>(type: "int", nullable: false),
                    MaSp = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietmausac", x => new { x.MaMau, x.MaSp });
                    table.ForeignKey(
                        name: "FK_Chitietmausac_Mausacs_MaMau",
                        column: x => x.MaMau,
                        principalTable: "Mausacs",
                        principalColumn: "MaMau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitietmausac_Sanphams_MaSp",
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
                table: "Chatlieus",
                columns: new[] { "MaChatLieu", "IsDelete", "TenChatLieu" },
                values: new object[,]
                {
                    { 1, false, "Da Thật" },
                    { 2, false, "Vải" },
                    { 3, false, "Nhựa" }
                });

            migrationBuilder.InsertData(
                table: "Khachhangs",
                columns: new[] { "MaKh", "Avatar", "Cccd", "DiaChi", "Email", "GioiTinh", "HoTen", "IsDelete", "MatKhau", "NgaySinh", "Sdt", "TenTaiKhoan", "TinhTrang" },
                values: new object[,]
                {
                    { "KH001", "images (1).jfif", "123456789", "123 Đường ABC", "email1@example.com", "Nam", "Nguyễn Văn A", false, "password1", new DateOnly(1990, 1, 15), "0901234567", "user1", "Đang hoạt động" },
                    { "KH002", "anh-chan-dung-dep-yodyvn1.jpg", "987654321", "456 Đường DEF", "email2@example.com", "Nữ", "Trần Thị B", false, "password2", new DateOnly(1995, 5, 20), "0912345678", "user2", "Đang hoạt động" },
                    { "KH003", "photo-1-15997930085231081781532.webp", "321654987", "789 Đường GHI", "email3@example.com", "Nam", "Lê Văn C", false, "password3", new DateOnly(1988, 3, 25), "0923456789", "user3", "Đang hoạt động" },
                    { "KH004", "tao-dang-chup-anh-chan-dung-01.jpg", "654987321", "321 Đường JKL", "email4@example.com", "Nữ", "Phạm Thị D", false, "password4", new DateOnly(1992, 7, 30), "0934567890", "user4", "Đang hoạt động" },
                    { "KH005", "anh-chan-dung-dep-yodyvn1.jpg", "123123123", "654 Đường MNO", "email5@example.com", "Nam", "Ngô Văn E", false, "password5", new DateOnly(1985, 2, 14), "0945678901", "user5", "Đang hoạt động" },
                    { "KH006", "images (1).jfif", "321321321", "987 Đường PQR", "email6@example.com", "Nữ", "Đỗ Thị F", false, "password6", new DateOnly(1993, 8, 10), "0956789012", "user6", "Đang hoạt động" },
                    { "KH007", "images.jfif", "456456456", "147 Đường STU", "email7@example.com", "Nam", "Bùi Văn G", false, "password7", new DateOnly(1991, 12, 5), "0967890123", "user7", "Đang hoạt động" },
                    { "KH008", "photo-1-15997930085231081781532.webp", "789789789", "258 Đường VWX", "email8@example.com", "Nữ", "Vũ Thị H", false, "password8", new DateOnly(1994, 11, 18), "0978901234", "user8", "Đang hoạt động" },
                    { "KH009", "tao-dang-chup-anh-chan-dung-01.jpg", "159159159", "369 Đường YZ", "email9@example.com", "Nam", "Hoàng Văn I", false, "password9", new DateOnly(1989, 4, 22), "0989012345", "user9", "Đang hoạt động" },
                    { "KH010", "anh-chan-dung-dep-yodyvn1.jpg", "753753753", "753 Đường ABCD", "email10@example.com", "Nữ", "Nguyễn Thị J", false, "password10", new DateOnly(1996, 9, 29), "0912345678", "user10", "Đang hoạt động" },
                    { "KH011", "tao-dang-chup-anh-chan-dung-01.jpg", "258258258", "147 Đường EFGH", "email11@example.com", "Nam", "Trần Văn K", false, "password11", new DateOnly(1987, 6, 12), "0923456789", "user11", "Đang hoạt động" },
                    { "KH012", "photo-1-15997930085231081781532.webp", "159159159", "369 Đường IJKL", "email12@example.com", "Nữ", "Lê Thị L", false, "password12", new DateOnly(1990, 3, 15), "0934567890", "user12", "Đang hoạt động" },
                    { "KH013", "anh-chan-dung-dep-yodyvn1.jpg", "753753753", "258 Đường MNOP", "email13@example.com", "Nam", "Ngô Văn M", false, "password13", new DateOnly(1985, 1, 21), "0945678901", "user13", "Đang hoạt động" }
                });

            migrationBuilder.InsertData(
                table: "Kichthuocs",
                columns: new[] { "MaKichThuoc", "IsDelete", "KichThuoc1", "TenKichThuoc" },
                values: new object[,]
                {
                    { 1, false, "20 x 15 x 10", "Nhỏ" },
                    { 2, false, "30 x 25 x 15", "Trung Bình" },
                    { 3, false, "40 x 30 x 20", "Lớn" }
                });

            migrationBuilder.InsertData(
                table: "Mausacs",
                columns: new[] { "MaMau", "IsDelete", "TenMau" },
                values: new object[,]
                {
                    { 1, false, "Đỏ" },
                    { 2, false, "Xanh" },
                    { 3, false, "Vàng" },
                    { 4, false, "Trắng" },
                    { 5, false, "Đen" }
                });

            migrationBuilder.InsertData(
                table: "Nhacungcaps",
                columns: new[] { "MaNhaCc", "DiaChi", "Email", "IsDelete", "Sdt", "TenNhaCc" },
                values: new object[,]
                {
                    { "NCC01", "Via Tornabuoni 73r, Florence, Italy", "contact@gucci.com", false, "0123456789", "Gucci Ltd." },
                    { "NCC02", "22 Avenue Montaigne, Paris, France", "support@louisvuitton.com", false, "0987654321", "Louis Vuitton S.A." },
                    { "NCC03", "135 Avenue Charles de Gaulle, Neuilly-sur-Seine, France", "info@chanel.com", false, "0234567890", "Chanel Inc." },
                    { "NCC04", "Via Antonio Fogazzaro 28, Milan, Italy", "contact@prada.com", false, "0789123456", "Prada S.p.A." },
                    { "NCC05", "11 W 42nd St, New York, USA", "support@michaelkors.com", false, "0543216789", "Michael Kors Holdings Ltd." },
                    { "NCC06", "24 Rue du Faubourg Saint-Honoré, Paris, France", "info@hermes.com", false, "0645372910", "Hermès International S.A." },
                    { "NCC07", "10 Hudson Yards, New York, USA", "contact@coach.com", false, "0823451679", "Coach Inc." },
                    { "NCC08", "2 Park Avenue, New York, USA", "support@katespade.com", false, "0754318296", "Kate Spade New York" },
                    { "NCC09", "901 S Central Expy, Richardson, Texas, USA", "info@fossil.com", false, "0934562871", "Fossil Group Inc." },
                    { "NCC10", "205 W 39th St, New York, USA", "contact@calvinklein.com", false, "0835472160", "Calvin Klein Inc." },
                    { "NCC11", "30 Avenue Montaigne, Paris, France", "support@dior.com", false, "0726348195", "Dior S.A." },
                    { "NCC12", "336 Rue Saint-Honoré, Paris, France", "info@balenciaga.com", false, "0867432150", "Balenciaga S.A." },
                    { "NCC13", "3 Avenue George V, Paris, France", "support@givenchy.com", false, "0654327198", "Givenchy S.A." },
                    { "NCC14", "285 Madison Ave, New York, USA", "contact@tommy.com", false, "0823765419", "Tommy Hilfiger Corporation" },
                    { "NCC15", "11 W 19th St, New York, USA", "support@toryburch.com", false, "0965143278", "Tory Burch LLC" },
                    { "NCC16", "31 Rue de Provence, Paris, France", "info@lacoste.com", false, "0786435219", "Lacoste S.A." },
                    { "NCC17", "25 Drydock Ave, Boston, USA", "contact@reebok.com", false, "0928374165", "Reebok International Ltd." },
                    { "NCC18", "1588 South Coast Dr, Costa Mesa, USA", "support@vans.com", false, "0648293751", "Vans Inc." },
                    { "NCC19", "1020 Hull St, Baltimore, USA", "info@underarmour.com", false, "0735142896", "Under Armour Inc." },
                    { "NCC20", "Adi-Dassler-Strasse 1, Herzogenaurach, Germany", "contact@adidas.com", false, "0873154629", "Adidas AG" }
                });

            migrationBuilder.InsertData(
                table: "Nhanviens",
                columns: new[] { "MaNv", "Avatar", "Cccd", "DiaChi", "Email", "GioiTinh", "HoTen", "IsDelete", "Luong", "MatKhau", "NgaySinh", "NgayVaoLam", "Sdt", "TenTaiKhoan", "TinhTrang", "VaiTro" },
                values: new object[,]
                {
                    { "NV001", "images (1).jfif", "123456789", "BMT", "thanhdat0968367@gmail.com", "Nam", "Admin", false, 10000000, "Admin123", new DateOnly(2005, 2, 23), new DateOnly(2023, 1, 1), "0123456789", "Admin", "Đang hoạt động", "Admin" },
                    { "NV002", "anh-chan-dung-dep-yodyvn1.jpg", "234567890123", "Số 2, Đường B, Quận 2", "ttb@gmail.com", "Nữ", "Trần Thị B", false, 12000, "password123", new DateOnly(1992, 6, 20), new DateOnly(2020, 2, 1), "0987654321", "ttb", "Đang hoạt động", "Nhân viên" },
                    { "NV003", "images.jfif", "345678901234", "Số 3, Đường C, Quận 3", "nvc@gmail.com", "Nam", "Nguyễn Văn C", false, 11000, "password123", new DateOnly(1988, 8, 30), new DateOnly(2020, 3, 1), "0912345678", "nvc", "Đang hoạt động", "Nhân viên" },
                    { "NV004", "photo-1-15997930085231081781532.webp", "456789012345", "Số 4, Đường D, Quận 4", "ptd@gmail.com", "Nữ", "Phạm Thị D", false, 9000, "password123", new DateOnly(1995, 12, 10), new DateOnly(2020, 4, 1), "0934567890", "ptd", "Đang hoạt động", "Nhân viên" },
                    { "NV005", "tao-dang-chup-anh-chan-dung-01.jpg", "567890123456", "Số 5, Đường E, Quận 5", "nve@gmail.com", "Nam", "Nguyễn Văn E", false, 9500, "password123", new DateOnly(1993, 2, 14), new DateOnly(2020, 5, 1), "0961234567", "nve", "Đang hoạt động", "Nhân viên" },
                    { "NV006", "photo-1-15997930085231081781532.webp", "678901234567", "Số 6, Đường F, Quận 6", "ltf@gmail.com", "Nữ", "Lê Thị F", false, 10500, "password123", new DateOnly(1994, 3, 21), new DateOnly(2020, 6, 1), "0976543210", "ltf", "Đang hoạt động", "Nhân viên" },
                    { "NV007", "images.jfif", "789012345678", "Số 7, Đường G, Quận 7", "nvg@gmail.com", "Nam", "Nguyễn Văn G", false, 11500, "password123", new DateOnly(1991, 7, 11), new DateOnly(2020, 7, 1), "0912345679", "nvg", "Đang hoạt động", "Nhân viên" },
                    { "NV008", "images (1).jfif", "890123456789", "Số 8, Đường H, Quận 8", "dth@gmail.com", "Nữ", "Đặng Thị H", false, 8500, "password123", new DateOnly(1996, 9, 5), new DateOnly(2020, 8, 1), "0923456780", "dth", "Đang hoạt động", "Nhân viên" },
                    { "NV009", "anh-chan-dung-dep-yodyvn1.jpg", "901234567890", "Số 9, Đường I, Quận 9", "nvi@gmail.com", "Nam", "Nguyễn Văn I", false, 9000, "password123", new DateOnly(1990, 4, 25), new DateOnly(2020, 9, 1), "0931234567", "nvi", "Đang hoạt động", "Nhân viên" },
                    { "NV010", "images (1).jfif", "012345678901", "Số 10, Đường K, Quận 10", "ntk@gmail.com", "Nữ", "datne", false, 8000, "password123", new DateOnly(1997, 10, 12), new DateOnly(2020, 10, 1), "0941234567", "ntka", "Đang hoạt động", "Nhân viên" },
                    { "NV011", "tao-dang-chup-anh-chan-dung-01.jpg", "0123456789", "123 Le Loi", "nguyenvana@example.com", "Nam", "Nguyen Van A", false, 5000000, "password123", new DateOnly(1990, 1, 1), new DateOnly(2023, 1, 1), "0912345678", "nv011", "Đang hoạt động", "Nhân viên" },
                    { "NV012", "photo-1-15997930085231081781532.webp", "0123456790", "456 Tran Phu", "lethib@example.com", "Nam", "Le Thi B", false, 5500000, "password123", new DateOnly(1991, 2, 2), new DateOnly(2023, 1, 2), "0912345679", "nv012", "Đang hoạt động", "Nhân viên" },
                    { "NV013", "images.jfif", "0123456791", "789 Nguyen Hue", "tranvanc@example.com", "Nam", "Tran Van C", false, 6000000, "password123", new DateOnly(1992, 3, 3), new DateOnly(2023, 1, 3), "0912345680", "nv013", "Đang hoạt động", "Nhân viên" },
                    { "NV014", "images (1).jfif", "0123456792", "101 Pham Van Dong", "nguyenthid@example.com", "Nam", "Nguyen Thi D", false, 6500000, "password123", new DateOnly(1993, 4, 4), new DateOnly(2023, 1, 4), "0912345681", "nv014", "Đang hoạt động", "Nhân viên" },
                    { "NV015", "photo-1-15997930085231081781532.webp", "0123456793", "202 Vo Van Tan", "phanvane@example.com", "Nam", "Phan Van E", false, 7000000, "password123", new DateOnly(1994, 5, 5), new DateOnly(2023, 1, 5), "0912345682", "nv015", "Đang hoạt động", "Nhân viên" },
                    { "NV016", "images.jfif", "0123456794", "303 Le Thanh Ton", "vothif@example.com", "Nam", "Vo Thi F", false, 7500000, "password123", new DateOnly(1995, 6, 6), new DateOnly(2023, 1, 6), "0912345683", "nv016", "Đang hoạt động", "Nhân viên" },
                    { "NV017", "images (1).jfif", "0123456795", "404 Nguyen Thi Minh Khai", "levang@example.com", "Nam", "Le Van G", false, 8000000, "password123", new DateOnly(1996, 7, 7), new DateOnly(2023, 1, 7), "0912345684", "nv017", "Đang hoạt động", "Nhân viên" },
                    { "NV018", "photo-1-15997930085231081781532.webp", "0123456796", "505 Hai Ba Trung", "phamvanh@example.com", "Nam", "Pham Van H", false, 8500000, "password123", new DateOnly(1997, 8, 8), new DateOnly(2023, 1, 8), "0912345685", "nv018", "Đang hoạt động", "Nhân viên" },
                    { "NV019", "anh-chan-dung-dep-yodyvn1.jpg", "0123456797", "606 Ly Tu Trong", "tranthii@example.com", "Nam", "Tran Thi I", false, 9000000, "password123", new DateOnly(1998, 9, 9), new DateOnly(2023, 1, 9), "0912345686", "nv019", "Đang hoạt động", "Nhân viên" },
                    { "NV020", "images (1).jfif", "0123456798", "707 Nguyen Trai", "phamthij@example.com", "Nam", "Pham Thi J", false, 9500000, "password123", new DateOnly(1999, 10, 10), new DateOnly(2023, 1, 10), "0912345687", "nv020", "Đang hoạt động", "Nhân viên" }
                });

            migrationBuilder.InsertData(
                table: "Phieunhaps",
                columns: new[] { "MaPhieuNhap", "ThoiGianNhap" },
                values: new object[,]
                {
                    { "PN001", new DateOnly(2023, 1, 5) },
                    { "PN002", new DateOnly(2023, 1, 10) },
                    { "PN003", new DateOnly(2023, 1, 15) },
                    { "PN004", new DateOnly(2023, 1, 20) },
                    { "PN005", new DateOnly(2023, 1, 25) },
                    { "PN006", new DateOnly(2023, 2, 1) },
                    { "PN007", new DateOnly(2023, 2, 5) },
                    { "PN008", new DateOnly(2023, 2, 10) },
                    { "PN009", new DateOnly(2023, 2, 15) },
                    { "PN010", new DateOnly(2023, 2, 20) },
                    { "PN011", new DateOnly(2023, 2, 25) },
                    { "PN012", new DateOnly(2023, 3, 1) },
                    { "PN013", new DateOnly(2023, 3, 5) },
                    { "PN014", new DateOnly(2023, 3, 10) },
                    { "PN015", new DateOnly(2023, 3, 15) }
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

            migrationBuilder.InsertData(
                table: "Hoadons",
                columns: new[] { "MaHoaDon", "DiaChiNhanHang", "Hoten", "Httt", "MaKh", "MaNv", "MoTa", "NgayTao", "Sdt", "ThoiGianDat", "ThoiGianGiao", "TinhTrang" },
                values: new object[,]
                {
                    { "HD001", "123 Đường A, Quận 1", "Nguyễn Văn A", "COD", "KH001", "NV001", "Hóa đơn đầu tiên", new DateOnly(2024, 11, 6), "0123456789", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8), "Đã thanh toán" },
                    { "HD002", "456 Đường B, Quận 2", "Trần Thị B", "COD", "KH002", "NV002", "Hóa đơn thứ hai", new DateOnly(2024, 11, 6), "0987654321", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9), "Đã thanh toán" },
                    { "HD003", "789 Đường C, Quận 3", "Nguyễn Thị C", "COD", "KH003", "NV003", "Hóa đơn thứ ba", new DateOnly(2024, 11, 6), "0912345678", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 7), "Đã thanh toán" },
                    { "HD004", "321 Đường D, Quận 4", "Lê Văn D", "COD", "KH004", "NV001", "Hóa đơn thứ tư", new DateOnly(2024, 11, 6), "0123456789", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 11), "Đã thanh toán" },
                    { "HD005", "654 Đường E, Quận 5", "Nguyễn Văn E", "COD", "KH005", "NV002", "Hóa đơn thứ năm", new DateOnly(2024, 11, 6), "0987654321", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8), "Đã thanh toán" },
                    { "HD006", "987 Đường F, Quận 6", "Trần Thị F", "COD", "KH006", "NV003", "Hóa đơn thứ sáu", new DateOnly(2024, 11, 6), "0912345678", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9), "Đã thanh toán" },
                    { "HD007", "159 Đường G, Quận 7", "Nguyễn Văn G", "COD", "KH007", "NV001", "Hóa đơn thứ bảy", new DateOnly(2024, 11, 6), "0123456789", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 10), "Đã thanh toán" },
                    { "HD008", "753 Đường H, Quận 8", "Lê Thị H", "COD", "KH008", "NV002", "Hóa đơn thứ tám", new DateOnly(2024, 11, 6), "0987654321", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8), "Đã thanh toán" },
                    { "HD009", "258 Đường I, Quận 9", "Nguyễn Văn I", "COD", "KH009", "NV003", "Hóa đơn thứ chín", new DateOnly(2024, 11, 6), "0912345678", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 11), "Đã thanh toán" },
                    { "HD010", "369 Đường J, Quận 10", "Trần Văn J", "COD", "KH010", "NV001", "Hóa đơn thứ mười", new DateOnly(2024, 11, 6), "0123456789", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9), "Đã thanh toán" },
                    { "HD011", "123 Đường K, Quận 11", "Lê Thị K", "COD", "KH011", "NV002", "Hóa đơn thứ mười một", new DateOnly(2024, 11, 6), "0987654321", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8), "Đã thanh toán" },
                    { "HD012", "456 Đường L, Quận 12", "Nguyễn Văn L", "COD", "KH012", "NV003", "Hóa đơn thứ mười hai", new DateOnly(2024, 11, 6), "0912345678", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 11), "Đã thanh toán" },
                    { "HD013", "789 Đường M, Quận 1", "Lê Văn M", "COD", "KH013", "NV001", "Hóa đơn thứ mười ba", new DateOnly(2024, 11, 6), "0123456789", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8), "Đã thanh toán" },
                    { "HD014", "321 Đường N, Quận 2", "Nguyễn Thị N", "COD", "KH013", "NV002", "Hóa đơn thứ mười bốn", new DateOnly(2024, 11, 6), "0987654321", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9), "Đã thanh toán" },
                    { "HD015", "654 Đường O, Quận 3", "Lê Văn O", "COD", "KH013", "NV003", "Hóa đơn thứ mười lăm", new DateOnly(2024, 11, 6), "0912345678", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 10), "Đã thanh toán" },
                    { "HD016", "987 Đường P, Quận 4", "Nguyễn Văn P", "COD", "KH013", "NV001", "Hóa đơn thứ mười sáu", new DateOnly(2024, 11, 6), "0123456789", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8), "Đã thanh toán" },
                    { "HD017", "159 Đường Q, Quận 5", "Trần Thị Q", "COD", "KH013", "NV002", "Hóa đơn thứ mười bảy", new DateOnly(2024, 11, 6), "0987654321", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9), "Đã thanh toán" },
                    { "HD018", "753 Đường R, Quận 6", "Lê Văn R", "COD", "KH013", "NV003", "Hóa đơn thứ mười tám", new DateOnly(2024, 11, 6), "0912345678", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 10), "Đã thanh toán" },
                    { "HD019", "258 Đường S, Quận 7", "Nguyễn Thị S", "COD", "KH013", "NV001", "Hóa đơn thứ mười chín", new DateOnly(2024, 11, 6), "0123456789", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 8), "Đã thanh toán" },
                    { "HD020", "369 Đường T, Quận 8", "Lê Văn T", "COD", "KH013", "NV002", "Hóa đơn thứ hai mươi", new DateOnly(2024, 11, 6), "0987654321", new DateOnly(2024, 11, 6), new DateOnly(2024, 11, 9), "Đã thanh toán" }
                });

            migrationBuilder.InsertData(
                table: "Sanphams",
                columns: new[] { "MaSp", "DonGiaBan", "Hinh", "IsDelete", "MaNhaCc", "MaThuongHieu", "MoTa", "NgaySanXuat", "SoLuongBan", "TenSp" },
                values: new object[,]
                {
                    { "SP001", 15000000.0, "gucci_bag.jpg", false, "NCC01", "TH001", "Túi xách cao cấp thương hiệu Gucci.", new DateOnly(2023, 1, 1), 50, "Túi Xách Gucci" },
                    { "SP002", 20000000.0, "lv_bag.jpg", false, "NCC02", "TH002", "Túi xách sang trọng của Louis Vuitton.", new DateOnly(2023, 1, 5), 30, "Túi Xách Louis Vuitton" },
                    { "SP003", 18000000.0, "chanel_bag.jpg", false, "NCC01", "TH003", "Túi xách đẹp và quý phái của Chanel.", new DateOnly(2023, 1, 10), 25, "Túi Xách Chanel" },
                    { "SP004", 17000000.0, "prada_bag.jpg", false, "NCC03", "TH004", "Túi xách thời trang của Prada.", new DateOnly(2023, 1, 15), 40, "Túi Xách Prada" },
                    { "SP005", 12000000.0, "mk_bag.jpg", false, "NCC02", "TH005", "Túi xách phong cách và tiện lợi của Michael Kors.", new DateOnly(2023, 2, 1), 60, "Túi Xách Michael Kors" },
                    { "SP006", 30000000.0, "hermes_bag.jpg", false, "NCC01", "TH006", "Túi xách xa xỉ thương hiệu Hermès.", new DateOnly(2023, 2, 5), 20, "Túi Xách Hermès" },
                    { "SP007", 9500000.0, "coach_bag.jpg", false, "NCC03", "TH007", "Túi xách tiện dụng của Coach.", new DateOnly(2023, 2, 10), 45, "Túi Xách Coach" },
                    { "SP008", 11000000.0, "kate_spade_bag.jpg", false, "NCC02", "TH008", "Túi xách nữ tính của Kate Spade.", new DateOnly(2023, 2, 15), 35, "Túi Xách Kate Spade" },
                    { "SP009", 7500000.0, "fossil_bag.jpg", false, "NCC01", "TH009", "Túi xách năng động của Fossil.", new DateOnly(2023, 3, 1), 50, "Túi Xách Fossil" },
                    { "SP010", 8000000.0, "ck_bag.jpg", false, "NCC03", "TH010", "Túi xách hiện đại của Calvin Klein.", new DateOnly(2023, 3, 5), 65, "Túi Xách Calvin Klein" },
                    { "SP011", 25000000.0, "dior_bag.jpg", false, "NCC02", "TH001", "Túi xách thời thượng của Dior.", new DateOnly(2023, 3, 10), 30, "Túi Xách Dior" },
                    { "SP012", 29000000.0, "balenciaga_bag.jpg", false, "NCC01", "TH002", "Túi xách độc đáo của Balenciaga.", new DateOnly(2023, 3, 15), 20, "Túi Xách Balenciaga" },
                    { "SP013", 22000000.0, "givenchy_bag.jpg", false, "NCC02", "TH003", "Túi xách thanh lịch của Givenchy.", new DateOnly(2023, 4, 1), 25, "Túi Xách Givenchy" },
                    { "SP014", 9000000.0, "tommy_bag.jpg", false, "NCC03", "TH004", "Túi xách phong cách của Tommy Hilfiger.", new DateOnly(2023, 4, 5), 40, "Túi Xách Tommy Hilfiger" },
                    { "SP015", 10500000.0, "tory_burch_bag.jpg", false, "NCC01", "TH005", "Túi xách trẻ trung của Tory Burch.", new DateOnly(2023, 4, 10), 50, "Túi Xách Tory Burch" },
                    { "SP016", 6500000.0, "lacoste_bag.jpg", false, "NCC02", "TH006", "Túi xách thể thao của Lacoste.", new DateOnly(2023, 4, 15), 30, "Túi Xách Lacoste" },
                    { "SP017", 7200000.0, "reebok_bag.jpg", false, "NCC03", "TH007", "Túi xách năng động của Reebok.", new DateOnly(2023, 5, 1), 20, "Túi Xách Reebok" },
                    { "SP018", 5600000.0, "vans_bag.jpg", false, "NCC01", "TH008", "Túi xách cá tính của Vans.", new DateOnly(2023, 5, 5), 35, "Túi Xách Vans" },
                    { "SP019", 8000000.0, "under_armour_bag.jpg", false, "NCC02", "TH009", "Túi xách bền bỉ của Under Armour.", new DateOnly(2023, 5, 10), 25, "Túi Xách Under Armour" },
                    { "SP020", 7800000.0, "nike_bag.jpg", false, "NCC03", "TH010", "Túi xách thời trang của Nike.", new DateOnly(2023, 5, 15), 40, "Túi Xách Nike" }
                });

            migrationBuilder.InsertData(
                table: "Chitietchatlieu",
                columns: new[] { "MaChatLieu", "MaSp" },
                values: new object[,]
                {
                    { 1, "SP001" },
                    { 1, "SP006" },
                    { 2, "SP002" },
                    { 2, "SP007" },
                    { 3, "SP003" },
                    { 3, "SP008" },
                    { 2, "SP004" },
                    { 2, "SP009" },
                    { 1, "SP005" },
                    { 3, "SP010" }
                });

            migrationBuilder.InsertData(
                table: "Chitiethoadons",
                columns: new[] { "MaHoaDon", "MaSp", "ChatLieu_ThuocTinhSuyDien", "DonGia", "KichThuoc_ThuocTinhSuyDien", "MauSac_ThuocTinhSuyDien", "SoLuongMua" },
                values: new object[,]
                {
                    { "HD001", "SP001", "Da Thật", 150000.0, "Nhỏ", "Đỏ", 2 },
                    { "HD002", "SP002", "Vải", 200000.0, "Trung Bình", "Xanh", 1 },
                    { "HD003", "SP003", "Nhựa", 250000.0, "Lớn", "Vàng", 3 },
                    { "HD004", "SP004", "Vải", 120000.0, "Nhỏ", "Trắng", 5 },
                    { "HD005", "SP005", "Cotton", 175000.0, "Trung Bình", "Đen", 2 },
                    { "HD006", "SP006", "Vải", 300000.0, "Lớn", "Đỏ", 1 },
                    { "HD007", "SP007", "Da Thật", 250000.0, "Nhỏ", "Xanh", 3 },
                    { "HD008", "SP008", "Cotton", 220000.0, "Trung Bình", "Vàng", 4 },
                    { "HD009", "SP009", "Nhựa", 275000.0, "Lớn", "Trắng", 2 },
                    { "HD010", "SP010", "Vải", 180000.0, "Nhỏ", "Đen", 1 }
                });

            migrationBuilder.InsertData(
                table: "Chitietkichthuoc",
                columns: new[] { "MaKichThuoc", "MaSp" },
                values: new object[,]
                {
                    { 1, "SP001" },
                    { 1, "SP004" },
                    { 1, "SP007" },
                    { 1, "SP010" },
                    { 2, "SP002" },
                    { 2, "SP005" },
                    { 2, "SP008" },
                    { 3, "SP003" },
                    { 3, "SP006" },
                    { 3, "SP009" }
                });

            migrationBuilder.InsertData(
                table: "Chitietmausac",
                columns: new[] { "MaMau", "MaSp" },
                values: new object[,]
                {
                    { 1, "SP001" },
                    { 1, "SP006" },
                    { 2, "SP002" },
                    { 2, "SP007" },
                    { 3, "SP003" },
                    { 3, "SP008" },
                    { 4, "SP004" },
                    { 4, "SP009" },
                    { 5, "SP005" },
                    { 5, "SP010" }
                });

            migrationBuilder.InsertData(
                table: "Chitietphieunhaps",
                columns: new[] { "MaCtpn", "DonGiaNhap", "MaPhieuNhap", "MaSp", "SoluongNhap" },
                values: new object[,]
                {
                    { "CT001", 120000.0, "PN001", "SP001", 50 },
                    { "CT002", 95000.0, "PN002", "SP002", 30 },
                    { "CT003", 75000.0, "PN003", "SP003", 20 },
                    { "CT004", 105000.0, "PN004", "SP004", 40 },
                    { "CT005", 130000.0, "PN005", "SP005", 60 },
                    { "CT006", 110000.0, "PN006", "SP006", 70 },
                    { "CT007", 90000.0, "PN007", "SP007", 25 },
                    { "CT008", 115000.0, "PN008", "SP008", 35 },
                    { "CT009", 125000.0, "PN009", "SP009", 45 },
                    { "CT010", 135000.0, "PN010", "SP010", 55 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietchatlieu_MaSp",
                table: "Chitietchatlieu",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_Chitiethoadons_MaSp",
                table: "Chitiethoadons",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietkichthuoc_MaSp",
                table: "Chitietkichthuoc",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietmausac_MaSp",
                table: "Chitietmausac",
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
                name: "Chitietchatlieu");

            migrationBuilder.DropTable(
                name: "Chitiethoadons");

            migrationBuilder.DropTable(
                name: "Chitietkichthuoc");

            migrationBuilder.DropTable(
                name: "Chitietmausac");

            migrationBuilder.DropTable(
                name: "Chitietphieunhaps");

            migrationBuilder.DropTable(
                name: "Hinhanhs");

            migrationBuilder.DropTable(
                name: "Chatlieus");

            migrationBuilder.DropTable(
                name: "Hoadons");

            migrationBuilder.DropTable(
                name: "Kichthuocs");

            migrationBuilder.DropTable(
                name: "Mausacs");

            migrationBuilder.DropTable(
                name: "Phieunhaps");

            migrationBuilder.DropTable(
                name: "Sanphams");

            migrationBuilder.DropTable(
                name: "Khachhangs");

            migrationBuilder.DropTable(
                name: "Nhanviens");

            migrationBuilder.DropTable(
                name: "Nhacungcaps");

            migrationBuilder.DropTable(
                name: "Thuonghieus");
        }
    }
}

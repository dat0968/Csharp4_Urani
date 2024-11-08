using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;

namespace ASMCshrp4_12345.Models;

public partial class Csharp4Context : DbContext
{
    public Csharp4Context()
    {
    }

    public Csharp4Context(DbContextOptions<Csharp4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Chatlieu> Chatlieus { get; set; }

    public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }

    public virtual DbSet<Chitietphieunhap> Chitietphieunhaps { get; set; }

    public virtual DbSet<Hinhanh> Hinhanhs { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Kichthuoc> Kichthuocs { get; set; }

    public virtual DbSet<Mausac> Mausacs { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phieunhap> Phieunhaps { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }

    public virtual DbSet<Chitietchatlieu> Chitietchatlieus { get; set; }
    public virtual DbSet<Chitietkichthuoc> Chitietkichthuocs { get; set; }
    public virtual DbSet<Chitietmausac> Chitietmausacs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Thêm 2 khóa chính cho bảng chi tiết hóa đơn
        modelBuilder.Entity<Chitiethoadon>()
           .HasKey(c => new { c.MaHoaDon, c.MaSp });
        //Thêm 2 khóa chính cho bảng chi tiết màu sắc
        modelBuilder.Entity<Chitietmausac>()
          .HasKey(c => new { c.MaMau, c.MaSp });
        //Thêm 2 khóa chính cho bảng chi tiết kích thước
        modelBuilder.Entity<Chitietkichthuoc>()
          .HasKey(c => new { c.MaKichThuoc, c.MaSp });
        //Thêm 2 khóa chính cho bảng chi tiết chất liệu
        modelBuilder.Entity<Chitietchatlieu>()
         .HasKey(c => new { c.MaChatLieu, c.MaSp });

        // Thêm dữ liệu khởi tạo
        modelBuilder.Entity<Thuonghieu>().HasData(
            new Thuonghieu { MaThuongHieu = "TH001", TenThuongHieu = "Gucci", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH002", TenThuongHieu = "Louis Vuitton", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH003", TenThuongHieu = "Chanel", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH004", TenThuongHieu = "Prada", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH005", TenThuongHieu = "Michael Kors", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH006", TenThuongHieu = "Hermès", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH007", TenThuongHieu = "Coach", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH008", TenThuongHieu = "Kate Spade", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH009", TenThuongHieu = "Fossil", IsDelete = false },
            new Thuonghieu { MaThuongHieu = "TH010", TenThuongHieu = "Calvin Klein", IsDelete = false }
        );
        modelBuilder.Entity<Mausac>().HasData(
            new Mausac { MaMau = 1, TenMau = "Đỏ", IsDelete = false },
            new Mausac { MaMau = 2, TenMau = "Xanh", IsDelete = false },
            new Mausac { MaMau = 3, TenMau = "Vàng", IsDelete = false },
            new Mausac { MaMau = 4, TenMau = "Trắng", IsDelete = false },
            new Mausac { MaMau = 5, TenMau = "Đen", IsDelete = false }
        );
        modelBuilder.Entity<Chatlieu>().HasData(
            new Chatlieu { MaChatLieu = 1, TenChatLieu = "Da Thật", IsDelete = false },
            new Chatlieu { MaChatLieu = 2, TenChatLieu = "Vải", IsDelete = false },
            new Chatlieu { MaChatLieu = 3, TenChatLieu = "Nhựa", IsDelete = false }
        );
        modelBuilder.Entity<Kichthuoc>().HasData(
            new Kichthuoc { MaKichThuoc = 1, TenKichThuoc = "Nhỏ", KichThuoc1 = "20 x 15 x 10", IsDelete = false },
            new Kichthuoc { MaKichThuoc = 2, TenKichThuoc = "Trung Bình", KichThuoc1 = "30 x 25 x 15", IsDelete = false },
            new Kichthuoc { MaKichThuoc = 3, TenKichThuoc = "Lớn", KichThuoc1 = "40 x 30 x 20 trở lên", IsDelete = false }
        );
        modelBuilder.Entity<Nhacungcap>().HasData(
            new Nhacungcap { MaNhaCc = "NCC01", TenNhaCc = "Gucci Ltd.", DiaChi = "Via Tornabuoni 73r, Florence, Italy", Email = "contact@gucci.com", Sdt = "0123456789", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC02", TenNhaCc = "Louis Vuitton S.A.", DiaChi = "22 Avenue Montaigne, Paris, France", Email = "support@louisvuitton.com", Sdt = "0987654321", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC03", TenNhaCc = "Chanel Inc.", DiaChi = "135 Avenue Charles de Gaulle, Neuilly-sur-Seine, France", Email = "info@chanel.com", Sdt = "0234567890", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC04", TenNhaCc = "Prada S.p.A.", DiaChi = "Via Antonio Fogazzaro 28, Milan, Italy", Email = "contact@prada.com", Sdt = "0789123456", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC05", TenNhaCc = "Michael Kors Holdings Ltd.", DiaChi = "11 W 42nd St, New York, USA", Email = "support@michaelkors.com", Sdt = "0543216789", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC06", TenNhaCc = "Hermès International S.A.", DiaChi = "24 Rue du Faubourg Saint-Honoré, Paris, France", Email = "info@hermes.com", Sdt = "0645372910", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC07", TenNhaCc = "Coach Inc.", DiaChi = "10 Hudson Yards, New York, USA", Email = "contact@coach.com", Sdt = "0823451679", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC08", TenNhaCc = "Kate Spade New York", DiaChi = "2 Park Avenue, New York, USA", Email = "support@katespade.com", Sdt = "0754318296", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC09", TenNhaCc = "Fossil Group Inc.", DiaChi = "901 S Central Expy, Richardson, Texas, USA", Email = "info@fossil.com", Sdt = "0934562871", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC10", TenNhaCc = "Calvin Klein Inc.", DiaChi = "205 W 39th St, New York, USA", Email = "contact@calvinklein.com", Sdt = "0835472160", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC11", TenNhaCc = "Dior S.A.", DiaChi = "30 Avenue Montaigne, Paris, France", Email = "support@dior.com", Sdt = "0726348195", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC12", TenNhaCc = "Balenciaga S.A.", DiaChi = "336 Rue Saint-Honoré, Paris, France", Email = "info@balenciaga.com", Sdt = "0867432150", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC13", TenNhaCc = "Givenchy S.A.", DiaChi = "3 Avenue George V, Paris, France", Email = "support@givenchy.com", Sdt = "0654327198", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC14", TenNhaCc = "Tommy Hilfiger Corporation", DiaChi = "285 Madison Ave, New York, USA", Email = "contact@tommy.com", Sdt = "0823765419", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC15", TenNhaCc = "Tory Burch LLC", DiaChi = "11 W 19th St, New York, USA", Email = "support@toryburch.com", Sdt = "0965143278", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC16", TenNhaCc = "Lacoste S.A.", DiaChi = "31 Rue de Provence, Paris, France", Email = "info@lacoste.com", Sdt = "0786435219", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC17", TenNhaCc = "Reebok International Ltd.", DiaChi = "25 Drydock Ave, Boston, USA", Email = "contact@reebok.com", Sdt = "0928374165", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC18", TenNhaCc = "Vans Inc.", DiaChi = "1588 South Coast Dr, Costa Mesa, USA", Email = "support@vans.com", Sdt = "0648293751", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC19", TenNhaCc = "Under Armour Inc.", DiaChi = "1020 Hull St, Baltimore, USA", Email = "info@underarmour.com", Sdt = "0735142896", IsDelete = false },
            new Nhacungcap { MaNhaCc = "NCC20", TenNhaCc = "Adidas AG", DiaChi = "Adi-Dassler-Strasse 1, Herzogenaurach, Germany", Email = "contact@adidas.com", Sdt = "0873154629", IsDelete = false }
        );

        modelBuilder.Entity<Sanpham>().HasData(
            new Sanpham { MaSp = "SP001", TenSp = "Túi Xách Gucci", SoLuongBan = 50, DonGiaBan = 15000000, MaThuongHieu = "TH001", Hinh = "gucci_bag.jpg", MoTa = "Túi xách cao cấp thương hiệu Gucci.", NgaySanXuat = new DateOnly(2023, 1, 1), MaNhaCc = "NCC01", IsDelete = false },
            new Sanpham { MaSp = "SP002", TenSp = "Túi Xách Louis Vuitton", SoLuongBan = 30, DonGiaBan = 20000000, MaThuongHieu = "TH002", Hinh = "lv_bag.jpg", MoTa = "Túi xách sang trọng của Louis Vuitton.", NgaySanXuat = new DateOnly(2023, 1, 5), MaNhaCc = "NCC02", IsDelete = false },
            new Sanpham { MaSp = "SP003", TenSp = "Túi Xách Chanel", SoLuongBan = 25, DonGiaBan = 18000000, MaThuongHieu = "TH003", Hinh = "chanel_bag.jpg", MoTa = "Túi xách đẹp và quý phái của Chanel.", NgaySanXuat = new DateOnly(2023, 1, 10), MaNhaCc = "NCC01", IsDelete = false },
            new Sanpham { MaSp = "SP004", TenSp = "Túi Xách Prada", SoLuongBan = 40, DonGiaBan = 17000000, MaThuongHieu = "TH004", Hinh = "prada_bag.jpg", MoTa = "Túi xách thời trang của Prada.", NgaySanXuat = new DateOnly(2023, 1, 15), MaNhaCc = "NCC03", IsDelete = false },
            new Sanpham { MaSp = "SP005", TenSp = "Túi Xách Michael Kors", SoLuongBan = 60, DonGiaBan = 12000000, MaThuongHieu = "TH005", Hinh = "mk_bag.jpg", MoTa = "Túi xách phong cách và tiện lợi của Michael Kors.", NgaySanXuat = new DateOnly(2023, 2, 1), MaNhaCc = "NCC02", IsDelete = false },
            new Sanpham { MaSp = "SP006", TenSp = "Túi Xách Hermès", SoLuongBan = 20, DonGiaBan = 30000000, MaThuongHieu = "TH006", Hinh = "hermes_bag.jpg", MoTa = "Túi xách xa xỉ thương hiệu Hermès.", NgaySanXuat = new DateOnly(2023, 2, 5), MaNhaCc = "NCC01", IsDelete = false },
            new Sanpham { MaSp = "SP007", TenSp = "Túi Xách Coach", SoLuongBan = 45, DonGiaBan = 9500000, MaThuongHieu = "TH007", Hinh = "coach_bag.jpg", MoTa = "Túi xách tiện dụng của Coach.", NgaySanXuat = new DateOnly(2023, 2, 10), MaNhaCc = "NCC03", IsDelete = false },
            new Sanpham { MaSp = "SP008", TenSp = "Túi Xách Kate Spade", SoLuongBan = 35, DonGiaBan = 11000000, MaThuongHieu = "TH008", Hinh = "kate_spade_bag.jpg", MoTa = "Túi xách nữ tính của Kate Spade.", NgaySanXuat = new DateOnly(2023, 2, 15), MaNhaCc = "NCC02", IsDelete = false },
            new Sanpham { MaSp = "SP009", TenSp = "Túi Xách Fossil", SoLuongBan = 50, DonGiaBan = 7500000, MaThuongHieu = "TH009", Hinh = "fossil_bag.jpg", MoTa = "Túi xách năng động của Fossil.", NgaySanXuat = new DateOnly(2023, 3, 1), MaNhaCc = "NCC01", IsDelete = false },
            new Sanpham { MaSp = "SP010", TenSp = "Túi Xách Calvin Klein", SoLuongBan = 65, DonGiaBan = 8000000, MaThuongHieu = "TH010", Hinh = "ck_bag.jpg", MoTa = "Túi xách hiện đại của Calvin Klein.", NgaySanXuat = new DateOnly(2023, 3, 5), MaNhaCc = "NCC03", IsDelete = false },
            new Sanpham { MaSp = "SP011", TenSp = "Túi Xách Dior", SoLuongBan = 30, DonGiaBan = 25000000, MaThuongHieu = "TH001", Hinh = "dior_bag.jpg", MoTa = "Túi xách thời thượng của Dior.", NgaySanXuat = new DateOnly(2023, 3, 10), MaNhaCc = "NCC02", IsDelete = false },
            new Sanpham { MaSp = "SP012", TenSp = "Túi Xách Balenciaga", SoLuongBan = 20, DonGiaBan = 29000000, MaThuongHieu = "TH002", Hinh = "balenciaga_bag.jpg", MoTa = "Túi xách độc đáo của Balenciaga.", NgaySanXuat = new DateOnly(2023, 3, 15), MaNhaCc = "NCC01", IsDelete = false },
            new Sanpham { MaSp = "SP013", TenSp = "Túi Xách Givenchy", SoLuongBan = 25, DonGiaBan = 22000000, MaThuongHieu = "TH003", Hinh = "givenchy_bag.jpg", MoTa = "Túi xách thanh lịch của Givenchy.", NgaySanXuat = new DateOnly(2023, 4, 1), MaNhaCc = "NCC02", IsDelete = false },
            new Sanpham { MaSp = "SP014", TenSp = "Túi Xách Tommy Hilfiger", SoLuongBan = 40, DonGiaBan = 9000000, MaThuongHieu = "TH004", Hinh = "tommy_bag.jpg", MoTa = "Túi xách phong cách của Tommy Hilfiger.", NgaySanXuat = new DateOnly(2023, 4, 5), MaNhaCc = "NCC03", IsDelete = false },
            new Sanpham { MaSp = "SP015", TenSp = "Túi Xách Tory Burch", SoLuongBan = 50, DonGiaBan = 10500000, MaThuongHieu = "TH005", Hinh = "tory_burch_bag.jpg", MoTa = "Túi xách trẻ trung của Tory Burch.", NgaySanXuat = new DateOnly(2023, 4, 10), MaNhaCc = "NCC01", IsDelete = false },
            new Sanpham { MaSp = "SP016", TenSp = "Túi Xách Lacoste", SoLuongBan = 30, DonGiaBan = 6500000, MaThuongHieu = "TH006", Hinh = "lacoste_bag.jpg", MoTa = "Túi xách thể thao của Lacoste.", NgaySanXuat = new DateOnly(2023, 4, 15), MaNhaCc = "NCC02", IsDelete = false },
            new Sanpham { MaSp = "SP017", TenSp = "Túi Xách Reebok", SoLuongBan = 20, DonGiaBan = 7200000, MaThuongHieu = "TH007", Hinh = "reebok_bag.jpg", MoTa = "Túi xách năng động của Reebok.", NgaySanXuat = new DateOnly(2023, 5, 1), MaNhaCc = "NCC03", IsDelete = false },
            new Sanpham { MaSp = "SP018", TenSp = "Túi Xách Vans", SoLuongBan = 35, DonGiaBan = 5600000, MaThuongHieu = "TH008", Hinh = "vans_bag.jpg", MoTa = "Túi xách cá tính của Vans.", NgaySanXuat = new DateOnly(2023, 5, 5), MaNhaCc = "NCC01", IsDelete = false },
            new Sanpham { MaSp = "SP019", TenSp = "Túi Xách Under Armour", SoLuongBan = 25, DonGiaBan = 8000000, MaThuongHieu = "TH009", Hinh = "under_armour_bag.jpg", MoTa = "Túi xách bền bỉ của Under Armour.", NgaySanXuat = new DateOnly(2023, 5, 10), MaNhaCc = "NCC02", IsDelete = false },
            new Sanpham { MaSp = "SP020", TenSp = "Túi Xách Nike", SoLuongBan = 40, DonGiaBan = 7800000, MaThuongHieu = "TH010", Hinh = "nike_bag.jpg", MoTa = "Túi xách thời trang của Nike.", NgaySanXuat = new DateOnly(2023, 5, 15), MaNhaCc = "NCC03", IsDelete = false }
        );

        modelBuilder.Entity<Phieunhap>().HasData(
            new Phieunhap { MaPhieuNhap = "PN001", ThoiGianNhap = new DateOnly(2023, 1, 5) },
            new Phieunhap { MaPhieuNhap = "PN002", ThoiGianNhap = new DateOnly(2023, 1, 10) },
            new Phieunhap { MaPhieuNhap = "PN003", ThoiGianNhap = new DateOnly(2023, 1, 15) },
            new Phieunhap { MaPhieuNhap = "PN004", ThoiGianNhap = new DateOnly(2023, 1, 20) },
            new Phieunhap { MaPhieuNhap = "PN005", ThoiGianNhap = new DateOnly(2023, 1, 25) },
            new Phieunhap { MaPhieuNhap = "PN006", ThoiGianNhap = new DateOnly(2023, 2, 1) },
            new Phieunhap { MaPhieuNhap = "PN007", ThoiGianNhap = new DateOnly(2023, 2, 5) },
            new Phieunhap { MaPhieuNhap = "PN008", ThoiGianNhap = new DateOnly(2023, 2, 10) },
            new Phieunhap { MaPhieuNhap = "PN009", ThoiGianNhap = new DateOnly(2023, 2, 15) },
            new Phieunhap { MaPhieuNhap = "PN010", ThoiGianNhap = new DateOnly(2023, 2, 20) },
            new Phieunhap { MaPhieuNhap = "PN011", ThoiGianNhap = new DateOnly(2023, 2, 25) },
            new Phieunhap { MaPhieuNhap = "PN012", ThoiGianNhap = new DateOnly(2023, 3, 1) },
            new Phieunhap { MaPhieuNhap = "PN013", ThoiGianNhap = new DateOnly(2023, 3, 5) },
            new Phieunhap { MaPhieuNhap = "PN014", ThoiGianNhap = new DateOnly(2023, 3, 10) },
            new Phieunhap { MaPhieuNhap = "PN015", ThoiGianNhap = new DateOnly(2023, 3, 15) }
        );

        modelBuilder.Entity<Nhanvien>().HasData(
            new Nhanvien { MaNv = "NV001", HoTen = "Admin", GioiTinh = "Nam", NgaySinh = new DateOnly(2005, 2, 23), DiaChi = "BMT", Cccd = "123456789", Sdt = "0123456789", Email = "thanhdat0968367@gmail.com", NgayVaoLam = new DateOnly(2023, 1, 1), Luong = 10000000, VaiTro = "Admin", TenTaiKhoan = "Admin", MatKhau = "Admin123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images (1).jfif" },
            new Nhanvien { MaNv = "NV002", HoTen = "Trần Thị B", GioiTinh = "Nữ", NgaySinh = new DateOnly(1992, 6, 20), DiaChi = "Số 2, Đường B, Quận 2", Cccd = "234567890123", Sdt = "0987654321", Email = "ttb@gmail.com", NgayVaoLam = new DateOnly(2020, 2, 1), Luong = 12000, VaiTro = "Nhân viên", TenTaiKhoan = "ttb", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "anh-chan-dung-dep-yodyvn1.jpg" },
            new Nhanvien { MaNv = "NV003", HoTen = "Nguyễn Văn C", GioiTinh = "Nam", NgaySinh = new DateOnly(1988, 8, 30), DiaChi = "Số 3, Đường C, Quận 3", Cccd = "345678901234", Sdt = "0912345678", Email = "nvc@gmail.com", NgayVaoLam = new DateOnly(2020, 3, 1), Luong = 11000, VaiTro = "Nhân viên", TenTaiKhoan = "nvc", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images.jfif" },
            new Nhanvien { MaNv = "NV004", HoTen = "Phạm Thị D", GioiTinh = "Nữ", NgaySinh = new DateOnly(1995, 12, 10), DiaChi = "Số 4, Đường D, Quận 4", Cccd = "456789012345", Sdt = "0934567890", Email = "ptd@gmail.com", NgayVaoLam = new DateOnly(2020, 4, 1), Luong = 9000, VaiTro = "Nhân viên", TenTaiKhoan = "ptd", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "photo-1-15997930085231081781532.webp" },
            new Nhanvien { MaNv = "NV005", HoTen = "Nguyễn Văn E", GioiTinh = "Nam", NgaySinh = new DateOnly(1993, 2, 14), DiaChi = "Số 5, Đường E, Quận 5", Cccd = "567890123456", Sdt = "0961234567", Email = "nve@gmail.com", NgayVaoLam = new DateOnly(2020, 5, 1), Luong = 9500, VaiTro = "Nhân viên", TenTaiKhoan = "nve", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "tao-dang-chup-anh-chan-dung-01.jpg" },
            new Nhanvien { MaNv = "NV006", HoTen = "Lê Thị F", GioiTinh = "Nữ", NgaySinh = new DateOnly(1994, 3, 21), DiaChi = "Số 6, Đường F, Quận 6", Cccd = "678901234567", Sdt = "0976543210", Email = "ltf@gmail.com", NgayVaoLam = new DateOnly(2020, 6, 1), Luong = 10500, VaiTro = "Nhân viên", TenTaiKhoan = "ltf", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "photo-1-15997930085231081781532.webp" },
            new Nhanvien { MaNv = "NV007", HoTen = "Nguyễn Văn G", GioiTinh = "Nam", NgaySinh = new DateOnly(1991, 7, 11), DiaChi = "Số 7, Đường G, Quận 7", Cccd = "789012345678", Sdt = "0912345679", Email = "nvg@gmail.com", NgayVaoLam = new DateOnly(2020, 7, 1), Luong = 11500, VaiTro = "Nhân viên", TenTaiKhoan = "nvg", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images.jfif" },
            new Nhanvien { MaNv = "NV008", HoTen = "Đặng Thị H", GioiTinh = "Nữ", NgaySinh = new DateOnly(1996, 9, 5), DiaChi = "Số 8, Đường H, Quận 8", Cccd = "890123456789", Sdt = "0923456780", Email = "dth@gmail.com", NgayVaoLam = new DateOnly(2020, 8, 1), Luong = 8500, VaiTro = "Nhân viên", TenTaiKhoan = "dth", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images (1).jfif" },
            new Nhanvien { MaNv = "NV009", HoTen = "Nguyễn Văn I", GioiTinh = "Nam", NgaySinh = new DateOnly(1990, 4, 25), DiaChi = "Số 9, Đường I, Quận 9", Cccd = "901234567890", Sdt = "0931234567", Email = "nvi@gmail.com", NgayVaoLam = new DateOnly(2020, 9, 1), Luong = 9000, VaiTro = "Nhân viên", TenTaiKhoan = "nvi", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "anh-chan-dung-dep-yodyvn1.jpg" },
            new Nhanvien { MaNv = "NV010", HoTen = "datne", GioiTinh = "Nữ", NgaySinh = new DateOnly(1997, 10, 12), DiaChi = "Số 10, Đường K, Quận 10", Cccd = "012345678901", Sdt = "0941234567", Email = "ntk@gmail.com", NgayVaoLam = new DateOnly(2020, 10, 1), Luong = 8000, VaiTro = "Nhân viên", TenTaiKhoan = "ntka", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images (1).jfif" },
            new Nhanvien { MaNv = "NV011", HoTen = "Nguyen Van A", GioiTinh = "Nam", NgaySinh = new DateOnly(1990, 1, 1), DiaChi = "123 Le Loi", Cccd = "0123456789", Sdt = "0912345678", Email = "nguyenvana@example.com", NgayVaoLam = new DateOnly(2023, 1, 1), Luong = 5000000, VaiTro = "Nhân viên", TenTaiKhoan = "nv011", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "tao-dang-chup-anh-chan-dung-01.jpg" },
            new Nhanvien { MaNv = "NV012", HoTen = "Le Thi B", GioiTinh = "Nam", NgaySinh = new DateOnly(1991, 2, 2), DiaChi = "456 Tran Phu", Cccd = "0123456790", Sdt = "0912345679", Email = "lethib@example.com", NgayVaoLam = new DateOnly(2023, 1, 2), Luong = 5500000, VaiTro = "Nhân viên", TenTaiKhoan = "nv012", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "photo-1-15997930085231081781532.webp" },
            new Nhanvien { MaNv = "NV013", HoTen = "Tran Van C", GioiTinh = "Nam", NgaySinh = new DateOnly(1992, 3, 3), DiaChi = "789 Nguyen Hue", Cccd = "0123456791", Sdt = "0912345680", Email = "tranvanc@example.com", NgayVaoLam = new DateOnly(2023, 1, 3), Luong = 6000000, VaiTro = "Nhân viên", TenTaiKhoan = "nv013", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images.jfif" },
            new Nhanvien { MaNv = "NV014", HoTen = "Nguyen Thi D", GioiTinh = "Nam", NgaySinh = new DateOnly(1993, 4, 4), DiaChi = "101 Pham Van Dong", Cccd = "0123456792", Sdt = "0912345681", Email = "nguyenthid@example.com", NgayVaoLam = new DateOnly(2023, 1, 4), Luong = 6500000, VaiTro = "Nhân viên", TenTaiKhoan = "nv014", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images (1).jfif" },
            new Nhanvien { MaNv = "NV015", HoTen = "Phan Van E", GioiTinh = "Nam", NgaySinh = new DateOnly(1994, 5, 5), DiaChi = "202 Vo Van Tan", Cccd = "0123456793", Sdt = "0912345682", Email = "phanvane@example.com", NgayVaoLam = new DateOnly(2023, 1, 5), Luong = 7000000, VaiTro = "Nhân viên", TenTaiKhoan = "nv015", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "photo-1-15997930085231081781532.webp" },
            new Nhanvien { MaNv = "NV016", HoTen = "Vo Thi F", GioiTinh = "Nam", NgaySinh = new DateOnly(1995, 6, 6), DiaChi = "303 Le Thanh Ton", Cccd = "0123456794", Sdt = "0912345683", Email = "vothif@example.com", NgayVaoLam = new DateOnly(2023, 1, 6), Luong = 7500000, VaiTro = "Nhân viên", TenTaiKhoan = "nv016", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images.jfif" },
            new Nhanvien { MaNv = "NV017", HoTen = "Le Van G", GioiTinh = "Nam", NgaySinh = new DateOnly(1996, 7, 7), DiaChi = "404 Nguyen Thi Minh Khai", Cccd = "0123456795", Sdt = "0912345684", Email = "levang@example.com", NgayVaoLam = new DateOnly(2023, 1, 7), Luong = 8000000, VaiTro = "Nhân viên", TenTaiKhoan = "nv017", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images (1).jfif" },
            new Nhanvien { MaNv = "NV018", HoTen = "Pham Van H", GioiTinh = "Nam", NgaySinh = new DateOnly(1997, 8, 8), DiaChi = "505 Hai Ba Trung", Cccd = "0123456796", Sdt = "0912345685", Email = "phamvanh@example.com", NgayVaoLam = new DateOnly(2023, 1, 8), Luong = 8500000, VaiTro = "Nhân viên", TenTaiKhoan = "nv018", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "photo-1-15997930085231081781532.webp" },
            new Nhanvien { MaNv = "NV019", HoTen = "Tran Thi I", GioiTinh = "Nam", NgaySinh = new DateOnly(1998, 9, 9), DiaChi = "606 Ly Tu Trong", Cccd = "0123456797", Sdt = "0912345686", Email = "tranthii@example.com", NgayVaoLam = new DateOnly(2023, 1, 9), Luong = 9000000, VaiTro = "Nhân viên", TenTaiKhoan = "nv019", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "anh-chan-dung-dep-yodyvn1.jpg" },
            new Nhanvien { MaNv = "NV020", HoTen = "Pham Thi J", GioiTinh = "Nam", NgaySinh = new DateOnly(1999, 10, 10), DiaChi = "707 Nguyen Trai", Cccd = "0123456798", Sdt = "0912345687", Email = "phamthij@example.com", NgayVaoLam = new DateOnly(2023, 1, 10), Luong = 9500000, VaiTro = "Nhân viên", TenTaiKhoan = "nv020", MatKhau = "password123", TinhTrang = "Đang hoạt động", IsDelete = false, Avatar = "images (1).jfif" }
        );

        modelBuilder.Entity<Khachhang>().HasData(
            new Khachhang { MaKh = "KH001", HoTen = "Nguyễn Văn A", Avatar = "images (1).jfif", GioiTinh = "Nam", NgaySinh = new DateOnly(1990, 1, 15), DiaChi = "123 Đường ABC", Cccd = "123456789", Sdt = "0901234567", Email = "email1@example.com", TenTaiKhoan = "user1", MatKhau = "password1", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH002", HoTen = "Trần Thị B", Avatar = "anh-chan-dung-dep-yodyvn1.jpg", GioiTinh = "Nữ", NgaySinh = new DateOnly(1995, 5, 20), DiaChi = "456 Đường DEF", Cccd = "987654321", Sdt = "0912345678", Email = "email2@example.com", TenTaiKhoan = "user2", MatKhau = "password2", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH003", HoTen = "Lê Văn C", Avatar = "photo-1-15997930085231081781532.webp", GioiTinh = "Nam", NgaySinh = new DateOnly(1988, 3, 25), DiaChi = "789 Đường GHI", Cccd = "321654987", Sdt = "0923456789", Email = "email3@example.com", TenTaiKhoan = "user3", MatKhau = "password3", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH004", HoTen = "Phạm Thị D", Avatar = "tao-dang-chup-anh-chan-dung-01.jpg", GioiTinh = "Nữ", NgaySinh = new DateOnly(1992, 7, 30), DiaChi = "321 Đường JKL", Cccd = "654987321", Sdt = "0934567890", Email = "email4@example.com", TenTaiKhoan = "user4", MatKhau = "password4", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH005", HoTen = "Ngô Văn E", Avatar = "anh-chan-dung-dep-yodyvn1.jpg", GioiTinh = "Nam", NgaySinh = new DateOnly(1985, 2, 14), DiaChi = "654 Đường MNO", Cccd = "123123123", Sdt = "0945678901", Email = "email5@example.com", TenTaiKhoan = "user5", MatKhau = "password5", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH006", HoTen = "Đỗ Thị F", Avatar = "images (1).jfif", GioiTinh = "Nữ", NgaySinh = new DateOnly(1993, 8, 10), DiaChi = "987 Đường PQR", Cccd = "321321321", Sdt = "0956789012", Email = "email6@example.com", TenTaiKhoan = "user6", MatKhau = "password6", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH007", HoTen = "Bùi Văn G", Avatar = "images.jfif", GioiTinh = "Nam", NgaySinh = new DateOnly(1991, 12, 5), DiaChi = "147 Đường STU", Cccd = "456456456", Sdt = "0967890123", Email = "email7@example.com", TenTaiKhoan = "user7", MatKhau = "password7", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH008", HoTen = "Vũ Thị H", Avatar = "photo-1-15997930085231081781532.webp", GioiTinh = "Nữ", NgaySinh = new DateOnly(1994, 11, 18), DiaChi = "258 Đường VWX", Cccd = "789789789", Sdt = "0978901234", Email = "email8@example.com", TenTaiKhoan = "user8", MatKhau = "password8", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH009", HoTen = "Hoàng Văn I", Avatar = "tao-dang-chup-anh-chan-dung-01.jpg", GioiTinh = "Nam", NgaySinh = new DateOnly(1989, 4, 22), DiaChi = "369 Đường YZ", Cccd = "159159159", Sdt = "0989012345", Email = "email9@example.com", TenTaiKhoan = "user9", MatKhau = "password9", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH010", HoTen = "Nguyễn Thị J", Avatar = "anh-chan-dung-dep-yodyvn1.jpg", GioiTinh = "Nữ", NgaySinh = new DateOnly(1996, 9, 29), DiaChi = "753 Đường ABCD", Cccd = "753753753", Sdt = "0912345678", Email = "email10@example.com", TenTaiKhoan = "user10", MatKhau = "password10", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH011", HoTen = "Trần Văn K", Avatar = "tao-dang-chup-anh-chan-dung-01.jpg", GioiTinh = "Nam", NgaySinh = new DateOnly(1987, 6, 12), DiaChi = "147 Đường EFGH", Cccd = "258258258", Sdt = "0923456789", Email = "email11@example.com", TenTaiKhoan = "user11", MatKhau = "password11", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH012", HoTen = "Lê Thị L", Avatar = "photo-1-15997930085231081781532.webp", GioiTinh = "Nữ", NgaySinh = new DateOnly(1990, 3, 15), DiaChi = "369 Đường IJKL", Cccd = "159159159", Sdt = "0934567890", Email = "email12@example.com", TenTaiKhoan = "user12", MatKhau = "password12", TinhTrang = "Đang hoạt động", IsDelete = false },
            new Khachhang { MaKh = "KH013", HoTen = "Ngô Văn M", Avatar = "anh-chan-dung-dep-yodyvn1.jpg", GioiTinh = "Nam", NgaySinh = new DateOnly(1985, 1, 21), DiaChi = "258 Đường MNOP", Cccd = "753753753", Sdt = "0945678901", Email = "email13@example.com", TenTaiKhoan = "user13", MatKhau = "password13", TinhTrang = "Đang hoạt động", IsDelete = false }
        );
        modelBuilder.Entity<Hoadon>().HasData(
            new Hoadon
            {
                MaHoaDon = "HD001",
                DiaChiNhanHang = "123 Đường A, Quận 1",
                NgayTao = DateOnly.FromDateTime(DateTime.Now),
                Httt = "COD",
                TinhTrang = "Đã thanh toán",
                MaNv = "NV001",
                MaKh = "KH001",
                MoTa = "Hóa đơn đầu tiên",
                Hoten = "Nguyễn Văn A",
                Sdt = "0123456789",
                ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
                ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),

            },
        new Hoadon
        {
            MaHoaDon = "HD002",
            DiaChiNhanHang = "456 Đường B, Quận 2",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV002",
            MaKh = "KH002",
            MoTa = "Hóa đơn thứ hai",
            Hoten = "Trần Thị B",
            Sdt = "0987654321",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
       
        },
        new Hoadon
        {
            MaHoaDon = "HD003",
            DiaChiNhanHang = "789 Đường C, Quận 3",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV003",
            MaKh = "KH003",
            MoTa = "Hóa đơn thứ ba",
            Hoten = "Nguyễn Thị C",
            Sdt = "0912345678",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            
        },
        new Hoadon
        {
            MaHoaDon = "HD004",
            DiaChiNhanHang = "321 Đường D, Quận 4",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV001",
            MaKh = "KH004",
            MoTa = "Hóa đơn thứ tư",
            Hoten = "Lê Văn D",
            Sdt = "0123456789",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
          
        },
        new Hoadon
        {
            MaHoaDon = "HD005",
            DiaChiNhanHang = "654 Đường E, Quận 5",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV002",
            MaKh = "KH005",
            MoTa = "Hóa đơn thứ năm",
            Hoten = "Nguyễn Văn E",
            Sdt = "0987654321",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            
        },
        new Hoadon
        {
            MaHoaDon = "HD006",
            DiaChiNhanHang = "987 Đường F, Quận 6",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV003",
            MaKh = "KH006",
            MoTa = "Hóa đơn thứ sáu",
            Hoten = "Trần Thị F",
            Sdt = "0912345678",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
          
        },
        new Hoadon
        {
            MaHoaDon = "HD007",
            DiaChiNhanHang = "159 Đường G, Quận 7",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV001",
            MaKh = "KH007",
            MoTa = "Hóa đơn thứ bảy",
            Hoten = "Nguyễn Văn G",
            Sdt = "0123456789",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
          
        },
        new Hoadon
        {
            MaHoaDon = "HD008",
            DiaChiNhanHang = "753 Đường H, Quận 8",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV002",
            MaKh = "KH008",
            MoTa = "Hóa đơn thứ tám",
            Hoten = "Lê Thị H",
            Sdt = "0987654321",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
       
        },
        new Hoadon
        {
            MaHoaDon = "HD009",
            DiaChiNhanHang = "258 Đường I, Quận 9",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV003",
            MaKh = "KH009",
            MoTa = "Hóa đơn thứ chín",
            Hoten = "Nguyễn Văn I",
            Sdt = "0912345678",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
          
        },
        new Hoadon
        {
            MaHoaDon = "HD010",
            DiaChiNhanHang = "369 Đường J, Quận 10",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV001",
            MaKh = "KH010",
            MoTa = "Hóa đơn thứ mười",
            Hoten = "Trần Văn J",
            Sdt = "0123456789",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
          
        },
        new Hoadon
        {
            MaHoaDon = "HD011",
            DiaChiNhanHang = "123 Đường K, Quận 11",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV002",
            MaKh = "KH011",
            MoTa = "Hóa đơn thứ mười một",
            Hoten = "Lê Thị K",
            Sdt = "0987654321",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
          
        },
        new Hoadon
        {
            MaHoaDon = "HD012",
            DiaChiNhanHang = "456 Đường L, Quận 12",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV003",
            MaKh = "KH012",
            MoTa = "Hóa đơn thứ mười hai",
            Hoten = "Nguyễn Văn L",
            Sdt = "0912345678",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
       
        },
        new Hoadon
        {
            MaHoaDon = "HD013",
            DiaChiNhanHang = "789 Đường M, Quận 1",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV001",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ mười ba",
            Hoten = "Lê Văn M",
            Sdt = "0123456789",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
       
        },
        new Hoadon
        {
            MaHoaDon = "HD014",
            DiaChiNhanHang = "321 Đường N, Quận 2",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV002",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ mười bốn",
            Hoten = "Nguyễn Thị N",
            Sdt = "0987654321",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
         
        },
        new Hoadon
        {
            MaHoaDon = "HD015",
            DiaChiNhanHang = "654 Đường O, Quận 3",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV003",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ mười lăm",
            Hoten = "Lê Văn O",
            Sdt = "0912345678",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
           
        },
        new Hoadon
        {
            MaHoaDon = "HD016",
            DiaChiNhanHang = "987 Đường P, Quận 4",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV001",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ mười sáu",
            Hoten = "Nguyễn Văn P",
            Sdt = "0123456789",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
          
        },
        new Hoadon
        {
            MaHoaDon = "HD017",
            DiaChiNhanHang = "159 Đường Q, Quận 5",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV002",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ mười bảy",
            Hoten = "Trần Thị Q",
            Sdt = "0987654321",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
           
        },
        new Hoadon
        {
            MaHoaDon = "HD018",
            DiaChiNhanHang = "753 Đường R, Quận 6",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV003",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ mười tám",
            Hoten = "Lê Văn R",
            Sdt = "0912345678",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
           
        },
        new Hoadon
        {
            MaHoaDon = "HD019",
            DiaChiNhanHang = "258 Đường S, Quận 7",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV001",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ mười chín",
            Hoten = "Nguyễn Thị S",
            Sdt = "0123456789",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
       
        },
        new Hoadon
        {
            MaHoaDon = "HD020",
            DiaChiNhanHang = "369 Đường T, Quận 8",
            NgayTao = DateOnly.FromDateTime(DateTime.Now),
            Httt = "COD",
            TinhTrang = "Đã thanh toán",
            MaNv = "NV002",
            MaKh = "KH013",
            MoTa = "Hóa đơn thứ hai mươi",
            Hoten = "Lê Văn T",
            Sdt = "0987654321",
            ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
           
        }
        );
        modelBuilder.Entity<Chitietphieunhap>().HasData(
            new Chitietphieunhap { MaCtpn = "CT001", MaPhieuNhap = "PN001", MaSp = "SP001", SoluongNhap = 50, DonGiaNhap = 120000 },
            new Chitietphieunhap { MaCtpn = "CT002", MaPhieuNhap = "PN002", MaSp = "SP002", SoluongNhap = 30, DonGiaNhap = 95000 },
            new Chitietphieunhap { MaCtpn = "CT003", MaPhieuNhap = "PN003", MaSp = "SP003", SoluongNhap = 20, DonGiaNhap = 75000 },
            new Chitietphieunhap { MaCtpn = "CT004", MaPhieuNhap = "PN004", MaSp = "SP004", SoluongNhap = 40, DonGiaNhap = 105000 },
            new Chitietphieunhap { MaCtpn = "CT005", MaPhieuNhap = "PN005", MaSp = "SP005", SoluongNhap = 60, DonGiaNhap = 130000 },
            new Chitietphieunhap { MaCtpn = "CT006", MaPhieuNhap = "PN006", MaSp = "SP006", SoluongNhap = 70, DonGiaNhap = 110000 },
            new Chitietphieunhap { MaCtpn = "CT007", MaPhieuNhap = "PN007", MaSp = "SP007", SoluongNhap = 25, DonGiaNhap = 90000 },
            new Chitietphieunhap { MaCtpn = "CT008", MaPhieuNhap = "PN008", MaSp = "SP008", SoluongNhap = 35, DonGiaNhap = 115000 },
            new Chitietphieunhap { MaCtpn = "CT009", MaPhieuNhap = "PN009", MaSp = "SP009", SoluongNhap = 45, DonGiaNhap = 125000 },
            new Chitietphieunhap { MaCtpn = "CT010", MaPhieuNhap = "PN010", MaSp = "SP010", SoluongNhap = 55, DonGiaNhap = 135000 }
        );

        modelBuilder.Entity<Chitiethoadon>().HasData(
            new Chitiethoadon
            {
                MaHoaDon = "HD001",
                MaSp = "SP001",
                MauSac_ThuocTinhSuyDien = "Đỏ",
                KichThuoc_ThuocTinhSuyDien = "Nhỏ",
                ChatLieu_ThuocTinhSuyDien = "Da Thật",
                SoLuongMua = 2,
                DonGia = 150000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD002",
                MaSp = "SP002",
                MauSac_ThuocTinhSuyDien = "Xanh",
                KichThuoc_ThuocTinhSuyDien = "Trung Bình",
                ChatLieu_ThuocTinhSuyDien = "Vải",
                SoLuongMua = 1,
                DonGia = 200000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD003",
                MaSp = "SP003",
                MauSac_ThuocTinhSuyDien = "Vàng",
                KichThuoc_ThuocTinhSuyDien = "Lớn",
                ChatLieu_ThuocTinhSuyDien = "Nhựa",
                SoLuongMua = 3,
                DonGia = 250000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD004",
                MaSp = "SP004",
                MauSac_ThuocTinhSuyDien = "Trắng",
                KichThuoc_ThuocTinhSuyDien = "Nhỏ",
                ChatLieu_ThuocTinhSuyDien = "Vải",
                SoLuongMua = 5,
                DonGia = 120000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD005",
                MaSp = "SP005",
                MauSac_ThuocTinhSuyDien = "Đen",
                KichThuoc_ThuocTinhSuyDien = "Trung Bình",
                ChatLieu_ThuocTinhSuyDien = "Cotton",
                SoLuongMua = 2,
                DonGia = 175000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD006",
                MaSp = "SP006",
                MauSac_ThuocTinhSuyDien = "Đỏ",
                KichThuoc_ThuocTinhSuyDien = "Lớn",
                ChatLieu_ThuocTinhSuyDien = "Vải",
                SoLuongMua = 1,
                DonGia = 300000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD007",
                MaSp = "SP007",
                MauSac_ThuocTinhSuyDien = "Xanh",
                KichThuoc_ThuocTinhSuyDien = "Nhỏ",
                ChatLieu_ThuocTinhSuyDien = "Da Thật",
                SoLuongMua = 3,
                DonGia = 250000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD008",
                MaSp = "SP008",
                MauSac_ThuocTinhSuyDien = "Vàng",
                KichThuoc_ThuocTinhSuyDien = "Trung Bình",
                ChatLieu_ThuocTinhSuyDien = "Cotton",
                SoLuongMua = 4,
                DonGia = 220000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD009",
                MaSp = "SP009",
                MauSac_ThuocTinhSuyDien = "Trắng",
                KichThuoc_ThuocTinhSuyDien = "Lớn",
                ChatLieu_ThuocTinhSuyDien = "Nhựa",
                SoLuongMua = 2,
                DonGia = 275000
            },
            new Chitiethoadon
            {
                MaHoaDon = "HD010",
                MaSp = "SP010",
                MauSac_ThuocTinhSuyDien = "Đen",
                KichThuoc_ThuocTinhSuyDien = "Nhỏ",
                ChatLieu_ThuocTinhSuyDien = "Vải",
                SoLuongMua = 1,
                DonGia = 180000
            }
        );

        modelBuilder.Entity<Chitietmausac>().HasData(
            new Chitietmausac { MaMau = 1, MaSp = "SP001" },
            new Chitietmausac { MaMau = 2, MaSp = "SP002" },
            new Chitietmausac { MaMau = 3, MaSp = "SP003" },
            new Chitietmausac { MaMau = 4, MaSp = "SP004" },
            new Chitietmausac { MaMau = 5, MaSp = "SP005" },
            new Chitietmausac { MaMau = 1, MaSp = "SP006" },
            new Chitietmausac { MaMau = 2, MaSp = "SP007" },
            new Chitietmausac { MaMau = 3, MaSp = "SP008" },
            new Chitietmausac { MaMau = 4, MaSp = "SP009" },
            new Chitietmausac { MaMau = 5, MaSp = "SP010" }
        );

        modelBuilder.Entity<Chitietkichthuoc>().HasData(
            new Chitietkichthuoc { MaKichThuoc = 1, MaSp = "SP001" },
            new Chitietkichthuoc { MaKichThuoc = 2, MaSp = "SP002" },
            new Chitietkichthuoc { MaKichThuoc = 3, MaSp = "SP003" },
            new Chitietkichthuoc { MaKichThuoc = 1, MaSp = "SP004" },
            new Chitietkichthuoc { MaKichThuoc = 2, MaSp = "SP005" },
            new Chitietkichthuoc { MaKichThuoc = 3, MaSp = "SP006" },
            new Chitietkichthuoc { MaKichThuoc = 1, MaSp = "SP007" },
            new Chitietkichthuoc { MaKichThuoc = 2, MaSp = "SP008" },
            new Chitietkichthuoc { MaKichThuoc = 3, MaSp = "SP009" },
            new Chitietkichthuoc { MaKichThuoc = 1, MaSp = "SP010" }
        );

        modelBuilder.Entity<Chitietchatlieu>().HasData(
            new Chitietchatlieu { MaChatLieu = 1, MaSp = "SP001" },
            new Chitietchatlieu { MaChatLieu = 2, MaSp = "SP002" },
            new Chitietchatlieu { MaChatLieu = 3, MaSp = "SP003" },
            new Chitietchatlieu { MaChatLieu = 4, MaSp = "SP004" },
            new Chitietchatlieu { MaChatLieu = 5, MaSp = "SP005" },
            new Chitietchatlieu { MaChatLieu = 1, MaSp = "SP006" },
            new Chitietchatlieu { MaChatLieu = 2, MaSp = "SP007" },
            new Chitietchatlieu { MaChatLieu = 3, MaSp = "SP008" },
            new Chitietchatlieu { MaChatLieu = 4, MaSp = "SP009" },
            new Chitietchatlieu { MaChatLieu = 5, MaSp = "SP010" }
        );


        modelBuilder.Entity<Hoadon>().HasData(
       new Hoadon
       {
           MaHoaDon = "HD001",
           DiaChiNhanHang = "123 Đường A, Quận B, Thành phố C",
           NgayTao = new DateOnly(2024, 1, 10),
           Httt = "Tiền mặt",
           TinhTrang = "Đang xử lý",
           MaNv = "NV001",
           MaKh = "KH425",
           Hoten = "Nguyễn Văn A",
           Sdt = "0123456789",
           ThoiGianDat = new DateOnly(2024, 1, 9)
       });

       base.OnModelCreating(modelBuilder);
    }

}

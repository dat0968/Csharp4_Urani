using System;
using System.Collections.Generic;
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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            new Mausac { MaMau = "MM001", TenMau = "Đỏ", IsDelete = false },
            new Mausac { MaMau = "MM002", TenMau = "Xanh", IsDelete = false },
            new Mausac { MaMau = "MM003", TenMau = "Vàng", IsDelete = false },
            new Mausac { MaMau = "MM004", TenMau = "Trắng", IsDelete = false },
            new Mausac { MaMau = "MM005", TenMau = "Đen", IsDelete = false }
        );

        modelBuilder.Entity<Chatlieu>().HasData(
            new Chatlieu { MaChatLieu = "CL001", TenChatLieu = "Da Thật", IsDelete = false },
            new Chatlieu { MaChatLieu = "CL002", TenChatLieu = "Vải", IsDelete = false },
            new Chatlieu { MaChatLieu = "CL003", TenChatLieu = "Nhựa", IsDelete = false },
            new Chatlieu { MaChatLieu = "CL004", TenChatLieu = "Toàn Bộ", IsDelete = false },
            new Chatlieu { MaChatLieu = "CL005", TenChatLieu = "Cotton", IsDelete = false }
        );

        modelBuilder.Entity<Kichthuoc>().HasData(
            new Kichthuoc { MaKichThuoc = "KT001", TenKichThuoc = "Nhỏ", KichThuoc1 = "20 x 15 x 10", IsDelete = false },
            new Kichthuoc { MaKichThuoc = "KT002", TenKichThuoc = "Trung Bình", KichThuoc1 = "30 x 25 x 15", IsDelete = false },
            new Kichthuoc { MaKichThuoc = "KT003", TenKichThuoc = "Lớn", KichThuoc1 = "40 x 30 x 20", IsDelete = false }
        );
        modelBuilder.Entity<Chitiethoadon>()
           .HasKey(c => new { c.MaHoaDon, c.MaSp });
        // Thêm Admin
        modelBuilder.Entity<Nhanvien>().HasData(new Nhanvien
        {
            MaNv = "NV001",
            HoTen = "Admin",
            GioiTinh = "Nam",
            NgaySinh = new DateOnly(2005, 02, 23),
            DiaChi = "BMT",
            Cccd = "123456789",
            Sdt = "0123456789",
            Email = "thanhdat0968367@gmail.com",
            NgayVaoLam = new DateOnly(2023, 1, 1),
            Luong = 10000000,
            VaiTro = "Admin",
            TenTaiKhoan = "Admin",
            MatKhau = "Admin123",
            TinhTrang = "Hoạt động",
            IsDelete = false
        });

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

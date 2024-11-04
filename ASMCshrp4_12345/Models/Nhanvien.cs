using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.Models;

public partial class Nhanvien
{
    [Key]
    [Required(ErrorMessage = "Mã nhân viên không được để trống")]
    [StringLength(5, ErrorMessage = "Mã nhân viên không được vượt quá 5 ký tự.")]
    public string MaNv { get; set; }

    [Required(ErrorMessage = "Họ tên không được để trống")]
    [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự.")]
    public string HoTen { get; set; }

    [Required(ErrorMessage = "Giới tính không được để trống")]
    public string GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    [StringLength(20, ErrorMessage = "CCCD không được vượt quá 20 ký tự.")]
    public string? Cccd { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 ký tự.")]
    public string Sdt { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Ngày vào làm không được để trống")]
    public DateOnly NgayVaoLam { get; set; }

    [Required(ErrorMessage = "Lương không được để trống")]
    [Range(0, int.MaxValue, ErrorMessage = "Lương phải lớn hơn hoặc bằng 0.")]
    public int Luong { get; set; }

    [Required(ErrorMessage = "Vai trò không được để trống")]
    public string VaiTro { get; set; } = "Nhân viên";

    [StringLength(15, ErrorMessage = "Tên tài khoản không được vượt quá 15 ký tự.")]
    public string? TenTaiKhoan { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [StringLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự.")]
    public string MatKhau { get; set; }

    public string TinhTrang { get; set; } = "Đang hoạt động";

    public bool IsDelete { get; set; } = false; 

    public virtual ICollection<Hoadon>? Hoadons { get; set; } = new List<Hoadon>();
}

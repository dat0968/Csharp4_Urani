using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.Models;

public partial class Khachhang
{
    [Key]
    [Required(ErrorMessage = "Mã khách hàng không được để trống")]
    [StringLength(5, ErrorMessage = "Mã khách hàng không được vượt quá 5 ký tự.")]

    public string MaKh { get; set; }

    //[Required(ErrorMessage = "Họ tên không được để trống")]
    [StringLength(50, ErrorMessage = "Họ tên không được vượt quá 50 ký tự.")]
    public string? HoTen { get; set; }

    public string? Avatar { get; set; }

    //[Required(ErrorMessage = "Giới tính không được để trống")]
    [StringLength(5, ErrorMessage = "Giới tính không được vượt quá 5 ký tự.")]
    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
    public string? DiaChi { get; set; }


    [StringLength(12, ErrorMessage = "CCCD không được vượt quá 12 ký tự.")]
    public string? Cccd { get; set; }


    //[Required(ErrorMessage = "Số điện thoại không được để trống")]
    [StringLength(10, ErrorMessage = "Số điện thoại không được vượt quá 10 ký tự.")]
    public string? Sdt { get; set; }


    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
    public string Email { get; set; }

    [StringLength(15, ErrorMessage = "Tên tài khoản không được vượt quá 15 ký tự.")]
    public string? TenTaiKhoan { get; set; }


    //[Required(ErrorMessage = "Mật khẩu không được để trống")]
    [StringLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự.")]
    public string? MatKhau { get; set; }


    [StringLength(30, ErrorMessage = "Tình trạng không được vượt quá 30 ký tự.")]
    public string TinhTrang { get; set; } = "Đang hoạt động";

    public bool IsDelete { get; set; } = false;

    public virtual ICollection<Hoadon>? Hoadons { get; set; } = new List<Hoadon>();
}

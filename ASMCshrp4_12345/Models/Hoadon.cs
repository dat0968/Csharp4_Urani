using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models;

public partial class Hoadon
{
    [Key]
    [Required(ErrorMessage = "Mã hóa đơn không được để trống")]
    [StringLength(5, ErrorMessage = "Mã hóa đơn không được vượt quá 5 ký tự.")]
    public string MaHoaDon { get; set; }

    [Required(ErrorMessage = "Địa chỉ nhận hàng không được để trống")]
    [StringLength(200, ErrorMessage = "Địa chỉ nhận hàng không được vượt quá 200 ký tự.")]
    public string DiaChiNhanHang { get; set; } 

    [Required(ErrorMessage = "Ngày tạo không được để trống")]
    public DateOnly NgayTao { get; set; }

    [Required(ErrorMessage = "Hình thức thanh toán không được để trống")]

    public string Httt { get; set; } 

    [Required(ErrorMessage = "Tình trạng không được để trống")]
    [StringLength(30, ErrorMessage = "Tình trạng không được vượt quá 30 ký tự.")]
    public string TinhTrang { get; set; }

    [StringLength(5, ErrorMessage = "Mã nhân viên không được vượt quá 5 ký tự.")]
    [ForeignKey(nameof(MaNvNavigation))]
    public string? MaNv { get; set; }

    [Required(ErrorMessage = "Khách hàng không được để trống")]
    [StringLength(5, ErrorMessage = "Khách hàng không được vượt quá 5 ký tự.")]
    [ForeignKey(nameof(MaKhNavigation))]
    public string MaKh { get; set; } 

    
    public string? MoTa { get; set; } 

    [StringLength(50, ErrorMessage = "Họ tên không được vượt quá 50 ký tự.")]
    public string? Hoten { get; set; }


    [StringLength(12, ErrorMessage = "Số điện thoại không được vượt quá 12 ký tự.")]
    public string? Sdt { get; set; }

    
    [Required(ErrorMessage = "Thời gian đặt không được để trống")]
    public DateOnly ThoiGianDat { get; set; }

    
    public DateOnly? ThoiGianGiao { get; set; }

    public virtual ICollection<Chitiethoadon>? Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual Khachhang? MaKhNavigation { get; set; } 

    public virtual Nhanvien? MaNvNavigation { get; set; }
}

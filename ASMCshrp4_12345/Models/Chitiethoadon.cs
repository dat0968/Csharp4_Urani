using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models;

public partial class Chitiethoadon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaChiTietHoaDon { get; set; }
    [ForeignKey("MaHoaDonNavigation")]
    [Required(ErrorMessage = "Mã hóa đơn không được để trống.")]
    [StringLength(5, ErrorMessage = "Mã hóa đơn không được vượt quá 5 ký tự.")]
    public string MaHoaDon { get; set; }

    
    [ForeignKey("MaSpNavigation")]
    [Required(ErrorMessage = "Mã sản phẩm không được để trống.")]
    [StringLength(5, ErrorMessage = "Mã sản phẩm không được vượt quá 5 ký tự.")]
    public string MaSp { get; set; }
    public int? MaComBo_ThuocTinhSuyDien { get; set; }

    public string? MauSac_ThuocTinhSuyDien { get; set; }

    public string? KichThuoc_ThuocTinhSuyDien { get; set; }

    public string? ChatLieu_ThuocTinhSuyDien { get; set; }
    [Required(ErrorMessage = "Số lượng mua không được để trống.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Số lượng mua phải lớn hơn 0 và không được chứa ký tự đặc biệt ")]
    public int SoLuongMua { get; set; }

    [Required(ErrorMessage = "Đơn giá không được để trống.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Đơn giá phải lớn hơn 0 và không được chứa ký tự đặc biệt ")]
    public double DonGia { get; set; }

    public virtual Hoadon? MaHoaDonNavigation { get; set; } 

    public virtual Sanpham? MaSpNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models;

public partial class Chitietphieunhap
{
    [Key]
    [Required(ErrorMessage = "Mã chi tiết phiếu nhập không được để trống")]
    [StringLength(5, ErrorMessage = "Mã CTPN không được vượt quá 5 ký tự.")]
    public string MaCtpn { get; set; }
    [ForeignKey("MaPhieuNhapNavigation")]
    [Required(ErrorMessage = "Mã phiếu nhập không được để trống")]
    public string MaPhieuNhap { get; set; }
    [ForeignKey("MaSpNavigation")]
    [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
    public string MaSp { get; set; }
    [Required(ErrorMessage = "Số lượng nhập không được để trống.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Số lượng nhập phải lớn hơn 0 và không được chứa ký tự đặc biệt ")]
    public int SoluongNhap { get; set; }
    [Required(ErrorMessage = "Đơn giá nhập không được để trống.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Đơn giá nhập phải lớn hơn 0 và không được chứa ký tự đặc biệt ")]
    public double DonGiaNhap { get; set; }

    public virtual Phieunhap? MaPhieuNhapNavigation { get; set; }

    public virtual Sanpham? MaSpNavigation { get; set; }
}

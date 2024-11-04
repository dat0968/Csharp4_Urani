using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models;

public partial class Sanpham
{
    [Key]
    [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
    [StringLength(5, ErrorMessage = "Mã sản phẩm không được vượt quá 5 ký tự.")]
    public string MaSp { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [StringLength(40, ErrorMessage ="Tên sản phẩm không vượt quá 40 kí tự")]
    public string TenSp { get; set; }

    [Required(ErrorMessage = "Số lượng bán không được để trống")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Số lượng bán phải lớn hơn 0 và không được chứa ký tự đặc biệt ")]
    public int SoLuongBan { get; set; }

    [Required(ErrorMessage = "Đơn giá bán không được để trống")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Đơn giá bán phải lớn hơn 0 không được chứa ký tự đặc biệt")]
    public double DonGiaBan { get; set; }
    [ForeignKey("MaThuongHieuNavigation")]
    [Required(ErrorMessage = "Thương hiệu không được để trống")]
    public string MaThuongHieu { get; set; }

    [Required(ErrorMessage = "Hình ảnh không được để trống")]
    public string Hinh { get; set; }

    [Required(ErrorMessage = "Mô tả không được để trống")]
    public string MoTa { get; set; }

    [Required(ErrorMessage = "Ngày sản xuất không được để trống")]
    public DateOnly NgaySanXuat { get; set; }
    [ForeignKey("MaNhaCcNavigation")]
    [Required(ErrorMessage = "Nhà cung cấp không được để trống")]
    public string MaNhaCc { get; set; }
    [ForeignKey("MaChatLieuNavigation")]
    [Required(ErrorMessage = "Chất liệu không được để trống")]
    public string MaChatLieu { get; set; }
    [ForeignKey("MaMauNavigation")]
    [Required(ErrorMessage = "Màu không được để trống")]
    public string MaMau { get; set; }
    [ForeignKey("MaKichThuocNavigation")]
    [Required(ErrorMessage = "Kích thước không được để trống")]
    public string MaKichThuoc { get; set; }

    public bool IsDelete { get; set; } = false;

   
    public virtual ICollection<Chitiethoadon>? Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual ICollection<Chitietphieunhap>? Chitietphieunhaps { get; set; } = new List<Chitietphieunhap>();

    public virtual ICollection<Hinhanh>? Hinhanhs { get; set; } = new List<Hinhanh>();

  
    public virtual Chatlieu? MaChatLieuNavigation { get; set; }

    public virtual Kichthuoc? MaKichThuocNavigation { get; set; }

 
    public virtual Mausac? MaMauNavigation { get; set; }

   
    public virtual Nhacungcap? MaNhaCcNavigation { get; set; } 

   
    public virtual Thuonghieu? MaThuongHieuNavigation { get; set; } 
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.Models;

public partial class Nhacungcap
{
    [Key]
    [Required(ErrorMessage = "Mã nhà cung cấp không được để trống")]
    [StringLength(5, ErrorMessage = "Mã nhà cung cấp không được vượt quá 5 ký tự.")]
    public string MaNhaCc { get; set; }

    [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
    [StringLength(100, ErrorMessage = "Tên nhà cung cấp không được vượt quá 100 ký tự.")]
    public string TenNhaCc { get; set; }

    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
    public string DiaChi { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [StringLength(11, ErrorMessage = "Số điện thoại không được vượt quá 11 ký tự.")]
    [RegularExpression(@"0[9876]\d{8}",ErrorMessage ="Số điện thoại phải bắt đầu từ 0 và có 10 số")]
    public string Sdt { get; set; }

    public bool IsDelete { get; set; } = false; 

    public virtual ICollection<Sanpham>? Sanphams { get; set; } = new List<Sanpham>();
}

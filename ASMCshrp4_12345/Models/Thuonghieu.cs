using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.Models;

public partial class Thuonghieu
{
    [Key] 
    [Required(ErrorMessage = "Mã thương hiệu không được để trống")]
    [StringLength(5, ErrorMessage = "Mã thương hiệu không được vượt quá 5 ký tự.")]
    public string MaThuongHieu { get; set; }

    [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
    [StringLength(40, ErrorMessage = "Tên thương hiệu không được vượt quá 40 ký tự.")]
    public string TenThuongHieu { get; set; }

    public bool IsDelete { get; set; } = false;

    // Mối quan hệ với bảng Sanpham
    public virtual ICollection<Sanpham>? Sanphams { get; set; } = new List<Sanpham>();
}

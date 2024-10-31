using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models;

public partial class Hinhanh
{
    [Key]
    [Required(ErrorMessage ="Mã hình ảnh không được để trống")]
    [StringLength(5, ErrorMessage = "Mã hình ảnh không được vượt quá 5 ký tự.")]
    public int MaHinhAnh { get; set; }
    [Required(ErrorMessage = "Đường dẫn ảnh không được để trống")]
    public string HinhAnh1 { get; set; }
    [ForeignKey("MaSpNavigation")]
    [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
    [StringLength(5, ErrorMessage = "Mã sản phẩm không được vượt quá 5 ký tự.")]
    public string MaSp { get; set; }

    public virtual Sanpham? MaSpNavigation { get; set; }
}

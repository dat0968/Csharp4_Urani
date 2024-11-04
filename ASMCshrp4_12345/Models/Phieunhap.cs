using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.Models;

public partial class Phieunhap
{
    [Key] 
    [Required(ErrorMessage = "Mã phiếu nhập không được để trống")]
    [StringLength(5, ErrorMessage = "Mã phiếu nhập không được vượt quá 5 ký tự.")]
    public string MaPhieuNhap { get; set; }

    [Required(ErrorMessage = "Thời gian nhập không được để trống")]
    public DateOnly ThoiGianNhap { get; set; }

    public virtual ICollection<Chitietphieunhap>? Chitietphieunhaps { get; set; } = new List<Chitietphieunhap>();
}

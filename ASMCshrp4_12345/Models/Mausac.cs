using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.Models;

public partial class Mausac
{
    [Key] 
    [Required(ErrorMessage = "Mã màu không được để trống")]
    [StringLength(5, ErrorMessage = "Mã màu không được vượt quá 5 ký tự.")]
    public string MaMau { get; set; }

    [Required(ErrorMessage = "Tên màu không được để trống")]
    [StringLength(20, ErrorMessage = "Tên màu không được vượt quá 20 ký tự.")]
    public string TenMau { get; set; }

    public bool IsDelete { get; set; } = false; 

    public virtual ICollection<Sanpham>? Sanphams { get; set; } = new List<Sanpham>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models;

public partial class Kichthuoc
{
    [Key] 
    [Required(ErrorMessage = "Mã kích thước không được để trống")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaKichThuoc { get; set; }

    [Required(ErrorMessage = "Tên kích thước không được để trống")]
    [StringLength(30, ErrorMessage = "Tên kích thước không được vượt quá 30 ký tự.")]
    public string TenKichThuoc { get; set; } 

    [Required(ErrorMessage = "Kích thước không được để trống")]
    [StringLength(50, ErrorMessage = "Kích thước không được vượt quá 50 ký tự.")]
    public string KichThuoc1 { get; set; } 

    public bool IsDelete { get; set; } = false;

    public virtual ICollection<Chitietkichthuoc>? Chitietkichthuocs { get; set; } = new List<Chitietkichthuoc>();
}

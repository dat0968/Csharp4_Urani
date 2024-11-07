using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models;

public partial class Chatlieu
{
    [Key]
    [Required(ErrorMessage = "Mã chất liệu không được để trống.")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaChatLieu { get; set; }
    [Required(ErrorMessage = "Tên chất liệu không được để trống")]
    [StringLength(50, ErrorMessage = "Tên chất liệu không vượt quá 50 kí tự")]
    public string TenChatLieu { get; set; }
    public bool IsDelete { get; set; } = false;
    public virtual ICollection<Chitietchatlieu>? Chitietchatlieus { get; set; } = new List<Chitietchatlieu>();

}

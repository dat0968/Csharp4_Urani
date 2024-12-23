﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class Chitietmausac
    {
        [ForeignKey("MaMauNavigation")]
        [Required]
        public int MaMau { get; set; }
        [ForeignKey("MaSpNavigation")]
        [Required]
        public string MaSp { get; set; }
        public virtual Mausac? MaMauNavigation { get; set; }
        public virtual Sanpham? MaSpNavigation { get; set; }
        [NotMapped]  // Nếu bạn không muốn thuộc tính này được map vào cơ sở dữ liệu
        public string TenMau { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class Chitietkichthuoc
    {
        [ForeignKey("MaKichThuocNavigation")]
        [Required]
        public int MaKichThuoc { get; set; }
        [ForeignKey("MaSpNavigation")]
        [Required]
        public string MaSp { get; set; }
        public virtual Kichthuoc? MaKichThuocNavigation { get; set; }
        public virtual Sanpham? MaSpNavigation { get; set; }
    }
}

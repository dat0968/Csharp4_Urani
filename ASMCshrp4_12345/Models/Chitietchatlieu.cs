using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class Chitietchatlieu
    {
        [ForeignKey("MaChatLieuNavigation")]
        [Required]
        public int MaChatLieu { get; set; }
        [ForeignKey("MaSpNavigation")]
        [Required]
        public string MaSp { get; set; }
        public virtual Chatlieu? MaChatLieuNavigation { get; set; }
        public virtual Sanpham? MaSpNavigation { get; set; }
    }
}

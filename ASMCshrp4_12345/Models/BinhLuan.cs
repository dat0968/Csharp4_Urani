using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class BinhLuan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBinhLuan { get; set; }
        [Required]
        public string NoiDung {  get; set; }
        [Required]
        public DateTime ThoiGian { get; set; }
        [Required]
        [ForeignKey("MaSPNavigation")]
        public string MaSP { get; set; }
        [Required]
        [ForeignKey("MaKHNavigation")]
        public string MaKH { get; set; }
        public double Rating { get; set; }
        public bool isDelete { get; set; } = false;

        public virtual Sanpham? MaSPNavigation { get; set; }
        public virtual Khachhang? MaKHNavigation { get; set; }
        public virtual ICollection<TraLoiBinhLuan>? TraLoiBinhLuans { get; set; } = new List<TraLoiBinhLuan>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class CtComBo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCtComBo { get; set; }
        [ForeignKey("MaComBoNavigation")]
        public int MaComBo { get; set; }
        [ForeignKey("MaSpNavigation")]
        public string MaSp { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public virtual ComBo? MaComBoNavigation { get; set; }
        public virtual Sanpham? MaSpNavigation { get; set; }
    }
}

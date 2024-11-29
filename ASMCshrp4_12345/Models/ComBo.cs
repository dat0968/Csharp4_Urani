using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class ComBo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaComBo { get; set; }
        public string TenComBo { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public string? MoTa { get; set; }
        public virtual ICollection<CtComBo>? CtComBos { get; set; } = new List<CtComBo>();
        public virtual ICollection<AnhComBo>? AnhComBos { get; set; } = new List<AnhComBo>();

    }
}

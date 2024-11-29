using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class AnhComBo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnh { get; set; }
        [ForeignKey("MaComBoNavigation")]
        public int MaComBo { get; set; }
        public string HinhAnh { get; set; }
        public virtual ComBo? MaComBoNavigation { get; set; }
    }
}

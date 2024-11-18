using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class TraLoiBinhLuan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("IdBinhLuanNavigation")]
        public int IdBinhLuan { get; set; }
        [Required]
        public DateTime ThoiGian { get; set; }
        [Required]
        public string NoiDung { get; set; }
        [Required]
        [ForeignKey("MaNVNavigation")]
        public string MaNV { get; set; }
        public bool isDelete { get; set; } = false;
        public virtual Nhanvien? MaNVNavigation { get; set; }
        public virtual BinhLuan? IdBinhLuanNavigation { get; set; }
    }
}

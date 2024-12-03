using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASMCshrp4_12345.Models
{
    public class ComBo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaComBo { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên combo.")]
        [StringLength(300, ErrorMessage = "Tên Combo không được vượt quá 300 ký tự.")]
        public string TenComBo { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đơn giá.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 0.")]
        public double DonGia { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
        public int SoLuong { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? MoTa { get; set; }
        public virtual ICollection<CtComBo>? CtComBos { get; set; } = new List<CtComBo>();
        public virtual ICollection<AnhComBo>? AnhComBos { get; set; } = new List<AnhComBo>();

    }
}

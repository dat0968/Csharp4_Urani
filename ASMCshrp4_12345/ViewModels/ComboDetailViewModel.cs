using ASMCshrp4_12345.Models;


namespace ASMCshrp4_12345.ViewModels
{
    public class ComboDetailViewModel
    {
        public int MaComBo { get; set; }
        public string TenComBo { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public string MoTa { get; set; }
        public List<IFormFile> HinhAnhList { get; set; }
        public List<int> HinhAnhToDelete { get; set; }
        public List<SanPhamComBoViewModel> SanPhamList { get; set; }
        public List<SanPhamComBoViewModel> AllSanPhamList { get; set; } = new List<SanPhamComBoViewModel>();
        public List<AnhComBo> AnhComBos { get; set; }
    }
}

using ASMCshrp4_12345.Models;

namespace ASMCshrp4_12345.ViewModels
{
    public class ComboViewModel
    {
        public int MaComBo {  get; set; }
        public string TenComBo { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public List<AnhComBo> AnhComBos { get; set; }
        public List<int> HinhAnhToDelete { get; set; }
        public List<SanPhamComBoViewModel> SanPhamList { get; set; }
        public List<Chitietchatlieu> ChatLieuList { get; set; }
        public List<Chitietmausac> MauSacList { get; set; }
        public List<Chitietkichthuoc> KichThuocList { get; set; }
        public List<SanPhamComBoViewModel> AllSanPhamList { get; set; } = new List<SanPhamComBoViewModel>();
        public List<IFormFile> HinhAnhList { get; set; }
    }
}

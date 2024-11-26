namespace ASMCshrp4_12345.ViewModels
{
    public class ComboDetailViewModel
    {
        public int MaComBo { get; set; }
        public string TenComBo { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public List<SanPhamComBoViewModel> SanPhamList { get; set; }
    }
}

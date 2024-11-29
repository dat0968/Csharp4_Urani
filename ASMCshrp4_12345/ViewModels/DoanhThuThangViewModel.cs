using ASMCshrp4_12345.Models;

namespace ASMCshrp4_12345.ViewModels
{
    public class DoanhThuThangViewModel
    {
        public decimal DoanhThuThang { get; set; }
        public List<ProductSale> SanPhamBanChay { get; set; }
    }
    public class ProductSale
    {
        public string TenSp { get; set; }
        public int SoLuongBan { get; set; }
        public double DonGia { get; set; }
    }
}

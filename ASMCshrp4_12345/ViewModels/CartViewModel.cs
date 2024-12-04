using ASMCshrp4_12345.Models;
using DocumentFormat.OpenXml.Bibliography;

namespace ASMCshrp4_12345.ViewModels
{
    public class CartViewModel
    {
        public string MaHh { get; set; }
        public string Hinh { get; set; }
        public string TenHh { get; set; }
        public string Mau { get; set; }
        public string ChatLieu { get; set; }
        public string KichThuoc { get; set; }
        //public List<string> Maus { get; set; }
        //public List<string> ChatLieus { get; set; }
        //public List<string> KichThuocs { get; set; }
        public List<Tuple<string, string, string>> thuoctinh { get; set; }
        public List<dsSanPhamViewModel> dsSanPhams { get; set; }
        public bool isCombo { get; set; }
        public decimal? Gia { get; set; }
        public string MoTa { get; set; }
        public int SoLuong { get; set; }
        public int SoluongAvailable { get; set; }
        public decimal ThanhTien => (decimal)(Gia * SoLuong);
    }
    public class dsSanPhamViewModel
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string KichThuoc { get; set; }
        public string ChatLieu { get; set; }
        public string Mau { get; set; } = string.Empty;

    }
}

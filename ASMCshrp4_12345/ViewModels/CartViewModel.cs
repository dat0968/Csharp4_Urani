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
        public decimal? Gia { get; set; }
        public int SoLuong { get; set; }
        public int SoluongAvailable { get; set; }
        public decimal ThanhTien => (decimal)(Gia * SoLuong);
    }
}

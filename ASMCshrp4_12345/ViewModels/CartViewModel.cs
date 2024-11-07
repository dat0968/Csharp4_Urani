namespace ASMCshrp4_12345.ViewModels
{
    public class CartViewModel
    {
        public string MaHh { get; set; }
        public string Hinh { get; set; }
        public string TenHh { get; set; }
        public float Gia { get; set; }
        public int SoLuong { get; set; }
        public float ThanhTien => Gia * SoLuong;
    }
}

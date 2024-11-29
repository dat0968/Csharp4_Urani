using ASMCshrp4_12345.Migrations;

namespace ASMCshrp4_12345.ViewModels
{
        public class SanPhamComBoViewModel
        {
            public string MaSp { get; set; }
            public string TenSp { get; set; }
            public double GiaBan { get; set; }
            public bool IsSelected { get; set; }
            public int SoLuong { get; set; }
            public string? TenMau { get; set; }      // Màu sắc
            public string? TenKichThuoc { get; set; } // Kích thước
            public string? TenChatLieu { get; set; }
            
    }
}

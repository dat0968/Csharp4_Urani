using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASMCshrp4_12345.Controllers
{
    
    public class ThongKeController : Controller
    {
        private readonly Csharp4Context _context;
        public ThongKeController(Csharp4Context db)
        {
            _context = db;
        }
        public IActionResult Index()
        {

            var model = new DoanhThuThangViewModel()
            {

                SoLuongDonThanhToan = _context.Hoadons.Count(p => p.TinhTrang == "Đã thanh toán"),
                DoanhThuThang = (decimal)_context.Chitiethoadons.Where(p => p.MaHoaDonNavigation.NgayTao.Month == DateTime.Now.Month && p.MaHoaDonNavigation.NgayTao.Year == DateTime.Now.Year && p.MaHoaDonNavigation.TinhTrang == "Đã thanh toán")
                                .Sum(ct => ct.SoLuongMua * ct.DonGia),
                SoLuongNhanVien = _context.Nhanviens.Count(),
                SoLuongKhachHang = _context.Khachhangs.Count(),
                SoLuongNhanVienNam = _context.Nhanviens.Count(n => n.GioiTinh == "Nam"),
                SoLuongNhanVienNu = _context.Nhanviens.Count(n => n.GioiTinh == "Nữ"),

                SoLuongKhachHangNam = _context.Khachhangs.Count(k => k.GioiTinh == "Nam"),
                SoLuongKhachHangNu = _context.Khachhangs.Count(k => k.GioiTinh == "Nữ"),
            }; 
            return View(model);
        }
    }
}

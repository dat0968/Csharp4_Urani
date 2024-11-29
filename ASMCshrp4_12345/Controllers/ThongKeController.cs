using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using AspNetCoreGeneratedDocument;
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
        public IActionResult Index(int? month, int? year)
        {
            month = month ?? DateTime.Now.Month;
            year = year ?? DateTime.Now.Year;
            ViewData["CurrentMonth"] = month;
            ViewData["CurrentYear"] = year;
            var doanhthu = _context.Chitiethoadons
            .Where(c => c.MaHoaDonNavigation.NgayTao.Month == month && c.MaHoaDonNavigation.NgayTao.Year == year)
            .Sum(c => c.SoLuongMua * c.DonGia);

            var top5SanPham = _context.Chitiethoadons
            .Where(c => c.MaHoaDonNavigation.NgayTao.Month == month && c.MaHoaDonNavigation.NgayTao.Year == year)
            .GroupBy(c => c.MaSp)
            .Select(g => new ProductSale
            {
                TenSp = g.FirstOrDefault().MaSpNavigation.TenSp,
                SoLuongBan = g.Sum(x => x.SoLuongMua),
                DonGia = g.FirstOrDefault().DonGia
            })
            .OrderByDescending(p => p.SoLuongBan)
            .Take(5)
            .ToList();
            var thongKe = new DoanhThuThangViewModel
            {
                DoanhThuThang = (decimal)doanhthu,
                SanPhamBanChay = top5SanPham
            };
            ViewBag.Top5SanPhamLabels = top5SanPham.Select(x => x.TenSp).ToList();
            ViewBag.Top5SanPhamData = top5SanPham.Select(x => x.SoLuongBan).ToList();
            ViewBag.DoanhThu = doanhthu;
            return View(thongKe);
        }
    }
}

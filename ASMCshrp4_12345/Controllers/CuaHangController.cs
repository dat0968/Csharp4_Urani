using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using X.PagedList;
using X.PagedList.Extensions;
using System.Linq;
using NuGet.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace ASMCshrp4_12345.Controllers
{
    public class CuaHangController : Controller
    {
        private readonly Csharp4Context _context;
        public CuaHangController(Csharp4Context context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, int pageSize = 6,
            string sortOrder = "", string selectedBrand = null, string[] selectedColors = null,
            string[] selectedSizes = null, decimal? minPrice = null, decimal? maxPrice = null, string searchTerm = null)
        {
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            var sanPhamQuery = _context.Sanphams.Where(p => p.IsDelete == false && p.Chitietchatlieus.Any() && p.Chitietkichthuocs.Any() && p.Chitietmausacs.Any() )
                .Include(s => s.Hinhanhs)
                .Include(s => s.Chitietkichthuocs)
                .ThenInclude(s => s.MaKichThuocNavigation)
                .Include(s => s.Chitietmausacs)
                .ThenInclude(s => s.MaMauNavigation)
                .Include(s => s.Chitietchatlieus)
                .ThenInclude(s => s.MaChatLieuNavigation)
                .Include(s => s.BinhLuans)
                .AsQueryable();
            // Tìm kiếm theo tên sản phẩm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.TenSp.Contains(searchTerm));
            }
            // Lọc theo thương hiệu
            if (!string.IsNullOrEmpty(selectedBrand))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.MaThuongHieu == selectedBrand);
            }
            //Lọc theo màu sắc
            if (selectedColors != null && selectedColors.Length > 0 && !selectedColors.Contains("all"))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.Chitietmausacs.Any(p => selectedColors.Contains(p.MaMau.ToString())));
            }
            // Lọc theo kích thước
            if (selectedSizes != null && selectedSizes.Length > 0 && !selectedSizes.Contains("all"))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.Chitietkichthuocs.Any(p => selectedSizes.Contains(p.MaKichThuoc.ToString())));
            }
                // Lọc theo khoảng giá
                if (minPrice.HasValue && maxPrice.HasValue)
            {
                sanPhamQuery = sanPhamQuery.Where(sp => (decimal)sp.DonGiaBan >= minPrice.Value && (decimal)sp.DonGiaBan <= maxPrice.Value);
            }

            // Sắp xếp theo giá
            switch (sortOrder)
            {
                case "price_asc":
                    sanPhamQuery = sanPhamQuery.OrderBy(sp => sp.DonGiaBan);
                    break;
                case "price_desc":
                    sanPhamQuery = sanPhamQuery.OrderByDescending(sp => sp.DonGiaBan);
                    break;
                default:
                    sanPhamQuery = sanPhamQuery.OrderBy(sp => sp.MaSp);
                    break;
            }
            foreach (var sanPham in sanPhamQuery)
            {
                // Tính điểm rating trung bình từ tất cả bình luận (nếu có)
                if (sanPham.BinhLuans.Any())
                {
                    sanPham.Rating = sanPham.BinhLuans.Average(bl => bl.Rating);  
                }
                else
                {
                    sanPham.Rating = 0;  
                }
            }
            var sanPhams = sanPhamQuery.ToPagedList(page, pageSize);
            return View(sanPhams);
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.Sanphams
                .Include(s => s.Hinhanhs)
                .Include(s => s.Chitietkichthuocs)
                    .ThenInclude(kt => kt.MaKichThuocNavigation)
                .Include(s => s.Chitietmausacs)
                    .ThenInclude(ms => ms.MaMauNavigation)
                .Include(s => s.Chitietchatlieus)
                    .ThenInclude(cl => cl.MaChatLieuNavigation)
                .Include(s => s.BinhLuans)
                    .ThenInclude(kh => kh.MaKHNavigation)
                .Include(m => m.BinhLuans)
                    .ThenInclude(s => s.TraLoiBinhLuans)
                    .ThenInclude(s => s.MaNVNavigation)

                .FirstOrDefaultAsync(m => m.MaSp == id);

            if (sanPham == null)
            {
                return NotFound();
            }
            sanPham.Rating = sanPham.BinhLuans.Any() ? sanPham.BinhLuans.Average(p => p.Rating) : 0;
            var sanPhamTuongTu = _context.Sanphams.Where(p => p.MaThuongHieu == sanPham.MaThuongHieu && p.MaSp != sanPham.MaSp )
                .Include(s => s.Hinhanhs)
                .Include(s => s.Chitietkichthuocs)
                .ThenInclude(s => s.MaKichThuocNavigation)
                .Include(s => s.Chitietmausacs)
                .ThenInclude(s => s.MaMauNavigation)
                .Include(s => s.Chitietchatlieus)
                .ThenInclude(s => s.MaChatLieuNavigation)
                .Include(s => s.BinhLuans)
                .ToList();
            foreach (var sp in sanPhamTuongTu)
            {
                sp.Rating = sp.BinhLuans.Any()
                    ? sp.BinhLuans.Average(bl => bl.Rating)
                    : 0;
            }
            ViewBag.SanPhamTuongTu = sanPhamTuongTu;

            var sanPhams = new List<Sanpham> { sanPham };

            return View(sanPhams);
        }
        [HttpPost]
        public IActionResult SendRating(string MaSP, string NoiDung, int rating)
        {
            if (User.Identity.IsAuthenticated == false )
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để thực hiện thao tác này";
                return RedirectToAction("Details", new { id = MaSP });
            }
            else
            {
                if (rating == 0)
                {
                    TempData["ErrorMessage"] = "Hãy điền đầy đủ nội dung bình luận và chọn sao đánh giá";
                    return RedirectToAction("Details", new { id = MaSP });
                }
                var newComment_Rating = new BinhLuan
                {
                    NoiDung = NoiDung,
                    ThoiGian = DateTime.Now,
                    MaSP = MaSP,
                    MaKH = User.Claims.FirstOrDefault(p => p.Type == "CustomerID").Value,
                    Rating = rating,
                    isDelete = false,
                };
                _context.Binhluans.Add(newComment_Rating);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Đã gửi đánh giá thành công";
            }
            
            return RedirectToAction("Details", new { id = MaSP });
        }
        
    }
}

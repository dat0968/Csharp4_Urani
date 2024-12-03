using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using X.PagedList;
using X.PagedList.Extensions;
using System.Linq;
using NuGet.Versioning;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.IdentityModel.Tokens;

namespace ASMCshrp4_12345.Controllers
{
    public class CuaHangController : Controller
    {
        private readonly Csharp4Context _context;
        public CuaHangController(Csharp4Context context)
        {
            _context = context;
        }
        public IActionResult Index(int page, int pageSize,
            string? sortOrder, string? priceRange, string? selectedBrand, string? selectedColor,
            string? selectedSize, string? searchTerm)
        {
            ViewBag.sortOrder = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.priceRange = priceRange ?? "all";
            ViewBag.selectedColor = selectedColor ?? "all";
            ViewBag.selectedSize = selectedSize ?? "all";
            page = page < 1 ? 1 : page;
            pageSize = 6;
            var sanPhamQuery = _context.Sanphams.Where(p => p.IsDelete == false && p.Chitietchatlieus.Any() && p.Chitietkichthuocs.Any() && p.Chitietmausacs.Any())
                .Include(s => s.Hinhanhs)
                .Include(s => s.Chitietkichthuocs)
                .ThenInclude(s => s.MaKichThuocNavigation)
                .Include(s => s.Chitietmausacs)
                .ThenInclude(s => s.MaMauNavigation)
                .Include(s => s.Chitietchatlieus)
                .ThenInclude(s => s.MaChatLieuNavigation)
                .Include(s => s.BinhLuans)
                .Include(s => s.CtComBos)
                    .ThenInclude(s => s.MaComBoNavigation)
                    .ThenInclude(combo => combo.AnhComBos)
                .AsQueryable();
            
            // Tìm kiếm theo tên sản phẩm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                sanPhamQuery = sanPhamQuery.Where(sp =>
                    sp.TenSp.Contains(searchTerm));
            }

            // Lọc theo thương hiệu
            if (!string.IsNullOrEmpty(selectedBrand))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.MaThuongHieu == selectedBrand);
            }
            //Lọc theo màu sắc
            if (!string.IsNullOrEmpty(selectedColor) && !selectedColor.Contains("all"))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.Chitietmausacs.Any(p => selectedColor.Contains(p.MaMau.ToString())));
            }
            // Lọc theo kích thước
            if (!string.IsNullOrEmpty(selectedSize) && !selectedSize.Contains("all"))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.Chitietkichthuocs.Any(p => selectedSize.Contains(p.MaKichThuoc.ToString())));
            }
            // Lọc theo khoảng giá
            if (!string.IsNullOrEmpty(priceRange))
            {
                switch (priceRange)
                {
                    case "100000-10000000":
                        sanPhamQuery = sanPhamQuery.Where(sp => sp.DonGiaBan >= 100000 && sp.DonGiaBan <= 10000000);
                        break;
                    case "10000000-20000000":
                        sanPhamQuery = sanPhamQuery.Where(sp => sp.DonGiaBan >= 10000000 && sp.DonGiaBan <= 20000000);
                        break;
                    case "20000000-30000000":
                        sanPhamQuery = sanPhamQuery.Where(sp => sp.DonGiaBan >= 20000000 && sp.DonGiaBan <= 30000000);
                        break;
                    case "30000000-40000000":
                        sanPhamQuery = sanPhamQuery.Where(sp => sp.DonGiaBan >= 30000000 && sp.DonGiaBan <= 40000000);
                        break;
                    case "40000000-50000000":
                        sanPhamQuery = sanPhamQuery.Where(sp => sp.DonGiaBan >= 40000000 && sp.DonGiaBan <= 50000000);
                        break;
                    default:
                        sanPhamQuery = sanPhamQuery;
                        break;
                }
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
                    .Include(s => s.CtComBos)
                    .ThenInclude(s => s.MaComBoNavigation)
                    .ThenInclude(combo => combo.AnhComBos)
                .FirstOrDefaultAsync(m => m.MaSp == id);

            if (sanPham == null)
            {
                return NotFound();
            }
            //
            sanPham.Rating = sanPham.BinhLuans.Any() ? sanPham.BinhLuans.Average(p => p.Rating) : 0;
            var sanPhamTuongTu = _context.Sanphams.Where(p => p.MaThuongHieu == sanPham.MaThuongHieu && p.MaSp != sanPham.MaSp && p.IsDelete == false  )
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
        public async Task<IActionResult> DetailCombo(int? idcombo)
        {
            if (idcombo == null || _context.ComBos == null)
            {
                return NotFound();
            }
            var combo = await _context.ComBos
                    .Include(s => s.CtComBos)
                        .ThenInclude(sp => sp.MaSpNavigation)
                    .Include(combo => combo.AnhComBos)
                .FirstOrDefaultAsync(m => m.MaComBo == idcombo);

            if (combo == null)
            {
                return NotFound();
            }
            var comBoTuongTu = _context.ComBos.Where(p => p.MaComBo == combo.MaComBo && p.MaComBo != combo.MaComBo)
                    .Include(s => s.CtComBos)
                    .Include(combo => combo.AnhComBos)
                .ToList();
            ViewBag.comBoTuongTu = comBoTuongTu;
            var combos = new List<ComBo> { combo };
            return View(combos);
        }
    }
}

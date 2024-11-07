using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using X.PagedList;
using X.PagedList.Extensions;
using System.Linq;

namespace ASMCshrp4_12345.Controllers
{
    public class CuaHangController : Controller
    {
        private readonly Csharp4Context _context;
        public CuaHangController(Csharp4Context context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, int pageSize = 6, string sortOrder = "", string selectedBrand = null, string[] selectedColors = null, string[] selectedSizes = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            var sanPhamQuery = _context.Sanphams.Where(p => p.IsDelete == false)
                .Include(sp => sp.Hinhanhs)
                .Include(p => p.Chitietchatlieus)
                .Include(a => a.Chitietkichthuocs)
                .Include(b => b.Chitietmausacs)
                .AsQueryable();

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
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPham == null)
            {
                return NotFound();
            }
            // Bọc sản phẩm vào một danh sách
            var sanPhams = new List<Sanpham> { sanPham };
            return View(sanPhams);
        }

    }
}

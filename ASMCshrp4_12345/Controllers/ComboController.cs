using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static ASMCshrp4_12345.ViewModels.SanPhamComBoViewModel;

namespace ASMCshrp4_12345.Controllers
{
    public class ComboController : Controller
    {
        private readonly Csharp4Context _context;
        public ComboController(Csharp4Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var combos = await _context.ComBos.ToListAsync();
            return View(combos);
        }

        // Thêm Combo (GET)
        public IActionResult Create()
        {
            var viewModel = new ComboViewModel
            {
                SanPhamList = _context.Sanphams
                    .Select(sp => new SanPhamComBoViewModel
                    {
                        MaSp = sp.MaSp,
                        TenSp = sp.TenSp,
                        GiaBan = sp.DonGiaBan,
                        IsSelected = false,
                        SoLuong = 0
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ComboViewModel model, string SanPhamList)
        {
            if (ModelState.IsValid)
            {
                // Deserialize JSON thành danh sách sản phẩm
                if (!string.IsNullOrEmpty(SanPhamList))
                {
                    model.SanPhamList = JsonConvert.DeserializeObject<List<SanPhamComBoViewModel>>(SanPhamList);
                }

                // Kiểm tra danh sách sản phẩm
                if (model.SanPhamList == null || !model.SanPhamList.Any())
                {
                    ModelState.AddModelError("", "Danh sách sản phẩm không được để trống.");
                    return View(model);
                }

                // Lưu combo vào cơ sở dữ liệu
                // Giả sử bạn có một thực thể Combo và ChiTietCombo
                var combo = new ComBo
                {
                    TenComBo = model.TenComBo,
                    SoLuong = model.SoLuong,
                    DonGia = model.DonGia
                };

                _context.ComBos.Add(combo);
                _context.SaveChanges();

                foreach (var sp in model.SanPhamList)
                {
                    var chiTiet = new CtComBo
                    {
                        MaComBo = combo.MaComBo, // ID của combo vừa lưu
                        MaSp = sp.MaSp,
                        SoLuong = sp.SoLuong,
                        DonGia = sp.GiaBan
                    };
                    _context.CtComBos.Add(chiTiet);
                }
                _context.SaveChanges();

                return RedirectToAction("Index"); // Quay lại danh sách combo
            }

            return View(model);
        }


        // Sửa ComBo (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var combo = await _context.ComBos.FindAsync(id);
            if (combo == null)
            {
                return NotFound();
            }
            return View(combo);
        }

        // Sửa ComBo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ComBo combo)
        {
            if (id != combo.MaComBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ComBos.Any(e => e.MaComBo == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(combo);
        }
        public async Task<IActionResult> Details(int id)
        {
            var combo = await _context.ComBos
                .Include(c => c.CtComBos)
                .ThenInclude(ct => ct.MaSpNavigation)
                .FirstOrDefaultAsync(c => c.MaComBo == id);

            if (combo == null)
            {
                return NotFound();
            }

            var viewModel = new ComboDetailViewModel
            {
                MaComBo = combo.MaComBo,
                TenComBo = combo.TenComBo,
                SoLuong = combo.SoLuong,
                DonGia = combo.DonGia,
                SanPhamList = combo.CtComBos.Select(ct => new SanPhamComBoViewModel
                {
                    MaSp = ct.MaSp,
                    TenSp = ct.MaSpNavigation?.TenSp ?? "N/A",
                    SoLuong = ct.SoLuong,
                    GiaBan = ct.DonGia
                }).ToList()
            };

            return PartialView("_DetailPartial", viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var combo = await _context.ComBos.FindAsync(id);
            if (combo == null)
            {
                return NotFound();
            }

            // Nếu tìm thấy combo, chuyển sang xóa trực tiếp
            var ctComBoItems = _context.CtComBos.Where(p => p.MaComBo == id);
            _context.CtComBos.RemoveRange(ctComBoItems); // Xóa các item liên quan trong CtComBo
            _context.ComBos.Remove(combo); // Xóa combo chính
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // Sau khi xóa, chuyển đến trang danh sách
        }
    }
}
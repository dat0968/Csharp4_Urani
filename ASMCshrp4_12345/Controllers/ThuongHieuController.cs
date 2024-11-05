using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASMCshrp4_12345.Controllers
{
    public class ThuongHieuController : Controller
    {
        private readonly Csharp4Context _context;
        public ThuongHieuController(Csharp4Context context)
        {
            _context = context;
        }
        public IActionResult Index(string searchString, string sortOrder, bool showDeleted = false)
        {
            ViewBag.ShowDeleted = showDeleted;

            var thuonghieus = _context.Thuonghieus.AsQueryable();

            if (!showDeleted)
            {
                thuonghieus = thuonghieus.Where(n => !n.IsDelete);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                thuonghieus = thuonghieus.Where(n => n.TenThuongHieu.Contains(searchString) || n.MaThuongHieu.Contains(searchString));
            }
            if (sortOrder == "AZ")
            {
                thuonghieus = thuonghieus.OrderBy(n => n.TenThuongHieu);
            }
            else if (sortOrder == "ZA")
            {
                thuonghieus = thuonghieus.OrderByDescending(n => n.TenThuongHieu);
            }

            return View(thuonghieus.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Thuonghieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuonghieu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(thuonghieu);
        }
        public IActionResult Edit(string id)
        {
            var thuonghieu = _context.Thuonghieus.Find(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }
            return View(thuonghieu);
        }
        [HttpPost]
        public IActionResult Edit(string id, Thuonghieu thuonghieu)
        {
            if (id!=thuonghieu.MaThuongHieu)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(thuonghieu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(thuonghieu);
        }
        public IActionResult Delete(string id)
        {
            var thuonghieu = _context.Thuonghieus.Find(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }
            return View(thuonghieu);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var thuonghieu = _context.Thuonghieus.Find(id);
            if (thuonghieu != null)
            {
                thuonghieu.IsDelete = true;
                _context.Update(thuonghieu);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

﻿using ASMCshrp4_12345.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ASMCshrp4_12345.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly Csharp4Context _context;
        public NhaCungCapController(Csharp4Context context)
        {
            _context = context;
        }
        public IActionResult Index(string searchString, string sortOrder, bool showDeleted = false)
        {
            ViewBag.ShowDeleted = showDeleted;

            var nhacungcaps = _context.Nhacungcaps.Where(p => p.IsDelete == false).AsQueryable();

            if (!showDeleted)
            {
                nhacungcaps = nhacungcaps.Where(n => !n.IsDelete);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                nhacungcaps = nhacungcaps.Where(n => n.TenNhaCc.Contains(searchString) || n.MaNhaCc.Contains(searchString));
            }

            // Sắp xếp theo lựa chọn
            if (sortOrder == "AZ")
            {
                nhacungcaps = nhacungcaps.OrderBy(n => n.TenNhaCc);
            }
            else if (sortOrder == "ZA")
            {
                nhacungcaps = nhacungcaps.OrderByDescending(n => n.TenNhaCc);
            }

            return View(nhacungcaps.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Nhacungcap model)
        {
            var nhacungcap = new Nhacungcap();
            var lastSupplier = _context.Nhacungcaps.OrderByDescending(p => p.MaNhaCc).FirstOrDefault();
            if (lastSupplier != null)
            {
                string lastSupplierID = lastSupplier.MaNhaCc;
                if (lastSupplierID.Length > 3 && lastSupplierID.StartsWith("NCC"))
                {
                    int number = int.Parse(lastSupplierID.Substring(3));
                    nhacungcap.MaNhaCc = "NCC" + (number + 1).ToString("D2");
                }
                else
                {
                    nhacungcap.MaNhaCc = "NCC01";
                }
            }
            nhacungcap.TenNhaCc = model.TenNhaCc;
            nhacungcap.DiaChi = model.DiaChi;
            nhacungcap.Email = model.Email;
            nhacungcap.Sdt = model.Sdt;
            _context.Add(nhacungcap);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Thêm nhà cung cấp thành công!";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(string id)
        {
            var nhacungcap = _context.Nhacungcaps.Find(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }
        [HttpPost]
        public IActionResult Edit(string id, Nhacungcap nhacungcap)
        {
            if (id!=nhacungcap.MaNhaCc)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(nhacungcap);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Cập nhật thông tin nhà cung cấp thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(nhacungcap);
        }
        public IActionResult Delete(string id)
        {
            var nhacungcap = _context.Nhacungcaps.Find(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var nhacungcap = _context.Nhacungcaps.Find(id);
            if (nhacungcap != null)
            {
                nhacungcap.IsDelete = true;
                _context.Update(nhacungcap);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Xóa nhà cung cấp thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    
    }
}

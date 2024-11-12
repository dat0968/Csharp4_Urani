using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASMCshrp4_12345.Models;
using X.PagedList.Extensions;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;
using ASMCshrp4_12345.ViewModels;

namespace ASMCshrp4_12345.Controllers
{
    
    public class KhachhangsController : Controller
    {
        private readonly Csharp4Context _context;

        public KhachhangsController(Csharp4Context context)
        {
            _context = context;
        }

        // GET: Khachhangs
        public async Task<IActionResult> Index(string? keywords, string? filterGender, string? statusFilter, string? sortOrder, int page = 1)
        {
            var csharp4Context = _context.Khachhangs.Where(p => p.IsDelete == false);
            page = page < 1 ? 1 : page;
            int pagesize = 10;

            ViewData["CurrentKeywords"] = keywords;
            ViewData["CurrentGenderFilter"] = filterGender;
            ViewData["CurrentStatusFilter"] = statusFilter;
            ViewData["CurrentSortOrder"] = sortOrder;

            if (keywords != null)
            {
                csharp4Context = csharp4Context.Where(p => p.MaKh.Contains(keywords) || p.HoTen.Contains(keywords));
            }

            if (filterGender != null)
            {
                csharp4Context = csharp4Context.Where(p => p.GioiTinh.Contains(filterGender));
            }

            if (statusFilter != null)
            {
                csharp4Context = csharp4Context.Where(p => p.TinhTrang.Contains(statusFilter));
            }

            switch (sortOrder)
            {
                case "name_asc":
                    csharp4Context = csharp4Context.OrderBy(p => p.HoTen);
                    break;
                case "name_desc":
                    csharp4Context = csharp4Context.OrderByDescending(p => p.HoTen);
                    break;
                default:
                    csharp4Context = csharp4Context.OrderBy(p => p.MaKh);
                    break;
            }
            var khachhang = csharp4Context.ToPagedList(page, pagesize);
            return View(khachhang);
        }

        // GET: Khachhangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .FirstOrDefaultAsync(m => m.MaKh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }
        [HttpGet]
        public JsonResult checkCCCD(string cccd)
        {
            var exists = _context.Khachhangs.Any(p => p.Cccd.ToString() == cccd);
            return Json(exists);
        }
        [HttpGet]
        public JsonResult checkSDT(string sdt)
        {
            var exists = _context.Khachhangs.Any(p => p.Sdt.ToString() == sdt);
            return Json(exists);
        }
        [HttpGet]
        public JsonResult checkEmail(string email)
        {
            var exists = _context.Khachhangs.Any(p => p.Email.ToString() == email);
            return Json(exists);
        }
        [HttpGet]
        public JsonResult checkTenTaiKhoan(string tentaikhoan)
        {
            var exists = _context.Khachhangs.Any(p => p.TenTaiKhoan.ToString() == tentaikhoan);
            return Json(exists);
        }
        // GET: Khachhangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( KhachHangViewModel model)
        {

            var khachhang = new Khachhang();
            var lastCusmer = _context.Khachhangs.OrderByDescending(p => p.MaKh).FirstOrDefault();
            if (lastCusmer != null)
            {
                string lastCustomerID = lastCusmer.MaKh;
                int number = int.Parse(lastCustomerID.Substring(2));
                khachhang.MaKh = "KH" + (number + 1).ToString("D3");
            }
            else
            {
                khachhang.MaKh = "KH001";
            }
            if(model.fileAvatar != null && model.fileAvatar.Length > 0)
            {
                string folderPath = Path.Combine("wwwroot/HinhAnh/KhachHang");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string filePath = Path.Combine(folderPath, model.fileAvatar.FileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.fileAvatar.CopyToAsync(stream);
                }
                khachhang.Avatar = model.fileAvatar.FileName;
                khachhang.HoTen = model.HoTen;
                khachhang.GioiTinh = model.GioiTinh;
                khachhang.NgaySinh = model.NgaySinh;
                khachhang.DiaChi = model.DiaChi;
                khachhang.Cccd = model.Cccd;
                khachhang.Sdt = model.Sdt;
                khachhang.Email = model.Email;
                khachhang.TenTaiKhoan = model.TenTaiKhoan;
                khachhang.MatKhau = model.MatKhau;
                khachhang.TinhTrang = model.TinhTrang;
                khachhang.IsDelete = false;
            }
            _context.Add(khachhang);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Thêm khách hàng thành công!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Khachhangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            var editCustomer = new KhachHangViewModel
            {
                MaKh = khachhang.MaKh,
                HoTen = khachhang.HoTen,
                Avatar = khachhang.Avatar,
                GioiTinh = khachhang.GioiTinh,
                NgaySinh = khachhang.NgaySinh,
                DiaChi = khachhang.DiaChi,
                Cccd = khachhang.Cccd,
                Sdt = khachhang.Sdt,
                Email = khachhang.Email,
                TenTaiKhoan = khachhang.TenTaiKhoan,
                MatKhau = khachhang.MatKhau,
                TinhTrang = khachhang.TinhTrang,
                IsDelete = khachhang.IsDelete,
            };
            return View(editCustomer);
        }

        // POST: Khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, KhachHangViewModel model)
        {
            var khachhang = await _context.Khachhangs.AsNoTracking().FirstOrDefaultAsync(p => p.MaKh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            try
            {
                if (model.fileAvatar != null && model.fileAvatar.Length > 0)
                {
                    string folderPath = Path.Combine("wwwroot/HinhAnh/KhachHang");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string filePath = Path.Combine(folderPath, model.fileAvatar.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.fileAvatar.CopyToAsync(stream);
                    }
                    khachhang.Avatar = model.fileAvatar.FileName;
                }
               
                TempData["SuccessMessage"] = "Cập nhật thông tin khách hàng thành công!";
                _context.Update(khachhang);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachhangExists(khachhang.MaKh))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }


        // POST: Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang != null)
            {
                khachhang.IsDelete = true;
                khachhang.TenTaiKhoan = null;
                khachhang.Cccd = null;
                khachhang.Email = "";
            }
            _context.Update(khachhang);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Xóa thông tin khách hàng thành công!";
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(string id)
        {
            return _context.Khachhangs.Any(e => e.MaKh == id);
        }


        public IActionResult ExportToExcel()
        {
            var khachhangs = _context.Khachhangs.Where(kh => !kh.IsDelete).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("DanhSachKhachHang");
                var currentRow = 1;


                worksheet.Cell(currentRow, 1).Value = "MÃ KHÁCH HÀNG";
                worksheet.Cell(currentRow, 2).Value = "HỌ TÊN";
                worksheet.Cell(currentRow, 3).Value = "TÊN TÀI KHOẢN";
                worksheet.Cell(currentRow, 4).Value = "EMAIL";
                worksheet.Cell(currentRow, 5).Value = "CCCD";
                worksheet.Cell(currentRow, 6).Value = "SỐ ĐIỆN THOẠI";
                worksheet.Cell(currentRow, 7).Value = "NGÀY SINH";
                worksheet.Cell(currentRow, 8).Value = "ĐỊA CHỈ";
                worksheet.Cell(currentRow, 9).Value = "GIỚI TÍNH";
                worksheet.Cell(currentRow, 10).Value = "TÌNH TRẠNG";


                foreach (var kh in khachhangs)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = kh.MaKh;
                    worksheet.Cell(currentRow, 2).Value = kh.HoTen;
                    worksheet.Cell(currentRow, 3).Value = kh.TenTaiKhoan;
                    worksheet.Cell(currentRow, 4).Value = kh.Email;
                    worksheet.Cell(currentRow, 5).Value = kh.Cccd;
                    worksheet.Cell(currentRow, 6).Value = kh.Sdt;
                    if (kh.NgaySinh.HasValue)
                    {
                        worksheet.Cell(currentRow, 7).Value = kh.NgaySinh.Value.ToDateTime(new TimeOnly());
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 7).Value = string.Empty;
                    }
                    worksheet.Cell(currentRow, 8).Value = kh.DiaChi;
                    worksheet.Cell(currentRow, 9).Value = kh.GioiTinh;
                    worksheet.Cell(currentRow, 10).Value = kh.TinhTrang;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DanhSachKhachHang.xlsx");
                }
            }
        }

    }
}

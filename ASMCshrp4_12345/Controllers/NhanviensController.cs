using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASMCshrp4_12345.Models;
using X.PagedList;
using X.PagedList.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ClosedXML.Excel;
namespace ASMCshrp4_12345.Controllers
{
    public class NhanviensController : Controller
    {
        private readonly Csharp4Context _context;

        public NhanviensController(Csharp4Context context)
        {
            _context = context;
        }

        // GET: Nhanviens
        public async Task<IActionResult> Index(string? keywords, string? roleFilter, string? statusFilter, string? sortOrder, int page = 1)
        {
            var csharp4Context = _context.Nhanviens.Where(p => p.IsDelete == false);
            page = page < 1 ? 1 : page;
            int pagesize = 10;
            ViewData["CurrentKeywords"] = keywords;
            ViewData["CurrentRoleFilter"] = roleFilter;
            ViewData["CurrentStatusFilter"] = statusFilter;
            ViewData["CurrentSortOrder"] = sortOrder;
            if (keywords != null)
            {
                csharp4Context = csharp4Context.Where(p => p.MaNv.Contains(keywords) || p.HoTen.Contains(keywords));
            }
            if (roleFilter != null)
            {
                csharp4Context = csharp4Context.Where(p => p.VaiTro.Contains(roleFilter));
            }
            if (statusFilter != null)
            {
                csharp4Context = csharp4Context.Where(p => p.TinhTrang.Contains(statusFilter));
            }
            switch (sortOrder)
            {
                case "date_asc":
                    csharp4Context = csharp4Context.OrderBy(p => p.NgayVaoLam);
                    break;
                case "date_desc":
                    csharp4Context = csharp4Context.OrderByDescending(p => p.NgayVaoLam);
                    break;
                default:
                    csharp4Context = csharp4Context.OrderBy(p => p.MaNv);
                    break;
            }
            var nhanvien = csharp4Context.ToPagedList(page, pagesize);
            return View(nhanvien);
        }

        // GET: Nhanviens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        [HttpGet]
        public JsonResult CheckUsernameExists(string username)
        {
            var exists = _context.Nhanviens.Any(nv => nv.TenTaiKhoan == username);
            return Json(exists);
        }

        [HttpGet]
        public JsonResult CheckCccdExists(string cccd)
        {
            var exists = _context.Nhanviens.Any(nv => nv.Cccd.ToString() == cccd);
            return Json(exists);
        }

        [HttpGet]
        public JsonResult CheckEmailExists(string email)
        {
            var exists = _context.Nhanviens.Any(nv => nv.Email.ToString() == email);
            return Json(exists);
        }

        [HttpGet]
        public JsonResult CheckSDTExists(string sdt)
        {
            var exists = _context.Nhanviens.Any(nv => nv.Sdt.ToString() == sdt);
            return Json(exists);
        }

        // GET: Nhanviens/Create
        public IActionResult Create()
        {
            var model = new Nhanvien()
            {
                NgayVaoLam = DateOnly.FromDateTime(DateTime.Now) // Lấy ngày hiện tại
            };
            return View(model);
        }

        // POST: Nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nhanvien nhanvien)
        {
            var lastStaff = _context.Nhanviens.OrderByDescending(m => m.MaNv).FirstOrDefault();
            if (lastStaff != null)
            {
                string lastStaffID = lastStaff.MaNv;
                int number = int.Parse(lastStaffID.Substring(2));
                nhanvien.MaNv = "NV" + (number + 1).ToString("D3");
            }
            else
            {
                nhanvien.MaNv = "NV001";
            }
            if (nhanvien.fileAvatar != null && nhanvien.fileAvatar.Length > 0)
            {
                var folderPath = Path.Combine("wwwroot/HinhAnh/NhanVien");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var filePath = Path.Combine(folderPath, nhanvien.fileAvatar.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await nhanvien.fileAvatar.CopyToAsync(stream);
                }
                nhanvien.Avatar = nhanvien.fileAvatar.FileName;
            }

            nhanvien.IsDelete = false;
            _context.Add(nhanvien);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Thêm nhân viên thành công!"; 
            return RedirectToAction("Index");


        }

        // GET: Nhanviens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Nhanvien nhanvien)
        {


            if (id != nhanvien.MaNv)
            {
                return NotFound();
            }

            try
            {
                var updateStaff = await _context.Nhanviens.AsNoTracking().FirstOrDefaultAsync(n => n.MaNv == id);
                if (nhanvien.fileAvatar != null && nhanvien.fileAvatar.Length > 0)
                {


                    var folderPath = Path.Combine("wwwroot/HinhAnh/NhanVien", nhanvien.fileAvatar.FileName);
                    using (var stream = new FileStream(folderPath, FileMode.Create))
                    {
                        await nhanvien.fileAvatar.CopyToAsync(stream);
                    }
                    nhanvien.Avatar = nhanvien.fileAvatar.FileName;
                }
                else
                {
                    nhanvien.Avatar = updateStaff.Avatar;
                }
                TempData["SuccessMessage"] = "Cập nhật thông tin nhân viên thành công!";
                _context.Update(nhanvien);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanvienExists(nhanvien.MaNv))
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


        // POST: Nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null)
            {
                nhanvien.IsDelete = true;
            }
            _context.Update(nhanvien);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Xóa thông tin nhân viên thành công!";
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
            return _context.Nhanviens.Any(e => e.MaNv == id);
        }


        public IActionResult ExportToExcel()
        {
            var nhanviens = _context.Nhanviens.Where(nv => !nv.IsDelete).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("DanhSachNhanVien");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "MÃ NHÂN VIÊN";
                worksheet.Cell(currentRow, 2).Value = "TÊN NHÂN VIÊN";
                worksheet.Cell(currentRow, 3).Value = "TÊN TÀI KHOẢN";
                worksheet.Cell(currentRow, 4).Value = "EMAIL";
                worksheet.Cell(currentRow, 5).Value = "CCCD";
                worksheet.Cell(currentRow, 6).Value = "SỐ ĐIỆN THOẠI";
                worksheet.Cell(currentRow, 7).Value = "NGÀY SINH";
                worksheet.Cell(currentRow, 8).Value = "ĐỊA CHỈ";
                worksheet.Cell(currentRow, 9).Value = "LƯƠNG";
                worksheet.Cell(currentRow, 10).Value = "NGÀY VÀO LÀM";
                worksheet.Cell(currentRow, 11).Value = "VAI TRÒ";
                worksheet.Cell(currentRow, 12).Value = "TÌNH TRẠNG";


                foreach (var nv in nhanviens)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = nv.MaNv;
                    worksheet.Cell(currentRow, 2).Value = nv.HoTen;
                    worksheet.Cell(currentRow, 3).Value = nv.TenTaiKhoan;
                    worksheet.Cell(currentRow, 4).Value = nv.Email;
                    worksheet.Cell(currentRow, 5).Value = nv.Cccd;
                    worksheet.Cell(currentRow, 6).Value = nv.Sdt;
                    if (nv.NgaySinh.HasValue)
                    {
                        worksheet.Cell(currentRow, 7).Value = nv.NgaySinh.Value.ToDateTime(new TimeOnly());
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 7).Value = string.Empty; 
                    }
                    worksheet.Cell(currentRow, 8).Value = nv.DiaChi;
                    worksheet.Cell(currentRow, 9).Value = nv.Luong;
                    worksheet.Cell(currentRow, 10).Value = nv.NgayVaoLam.ToDateTime(new TimeOnly());
                    worksheet.Cell(currentRow, 11).Value = nv.VaiTro;
                    worksheet.Cell(currentRow, 12).Value = nv.TinhTrang;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DanhSachNhanVien.xlsx");
                }
            }
        }


    }
}

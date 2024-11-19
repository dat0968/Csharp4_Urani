using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASMCshrp4_12345.Models;
using X.PagedList.Extensions;
using ClosedXML.Excel;
using System.Security.Claims;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace ASMCshrp4_12345.Controllers
{
    public class HoadonsController : Controller
    {
        private readonly Csharp4Context _context;

        public HoadonsController(Csharp4Context context)
        {
            _context = context;
        }

        // GET: Hoadons
        public async Task<IActionResult> Index(int? page, string filterPaymentMethod, string statusFilter, string sortOrder)
        {
            var hoadonsQuery = _context.Hoadons.AsQueryable();

            if (!string.IsNullOrEmpty(filterPaymentMethod))
            {
                hoadonsQuery = hoadonsQuery.Where(hd => hd.Httt == filterPaymentMethod);
                ViewData["CurrentPaymentFilter"] = filterPaymentMethod;
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                hoadonsQuery = hoadonsQuery.Where(hd => hd.TinhTrang == statusFilter);
                ViewData["CurrentStatusFilter"] = statusFilter;
            }

            switch (sortOrder)
            {
                case "name_asc":
                    hoadonsQuery = hoadonsQuery.OrderBy(hd => hd.Hoten);
                    break;
                case "name_desc":
                    hoadonsQuery = hoadonsQuery.OrderByDescending(hd => hd.Hoten);
                    break;
                default:
                    break;
            }

            ViewData["CurrentSortOrder"] = sortOrder;

            var hoadons = await hoadonsQuery.ToListAsync();
            if (hoadons == null || !hoadons.Any())
            {
                ViewData["Message"] = "Không có dữ liệu để hiển thị.";
            }

            return View(hoadons.ToPagedList(page ?? 1, 10));
        }

        // GET: Hoadons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .Include(h => h.Chitiethoadons)
                    .ThenInclude(h => h.MaSpNavigation)
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        

        // GET: Hoadons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.Khachhangs, "MaKh", "MaKh", hoadon.MaKh);
            ViewData["MaNv"] = new SelectList(_context.Nhanviens, "MaNv", "MaNv", hoadon.MaNv);
            return View(hoadon);
        }

        // POST: Hoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Hoadon hoadon)
        {
            if (id != hoadon.MaHoaDon)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                string currentEmployeeId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var order = _context.Hoadons.AsNoTracking().FirstOrDefault(p => p.MaHoaDon == id);

                DateOnly? ngayGiaoHang = order.ThoiGianGiao;
                string currentStatus = order.TinhTrang;
                DateTime currentDate = DateTime.Now;
                DateTime? ngayGiaoHangDateTime = ngayGiaoHang.HasValue ? ngayGiaoHang.Value.ToDateTime(new TimeOnly(0, 0)) : (DateTime?)null;
                if (ngayGiaoHangDateTime.HasValue)
                {
                    
                    var daysDifference = (currentDate - ngayGiaoHangDateTime.Value).TotalDays;

                    
                    if (hoadon.TinhTrang == "Hoàn tiền" && currentStatus == "Đã thanh toán")
                    {
                        if (daysDifference > 3)
                        {
                            
                            TempData["ErrorMessage"] = "Trạng thái chỉ có hiệu lực với những đơn hàng 'Đã thanh toán' và thời gian hàng đã được giao tới tay người dùng không quá 3 ngày";
                            return View(hoadon);
                        }
                    }
                }
                hoadon.TinhTrang = hoadon.TinhTrang;

                if (!string.IsNullOrEmpty(currentEmployeeId))
                {
                    hoadon.MaNv = currentEmployeeId;
                }
                if(hoadon.TinhTrang == "Đã giao")
                {
                    hoadon.ThoiGianGiao = DateOnly.FromDateTime(DateTime.Now);
                }
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật thông tin đơn hàng thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.MaHoaDon))
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
            ViewData["MaKh"] = new SelectList(_context.Khachhangs, "MaKh", "MaKh", hoadon.MaKh);
            ViewData["MaNv"] = new SelectList(_context.Nhanviens, "MaNv", "MaNv", hoadon.MaNv);
            return View(hoadon);
        }

        public IActionResult ExportToExcel()
        {
            var hoadons = _context.Hoadons.ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("DanhSachHoaDon");
                var currentRow = 1;


                worksheet.Cell(currentRow, 1).Value = "MÃ HÓA ĐƠN";
                worksheet.Cell(currentRow, 2).Value = "ĐỊA CHỈ NHẬN HÀNG";
                worksheet.Cell(currentRow, 3).Value = "NGÀY TẠO";
                worksheet.Cell(currentRow, 4).Value = "HÌNH THỨC THANH TOÁN";
                worksheet.Cell(currentRow, 5).Value = "TÌNH TRẠNG";
                worksheet.Cell(currentRow, 6).Value = "MÃ NHÂN VIÊN";
                worksheet.Cell(currentRow, 7).Value = "MÃ KHÁCH HÀNG";
                worksheet.Cell(currentRow, 8).Value = "MÔ TẢ";
                worksheet.Cell(currentRow, 9).Value = "HỌ TÊN";
                worksheet.Cell(currentRow, 10).Value = "SỐ ĐIỆN THOẠI";
                worksheet.Cell(currentRow, 11).Value = "THỜI GIAN ĐẶT";
                worksheet.Cell(currentRow, 12).Value = "THỜI GIAN GIAO";


                worksheet.Range("A1:L1").Style.Font.Bold = true;
                worksheet.Range("A1:L1").Style.Fill.BackgroundColor = XLColor.LightGray;
                worksheet.Range("A1:L1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                worksheet.Columns().AdjustToContents();


                foreach (var hd in hoadons)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = hd.MaHoaDon;
                    worksheet.Cell(currentRow, 2).Value = hd.DiaChiNhanHang;
                    worksheet.Cell(currentRow, 3).Value = hd.NgayTao.ToString("dd/MM/yyyy");
                    worksheet.Cell(currentRow, 4).Value = hd.Httt;
                    worksheet.Cell(currentRow, 5).Value = hd.TinhTrang;
                    worksheet.Cell(currentRow, 6).Value = hd.MaNv;
                    worksheet.Cell(currentRow, 7).Value = hd.MaKh;
                    worksheet.Cell(currentRow, 8).Value = hd.MoTa;
                    worksheet.Cell(currentRow, 9).Value = hd.Hoten;
                    worksheet.Cell(currentRow, 10).Value = hd.Sdt;
                    worksheet.Cell(currentRow, 11).Value = hd.ThoiGianDat.ToString("dd/MM/yyyy");
                    worksheet.Cell(currentRow, 12).Value = hd.ThoiGianGiao?.ToString("dd/MM/yyyy");
                }


                worksheet.Range($"A1:L{currentRow}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Range($"A1:L{currentRow}").Style.Border.InsideBorder = XLBorderStyleValues.Thin;


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DanhSachHoaDon.xlsx");
                }
            }
        }
        private bool HoadonExists(string id)
        {
            return _context.Hoadons.Any(e => e.MaHoaDon == id);
        }
    }
}

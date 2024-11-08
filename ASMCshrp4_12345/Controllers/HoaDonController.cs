using ASMCshrp4_12345.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace ASMCshrp4_12345.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly Csharp4Context _context;

        public HoaDonController(Csharp4Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? page, string filterPaymentMethod,string statusFilter, string sortOrder)
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            return View(hoadon);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Update(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoadon);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);

            if (hoadon == null)
            {
                return NotFound();
            }

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

    }
}

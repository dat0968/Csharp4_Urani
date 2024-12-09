using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using X.PagedList;
using X.PagedList.Mvc.Core;
using X.PagedList.Extensions;
using ClosedXML;
using ClosedXML.Excel;
namespace ASMCshrp4_12345.Controllers
{
    public class SanphamsController : Controller
    {
        private readonly Csharp4Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SanphamsController(Csharp4Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Sanphams
            public async Task<IActionResult> Index(string tim, string mucgia, string sapxep, int page = 1, int pagesize = 7)
            {
            
                // vì nếu dùng where sau sẽ bị lỗi khi dùng include nên xài cái này
                IQueryable<Sanpham> csharp4Context = _context.Sanphams.Where(s => s.IsDelete == false)
                                                                        .Include(s => s.Hinhanhs)
                                                                        .Include(s => s.Chitietchatlieus)
                                                                        .Include(s => s.Chitietkichthuocs)
                                                                        .Include(s => s.Chitietmausacs)
                                                                        .Include(s => s.MaNhaCcNavigation)
                                                                        .Include(s => s.MaThuongHieuNavigation);
                ViewData["tim"] = tim;
                ViewData["mucgia"] = mucgia;
                ViewData["sapxep"] = sapxep;
                //tìm kiếm
                if (!string.IsNullOrEmpty(tim))
                {
                    csharp4Context = csharp4Context.Where(s => s.TenSp.Contains(tim)
                                                          || s.MaSp.Contains(tim)
                                                          );
                }

                // lọc theo giá
                if (!string.IsNullOrEmpty(mucgia))
                {
                    switch (mucgia)
                    {
                        case "1":
                            csharp4Context = csharp4Context.Where(s => s.DonGiaBan < 500000);
                            break;
                        case "2":
                            csharp4Context = csharp4Context.Where(s => s.DonGiaBan >= 500000 && s.DonGiaBan <= 1000000);
                            break;
                        case "3":
                            csharp4Context = csharp4Context.Where(s => s.DonGiaBan > 1000000);
                            break;
                        default:
                            csharp4Context = csharp4Context.OrderByDescending(p => p.MaSp);
                            break;
                }
            }

                // sắp xếp tăng giảm theo các mục
                csharp4Context = sapxep switch
                {
                    "tenTang" => csharp4Context.OrderBy(s => s.TenSp),
                    "tenGiam" => csharp4Context.OrderByDescending(s => s.TenSp),
                    "giaTang" => csharp4Context.OrderBy(s => s.DonGiaBan),
                    "giaGiam" => csharp4Context.OrderByDescending(s => s.DonGiaBan),
                    "ngayTang" => csharp4Context.OrderBy(s => s.NgaySanXuat),
                    "ngayGiam" => csharp4Context.OrderByDescending(s => s.NgaySanXuat),
                    _ => csharp4Context.OrderBy(s => s.MaSp) // này là cái mặc định theo tên tăng dần
                };

                // truyền qua thôi
                ViewData["tim"] = tim;
                ViewData["mucgia"] = mucgia;
                ViewData["sapxep"] = sapxep;
                var pagedResult = csharp4Context.ToPagedList(page, pagesize);
                return View(pagedResult);
            }

        // GET: Sanphams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.Hinhanhs)
                .Include(s => s.Chitietchatlieus)
                    .ThenInclude(p => p.MaChatLieuNavigation)
                .Include(s => s.Chitietkichthuocs)
                    .ThenInclude(p => p.MaKichThuocNavigation)
                .Include(s => s.Chitietmausacs)
                    .ThenInclude(p => p.MaMauNavigation)
                .Include(s => s.MaNhaCcNavigation)                   
                .Include(s => s.MaThuongHieuNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanphams/Create
        public IActionResult Create()
        {
            ViewData["MaChatLieu"] = new SelectList(_context.Chatlieus, "MaChatLieu", "TenChatLieu");
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "KichThuoc1");
            ViewData["MaMau"] = new SelectList(_context.Mausacs, "MaMau", "TenMau");
            ViewData["MaNhaCc"] = new SelectList(_context.Nhacungcaps, "MaNhaCc", "TenNhaCc");
            ViewData["MaThuongHieu"] = new SelectList(_context.Thuonghieus, "MaThuongHieu", "TenThuongHieu");
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Sanpham sanpham, string NewMaterial, string NewColor, string NewSize)
        {
            if (!ModelState.IsValid)
            {
                var lastProduct = _context.Sanphams.OrderByDescending(s => s.MaSp).FirstOrDefault();
                if (lastProduct != null)
                {
                    string lastMaSp = lastProduct.MaSp;
                    int number = int.Parse(lastMaSp.Substring(2));
                    sanpham.MaSp = "SP" + (number + 1).ToString("D3");
                }
                else
                {
                    sanpham.MaSp = "SP001";
                }
                sanpham.IsDelete = false;
                if (sanpham.HinhFile != null && sanpham.HinhFile.Length > 0)
                {
                    var folderPath = Path.Combine("wwwroot/HinhAnh/SanPham");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    var filePath = Path.Combine(folderPath, sanpham.HinhFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await sanpham.HinhFile.CopyToAsync(stream);
                    }
                    sanpham.Hinh = sanpham.HinhFile.FileName;
                }
                _context.Sanphams.Add(sanpham);
                await _context.SaveChangesAsync();
                if (sanpham.HinhAnhFiles != null && sanpham.HinhAnhFiles.Count > 0)
                {
                    var folderPath = Path.Combine("wwwroot/HinhAnh/SanPham");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    foreach (var file in sanpham.HinhAnhFiles)
                    {
                        if (file.Length > 0)
                        {
                            var filePath = Path.Combine(folderPath, file.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                            var hinhAnh = new Hinhanh
                            {
                                MaSp = sanpham.MaSp,
                                HinhAnh1 = file.FileName
                            };
                            _context.Hinhanhs.Add(hinhAnh);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                _context.Database.BeginTransaction();
                try
                {
   
                    if (!string.IsNullOrEmpty(NewMaterial))
                    {
                        var chatlieu = new Chatlieu
                        {
                            TenChatLieu = NewMaterial,
                        };
                        _context.Chatlieus.Add(chatlieu);
                        await _context.SaveChangesAsync();
                        sanpham.SelectedChatLieuIds.Add(chatlieu.MaChatLieu);
                    }
                    if (!string.IsNullOrEmpty(NewColor))
                    {
                        var mau = new Mausac { TenMau = NewColor };
                        _context.Mausacs.Add(mau);
                        await _context.SaveChangesAsync();
                        sanpham.SelectedMauIds.Add(mau.MaMau);
                    }
                    if (!string.IsNullOrEmpty(NewSize))
                    {
                        var kichThuoc = new Kichthuoc { TenKichThuoc = NewSize };
                        _context.Kichthuocs.Add(kichThuoc);
                        await _context.SaveChangesAsync();
                        sanpham.SelectedKichThuocIds.Add(kichThuoc.MaKichThuoc);
                    }
                    foreach (var chatlieuId in sanpham.SelectedChatLieuIds)
                    {
                        _context.Chitietchatlieus.Add(
                            new Chitietchatlieu
                            {
                                MaChatLieu = chatlieuId,
                                MaSp = sanpham.MaSp,
                            });
                    }
                    foreach (var mausacID in sanpham.SelectedMauIds)
                    {
                        _context.Chitietmausacs.Add(
                            new Chitietmausac
                            {
                                MaMau = mausacID,
                                MaSp = sanpham.MaSp,
                            });
                    }
                    foreach (var kichthuocID in sanpham.SelectedKichThuocIds)
                    {
                        _context.Chitietkichthuocs.Add(
                            new Chitietkichthuoc
                            {
                                MaKichThuoc = kichthuocID,
                                MaSp = sanpham.MaSp,
                            });
                    }
                    await _context.SaveChangesAsync();
                    _context.Database.CommitTransaction();
                    TempData["SuccessMessage"] = "Thêm sản phẩm thành công";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // In lỗi nếu lưu thất bại
                    _context.Database.RollbackTransaction();
                    Console.WriteLine(ex.Message + ex.InnerException?.Message ?? ex.Message);
                    return BadRequest("Có lỗi xảy ra khi thêm sản phẩm.");                   
                }
                

                
            }
            ViewData["MaChatLieu"] = new SelectList(_context.Chatlieus, "MaChatLieu", "TenChatLieu");
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "KichThuoc1");
            ViewData["MaMau"] = new SelectList(_context.Mausacs, "MaMau", "TenMau");
            ViewData["MaNhaCc"] = new SelectList(_context.Nhacungcaps, "MaNhaCc", "TenNhaCc");
            ViewData["MaThuongHieu"] = new SelectList(_context.Thuonghieus, "MaThuongHieu", "TenThuongHieu");
            return View(sanpham);
        }

        // GET: Sanphams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                   .Include(s => s.Hinhanhs)
                   .Include(s => s.Chitietchatlieus)
                   .Include(s => s.Chitietkichthuocs)
                   .Include(s => s.Chitietmausacs)
                   .Include(s => s.MaNhaCcNavigation)
                   .Include(s => s.MaThuongHieuNavigation)
                   .FirstOrDefaultAsync(s => s.MaSp == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["MaChatLieu"] = new SelectList(_context.Chatlieus, "MaChatLieu", "TenChatLieu");
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "KichThuoc1");
            ViewData["MaMau"] = new SelectList(_context.Mausacs, "MaMau", "TenMau");
            ViewData["MaNhaCc"] = new SelectList(_context.Nhacungcaps, "MaNhaCc", "TenNhaCc");
            ViewData["MaThuongHieu"] = new SelectList(_context.Thuonghieus, "MaThuongHieu", "TenThuongHieu");

            // Gán các thuộc tính hiện có của sản phẩm vào `Selected` để hiển thị chọn sẵn trong view
            sanpham.SelectedMauIds = sanpham.Chitietmausacs.Select(sm => sm.MaMau).ToList();
            sanpham.SelectedKichThuocIds = sanpham.Chitietkichthuocs.Select(sk => sk.MaKichThuoc).ToList();
            sanpham.SelectedChatLieuIds = sanpham.Chitietchatlieus.Select(sc => sc.MaChatLieu).ToList();
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Sanpham sanpham, int[] selectedImages)
        {
            if (id != sanpham.MaSp)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var existingSanPham = await _context.Sanphams.AsNoTracking().FirstOrDefaultAsync(sp => sp.MaSp == id);
                if (existingSanPham == null)
                {
                    return NotFound();
                }

                // Cập nhật thông tin sản phẩm
                existingSanPham.TenSp = sanpham.TenSp;
                existingSanPham.SoLuongBan = sanpham.SoLuongBan;
                existingSanPham.DonGiaBan = sanpham.DonGiaBan;
                //existingSanPham.MaChatLieu = sanpham.MaChatLieu;
                existingSanPham.MaNhaCc = sanpham.MaNhaCc;
                //existingSanPham.MaMau = sanpham.MaMau;
                existingSanPham.MaThuongHieu = sanpham.MaThuongHieu;
                existingSanPham.MoTa = sanpham.MoTa;
                existingSanPham.NgaySanXuat = sanpham.NgaySanXuat;
                //existingSanPham.MaKichThuoc = sanpham.MaKichThuoc;

                // Cập nhật hình ảnh chính
                if (sanpham.HinhFile != null && sanpham.HinhFile.Length > 0)
                {
                    // Logic để lưu hình ảnh chính
                    var folderPath = Path.Combine("wwwroot/HinhAnh/SanPham");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Xóa hình ảnh cũ nếu cần
                    var oldImagePath = Path.Combine(folderPath, existingSanPham.Hinh);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    // Lưu hình ảnh mới
                    var filePath = Path.Combine(folderPath, sanpham.HinhFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await sanpham.HinhFile.CopyToAsync(stream);
                    }

                    existingSanPham.Hinh = sanpham.HinhFile.FileName; // Cập nhật tên hình
                }

                // Xóa hình ảnh phụ đã chọn
                if (selectedImages != null && selectedImages.Length > 0)
                {
                    var imagesToRemove = existingSanPham.Hinhanhs.Where(h => selectedImages.Contains(h.MaHinhAnh)).ToList();
                    foreach (var image in imagesToRemove)
                    {
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "HinhAnh/SanPham", image.HinhAnh1);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath); // Xóa trong wwwroot
                        }
                        _context.Hinhanhs.Remove(image); // Xóa trong cơ sở dữ liệu
                    }
                }

                // Thêm hình ảnh phụ mới
                if (sanpham.HinhAnhFiles != null && sanpham.HinhAnhFiles.Count > 0)
                {
                    foreach (var file in sanpham.HinhAnhFiles)
                    {
                        if (file.Length > 0)
                        {
                            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "HinhAnh/SanPham");
                            string imageName = Guid.NewGuid().ToString() + "_" + file.FileName;
                            string filePath = Path.Combine(uploadDir, imageName);

                            try
                            {
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                                Hinhanh anh = new Hinhanh
                                {
                                    HinhAnh1 = imageName,
                                    MaSp = existingSanPham.MaSp,
                                };

                                existingSanPham.Hinhanhs.Add(anh);
                            }
                            catch (Exception ex)
                            {
                                ModelState.AddModelError("", "Lỗi khi tải lên hình ảnh: " + ex.Message);
                                return View(sanpham);
                            }
                        }
                    }
                }


                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {


                    await _context.Database.ExecuteSqlRawAsync("DELETE FROM Chitietchatlieus WHERE MaSp = {0}", id);
                    await _context.SaveChangesAsync();

                    await _context.Database.ExecuteSqlRawAsync("DELETE FROM Chitietmausacs WHERE MaSp = {0}", id);
                    await _context.SaveChangesAsync();

                    await _context.Database.ExecuteSqlRawAsync("DELETE FROM Chitietkichthuocs WHERE MaSp = {0}", id);
                    await _context.SaveChangesAsync();
                    foreach (var chatlieuId in sanpham.SelectedChatLieuIds)
                    {
                        var chitietChatLieu = new Chitietchatlieu { MaSp = sanpham.MaSp, MaChatLieu = chatlieuId };
                        _context.Chitietchatlieus.Add(chitietChatLieu);
                    }

                    foreach (var mauId in sanpham.SelectedMauIds)
                    {
                        var chitietMauSac = new Chitietmausac { MaSp = sanpham.MaSp, MaMau = mauId };
                        _context.Chitietmausacs.Add(chitietMauSac);
                    }

                    foreach (var kichthuocId in sanpham.SelectedKichThuocIds)
                    {
                        var chitietKichThuoc = new Chitietkichthuoc { MaSp = sanpham.MaSp, MaKichThuoc = kichthuocId };
                        _context.Chitietkichthuocs.Add(chitietKichThuoc);
                    }
                    _context.Update(existingSanPham);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    TempData["SuccessMessage"] = "Sửa sản phẩm thành công";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", "Lỗi khi lưu dữ liệu sản phẩm: " + ex.InnerException?.Message ?? ex.Message);
                }
            }

            // Nếu có lỗi, hiển thị lại form với dữ liệu đã nhập
            ViewData["MaChatLieu"] = new SelectList(_context.Chatlieus, "MaChatLieu", "TenChatLieu");
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "KichThuoc1");
            ViewData["MaMau"] = new SelectList(_context.Mausacs, "MaMau", "TenMau");
            ViewData["MaNhaCc"] = new SelectList(_context.Nhacungcaps, "MaNhaCc", "TenNhaCc");
            ViewData["MaThuongHieu"] = new SelectList(_context.Thuonghieus, "MaThuongHieu", "TenThuongHieu");
            return View(sanpham);
        }
        public  IActionResult XuatExcel()
        {
            var sanpham =  _context.Sanphams
                   .Include(s => s.Hinhanhs)
                .Include(s => s.Chitietchatlieus)
                    .ThenInclude(p => p.MaChatLieuNavigation)
                .Include(s => s.Chitietkichthuocs)
                    .ThenInclude(p => p.MaKichThuocNavigation)
                .Include(s => s.Chitietmausacs)
                    .ThenInclude(p => p.MaMauNavigation)
                .Include(s => s.MaNhaCcNavigation)
                .Include(s => s.MaThuongHieuNavigation).ToList();
            using (var workbook = new XLWorkbook())
            {
                var hanghientai = 1;
                var wooksheet = workbook.Worksheets.Add("DanhSachSanPham");
                wooksheet.Cell(hanghientai, 1).Value = "Mã Sản phẩm";
                wooksheet.Cell(hanghientai, 2).Value = "Tên Sản phẩm";
                wooksheet.Cell(hanghientai, 3).Value = "Số lượng";
                wooksheet.Cell(hanghientai, 4).Value = "Đơn giá";
                wooksheet.Cell(hanghientai, 5).Value = "Ngày sản xuất";
                wooksheet.Cell(hanghientai, 6).Value = "Thương hiệu";
                wooksheet.Cell(hanghientai, 7).Value = "Chất liệu";
                wooksheet.Cell(hanghientai, 8).Value = "Nhà cung cấp";
                wooksheet.Cell(hanghientai, 9).Value = "Kích thước";
                wooksheet.Cell(hanghientai, 10).Value = "Màu sắc";
                wooksheet.Cell(hanghientai, 11).Value = "Mô tả";
                foreach (var sp in sanpham)
                {
                    hanghientai++;
                    wooksheet.Cell(hanghientai, 1).Value = sp.MaSp;
                    wooksheet.Cell(hanghientai, 2).Value = sp.TenSp;
                    wooksheet.Cell(hanghientai, 3).Value = sp.SoLuongBan;
                    wooksheet.Cell(hanghientai, 4).Value = sp.DonGiaBan;
                    wooksheet.Cell(hanghientai, 5).Value = sp.NgaySanXuat.ToString();
                    wooksheet.Cell(hanghientai, 6).Value = sp.MaThuongHieuNavigation.TenThuongHieu;
                    wooksheet.Cell(hanghientai, 7).Value = sp.Chitietchatlieus.Select(p => p.MaChatLieuNavigation.TenChatLieu).ToString();
                    wooksheet.Cell(hanghientai, 8).Value = sp.MaNhaCcNavigation.TenNhaCc;
                    wooksheet.Cell(hanghientai, 9).Value = sp.Chitietkichthuocs.Select(p => p.MaKichThuocNavigation.TenKichThuoc).ToString();
                    wooksheet.Cell(hanghientai, 10).Value = sp.Chitietmausacs.Select(p => p.MaMauNavigation.TenMau).ToString();
                    wooksheet.Cell(hanghientai, 11).Value = sp.MoTa;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DanhSachSanPham.xlsx");
                }
            }
            
        }
   

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham != null)
            {
                sanpham.IsDelete = true; 
                _context.Sanphams.Update(sanpham);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Xóa sản phẩm thành công";
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(string id)
        {
            return _context.Sanphams.Any(e => e.MaSp == id);
        }
    }
}

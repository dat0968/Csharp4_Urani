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
        public async Task<IActionResult> Index(string tim, string mucgia, string sapxep, int page = 1, int pagesize = 5)
        {
            // vì nếu dùng where sau sẽ bị lỗi khi dùng include nên xài cái này
            IQueryable<Sanpham> csharp4Context = _context.Sanphams.Where(s => s.IsDelete == false)
                                                                  .Include(s => s.MaChatLieuNavigation)
                                                                  .Include(s => s.MaKichThuocNavigation)
                                                                  .Include(s => s.MaMauNavigation)
                                                                  .Include(s => s.MaNhaCcNavigation)
                                                                  .Include(s => s.MaThuongHieuNavigation);
                                                                  
            //tìm kiếm
            if (!string.IsNullOrEmpty(tim))
            {
                csharp4Context = csharp4Context.Where(s => s.TenSp.Contains(tim) ||
                                                      s.MaChatLieuNavigation.TenChatLieu.Contains(tim) ||
                                                      s.MaKichThuocNavigation.TenKichThuoc.Contains(tim) ||
                                                      s.MaMauNavigation.TenMau.Contains(tim) ||
                                                      s.MaNhaCcNavigation.TenNhaCc.Contains(tim) ||
                                                      s.MaThuongHieuNavigation.TenThuongHieu.Contains(tim));
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
                _ => csharp4Context.OrderBy(s => s.TenSp) // này là cái mặc định theo tên tăng dần
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
                .Include(s => s.MaChatLieuNavigation)
                .Include(s => s.MaKichThuocNavigation)
                .Include(s => s.MaMauNavigation)
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
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "TenKichThuoc");
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
        public async Task<IActionResult> Create( Sanpham sanpham)
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

                // Kiểm tra và xử lý hình ảnh
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

                try
                {
                    _context.Add(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // In lỗi nếu lưu thất bại
                    Console.WriteLine(ex.Message);
                    return BadRequest("Có lỗi xảy ra khi thêm sản phẩm.");
                }
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

                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChatLieu"] = new SelectList(_context.Chatlieus, "MaChatLieu", "TenChatLieu", sanpham.MaChatLieu);
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "TenKichThuoc", sanpham.MaKichThuoc);
            ViewData["MaMau"] = new SelectList(_context.Mausacs, "MaMau", "TenMau", sanpham.MaMau);
            ViewData["MaNhaCc"] = new SelectList(_context.Nhacungcaps, "MaNhaCc", "TenNhaCc", sanpham.MaNhaCc);
            ViewData["MaThuongHieu"] = new SelectList(_context.Thuonghieus, "MaThuongHieu", "TenThuongHieu", sanpham.MaThuongHieu);
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
                   .FirstOrDefaultAsync(s => s.MaSp == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["MaChatLieu"] = new SelectList(_context.Chatlieus, "MaChatLieu", "TenChatLieu", sanpham.MaChatLieu);
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "TenKichThuoc", sanpham.MaKichThuoc);
            ViewData["MaMau"] = new SelectList(_context.Mausacs, "MaMau", "TenMau", sanpham.MaMau);
            ViewData["MaNhaCc"] = new SelectList(_context.Nhacungcaps, "MaNhaCc", "TenNhaCc", sanpham.MaNhaCc);
            ViewData["MaThuongHieu"] = new SelectList(_context.Thuonghieus, "MaThuongHieu", "TenThuongHieu", sanpham.MaThuongHieu);
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
                var existingSanPham = await _context.Sanphams.Include(h => h.Hinhanhs).FirstOrDefaultAsync(sp => sp.MaSp == id);
                if (existingSanPham == null)
                {
                    return NotFound();
                }

                // Cập nhật thông tin sản phẩm
                existingSanPham.TenSp = sanpham.TenSp;
                existingSanPham.SoLuongBan = sanpham.SoLuongBan;
                existingSanPham.DonGiaBan = sanpham.DonGiaBan;
                existingSanPham.MaChatLieu = sanpham.MaChatLieu;
                existingSanPham.MaNhaCc = sanpham.MaNhaCc;
                existingSanPham.MaMau = sanpham.MaMau;
                existingSanPham.MaThuongHieu = sanpham.MaThuongHieu;
                existingSanPham.MoTa = sanpham.MoTa;
                existingSanPham.NgaySanXuat = sanpham.NgaySanXuat;
                existingSanPham.MaKichThuoc = sanpham.MaKichThuoc;

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

                try
                {
                    _context.Update(existingSanPham);
                    await _context.SaveChangesAsync();
                    TempData["ThanhCong"] = "Sửa sản phẩm thành công";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi lưu dữ liệu sản phẩm: " + ex.Message);
                }
            }

            // Nếu có lỗi, hiển thị lại form với dữ liệu đã nhập
            ViewData["MaChatLieu"] = new SelectList(_context.Chatlieus, "MaChatLieu", "TenChatLieu", sanpham.MaChatLieu);
            ViewData["MaKichThuoc"] = new SelectList(_context.Kichthuocs, "MaKichThuoc", "TenKichThuoc", sanpham.MaKichThuoc);
            ViewData["MaMau"] = new SelectList(_context.Mausacs, "MaMau", "TenMau", sanpham.MaMau);
            ViewData["MaNhaCc"] = new SelectList(_context.Nhacungcaps, "MaNhaCc", "TenNhaCc", sanpham.MaNhaCc);
            ViewData["MaThuongHieu"] = new SelectList(_context.Thuonghieus, "MaThuongHieu", "TenThuongHieu", sanpham.MaThuongHieu);
            return View(sanpham);
        }

        // GET: Sanphams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.MaChatLieuNavigation)
                .Include(s => s.MaKichThuocNavigation)
                .Include(s => s.MaMauNavigation)
                .Include(s => s.MaNhaCcNavigation)
                .Include(s => s.MaThuongHieuNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham != null)
            {
                sanpham.IsDelete = true; 
                _context.Sanphams.Update(sanpham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(string id)
        {
            return _context.Sanphams.Any(e => e.MaSp == id);
        }
    }
}

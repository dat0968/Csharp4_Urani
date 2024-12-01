using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASMCshrp4_12345.Controllers
{
    public class ThongTinNvController : Controller
    {
        private readonly Csharp4Context _context;

        public ThongTinNvController(Csharp4Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> EditNhanVien()
        {
            var maNv = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(maNv))
            {
                return RedirectToAction("Index", "Login");
            }

            var nhanvien = await _context.Nhanviens.FindAsync(maNv);

            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        [HttpPost]
        public async Task<IActionResult> EditNhanVien(Nhanvien nv, IFormFile Avatar)
        {
            if (!ModelState.IsValid)
            {
                var nhanvien = await _context.Nhanviens.FindAsync(nv.MaNv);

                if (nhanvien != null)
                {
                    nhanvien.HoTen = nv.HoTen;
                    nhanvien.GioiTinh = nv.GioiTinh;
                    nhanvien.NgaySinh = nv.NgaySinh;
                    nhanvien.DiaChi = nv.DiaChi;
                    nhanvien.Cccd = nv.Cccd;
                    nhanvien.Sdt = nv.Sdt;
                    nhanvien.Email = nv.Email;
                    nhanvien.NgayVaoLam = nv.NgayVaoLam;
                    nhanvien.VaiTro = nv.VaiTro;
                    nhanvien.TinhTrang = nv.TinhTrang;

                    // Xử lý hình ảnh nếu có
                    if (Avatar != null && Avatar.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Avatar.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HinhAnh/NhanVien", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Avatar.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrEmpty(nhanvien.Avatar))
                        {
                            var oldAvatarPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HinhAnh/NhanVien", nhanvien.Avatar.TrimStart('/'));
                            if (System.IO.File.Exists(oldAvatarPath))
                            {
                                System.IO.File.Delete(oldAvatarPath);
                            }
                        }
                        nhanvien.Avatar = fileName;
                    }
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
                }
                

                return RedirectToAction(nameof(EditNhanVien)); 
            }

            return View(nv);
        }
    }
}

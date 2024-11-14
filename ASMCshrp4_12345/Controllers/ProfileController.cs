using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASMCshrp4_12345.Controllers
{
    public class ProfileController : Controller
    {
        private readonly Csharp4Context _context;

        public ProfileController(Csharp4Context context)
        {
            _context = context;
        }
        public IActionResult Editprofile()
        {
            var userId = User.FindFirst("CustomerID")?.Value;
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var khachhang = _context.Khachhangs.FirstOrDefault(kh => kh.MaKh == userId);

            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editprofile(Khachhang updatedKhachhang, IFormFile Avatar)
        {
            if (ModelState.IsValid)
            {
                var khachhang = _context.Khachhangs.FirstOrDefault(kh => kh.MaKh == updatedKhachhang.MaKh);

                if (khachhang != null)
                {
                  
                    khachhang.HoTen = updatedKhachhang.HoTen;
                    khachhang.GioiTinh = updatedKhachhang.GioiTinh;
                    khachhang.NgaySinh = updatedKhachhang.NgaySinh;
                    khachhang.DiaChi = updatedKhachhang.DiaChi;
                    khachhang.Cccd = updatedKhachhang.Cccd;
                    khachhang.Sdt = updatedKhachhang.Sdt;
                    khachhang.Email = updatedKhachhang.Email;


       
                    if (Avatar != null && Avatar.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Avatar.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HinhAnh/KhachHang", fileName);

       
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            Avatar.CopyTo(stream);
                        }

                        if (!string.IsNullOrEmpty(khachhang.Avatar))
                        {
                            var oldAvatarPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HinhAnh/KhachHang", khachhang.Avatar.TrimStart('/'));
                            if (System.IO.File.Exists(oldAvatarPath))
                            {
                                System.IO.File.Delete(oldAvatarPath);
                            }
                        }


                        khachhang.Avatar = "/HinhAnh/KhachHang/" + fileName;
                    }

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không tìm thấy thông tin khách hàng!";
                }

    
                var updatedKhachHangData = _context.Khachhangs.FirstOrDefault(kh => kh.MaKh == updatedKhachhang.MaKh);
                return View(updatedKhachHangData);
            }

   
            return View(updatedKhachhang);
        }

    }
}

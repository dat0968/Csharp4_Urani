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

            var today = DateTime.Today;
            var dob = updatedKhachhang.NgaySinh?.ToDateTime(TimeOnly.MinValue); 

            if (dob.HasValue)
            {
                var age = today.Year - dob.Value.Year;

             
                if (today.Month < dob.Value.Month || (today.Month == dob.Value.Month && today.Day < dob.Value.Day))
                {
                    age--;
                }

                if (age < 16)
                {
                   
                    TempData["ErrorMessage"] = "Bạn phải trên 16 tuổi để cập nhật thông tin.";
                    return View(updatedKhachhang);  
                }
            }

            if (!string.IsNullOrEmpty(updatedKhachhang.Cccd) && !System.Text.RegularExpressions.Regex.IsMatch(updatedKhachhang.Cccd, @"^\d{9,12}$"))
            {
                TempData["ErrorMessage"] = "CCCD phải là chuỗi số, tối đa 12 chữ số.";
                return View(updatedKhachhang);
            }

            if (!string.IsNullOrEmpty(updatedKhachhang.Sdt) && !System.Text.RegularExpressions.Regex.IsMatch(updatedKhachhang.Sdt, @"^\d{10,11}$"))
            {
                TempData["ErrorMessage"] = "Số điện thoại phải là chuỗi số, tối đa 10 chữ số";
                return View(updatedKhachhang);
            }

            if (!string.IsNullOrEmpty(updatedKhachhang.Email) && !System.Text.RegularExpressions.Regex.IsMatch(updatedKhachhang.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                TempData["ErrorMessage"] = "Email không hợp lệ.";
                return View(updatedKhachhang);
            }

            if (dob.HasValue && dob.Value > today)
            {
                TempData["ErrorMessage"] = "Ngày sinh không thể là ngày trong tương lai.";
                return View(updatedKhachhang);
            }

            if (Avatar != null && Avatar.Length > 0)
            {
  
                var validFileTypes = new[] { "image/jpeg", "image/png" };
                if (!validFileTypes.Contains(Avatar.ContentType))
                {
                    TempData["ErrorMessage"] = "Chỉ cho phép tệp ảnh JPG hoặc PNG.";
                    return View(updatedKhachhang);
                }

              
                if (Avatar.Length > 5 * 1024 * 1024)
                {
                    TempData["ErrorMessage"] = "Tệp ảnh không được lớn hơn 5MB.";
                    return View(updatedKhachhang);
                }
            }

            var khachhang = _context.Khachhangs.FirstOrDefault(kh => kh.MaKh == updatedKhachhang.MaKh);
      
            if (khachhang.MaKh != null)
            {
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


                        khachhang.Avatar = fileName;
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

using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace ASMCshrp4_12345.Controllers
{
    public class AccountController : Controller
    {

        private readonly Csharp4Context _db;
      

        public AccountController( Csharp4Context db)
        {

            _db = db;
           
        }
        public IActionResult Index(string? returnURL)
        {
            ViewBag.returnURL = returnURL;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model, string? returnURL)
        {
            ViewBag.returnURL = returnURL;
            if (ModelState.IsValid)
            {
                var user = _db.Khachhangs.FirstOrDefault(u => u.TenTaiKhoan == model.TenTaiKhoan && u.MatKhau == model.MatKhau);
                //var userId = User.FindFirst("CustomerID")?.Value;

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        
                        new Claim(ClaimTypes.Name, user.TenTaiKhoan),
                        new Claim("FullName", user.HoTen),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("CustomerID", user.MaKh),
                        new Claim(ClaimTypes.Role, "User")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    TempData["SuccessMessage"] = "Đăng nhập thành công!";
                    if (Url.IsLocalUrl(returnURL))
                    {
                        return Redirect(returnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tên tài khoản hoặc mật khẩu không chính xác");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            Random random = new Random();
            int randomValue = random.Next(1000);
            string maKH = "KH" + randomValue.ToString("D3");
            if (ModelState.IsValid)
            {
                var newUser = new Khachhang
                {
                    MaKh = maKH,
                    HoTen = model.HoTen,
                    Email = model.Email,
                    TenTaiKhoan = model.TenTaiKhoan,
                    MatKhau = model.MatKhau,
                };

                _db.Khachhangs.Add(newUser);
                _db.SaveChanges();

                return RedirectToAction("Index", "Account");
            }
            else
            {
                TempData["rePass"] = "Vui lòng nhập lại đúng mật khẩu";
                return View(model);
            }
        }

        public async Task LoginGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse")
                });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            if (!result.Succeeded || result.Principal == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);

            var existingUser = _db.Khachhangs.FirstOrDefault(u => u.Email == email);
            if (existingUser == null)
            {
                Random random = new Random();
                int randomValue = random.Next(1000);
                string maKH = "KH" + randomValue.ToString("D3");
                existingUser = new Khachhang
                {
                    MaKh = maKH,
                    HoTen = name,
                    Email = email,
                };
                _db.Khachhangs.Add(existingUser);
                _db.SaveChanges();
            }
            // Đăng nhập người dùng với Cookie Authentication
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal);

            //HttpContext.Session.SetString("CustomerID", existingUser.MaKh);
            // return Json(claims);
            // Tạo danh sách các claim (bao gồm cả MaKh)
            var claims = new List<Claim>
            {
                new Claim("CustomerID", existingUser.MaKh),
                new Claim(ClaimTypes.Role, "User")
            };

            // Tạo principal với các claim mới
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Đăng nhập người dùng với Cookie Authentication
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            TempData["SuccessMessage"] = "Đăng nhập thành công!";
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuiMail(string Email)
        {
            var khachHang = _db.Khachhangs.FirstOrDefault(kh => kh.Email == Email);
            var nhanvien = _db.Nhanviens.FirstOrDefault(nv => nv.Email == Email);

            if (khachHang != null)
            {
                string MaXacNhan;
                Random rnd = new Random();
                MaXacNhan = rnd.Next(10000, 100000).ToString();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("sthe06714@gmail.com", "ezos qjgi xwet ulvt");

                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                mail.From = new MailAddress("sthe06714@gmail.com");
                mail.Subject = "Thông Báo Từ Urani Team  ";

                string logoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/NASA_logo.svg/1224px-NASA_logo.svg.png";

                mail.Body = "Kính gửi,<br>" +
                            "Chúng tôi xác nhận bạn đã sử dụng quên mật khẩu của chúng tôi<br>" +
                            "<strong><h2>Đây là mã xác nhận của bạn: " + MaXacNhan + "</h2></strong><br>" +
                            "Xin vui lòng không cung cấp cho người khác<br>" +
                            "Trân trọng.<br>" +
                            "Đội ngũ hỗ trợ Urani" + "<br><br>" +
                            "<img src='" + logoUrl + "' alt='Logo' />";
                mail.IsBodyHtml = true;
                await smtp.SendMailAsync(mail);
                return Json(new { success = true, confirmationCode = MaXacNhan, responseText = "Email đã được gửi thành công!" });
            }
            if (nhanvien != null)
            {
                string MaXacNhan;
                Random rnd = new Random();
                MaXacNhan = rnd.Next().ToString();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("sthe06714@gmail.com", "ezos qjgi xwet ulvt");

                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                mail.From = new MailAddress("sthe06714@gmail.com");
                mail.Subject = "Thông Báo Từ Urani Team  ";

                string logoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/LEGO_logo.svg/2048px-LEGO_logo.svg.png";

                mail.Body = "Kính gửi,<br>" +
                            "Chúng tôi xác nhận bạn đã sử dụng quên mật khẩu của chúng tôi<br>" +
                            "<strong><h2>Đây là mã xác nhận của bạn: " + MaXacNhan + "</h2></strong><br>" +
                            "Xin vui lòng không cung cấp cho người khác<br>" +
                            "Trân trọng.<br>" +
                            "Đội ngũ hỗ trợ Urani" + "<br><br>" +
                            "<img src='" + logoUrl + "' alt='Logo' />";
                mail.IsBodyHtml = true;
                await smtp.SendMailAsync(mail);
                return Json(new { success = true, confirmationCode = MaXacNhan, responseText = "Email đã được gửi thành công!" });
            }

            return Ok();
        }
        [HttpPost]
        public IActionResult QuenMatKhau(string Email, string NewPassword)
        {
            var khachHang = _db.Khachhangs.FirstOrDefault(s => s.Email == Email);
            var nhanvien = _db.Nhanviens.FirstOrDefault(s => s.Email == Email);
            if (khachHang != null)
            {
                khachHang.MatKhau = NewPassword;
                _db.Khachhangs.Update(khachHang);
            }
            if (nhanvien != null)
            {
                nhanvien.MatKhau = NewPassword;
                _db.Nhanviens.Update(nhanvien);
            }

            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Xóa thông tin trong session
            HttpContext.Session.Clear(); // Xóa toàn bộ session
            return RedirectToAction("Index", "Home"); 
        }
    }
}

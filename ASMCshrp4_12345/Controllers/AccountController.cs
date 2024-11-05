using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Linq;

namespace ASMCshrp4_12345.Controllers
{
    public class AccountController : Controller
    {

        private readonly Csharp4Context _db;
      

        public AccountController( Csharp4Context db)
        {

            _db = db;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Khachhangs.FirstOrDefault(u => u.TenTaiKhoan == model.TenTaiKhoan && u.MatKhau == model.MatKhau);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.TenTaiKhoan),
                        new Claim("FullName", user.HoTen),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    TempData["SuccessMessage"] = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Home");
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
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal);

            HttpContext.Session.SetString("CustomerID", existingUser.MaKh);
            // return Json(claims);
            TempData["SuccessMessage"] = "Đăng nhập thành công!";
            return RedirectToAction("Index", "Home", new { area = "" });
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

using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;

namespace ASMCshrp4_12345.Controllers
{
    public class Account_StaffController : Controller
    {
        private readonly Csharp4Context db;
        public Account_StaffController(Csharp4Context db)
        {
            this.db = db;
        }
        public IActionResult LoginStaff()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginStaff(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var staffAccount = db.Nhanviens.FirstOrDefault(p => p.TenTaiKhoan == model.TenTaiKhoan && p.MatKhau == model.MatKhau);
                if (staffAccount != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, staffAccount.TenTaiKhoan),
                        new Claim(ClaimTypes.Role, staffAccount.VaiTro),
                        new Claim(ClaimTypes.NameIdentifier, staffAccount.MaNv)

                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    TempData["SuccessMessage"] = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Redirect");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tên tài khoản hoặc mật khẩu không chính xác");
                }
            }


            return View(model);
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

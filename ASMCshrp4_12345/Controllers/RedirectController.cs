using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;

namespace ASMCshrp4_12345.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult Index()
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim != null && roleClaim.Value == "Admin")
            {
                return RedirectToAction("Index", "ThongKe");
            }
            else
            {
                return RedirectToAction("Index", "Hoadons");
            }


        }
    }
}

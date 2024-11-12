using System.Diagnostics;
using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;

namespace ASMCshrp4_12345.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly Csharp4Context _context;
        public HomeController(ILogger<HomeController> logger, Csharp4Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "ThongKe");
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("Nhân viên"))
            {
                return RedirectToAction("Index", "Hoadons");
            }
            var sanPhamNoiBat = _context.Sanphams
                            .Include(sp => sp.Hinhanhs)
                            .Where(sp => sp.SoLuongBan > 1)
                            .OrderByDescending(sp => sp.SoLuongBan)
                            .Take(8)                          
                            .ToList();
            return View(sanPhamNoiBat);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

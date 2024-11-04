using System.Diagnostics;
using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

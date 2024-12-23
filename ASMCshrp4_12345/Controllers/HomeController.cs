using System.Diagnostics;
using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.EMMA;
using ASMCshrp4_12345.ViewModels;
using AspNetCoreGeneratedDocument;

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

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "ThongKe");
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("Nh�n vi�n"))
            {
                return RedirectToAction("Index", "Hoadons");
            }

            var sanPhamNoiBat = await (from cthd in _context.Chitiethoadons
                                       join sp in _context.Sanphams on cthd.MaSp equals sp.MaSp
                                       where sp.IsDelete == false
                                       join dg in _context.Binhluans on sp.MaSp equals dg.MaSP into reviews
                                       group cthd by new { sp.TenSp, sp.MaSp, sp.DonGiaBan, sp.Hinh } into productGroup
                                       orderby productGroup.Sum(cthd => cthd.SoLuongMua) descending
                                       select new SanPhamNoiBat
                                       {
                                           MaSp = productGroup.Key.MaSp,
                                           TenSp = productGroup.Key.TenSp,
                                           GiaBan = (double)productGroup.Key.DonGiaBan,
                                           TongSoLuongMua = productGroup.Sum(pod => pod.SoLuongMua),
                                           Hinh = productGroup.Key.Hinh,
                                           sosaotrungbinh = productGroup.SelectMany(p => p.MaSpNavigation.BinhLuans).Any()
                                            ? productGroup.SelectMany(p => p.MaSpNavigation.BinhLuans).Average(r => r.Rating) : 0,
                                           socomment = productGroup.SelectMany(p => p.MaSpNavigation.BinhLuans).Count()
                                       }).ToListAsync();

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

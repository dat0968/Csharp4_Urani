using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ASMCshrp4_12345.Controllers
{
    public class PhanHoiBinhLuanController : Controller
    {
        private readonly Csharp4Context _context;
        public PhanHoiBinhLuanController(Csharp4Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult PhanHoi()
        {
            var replycoments = _context.Binhluans
                                .Include(s => s.TraLoiBinhLuans)
                                .Include(p => p.MaKHNavigation)
                                .Include(p => p.MaSPNavigation);
                                
            return View(replycoments);
        }
        [HttpPost]
        public IActionResult PhanHoi(string ReplyContent, int CommentId)
        {
            
            var newResponse = new TraLoiBinhLuan
            {
                IdBinhLuan = CommentId,
                ThoiGian = DateTime.Now,
                NoiDung = ReplyContent,
                MaNV = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value,
                isDelete = false,
            };
            _context.Traloibinhluans.Add(newResponse);
            TempData["SuccessMessage"] = "Phản hồi thành công";
            _context.SaveChanges();
            return RedirectToAction("PhanHoi", "PhanHoiBinhLuan");
        }
    }
}

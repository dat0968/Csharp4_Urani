using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASMCshrp4_12345.Controllers
{
    public class HuyDon_HoanTienController : Controller
    {
        private readonly Csharp4Context _context;

        public HuyDon_HoanTienController(Csharp4Context context)
        {
            _context = context;
        }
        public IActionResult HuyDon(string id)
        {
            var findOrder = _context.Hoadons.Find(id);
            if (findOrder != null)
            {
                findOrder.TinhTrang = "Đã hủy";
                _context.Update(findOrder);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Hủy đơn hàng thành công";
            }
            return RedirectToAction("ThongTinDonHang", "Cart");
        }
        public IActionResult HoanTien(string id)
        {
            var findOrder = _context.Hoadons.Find(id);
            if (findOrder != null)
            {
                findOrder.TinhTrang = "Hoàn tiền";
                _context.Update(findOrder);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Yêu cầu hoàn tiền thành công, cửa hàng sẽ sớm liên hệ lại với bạn";
            }
            return RedirectToAction("ThongTinDonHang", "Cart");
        }
    }
}

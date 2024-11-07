using ASMCshrp4_12345.ExtensionMethod;
using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASMCshrp4_12345.Controllers
{
    public class CartController : Controller
    {
        private readonly Csharp4Context db;
        public CartController(Csharp4Context db)
        {
            this.db = db;
        }
        const string CART_KEY = "MYCART";
        public List<CartViewModel> Cart => HttpContext.Session.Get<List<CartViewModel>>(CART_KEY) ?? new List<CartViewModel>();
        public IActionResult Index()
        {
            return View(Cart);
        }

        [HttpPost]
        public IActionResult AddToCart(string? id, int quantity = 1)
        {
            var giohang = Cart;
            var checkProduct = db.Sanphams.FirstOrDefault(p => p.MaSp == id);
            var item = giohang.FirstOrDefault(p => p.MaHh == id);
            if (checkProduct != null)
            {
                if (item != null)
                {
                    item = new CartViewModel
                    {
                        MaHh = checkProduct.MaSp,
                        TenHh = checkProduct.TenSp,
                        Hinh = checkProduct.Hinh,
                        SoLuong = quantity,
                    };
                    giohang.Add(item);
                }
                else
                {
                    item.SoLuong += quantity;
                }
                HttpContext.Session.Set(CART_KEY, item);
                TempData["AddToCartSuccess"] = "Đã thêm vào giỏ hàng";
                return RedirectToAction("Details", "CuaHang");
            }
            return RedirectToAction("Index");
        }
    }
}

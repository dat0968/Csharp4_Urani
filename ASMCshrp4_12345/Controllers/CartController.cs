using ASMCshrp4_12345.ExtensionMethod;
using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.Services;
using ASMCshrp4_12345.ViewModels;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASMCshrp4_12345.Controllers
{
    public class CartController : Controller
    {
        private readonly Csharp4Context db;
        private readonly IVnPayService _vnpayService;

        public CartController(Csharp4Context db, IVnPayService vnpayService)
        {
            this.db = db;
            _vnpayService = vnpayService;
        }
        const string CART_KEY = "MYCART";
        public List<CartViewModel> Cart => HttpContext.Session.Get<List<CartViewModel>>(CART_KEY) ?? new List<CartViewModel>();
        public IActionResult Index()
        {
             
            return View(Cart);
        }

        [HttpPost]
        public IActionResult AddToCart(string? id, string? size, string? color, string? chatlieu, int quantity = 1)
        {
            var giohang = Cart;
            var item = giohang.SingleOrDefault(p => p.MaHh.Equals(id) && (p.Mau.Equals(color) && p.KichThuoc.Equals(size) && p.ChatLieu.Equals(chatlieu)));
            var sanpham = db.Sanphams.SingleOrDefault(p => p.MaSp.Equals(id));
            if (item == null)
            {
                if (sanpham == null)
                {
                    TempData["Message"] = $"Không tìm thấy sản phẩm có mã {id}";
                    return Redirect("/404");
                }
                else
                {
                    item = new CartViewModel
                    {
                        MaHh = sanpham.MaSp,
                        TenHh = sanpham.TenSp,
                        Gia = (decimal?)sanpham.DonGiaBan,
                        Hinh = sanpham.Hinh ?? string.Empty,
                        SoLuong = quantity,
                        Mau = color,
                        KichThuoc = size,
                        ChatLieu = chatlieu,
                        SoluongAvailable = sanpham.SoLuongBan,
                    };
                    giohang.Add(item);
                }
            }
            else
            {
                item.SoLuong += quantity;
            }
            HttpContext.Session.Set(CART_KEY, giohang);
            return RedirectToAction("index");
        }

        public IActionResult RemoveCart(string id)
        {
            var giohang = Cart;
            var item = giohang.SingleOrDefault(p => p.MaHh.Equals(id));
            if (item != null)
            {
                giohang.Remove(item);
                HttpContext.Session.Set(CART_KEY, giohang);
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            if (Cart.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }
            var GetinfoCustomer = HttpContext.User.Claims.FirstOrDefault(p => p.Type == "CustomerID").Value;
            var checkFullInfo = db.Khachhangs.FirstOrDefault(p => p.MaKh == GetinfoCustomer);
            if (checkFullInfo != null)
            {
                if (checkFullInfo.DiaChi == null || checkFullInfo.DiaChi == "" || checkFullInfo.Sdt == null || checkFullInfo.Sdt == "" || checkFullInfo.Cccd == null || checkFullInfo.Cccd == "")
                {
                    TempData["ErrorMessage"] = "Thông tin của tài khoản này chưa được cập nhật đầy đủ. Vui lòng cập nhật hồ sơ";
                    return RedirectToAction("Index", "Cart");
                }
            }
            if (GetinfoCustomer != null)
            {
                ViewBag.HoTen = checkFullInfo.HoTen;
                ViewBag.Sdt = checkFullInfo.Sdt;
                ViewBag.DiaChi = checkFullInfo.DiaChi;
            }
            
            return View(Cart);
        }
        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model, string paymentMethod, string? MoTa_GuiToiDiaChiKhacfalse, string? MoTa_GuiToiDiaChiKhactrue)
        {
            var khachhang = new Khachhang();
            var GetinfoCustomer = HttpContext.User.Claims.FirstOrDefault(p => p.Type == "CustomerID").Value;
            if (string.IsNullOrEmpty(GetinfoCustomer))
            {
                TempData["ErrorMessage"] = "Không tìm thấy thông tin người dùng.";
                return RedirectToAction("Index", "Cart");
            }
            if (model.GuiToiDiaChiKhac == false)
            {
                khachhang = db.Khachhangs.FirstOrDefault(p => p.MaKh == GetinfoCustomer);
            }
            string newMaHD;
            var lastMaHD = db.Hoadons.OrderByDescending(p => p.MaHoaDon).FirstOrDefault();
            if (lastMaHD == null)
            {
                newMaHD = "HD001";
            }
            else
            {
                string lastCodeNumber = lastMaHD.MaHoaDon.Substring(2);
                int newCodeNumber = int.Parse(lastCodeNumber) + 1;
                newMaHD = "HD" + newCodeNumber.ToString("D3");
            };
            if (MoTa_GuiToiDiaChiKhacfalse != null)
            {
                model.MoTa = MoTa_GuiToiDiaChiKhacfalse;
            }
            else
            {
                model.MoTa = MoTa_GuiToiDiaChiKhactrue;
            }
            //Lưu thông tin vào session để thao tác cho chức năng VNPAY sau này
            HttpContext.Session.Set("GuiToiDiaChiKhac", model.GuiToiDiaChiKhac);
            HttpContext.Session.Set("Hoten", model.HoTen);
            HttpContext.Session.Set("DiaChi", model.DiaChi);
            HttpContext.Session.Set("Sdt", model.DienThoai);
            HttpContext.Session.Set("MoTa", model.MoTa);

            if (paymentMethod == "COD")
            {             
                var hoadon = new Hoadon
                {
                    MaHoaDon = newMaHD,
                    MaKh = GetinfoCustomer,
                    Hoten = model.HoTen ?? khachhang.HoTen,
                    DiaChiNhanHang = model.DiaChi ?? khachhang.DiaChi,
                    Sdt = model.DienThoai ?? khachhang.Sdt,
                    NgayTao = DateOnly.FromDateTime(DateTime.Now),
                    Httt = "COD",
                    TinhTrang = "Chờ xác nhận",
                    MoTa = model.MoTa,
                    ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
                };
                db.Database.BeginTransaction();
                try
                {
                    db.Add(hoadon);
                    db.SaveChanges();
                    var chitiethoadon = new List<Chitiethoadon>();

                    foreach (var item in Cart)
                    {
                        chitiethoadon.Add(new Chitiethoadon
                        {
                            MaHoaDon = hoadon.MaHoaDon,
                            MaSp = item.MaHh,
                            SoLuongMua = item.SoLuong,
                            DonGia = (double)item.Gia,
                            MauSac_ThuocTinhSuyDien = item.Mau,
                            ChatLieu_ThuocTinhSuyDien = item.ChatLieu,
                            KichThuoc_ThuocTinhSuyDien = item.KichThuoc,
                        });
                        var sanpham = db.Sanphams.Find(item.MaHh);
                        sanpham.SoLuongBan = sanpham.SoLuongBan - item.SoLuong;
                        db.Sanphams.Update(sanpham);
                        db.SaveChanges();
                    }
                    db.AddRange(chitiethoadon);
                    db.SaveChanges();
                    HttpContext.Session.Set<List<CartViewModel>>(CART_KEY, new List<CartViewModel>());
                    db.Database.CommitTransaction();
                    TempData["SuccessMessage"] = "Thanh toán thành công";

                    return RedirectToAction("Index", "CART");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Thanh toán thất bại, có lỗi xảy ra khi thực hiện thao tác";

                    db.Database.RollbackTransaction();
                    Console.WriteLine($"Error: {ex.Message}, Inner: {ex.InnerException?.Message}");
                    return BadRequest("Có lỗi xảy ra.");
                }
            }
            if (paymentMethod == "VNPAY")
            {

                var vnPaymodel = new VnPaymentRequestModel
                {
                    Amout = (double)Cart.Sum(p => p.ThanhTien),
                    CreatedDate = DateTime.Now,
                    Description = $"{model.HoTen} {model.DienThoai}",
                    FullName = model.HoTen,
                    OrderId = new Random().Next(1000, 10000),
                };
                return Redirect(_vnpayService.CreatePaymentUrl(HttpContext, vnPaymodel));
            }
            return View(Cart);
        }

        [Authorize]
        public IActionResult PaymentCallBack()
        {
            var response = _vnpayService.PaymentExecute(Request.Query);

            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["ErrorMessage"] = "Lỗi thanh toán VNPAY";
                return RedirectToAction("Index", "CART");
            }

            // Lưu đơn hàng vô database
            var khachhang = new Khachhang();
            var GetinfoCustomer = HttpContext.User.Claims.FirstOrDefault(p => p.Type == "CustomerID").Value;
            var Guitoidiachikhac = HttpContext.Session.Get<bool>("GuiToiDiaChiKhac");
            var HoTen = HttpContext.Session.Get<string>("Hoten");
            var DiaChi = HttpContext.Session.Get<string>("DiaChi");
            var Sdt = HttpContext.Session.Get<string>("Sdt");
            var MoTa = HttpContext.Session.Get<string>("MoTa");

            if (string.IsNullOrEmpty(GetinfoCustomer))
            {
                TempData["ErrorMessage"] = "Không tìm thấy thông tin người dùng.";
                return RedirectToAction("Index", "Cart");
            }
            if(Guitoidiachikhac == false)
            {
                khachhang = db.Khachhangs.FirstOrDefault(p => p.MaKh == GetinfoCustomer);
            }
            string newMaHD;
            var lastMaHD = db.Hoadons.OrderByDescending(p => p.MaHoaDon).FirstOrDefault();
            if (lastMaHD == null)
            {
                newMaHD = "HD001";
            }
            else
            {
                string lastCodeNumber = lastMaHD.MaHoaDon.Substring(2);
                int newCodeNumber = int.Parse(lastCodeNumber) + 1;
                newMaHD = "HD" + newCodeNumber.ToString("D3");
            };

            var hoadon = new Hoadon
            {
                MaHoaDon = newMaHD,
                MaKh = GetinfoCustomer,
                Hoten = HoTen ?? khachhang.HoTen,
                DiaChiNhanHang = DiaChi ?? khachhang.DiaChi,
                Sdt = Sdt ?? khachhang.Sdt,
                NgayTao = DateOnly.FromDateTime(DateTime.Now),
                Httt = "VNPAY",
                TinhTrang = "Chờ xác nhận",
                MoTa = MoTa,
                ThoiGianDat = DateOnly.FromDateTime(DateTime.Now),
            };
            db.Database.BeginTransaction();
            try
            {
                db.Add(hoadon);
                db.SaveChanges();
                var chitiethoadon = new List<Chitiethoadon>();

                foreach (var item in Cart)
                {
                    chitiethoadon.Add(new Chitiethoadon
                    {
                        MaHoaDon = hoadon.MaHoaDon,
                        MaSp = item.MaHh,
                        SoLuongMua = item.SoLuong,
                        DonGia = (double)item.Gia,
                        MauSac_ThuocTinhSuyDien = item.Mau,
                        ChatLieu_ThuocTinhSuyDien = item.ChatLieu,
                        KichThuoc_ThuocTinhSuyDien = item.KichThuoc,
                    });
                    var sanpham = db.Sanphams.Find(item.MaHh);
                    sanpham.SoLuongBan = sanpham.SoLuongBan - item.SoLuong;
                    db.Sanphams.Update(sanpham);
                    db.SaveChanges();
                }
                db.AddRange(chitiethoadon);
                db.SaveChanges();
                HttpContext.Session.Set<List<CartViewModel>>(CART_KEY, new List<CartViewModel>());
                db.Database.CommitTransaction();
                TempData["SuccessMessage"] = "Thanh toán VNPAY thành công";

                return RedirectToAction("Index", "CART");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Thanh toán thất bại, có lỗi xảy ra khi thực hiện thao tác";

                db.Database.RollbackTransaction();
                Console.WriteLine($"Error: {ex.Message}, Inner: {ex.InnerException?.Message}");
                return BadRequest("Có lỗi xảy ra.");
            }

        }

        public IActionResult ThongTinDonHang()
        {
            var maKh = HttpContext.User.Claims.FirstOrDefault(p => p.Type == "CustomerID").Value;

            if (string.IsNullOrEmpty(maKh))
            {
                // Nếu không có mã khách hàng trong Claims, có thể redirect về trang đăng nhập
                return RedirectToAction("Index", "Account");
            }

            // Lấy các đơn hàng theo các trạng thái
            var donHangsChuaXacNhan = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Chờ xác nhận").ToList();
            var donHangsDaXacNhan = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Đã xác nhận").ToList();
            var donHangsDangGiao = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Đang giao hàng").ToList();
            var donHangsDaTT = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Đã thanh toán").ToList();

            // Truyền các danh sách đơn hàng vào View
            var model = new
            {
                DonHangsChuaXacNhan = donHangsChuaXacNhan,
                DonHangsDaXacNhan = donHangsDaXacNhan,
                DonHangsDangGiao = donHangsDangGiao,
                DonHangsDaTT = donHangsDaTT
            };

            return View(model);

        }
    }
}

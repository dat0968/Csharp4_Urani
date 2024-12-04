using ASMCshrp4_12345.ExtensionMethod;
using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.Services;
using ASMCshrp4_12345.ViewModels;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tuple = System.Tuple;


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
        public IActionResult AddToCart(string? id, string? size, string? color, string? chatlieu, int quantity = 1, bool isCombo = false)
        {
            var giohang = Cart;
            var item = new CartViewModel();
            if (isCombo == true)
            {
                item = giohang.SingleOrDefault(p => p.MaHh.Equals(id));
                var combo = db.ComBos.Include(p => p.CtComBos).ThenInclude(p => p.MaSpNavigation).AsNoTracking().SingleOrDefault(p => p.MaComBo.ToString().Equals(id));
                if (item == null)
                {
                    if (combo == null)
                    {
                        TempData["Message"] = $"Không tìm thấy combo có mã {id}";
                        return Redirect("/404");
                    }
                    

                    else
                    {
                        item = new CartViewModel
                        {
                            MaHh = combo.MaComBo.ToString(),
                            TenHh = combo.TenComBo,
                            Gia = (decimal?)combo.DonGia ?? 0,
                            Hinh = combo.AnhComBos?.FirstOrDefault()?.HinhAnh ?? string.Empty,
                            SoLuong = quantity,
                            //Maus = (List<string>)combo.CtComBos.Select(p => p.TenMau),
                            //KichThuocs = (List<string>)combo.CtComBos.Select(p => p.TenKichThuoc),
                            //ChatLieus = (List<string>)combo.CtComBos.Select(p => p.TenChatLieu),
                            thuoctinh = combo.CtComBos.Select(p => Tuple.Create(p.TenMau, p.TenKichThuoc, p.TenChatLieu)).ToList(),
                            MoTa = "",
                            dsSanPhams = combo.CtComBos
                            .Select(p => new dsSanPhamViewModel
                            {
                                MaSP = p.MaSp,
                                TenSP = p.MaSpNavigation.TenSp,  
                                KichThuoc = p.TenKichThuoc,       
                                ChatLieu = p.TenChatLieu,         
                                Mau = p.TenMau                    
                            })
                            .ToList(),

                            SoluongAvailable = combo.SoLuong,
                            isCombo = true,
                        };
                        giohang.Add(item);
                    }
                }
                else
                {
                    item.SoLuong += quantity;
                    if (item.SoLuong > item.SoluongAvailable)
                    {
                        TempData["ErrorMessage"] = $"Số lượng không đủ, số lượng chỉ còn {item.SoluongAvailable}  ";
                        item.SoLuong = item.SoluongAvailable;

                    }
                    else if (item.SoLuong < 1)
                    {
                        item.SoLuong = 1;

                    }
                }
            }
            else
            {             
                item = giohang.SingleOrDefault(p => p.MaHh.Equals(id) && (p.Mau.Equals(color) && p.KichThuoc.Equals(size) && p.ChatLieu.Equals(chatlieu)));
                var sanpham = db.Sanphams.AsNoTracking().SingleOrDefault(p => p.MaSp.Equals(id));
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
                            MoTa = "",
                            SoluongAvailable = sanpham.SoLuongBan,
                        };
                        giohang.Add(item);
                    }
                }
                else
                {
                    item.SoLuong += quantity;
                    if (item.SoLuong > item.SoluongAvailable)
                    {
                        TempData["ErrorMessage"] = $"Số lượng không đủ, chỉ còn {item.SoluongAvailable} sản phẩm";
                        item.SoLuong = item.SoluongAvailable;

                    }
                    else if (item.SoLuong < 1)
                    {
                        item.SoLuong = 1;

                    }
                }
            }          
            HttpContext.Session.Set(CART_KEY, giohang);
            return RedirectToAction("index");
        }

        public IActionResult RemoveCart(string? id, string? chatlieu, string? kichthuoc, string? mausac)
        {
            var giohang = Cart;
            if (!string.IsNullOrEmpty(chatlieu) && !string.IsNullOrEmpty(kichthuoc) && !string.IsNullOrEmpty(mausac))
            {
                var item = giohang.SingleOrDefault(p => p.MaHh.Equals(id) && p.KichThuoc.Equals(kichthuoc) && p.Mau.Equals(mausac)); 
                giohang.Remove(item);
                HttpContext.Session.Set(CART_KEY, giohang);
            }
            else
            {
                var item = giohang.SingleOrDefault(p => p.MaHh.Equals(id));
                if(item  != null)
                {
                    giohang.Remove(item);
                    HttpContext.Session.Set(CART_KEY, giohang);
                }
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        [Authorize(Roles = "User")]
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
                        if(item.isCombo == false)
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
                            var sanpham = db.Sanphams.AsNoTracking().FirstOrDefault(p => p.MaSp == item.MaHh);
                            if (sanpham != null)
                            {
                                var attachedSanpham = db.Sanphams.Local.FirstOrDefault(p => p.MaSp == sanpham.MaSp);
                                if (attachedSanpham != null)
                                {
                                    db.Entry(attachedSanpham).State = EntityState.Detached;
                                }
                                sanpham.SoLuongBan = Math.Max(sanpham.SoLuongBan - item.SoLuong, 0);
                                db.Sanphams.Update(sanpham);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            foreach (var sp in item.dsSanPhams)
                            {
                                chitiethoadon.Add(new Chitiethoadon
                                {
                                    MaHoaDon = hoadon.MaHoaDon,
                                    MaSp = sp.MaSP,
                                    SoLuongMua = item.SoLuong,
                                    DonGia = (double)item.Gia,
                                    MauSac_ThuocTinhSuyDien = sp.Mau,
                                    ChatLieu_ThuocTinhSuyDien = sp.ChatLieu,
                                    KichThuoc_ThuocTinhSuyDien = sp.KichThuoc,
                                    MaComBo_ThuocTinhSuyDien = int.Parse(item.MaHh)
                                });                                                              
                            }
                            var combo = db.ComBos.AsNoTracking().FirstOrDefault(p => p.MaComBo.ToString().Equals(item.MaHh));
                            if (combo != null)
                            {
                                var attachedSanpham = db.ComBos.Local.FirstOrDefault(p => p.MaComBo == combo.MaComBo);
                                if (attachedSanpham != null)
                                {
                                    db.Entry(attachedSanpham).State = EntityState.Detached;
                                }

                            }
                            combo.SoLuong = Math.Max(combo.SoLuong - item.SoLuong, 0);
                            db.ComBos.Update(combo);
                            db.SaveChanges();
                        }
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
                    return BadRequest(new
                    {
                        Error = "Có lỗi xảy ra.",
                        Message = ex.Message,
                        InnerMessage = ex.InnerException?.Message
                    });
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
            if (Guitoidiachikhac == false)
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
                    if(item.isCombo == false)
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
                        var sanpham = db.Sanphams.AsNoTracking().FirstOrDefault(p => p.MaSp == item.MaHh);
                        if (sanpham != null)
                        {
                            var attachedSanpham = db.Sanphams.Local.FirstOrDefault(p => p.MaSp == sanpham.MaSp);
                            if (attachedSanpham != null)
                            {
                                db.Entry(attachedSanpham).State = EntityState.Detached;
                            }

                            sanpham.SoLuongBan = Math.Max(sanpham.SoLuongBan - item.SoLuong, 0);
                            db.Sanphams.Update(sanpham);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        foreach (var sp in item.dsSanPhams)
                        {
                            chitiethoadon.Add(new Chitiethoadon
                            {
                                MaHoaDon = hoadon.MaHoaDon,
                                MaSp = sp.MaSP,
                                SoLuongMua = item.SoLuong,
                                DonGia = (double)item.Gia,
                                MauSac_ThuocTinhSuyDien = sp.Mau,
                                ChatLieu_ThuocTinhSuyDien = sp.ChatLieu,
                                KichThuoc_ThuocTinhSuyDien = sp.KichThuoc,
                                MaComBo_ThuocTinhSuyDien = int.Parse(item.MaHh)
                            });                         
                        }
                        var combo = db.ComBos.AsNoTracking().FirstOrDefault(p => p.MaComBo.ToString().Equals(item.MaHh));
                        if (combo != null)
                        {
                            var attachedSanpham = db.ComBos.Local.FirstOrDefault(p => p.MaComBo == combo.MaComBo);
                            if (attachedSanpham != null)
                            {
                                db.Entry(attachedSanpham).State = EntityState.Detached;
                            }

                        }
                        combo.SoLuong = Math.Max(combo.SoLuong - item.SoLuong, 0);
                        db.ComBos.Update(combo);
                        db.SaveChanges();
                    }
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
                return BadRequest(new
                {
                    Error = "Có lỗi xảy ra.",
                    Message = ex.Message,
                    InnerMessage = ex.InnerException?.Message
                });
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
            var donHangsDaGiao = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Đã giao").ToList();
            var donHangsDaTT = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Đã thanh toán").ToList();
            var donHangsDaHuy = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Đã hủy").ToList();
            var donHangsHoanTien = db.Hoadons.Where(h => h.MaKh == maKh && h.TinhTrang == "Hoàn tiền").ToList();

            // Truyền các danh sách đơn hàng vào View
            var model = new
            {
                DonHangsChuaXacNhan = donHangsChuaXacNhan,
                DonHangsDaXacNhan = donHangsDaXacNhan,
                DonHangsDangGiao = donHangsDangGiao,
                DonHangsDaGiao = donHangsDaGiao,
                DonHangsDaTT = donHangsDaTT,
                DonHangsDaHuy = donHangsDaHuy,
                DonHangsHoanTien = donHangsHoanTien
            };

            return View(model);

        }
        public IActionResult ChiTietDonHang(string maHoaDon)
        {
            var donHang = db.Chitiethoadons
        .Include(h => h.MaSpNavigation)
        .Include(ct => ct.MaHoaDonNavigation)
        .Where(h => h.MaHoaDon == maHoaDon)
        .ToList();

            if (donHang == null)
            {
                // Trả về partial view với thông báo lỗi
                return PartialView("ChiTietDonHang", null);
            }

            // Trả về partial view với dữ liệu đơn hàng
            return PartialView("ChiTietDonHang", donHang);
        }
    }
}
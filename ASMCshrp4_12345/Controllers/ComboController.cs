using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static ASMCshrp4_12345.ViewModels.SanPhamComBoViewModel;

namespace ASMCshrp4_12345.Controllers
{
    public class ComboController : Controller
    {
        private readonly Csharp4Context _context;
        public ComboController(Csharp4Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var combos = await _context.ComBos.ToListAsync();
            return View(combos);
        }

        // Thêm Combo (GET)
        public async Task<IActionResult> Create()
        {
            var viewModel =  new ComboViewModel
            {
                SanPhamList = await _context.Sanphams
                    .Select(sp => new SanPhamComBoViewModel
                    {
                        MaSp = sp.MaSp,
                        TenSp = sp.TenSp,
                        GiaBan = sp.DonGiaBan,
                        IsSelected = false,
                        SoLuong = 0
                    })
                    .ToListAsync(),
                MauSacList = await _context.Mausacs
                    .Select(ct => new Chitietmausac
                    {
                        MaMau = ct.MaMau,
                        // Access TenMau from the MaMauNavigation navigation property
                        TenMau = ct.TenMau
                    })
                    .ToListAsync(),

                // Lấy kích thước cho từng sản phẩm
                KichThuocList = await _context.Kichthuocs
                    .Select(ct => new Chitietkichthuoc
                    {
                        MaKichThuoc = ct.MaKichThuoc,
                        TenKichThuoc = ct.KichThuoc1
                    })
                    .ToListAsync(),

                // Lấy chất liệu cho từng sản phẩm
                ChatLieuList = await _context.Chatlieus
                    .Select(ct => new Chitietchatlieu
                    {
                        MaChatLieu = ct.MaChatLieu,
                        TenChatLieu = ct.TenChatLieu
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ComboViewModel model, string SanPhamList)
        {
            if (!ModelState.IsValid)
            {
                // lấy dữ liệu và chuyển JSON thành mảng để render
                if (!string.IsNullOrEmpty(SanPhamList))
                {
                    model.SanPhamList = JsonConvert.DeserializeObject<List<SanPhamComBoViewModel>>(SanPhamList);
                }
                if (model.SanPhamList == null || !model.SanPhamList.Any())
                {
                    ModelState.AddModelError("", "Danh sách sản phẩm không được để trống.");
                    return  View(model);
                }
                var combo = new ComBo
                {
                    TenComBo = model.TenComBo,
                    SoLuong = model.SoLuong,
                    DonGia = model.DonGia,
                    MoTa = model.MoTa,
                };

                _context.ComBos.Add(combo);
                await _context.SaveChangesAsync();
                // Lưu danh sách ảnh
                if (model.HinhAnhList != null && model.HinhAnhList.Count > 0)
                {
                    foreach (var file in model.HinhAnhList)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                            var filePath = Path.Combine("wwwroot/HinhAnh", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            var anhCombo = new AnhComBo
                            {
                                MaComBo = combo.MaComBo,
                                HinhAnh = fileName
                            };
                            _context.AnhComBos.Add(anhCombo);
                        }
                    }
                     await _context.SaveChangesAsync();
                }
                foreach (var sp in model.SanPhamList)
                {
                    var chiTiet = new CtComBo
                    {
                        MaComBo = combo.MaComBo, 
                        MaSp = sp.MaSp,
                        SoLuong = sp.SoLuong,
                        DonGia = sp.GiaBan,
                        TenMau = sp.TenMau,       
                        TenKichThuoc = sp.TenKichThuoc, 
                        TenChatLieu = sp.TenChatLieu
                    };
                    _context.CtComBos.Add(chiTiet);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); 
            }

            return View(model);
        }

        // Sửa Combo (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var combo = await _context.ComBos
                .Include(c => c.CtComBos)
                .ThenInclude(ct => ct.MaSpNavigation)
                .Include(a => a.AnhComBos)
                .FirstOrDefaultAsync(c => c.MaComBo == id);

            var viewModel = new ComboViewModel
            {
                MaComBo = combo.MaComBo,
                TenComBo = combo.TenComBo,
                SoLuong = combo.SoLuong,
                DonGia = combo.DonGia,
                AnhComBos = combo.AnhComBos.ToList(),
                //lấy cái danh sách trong chi tiết combo
                SanPhamList = combo.CtComBos.Select(ct => new SanPhamComBoViewModel
                {
                    MaSp = ct.MaSp,
                    TenSp = ct.MaSpNavigation?.TenSp ?? "N/A",
                    SoLuong = ct.SoLuong,
                    GiaBan = ct.DonGia,
                    TenMau = ct.TenMau,
                    TenKichThuoc = ct.TenKichThuoc,
                    TenChatLieu = ct.TenChatLieu 
                }).ToList(),
                //lấy hết danh sách sản phẩm để thêm vào chi tiết combo khi sửa 
                AllSanPhamList = await _context.Sanphams.Select(sp => new SanPhamComBoViewModel
                {
                    MaSp = sp.MaSp,
                    TenSp = sp.TenSp,
                    GiaBan = sp.DonGiaBan,
                }).ToListAsync(),
                HinhAnhToDelete = combo.AnhComBos.Select(a => a.IdAnh).ToList(),

                MauSacList = await _context.Mausacs
                    .Select(ct => new Chitietmausac
                    {
                        MaMau = ct.MaMau,
                        // Access TenMau from the MaMauNavigation navigation property
                        TenMau = ct.TenMau
                    })
                    .ToListAsync(),

                // Lấy kích thước cho từng sản phẩm
                KichThuocList = await _context.Kichthuocs
                    .Select(ct => new Chitietkichthuoc
                    {
                        MaKichThuoc = ct.MaKichThuoc,
                        TenKichThuoc = ct.KichThuoc1
                    })
                    .ToListAsync(),

                // Lấy chất liệu cho từng sản phẩm
                ChatLieuList = await _context.Chatlieus
                    .Select(ct => new Chitietchatlieu
                    {
                        MaChatLieu = ct.MaChatLieu,
                        TenChatLieu = ct.TenChatLieu
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ComboViewModel model, string SanPhamList)
        {
            if (id != model.MaComBo)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                // lấy dữ liệu và chuyển JSON thành mảng để render
                if (!string.IsNullOrEmpty(SanPhamList))
                {
                    model.SanPhamList = JsonConvert.DeserializeObject<List<SanPhamComBoViewModel>>(SanPhamList);
                }
                if (model.SanPhamList == null || !model.SanPhamList.Any())
                {
                    ModelState.AddModelError("", "Danh sách sản phẩm không được để trống.");
                    return View(model);
                }
                      // Cập nhật thông tin combo
                var combo = await _context.ComBos.FindAsync(id);
                if (combo == null)
                {
                    return NotFound();
                }
                combo.TenComBo = model.TenComBo;
                combo.DonGia = model.DonGia;
                combo.SoLuong = model.SoLuong;
                combo.MoTa = model.MoTa;
                _context.Update(combo);
                if (model.HinhAnhToDelete != null && model.HinhAnhToDelete.Any())
                {
                    foreach (var imageId in model.HinhAnhToDelete)
                    {
                        var anhToDelete = await _context.AnhComBos.FirstOrDefaultAsync(a => a.IdAnh == imageId);
                        if (anhToDelete != null)
                        {
                            var filePath = Path.Combine("wwwroot/HinhAnh", anhToDelete.HinhAnh);
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }
                            _context.AnhComBos.Remove(anhToDelete);
                        }
                    }
                }

                // Thêm ảnh mới nếu có
                if (model.HinhAnhList != null && model.HinhAnhList.Count > 0)
                {
                    foreach (var file in model.HinhAnhList)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                            var filePath = Path.Combine("wwwroot/HinhAnh", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            var anhCombo = new AnhComBo
                            {
                                MaComBo = combo.MaComBo,
                                HinhAnh = fileName
                            };
                            _context.AnhComBos.Add(anhCombo);
                        }
                    }
                }

                // Xóa các chi tiết combo cũ nếu bấm nút xóa trong view
                var oldCtComBos = _context.CtComBos.Where(ct => ct.MaComBo == id).ToList();
                foreach (var oldCtComBo in oldCtComBos)
                {
                    var newProduct = model.SanPhamList.FirstOrDefault(sp => sp.MaSp == oldCtComBo.MaSp);
                    //kiểm tra xem chi tiết combo có bấm xóa hay không 
                    if (newProduct == null || newProduct.IsSelected)
                    {
                        _context.CtComBos.Remove(oldCtComBo);
                    }
                    else
                    {
                        oldCtComBo.SoLuong = newProduct.SoLuong;
                        oldCtComBo.DonGia = newProduct.GiaBan;
                        oldCtComBo.TenMau = newProduct.TenMau;
                        oldCtComBo.TenKichThuoc = newProduct.TenKichThuoc;
                        oldCtComBo.TenChatLieu = newProduct.TenChatLieu;
                    }
                }
                // thêm mấy sản phẩm được chọn thêm vào chi tiết cb
                foreach (var sp in model.SanPhamList)
                {
                    if (sp.IsSelected)
                    {
                        var chiTiet = new CtComBo
                        {
                            MaComBo = id,
                            MaSp = sp.MaSp,
                            SoLuong = sp.SoLuong,
                            DonGia = sp.GiaBan,
                            TenMau = sp.TenMau,
                            TenKichThuoc = sp.TenKichThuoc,
                            TenChatLieu = sp.TenChatLieu
                        };
                        _context.CtComBos.Add(chiTiet);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        public async Task<IActionResult> Details(int id)
        {
            var combo = await _context.ComBos
                .Include(c => c.CtComBos)
                .ThenInclude(ct => ct.MaSpNavigation)
                .Include(c => c.AnhComBos)
                .FirstOrDefaultAsync(c => c.MaComBo == id);

            if (combo == null)
            {
                return NotFound();
            }

            var viewModel = new ComboDetailViewModel
            {
                MaComBo = combo.MaComBo,
                TenComBo = combo.TenComBo,
                SoLuong = combo.SoLuong,
                DonGia = combo.DonGia,
                MoTa = combo.MoTa,
                SanPhamList = combo.CtComBos.Select(ct => new SanPhamComBoViewModel
                {
                    MaSp = ct.MaSp,
                    TenSp = ct.MaSpNavigation?.TenSp ?? "N/A",
                    SoLuong = ct.SoLuong,
                    GiaBan = ct.DonGia,
                    TenMau = ct.TenMau, 
                    TenKichThuoc = ct.TenKichThuoc, 
                    TenChatLieu = ct.TenChatLieu,
                    IsSelected = true
                }).ToList(),
                AnhComBos = combo.AnhComBos.Select(a => new AnhComBo
                {
                    IdAnh = a.IdAnh,
                    HinhAnh = a.HinhAnh
                }).ToList()
            };

            return PartialView("_DetailPartial", viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var combo = await _context.ComBos.FindAsync(id);
            if (combo == null)
            {
                return NotFound();
            }
            // xóa chi tiết cb trước
            var ctComBoItems = _context.CtComBos.Where(p => p.MaComBo == id);
            _context.CtComBos.RemoveRange(ctComBoItems); 
            _context.ComBos.Remove(combo); 
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 
        }
        

    }
}
using ASMCshrp4_12345.Models;
using ASMCshrp4_12345.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASMCshrp4_12345.Repository.Components
{
    public class ThuocTinhSanPhamViewComponent : ViewComponent
    {
        private readonly Csharp4Context _context;
        public ThuocTinhSanPhamViewComponent(Csharp4Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listmausac = _context.Mausacs.ToList();
            var listkichthuoc = _context.Kichthuocs.ToList();
            var listchatlieu = _context.Chatlieus.ToList();
            var thuoctinh = new ThuocTinhSanPham
            {
                mausacs = listmausac,
                chatlieus = listchatlieu,
                kichthuocs = listkichthuoc,
            };
            return View(thuoctinh);
        }
    }
}

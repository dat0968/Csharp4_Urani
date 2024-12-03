using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASMCshrp4_12345.Repository.Components
{
    public class SanPhamTheoComBoViewComponent : ViewComponent
    {
        private readonly Csharp4Context db;
        public SanPhamTheoComBoViewComponent(Csharp4Context db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listCombo = db.ComBos.Include(p => p.AnhComBos).Include(p => p.CtComBos).ThenInclude(p => p.MaSpNavigation).Take(4).ToList();
            return View(listCombo);
        }
    }
}

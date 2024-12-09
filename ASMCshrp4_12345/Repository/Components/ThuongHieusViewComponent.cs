using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASMCshrp4_12345.Repository.Components
{
    public class ThuongHieusViewComponent : ViewComponent
    {
        private readonly Csharp4Context _context;

        public ThuongHieusViewComponent(Csharp4Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var thuongHieus = await _context.Thuonghieus.Where(p => p.IsDelete == false).ToListAsync();
            return View(thuongHieus);
        }
    }
}

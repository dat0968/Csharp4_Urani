using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ASMCshrp4_12345.Repository.Components
{
    public class MausViewComponent : ViewComponent
    {
        private readonly Csharp4Context _context;
        public MausViewComponent(Csharp4Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Mausacs.ToListAsync());
    }
}

using ASMCshrp4_12345.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASMCshrp4_12345.Repository.Components
{
    public class KichThuocsViewComponent : ViewComponent
    {
        private readonly Csharp4Context _context;

        public KichThuocsViewComponent(Csharp4Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Kichthuocs.ToListAsync());
    }
}

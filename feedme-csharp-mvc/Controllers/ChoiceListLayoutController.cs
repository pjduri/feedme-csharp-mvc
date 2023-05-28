using feedme_csharp_mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace feedme_csharp_mvc.Controllers
{
    public class ChoiceListLayoutController : Controller
    {
        private readonly FeedMeDbContext _context;

        public ChoiceListLayoutController(FeedMeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return _context.ChoiceListLayouts != null ?
                        View(await _context.ChoiceListLayouts.ToListAsync()) :
                        Problem("Entity set 'FeedMeDbContext.ChoiceListLayouts'  is null.");
        }
    }
}

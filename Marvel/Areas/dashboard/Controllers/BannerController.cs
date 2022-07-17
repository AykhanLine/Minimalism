using Marvel.Data;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class BannerController : Controller
    {
      
        private readonly ApplicationDbContext _context;

        public BannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

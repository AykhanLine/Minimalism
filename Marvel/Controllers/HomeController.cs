using Marvel.Data;
using Marvel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            var stylish = _context.Stylishes.FirstOrDefault();
            var service = _context.Services.ToList();
            var callout = _context.Callouts.FirstOrDefault();
            var portfolios = _context.Portfolios.ToList();
            var calltoact = _context.CallToActs.FirstOrDefault();


            HomeVM vm = new()
            {
                Banner = banner,
                Stylish = stylish,
                Services = service,
                Callout = callout,
                Portfolio = portfolios,
                CallToAct = calltoact

            };


            return View(vm);
        }
    }
}

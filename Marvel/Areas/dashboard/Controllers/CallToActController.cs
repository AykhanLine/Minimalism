using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    public class CallToActController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CallToActController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var callings = _context.CallToActs.FirstOrDefault();
            return View(callings);
        }

        public IActionResult Create()
        {
            var callings = _context.CallToActs.FirstOrDefault();

            if (callings != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]

        public IActionResult Create(CallToAct callings)
        {
          
            _context.CallToActs.Add(callings);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var callings = _context.CallToActs.FirstOrDefault(x => x.Id == id);
            if (callings == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(CallToAct callings)
        {
            if (callings == null)
            {
                return RedirectToAction("Index");
            }
            _context.CallToActs.Remove(callings);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var callings = _context.CallToActs.FirstOrDefault(x => x.Id == id);
            if (callings == null)
            {
                return NotFound();
            }
            return View(callings);
        }

        [HttpPost]
        public IActionResult Edit(CallToAct callings)
        {
            
            _context.CallToActs.Update(callings);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

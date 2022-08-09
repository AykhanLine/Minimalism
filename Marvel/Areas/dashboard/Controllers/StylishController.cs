using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    public class StylishController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StylishController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var stylish = _context.Stylishes.FirstOrDefault();
            return View(stylish);
        }

        public IActionResult Create()
        {
            var stylish = _context.Stylishes.FirstOrDefault();

            if(stylish != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]

        public IActionResult Create(Stylish stylish)
        {
            if (stylish == null)
            {
                return RedirectToAction("Index");
            }

            _context.Stylishes.Add(stylish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {


            var stylish = _context.Stylishes.FirstOrDefault(x => x.Id == id);
            if (stylish == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]

        public IActionResult Delete(Stylish Stylish)
        {
            if (Stylish == null)
            {
                return RedirectToAction("Index");
            }
            _context.Stylishes.Remove(Stylish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Detail(int id)
        {


            if (id == null)
            {
                return NotFound();
            }
            var stylish = _context.Stylishes.FirstOrDefault(x => x.Id == id);
            if (stylish == null)
            {
                return NotFound();
            }
            return View(stylish);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var stylish = _context.Stylishes.FirstOrDefault(x => x.Id == id);
            if (stylish == null)
            {
                return NotFound();
            }
            return View(stylish);
        }

        [HttpPost]

        public IActionResult Edit(Stylish stylish)
        {
            if (stylish == null)
            {
                return RedirectToAction("Index");
            }
            _context.Stylishes.Update(stylish);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var service = _context.Services.ToList();
            return View(service);
        }

        public IActionResult Create()
        {
            var service = _context.Services.ToList();
            if(service == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]

        public IActionResult Create(Service service)
        {
            if(service == null)
            {
                return RedirectToAction("Index");
            }

            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var service = _context.Services.FirstOrDefault(x => x.Id == id);
            if(service == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Service service)
        {
            if(service == null)
            {
                return RedirectToAction("Index"); 
            }
            _context.Services.Remove(service);
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
            var service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = _context.Services.FirstOrDefault(x => x.Id == id);
            if(service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost]

        public IActionResult Edit(Service service)
        {
            if (service == null)
            {
                return RedirectToAction("Index");
            }
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

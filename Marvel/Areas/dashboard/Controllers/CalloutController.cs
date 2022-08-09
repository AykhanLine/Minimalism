using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    public class CallOutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CallOutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var callout = _context.Callouts.FirstOrDefault();
            return View(callout);
        }

        public IActionResult Create()
        {
            var callout = _context.Callouts.FirstOrDefault();
            if (callout != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]

        public IActionResult Create(Callout callout, IFormFile NewPhoto)
        {
            var fileExtation = Path.GetExtension(NewPhoto.FileName);
            if (fileExtation != ".jpg")
            {
                ViewBag.PhotoError = "Only photos";
                return View();
            }
            var MyPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", MyPhoto);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                NewPhoto.CopyTo(stream);
            }
            callout.PhotoURL = "/img/" + MyPhoto;
            _context.Callouts.Add(callout);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var callout = _context.Callouts.FirstOrDefault(x => x.Id == id);
            if (callout == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]

        public IActionResult Delete(Callout callout)
        {
            if (callout == null)
            {
                return RedirectToAction("Index");
            }
            _context.Callouts.Remove(callout);
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

            var callout = _context.Callouts.FirstOrDefault(x => x.Id == id);
            if (callout == null)
            {
                return NotFound();
            }
            return View(callout);
        }

        


        [HttpPost]
        public IActionResult Edit( Callout callout, IFormFile NewPhoto, string? oldPhoto)
        {
            if (NewPhoto != null)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                //get url
                string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", imageName);
                using (var fs = new FileStream(savePath, FileMode.Create))
                {
                    NewPhoto.CopyTo(fs);
                }
                callout.PhotoURL = "/img/" + imageName;
            }
            else
            {
                callout.PhotoURL = oldPhoto;
            }
            _context.Callouts.Update(callout);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

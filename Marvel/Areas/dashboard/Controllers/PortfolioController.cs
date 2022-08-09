using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var portfolio = _context.Portfolios.ToList();
            return View(portfolio);
        }

        public IActionResult Create()
        {
            var portfolio = _context.Portfolios.ToList();
            if (portfolio == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]

        public IActionResult Create(Portfolio portfolio, IFormFile NewPhoto)
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
            portfolio.PhotoURL = "/img/" + MyPhoto;
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Portfolio portfolio)
        {
            if (portfolio == null)
            {
                return RedirectToAction("Index");
            }
            _context.Portfolios.Remove(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }

        [HttpPost]
        public IActionResult Edit(Portfolio portfolio, IFormFile NewPhoto, string? oldPhoto)
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
                portfolio.PhotoURL = "/img/" + imageName;
            }
            else
            {
                portfolio.PhotoURL = oldPhoto;
            }
            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}

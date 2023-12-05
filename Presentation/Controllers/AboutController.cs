using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _aboutService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            ViewBag.Image = value.ExistImage;
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about, IFormFile aboutImage)
        {
            if (aboutImage != null && aboutImage.Length > 0)
            {
                // Dosya adını ve yolunu oluşturun
                var fileName = Path.GetFileName(aboutImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Dosyayı kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    aboutImage.CopyTo(stream);
                }

                // Dosya yolunu veritabanına kaydedin veya Product nesnesine atayın
                about.ExistImage = "/images/" + fileName; // Örnek olarak dosyanın wwwroot/images altında olduğunu varsayalım
            }
            else
            {
                Context c = new Context();
                about.ExistImage = c.Abouts.Find(about.AboutID).ExistImage;
            }

            AboutValidator validationRules = new AboutValidator();
            ValidationResult result = validationRules.Validate(about);
            if (result.IsValid)
            {


                _aboutService.TUpdate(about);

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
    }
}

using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	public class ContactAboutController : Controller
	{
		private readonly IContactAboutService _contactAboutService;

		public ContactAboutController(IContactAboutService contactAboutService)
		{
			_contactAboutService = contactAboutService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var values = _contactAboutService.TGetList();
			return View(values);
		}

        [HttpGet]
        public IActionResult UpdateContactAbout(int id = 1)
        {
            var value = _contactAboutService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContactAbout(ContactAbout contactAbout)
        {
            ContactAboutValidator validationRules = new ContactAboutValidator();
            ValidationResult result = validationRules.Validate(contactAbout);
            if (result.IsValid)
            {
                _contactAboutService.TUpdate(contactAbout);
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

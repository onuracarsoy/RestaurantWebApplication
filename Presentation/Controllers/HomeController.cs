using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Presentation.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IAboutService _aboutService;
        private readonly IContactService _contactService;

        public HomeController(ICategoryService categoryService, IProductService productService, IAboutService aboutService, IContactService contactService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _aboutService = aboutService;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var values = _productService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var values = _productService.ProductListWithCategory(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult About(int id = 1)
        {
            var value = _aboutService.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult Contact(int id = 1)
        {
            var value = _contactService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {

            ContactValidator validationRules = new ContactValidator();
            ValidationResult result = validationRules.Validate(contact);
            if (result.IsValid)
            {
                contact.Date= DateTime.Now;
                _contactService.TInsert(contact);
                return RedirectToAction("All","Home");
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
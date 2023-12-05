using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Presentation.Models;


namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(IContactService contactService, ICategoryService categoryService, IProductService productService, UserManager<AppUser> userManager)
        {
            _contactService = contactService;
            _categoryService = categoryService;
            _productService = productService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int contactCount = _contactService.ContactCount();
            ViewBag.ContactCount = contactCount;

            int categoryCount = _categoryService.CategoryCount();
            ViewBag.CategoryCount = categoryCount;
            
            int productCount = _productService.ProductCount();
            ViewBag.ProductCount = productCount;


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Admins()
        {
            

            List<AppUser> users = await _userManager.Users.ToListAsync();
            return View(users);
 
        }

        public async Task<IActionResult> DeleteAdmin(string id)
        {
            var value = await _userManager.FindByIdAsync(id);
         

         
            await _userManager.DeleteAsync(value);
            return RedirectToAction("Admins","Admin");

        }

    }
}

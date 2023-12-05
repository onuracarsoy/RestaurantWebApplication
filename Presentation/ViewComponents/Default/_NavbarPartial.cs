using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.ViewComponents.Default
{
    public class _NavbarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _NavbarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        //[HttpGet]
        //public async IViewComponentResult Invoke()
        //{
        //    var values =await _userManager.FindByNameAsync(User.Identity.Name);
        //    UserDetailsViewModel model = new UserDetailsViewModel();
        //    model.Name = values.Name;
        //    model.Surname = values.Surname;

        //    return View();
        //}

        public IViewComponentResult Invoke()
        {
            // Asenkron işlemleri çağırmak için bir Task.Run kullanabilirsiniz.
            var model = Task.Run(async () =>
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                UserDetailsViewModel userDetails = new UserDetailsViewModel
                {
                    Name = values.Name,
                    Surname = values.Surname
                };
                return userDetails;
            }).GetAwaiter().GetResult();

            return View(model);
        }
    }
}

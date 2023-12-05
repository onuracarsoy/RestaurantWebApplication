using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Default
{
    public class _HNavbarPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

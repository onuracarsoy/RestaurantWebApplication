using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Default
{
    public class _HHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

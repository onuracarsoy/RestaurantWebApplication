using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Default
{
    public class _SidebarPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _SidebarPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IViewComponentResult Invoke()
        {

            var values = _categoryService.TGetList();


            return View(values);
        }
    }
}

using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Default
{
	public class _HAboutEntryPartial : ViewComponent
    {
        private readonly IAboutService _AboutService;

        public _HAboutEntryPartial(IAboutService aboutService)
        {
            _AboutService = aboutService;
        }

        [HttpGet]
		public IViewComponentResult Invoke(int id=1)
		{
            var value = _AboutService.TGetById(id);
            return View(value);
        }
	}
}

using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Default
{
	public class _HContactAboutExistPartial : ViewComponent
	{
		private readonly IContactAboutService _contactAboutService;

		public _HContactAboutExistPartial(IContactAboutService contactAboutService)
		{
			_contactAboutService = contactAboutService;
		}
		[HttpGet]
		public IViewComponentResult Invoke()
		{
			var values = _contactAboutService.TGetList();
			return View(values);
		}
	}
}

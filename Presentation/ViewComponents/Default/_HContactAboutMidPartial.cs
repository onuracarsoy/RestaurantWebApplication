using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Default
{
	public class _HContactAboutMidPartial : ViewComponent
	{
		private readonly IContactAboutService _contactAboutService;

		public _HContactAboutMidPartial(IContactAboutService contactAboutService)
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

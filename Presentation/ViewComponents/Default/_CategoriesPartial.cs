using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Default
{
	public class _CategoriesPartial : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public _CategoriesPartial(ICategoryService categoryService)
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

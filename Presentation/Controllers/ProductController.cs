using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Presentation.Models;
using System.Drawing.Text;
using X.PagedList;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var values = _productService.GetListWithCategory().ToPagedList(page, 7);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {


            List<SelectListItem> categoryValues = _categoryService.TGetList()
              .Select(x => new SelectListItem
              {
                  Text = x.CategoryName,
                  Value = x.CategoryID.ToString()
              })
               .ToList();

            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile productImage)
        {
            if (productImage != null && productImage.Length > 0)
            {
                // Dosya adını ve yolunu oluşturun
                var fileName = Path.GetFileName(productImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Dosyayı kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productImage.CopyTo(stream);
                }

                // Dosya yolunu veritabanına kaydedin veya Product nesnesine atayın
                product.ProductImage = "/images/" + fileName; // Örnek olarak dosyanın wwwroot/images altında olduğunu varsayalım
            }



            List<SelectListItem> categoryValues = _categoryService.TGetList()
                      .Select(x => new SelectListItem
                      {
                          Text = x.CategoryName,
                          Value = x.CategoryID.ToString()
                      })
                       .ToList();

            ViewBag.CategoryValues = categoryValues;



            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(product);
            if (result.IsValid)
            {




                _productService.TInsert(product);
                return RedirectToAction("Index");
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

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
         

            List<SelectListItem> categoryValues = _categoryService.TGetList()
              .Select(x => new SelectListItem
              {
                  Text = x.CategoryName,
                  Value = x.CategoryID.ToString()
              })
               .ToList();

            ViewBag.CategoryValues = categoryValues;
            var value = _productService.TGetById(id);
            ViewBag.Image = value.ProductImage;
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product, IFormFile productImage)
        {



            if (productImage != null && productImage.Length > 0)
            {
                // Dosya adını ve yolunu oluşturun
                var fileName = Path.GetFileName(productImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Dosyayı kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productImage.CopyTo(stream);
                }

                // Dosya yolunu veritabanına kaydedin veya Product nesnesine atayın
                product.ProductImage = "/images/" + fileName; // Örnek olarak dosyanın wwwroot/images altında olduğunu varsayalım
            }
            else 
            {
                Context c = new Context();
                product.ProductImage = c.Products.Find(product.ProductID).ProductImage;
            }
       


            List<SelectListItem> categoryValues = _categoryService.TGetList()
                  .Select(x => new SelectListItem
                  {
                      Text = x.CategoryName,
                      Value = x.CategoryID.ToString()
                  })
                   .ToList();

            ViewBag.CategoryValues = categoryValues;

            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(product);
         
            if (result.IsValid)
            {


                _productService.TUpdate(product);
                return RedirectToAction("Index");
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


        [HttpGet]
        public IActionResult DetailsProduct(int id)
        {
            var value = _productService.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult Index2(int id = 1)
        {
            var values = _productService.ProductListWithCategory(id);
            return View(values);
        }
    }
}

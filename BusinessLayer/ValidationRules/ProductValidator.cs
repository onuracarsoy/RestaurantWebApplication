using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez!");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz!");

            RuleFor(x => x.ProductImage).NotEmpty().WithMessage("Ürün resmi boş geçilemez!");

            RuleFor(x => x.ProductContent).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.ProductContent).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz!");
            RuleFor(x => x.ProductContent).MaximumLength(500).WithMessage("Lütfen en az 500 karakter giriniz!");

            RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Fiyat boş geçilemez!");

            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori boş geçilemez!");
        }
    }
}

using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.EntryTitle).NotEmpty().WithMessage("Giriş başlığı boş geçilemez!");
            RuleFor(x => x.EntryTitle).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
            RuleFor(x => x.EntryTitle).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz!");

            RuleFor(x => x.EntryContent).NotEmpty().WithMessage("Giriş içeriği boş geçilemez!");
            RuleFor(x => x.EntryContent).MinimumLength(10).WithMessage("Lütfen en az 10 karakter giriniz!");
            RuleFor(x => x.EntryContent).MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter giriniz!");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Ana başlık boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz!");


            RuleFor(x => x.Content).NotEmpty().WithMessage("Giriş içeriği boş geçilemez!");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Lütfen en az 10 karakter giriniz!");
            RuleFor(x => x.Content).MaximumLength(800).WithMessage("Lütfen en fazla 800 karakter giriniz!");

            RuleFor(x => x.ExistImage).NotEmpty().WithMessage("Bitiş resmi boş geçilemez!");

            RuleFor(x => x.ExistTitle).NotEmpty().WithMessage("Bitiş başlığı boş geçilemez!");
            RuleFor(x => x.ExistTitle).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
            RuleFor(x => x.ExistTitle).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz!");


            RuleFor(x => x.ExistContent).NotEmpty().WithMessage("Bitiş içeriği boş geçilemez!");
            RuleFor(x => x.ExistContent).MinimumLength(10).WithMessage("Lütfen en az 10 karakter giriniz!");
            RuleFor(x => x.ExistContent).MaximumLength(350).WithMessage("Lütfen en fazla 350 karakter giriniz!");
        }
    }
}

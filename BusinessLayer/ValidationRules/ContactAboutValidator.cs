using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactAboutValidator : AbstractValidator<ContactAbout>
	{
		public ContactAboutValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
			RuleFor(x => x.Title).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
			RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz!");

			RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");
			RuleFor(x => x.Description).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz!");
			RuleFor(x => x.Description).MaximumLength(300).WithMessage("Lütfen en fazla 300 karakter giriniz!");

			RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş geçilemez!");
			RuleFor(x => x.Address).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz!");
			RuleFor(x => x.Address).MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter giriniz!");

			RuleFor(x => x.GoogleAddress).NotEmpty().WithMessage("Google Adresi boş geçilemez!");

			RuleFor(x => x.Phone).NotEmpty().WithMessage("Açıklama boş geçilemez!");
			RuleFor(x => x.Phone).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
			RuleFor(x => x.Phone).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz!");

			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez!");
			RuleFor(x => x.Mail).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz!");
			RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter giriniz!");
			RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir mail giriniz!");
		}
	}
}

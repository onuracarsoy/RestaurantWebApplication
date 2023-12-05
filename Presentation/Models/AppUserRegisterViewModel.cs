using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class AppUserRegisterViewModel
    {
        [Required(ErrorMessage = "Ad kısmı boş geçilemez!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad kısmı boş geçilemez!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcıadı kısmı boş geçilemez!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre kısmı boş geçilemez!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tekrar şifre kısmı boş geçilemez!")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}

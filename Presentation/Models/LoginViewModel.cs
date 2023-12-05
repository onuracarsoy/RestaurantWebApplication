using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "kullanıcıadı giriniz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre giriniz!")]
        public string Password { get; set; }
    }
}

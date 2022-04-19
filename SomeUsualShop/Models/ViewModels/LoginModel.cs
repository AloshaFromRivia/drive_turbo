using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SomeUsualShop.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Требуется ввести почту")]
        [DisplayName("Адрес почты")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Требуется ввести пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set;}
    }
}
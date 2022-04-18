using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SomeUsualShop.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Требуется ввести логин")]
        [DisplayName("Логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Требуется ввести пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set;}
    }
}
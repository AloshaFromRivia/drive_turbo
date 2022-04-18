using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SomeUsualShop.Models.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Отсутствует имя пользователя")]
        [DisplayName("Имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Отсутствует пароль")]
        [MinLength(5)]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Отсутствует почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}
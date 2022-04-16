using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SomeUsualShop.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        [BindNever]
        public ICollection<CartItem> Items { get; set; }
        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Имя не должно быть пустым")]
        public string Name { get; set; }
        [DisplayName("Город")]
        [Required(ErrorMessage = "Город не должен быть пустым")]
        public string City { get; set; }
        [DisplayName("Адрес")]
        [Required(ErrorMessage = "Адрес не должен быть пустым")]
        public string Line { get; set; }
        [DisplayName("Почтовый индекс")]
        [Required(ErrorMessage = "Почтовый индекс не должен быть пустым")]
        public string Zip { get; set; }
    }
}
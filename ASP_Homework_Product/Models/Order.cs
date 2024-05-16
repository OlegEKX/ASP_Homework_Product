using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public enum OrderStatuses
    {
		Created,
		Processed,
		Delivering,
		Delivered,
		Canceled
	}

    public class Order
    {
        public Guid Id { get; set; }
        public Basket Basket { get; set; }
        [Required(ErrorMessage = "Не указаны имя, фамилия и отчество")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Введите имя, фамилию им отчество полностью")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введит номер телефона")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Введите адрес доставки")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Введите адрес полностью")]
        public string Address { get; set; }
        public string Comment { get; set; }

        public DateTime DateTime { get; set; }
        public OrderStatuses OrderStatus { get; set; }
    }
}

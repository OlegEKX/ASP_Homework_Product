using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
	public class Register
	{
		[Required(ErrorMessage = "Не указан email")]
		[EmailAddress(ErrorMessage = "Укажите верный email")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Введите пароль")]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "Введите валидный пароль (не менее 4 символов и не болеее 20)")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Второй пароль должен быть указан")]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "Введите валидный пароль (не менее 4 символов и не болеее 20)")]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string ConfirmPassword { get; set; }
	}
}

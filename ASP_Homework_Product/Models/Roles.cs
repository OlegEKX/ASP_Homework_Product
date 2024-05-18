using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
	public class Roles
	{
		[Required(ErrorMessage = "Заполните название добавляемой роли")]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Длина новой роли должна быть более 3 символов и менее 20")]
		public string Name { get; set; }

		public Roles()
		{ }

		public Roles(string name)
		{
			Name = Name;
		}
	}
}

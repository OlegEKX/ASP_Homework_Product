using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
	public class ProductEdit
	{
		[Required(ErrorMessage = "Заполните название товара")]
		[StringLength(30, MinimumLength = 4, ErrorMessage = "Длина названия должна быть от 4 до 30 символов")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Заполните поле для цены")]
		[Range(100, 1000000, ErrorMessage = "Цена должжна иметь диапазон от 100 до 1 000 000")]
		public int Cost { get; set; }

		[Required(ErrorMessage = "Пару слов о товаре")]
		[StringLength(300, MinimumLength = 20, ErrorMessage = "Длина описания должна быть от 20 до 300 символов")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Обязательно для вставки картинки в карту продукта")]
		
		public string ImageURL { get; set; }

		public int Id { get; set; }

		public ProductEdit()
		{

		}

		public ProductEdit(string name, int cost, string description, string imageURL, int id)
		{
			Name = name;
			Cost = cost;
			Description = description;
			ImageURL = imageURL;
			Id = id;
		}
	}
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class Login
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Укажите верный email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Введите валидный пароль (не менее 4 символов и не болеее 20)")]
        public string Password { get; set; }

        /*[Required(ErrorMessage = "Второй пароль должен быть указан")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string RepeatPassword { get; set; }*/

        //[Range(12, 50, ErrorMessage = "Что-то для возраста")] (ПРИМЕР ЕСЛИ БУДЕТ ПРИСУТСТОВАВАТЬ ВОЗРАСТ В РЕГИСТРАЦИИ)
        public string CheckBox { get; set; }
        public bool RememberMe 
        {
            get
            {
                if (CheckBox == "on")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

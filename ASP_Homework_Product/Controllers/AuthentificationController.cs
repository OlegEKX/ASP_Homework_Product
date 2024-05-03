using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class AuthentificationController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(User UserData)
        {
            return Redirect("/Home/Index");
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult AddNewUser(User userData)
        {
            if (userData.Login == userData.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
				return Redirect("/Home/Index");
			}
			return Redirect("/Home/Index");
			//return Redirect("/Home/Index");
		}
    }
}

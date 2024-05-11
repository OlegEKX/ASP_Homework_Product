using ASP_Homework_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Homework_Product.Controllers
{
    public class AuthentificationController : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(Login UserData)
        {
            if (ModelState.IsValid)
            {
				return Redirect("/Home/Index");
			}

            return RedirectToAction("Login");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(Register userData)
        {
			if (userData.UserName == userData.Password)
			{
				ModelState.AddModelError("", "Логин и пароль не должны совпадать");
			}

			if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Registration");


			//return Redirect("/Home/Index");
		}
    }
}

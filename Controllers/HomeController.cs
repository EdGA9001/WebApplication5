using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsernameModel userFileModel = new UsernameModel();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUsername(string username, string password)
        {
            var result = userFileModel.Register(username, password);

            if (!result)
            {
                return Json(new { success = false, message = "Username already exists or you left a feild empty." });
            }

            return Json(new { success = true, message = "You're registered!" });
        }

        [HttpPost]
        public IActionResult ValidateUser(string username, string password)
        {
            var isValid = userFileModel.ValidateUser(username, password);

            if (isValid)
            {
                return Json(new { success = true, message = "Welcome, " + username + "!" });
            }

            else
            {
                return Json(new { success = false, message = "Could not find username or password. Please try again." });
            }
        }
    }
}
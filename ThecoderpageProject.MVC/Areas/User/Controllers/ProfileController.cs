using Microsoft.AspNetCore.Mvc;

namespace ThecoderpageProject.MVC.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

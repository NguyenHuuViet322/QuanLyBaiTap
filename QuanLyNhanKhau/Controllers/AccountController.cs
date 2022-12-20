using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhanKhau.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
    }
}

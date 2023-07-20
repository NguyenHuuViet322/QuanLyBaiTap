using Microsoft.AspNetCore.Mvc;
using QuanLyTruongHoc.Models.Utils;
using QuanLyTruongHoc.Models;


namespace QuanLyNhanKhau.Controllers
{
    public class AccountController : Controller
    {
        private readonly QuanLyTruongHocConText _context;

        public AccountController (QuanLyTruongHocConText context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login(string username, string password)
        {
            var user = _context.accounts.FirstOrDefault(p => p.username == username && p.password == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.IdUser);
                HttpContext.Session.SetInt32("role", user.Role);

                return RedirectToAction("Index", "Home");
            }
            if (username == Constance.usernameAdmin && password == Constance.passwordAdmin)
            {
                HttpContext.Session.SetInt32("id", 0);
                HttpContext.Session.SetInt32("role", 5);
                return RedirectToAction("Index", "Home");
            }
            else return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account");
        }
    }
}

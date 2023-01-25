using Microsoft.AspNetCore.Mvc;
using QuanLyNhanKhau.Models;

namespace QuanLyNhanKhau.Controllers
{
    public class AccountController : Controller
    {
        private readonly QuanLyNhanKhauConText _context;

        public AccountController (QuanLyNhanKhauConText context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login(string CMND, string password)
        {
            try
            {
                if (CMND == "0") return View("Login");

                var account = _context.accounts.Where(p => p.CMND == CMND).FirstOrDefault();
                
                if (account.Password == password && account.role == (int)Role.Dan)
                {
                    account.nhanKhau = _context.nhanKhaus.Where(p => p.IdNhanKhau == account.nhanKhauId).FirstOrDefault();
                    HttpContext.Session.SetInt32("id", (int)account.nhanKhauId);
                    HttpContext.Session.SetString("name", account.nhanKhau.HoTen);
                    HttpContext.Session.SetInt32("role", account.role);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    HttpContext.Session.SetInt32("id", -1);
                    HttpContext.Session.SetString("name", "Nguyễn Hữu Việt");
                    HttpContext.Session.SetInt32("role", account.role);
                    return RedirectToAction("Index", "Home");
                }    
            } catch (NullReferenceException)
            {
                return View("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using QuanLyNhanKhau.Models;
using System.Diagnostics;

namespace QuanLyNhanKhau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //if (HttpContext.Session.GetString("name") == null) 
            //    return RedirectToAction("Index", "Account");
            //else 
                return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using QuanLyTruongHoc.Models;
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
            if (HttpContext.Session.GetInt32("role") == null)
                return RedirectToAction("Index", "Account");
            return View();
        }

        public IActionResult Error(string message)
        {
            ErrorViewModel modelViewError = new ErrorViewModel(message);
            return View(modelViewError);
        }

        public IActionResult Error_list(List<string> error)
        {
            ErrorViewModel modelViewError = new ErrorViewModel(error);
            return View("Error", modelViewError);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace WebApplication20.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}

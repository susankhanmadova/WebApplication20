using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication20.DAL;


namespace WebApplication20.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}

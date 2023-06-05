using aspnet02_boardapp.Data;
using aspnet02_boardapp.Models;
using aspnet03_portfolioWebApp.Logics;
using aspnet03_portfolioWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspnet02_boardapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // SELECT * FROM portfolios WHERE Division = 'PORTFOLIO';
            var model = _db.Portfolios.Where(q => q.Division == "PORTFOLIO").ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MailSend(string name, string phonenumber, string email, string message)
        {
            MailSender.SendMail(email, name, phonenumber, message, message);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
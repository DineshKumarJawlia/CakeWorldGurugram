using CakeWorldGurugram.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CakeWorldGurugram.Controllers
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
            return View("~/Views/Home/Index.cshtml");
        }

		public IActionResult Docx(string FileName)
		{
            string view = string.Empty;

            if(FileName == "TermsConditions")
			{
				view = "~/Views/Home/Terms.cshtml";
			}
            else if(FileName == "PrivacyPolicy")
			{
				view = "~/Views/Home/Privacy.cshtml";
			}

            return View(view);
		}

		[HttpGet]
		public IActionResult ContactUs()
		{
			return View("~/Views/Home/ContactUs.cshtml");
		}

        [HttpPost]
		public IActionResult ContactUs(string Name, string Email, string Message)
		{
			return View("~/Views/Home/ContactUs.cshtml");
		}

		public IActionResult DesignDevelopBy()
        {
            return View("~/Views/Home/DesignDevelopBy.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
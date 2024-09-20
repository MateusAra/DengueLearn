using DengueLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DengueLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? videoId)
        {
            string iframe = "";

            switch (videoId)
            {
                case "1":
                    iframe = "<iframe width=\"600\" height=\"355\" src=\"https://www.youtube.com/embed/LopVIUrshf8?si=mS0BCjotWNGe_71v\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>";
                    break;
                case "2":
                    iframe = "<iframe width=\"600\" height=\"355\" src=\"https://www.youtube.com/embed/HuNQI8U6MfU?si=XBTtIuWg2dBcq-h0\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>";
                    break;
                case "3":
                    iframe = "<iframe width=\"600\" height=\"355\" src=\"https://www.youtube.com/embed/yw9YMvtGmgk?si=OOjU6kUppHboglD3\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>";
                    break;
                case "4":
                    iframe = "<iframe width=\"600\" height=\"355\" src=\"https://www.youtube.com/embed/1QZR5De4f9E?si=wFcfceQy4pG9rNn7\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>";
                    break;
                default:
                    iframe = "<iframe width=\"600\" height=\"355\" src=\"https://www.youtube.com/embed/LopVIUrshf8?si=mS0BCjotWNGe_71v\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>";
                    break;
            }

            var model = new HomeModel()
            {
                Iframe = iframe
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SecurityApp.DAL;
using SecurityApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace SecurityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IManufacturer _manufactureService;

        public HomeController(ILogger<HomeController> logger, IManufacturer manufactureService)
        {
            _logger = logger;
            _manufactureService = manufactureService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> List(string id = "",string filter = "",[FromQuery] string Search = "")
        {
            int _pageNumber = 1;
            string _filter = "";

            bool isId = false;
            if (!string.IsNullOrEmpty(id)) 
            {
                isId = int.TryParse(id, out int result);
                if (isId) {_pageNumber = result; _filter = filter;}
                else _filter = id;
            }

            return View(await _manufactureService.getList(_pageNumber,filter, Search));
        }

        public IActionResult Details()
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
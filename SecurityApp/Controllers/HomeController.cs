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

        public async Task<IActionResult> List(int id = -1,string filter = "",[FromQuery] string Search = "", [FromQuery] int PageNumber = 1)
        {
            var resultData = await _manufactureService.getList(PageNumber, id, Search);
            return View(resultData);
        }

        public async  Task<IActionResult> Details(int cbdId, int manufacturerId)
        {
            var resultData = await _manufactureService.getManufacturersDetails(cbdId, manufacturerId);
            return View(resultData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
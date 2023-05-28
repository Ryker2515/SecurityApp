using Microsoft.AspNetCore.Mvc;
using SecurityApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace SecurityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
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



            var apiUrl = $"http://localhost:5263/api/WeatherForecast/GetManufacturersData?PageNumber={_pageNumber}" +
                         $"&Filter={filter}&SearchText={Search}"; // Replace with your API URL

            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //return Ok(content);
                var manufacturerDto1 = JsonSerializer.Deserialize<List<ManufacturerDto>>(content);
                return View(manufacturerDto1);
            }

            //return StatusCode((int)response.StatusCode);

            List<ManufacturerDto> manufacturerDto = new List<ManufacturerDto>();

            return View(manufacturerDto);
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
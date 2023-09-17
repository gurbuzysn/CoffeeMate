using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Interfaces;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeViewModelService _homeViewModelService;

        public HomeController(ILogger<HomeController> logger, IHomeViewModelService homeViewModelService)
        {
            _logger = logger;
            _homeViewModelService = homeViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public async  Task<IActionResult> Product()
        {
            var products = await _homeViewModelService.GetHomeViewModelAsync();

            return View(products);
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
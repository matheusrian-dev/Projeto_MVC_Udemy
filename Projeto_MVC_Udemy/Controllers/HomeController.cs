using Microsoft.AspNetCore.Mvc;
using Projeto_LanchesMac_Udemy.Repositories.Interfaces;
using Projeto_LanchesMac_Udemy.ViewModels;
using Projeto_MVC_Udemy.Models;
using System.Diagnostics;

namespace Projeto_MVC_Udemy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }

        public IActionResult Demo()
        {
            return View();
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
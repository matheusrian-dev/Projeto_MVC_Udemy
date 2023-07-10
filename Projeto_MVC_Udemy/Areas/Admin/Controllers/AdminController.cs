using Microsoft.AspNetCore.Mvc;

namespace Projeto_LanchesMac_Udemy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

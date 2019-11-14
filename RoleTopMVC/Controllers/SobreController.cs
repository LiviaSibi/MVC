using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index (){
            ViewData["NomeView"] = "Sobre";
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult Index (){
            ViewData["NomeView"] = "Evento";
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login(){
            
            ViewData["NomeView"] = "Cliente";
            return View();
        }
    }
}
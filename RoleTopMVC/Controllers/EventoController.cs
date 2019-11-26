using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class EventoController : AbstractController
    {
        public IActionResult Index (){
            ViewData["NomeView"] = "Evento";
            return View(new BaseViewModel(){
                NomeView = "Evento",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}
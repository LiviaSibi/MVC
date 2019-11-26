using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class SobreController : AbstractController
    {
        public IActionResult Index (){
            ViewData["NomeView"] = "Sobre";
            return View(new BaseViewModel(){
                NomeView = "Sobre",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}
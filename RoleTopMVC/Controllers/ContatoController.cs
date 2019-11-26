using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class ContatoController : AbstractController
    {
        public IActionResult Index (){
            ViewData["NomeView"] = "Contato";
            return View(new BaseViewModel(){
                NomeView = "Contato",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SENAIzinhoMVC.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        public IActionResult CadastroAluno(IFormCollection form){
            try{
                Aluno aluno = new Aluno(
                    
                )
                return View();
            }

            catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
            }
        }
    }
}
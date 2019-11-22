using System;
using RoleTopMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RoleTopMVC.Controllers
{
    public class AgendaController : Controller
    {
        AgendaRepository agendaRepository = new AgendaRepository();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agendar(IFormCollection form)
        {
            ViewData["Action"] = "Agendamento";

            try{
                return View("Sucesso");
            } 
            catch (Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
    }
}
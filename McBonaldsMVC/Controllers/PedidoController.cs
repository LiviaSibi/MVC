using System;
using McBonaldsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace McBonaldsMVC.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index(){
            return View();
        }
        public IActionResult Registrar(IFormCollection form){
            Pedido pedido = new Pedido();

            Shake shake = new Shake();
            shake.Nome = form["shake"];
            shake.Preco = 0.0;

            Hamburguer hamburguer = new Hamburguer();
            hamburguer.Nome = form["hamburguer"];
            hamburguer.Preco = 0.0;

            ViewData["Action"] = "Pedido";
            
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